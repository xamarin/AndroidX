// Tools needed by cake addins
#tool nuget:?package=ILRepack&version=2.0.13
#tool nuget:?package=Cake.MonoApiTools&version=3.0.1
//#tool nuget:?package=Microsoft.DotNet.BuildTools.GenAPI&version=1.0.0-beta-00081
#tool nuget:?package=vswhere

// Cake Addins
#addin nuget:?package=Cake.FileHelpers&version=3.1.0
#addin nuget:?package=Cake.Compression&version=0.1.6
#addin nuget:?package=Cake.MonoApiTools&version=3.0.1
#addin nuget:?package=Xamarin.Nuget.Validator&version=1.1.1

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
var ANDROID_SDK_VERSION = IsRunningOnWindows () ? "v9.0" : "android-28";
var RENDERSCRIPT_FOLDER = "android-8.1.0";
var TF_MONIKER = "monoandroid90";

var REF_DOCS_URL = "https://bosstoragemirror.blob.core.windows.net/android-docs-scraper/ea/ea65204c51cf20873c17c32584f3b12ed390ac55/android-support.zip";

// We grab the previous release's api-info.xml to use as a comparison for this build's generated info to make an api-diff
var BASE_API_INFO_URL = EnvironmentVariable("MONO_API_INFO_XML_URL") ?? "https://github.com/xamarin/AndroidSupportComponents/releases/download/27.1.1-rc/api-info.xml";


var MONODROID_PATH = "/Library/Frameworks/Xamarin.Android.framework/Versions/Current/lib/mandroid/platforms/" + ANDROID_SDK_VERSION + "/";
if (IsRunningOnWindows ()) {
	var vsInstallPath = VSWhereLatest (new VSWhereLatestSettings { Requires = "Component.Xamarin" });
	MONODROID_PATH = vsInstallPath.Combine ("Common7/IDE/ReferenceAssemblies/Microsoft/Framework/MonoAndroid/" + ANDROID_SDK_VERSION).FullPath;
}

var MSCORLIB_PATH = "/Library/Frameworks/Xamarin.Android.framework/Libraries/mono/2.1/";
if (IsRunningOnWindows ()) {

	var DOTNETDIR = new DirectoryPath (Environment.GetFolderPath (Environment.SpecialFolder.Windows)).Combine ("Microsoft.NET/");

	if (DirectoryExists (DOTNETDIR.Combine ("Framework64")))
		MSCORLIB_PATH = MakeAbsolute (DOTNETDIR.Combine("Framework64/v4.0.30319/")).FullPath;
	else
		MSCORLIB_PATH = MakeAbsolute (DOTNETDIR.Combine("Framework/v4.0.30319/")).FullPath;
}

Information ("MONODROID_PATH: {0}", MONODROID_PATH);
Information ("MSCORLIB_PATH: {0}", MSCORLIB_PATH);

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
		c.Configuration = "Release";
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
		c.Configuration = "Release";
		c.MaxCpuCount = 0;
		c.Verbosity = VERBOSITY;
		c.Targets.Clear();
		c.Targets.Add("Pack");
		c.Properties.Add("PackageOutputPath", new [] { MakeAbsolute(new FilePath("./output")).FullPath });
		c.Properties.Add("PackageRequireLicenseAcceptance", new [] { "true" });
		c.Properties.Add("DesignTimeBuild", new [] { "false" });
		c.Properties.Add("AndroidSdkBuildToolsVersion", new [] { "28.0.3" });
	});
});

Task("nuget-fat")
	.Does(() =>
{
	// Make a temp folder to move the created nugets to before we fat package them
	EnsureDirectoryExists("./tmp");
	CleanDirectories("./tmp");
	EnsureDirectoryExists("./tmp/nuget");
	EnsureDirectoryExists("./tmp/output");

	// Move all of the nupkg files from output into the temp folder we just created
	MoveFiles("./output/*.nupkg", "./tmp/nuget");

	// Move the remaining output bits to a temp location so they don't get overwritten
	MoveFiles("./output/*", "./tmp/output");

	// Run the fat NuGet script
	CakeExecuteScript("nuget.cake", new CakeSettings {
		Arguments = new Dictionary<string, string> {
			{ "localSource", "./tmp/nuget" },
			{ "packagesPath", "./tmp/pkgs" },
			{ "workingPath", "./tmp/working" },
			{ "outputPath", "./output" },
			{ "incrementVersion", "false" },
			{ "packLatestOnly", "true" },
			{ "useExplicitVersion", "true" },
			{ "verbosity", VERBOSITY.ToString() },
		}
	});

	// Move the other output bits back to the original output folder
	MoveFiles("./tmp/output/*", "./output");
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

Task ("diff")
	.WithCriteria (!IsRunningOnWindows ())
	.IsDependentOn ("merge")
	.Does (() =>
{
	var SEARCH_DIRS = new DirectoryPath [] {
		MONODROID_PATH,
		"/Library/Frameworks/Xamarin.Android.framework/Versions/Current/lib/xbuild-frameworks/MonoAndroid/v1.0/",
		"/Library/Frameworks/Xamarin.Android.framework/Versions/Current/lib/mono/2.1/"
	};

	MonoApiInfo ("./output/AndroidSupport.Merged.dll",
		"./output/AndroidSupport.api-info.xml",
		new MonoApiInfoToolSettings { SearchPaths = SEARCH_DIRS });

	try
	{
		// Grab the last public release's api-info.xml to use as a base to compare and make an API diff
		DownloadFile (BASE_API_INFO_URL, "./output/AndroidSupport.api-info.previous.xml");
	}
	catch
	{
		Warning($"Download failed: {BASE_API_INFO_URL}");
		string base_api_info_file = @"../AndroidSupportComponents-28.0.0-binderate/output/AndroidSupport.api-info.xml ";
		Warning($"	using local file {base_api_info_file}");
		CopyFile(base_api_info_file, "./output/AndroidSupport.api-info.previous.xml");
	}

	// Now diff against current release'd api info
	// eg: mono mono-api-diff.exe ./gps.r26.xml ./gps.r27.xml > gps.diff.xml
	MonoApiDiff ("./output/AndroidSupport.api-info.previous.xml",
		"./output/AndroidSupport.api-info.xml",
		"./output/AndroidSupport.api-diff.xml");

	// Now let's make a purty html file
	// eg: mono mono-api-html.exe -c -x ./gps.previous.info.xml ./gps.current.info.xml > gps.diff.html
	MonoApiHtml ("./output/AndroidSupport.api-info.previous.xml",
		"./output/AndroidSupport.api-info.xml",
		"./output/AndroidSupport.api-diff.html");
});

Task ("merge")
	.IsDependentOn ("libs")
	.Does (() =>
{
	EnsureDirectoryExists("./output/");

	if (FileExists ("./output/AndroidSupport.Merged.dll"))
		DeleteFile ("./output/AndroidSupport.Merged.dll");

	var allDlls = GetFiles ("./generated/**/bin/Release/" + TF_MONIKER + "/*.dll");

	var mergeDlls = allDlls
		.GroupBy(d => new FileInfo(d.FullPath).Name)
		.Select(g => g.FirstOrDefault())
		.Where (g => !g.FullPath.Contains("v4") && !g.FullPath.Contains(".Android.Support.Constraint.Layout."))
		.ToList();

	Information("Merging: \n {0}", string.Join("\n", mergeDlls));

	// Wait for ILRepack support in cake-0.5.2
	ILRepack ("./output/AndroidSupport.Merged.dll", mergeDlls.First(), mergeDlls.Skip(1), new ILRepackSettings {
		CopyAttrs = true,
		AllowMultiple = true,
		//TargetKind = ILRepack.TargetKind.Dll,
		Libs = new List<DirectoryPath> {
			MONODROID_PATH
		},
	});
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

Task ("ci-fat")
	.IsDependentOn ("ci-setup")
	.IsDependentOn ("nuget-fat")
	.IsDependentOn ("nuget-validation");

Task ("ci")
	.IsDependentOn ("ci-setup")
	.IsDependentOn ("binderate")
	.IsDependentOn ("nuget")
	.IsDependentOn ("nuget-validation")
	.IsDependentOn ("diff");

RunTarget (TARGET);
