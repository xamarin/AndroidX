using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Xamarin.AndroidX.Migration.BuildTasks
{
	public class RemoveSkippedEmbeddedFiles : Task
	{
		[Required]
		public string AssemblyIdentityMapFile { get; set; }

		public ITaskItem[] Files { get; set; }

		public ITaskItem[] ContainersToSkip { get; set; }

		public string OutputImportDirectory { get; set; }

		public bool Verbose { get; set; }

		[Output]
		public ITaskItem[] OutputFiles { get; set; }

		public override bool Execute()
		{
			// if there are no files, then we are done
			if (Files == null || Files.Length == 0)
			{
				Log.LogMessage(MessageImportance.Low, $"There were no files to check.");

				return true;
			}

			// if there is nothing to skip, then we are done
			if (ContainersToSkip == null || ContainersToSkip.Length == 0)
			{
				Log.LogMessage(MessageImportance.Low, $"There were no containers to check.");

				OutputFiles = Files;
				return true;
			}

			// if there is no map file, then error
			if (string.IsNullOrWhiteSpace(AssemblyIdentityMapFile) || !File.Exists(AssemblyIdentityMapFile))
			{
				Log.LogError($"The map.cache file '{AssemblyIdentityMapFile}' does not exist.");
				return false;
			}

			// try and determine the full "lp" directory
			if (!string.IsNullOrWhiteSpace(OutputImportDirectory))
				OutputImportDirectory = Path.GetFullPath(OutputImportDirectory);
			else
				OutputImportDirectory = Path.GetDirectoryName(AssemblyIdentityMapFile);
			if (OutputImportDirectory[OutputImportDirectory.Length - 1] != Path.DirectorySeparatorChar)
				OutputImportDirectory += Path.DirectorySeparatorChar;

			// now process all the files
			OutputFiles = GetIncludedFiles().ToArray();

			return true;
		}

		private IEnumerable<ITaskItem> GetIncludedFiles()
		{
			var containers = ContainersToSkip.Select(c => c.ItemSpec).ToArray();

			var mapCache = File.ReadAllLines(AssemblyIdentityMapFile);

			foreach (var file in Files)
			{
				if (ShouldSkip(file, out var container))
				{
					Log.LogMessage($"Skipping '{file}' because it matched '{container}'.");
				}
				else
				{
					Log.LogMessage(MessageImportance.Low, $"The file '{file}' did not match any skippable containers.");

					yield return file;
				}
			}

			bool ShouldSkip(ITaskItem file, out string container)
			{
				container = null;

				var fullPath = Path.GetFullPath(file.ItemSpec);
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
}
