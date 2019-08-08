// Tools needed by cake addins
#tool nuget:?package=vswhere&version=2.7.1

// Cake Addins
#addin nuget:?package=Cake.FileHelpers&version=3.2.0
#addin nuget:?package=Cake.Compression&version=0.2.3
#addin nuget:?package=Xamarin.Nuget.Validator&version=1.1.1

using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using Xamarin.Nuget.Validator;

// The main configuration points
var TARGET = Argument ("t", Argument ("target", "Default"));
var BUILD_CONFIG = Argument ("config", "Release");
var VERBOSITY = (Verbosity) Enum.Parse (typeof(Verbosity), Argument ("v", Argument ("verbosity", "Normal")), true);
var PACKAGE_VERSION_SUFFIX = EnvironmentVariable ("PACKAGE_VERSION_SUFFIX");
var XAMARIN_ANDROID_PATH = EnvironmentVariable ("XAMARIN_ANDROID_PATH");

// Lists all the artifacts and their versions for com.android.support.*
// https://dl.google.com/dl/android/maven2/com/android/support/group-index.xml
// Master list of all the packages in the repo:
// https://dl.google.com/dl/android/maven2/master-index.xml

var REF_DOCS_URL = "https://bosstoragemirror.blob.core.windows.net/android-docs-scraper/a7/a712886a8b4ee709f32d51823223039883d38734/androidx.zip";

// In order to create the type mapping, we need to get the AndroidSupport.Merged.dll
var SUPPORT_MERGED_DLL_URL = EnvironmentVariable("SUPPORT_MERGED_DLL_URL") ?? $"https://github.com/xamarin/AndroidSupportComponents/releases/download/28.0.0.2/AndroidSupport.Merged.dll";

// Resolve Xamarin.Android installation
var ANDROID_SDK_BASE_VERSION = "v1.0";
var ANDROID_SDK_VERSION = "v9.0";
if (string.IsNullOrEmpty(XAMARIN_ANDROID_PATH)) {
	if (IsRunningOnWindows()) {
		var vsInstallPath = VSWhereLatest(new VSWhereLatestSettings { Requires = "Component.Xamarin" });
		XAMARIN_ANDROID_PATH = vsInstallPath.Combine("Common7/IDE/ReferenceAssemblies/Microsoft/Framework/MonoAndroid").FullPath;
	} else {
		if (DirectoryExists("/Library/Frameworks/Xamarin.Android.framework/Versions/Current/lib/xamarin.android/xbuild-frameworks/MonoAndroid"))
			XAMARIN_ANDROID_PATH = "/Library/Frameworks/Xamarin.Android.framework/Versions/Current/lib/xamarin.android/xbuild-frameworks/MonoAndroid";
		else
			XAMARIN_ANDROID_PATH = "/Library/Frameworks/Xamarin.Android.framework/Versions/Current/lib/xbuild-frameworks/MonoAndroid";
	}
}
if (!DirectoryExists($"{XAMARIN_ANDROID_PATH}/{ANDROID_SDK_VERSION}"))
	throw new Exception($"Unable to find Xamarin.Android {ANDROID_SDK_VERSION} at {XAMARIN_ANDROID_PATH}.");

// Load all the git variables
var BUILD_COMMIT = EnvironmentVariable("BUILD_SOURCEVERSION") ?? "DEV";
var BUILD_NUMBER = EnvironmentVariable("BUILD_NUMBER") ?? "DEBUG";
var BUILD_TIMESTAMP = DateTime.UtcNow.ToString();

var REQUIRED_DOTNET_TOOLS = new [] {
	"xamarin-android-binderator",
	"api-tools",
	"xamarin.androidx.migration.tool"
};

// Log some variables
Information ("XAMARIN_ANDROID_PATH: {0}", XAMARIN_ANDROID_PATH);
Information ("ANDROID_SDK_VERSION:  {0}", ANDROID_SDK_VERSION);
Information ("BUILD_COMMIT:         {0}", BUILD_COMMIT);
Information ("BUILD_NUMBER:         {0}", BUILD_NUMBER);
Information ("BUILD_TIMESTAMP:      {0}", BUILD_TIMESTAMP);

// You shouldn't have to configure anything below here
// ######################################################

void RunProcess(FilePath fileName, string processArguments)
{
	var exitCode = StartProcess(fileName, processArguments);
	if (exitCode != 0)
		throw new Exception ($"Process {fileName} exited with code {exitCode}.");
}

string[] RunProcessWithOutput(FilePath fileName, string processArguments)
{
	var exitCode = StartProcess(fileName, new ProcessSettings {
		Arguments = processArguments,
		RedirectStandardOutput = true,
		RedirectStandardError = true
	}, out var procOut);
	if (exitCode != 0)
		throw new Exception ($"Process {fileName} exited with code {exitCode}.");
	return procOut.ToArray();;
}

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

		RunProcess("java", "-jar \"" + MakeAbsolute(astJar).FullPath + "\" --text \"" + srcJarPath + "\" \"" + outTxtPath + "\"");
		RunProcess("java", "-jar \"" + MakeAbsolute(astJar).FullPath + "\" --xml \"" + srcJarPath + "\" \"" + outXmlPath + "\"");
	}
});

Task("check-tools")
	.Does(() =>
{
	var installedTools = RunProcessWithOutput("dotnet", "tool list -g");
	foreach (var toolName in REQUIRED_DOTNET_TOOLS) {
		if (installedTools.All(l => l.IndexOf(toolName, StringComparison.OrdinalIgnoreCase) == -1))
			throw new Exception ($"Missing dotnet tool: {toolName}");
	}
});

Task ("binderate")
	.Does (() =>
{
	var configFile = MakeAbsolute(new FilePath("./config.json")).FullPath;
	var basePath = MakeAbsolute(new DirectoryPath ("./")).FullPath;

	// Run the dotnet tool for binderator
	RunProcess("xamarin-android-binderator",
		$"--config=\"{configFile}\" --basepath=\"{basePath}\"");

	// format the targets file so they are pretty in the package
	var targetsFiles = GetFiles("generated/**/*.targets");
	var xmlns = (XNamespace)"http://schemas.microsoft.com/developer/msbuild/2003";
	foreach (var targets in targetsFiles) {
		var xdoc = XDocument.Load(targets.FullPath);
		xdoc.Save(targets.FullPath);
	}
});

Task("libs")
	.Does(() =>
{
	var settings = new MSBuildSettings()
		.SetConfiguration(BUILD_CONFIG)
		.SetVerbosity(VERBOSITY)
		.SetMaxCpuCount(0)
		.WithRestore()
		.WithProperty("PackageVersionSuffix", PACKAGE_VERSION_SUFFIX)
		.WithProperty("DesignTimeBuild", "false")
		.WithProperty("AndroidSdkBuildToolsVersion", "28.0.3");

	MSBuild("./generated/AndroidX.sln", settings);
});

Task("nuget")
	.IsDependentOn("libs")
	.Does(() =>
{
	var settings = new MSBuildSettings()
		.SetConfiguration(BUILD_CONFIG)
		.SetVerbosity(VERBOSITY)
		.SetMaxCpuCount(0)
		.WithRestore()
		.WithProperty("PackageVersionSuffix", PACKAGE_VERSION_SUFFIX)
		.WithProperty("PackageRequireLicenseAcceptance", "true")
		.WithProperty("PackageOutputPath", MakeAbsolute ((DirectoryPath)"./output/").FullPath)
		.WithProperty("DesignTimeBuild", "false")
		.WithProperty("AndroidSdkBuildToolsVersion", "28.0.3")
		.WithTarget("Pack");

	MSBuild("./generated/AndroidX.sln", settings);
});

Task("samples")
	.IsDependentOn("nuget")
	.Does(() =>
{
	// TODO: make this actually work with more than just this sample

	// make a big .targets file that pulls in everything
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
	var options = new NugetValidatorOptions {
		Copyright = "© Microsoft Corporation. All rights reserved.",
		Author = "Microsoft",
		Owner = "Microsoft",
		NeedsProjectUrl = true,
		NeedsLicenseUrl = true,
		ValidateRequireLicenseAcceptance = true,
		ValidPackageNamespace = new [] { "Xamarin" },
	};

	var nupkgFiles = GetFiles("./output/*.nupkg");
	Information("Found {0} NuGet packages to validate.", nupkgFiles.Count());

	foreach (var nupkgFile in nupkgFiles) {
		var fname = nupkgFile.GetFilename();
		Information($"Verifiying metadata of {fname}...");
		var result = NugetValidator.Validate(MakeAbsolute(nupkgFile).FullPath, options);
		if (!result.Success) {
			Error($"Metadata validation failed for: {fname} ");
			Error(string.Join("\n    ", result.ErrorMessages));
			throw new Exception($"Invalid Metadata for: {fname}");
		} else {
			Information($"Metadata validation passed for: {fname}");
		}
	}
});

Task ("diff")
	.Does (() =>
{
	RunProcess("api-tools",
		"nuget-diff output --latest --group-ids --output output/api-diff --cache externals/package_cache");
});

Task ("generate-mapping")
	.IsDependentOn ("merge")
	.Does (() =>
{
	// download the AndroidSupport.Merged.dll from a past build
	if (!FileExists ("./output/AndroidSupport.Merged.dll")) {
		EnsureDirectoryExists ("./output/");
		DownloadFile (SUPPORT_MERGED_DLL_URL, "./output/AndroidSupport.Merged.dll");
	}

	// generate the mapping
	RunProcess("androidx-migrator",
		$"generate -v " +
		$"  --support ./output/AndroidSupport.Merged.dll" +
		$"  --androidx ./output/AndroidX.Merged.dll" +
		$"  --java ./util/AndroidXMapper/Resources/androidx-class-mapping.csv" +
		$"  --override ./util/AndroidXMapper/Resources/override-mapping.csv" +
		$"  --output ./output/androidx-mapping.csv");
});

Task ("merge")
	.IsDependentOn ("libs")
	.Does (() =>
{
	// find all the dlls
	var allDlls = GetFiles($"./generated/*/bin/{BUILD_CONFIG}/monoandroid*/Xamarin.*.dll");
	var mergeDlls = allDlls
		.GroupBy(d => new FileInfo(d.FullPath).Name)
		.Select(g => g.FirstOrDefault())
		.ToList();

	// merge them all
	EnsureDirectoryExists("./output/");
	RunProcess("androidx-migrator",
		$"merge" +
		$"  --assembly " + string.Join(" --assembly ", mergeDlls) +
		$"  --output ./output/AndroidX.Merged.dll" +
		$"  --search \"{XAMARIN_ANDROID_PATH}/{ANDROID_SDK_VERSION}\" " +
		$"  --search \"{XAMARIN_ANDROID_PATH}/{ANDROID_SDK_BASE_VERSION}\" " +
		$"  --inject-assemblyname");
});

Task("inject-variables")
	.WithCriteria(!BuildSystem.IsLocalBuild)
	.Does(() =>
{
	var glob = "./source/AssemblyInfo.cs";

	ReplaceTextInFiles(glob, "{BUILD_COMMIT}", BUILD_COMMIT);
	ReplaceTextInFiles(glob, "{BUILD_NUMBER}", BUILD_NUMBER);
	ReplaceTextInFiles(glob, "{BUILD_TIMESTAMP}", BUILD_TIMESTAMP);
});

Task ("clean")
	.Does (() =>
{
	if (DirectoryExists ("./externals"))
		DeleteDirectory ("./externals", true);

	if (DirectoryExists ("./generated"))
		DeleteDirectory ("./generated", true);

	CleanDirectories ("./**/packages");
});

Task ("packages")
	.IsDependentOn ("binderate")
	.IsDependentOn ("nuget");

Task ("full-run")
	.IsDependentOn ("binderate")
	.IsDependentOn ("nuget")
	.IsDependentOn ("samples");

Task ("Default")
	.IsDependentOn ("binderate")
	.IsDependentOn ("nuget")
	.IsDependentOn ("nuget-validation")
	.IsDependentOn ("generate-mapping")
	.IsDependentOn ("diff")
	.IsDependentOn ("samples");

Task ("ci")
	.IsDependentOn ("check-tools")
	.IsDependentOn ("inject-variables")
	.IsDependentOn ("binderate")
	.IsDependentOn ("nuget")
	.IsDependentOn ("nuget-validation")
	.IsDependentOn ("generate-mapping")
	.IsDependentOn ("diff")
	.IsDependentOn ("samples");

RunTarget (TARGET);
