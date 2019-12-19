using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Xamarin.AndroidX.Migration.BuildTasks
{
	public class ValidateAndroidXPackages : Task
	{
		[Required]
		public ITaskItem[] ResolvedAssemblies { get; set; }

		public bool Verbose { get; set; }

		public bool UseWarningsInsteadOfErrors { get; set; }

		[Output]
		public bool ContainsSupportAssemblies { get; set; }

		public override bool Execute()
		{
			// if there are no assemblies, then we are done
			if (ResolvedAssemblies == null || ResolvedAssemblies.Length == 0)
			{
				Log.LogMessage($"There were no assemblies to check.");
				return true;
			}

			var hasMissing = false;

			var assemblyNames = ResolvedAssemblies.Select(a => Path.GetFileNameWithoutExtension(a.ItemSpec));

			var mapping = new AndroidXAssembliesCsvMapping();

			var assemblyPairs = new Dictionary<string, string>();
			var androidxAssemblies = new Dictionary<string, bool>();

			foreach (var support in assemblyNames)
			{
				// if there was no mapping found, then we don't care
				if (!mapping.TryGetAndroidXAssembly(support, out var androidx))
					continue;

				ContainsSupportAssemblies = true;

				Log.LogMessage(MessageImportance.Low, $"Making sure that the Android Support assembly '{support}' has a replacement Android X assembly...");

				// make sure the mapped assembly is referenced
				var exists = assemblyNames.Contains(androidx);
				androidxAssemblies[androidx] = exists;
				assemblyPairs[androidx] = support;

				if (exists)
				{
					Log.LogMessage(MessageImportance.Low, $"Found the Android X assembly '{androidx}'.");
				}
				else
				{
					Log.LogMessage(MessageImportance.Low, $"Missing the Android X assembly '{androidx}'.");
					hasMissing = true;
				}
			}

			if (hasMissing)
			{
				var missing = androidxAssemblies.Where(p => !p.Value).Select(p => p.Key).ToArray();

				var tree = PackageDependencyTree.Load();

				var reduced = tree.Reduce(missing).ToArray();

				var packages = new StringBuilder();
				var references = new StringBuilder();

				foreach (var assembly in reduced)
				{
					mapping.TryGetAndroidXPackage(assembly, out var package);
					mapping.TryGetAndroidXVersion(assembly, out var version);

					packages.AppendLine();
					packages.Append($" - {package}");

					references.AppendLine();
					references.Append($"    <PackageReference Include=\"{package}\" Version=\"{version}\" />");
				}

				var msg =
					$"Could not find {missing.Length} Android X assemblies, make sure to install the following NuGet packages:" +
					packages + Environment.NewLine +
					$"You can also copy-and-paste the following snippet into your .csproj file:" +
					references;

				if (UseWarningsInsteadOfErrors)
					Log.LogWarning(msg);
				else
					Log.LogError(msg);
			}

			return !hasMissing || UseWarningsInsteadOfErrors;
		}
	}
}
