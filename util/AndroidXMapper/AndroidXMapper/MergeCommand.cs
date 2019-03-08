using Mono.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AndroidXMapper
{
	public class MergeCommand : Command
	{
		public MergeCommand()
			: base("merge", "Merges the various AndroidX libraries.")
		{
			Options = new OptionSet
			{
				$"usage: {Program.Name} {Name} [OPTIONS]",
				"",
				Help,
				"",
				{ "a|assembly=", "One or more assemblies to merge", v => Assemblies.Add(v) },
				{ "o|output=", "The output path to use for the merged assembly", v => SetOutputPath(v) },
				{ "s|search=", "One or more search directories", v => SearchDirectories.Add(v) },
				{ "inject-assemblyname", "Add the assembly names to the types", _ => InjectAssemblyNames = true },
				{ "?|h|help", "Show this message and exit", _ => ShowHelp = true },
			};
		}

		private void SetOutputPath(string path)
		{
			if (string.IsNullOrWhiteSpace(path))
				return;

			if (path.EndsWith("/") || path.EndsWith("\\"))
				path += "AndroidX.Merged.dll";

			var dir = Path.GetDirectoryName(path);
			if (!string.IsNullOrWhiteSpace(dir) && !Directory.Exists(dir))
				Directory.CreateDirectory(dir);

			OutputPath = path;
		}

		public bool ShowHelp { get; private set; }

		public List<string> Assemblies { get; } = new List<string>();

		public string OutputPath { get; private set; }

		public List<string> SearchDirectories { get; } = new List<string>();

		public bool InjectAssemblyNames { get; private set; }

		public override int Invoke(IEnumerable<string> args)
		{
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

				var merger = new AssemblyMerger(Assemblies, SearchDirectories, InjectAssemblyNames);
				merger.Merge(OutputPath);

				return 0;
			}
			catch (Exception ex)
			{
				Console.Error.WriteLine($"{Program.Name}: An error occurred: `{ex.Message}`.");
				if (Program.Verbose)
					Console.Error.WriteLine(ex);
				return 1;
			}
		}

		private bool ValidateArguments()
		{
			var hasError = false;

			if (string.IsNullOrWhiteSpace(OutputPath))
			{
				Console.Error.WriteLine($"{Program.Name}: An output path is required `--output=PATH`.");
				hasError = true;
			}

			if (Assemblies.Count == 0)
			{
				Console.Error.WriteLine($"{Program.Name}: At least one assembly is required `--assembly=PATH`.");
				hasError = true;
			}

			var missing = Assemblies.Where(i => !File.Exists(i));

			if (missing.Any())
			{
				foreach (var file in missing)
					Console.Error.WriteLine($"{Program.Name}: File does not exist: `{file}`.");
				hasError = true;
			}

			if (hasError)
				Console.Error.WriteLine($"{Program.Name}: Use `{Program.Name} help {Name}` for details.");

			return !hasError;
		}
	}
}
