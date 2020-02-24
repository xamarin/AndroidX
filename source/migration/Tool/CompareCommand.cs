using Mono.ApiTools;
using Mono.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace AndroidXMigrator
{
	public class CompareCommand : BaseCommand
	{
		private string htmlDiff;
		private string mdDiff;
		private string xmlDiff;
		private bool alwaysResolve;
		private bool excludeNonbreaking;
		private bool excludeParameterNames;
		private bool outputApi;

		public CompareCommand()
			: base("compare", "[FIRST ASSEMBLY] [SECOND ASSEMBLY]", "Compares two .NET assemblies or XML API info files.")
		{
		}

		public List<string> Assemblies { get; } = new List<string>();

		public List<string> Directories { get; } = new List<string>();

		protected override OptionSet OnCreateOptions() => new OptionSet
		{
			{ "html=", "The output file for the HTML diff", v => htmlDiff = v },
			{ "md=", "The output file for the Markdown diff", v => mdDiff = v },
			{ "xml=", "The output file for the XML diff", v => xmlDiff = v },
			{ "d|directory=", "The directories to search for assemblies", v => AddDirectory(v) },
			{ "always-resolve", "Always resolve assemblies", v => alwaysResolve = true },
			{ "exclude-nonbreaking", "Exclude non-breaking changes from the diff", v => excludeNonbreaking = true },
			{ "exclude-params", "Exclude parameter name changes from the diff", v => excludeParameterNames = true },
			{ "output-api", "Output the API info for each assembly", v => outputApi = true },
		};

		protected override bool OnValidateArguments(IEnumerable<string> extras)
		{
			var hasError = false;

			Assemblies.AddRange(extras.Where(a => !string.IsNullOrWhiteSpace(a)));

			if (Assemblies.Count != 2)
			{
				Console.Error.WriteLine($"{Program.Name}: Exactly two assemblies are required.");
				hasError = true;
			}

			var missing = Assemblies.Where(i => !File.Exists(i));
			if (missing.Any())
			{
				foreach (var file in missing)
					Console.Error.WriteLine($"{Program.Name}: File does not exist: `{file}`.");
				hasError = true;
			}

			return !hasError;
		}

		protected override bool OnInvoke(IEnumerable<string> extras)
		{
			if (Program.Verbose)
			{
				Console.WriteLine($"Comparing the following assemblies:");
				foreach (var assembly in Assemblies)
					Console.WriteLine($" - {assembly}");

				if (Directories.Count > 0)
				{
					Console.WriteLine($"Using the following search diectories:");
					foreach (var directory in Directories)
						Console.WriteLine($" - {directory}");
				}
			}

			var infoStreams = new List<Stream>();
			{
				var config = new ApiInfoConfig
				{
					IgnoreResolutionErrors = !alwaysResolve,
					SearchDirectories = Directories,
				};

				foreach (var assembly in Assemblies)
				{
					if (Program.Verbose)
						Console.WriteLine($"Generating API info for {assembly}...");

					var xdoc = GetApiInfoDocument(assembly, config, out var wasXml);

					if (!wasXml && outputApi)
					{
						xdoc.Save(assembly + ".api.xml");
					}

					// in order to compare assemblies, they have to be the same name
					var xass = xdoc.Element("assemblies").Element("assembly");
					xass.SetAttributeValue("name", "Assembly");

					var stream = new MemoryStream();
					xdoc.Save(stream);
					stream.Position = 0;

					infoStreams.Add(stream);
				}
			}

			GenerateDiff(xmlDiff, writer =>
			{
				if (Program.Verbose)
					Console.WriteLine($"Generating XML diff at {xmlDiff}...");

				infoStreams[0].Position = 0;
				infoStreams[1].Position = 0;
				ApiDiff.Generate(infoStreams[0], infoStreams[1], writer);
			});
			GenerateDiff(htmlDiff, writer =>
			{
				if (Program.Verbose)
					Console.WriteLine($"Generating HTML diff at {htmlDiff}...");

				infoStreams[0].Position = 0;
				infoStreams[1].Position = 0;
				var config = new ApiDiffFormattedConfig
				{
					Colorize = true,
					Formatter = ApiDiffFormatter.Html,
					IgnoreNonbreaking = excludeNonbreaking,
					IgnoreParameterNameChanges = excludeParameterNames,
				};
				ApiDiffFormatted.Generate(infoStreams[0], infoStreams[1], writer, config);
			});
			GenerateDiff(mdDiff, writer =>
			{
				if (Program.Verbose)
					Console.WriteLine($"Generating Markdown diff at {mdDiff}...");

				infoStreams[0].Position = 0;
				infoStreams[1].Position = 0;
				var config = new ApiDiffFormattedConfig
				{
					Formatter = ApiDiffFormatter.Markdown,
					IgnoreNonbreaking = excludeNonbreaking,
					IgnoreParameterNameChanges = excludeParameterNames,
				};
				ApiDiffFormatted.Generate(infoStreams[0], infoStreams[1], writer, config);
			});

			return true;
		}

		private static XDocument GetApiInfoDocument(string assembly, ApiInfoConfig config, out bool wasXml)
		{
			try
			{
				using (var stream = new MemoryStream())
				{
					using (var writer = new StreamWriter(stream, new UTF8Encoding(false), 1024, true))
					{
						ApiInfo.Generate(assembly, writer, config);
					}

					stream.Position = 0;
					wasXml = false;
					return XDocument.Load(stream);
				}
			}
			catch (BadImageFormatException)
			{
			}

			try
			{
				wasXml = true;
				return XDocument.Load(assembly);
			}
			catch (XmlException)
			{
			}

			throw new InvalidOperationException($"Unable to load {assembly} as it was neither a .NET assembly nor an XML API info file.");
		}

		private static void GenerateDiff(string path, Action<TextWriter> generate)
		{
			if (string.IsNullOrWhiteSpace(path))
				return;

			var dir = Path.GetDirectoryName(path);
			if (!string.IsNullOrWhiteSpace(dir) && !Directory.Exists(dir))
				Directory.CreateDirectory(dir);

			using (var file = File.Create(path))
			using (var writer = new StreamWriter(file))
			{
				generate(writer);
			}
		}

		private void AddDirectory(string directory)
		{
			if (string.IsNullOrWhiteSpace(directory))
				return;

			if (!Path.IsPathRooted(directory))
				directory = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), directory));

			Directories.Add(directory);
		}
	}
}
