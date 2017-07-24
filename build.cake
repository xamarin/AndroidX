#tool nuget:?package=ILRepack&version=2.0.10
#tool nuget:?package=XamarinComponent
#tool nuget:?package=Cake.MonoApiTools
#tool nuget:?package=Microsoft.DotNet.BuildTools.GenAPI&version=1.0.0-beta-00081

#addin nuget:?package=Cake.Compression
#addin nuget:?package=Cake.Json
#addin nuget:?package=Cake.XCode
#addin nuget:?package=Cake.Xamarin
#addin nuget:?package=Cake.Xamarin.Build&version=2.0.18
#addin nuget:?package=Cake.FileHelpers
#addin nuget:?package=Cake.MonoApiTools

// From Cake.Xamarin.Build, dumps out versions of things
LogSystemInfo ();

var TARGET = Argument ("t", Argument ("target", "Default"));
var BUILD_CONFIG = Argument ("config", "Release");

var NUGET_VERSION = "25.4.0.1";
var COMPONENT_VERSION = "25.4.0.0";
var AAR_VERSION = "25.4.0";
var XBD_VERSION = "0.4.6";

var SUPPORT_PKG_NAME = "com.android.support";

// FROM: https://dl.google.com/android/repository/addon2-1.xml
var MAVEN_REPO_URL = "https://dl.google.com/dl/android/maven2/";
var BUILD_TOOLS_URL = "https://dl-ssl.google.com/android/repository/build-tools_r26-rc2-macosx.zip";
var ANDROID_SDK_VERSION = IsRunningOnWindows () ? "v7.1" : "android-25";
var RENDERSCRIPT_FOLDER = "android-O";

// We grab the previous release's api-info.xml to use as a comparison for this build's generated info to make an api-diff
var BASE_API_INFO_URL = "https://github.com/xamarin/AndroidSupportComponents/releases/download/25.3.1/api-info.xml";

var CPU_COUNT = System.Environment.ProcessorCount;
var USE_MSBUILD_ON_MAC = true;

// MSBUILD has issues on *nix/osx with a different CPU Count being specified
if (!IsRunningOnWindows())
	CPU_COUNT = 1;

var ARTIFACTS = new [] {
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
	new ArtifactInfo (SUPPORT_PKG_NAME, "instantvideo", "Xamarin.Android.Support.InstantVideo", "26.0.0-alpha1", "26.0.0-alpha1", COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "customtabs", "Xamarin.Android.Support.CustomTabs", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "preference-v7", "Xamarin.Android.Support.v7.Preference", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "preference-v14", "Xamarin.Android.Support.v14.Preference", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "preference-leanback-v17", "Xamarin.Android.Support.v17.Preference.Leanback", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "recommendation", "Xamarin.Android.Support.Recommendation", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "animated-vector-drawable", "Xamarin.Android.Support.Animated.Vector.Drawable", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "support-vector-drawable", "Xamarin.Android.Support.Vector.Drawable", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "support-compat", "Xamarin.Android.Support.Compat", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "support-core-utils", "Xamarin.Android.Support.Core.Utils", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "support-core-ui", "Xamarin.Android.Support.Core.UI", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "support-dynamic-animation", "Xamarin.Android.Support.Dynamic.Animation", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "support-media-compat", "Xamarin.Android.Support.Media.Compat", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "support-fragment", "Xamarin.Android.Support.Fragment", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	//new ArtifactInfo (SUPPORT_PKG_NAME, "support-tv-provider", "Xamarin.Android.Support.TV.Provider", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "transition", "Xamarin.Android.Support.Transition", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "exifinterface", "Xamarin.Android.Support.Exif", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "wearable", "Xamarin.Android.Support.Wearable", "26.0.0-alpha1", "26.0.0-alpha1", COMPONENT_VERSION),
	new ArtifactInfo (SUPPORT_PKG_NAME, "support-annotations", "Xamarin.Android.Support.Annotations", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION, true),
	//new ArtifactInfo (SUPPORT_PKG_NAME, "support-emoji", "Xamarin.Android.Support.Emoji", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	//new ArtifactInfo (SUPPORT_PKG_NAME, "support-emoji-appcompat", "Xamarin.Android.Support.Emoji.AppCompat", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	//new ArtifactInfo (SUPPORT_PKG_NAME, "support-emoji-bundled", "Xamarin.Android.Support.Emoji.Bundled", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),

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
	}

	public string Package { get; set; }
	public string ArtifactId { get; set; }
	public string NugetId { get;set; }
	public string ArtifactVersion { get; set; }
	public string NuGetVersion { get; set; }
	public string ComponentVersion { get; set; }
	public bool IsJar { get; set; }
}

var MONODROID_PATH = "/Library/Frameworks/Xamarin.Android.framework/Versions/Current/lib/mandroid/platforms/" + ANDROID_SDK_VERSION + "/";
if (IsRunningOnWindows ())
	MONODROID_PATH = MakeAbsolute (new DirectoryPath (Environment.GetFolderPath (Environment.SpecialFolder.ProgramFilesX86)).Combine ("Reference Assemblies/Microsoft/Framework/MonoAndroid/" + ANDROID_SDK_VERSION +"/")).FullPath;

var MSCORLIB_PATH = "/Library/Frameworks/Xamarin.Android.framework/Libraries/mono/2.1/";
if (IsRunningOnWindows ()) {

	var DOTNETDIR = new DirectoryPath (Environment.GetFolderPath (Environment.SpecialFolder.Windows)).Combine ("Microsoft.NET/");

	if (DirectoryExists (DOTNETDIR.Combine ("Framework64")))
		MSCORLIB_PATH = MakeAbsolute (DOTNETDIR.Combine("Framework64/v4.0.30319/")).FullPath;
	else
		MSCORLIB_PATH = MakeAbsolute (DOTNETDIR.Combine("Framework/v4.0.30319/")).FullPath;
}

var nugetInfos = ARTIFACTS.Select (a => new NuGetInfo { NuSpec = "./" + a.ArtifactId + "/nuget/" + a.NugetId + ".nuspec", Version = NUGET_VERSION, RequireLicenseAcceptance = true }).ToList ();
nugetInfos.Add (new NuGetInfo { NuSpec = "./support-v4/nuget/Xamarin.Android.Support.v4.nuspec", Version = NUGET_VERSION, RequireLicenseAcceptance = true });

var buildSpec = new BuildSpec {
	Libs = new [] {
		new DefaultSolutionBuilder {
			SolutionPath = "./AndroidSupport.sln",
			BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac,
			MaxCpuCount = CPU_COUNT,
			AlwaysUseMSBuild = USE_MSBUILD_ON_MAC,
			Verbosity = Cake.Core.Diagnostics.Verbosity.Diagnostic,
			OutputFiles = ARTIFACTS.Select (a => new OutputFileCopy { FromFile = "./" + a.ArtifactId + "/source/bin/" + BUILD_CONFIG + "/" + a.NugetId + ".dll" }).ToArray (),
		}
	},

	Samples = new [] {
		new DefaultSolutionBuilder { SolutionPath = "./customtabs/samples/ChromeCustomTabsSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT, AlwaysUseMSBuild = USE_MSBUILD_ON_MAC },
		new DefaultSolutionBuilder { SolutionPath = "./design/samples/Cheesesquare.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT, AlwaysUseMSBuild = USE_MSBUILD_ON_MAC },
		new DefaultSolutionBuilder { SolutionPath = "./percent/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT, AlwaysUseMSBuild = USE_MSBUILD_ON_MAC },
		new DefaultSolutionBuilder { SolutionPath = "./recommendation/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT, AlwaysUseMSBuild = USE_MSBUILD_ON_MAC },
		new DefaultSolutionBuilder { SolutionPath = "./support-v4/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT, AlwaysUseMSBuild = USE_MSBUILD_ON_MAC },
		new DefaultSolutionBuilder { SolutionPath = "./appcompat-v7/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT, AlwaysUseMSBuild = USE_MSBUILD_ON_MAC },
		new DefaultSolutionBuilder { SolutionPath = "./cardview-v7/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT, AlwaysUseMSBuild = USE_MSBUILD_ON_MAC },
		new DefaultSolutionBuilder { SolutionPath = "./gridlayout-v7/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT, AlwaysUseMSBuild = USE_MSBUILD_ON_MAC },
		new DefaultSolutionBuilder { SolutionPath = "./mediarouter-v7/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT, AlwaysUseMSBuild = USE_MSBUILD_ON_MAC },
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
		new Component { ManifestDirectory = "./appcompat-v7/component" },
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
	.IsDependentOn ("externals-base")
	.IsDependentOn ("droiddocs")
	.WithCriteria (() => !FileExists ("./externals/support-v4/classes.jar"))
	.Does (() =>
{
	var path = "./externals/";

	EnsureDirectoryExists (path);

	// Copy the .aar's to a better location
	foreach (var art in ARTIFACTS) {

		// Manually process renderscript later
		if (art.ArtifactId == "renderscript-v8")
			continue;

		var localArtifact = "./externals/" + art.ArtifactId + (art.IsJar ? ".jar" : ".aar");
		var artifactUrl = MAVEN_REPO_URL + art.Package.Replace (".", "/") + "/" + art.ArtifactId + "/" + art.ArtifactVersion + "/" + art.ArtifactId + "-" + art.ArtifactVersion + (art.IsJar ? ".jar" : ".aar");

		if (!FileExists (localArtifact))
			DownloadFile (artifactUrl, localArtifact);

		// Open and fix .aar files
		if (!art.IsJar) {
			// Cake.Xamarin.Build has some good android aar fixes before we embed it
			// https://github.com/Redth/Cake.Xamarin.Build/blob/master/Cake.Xamarin.Build/AndroidAarFixer.cs#L24-L152
			FixAndroidAarFile(localArtifact, art.ArtifactId, true, true);

			// Only unzip if it doesn't exist
			if (!DirectoryExists("./externals/" + art.ArtifactId))
				Unzip (localArtifact, "./externals/" + art.ArtifactId);
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

Task ("merge").IsDependentOn ("libs").Does (() =>
{
	if (FileExists ("./output/AndroidSupport.Merged.dll"))
		DeleteFile ("./output/AndroidSupport.Merged.dll");

	var mergeDlls = GetFiles ("./output/*.dll");

	// Wait for ILRepack support in cake-0.5.2
	ILRepack ("./output/AndroidSupport.Merged.dll", mergeDlls.First(), mergeDlls.Skip(1), new ILRepackSettings {
		CopyAttrs = true,
		AllowMultiple = true,
		//TargetKind = ILRepack.TargetKind.Dll,
		Libs = new List<FilePath> {
			MONODROID_PATH
		},
	});
});


Task ("component-setup").Does (() =>
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

Task ("nuget-setup").IsDependentOn ("buildtasks").IsDependentOn ("externals")
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

		var proguardFile = new FilePath(string.Format("./externals/{0}/proguard.txt", art.ArtifactId));

		var targetsText = templateText;
		var targetsFile = new FilePath(string.Format ("{0}/nuget/{1}.targets", art.ArtifactId, art.NugetId));
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
		var mergeFile = new FilePath (art.ArtifactId + "/nuget/merge.targets");

		if (FileExists (mergeFile)) {
			Information ("merge.targets found, merging into generated file...");
			mergeTargetsFiles (mergeFile, targetsFile);
		}

		
		// Transform all template.nuspec files
		var nuspecText = FileReadText(art.ArtifactId + "/nuget/template.nuspec");
		nuspecText = nuspecText.Replace ("$xbdversion$", XBD_VERSION);
		var nuspecFile = new FilePath(art.ArtifactId + "/nuget/" + art.NugetId + ".nuspec");
		FileWriteText(nuspecFile, nuspecText);
		var xNuspec = System.Xml.Linq.XDocument.Load (MakeAbsolute(nuspecFile).FullPath);
		System.Xml.Linq.XNamespace nsNuspec = xNuspec.Root.Name.Namespace;

		// Check if we have a proguard.txt file for this artifact and include it in the nuspec if so
		if (FileExists (proguardFile)) {
			Information ("Adding {0} to {1}", "proguard.txt", nuspecFile);
			var filesElem = xNuspec.Root.Descendants (nsNuspec + "files")?.FirstOrDefault();
			filesElem.Add (new System.Xml.Linq.XElement (nsNuspec + "file", 
				new System.Xml.Linq.XAttribute(nsNuspec + "src", proguardFile.ToString()),
				new System.Xml.Linq.XAttribute(nsNuspec + "target", "proguard/proguard.txt")));
		}

	 	xNuspec.Save(MakeAbsolute(nuspecFile).FullPath);
	}
});

Task ("nuget").IsDependentOn ("nuget-setup").IsDependentOn ("nuget-base").IsDependentOn ("libs");
//Task ("nuget").IsDependentOn ("nuget-base").IsDependentOn ("libs");

Task ("component").IsDependentOn ("component-docs").IsDependentOn ("component-setup").IsDependentOn ("component-base").IsDependentOn ("libs");

Task ("clean").IsDependentOn ("clean-base").Does (() =>
{
	if (FileExists ("./generated.targets"))
		DeleteFile ("./generated.targets");

	if (DirectoryExists ("./externals"))
		DeleteDirectory ("./externals", true);

	CleanDirectories ("./**/packages");
});


Task ("component-docs").Does (() =>
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

//Task ("libs").IsDependentOn ("nuget-setup").IsDependentOn ("genapi").IsDependentOn ("libs-base");
Task ("libs").IsDependentOn ("genapi").IsDependentOn ("libs-base");
//Task ("libs").IsDependentOn ("libs-base");

Task ("genapi").IsDependentOn ("libs-base").IsDependentOn ("externals").Does (() => {

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

	DotNetBuild ("./AndroidSupport.TypeForwarders.sln", c => c.Configuration = BUILD_CONFIG);

	CopyFile ("./support-v4/source/bin/" + BUILD_CONFIG + "/Xamarin.Android.Support.v4.dll", "./output/Xamarin.Android.Support.v4.dll");
});

Task ("buildtasks").Does (() => 
{
	NuGetRestore ("./support-vector-drawable/buildtask/Vector-Drawable-BuildTasks.csproj");

	DotNetBuild ("./support-vector-drawable/buildtask/Vector-Drawable-BuildTasks.csproj", c => c.Configuration = BUILD_CONFIG);
});


Task ("droiddocs").Does(() => 
{
	EnsureDirectoryExists("./output");

	var compressedDocsFile = "./output/docs-" + AAR_VERSION + ".zip";

	if (!FileExists(compressedDocsFile)) {
		if (IsRunningOnWindows ())
			StartProcess ("util/droiddocs.exe", "scrape --out ./docs --url  https://developer.android.com/reference/ --package-filter \"android.support\"");
		else
			StartProcess ("mono", "util/droiddocs.exe scrape --out ./docs --url  https://developer.android.com/reference/ --package-filter \"android.support\"");

		// Scraper misses a few files we require
		EnsureDirectoryExists("./docs/reference");
		DownloadFile("https://developer.android.com/reference/classes.html", "./docs/reference/classes.html");
		CopyFile ("./docs/reference/classes.html", "./docs/reference/index.html");
		DownloadFile("https://developer.android.com/reference/packages.html", "./docs/reference/packages.html");
		

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


SetupXamarinBuildTasks (buildSpec, Tasks, Task);

RunTarget (TARGET);
