#addin nuget:?package=Cake.MonoApiTools

// SECTION: Arguments and Settings

var ROOT_DIR = MakeAbsolute((DirectoryPath)Argument("root", "."));
var ARTIFACTS_DIR = MakeAbsolute((DirectoryPath)Argument("artifacts", ROOT_DIR.Combine("output").FullPath));
var CACHE_DIR = MakeAbsolute((DirectoryPath)Argument("cache", ROOT_DIR.Combine("externals/api-diff").FullPath));
var OUTPUT_DIR = MakeAbsolute((DirectoryPath)Argument("output", ROOT_DIR.Combine("output/api-diff").FullPath));


// SECTION: Main Script

Information("");
Information("Script Arguments:");
Information("  Root directory: {0}", ROOT_DIR);
Information("  Artifacts directory: {0}", ARTIFACTS_DIR);
Information("  Cache directory: {0}", CACHE_DIR);
Information("  Output directory: {0}", OUTPUT_DIR);
Information("");


// SECTION: Diff NuGets

if (!GetFiles($"{ARTIFACTS_DIR}/**/*.nupkg").Any()) {
	Warning($"##vso[task.logissue type=warning]No NuGet packages were found.");
} else {
	var exitCode = StartProcess("api-tools", new ProcessSettings {
		Arguments = new ProcessArgumentBuilder()
			.Append("nuget-diff")
			.AppendQuoted(ARTIFACTS_DIR.FullPath)
			.Append("--latest")
			.Append("--prerelease")
			.Append("--group-ids")
			.Append("--ignore-unchanged")
			.AppendSwitchQuoted("--output", OUTPUT_DIR.FullPath)
			.AppendSwitchQuoted("--cache", CACHE_DIR.Combine("package-cache").FullPath)
	});
	if (exitCode != 0)
		throw new Exception ($"api-tools exited with error code {exitCode}.");
}


// SECTION: Upload Diffs

var diffs = GetFiles($"{OUTPUT_DIR}/**/*.md");
if (!diffs.Any()) {
	Warning($"##vso[task.logissue type=warning]No NuGet diffs were found.");
} else {
	var temp = CACHE_DIR.Combine("md-files");
	EnsureDirectoryExists(temp);

	foreach (var diff in diffs) {
		var segments = diff.Segments.Reverse().ToArray();
		var nugetId = segments[2];
		var platform = segments[1];
		var assembly = ((FilePath)segments[0]).GetFilenameWithoutExtension().GetFilenameWithoutExtension();
		var breaking = segments[0].EndsWith(".breaking.md");

		// using non-breaking spaces
		var newName = breaking ? "[BREAKING]   " : "";
		newName += $"{nugetId}    {assembly} ({platform}).md";
		var newPath = temp.CombineWithFilePath(newName);

		CopyFile(diff, newPath);
	}

	var temps = GetFiles($"{temp}/**/*.md");
	foreach (var t in temps.OrderBy(x => x.FullPath)) {
		Information($"##vso[task.uploadsummary]{t}");
	}
}




// Old ApiDiff
// https://github.com/xamarin/AndroidSupportComponents/blob/c25e6244c346eecbab704fbe35fbbe7532eadeeb/build.cake


// We grab the previous release's api-info.xml to use as a comparison for this build's generated info to make an api-diff
var BASE_API_INFO_URL = EnvironmentVariable("MONO_API_INFO_XML_URL") ?? "https://github.com/xamarin/AndroidSupportComponents/releases/download/28.0.0.3/api-info.xml";

// In order to create the type mapping, we need to get the AndroidSupport.Merged.dll
var SUPPORT_MERGED_DLL_URL = EnvironmentVariable("SUPPORT_MERGED_DLL_URL") ?? $"https://github.com/xamarin/AndroidSupportComponents/releases/download/28.0.0.3/AndroidSupport.Merged.dll";	

DownloadFile (BASE_API_INFO_URL, "./output/api-info.previous.xml");
// download the AndroidSupport.Merged.dll from a past build
if (!FileExists ("./output/AndroidSupport.Merged.dll")) 
{
	EnsureDirectoryExists ("./output/");
	DownloadFile (SUPPORT_MERGED_DLL_URL, "./output/AndroidSupport.Merged.dll");
}

var ANDROID_SDK_VERSION = "v9.0";
var TF_MONIKER = "monoandroid90";
var BUILD_CONFIG = Argument ("config", "Release");

var MONODROID_BASE_PATH = (DirectoryPath)"/Library/Frameworks/Xamarin.Android.framework/Versions/Current/lib/xbuild-frameworks/MonoAndroid/";
if (IsRunningOnWindows ()) {
	var vsInstallPath = VSWhereLatest (new VSWhereLatestSettings { Requires = "Component.Xamarin" });
	MONODROID_BASE_PATH = vsInstallPath.Combine ("Common7/IDE/ReferenceAssemblies/Microsoft/Framework/MonoAndroid/");
}
var MONODROID_PATH = MONODROID_BASE_PATH.Combine(ANDROID_SDK_VERSION);


Task ("merge")
	// .IsDependentOn ("androidxmapper")
	// .IsDependentOn ("libs")
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

Task ("generate-mapping")
	// .IsDependentOn ("androidxmapper")
	.IsDependentOn ("merge")
	.Does (() =>
{
	// download the AndroidSupport.Merged.dll from a past build
	if (!FileExists ("./output/AndroidSupport.Merged.dll")) {
		EnsureDirectoryExists ("./output/");
		DownloadFile (SUPPORT_MERGED_DLL_URL, "./output/AndroidSupport.Merged.dll");
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
