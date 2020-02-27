using Mono.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.AndroidX.Migration;

namespace AndroidXMigrator
{
	public class MergeCommand : BaseCommand
	{
		public MergeCommand()
			: base("merge", "Merges various .NET assemlies into a single file.")
		{
		}

		public List<string> Assemblies { get; } = new List<string>();

		public string OutputPath { get; set; }

		public List<string> SearchDirectories { get; } = new List<string>();

		public bool InjectAssemblyNames { get; set; }

		protected override OptionSet OnCreateOptions() => new OptionSet
		{
			{ "a|assembly=", "One or more assemblies to merge", v => Assemblies.Add(v) },
			{ "o|output=", "The output path to use for the merged assembly", v => SetOutputPath(v) },
			{ "s|search=", "One or more search directories", v => SearchDirectories.Add(v) },
			{ "inject-assemblyname", "Add the assembly names to the types", _ => InjectAssemblyNames = true },
		};

		protected override bool OnValidateArguments(IEnumerable<string> extras)
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

		protected override bool OnInvoke(IEnumerable<string> extras)
		{
			var merger = new AssemblyMerger
			{
				SearchDirectories = SearchDirectories,
				InjectAssemblyNames = InjectAssemblyNames,
				Verbose = Program.Verbose,
			};
			merger.Merge(Assemblies, OutputPath);

			return true;
		}

		private void SetOutputPath(string path)
		{
			if (string.IsNullOrWhiteSpace(path))
				return;

			if (path.EndsWith("/") || path.EndsWith("\\"))
				path += "Merged.dll";

			var dir = Path.GetDirectoryName(path);
			if (!string.IsNullOrWhiteSpace(dir) && !Directory.Exists(dir))
				Directory.CreateDirectory(dir);

			OutputPath = path;
		}
	}
}
