using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Xamarin.AndroidX.Migration.BuildTasks
{
	public class JetifyFiles : MigrationToolTask
	{
		// file inputs

		public ITaskItem[] Files { get; set; }
		public ITaskItem[] JetifiedFiles { get; set; }
		public string JetifiedDirectory { get; set; }

		// configuration inputs

		public string JavaPath { get; set; }
		public string ConfigurationPath { get; set; }
		public bool Verbose { get; set; }
		public bool Dejetify { get; set; }
		public bool IsStrict { get; set; }
		public bool ShouldRebuildTopOfTree { get; set; }
		public bool ShouldStripSignatures { get; set; }
		public bool IsProGuard { get; set; }
		public bool Parallel { get; set; }
		public bool UseIntermediateFile { get; set; }
		public string IntermediateFilePath { get; set; }

		public override bool Execute()
		{
			// make sure there is input
			if (Files == null || Files.Length == 0)
			{
				Log.LogError($"Nothing to jetify. No files were provided via the \"{nameof(Files)}\" attribute.");
				return false;
			}

			// make sure the output files are valid
			if (JetifiedFiles?.Length > 0)
			{
				if (Files.Length != JetifiedFiles?.Length)
				{
					Log.LogError($"The length of {nameof(Files)} and {nameof(JetifiedFiles)} must be the same.");
					return false;
				}
				if (!string.IsNullOrEmpty(JetifiedDirectory))
				{
					Log.LogError($"The {nameof(JetifiedDirectory)} and {nameof(JetifiedFiles)} cannot both be set.");
					return false;
				}
			}

			// make sure the intermediate file is valid
			if (UseIntermediateFile)
			{
				if (string.IsNullOrEmpty(IntermediateFilePath))
				{
					Log.LogError($"Invalid intermediate path \"{IntermediateFilePath}\".");
					return false;
				}
			}

			try
			{
				var filesToJetify = CreateMigrationPairs().ToList();

				foreach (var file in filesToJetify)
				{
					if (file.Source.Equals(file.Destination, StringComparison.OrdinalIgnoreCase))
						Log.LogMessage(MessageImportance.Low, $"Queuing jetification for {file.Source}.");
					else
						Log.LogMessage(MessageImportance.Low, $"Queuing jetification for {file.Source} to {file.Destination}.");
				}

				var jetifier = new Jetifier
				{
					ConfigurationPath = ConfigurationPath,
					Verbose = Verbose,
					Dejetify = Dejetify,
					IsStrict = IsStrict,
					ShouldRebuildTopOfTree = ShouldRebuildTopOfTree,
					ShouldStripSignatures = ShouldStripSignatures,
					IsProGuard = IsProGuard,
					Parallel = Parallel,
					UseIntermediateFile = UseIntermediateFile,
					IntermediateFilePath = IntermediateFilePath,
					JavaPath = JavaPath,
				};

				jetifier.MessageLogged += (sender, e) => LogToolMessage(e);

				if (!string.IsNullOrEmpty(JetifiedDirectory) && !Directory.Exists(JetifiedDirectory))
					Directory.CreateDirectory(JetifiedDirectory);

				return jetifier.Jetify(filesToJetify);
			}
			catch (Exception ex)
			{
				Log.LogErrorFromException(ex, true);
				return false;
			}
		}

		private IEnumerable<MigrationPair> CreateMigrationPairs()
		{
			var filesLength = Files?.Length ?? 0;
			for (int i = 0; i < filesLength; i++)
			{
				var inputFile = Files[i].ItemSpec;
				var outputFile = GetOutputFile(i) ?? inputFile;

				yield return (Path.GetFullPath(inputFile), Path.GetFullPath(outputFile));
			}
		}

		private string GetOutputFile(int index)
		{
			if (JetifiedFiles?.Length > index)
				return JetifiedFiles[index].ItemSpec;

			if (!string.IsNullOrEmpty(JetifiedDirectory))
			{
				var extension = Path.GetExtension(Files[index].ItemSpec);
				return Path.Combine(JetifiedDirectory, Guid.NewGuid().ToString() + extension);
			}

			return null;
		}
	}
}
