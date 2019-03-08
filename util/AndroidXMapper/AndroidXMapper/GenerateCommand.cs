using Mono.Options;
using System;
using System.Collections.Generic;
using System.IO;

namespace AndroidXMapper
{
	public class GenerateCommand : Command
	{
		public GenerateCommand()
			: base("generate", "Generates the mapping file.")
		{
			Options = new OptionSet
			{
				$"usage: {Program.Name} {Name} [OPTIONS]",
				"",
				Help,
				"",
				{ "s|support=", "The path to the merged Android.Support api-info.xml", v => AndroidSupportApi = v },
				{ "x|androidx=", "The path to the merged AndroidX api-info.xml", v => AndroidXApi = v },
				{ "j|java=", "The path to the Java mapping csv", v => JavaTypeMapping = v },
				{ "m|override=", "The path to the mapping overides csv", v => OverrideMapping = v },
				{ "o|output=", "The output path to use for the generated mapping", v => SetOutputPath(v) },
				{ "exclude-warnings", "Include warnings in the output", v => ExcludeWarnings = v != null },
				{ "?|h|help", "Show this message and exit", _ => ShowHelp = true },
			};
		}

		private void SetOutputPath(string path)
		{
			if (string.IsNullOrWhiteSpace(path))
				return;

			if (path.EndsWith("/") || path.EndsWith("\\"))
				path += "androidx-mapping.csv";

			var dir = Path.GetDirectoryName(path);
			if (!string.IsNullOrWhiteSpace(dir) && !Directory.Exists(dir))
				Directory.CreateDirectory(dir);

			OutputPath = path;
		}

		public bool ShowHelp { get; private set; }

		public bool ExcludeWarnings { get; private set; }

		public string AndroidSupportApi { get; private set; }

		public string AndroidXApi { get; private set; }

		public string JavaTypeMapping { get; private set; }

		public string OverrideMapping { get; private set; }

		public string OutputPath { get; private set; }

		public override int Invoke(IEnumerable<string> args)
		{
			StreamWriter writer = null;

			try
			{
				var extra = Options.Parse(args);

				if (ShowHelp)
				{
					Options.WriteOptionDescriptions(CommandSet.Out);
					return 0;
				}

				if (!ValidateArguments())
					return 1;

				var outputWriter = string.IsNullOrWhiteSpace(OutputPath)
					? Console.Out
					: (writer = new StreamWriter(OutputPath));

				var generator = new MappingGenerator(AndroidSupportApi, AndroidXApi, OverrideMapping, JavaTypeMapping);
				generator.Generate(outputWriter, !ExcludeWarnings);

				return 0;
			}
			catch (Exception ex)
			{
				Console.Error.WriteLine($"{Program.Name}: An error occurred: `{ex.Message}`.");
				if (Program.Verbose)
					Console.Error.WriteLine(ex);
				return 1;
			}
			finally
			{
				writer?.Dispose();
			}
		}

		private bool ValidateArguments()
		{
			var hasError = false;

			if (string.IsNullOrEmpty(AndroidSupportApi))
			{
				Console.Error.WriteLine($"{Program.Name}: Missing required argument `--support=PATH`.");
				hasError = true;
			}
			else if (!File.Exists(AndroidSupportApi))
			{
				Console.Error.WriteLine($"{Program.Name}: File does not exist: `{AndroidSupportApi}`.");
				hasError = true;
			}

			if (string.IsNullOrEmpty(AndroidXApi))
			{
				Console.Error.WriteLine($"{Program.Name}: Missing required argument `--androidx=PATH`.");
				hasError = true;
			}
			else if (!File.Exists(AndroidXApi))
			{
				Console.Error.WriteLine($"{Program.Name}: File does not exist: `{AndroidXApi}`.");
				hasError = true;
			}

			if (!string.IsNullOrEmpty(JavaTypeMapping) && !File.Exists(JavaTypeMapping))
			{
				Console.Error.WriteLine($"{Program.Name}: File does not exist: `{JavaTypeMapping}`.");
				hasError = true;
			}

			if (!string.IsNullOrEmpty(OverrideMapping) && !File.Exists(OverrideMapping))
			{
				Console.Error.WriteLine($"{Program.Name}: File does not exist: `{OverrideMapping}`.");
				hasError = true;
			}

			if (hasError)
				Console.Error.WriteLine($"{Program.Name}: Use `{Program.Name} help {Name}` for details.");

			return !hasError;
		}
	}
}
