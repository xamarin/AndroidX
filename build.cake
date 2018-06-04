// Tools needed by cake addins
#tool nuget:?package=XamarinComponent&version=1.1.0.49
#tool nuget:?package=ILRepack&version=2.0.13
#tool nuget:?package=Cake.MonoApiTools&version=2.0.0
#tool nuget:?package=Microsoft.DotNet.BuildTools.GenAPI&version=1.0.0-beta-00081
#tool nuget:?package=NUnit.Runners&version=2.6.4
#tool nuget:?package=Paket

// Cake Addins
#addin nuget:?package=Cake.FileHelpers&version=3.0.0
#addin nuget:?package=Cake.Json&version=3.0.1
#addin nuget:?package=Newtonsoft.Json&version=9.0.1
#addin nuget:?package=Cake.Yaml&version=2.1.0
#addin nuget:?package=YamlDotNet&version=4.2.1
#addin nuget:?package=Cake.Xamarin&version=3.0.0
#addin nuget:?package=Cake.XCode&version=4.0.0
#addin nuget:?package=Cake.Xamarin.Build&version=4.0.0
#addin nuget:?package=SharpZipLib&version=0.86.0
#addin nuget:?package=Cake.Compression&version=0.1.6
#addin nuget:?package=Cake.Android.SdkManager&version=3.0.0
#addin nuget:?package=Cake.Android.Adb&version=3.0.0
#addin nuget:?package=Cake.MonoApiTools&version=2.0.0
#addin nuget:?package=Cake.Xamarin.Binding.Util&version=2.0.0

// From Cake.Xamarin.Build, dumps out versions of things
LogSystemInfo ();

var TARGET = Argument ("t", Argument ("target", "Default"));
var BUILD_CONFIG = Argument ("config", "Release");

// Lists all the artifacts and their versions for com.android.support.*
// https://dl.google.com/dl/android/maven2/com/android/support/group-index.xml
// Master list of all the packages in the repo:
// https://dl.google.com/dl/android/maven2/master-index.xml

var NUGET_PRE = "";

var NUGET_VERSION = "27.0.2.1" + NUGET_PRE;
var COMPONENT_VERSION = "27.0.2.0";
var AAR_VERSION = "27.0.2";

var ARCH_CORE_COMMON_AAR_VERSION = "1.0.0";
var ARCH_CORE_RUNTIME_AAR_VERSION = "1.0.0";
var ARCH_LIFECYCLE_COMMON_AAR_VERSION = "1.0.3";
var ARCH_LIFECYCLE_RUNTIME_AAR_VERSION = "1.0.3";
var ARCH_LIFECYCLE_EXTENSIONS_AAR_VERSION = "1.0.0";

var ARCH_CORE_COMMON_NUGET_VERSION = "1.0.0.1" + NUGET_PRE;
var ARCH_CORE_RUNTIME_NUGET_VERSION = "1.0.0.1" + NUGET_PRE;
var ARCH_LIFECYCLE_COMMON_NUGET_VERSION = "1.0.3.1" + NUGET_PRE;
var ARCH_LIFECYCLE_RUNTIME_NUGET_VERSION = "1.0.3.1" + NUGET_PRE;
var ARCH_LIFECYCLE_EXTENSIONS_NUGET_VERSION = "1.0.0.1" + NUGET_PRE;


var DOC_VERSION = "2017-12-18";


var SUPPORT_PKG_NAME = "com.android.support";
var ARCH_LIFECYCLE_PKG_NAME = "android.arch.lifecycle";
var ARCH_CORE_PKG_NAME = "android.arch.core";

// FROM: https://dl.google.com/android/repository/addon2-1.xml
var MAVEN_REPO_URL = "https://dl.google.com/dl/android/maven2/";
var BUILD_TOOLS_URL = "https://dl-ssl.google.com/android/repository/build-tools_r27-macosx.zip";
var ANDROID_SDK_VERSION = IsRunningOnWindows () ? "v8.0" : "android-26";
var RENDERSCRIPT_FOLDER = "android-8.1.0";
var REFERENCE_DOCS_URL = "https://developer.android.com/reference/";
var REFERENCE_DOCS_PACKAGELIST_URL = REFERENCE_DOCS_URL + "android/support/package-list";

// We grab the previous release's api-info.xml to use as a comparison for this build's generated info to make an api-diff
var BASE_API_INFO_URL = EnvironmentVariable("MONO_API_INFO_XML_URL") ?? "https://github.com/xamarin/AndroidSupportComponents/releases/download/27.0.2/api-info.xml";

var CPU_COUNT = 1;
var USE_MSBUILD_ON_MAC = true;

var ARTIFACTS = new [] {
	new ArtifactInfo (ARCH_CORE_PKG_NAME, "common", "Xamarin.Android.Arch.Core.Common", ARCH_CORE_COMMON_AAR_VERSION, ARCH_CORE_COMMON_NUGET_VERSION, "1.0.0.0", true) { PathPrefix = "arch-core/" },
	new ArtifactInfo (ARCH_CORE_PKG_NAME, "runtime", "Xamarin.Android.Arch.Core.Runtime", ARCH_CORE_RUNTIME_AAR_VERSION, ARCH_CORE_RUNTIME_NUGET_VERSION, "1.0.0.0") { PathPrefix = "arch-core/" },
	new ArtifactInfo (ARCH_LIFECYCLE_PKG_NAME, "common", "Xamarin.Android.Arch.Lifecycle.Common", ARCH_LIFECYCLE_COMMON_AAR_VERSION, ARCH_LIFECYCLE_COMMON_NUGET_VERSION, "1.0.3.0", true) { PathPrefix = "arch-lifecycle/" },
	new ArtifactInfo (ARCH_LIFECYCLE_PKG_NAME, "runtime", "Xamarin.Android.Arch.Lifecycle.Runtime", ARCH_LIFECYCLE_RUNTIME_AAR_VERSION, ARCH_LIFECYCLE_RUNTIME_NUGET_VERSION, "1.0.3.0") { PathPrefix = "arch-lifecycle/" },
	new ArtifactInfo (ARCH_LIFECYCLE_PKG_NAME, "extensions", "Xamarin.Android.Arch.Lifecycle.Extensions", ARCH_LIFECYCLE_EXTENSIONS_AAR_VERSION, ARCH_LIFECYCLE_EXTENSIONS_NUGET_VERSION, "1.0.0.0") { PathPrefix = "arch-lifecycle/" },

	//new ArtifactInfo (SUPPORT_PKG_NAME, "support-v4", "Xamarin.Android.Support.v4", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "support-v13", "Xamarin.Android.Support.v13", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "appcompat-v7", "Xamarin.Android.Support.v7.AppCompat", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "gridlayout-v7", "Xamarin.Android.Support.v7.GridLayout", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "mediarouter-v7", "Xamarin.Android.Support.v7.MediaRouter", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "recyclerview-v7", "Xamarin.Android.Support.v7.RecyclerView", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "palette-v7", "Xamarin.Android.Support.v7.Palette", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "cardview-v7", "Xamarin.Android.Support.v7.CardView", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "leanback-v17", "Xamarin.Android.Support.v17.Leanback", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "design", "Xamarin.Android.Support.Design", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "percent", "Xamarin.Android.Support.Percent", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "customtabs", "Xamarin.Android.Support.CustomTabs", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "preference-v7", "Xamarin.Android.Support.v7.Preference", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "preference-v14", "Xamarin.Android.Support.v14.Preference", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "preference-leanback-v17", "Xamarin.Android.Support.v17.Preference.Leanback", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "recommendation", "Xamarin.Android.Support.Recommendation", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "animated-vector-drawable", "Xamarin.Android.Support.Animated.Vector.Drawable", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "support-vector-drawable", "Xamarin.Android.Support.Vector.Drawable", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "support-compat", "Xamarin.Android.Support.Compat", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "support-content", "Xamarin.Android.Support.Content", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "support-core-utils", "Xamarin.Android.Support.Core.Utils", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "support-core-ui", "Xamarin.Android.Support.Core.UI", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "support-dynamic-animation", "Xamarin.Android.Support.Dynamic.Animation", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "support-media-compat", "Xamarin.Android.Support.Media.Compat", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "support-fragment", "Xamarin.Android.Support.Fragment", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "support-tv-provider", "Xamarin.Android.Support.TV.Provider", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "transition", "Xamarin.Android.Support.Transition", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "exifinterface", "Xamarin.Android.Support.Exif", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "wear", "Xamarin.Android.Support.Wear", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "support-annotations", "Xamarin.Android.Support.Annotations", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION, true),
	new ArtifactInfo (SUPPORT_PKG_NAME, "support-emoji", "Xamarin.Android.Support.Emoji", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "support-emoji-appcompat", "Xamarin.Android.Support.Emoji.AppCompat", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "support-emoji-bundled", "Xamarin.Android.Support.Emoji.Bundled", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),

	new ArtifactInfo (SUPPORT_PKG_NAME, "renderscript-v8", "Xamarin.Android.Support.v8.RenderScript", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
};

class PartialZipInfo {
	public string Url { get;set; }
	public string LocalPath { get;set; }
	public string Md5 { get;set; }
	public long RangeStart { get;set; }
	public long RangeEnd { get;set; }
}

class ArtifactInfo
{
	public ArtifactInfo (string package, string artifactId, string nugetId, string artifactVersion, string nugetVersion, string componentVersion, bool isJar = false)
	{
		Package = package;
		ArtifactId = artifactId;
		NugetId = nugetId;
		ArtifactVersion = artifactVersion;
		NuGetVersion = nugetVersion;
		ComponentVersion = componentVersion;
		IsJar = isJar;
		PathPrefix = string.Empty;
	}

	public string Package { get; set; }
	public string ArtifactId { get; set; }
	public string NugetId { get;set; }
	public string ArtifactVersion { get; set; }
	public string NuGetVersion { get; set; }
	public string ComponentVersion { get; set; }
	public bool IsJar { get; set; }
	public string PathPrefix { get;set; }
}

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

var nugetInfos = ARTIFACTS.Select (a => new NuGetInfo { NuSpec = "./" + a.PathPrefix + a.ArtifactId + "/nuget/" + a.NugetId + ".nuspec", Version = a.NuGetVersion, RequireLicenseAcceptance = true }).ToList ();
nugetInfos.Add (new NuGetInfo { NuSpec = "./support-v4/nuget/Xamarin.Android.Support.v4.nuspec", Version = NUGET_VERSION, RequireLicenseAcceptance = true });

var buildSpec = new BuildSpec {
	Libs = new [] {
		new DefaultSolutionBuilder {
			SolutionPath = "./AndroidSupport.sln",
			BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac,
			MaxCpuCount = CPU_COUNT,
			AlwaysUseMSBuild = USE_MSBUILD_ON_MAC,
			Verbosity = Cake.Core.Diagnostics.Verbosity.Diagnostic,
			OutputFiles = ARTIFACTS.Select (a => new OutputFileCopy { FromFile = "./" + a.PathPrefix + a.ArtifactId + "/source/bin/" + BUILD_CONFIG + "/" + a.NugetId + ".dll" }).ToArray (),
		}
	},

	Samples = new [] {
		new DefaultSolutionBuilder { SolutionPath = "./customtabs/samples/ChromeCustomTabsSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT, AlwaysUseMSBuild = USE_MSBUILD_ON_MAC },
		new DefaultSolutionBuilder { SolutionPath = "./design/samples/Cheesesquare.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT, AlwaysUseMSBuild = USE_MSBUILD_ON_MAC },
		new DefaultSolutionBuilder { SolutionPath = "./percent/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT, AlwaysUseMSBuild = USE_MSBUILD_ON_MAC },
		new DefaultSolutionBuilder { SolutionPath = "./recommendation/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT, AlwaysUseMSBuild = USE_MSBUILD_ON_MAC },
		new DefaultSolutionBuilder { SolutionPath = "./support-v4/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT, AlwaysUseMSBuild = USE_MSBUILD_ON_MAC },
		//new DefaultSolutionBuilder { SolutionPath = "./appcompat-v7/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT, AlwaysUseMSBuild = USE_MSBUILD_ON_MAC },
		new DefaultSolutionBuilder { SolutionPath = "./cardview-v7/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT, AlwaysUseMSBuild = USE_MSBUILD_ON_MAC },
		new DefaultSolutionBuilder { SolutionPath = "./gridlayout-v7/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT, AlwaysUseMSBuild = USE_MSBUILD_ON_MAC },
		//new DefaultSolutionBuilder { SolutionPath = "./mediarouter-v7/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT, AlwaysUseMSBuild = USE_MSBUILD_ON_MAC },
		new DefaultSolutionBuilder { SolutionPath = "./palette-v7/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT, AlwaysUseMSBuild = USE_MSBUILD_ON_MAC },
		new DefaultSolutionBuilder { SolutionPath = "./preference-v7/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT, AlwaysUseMSBuild = USE_MSBUILD_ON_MAC },
		new DefaultSolutionBuilder { SolutionPath = "./recyclerview-v7/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT, AlwaysUseMSBuild = USE_MSBUILD_ON_MAC },
		new DefaultSolutionBuilder { SolutionPath = "./renderscript-v8/samples/RenderScriptSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT, AlwaysUseMSBuild = USE_MSBUILD_ON_MAC },
		new DefaultSolutionBuilder { SolutionPath = "./support-v13/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT, AlwaysUseMSBuild = USE_MSBUILD_ON_MAC },
		new DefaultSolutionBuilder { SolutionPath = "./leanback-v17/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT, AlwaysUseMSBuild = USE_MSBUILD_ON_MAC },
		new DefaultSolutionBuilder { SolutionPath = "./support-vector-drawable/samples/VectorDrawableSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT, AlwaysUseMSBuild = USE_MSBUILD_ON_MAC },
		new DefaultSolutionBuilder { SolutionPath = "./animated-vector-drawable/samples/VectorDrawableSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT, AlwaysUseMSBuild = USE_MSBUILD_ON_MAC },
	},

	NuGets = nugetInfos.ToArray (),

	Components = new [] {
		new Component { ManifestDirectory = "./animated-vector-drawable/component" },
		new Component { ManifestDirectory = "./customtabs/component" },
		new Component { ManifestDirectory = "./design/component" },
		new Component { ManifestDirectory = "./percent/component" },
		new Component { ManifestDirectory = "./recommendation/component" },
		new Component { ManifestDirectory = "./support-v4/component" },
		//new Component { ManifestDirectory = "./appcompat-v7/component" },
		new Component { ManifestDirectory = "./cardview-v7/component" },
		new Component { ManifestDirectory = "./gridlayout-v7/component" },
		new Component { ManifestDirectory = "./palette-v7/component" },
		new Component { ManifestDirectory = "./preference-v7/component" },
		new Component { ManifestDirectory = "./recyclerview-v7/component" },
		new Component { ManifestDirectory = "./renderscript-v8/component" },
		new Component { ManifestDirectory = "./support-v13/component" },
		new Component { ManifestDirectory = "./leanback-v17/component" },
		new Component { ManifestDirectory = "./support-vector-drawable/component" },
	}

};


var NUGET_SOURCES = EnvironmentVariable ("NUGET_SOURCES") ?? string.Empty;
if (!string.IsNullOrEmpty (NUGET_SOURCES))
	buildSpec.NuGetSources = NUGET_SOURCES.Split (';',',').Select (ns => new NuGetSource { Url = ns }).ToArray ();

// You shouldn't have to configure anything below here
// ######################################################

Task ("externals")
	.WithCriteria (() => !FileExists ("./externals/support-v4/classes.jar"))
	.IsDependentOn ("droiddocs")
	.IsDependentOn ("externals-base")
	.Does (() =>
{
	var path = "./externals/";

	EnsureDirectoryExists (path);

	// Copy the .aar's to a better location
	foreach (var art in ARTIFACTS) {

		// Manually process renderscript later
		if (art.ArtifactId == "renderscript-v8")
			continue;

		var localArtifact = new FilePath ("./externals/"  + art.PathPrefix + art.ArtifactId + (art.IsJar ? ".jar" : ".aar"));
		var artifactUrl = MAVEN_REPO_URL + art.Package.Replace (".", "/") + "/" + art.ArtifactId + "/" + art.ArtifactVersion + "/" + art.ArtifactId + "-" + art.ArtifactVersion + (art.IsJar ? ".jar" : ".aar");

		if (!FileExists (localArtifact)) {
			EnsureDirectoryExists (localArtifact.GetDirectory ());
			DownloadFile (artifactUrl, localArtifact);
		}

		// Open and fix .aar files
		if (!art.IsJar) {
			// Cake.Xamarin.Build has some good android aar fixes before we embed it
			// https://github.com/Redth/Cake.Xamarin.Build/blob/master/Cake.Xamarin.Build/AndroidAarFixer.cs#L24-L152
			FixAndroidAarFile(localArtifact, art.ArtifactId, true, true);

			// Only unzip if it doesn't exist
			if (!DirectoryExists("./externals/" + art.PathPrefix + art.ArtifactId))
				Unzip (localArtifact, "./externals/" + art.PathPrefix + art.ArtifactId);
		}
	}

	// Get Renderscript
	if (!FileExists (path + "buildtools.zip"))
		DownloadFile (BUILD_TOOLS_URL, path + "buildtools.zip");
	if (!FileExists (path + "build-tools/renderscript/lib/renderscript-v8.jar")) {
		Unzip (path + "buildtools.zip", path);
		CopyDirectory (path + RENDERSCRIPT_FOLDER, path + "build-tools");
		DeleteDirectory (path + RENDERSCRIPT_FOLDER, true);
	}

	// Download v4 manually since we build it separately as a type forwarder lib and it isn't downloaded in the set of main externals 
	var supportV4ArtifactUrl = MAVEN_REPO_URL + SUPPORT_PKG_NAME.Replace (".", "/") + "/support-v4/" + AAR_VERSION + "/support-v4-" + AAR_VERSION + ".aar";
	DownloadFile (supportV4ArtifactUrl, "./externals/support-v4.aar");
	Unzip ("./externals/support-v4.aar", "./externals/support-v4");

	// Fix naming for some of the arch libraries that have duplicate names of each other
	MoveFile ("./externals/arch-core/common.jar", "./externals/arch-core/arch-core-common.jar");
	MoveFile ("./externals/arch-core/runtime.aar", "./externals/arch-core/arch-core-runtime.aar");
	MoveFile ("./externals/arch-lifecycle/common.jar", "./externals/arch-lifecycle/arch-lifecycle-common.jar");
	MoveFile ("./externals/arch-lifecycle/runtime.aar", "./externals/arch-lifecycle/arch-lifecycle-runtime.aar");
	MoveFile ("./externals/arch-lifecycle/extensions.aar", "./externals/arch-lifecycle/arch-lifecycle-extensions.aar");
});

Task ("diff")
	.WithCriteria (!IsRunningOnWindows ())
	.IsDependentOn ("merge")
	.Does (() =>
{
	var SEARCH_DIRS = new FilePath [] {
		MONODROID_PATH,
		"/Library/Frameworks/Xamarin.Android.framework/Versions/Current/lib/xbuild-frameworks/MonoAndroid/v1.0/",
		"/Library/Frameworks/Xamarin.Android.framework/Versions/Current/lib/mono/2.1/"
	};

	MonoApiInfo ("./output/AndroidSupport.Merged.dll",
		"./output/AndroidSupport.api-info.xml",
		new MonoApiInfoToolSettings { SearchPaths = SEARCH_DIRS });

	// Grab the last public release's api-info.xml to use as a base to compare and make an API diff
	DownloadFile (BASE_API_INFO_URL, "./output/AndroidSupport.api-info.previous.xml");

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
	if (FileExists ("./output/AndroidSupport.Merged.dll"))
		DeleteFile ("./output/AndroidSupport.Merged.dll");

	var mergeDlls = GetFiles ("./output/*.dll");

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

Task ("nuget-setup")
	.IsDependentOn ("buildtasks")
	.Does (() => 
{
	Action<FilePath, FilePath> mergeTargetsFiles = (FilePath fromFile, FilePath intoFile) =>
	{
		// Load the doc to append to, and the doc to append
		var xOrig = System.Xml.Linq.XDocument.Load (MakeAbsolute(intoFile).FullPath);
		System.Xml.Linq.XNamespace nsOrig = xOrig.Root.Name.Namespace;
		var xMerge = System.Xml.Linq.XDocument.Load (MakeAbsolute(fromFile).FullPath);
		System.Xml.Linq.XNamespace nsMerge = xMerge.Root.Name.Namespace;
		// Add all the elements under <Project> into the existing file's <Project> node
		foreach (var xItemToAdd in xMerge.Element (nsMerge + "Project").Elements ())
			xOrig.Element (nsOrig + "Project").Add (xItemToAdd);

		xOrig.Save (MakeAbsolute (intoFile).FullPath);
	};

	var templateText = FileReadText ("./template.targets");

	var nugetArtifacts = ARTIFACTS.ToList ();
	nugetArtifacts.Add (new ArtifactInfo (SUPPORT_PKG_NAME, "support-v4", "Xamarin.Android.Support.v4", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION));

	foreach (var art in nugetArtifacts) {

		var proguardFile = new FilePath(string.Format("./externals/{0}/proguard.txt", art.PathPrefix + art.ArtifactId));

		var targetsText = templateText;
		var targetsFile = new FilePath(string.Format ("{0}/nuget/{1}.targets", art.PathPrefix + art.ArtifactId, art.NugetId));
		FileWriteText (targetsFile, targetsText);

		// Transform all .targets files
		var xTargets = System.Xml.Linq.XDocument.Load (MakeAbsolute(targetsFile).FullPath);
		System.Xml.Linq.XNamespace nsTargets = xTargets.Root.Name.Namespace;

		if (FileExists (proguardFile)) {
			var projElem = xTargets.Element(nsTargets + "Project");

			Information ("Adding {0} to {1}", "proguard.txt", targetsFile);

			projElem.Add (new System.Xml.Linq.XElement (nsTargets + "ItemGroup", 
				new System.Xml.Linq.XElement (nsTargets + "ProguardConfiguration",
					new System.Xml.Linq.XAttribute ("Include", "$(MSBuildThisFileDirectory)..\\..\\proguard\\proguard.txt"))));
		}

		xTargets.Save (MakeAbsolute(targetsFile).FullPath);

		// Check for an existing .targets file in this nuget package
		// we need to merge the generated one with it if it exists
		// nuget only allows one automatic .targets file in the build/ folder
		// of the nuget package, which must be named {nuget-package-id}.targets
		// so we need to merge them all into one
		var mergeFile = new FilePath (art.PathPrefix + art.ArtifactId + "/nuget/merge.targets");

		if (FileExists (mergeFile)) {
			Information ("merge.targets found, merging into generated file...");
			mergeTargetsFiles (mergeFile, targetsFile);
		}

		// Transform all template.nuspec files
		var nuspecText = FileReadText(art.PathPrefix + art.ArtifactId + "/nuget/template.nuspec");

		// We use a pattern of $package.id.artifact.id$ as a placeholder in nuspec templates
		// which we want to substitute the actual nuget version into
		// So for example $com.android.support.support-compat$ would get replaced with the nuget version for Xamarin.Android.Support.Compat
		foreach (var artifactInfo in ARTIFACTS) {
			var placeholder = "$" + artifactInfo.Package + "." + artifactInfo.ArtifactId + "$";
			nuspecText = nuspecText.Replace(placeholder, artifactInfo.NuGetVersion);
		}

		//nuspecText = nuspecText.Replace ("$xbdversion$", XBD_VERSION);
		var nuspecFile = new FilePath(art.PathPrefix + art.ArtifactId + "/nuget/" + art.NugetId + ".nuspec");
		FileWriteText(nuspecFile, nuspecText);
		var xNuspec = System.Xml.Linq.XDocument.Load (MakeAbsolute(nuspecFile).FullPath);
		System.Xml.Linq.XNamespace nsNuspec = xNuspec.Root.Name.Namespace;

		// Check if we have a proguard.txt file for this artifact and include it in the nuspec if so
		if (FileExists (proguardFile)) {
			Information ("Adding {0} to {1}", "proguard.txt", nuspecFile);
			var filesElems = xNuspec.Root.Descendants (nsNuspec + "files");

			if (filesElems != null) {
				var filesElem = filesElems.First();
				filesElem.Add (new System.Xml.Linq.XElement (nsNuspec + "file", 
					new System.Xml.Linq.XAttribute(nsNuspec + "src", proguardFile.ToString()),
					new System.Xml.Linq.XAttribute(nsNuspec + "target", "proguard/proguard.txt")));
			} 
		}

	 	xNuspec.Save(MakeAbsolute(nuspecFile).FullPath);
	}
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

	foreach (var art in ARTIFACTS) {
		var glob = "./" + art.PathPrefix + art.ArtifactId + "/**/source/**/AssemblyInfo.cs";

		ReplaceTextInFiles(glob, "{NUGET_VERSION}", art.NuGetVersion);
		ReplaceTextInFiles(glob, "{BUILD_COMMIT}", buildCommit);
		ReplaceTextInFiles(glob, "{BUILD_NUMBER}", buildNumber);
		ReplaceTextInFiles(glob, "{BUILD_TIMESTAMP}", buildTimestamp);
	}
});

Task ("component-setup")
	.Does (() =>
{
	var yamls = GetFiles ("./**/component/component.template.yaml");

	foreach (var yaml in yamls) {
		var manifestTxt = FileReadText (yaml)
			.Replace ("$nuget-version$", NUGET_VERSION)
			.Replace ("$version$", COMPONENT_VERSION);

		var newYaml = yaml.GetDirectory ().CombineWithFilePath ("component.yaml");

		FileWriteText (newYaml, manifestTxt);
	}
});

Task ("component-docs")
	.IsDependentOn ("component-setup")
	.Does (() =>
{
	var gettingStartedTemplates = new Dictionary<string, string> ();

	foreach (var f in GetFiles ("./component/GettingStarted.*.md")) {

		var key = f.GetFilenameWithoutExtension ().FullPath.Replace ("GettingStarted.", "");
		var val = TransformTextFile (f).ToString ();

		gettingStartedTemplates.Add (key, val);
	}

	var componentDirs = GetDirectories ("./*");

	foreach (var compDir in componentDirs)
		Information ("Found: {0}", compDir);

	foreach (var compDir in componentDirs) {

		var f = compDir.CombineWithFilePath ("./component/GettingStarted.template.md");

		if (!FileExists (f))
			continue;

		Information ("Transforming: {0}", compDir);

		var apiLevel = "Android 4.0.3 (API Level 15)";

		var t = TransformTextFile (f, "{", "}");

		foreach (var kvp in gettingStartedTemplates) {
			var v = TransformText (kvp.Value, "{", "}").WithToken ("APILEVEL", apiLevel).ToString ();
			t = t.WithToken (kvp.Key, v);
		}

		FileWriteText (compDir.CombineWithFilePath ("./component/GettingStarted.md"), t.ToString ());
	}


	var detailsTemplates = new Dictionary<string, string> ();

	foreach (var f in GetFiles ("./component/Details.*.md")) {

		var key = f.GetFilenameWithoutExtension ().FullPath.Replace ("Details.", "");
		var val = TransformTextFile (f).ToString ();

		detailsTemplates.Add (key, val);
	}

	foreach (var compDir in componentDirs) {

		var f = compDir.CombineWithFilePath ("./component/Details.template.md");

		if (!FileExists (f))
			continue;

		Information ("Transforming: {0}", compDir);

		var t = TransformTextFile (f, "{", "}");

		foreach (var kvp in detailsTemplates)
			t = t.WithToken (kvp.Key, kvp.Value);

		FileWriteText (compDir.CombineWithFilePath ("./component/Details.md"), t.ToString ());
	}
});

Task ("genapi")
	.IsDependentOn ("externals")
	.IsDependentOn ("libs-base")
	.Does (() => 
{
	var GenApiToolPath = GetFiles ("./tools/**/GenAPI.exe").FirstOrDefault ();

	// For some reason GenAPI.exe can't handle absolute paths on mac/unix properly, so always make them relative
	// GenAPI.exe -libPath:$(MONOANDROID) -out:Some.generated.cs -w:TypeForwards ./relative/path/to/Assembly.dll
	var libDirPrefix = IsRunningOnWindows () ? "output/" : "";

	var libs = new FilePath [] {
		"./" + libDirPrefix + "Xamarin.Android.Support.Compat.dll",
		"./" + libDirPrefix + "Xamarin.Android.Support.Core.UI.dll",
		"./" + libDirPrefix + "Xamarin.Android.Support.Core.Utils.dll",
		"./" + libDirPrefix + "Xamarin.Android.Support.Fragment.dll",
		"./" + libDirPrefix + "Xamarin.Android.Support.Media.Compat.dll",
	};


	foreach (var lib in libs) {
		var genName = lib.GetFilename () + ".generated.cs";

		var libPath = IsRunningOnWindows () ? MakeAbsolute (lib).FullPath : lib.FullPath;
		var monoDroidPath = IsRunningOnWindows () ? "\"" + MONODROID_PATH + "\"" : MONODROID_PATH;

		Information ("GenAPI: {0}", lib.FullPath);

		StartProcess (GenApiToolPath, new ProcessSettings {
			Arguments = string.Format("-libPath:{0} -out:{1}{2} -w:TypeForwards {3}",
							monoDroidPath + "," + MSCORLIB_PATH,
							IsRunningOnWindows () ? "" : "./",
							genName,
							libPath),
			WorkingDirectory = "./output/",
		});
	}

	MSBuild ("./AndroidSupport.TypeForwarders.sln", c => c.Configuration = BUILD_CONFIG);

	CopyFile ("./support-v4/source/bin/" + BUILD_CONFIG + "/Xamarin.Android.Support.v4.dll", "./output/Xamarin.Android.Support.v4.dll");
});

Task ("buildtasks")
	.Does (() => 
{
	NuGetRestore ("./support-vector-drawable/buildtask/Vector-Drawable-BuildTasks.csproj");

	MSBuild ("./support-vector-drawable/buildtask/Vector-Drawable-BuildTasks.csproj", c => c.Configuration = BUILD_CONFIG);
});


Task ("droiddocs")
	.Does (() => 
{
	EnsureDirectoryExists("./output");

	var compressedDocsFile = "./output/docs-" + DOC_VERSION + ".zip";

	if (!FileExists(compressedDocsFile)) {
		if (IsRunningOnWindows ())
			StartProcess ("util/droiddocs.exe", "scrape --out ./docs --url  " + REFERENCE_DOCS_URL + " --package-list-source " + REFERENCE_DOCS_PACKAGELIST_URL + " --package-filter \"android.support\"");
		else
			StartProcess ("mono", "util/droiddocs.exe scrape --out ./docs --url  " + REFERENCE_DOCS_URL + " --package-list-source " + REFERENCE_DOCS_PACKAGELIST_URL + " --package-filter \"android.support\"");

		// Scraper misses a few files we require
		EnsureDirectoryExists("./docs/reference");
		DownloadFile(REFERENCE_DOCS_URL + "classes.html", "./docs/reference/classes.html");
		CopyFile ("./docs/reference/classes.html", "./docs/reference/index.html");
		DownloadFile(REFERENCE_DOCS_URL + "packages.html", "./docs/reference/packages.html");
		

		ZipCompress ("./docs", compressedDocsFile);
	}

	if (!DirectoryExists("./docs"))
		Unzip (compressedDocsFile, "./docs");

	if (!FileExists("./Metadata.generated.xml")) {
		// Generate metadata file from docs
		if (IsRunningOnWindows ())
			StartProcess ("util/droiddocs.exe", "transform --out ./Metadata.generated.xml --type Metadata --dir ./docs --prefix \"/reference/\" --package-filter \"android.support\"");
		else
			StartProcess ("mono", "util/droiddocs.exe transform --out ./Metadata.generated.xml --type Metadata --dir ./docs --prefix \"/reference/\" --package-filter \"android.support\"");
	}
});

Task ("clean")
	.IsDependentOn ("clean-base")
	.Does (() =>
{
	if (FileExists ("./generated.targets"))
		DeleteFile ("./generated.targets");

	if (DirectoryExists ("./externals"))
		DeleteDirectory ("./externals", true);

	CleanDirectories ("./**/packages");
});

Task ("nuget")
	.IsDependentOn ("libs")
	.IsDependentOn ("nuget-setup")
	.IsDependentOn ("nuget-base");

Task ("component")
	.IsDependentOn ("nuget")
	.IsDependentOn ("component-docs")
	.IsDependentOn ("component-base");
	
Task ("libs")
	.IsDependentOn ("externals")
	.IsDependentOn ("nuget-setup")
	.IsDependentOn ("libs-base")
	.IsDependentOn ("genapi");

Task ("ci")
	.IsDependentOn ("ci-setup")
	.IsDependentOn ("diff")
	.IsDependentOn ("component");

SetupXamarinBuildTasks (buildSpec, Tasks, Task);

RunTarget (TARGET);
