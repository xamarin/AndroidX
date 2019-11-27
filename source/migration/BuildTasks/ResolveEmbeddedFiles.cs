using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Xamarin.AndroidX.Migration.BuildTasks
{
	public class ResolveEmbeddedFiles : Task
	{
		private string[] containers;
		private string[] mapCache;

		public ITaskItem[] ResourceDirectories { get; set; }

		public ITaskItem[] JavaLibraries { get; set; }

		public ITaskItem[] Resources { get; set; }

		public string OutputImportDirectory { get; set; }

		public string AssemblyIdentityMapFile { get; set; }

		public ITaskItem[] ContainersToSkip { get; set; }

		public bool Verbose { get; set; }

		[Output]
		public ITaskItem[] OutputFiles { get; set; }

		public override bool Execute()
		{
			// load the conainers and cache into memory
			containers = ContainersToSkip?.Length > 0
				? ContainersToSkip.Select(c => c.ItemSpec).ToArray()
				: Array.Empty<string>();
			mapCache = !string.IsNullOrWhiteSpace(AssemblyIdentityMapFile) && File.Exists(AssemblyIdentityMapFile)
				? File.ReadAllLines(AssemblyIdentityMapFile)
				: Array.Empty<string>();

			// try and determine the full "lp" directory
			if (!string.IsNullOrWhiteSpace(OutputImportDirectory))
				OutputImportDirectory = Path.GetFullPath(OutputImportDirectory);
			else if (!string.IsNullOrWhiteSpace(AssemblyIdentityMapFile))
				OutputImportDirectory = Path.GetDirectoryName(AssemblyIdentityMapFile);
			else
				OutputImportDirectory = null;
			if (OutputImportDirectory != null && OutputImportDirectory[OutputImportDirectory.Length - 1] != Path.DirectorySeparatorChar)
				OutputImportDirectory += Path.DirectorySeparatorChar;

			var output = new List<ITaskItem>();

			// look through all the extracted resources
			if (ResourceDirectories?.Length > 0)
			{
				var resources = GetExtractedResources();
				output.AddRange(resources);
			}

			// go through all the jar files
			if (JavaLibraries?.Length > 0)
			{
				foreach (var library in JavaLibraries)
				{
					if (bool.TrueString.Equals(library.GetMetadata("AndroidXSkipAndroidXMigration"), StringComparison.OrdinalIgnoreCase))
						continue;

					var lib = library.ItemSpec;

					if (ShouldSkipResource(lib, out var container) || !File.Exists(lib))
						continue;

					library.SetMetadata("InputItemSpec", lib);

					output.Add(library);
				}
			}

			// go through all the app resources
			if (Resources?.Length > 0)
			{
				foreach (var resource in Resources)
				{
					if (bool.TrueString.Equals(resource.GetMetadata("AndroidXSkipAndroidXMigration"), StringComparison.OrdinalIgnoreCase))
						continue;

					var ext = Path.GetExtension(resource.ItemSpec);
					if (ext == null || !ext.Equals(".xml", StringComparison.OrdinalIgnoreCase))
						continue;

					resource.SetMetadata("InputItemSpec", resource.GetMetadata("OriginalItemSpec"));

					output.Add(resource);
				}
			}

			OutputFiles = output.ToArray();

			return true;
		}

		private IEnumerable<ITaskItem> GetExtractedResources()
		{
			// go through all the resource directories and find the resources
			foreach (var directory in ResourceDirectories)
			{
				if (bool.TrueString.Equals(directory.GetMetadata("AndroidXSkipAndroidXMigration"), StringComparison.OrdinalIgnoreCase))
					continue;

				var dir = directory.ItemSpec;

				if (ShouldSkipResource(dir, out var container) || !Directory.Exists(dir))
					continue;

				var files = Directory.EnumerateFiles(dir, "*.xml", SearchOption.AllDirectories);

				foreach (var file in files)
				{
					var item = new TaskItem(file, new Dictionary<string, string>
					{
						{ "OriginalDirectory", dir},
						{ "InputItemSpec", file },
					});

					directory.CopyMetadataTo(item);

					yield return item;
				}
			}
		}

		private bool ShouldSkipResource(string path, out string container)
		{
			container = null;

			var fullPath = Path.GetFullPath(path);
			if (!fullPath.StartsWith(OutputImportDirectory, StringComparison.OrdinalIgnoreCase))
				return false;

			var subDir = fullPath.IndexOf(Path.DirectorySeparatorChar, OutputImportDirectory.Length);
			if (subDir == -1)
				return false;

			var indexStr = fullPath.Substring(OutputImportDirectory.Length, subDir - OutputImportDirectory.Length);

			if (!int.TryParse(indexStr, out int index) || index < 0 || index >= mapCache.Length)
				return false;

			container = mapCache[index];

			if (Array.IndexOf(containers, container) == -1)
				return false;

			return true;
		}
	}
}
