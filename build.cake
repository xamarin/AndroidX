// Tools needed by cake addins
#tool nuget:?package=Cake.MonoApiTools&version=3.0.1
#tool nuget:?package=vswhere

// Cake Addins
#addin nuget:?package=Cake.FileHelpers&version=3.1.0
#addin nuget:?package=Cake.Compression&version=0.1.6
#addin nuget:?package=Cake.MonoApiTools&version=3.0.1
#addin nuget:?package=Xamarin.Nuget.Validator&version=1.1.1

using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

// From Cake.Xamarin.Build, dumps out versions of things
//LogSystemInfo ();

var TARGET = Argument ("t", Argument ("target", "Default"));
var BUILD_CONFIG = Argument ("config", "Release");
var VERBOSITY = (Verbosity) Enum.Parse (typeof(Verbosity), Argument ("v", Argument ("verbosity", "Normal")), true);

// Lists all the artifacts and their versions for com.android.support.*
// https://dl.google.com/dl/android/maven2/com/android/support/group-index.xml
// Master list of all the packages in the repo:
// https://dl.google.com/dl/android/maven2/master-index.xml

var NUGET_PRE = "";

// FROM: https://dl.google.com/android/repository/addon2-1.xml
var BUILD_TOOLS_URL = "https://dl-ssl.google.com/android/repository/build-tools_r28-macosx.zip";
var ANDROID_SDK_VERSION = "v9.0";
var TF_MONIKER = "monoandroid90";

var REF_DOCS_URL = "https://bosstoragemirror.blob.core.windows.net/android-docs-scraper/a7/a712886a8b4ee709f32d51823223039883d38734/androidx.zip";

// We grab the previous release's api-info.xml to use as a comparison for this build's generated info to make an api-diff
var BASE_API_INFO_URL = EnvironmentVariable("MONO_API_INFO_XML_URL") ?? "https://github.com/xamarin/AndroidSupportComponents/releases/download/28.0.0.1/api-info.xml";

// In order to create the type mapping, we need to get the AndroidSupport.Merged.dll
var SUPPORT_MERGED_DLL_BUILD_ID = EnvironmentVariable("SUPPORT_MERGED_DLL_BUILD_ID") ?? "652";
var SUPPORT_MERGED_DLL_ZIP_URL = EnvironmentVariable("SUPPORT_MERGED_DLL_ZIP_URL") ?? $"https://dev.azure.com/xamarin/6fd3d886-57a5-4e31-8db7-52a1b47c07a8/_apis/build/builds/{SUPPORT_MERGED_DLL_BUILD_ID}/artifacts?artifactName=nuget&%24format=zip&api-version=5.0";

var MONODROID_BASE_PATH = (DirectoryPath)"/Library/Frameworks/Xamarin.Android.framework/Versions/Current/lib/xbuild-frameworks/MonoAndroid/";
if (IsRunningOnWindows ()) {
	var vsInstallPath = VSWhereLatest (new VSWhereLatestSettings { Requires = "Component.Xamarin" });
	MONODROID_BASE_PATH = vsInstallPath.Combine ("Common7/IDE/ReferenceAssemblies/Microsoft/Framework/MonoAndroid/");
}
var MONODROID_PATH = MONODROID_BASE_PATH.Combine(ANDROID_SDK_VERSION);

var ANDROIDX_MAPPER_EXE = MakeAbsolute ((FilePath)$"util/AndroidXMapper/AndroidXMapper/bin/{BUILD_CONFIG}/net47/AndroidXMapper.exe");

Information ("MONODROID_BASE_PATH: {0}", MONODROID_BASE_PATH);
Information ("MONODROID_PATH:      {0}", MONODROID_PATH);
Information ("ANDROIDX_MAPPER_EXE: {0}", ANDROIDX_MAPPER_EXE);

// You shouldn't have to configure anything below here
// ######################################################

Task("javadocs")
	.Does(() =>
{
	if (!FileExists("./externals/docs.zip"))
		DownloadFile(REF_DOCS_URL, "./externals/docs.zip");

	if (!DirectoryExists("./externals/docs"))
		Unzip ("./externals/docs.zip", "./externals/docs");

	var astJar = new FilePath("./util/JavaASTParameterNames-1.0.jar");
	var sourcesJars = GetFiles("./externals/**/*-sources.jar");

	foreach (var srcJar in sourcesJars) {
		var srcJarPath = MakeAbsolute(srcJar).FullPath;
		var outTxtPath = srcJarPath.Replace("-sources.jar", "-paramnames.txt");
		var outXmlPath = srcJarPath.Replace("-sources.jar", "-paramnames.xml");

		StartProcess("java", "-jar \"" + MakeAbsolute(astJar).FullPath + "\" --text \"" + srcJarPath + "\" \"" + outTxtPath + "\"");
		StartProcess("java", "-jar \"" + MakeAbsolute(astJar).FullPath + "\" --xml \"" + srcJarPath + "\" \"" + outXmlPath + "\"");
	}
});

Task("binderate")
	.Does(() =>
{
	if (!DirectoryExists("./util/binderator"))
	{
		EnsureDirectoryExists("./util/binderator");
		Unzip ("./util/binderator.zip", "./util/binderator");
	}

	var configFile = new FilePath("./config.json");
	var basePath = new DirectoryPath ("./");

	StartProcess("dotnet", "./util/binderator/android-binderator.dll --config=\""
		+ MakeAbsolute(configFile).FullPath + "\" --basepath=\"" + MakeAbsolute(basePath).FullPath + "\"");
});

Task("libs")
	.Does(() =>
{
	MSBuild("./generated/AndroidX.sln", c => {
		c.Configuration = BUILD_CONFIG;
		c.Restore = true;
		c.MaxCpuCount = 0;
		c.Verbosity = VERBOSITY;
		c.Properties.Add("DesignTimeBuild", new [] { "false" });
		c.Properties.Add("AndroidSdkBuildToolsVersion", new [] { "28.0.3" });
	});
});

Task("nuget")
	.IsDependentOn("libs")
	.Does(() =>
{
	MSBuild ("./generated/AndroidX.sln", c => {
		c.Configuration = BUILD_CONFIG;
		c.MaxCpuCount = 0;
		c.Verbosity = VERBOSITY;
		c.Targets.Clear();
		c.Targets.Add("Pack");
		c.Properties.Add("PackageOutputPath", new [] { MakeAbsolute(new FilePath("./output")).FullPath });
		c.Properties.Add("PackageRequireLicenseAcceptance", new [] { "true" });
		c.Properties.Add("DesignTimeBuild", new [] { "false" });
		c.Properties.Add("AndroidSdkBuildToolsVersion", new [] { "28.0.3" });
	});

	var xmlns = (XNamespace)"http://schemas.microsoft.com/developer/msbuild/2003";
	var itemGroup = new XElement(xmlns + "ItemGroup");
	foreach (var nupkg in GetFiles("./output/*.nupkg")) {
		// Skip Wear as it has special implications requiring more packages to be used properly in an app
		if (nupkg.FullPath.Contains(".Wear."))
			continue;
		var filename = nupkg.GetFilenameWithoutExtension();
		var match = Regex.Match(filename.ToString(), @"(.+?)\.(\d+[\.0-9\-a-zA-Z]+)");
		itemGroup.Add(new XElement(xmlns + "PackageReference",
			new XAttribute("Include", match.Groups[1]),
			new XAttribute("Version", match.Groups[2])));
	}
	var xdoc = new XDocument(new XElement(xmlns + "Project", itemGroup));
	xdoc.Save("./output/AllPackages.targets");
});

Task("samples")
	.IsDependentOn("nuget")
	.Does(() =>
{
	// TODO: make this actually work with more than just this sample

	// clear the packages folder so we always use the latest
	var packagesPath = MakeAbsolute((DirectoryPath)"./samples/packages").FullPath;
	EnsureDirectoryExists(packagesPath);
	CleanDirectories(packagesPath);

	// build the sample
	MSBuild (
		"./samples/BuildAll/BuildAll.sln", c => {
		c.Configuration = BUILD_CONFIG;
		c.MaxCpuCount = 0;
		c.Verbosity = VERBOSITY;
		c.Restore = true;
		c.Properties.Add("RestoreNoCache", new [] { "true" });
		c.Properties.Add("RestorePackagesPath", new [] { packagesPath });
		c.Properties.Add("DesignTimeBuild", new [] { "false" });
		c.Properties.Add("AndroidSdkBuildToolsVersion", new [] { "28.0.3" });
	});
});

Task("nuget-validation")
	.Does(() =>
{
	//setup validation options
	var options = new Xamarin.Nuget.Validator.NugetValidatorOptions()
	{
		Copyright = "© Microsoft Corporation. All rights reserved.",
		Author = "Microsoft",
		Owner = "Microsoft",
		NeedsProjectUrl = true,
		NeedsLicenseUrl = true,
		ValidateRequireLicenseAcceptance = true,
		ValidPackageNamespace = new [] { "Xamarin" },
	};

	var nupkgFiles = GetFiles ("./output/*.nupkg");

	Information ("Found ({0}) Nuget's to validate", nupkgFiles.Count ());

	foreach (var nupkgFile in nupkgFiles)
	{
		Information ("Verifiying Metadata of {0}", nupkgFile.GetFilename ());

		var result = Xamarin.Nuget.Validator.NugetValidator.Validate(MakeAbsolute(nupkgFile).FullPath, options);

		if (!result.Success)
		{
			Information ("Metadata validation failed for: {0} \n\n", nupkgFile.GetFilename ());
			Information (string.Join("\n    ", result.ErrorMessages));
			throw new Exception ($"Invalid Metadata for: {nupkgFile.GetFilename ()}");

		}
		else
		{
			Information ("Metadata validation passed for: {0}", nupkgFile.GetFilename ());
		}
	}

});

Task ("androidxmapper")
	.Does (() =>
{
	MSBuild (
		"./util/AndroidXMapper/AndroidXMapper.sln", c => {
		c.Configuration = BUILD_CONFIG;
		c.MaxCpuCount = 0;
		c.Verbosity = VERBOSITY;
		c.Restore = true;
	});
});

Task ("diff")
	.IsDependentOn ("merge")
	.Does (() =>
{
	var SEARCH_DIRS = new DirectoryPath [] {
		MONODROID_BASE_PATH.Combine("v1.0"),
		MONODROID_PATH,
	};

	EnsureDirectoryExists("./output/");
	MonoApiInfo ("./output/AndroidX.Merged.dll", "./output/api-info.xml", new MonoApiInfoToolSettings {
		SearchPaths = SEARCH_DIRS
	});

	DownloadFile (BASE_API_INFO_URL, "./output/api-info.previous.xml");

	// Now diff against current released api info
	MonoApiDiff ("./output/api-info.previous.xml", "./output/api-info.xml", "./output/api-diff.xml");

	// Now let's make pretty files
	MonoApiHtml ("./output/api-info.previous.xml", "./output/api-info.xml", "./output/api-diff.html");
	MonoApiMarkdown ("./output/api-info.previous.xml", "./output/api-info.xml", "./output/api-diff.md");
});

Task ("generate-mapping")
	.IsDependentOn ("androidxmapper")
	.IsDependentOn ("merge")
	.Does (() =>
{
	// download the AndroidSupport.Merged.dll from a past build
	if (!FileExists ("./output/AndroidSupport.Merged.dll")) {
		EnsureDirectoryExists ("./output/temp/");
		CleanDirectories ("./output/temp");
		DownloadFile (SUPPORT_MERGED_DLL_ZIP_URL, "./output/temp/AndroidSupport.NuGet.zip");
		Unzip ("./output/temp/AndroidSupport.NuGet.zip", "./output/temp/");
		CopyFileToDirectory ("./output/temp/nuget/AndroidSupport.Merged.dll", "./output/");
		DeleteDirectory ("./output/temp", true);
	}

	var result = StartProcess(ANDROIDX_MAPPER_EXE,
		$"generate -v " +
		$" -s " + MakeAbsolute((FilePath)"./output/AndroidSupport.Merged.dll") +
		$" -x " + MakeAbsolute((FilePath)"./output/AndroidX.Merged.dll") +
		$" -j " + MakeAbsolute((FilePath)"./util/AndroidXMapper/Resources/androidx-class-mapping.csv") +
		$" -m " + MakeAbsolute((FilePath)"./util/AndroidXMapper/Resources/override-mapping.csv") +
		$" -o " + MakeAbsolute((FilePath)"./output/androidx-mapping.csv"));
	if (result != 0)
		throw new Exception($"The androidxmapper failed with error code {result}.");
});

Task ("merge")
	.IsDependentOn ("androidxmapper")
	.IsDependentOn ("libs")
	.Does (() =>
{
	var allDlls = GetFiles ($"./generated/*/bin/{BUILD_CONFIG}/{TF_MONIKER}/Xamarin.*.dll");
	var mergeDlls = allDlls
		.GroupBy(d => new FileInfo(d.FullPath).Name)
		.Select(g => g.FirstOrDefault())
		.ToList();

	EnsureDirectoryExists("./output/");
	var result = StartProcess(ANDROIDX_MAPPER_EXE,
		$"merge" +
		$" -a {string.Join(" -a ", mergeDlls)} " +
		$" -o " + MakeAbsolute((FilePath)"./output/AndroidX.Merged.dll") +
		$" -s \"{MONODROID_PATH}\" " +
		$" --inject-assemblyname");
	if (result != 0)
		throw new Exception($"The androidxmapper failed with error code {result}.");
});

Task ("ci-setup")
	.WithCriteria (!BuildSystem.IsLocalBuild)
	.Does (() => 
{
	var buildCommit = "DEV";
	var buildNumber = "DEBUG";
	var buildTimestamp = DateTime.UtcNow.ToString ();

	if (BuildSystem.IsRunningOnJenkins) {
		buildNumber = BuildSystem.Jenkins.Environment.Build.BuildTag;
		buildCommit = EnvironmentVariable("GIT_COMMIT") ?? buildCommit;
	} else if (BuildSystem.IsRunningOnVSTS) {
		buildNumber = BuildSystem.TFBuild.Environment.Build.Number;
		buildCommit = BuildSystem.TFBuild.Environment.Repository.SourceVersion;
	}

	var glob = "./source/AssemblyInfo.cs";

	ReplaceTextInFiles(glob, "{BUILD_COMMIT}", buildCommit);
	ReplaceTextInFiles(glob, "{BUILD_NUMBER}", buildNumber);
	ReplaceTextInFiles(glob, "{BUILD_TIMESTAMP}", buildTimestamp);
});

Task ("clean")
	.Does (() =>
{
	if (DirectoryExists ("./externals"))
		DeleteDirectory ("./externals", true);

	if (DirectoryExists ("./generated"))
		DeleteDirectory ("./generated", true);

	if (DirectoryExists ("./util/binderator"))
		DeleteDirectory ("./util/binderator", true);

	CleanDirectories ("./**/packages");
});

Task ("full-run")
	.IsDependentOn ("binderate")
	.IsDependentOn ("nuget")
	.IsDependentOn ("samples");

Task ("ci")
	.IsDependentOn ("ci-setup")
	.IsDependentOn ("binderate")
	.IsDependentOn ("nuget")
	.IsDependentOn ("nuget-validation")
	.IsDependentOn ("generate-mapping")
	.IsDependentOn ("diff")
	.IsDependentOn ("samples");

RunTarget (TARGET);
