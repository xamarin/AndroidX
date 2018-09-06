using System;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Text.RegularExpressions;
using System.Runtime.Versioning;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Text;

namespace Xamarin.Android.Support.BuildTasks
{
	public class VerifyVersionsTask : Task
	{
		public const string PACKAGE_ID_PREFIX = "xamarin.android.support";

		// These packages are unrelated to the actual support libs
		public readonly static string[] ExcludedPackages = {
			"xamarin.android.support.constraint.layout",
			"xamarin.android.support.constraint.layout.solver",
		};

		[Required]
		public ITaskItem ProjectPath { get; set; }

		[Required]
		public ITaskItem ProjectExtensionsPath { get; set; }

		[Required]
		public ITaskItem TargetFrameworkVersion { get; set; }

		[Required]
		public ITaskItem TargetApiLevel { get; set; }

		[Required]
		public ITaskItem AndroidSdkBuildToolsVersion { get; set; }

		readonly Dictionary<string, string> packageVersions = new Dictionary<string, string>();

		public override bool Execute()
		{

			Log.LogMessage("ProjectPath: {0}", ProjectPath.ItemSpec);
			Log.LogMessage("ProjectExtensionsPath: {0}", ProjectExtensionsPath.ItemSpec);
			Log.LogMessage("TargetFrameworkVersion: {0}", TargetFrameworkVersion.ItemSpec);

			var frameworkVersion = Version.Parse(TargetFrameworkVersion.ItemSpec.ToLowerInvariant().TrimStart('v'));
			var apiLevel = NugetPackages.GetMajorVersion(TargetApiLevel.ItemSpec);
			var buildToolsApiLevel = NugetPackages.GetMajorVersion(AndroidSdkBuildToolsVersion.ItemSpec);

			Log.LogMessage("TargetApiLevel: {0}", apiLevel);
			Log.LogMessage("FrameworkVersion: {0}", frameworkVersion);
			Log.LogMessage("AndroidSdkBuildToolsApiLevel: {0}", buildToolsApiLevel);


			if (File.Exists(Path.Combine(ProjectPath.ItemSpec, "packages.config")))
			{
				Log.LogMessage("PackageReferenceType: packages.config");
				NugetPackages.GatherPackagesConfigVersions(PACKAGE_ID_PREFIX, ProjectPath.ItemSpec, ExcludedPackages, packageVersions);
			}
			else
			{
				Log.LogMessage("PackageReferenceType: PackageReference");
				NugetPackages.GatherProjectJsonVersions(PACKAGE_ID_PREFIX, ProjectExtensionsPath.ItemSpec, ExcludedPackages, frameworkVersion, packageVersions, Log);
			}

			foreach (var pkgId in packageVersions.Keys)
				Log.LogMessage("Referenced Support Package: {0} ({1})", pkgId, packageVersions[pkgId]);

			var distinctSupportVersions = NugetPackages.GetDistinctVersions(PACKAGE_ID_PREFIX, ExcludedPackages, packageVersions);

			if (distinctSupportVersions > 1)
			{
				// ERROR! We can't mix and match these
				var sb = new StringBuilder();
				sb.AppendLine("Invalid Android Support Library Configuration");
				sb.AppendLine("All installed Android Support library Nuget Packages must be the exact same version.");
				sb.AppendLine();
				sb.AppendLine("The following Xamarin.Android.Support.* packages and versions were detected:");
				sb.AppendLine();

				var recommendedSupportVersion = NugetPackages.GetRecommendedSupportPackageVersion(apiLevel);

				foreach (var pkg in packageVersions)
					sb.AppendLine($"    {pkg.Key} ({pkg.Value})");

				sb.AppendLine();
				sb.AppendLine($"Please install v{recommendedSupportVersion} of all Xamarin.Android.Support.* NuGet packages.");

				Log.LogError(sb.ToString());

				return false;
			}

			var invalidSupportVersionsForFramework = new List<Tuple<string, string, int, Version>> ();

			foreach (var pkgId in packageVersions.Keys)
			{
				var supportVersion = packageVersions[pkgId];

				var frameworkForSupportVersion = NugetPackages.FrameworkVersionForSupportVersion(supportVersion);
				var apiLevelForSupportVersion = NugetPackages.GetMajorVersion(supportVersion);

				if (frameworkForSupportVersion < frameworkVersion)
					invalidSupportVersionsForFramework.Add(Tuple.Create(pkgId, supportVersion, apiLevelForSupportVersion, frameworkForSupportVersion));
			}

			if (invalidSupportVersionsForFramework.Any())
			{
				// WARNING! TargetFrameworkVersion doesn't match support library version
				var sb = new StringBuilder();
				sb.AppendLine("Unsupported Android Support Library Configuration");
				sb.AppendLine($"Your project's TargetFrameworkVersion is currently set to: MonoAndroid,v{frameworkVersion} (Android API Level {apiLevel})");
				sb.AppendLine();

				foreach (var i in invalidSupportVersionsForFramework)
				{
					// If we don't have this version in our mapping, we want to still suggest a sane warning and not say it's only compatible with MonoAndroid,v0.0 which makes no sense
					if (i.Item4.Major <= 0)
						sb.AppendLine($"PackageId: {i.Item1} ({i.Item2}) is only incompatible with this TargetFrameworkVersion");
					else
						sb.AppendLine($"PackageId: {i.Item1} ({i.Item2}) is only compatible with TargetFrameworkVersion: MonoAndroid,v{i.Item4} (Android API Level {i.Item3})");
				}

				sb.AppendLine();
				sb.AppendLine("You should either install the right package versions, or update your project's TargetFrameworkVersion to match the version your packages are designed to be used with.");

				Log.LogWarning(sb.ToString());
			}

			return true;
		}
	}
}
