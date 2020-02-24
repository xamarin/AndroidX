using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mono.Options;
using NuGet.Packaging;
using Xamarin.AndroidX.Migration;

namespace AndroidXMigrator
{
	public class DependencyTreeCommand : BaseCommand
	{
		public DependencyTreeCommand()
			: base("deptree", "Create a dependency tree of NuGet packages.")
		{
		}

		protected override OptionSet OnCreateOptions() => new OptionSet
		{
			{ "d|directory=", "The directory to search for packages", v => AddDirectory(v) },
			{ "o|output=", "The path to the dependencies json", v => OutputPath = v },
		};

		public List<string> Directories { get; } = new List<string>();

		public string OutputPath { get; set; }

		protected override bool OnValidateArguments(IEnumerable<string> extras)
		{
			if (Directories.Count == 0)
				Directories.Add(Directory.GetCurrentDirectory());

			var hasError = false;

			if (Directories.Count == 0)
			{
				Console.Error.WriteLine($"{Program.Name}: At least one directory is required `--directory=PATH`.");
				hasError = true;
			}

			var missing = Directories.Where(i => !Directory.Exists(i));

			if (missing.Any())
			{
				foreach (var file in missing)
					Console.Error.WriteLine($"{Program.Name}: Directory does not exist: `{file}`.");
				hasError = true;
			}

			return !hasError;
		}

		protected override bool OnInvoke(IEnumerable<string> extras)
		{
			if (Program.Verbose)
			{
				Console.WriteLine($"Creating a dependency tree all the *.nupkg files in:");

				foreach (var directory in Directories)
					Console.WriteLine($" - {directory}");
			}

			var nupkgFiles = Directories
				.SelectMany(d => Directory.GetFiles(d, "*.nupkg", SearchOption.TopDirectoryOnly))
				.OrderBy(n => Path.GetFileName(n))
				.ToArray();

			if (Program.Verbose)
			{
				Console.WriteLine($"Found {nupkgFiles.Length} files:");

				foreach (var nupkg in nupkgFiles)
					Console.WriteLine($" - {nupkg}");
			}

			var tree = new PackageDependencyTree();

			foreach (var nupkg in nupkgFiles)
			{
				using (var reader = new PackageArchiveReader(nupkg))
				{
					var id = reader.GetIdentity().Id;
					var package = tree.GetOrCreate(id);

					var dependencies = reader
						.GetPackageDependencies()
						.SelectMany(d => d.Packages)
						.ToArray();
					foreach (var dep in dependencies)
					{
						var depId = dep.Id;
						var depPackage = tree.GetOrCreate(depId);

						if (package.Dependencies.All(d => !d.Equals(depId, StringComparison.OrdinalIgnoreCase)))
							package.Dependencies.Add(depId);
					}
				}
			}

			if (Program.Verbose)
				Console.WriteLine($"Final dependency tree:");

			if (Program.Verbose || string.IsNullOrWhiteSpace(OutputPath))
			{
				foreach (var package in tree.Packages)
				{
					Console.WriteLine($" - {package.Id}:");

					foreach (var dependency in package.Dependencies)
						Console.WriteLine($"    - {dependency }");
				}
			}

			if (!string.IsNullOrWhiteSpace(OutputPath))
				tree.Save(OutputPath);

			return true;
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
