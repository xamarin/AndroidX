// Tools needed by cake addins
#tool nuget:?package=vswhere&version=2.7.1

// Cake Addins
#addin nuget:?package=Cake.FileHelpers&version=3.2.0
#addin nuget:?package=Cake.MonoApiTools

using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

// The main configuration points
var TARGET = Argument ("t", Argument ("target", "Default"));
var CONFIGURATION = Argument ("c", Argument ("configuration", "Release"));
var VERBOSITY = Argument ("v", Argument ("verbosity", Verbosity.Normal));

// Lists all the artifacts and their versions for com.android.support.*
// https://dl.google.com/dl/android/maven2/com/android/support/group-index.xml
// Master list of all the packages in the repo:
// https://dl.google.com/dl/android/maven2/master-index.xml

var REF_DOCS_URL = "https://bosstoragemirror.blob.core.windows.net/android-docs-scraper/a7/a712886a8b4ee709f32d51823223039883d38734/androidx.zip";

// In order to create the type mapping, we need to get the AndroidSupport.Merged.dll
var SUPPORT_MERGED_DLL_URL = EnvironmentVariable("SUPPORT_MERGED_DLL_URL") ?? $"https://github.com/xamarin/AndroidSupportComponents/releases/download/28.0.0.3/AndroidSupport.Merged.dll";

// Resolve Xamarin.Android installation
var XAMARIN_ANDROID_PATH = EnvironmentVariable ("XAMARIN_ANDROID_PATH");
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
var BUILD_COMMIT = EnvironmentVariable("BUILD_COMMIT") ?? "DEV";
var BUILD_NUMBER = EnvironmentVariable("BUILD_NUMBER") ?? "DEBUG";
var BUILD_TIMESTAMP = DateTime.UtcNow.ToString();

var REQUIRED_DOTNET_TOOLS = new [] {
	"xamarin-android-binderator",
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
	if (bool.TryParse(EnvironmentVariable("PRE_RESTORE_PROJECTS") ?? "false", out var restore) && restore) {
		
		var restoreSettings = new MSBuildSettings()
			.SetConfiguration(CONFIGURATION)
			.SetVerbosity(VERBOSITY)
			.SetMaxCpuCount(0)
			.WithProperty("DesignTimeBuild", "false")
			.WithProperty("AndroidSdkBuildToolsVersion", "28.0.3")
			.WithTarget("Restore");

		foreach (var csproj in GetFiles("./generated/**/*.csproj")) {
			MSBuild(csproj, restoreSettings);
		}
	}

	var settings = new MSBuildSettings()
		.SetConfiguration(CONFIGURATION)
		.SetVerbosity(VERBOSITY)
		.SetMaxCpuCount(0)
		.EnableBinaryLogger("./output/libs.binlog")
		.WithRestore()
		.WithProperty("DesignTimeBuild", "false")
		.WithProperty("AndroidSdkBuildToolsVersion", "28.0.3");

	MSBuild("./generated/AndroidX.sln", settings);
});

Task("nuget")
	.IsDependentOn("libs")
	.Does(() =>
{
	var settings = new MSBuildSettings()
		.SetConfiguration(CONFIGURATION)
		.SetVerbosity(VERBOSITY)
		.SetMaxCpuCount(0)
		.WithProperty("NoBuild", "true")
		.WithProperty("PackageRequireLicenseAcceptance", "true")
		.WithProperty("PackageOutputPath", MakeAbsolute ((DirectoryPath)"./output/").FullPath)
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

	// build the samples
	var settings = new MSBuildSettings()
		.SetConfiguration(CONFIGURATION)
		.SetVerbosity(VERBOSITY)
		.SetMaxCpuCount(0)
		.EnableBinaryLogger("./output/samples.binlog")
		.WithRestore()
		.WithProperty("RestoreNoCache", "true")
		.WithProperty("RestorePackagesPath", packagesPath)
		.WithProperty("DesignTimeBuild", "false")
		.WithProperty("AndroidSdkBuildToolsVersion", "28.0.3");

	MSBuild("./samples/BuildAll/BuildAll.sln", settings);
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
		$"  --output ./output/androidx-mapping.csv");
});

Task ("merge")
	.IsDependentOn ("libs")
	.Does (() =>
{
	// find all the dlls
	var allDlls = GetFiles($"./generated/*/bin/{CONFIGURATION}/monoandroid*/Xamarin.*.dll");
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



var TF_MONIKER = "monoandroid90";
var BUILD_CONFIG = Argument ("config", "Release");
string SUPPORT_MERGED_DLL = "./output/AndroidSupport.Merged.dll";
string ANDROIDX_MERGED_DLL = "./output/AndroidX.Merged.dll";
string MAPPING_URL = "https://raw.githubusercontent.com/xamarin/XamarinAndroidXMigration/master/mappings/androidx-mapping.csv";
string MAPPING_LOCAL = "./output/androidx-mapping.csv";
string API_INFO_OLD = "./output/AndroidSupport.Merged.api-info.xml";
string API_INFO_OLD_MIGRATED = "./output/AndroidSupport.Merged.Migrated.api-info.xml";
string API_INFO_NEW = "./output/AndroidX.Merged.api-info.xml";


var MONODROID_BASE_PATH = (DirectoryPath)"/Library/Frameworks/Xamarin.Android.framework/Versions/Current/lib/xbuild-frameworks/MonoAndroid/";
if (IsRunningOnWindows ()) {
	var vsInstallPath = VSWhereLatest (new VSWhereLatestSettings { Requires = "Component.Xamarin" });
	MONODROID_BASE_PATH = vsInstallPath.Combine ("Common7/IDE/ReferenceAssemblies/Microsoft/Framework/MonoAndroid/");
}
var MONODROID_PATH = MONODROID_BASE_PATH.Combine(ANDROID_SDK_VERSION);


Task("api-info-migrate")
	.Does
	(
		() =>
		{
			EnsureDirectoryExists ("./output/");

			DownloadFile (SUPPORT_MERGED_DLL_URL, SUPPORT_MERGED_DLL);

			var result1 = StartProcess($"api-tools", $"api-info {SUPPORT_MERGED_DLL}");
			if (result1 != 0)
				throw new Exception($"The androidxmapper failed with error code {result1}.");


			DownloadFile (MAPPING_URL, MAPPING_LOCAL);
			string[] lines_mapping_local = FileReadLines(MAPPING_LOCAL);
			List<(string, string)> mapping = new List<(string, string)>();
			lines_mapping_local.ToList()
							.ForEach( x => { var r = x.Split(new char[] {','}); mapping.Add( (r[0], r[2]) ); } );
			mapping.GroupBy(g => new Tuple<string, string>(g.Item1, g.Item2))
				.Select(g => g.First())
				.ToList()
				.ForEach( x => { Console.WriteLine(x); } );


			string[] lines_api_info = FileReadLines(API_INFO_OLD);
			// lines_api_info.ToList()
			//                .ForEach( x => { Console.WriteLine(x); } );
			List<string> lines_api_info_migrated =  new List<string>();
			int i = 0;
			foreach(string l in lines_api_info)
			{
				string line_new = null;

				foreach((string, string) m in mapping)
				{
					if (string.IsNullOrEmpty(m.Item1))
					{
						continue;
					}
					if( l.Contains(m.Item1) )
					{
						line_new = l.Replace(m.Item1, m.Item2);
						break;
					}
					else
					{
						line_new = l;
					}
				}
				lines_api_info_migrated.Add(line_new);
			}

			FileWriteLines(API_INFO_OLD_MIGRATED, lines_api_info_migrated.ToArray());
		}
	);


Task("merge-fresh")
	.Does
	(
		() =>
		{
			var allDlls = GetFiles ($"./generated/*/bin/{BUILD_CONFIG}/{TF_MONIKER}/Xamarin.AndroidX.*.dll");
			var mergeDlls = allDlls
								.GroupBy(d => new FileInfo(d.FullPath).Name)
								.Select(g => g.FirstOrDefault())
								.ToList();
			mergeDlls.ForEach( x => { Console.WriteLine(x); });
			var result2 = StartProcess
							(
								"api-tools", 
								"merge -n Xamarin.AndroidX.Merged" +
								$" {string.Join(" ", mergeDlls)} " +
								$" -s /Library/Frameworks/Xamarin.Android.framework/Versions/9.1.0-17/lib/xamarin.android/xbuild-frameworks/MonoAndroid/v9.0/" +
								$" -s /Library/Frameworks/Xamarin.Android.framework/Versions/10.1.0.29/lib/xamarin.android/xbuild-frameworks/MonoAndroid/v1.0/" +
								$" -o " + MakeAbsolute((FilePath)"./output/AndroidX.Merged.dll") +
								$" --inject-assemblyname"
							);
			var result1 = StartProcess($"api-tools", $"api-info {ANDROIDX_MERGED_DLL}");
			if (result1 != 0)
				throw new Exception($"The androidxmapper failed with error code {result1}.");
				
			return;
		}
	);


Task("api-diff")
	.IsDependentOn ("api-info-migrate")
	.IsDependentOn ("merge-fresh")
	.Does
	(
		() =>
		{
			// https://github.com/Redth/Cake.MonoApiTools/
			MonoApiDiff(API_INFO_OLD_MIGRATED, API_INFO_NEW, "./output/api-info-diff.xml");
			string[] lines_xml = FileReadLines("./output/api-info-diff.xml");
			List<string> lines_xml_new = new List<string>();
			foreach(string line in lines_xml)
			{
				if (line.Contains(@"Java.Interop.IJavaPeerable"))
				{
					continue;
				}

				lines_xml_new.Add(line);
			}
			FileWriteLines("./output/api-info-diff.cleaned.xml", lines_xml_new.ToArray());


			MonoApiHtmlColorized(API_INFO_OLD_MIGRATED, API_INFO_NEW, "./output/api-info-diff.html");
			string[] lines_html = FileReadLines("./output/api-info-diff.html");
			List<string> lines_html_new = new List<string>();
			List<string> removed_types = new List<string>();
			foreach(string line in lines_html)
			{
				if (line.Contains(@"Java.Interop.IJavaPeerable"))
				{
					continue;
				}
				if (line.Contains("<h3>Removed Type <span class='breaking' data-is-breaking>"))
				{
					string type = line.Replace("<h3>Removed Type <span class='breaking' data-is-breaking>", "");
					type = type.Replace("</span></h3>",",");
					type = Regex.Replace(type, ",</div> <!-- (.*?) -->", "");
					type = Regex.Replace(type, ",<div> <!-- (.*?) -->", "");
					Information($"{type}");
					string[] types = type.Split( new string[] { "," }, StringSplitOptions.RemoveEmptyEntries );
					removed_types.AddRange(types); 
				}

				lines_html_new.Add(line);
			}

			FileWriteLines("./output/api-info-diff.cleaned.html", lines_html_new.ToArray());
			FileWriteLines("./output/removed-types.txt", removed_types.ToArray());

			return;
		}
	);

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

	//DownloadFile (BASE_API_INFO_URL, "./output/api-info.previous.xml");

	// Now diff against current released api info
	MonoApiDiff ("./output/api-info.previous.xml", "./output/api-info.xml", "./output/api-diff.xml");

	// Now let's make pretty files
	MonoApiHtml ("./output/api-info.previous.xml", "./output/api-info.xml", "./output/api-diff.html");
	MonoApiMarkdown ("./output/api-info.previous.xml", "./output/api-info.xml", "./output/api-diff.md");
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

Task ("ci")
	.IsDependentOn ("check-tools")
	.IsDependentOn ("inject-variables")
	.IsDependentOn ("binderate")
	.IsDependentOn ("nuget")
	.IsDependentOn ("generate-mapping")
	.IsDependentOn ("samples");

// for local builds, conditionally do the first binderate
if (FileExists ("./generated/AndroidX.sln")) {
	Task ("Default")
		.IsDependentOn ("nuget");
} else {
	Task ("Default")
		.IsDependentOn ("binderate")
		.IsDependentOn ("nuget");
}

RunTarget (TARGET);
