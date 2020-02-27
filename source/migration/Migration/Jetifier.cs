using System;
using System.Collections.Generic;
using System.IO;

namespace Xamarin.AndroidX.Migration
{
	public class Jetifier : MigrationTool
	{
		public string ConfigurationPath { get; set; }

		public bool Dejetify { get; set; }

		public bool IsStrict { get; set; }

		public bool ShouldRebuildTopOfTree { get; set; }

		public bool ShouldStripSignatures { get; set; }

		public bool IsProGuard { get; set; }

		public bool Parallel { get; set; }

		public bool UseIntermediateFile { get; set; }

		public string IntermediateFilePath { get; set; }

		public string JavaPath { get; set; } = "java";

		public string JetifierWrapperPath { get; set; } = Resources.JetifierWrapperDirectory;

		public bool Jetify(MigrationPair archives) =>
			Jetify(new[] { archives });

		public bool Jetify(string source, string destination) =>
			Jetify(new[] { new MigrationPair(source, destination) });

		public bool Jetify(IEnumerable<MigrationPair> archives)
		{
			if (archives == null)
				throw new ArgumentNullException(nameof(archives), "There's nothing to jetify.");

			var jars = Directory.GetFiles(Resources.JetifierWrapperDirectory, "*.jar");

			var inputs = string.Empty;
			if (UseIntermediateFile)
			{
				if (string.IsNullOrWhiteSpace(IntermediateFilePath))
				{
					var tempRoot = Path.Combine(Path.GetTempPath(), "Xamarin.AndroidX.Migration", "Jetifier", Guid.NewGuid().ToString());
					IntermediateFilePath = tempRoot;
				}

				var dir = Path.GetDirectoryName(IntermediateFilePath);
				if (!string.IsNullOrWhiteSpace(dir) && !Directory.Exists(dir))
					Directory.CreateDirectory(dir);

				using (var intermediate = File.CreateText(IntermediateFilePath))
				{
					foreach (var file in archives)
					{
						intermediate.WriteLine($"{file.Source};{file.Destination}");
					}
				}

				inputs = $" -intermediate \"{IntermediateFilePath}\"";
			}
			else
			{
				foreach (var file in archives)
				{
					inputs += $" -i \"{file.Source}\" -o \"{file.Destination}\"";
				}
			}

			var classPath = string.Join(Path.PathSeparator.ToString(), jars);
			var c = !string.IsNullOrWhiteSpace(ConfigurationPath) ? $" -c \"{ConfigurationPath}\"" : string.Empty;
			var l = Verbose ? $" -l verbose" : string.Empty;
			var r = Dejetify ? " -r" : string.Empty;
			var s = IsStrict ? " -s" : string.Empty;
			var rebuildTopOfTree = ShouldRebuildTopOfTree ? " -rebuildTopOfTree" : string.Empty;
			var stripSignatures = ShouldStripSignatures ? " -stripSignatures" : string.Empty;
			var isProGuard = IsProGuard ? " -isProGuard" : string.Empty;
			var parallel = Parallel ? " -parallel" : string.Empty;
			var options = $"{c}{l}{r}{s}{rebuildTopOfTree}{stripSignatures}{isProGuard}{parallel}";
			var arguments = $"-classpath \"{classPath}\" \"{Resources.JetifierWrapperMain}\" {inputs} {options}";

			return ExecuteExternalProcess(JavaPath, arguments);
		}
	}
}
