using Mono.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using Xamarin.Android.Tools.Bytecode;

namespace AndroidXMigrator
{
	public class SearchCommand : BaseCommand
	{
		public SearchCommand()
			: base("search", "Search artifacts in directories for Java classes.")
		{
		}

		protected override OptionSet OnCreateOptions() => new OptionSet
		{
			{ "d|directory=", "The directory to search for artifacts", v => AddDirectory(v) },
			{ "c|class=", "The Java class to find", v => JavaClasses.Add(v) },
		};

		public List<string> Directories { get; } = new List<string>();

		public List<string> JavaClasses { get; } = new List<string>();

		protected override bool OnValidateArguments(IEnumerable<string> extras)
		{
			if (Directories.Count == 0)
				Directories.Add(Directory.GetCurrentDirectory());

			var hasError = false;

			if (JavaClasses.Count == 0)
			{
				Console.Error.WriteLine($"{Program.Name}: At least one Java class is required `--class=PATH`.");
				hasError = true;
			}

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
				Console.WriteLine($"Looking for the following classes:");
				foreach (var javaClass in JavaClasses)
					Console.WriteLine($" - {javaClass}");
				Console.WriteLine($"In the following directories:");
				foreach (var directory in Directories)
					Console.WriteLine($" - {directory}");
			}

			foreach (var directory in Directories)
			{
				var aarFiles = Directory.EnumerateFiles(directory, "*.aar", SearchOption.AllDirectories);
				var jarFiles = Directory.EnumerateFiles(directory, "*.jar", SearchOption.AllDirectories);
				var artifacts = jarFiles.Union(aarFiles);

				foreach (var artifact in artifacts)
				{
					if (Program.Verbose)
						Console.WriteLine($"Processing {artifact}...");

					foreach (var javaClass in JavaClasses)
					{
						if (string.IsNullOrWhiteSpace(javaClass))
							continue;

						Stream jarStream = null;
						try
						{
							if (Path.GetExtension(artifact).Equals(".aar", StringComparison.OrdinalIgnoreCase))
								jarStream = ReadZipEntry(artifact, "classes.jar");
							else if (Path.GetExtension(artifact).Equals(".jar", StringComparison.OrdinalIgnoreCase))
								jarStream = File.OpenRead(artifact);

							if (jarStream != null)
							{
								var classPath = new ClassPath();
								classPath.Load(jarStream);

								DoSearch(artifact, classPath, javaClass);
							}
						}
						finally
						{
							jarStream?.Dispose();
						}
					}
				}
			}

			return true;
		}

		private void DoSearch(string artifact, ClassPath classPath, string javaClass)
		{
			foreach (var package in classPath.GetPackages())
			{
				var classFiles = package.Value;

				foreach (var classFile in classFiles)
				{
					var thisClass = classFile.ThisClass;
					if (thisClass.Name.Value.Contains(javaClass))
					{
						Console.WriteLine($"{thisClass.Name.Value}: {artifact}");
					}
				}
			}
		}

		public static Stream ReadZipEntry(string archivePath, string entryPath)
		{
			if (string.IsNullOrWhiteSpace(entryPath))
				return null;

			entryPath = entryPath.Replace("\\", "/");

			using (var archive = new ZipArchive(File.OpenRead(archivePath), ZipArchiveMode.Read, false))
			{
				var entry = archive.Entries.FirstOrDefault(e => e.FullName.Equals(entryPath, StringComparison.OrdinalIgnoreCase));
				if (entry != null)
				{
					using (var stream = entry.Open())
					{
						var output = new MemoryStream();
						stream.CopyTo(output);
						output.Position = 0;

						return output;
					}
				}
			}

			return null;
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
