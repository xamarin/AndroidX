using Mono.Options;
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.AndroidX.Migration;

namespace AndroidXMigrator
{
	public class GenerateCommand : BaseCommand
	{
		public GenerateCommand()
			: base("generate", "Generates the complete AndroidX mapping file.")
		{
		}

		public bool ExcludeWarnings { get; set; }

		public string AndroidSupportAssembly { get; set; }

		public string AndroidXAssembly { get; set; }

		public string JavaTypeMapping { get; set; } = Resources.JavaClassMappingPath;

		public string OverrideMapping { get; set; } = Resources.MappingOverridesPath;

		public string OutputPath { get; set; }

		protected override OptionSet OnCreateOptions() => new OptionSet
		{
			{ "s|support=", "The path to the merged Android.Support assembly", v => AndroidSupportAssembly = v },
			{ "x|androidx=", "The path to the merged AndroidX assembly", v => AndroidXAssembly = v },
			{ "j|java=", "The path to the Java mapping csv", v => JavaTypeMapping = v },
			{ "m|override=", "The path to the mapping overides csv", v => OverrideMapping = v },
			{ "o|output=", "The output path to use for the generated mapping", v => SetOutputPath(v) },
			{ "exclude-warnings", "Include warnings in the output", v => ExcludeWarnings = v != null },
		};

		protected override bool OnValidateArguments(IEnumerable<string> extras)
		{
			var hasError = false;

			if (string.IsNullOrEmpty(AndroidSupportAssembly))
			{
				Console.Error.WriteLine($"{Program.Name}: Missing required argument `--support=PATH`.");
				hasError = true;
			}
			else if (!File.Exists(AndroidSupportAssembly))
			{
				Console.Error.WriteLine($"{Program.Name}: File does not exist: `{AndroidSupportAssembly}`.");
				hasError = true;
			}

			if (string.IsNullOrEmpty(AndroidXAssembly))
			{
				Console.Error.WriteLine($"{Program.Name}: Missing required argument `--androidx=PATH`.");
				hasError = true;
			}
			else if (!File.Exists(AndroidXAssembly))
			{
				Console.Error.WriteLine($"{Program.Name}: File does not exist: `{AndroidXAssembly}`.");
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

		protected override bool OnInvoke(IEnumerable<string> extras)
		{
			StreamWriter writer = null;
			try
			{
				var outputWriter = string.IsNullOrWhiteSpace(OutputPath)
					? Console.Out
					: (writer = new StreamWriter(OutputPath));

				var generator = new MappingGenerator
				{
					OverridesPath = OverrideMapping,
					JavaMappingPath = JavaTypeMapping,
					IncludeWarnings = !ExcludeWarnings,
					Verbose = Program.Verbose,
				};
				generator.Generate(AndroidSupportAssembly, AndroidXAssembly, outputWriter);
			}
			finally
			{
				writer?.Dispose();
			}

			return true;
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
	}
}
