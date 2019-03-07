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

namespace Xamarin.AndroidX.Annotation.BuildTasks
{
	public class VerifyVersionsTask : Task
	{
		public const string AndroidXPackagePrefix = "xamarin.androidx";

		public readonly static string[] ExcludedAndroidXPackages = { };
		public readonly static string[] ExcludedAndroidSupportPackages = { };

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

		readonly Dictionary<string, string> androidxPackages = new Dictionary<string, string>();
		readonly Dictionary<string, string> androidSupportPackages = new Dictionary<string, string>();

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
				NugetPackages.GatherPackagesConfigVersions("xamarin.androidx.", ProjectPath.ItemSpec, ExcludedAndroidXPackages, androidxPackages);
				NugetPackages.GatherPackagesConfigVersions("xamarin.android.support.", ProjectPath.ItemSpec, ExcludedAndroidSupportPackages, androidSupportPackages);
			}
			else
			{
				Log.LogMessage("PackageReferenceType: PackageReference");
				NugetPackages.GatherProjectJsonVersions("xamarin.androidx.", ProjectExtensionsPath.ItemSpec, ExcludedAndroidXPackages, frameworkVersion, androidxPackages, Log);
				NugetPackages.GatherProjectJsonVersions("xamarin.android.support.", ProjectExtensionsPath.ItemSpec, ExcludedAndroidSupportPackages, frameworkVersion, androidSupportPackages, Log);
			}

			foreach (var pair in androidxPackages)
				Log.LogMessage("Referenced AndroidX Package: {0} ({1})", pair.Key, pair.Value);

			/* 
			 * In the future we may add some logic to detect if certain Android Support packages
			 * are referenced in the project but their equivalent AndroidX packages are not
			 */

			return true;
		}
	}
}
