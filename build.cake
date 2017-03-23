#tool nuget:?package=ILRepack&version=2.0.10
#tool nuget:?package=XamarinComponent
#tool nuget:?package=Cake.MonoApiTools
#tool nuget:?package=Microsoft.DotNet.BuildTools.GenAPI&version=1.0.0-beta-00081

#addin nuget:?package=Cake.Json
#addin nuget:?package=Cake.XCode
#addin nuget:?package=Cake.Xamarin
#addin nuget:?package=Cake.Xamarin.Build&version=1.1.13
#addin nuget:?package=Cake.FileHelpers
#addin nuget:?package=Cake.MonoApiTools

// From Cake.Xamarin.Build, dumps out versions of things
LogSystemInfo ();

var TARGET = Argument ("t", Argument ("target", "Default"));

var NUGET_VERSION = "25.2.0";
var COMPONENT_VERSION = "25.2.0.0";
var AAR_VERSION = "25.2.0";

// FROM: https://dl.google.com/android/repository/addon2-1.xml
var M2_REPOSITORY_URL = "https://dl-ssl.google.com/android/repository/android_m2repository_r44.zip";
var BUILD_TOOLS_URL = "https://dl-ssl.google.com/android/repository/build-tools_r25-macosx.zip";
var ANDROID_SDK_VERSION = IsRunningOnWindows () ? "v7.0" : "android-24";
var RENDERSCRIPT_FOLDER = "android-7.1.1";

// We grab the previous release's api-info.xml to use as a comparison for this build's generated info to make an api-diff
var BASE_API_INFO_URL = "https://github.com/xamarin/AndroidSupportComponents/releases/download/25.1.1/api-info.xml";

var CPU_COUNT = System.Environment.ProcessorCount;

var AAR_INFOS = new [] {
	new AarInfo ("support-v4", "v4", "Xamarin.Android.Support.v4", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new AarInfo ("support-v13", "v13", "Xamarin.Android.Support.v13", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new AarInfo ("appcompat-v7", "v7-appcompat", "Xamarin.Android.Support.v7.AppCompat", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new AarInfo ("gridlayout-v7", "v7-gridlayout", "Xamarin.Android.Support.v7.GridLayout", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new AarInfo ("mediarouter-v7", "v7-mediarouter", "Xamarin.Android.Support.v7.MediaRouter", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new AarInfo ("recyclerview-v7", "v7-recyclerview", "Xamarin.Android.Support.v7.RecyclerView", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new AarInfo ("palette-v7", "v7-palette", "Xamarin.Android.Support.v7.Palette", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new AarInfo ("cardview-v7", "v7-cardview", "Xamarin.Android.Support.v7.CardView", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new AarInfo ("leanback-v17", "v17-leanback", "Xamarin.Android.Support.v17.Leanback", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new AarInfo ("design", "design", "Xamarin.Android.Support.Design", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new AarInfo ("percent", "percent", "Xamarin.Android.Support.Percent", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new AarInfo ("customtabs", "customtabs", "Xamarin.Android.Support.CustomTabs", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new AarInfo ("preference-v7", "v7-preference", "Xamarin.Android.Support.v7.Preference", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new AarInfo ("preference-v14", "v14-preference", "Xamarin.Android.Support.v14.Preference", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new AarInfo ("preference-leanback-v17", "v17-preference-leanback", "Xamarin.Android.Support.v17.Preference.Leanback", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new AarInfo ("recommendation", "recommendation", "Xamarin.Android.Support.Recommendation", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new AarInfo ("animated-vector-drawable", "animated-vector-drawable", "Xamarin.Android.Support.Animated.Vector.Drawable", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new AarInfo ("support-vector-drawable", "vector-drawable", "Xamarin.Android.Support.Vector.Drawable", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new AarInfo ("support-compat", "support-compat", "Xamarin.Android.Support.Compat", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new AarInfo ("support-core-utils", "support-core-utils", "Xamarin.Android.Support.Core.Utils", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new AarInfo ("support-core-ui", "support-core-ui", "Xamarin.Android.Support.Core.UI", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new AarInfo ("support-media-compat", "support-media-compat", "Xamarin.Android.Support.Media.Compat", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new AarInfo ("support-fragment", "support-fragment", "Xamarin.Android.Support.Fragment", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new AarInfo ("transition", "transition", "Xamarin.Android.Support.Transition", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
	new AarInfo ("exifinterface", "exifinterface", "Xamarin.Android.Support.Exif", AAR_VERSION, NUGET_VERSION, COMPONENT_VERSION),
};

class PartialZipInfo {
	public string Url { get;set; }
	public string LocalPath { get;set; }
	public string Md5 { get;set; }
	public long RangeStart { get;set; }
	public long RangeEnd { get;set; }
}

class AarInfo
{
	public AarInfo (string dir, string path, string nugetId, string aarVersion, string nugetVersion, string componentVersion)
	{
		Dir = dir;
		Path = path;
		NugetId = nugetId;
		AarVersion = aarVersion;
		NuGetVersion = nugetVersion;
		ComponentVersion = componentVersion;
	}

	public string Dir { get; set; }
	public string Path { get; set; }
	public string NugetId { get;set; }
	public string AarVersion { get; set; }
	public string NuGetVersion { get; set; }
	public string ComponentVersion { get; set; }
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

var buildSpec = new BuildSpec {
	Libs = new [] {
		new DefaultSolutionBuilder {
			SolutionPath = "./AndroidSupport.sln",
			BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac,
			MaxCpuCount = CPU_COUNT,
			OutputFiles = new [] {
				new OutputFileCopy { FromFile = "./customtabs/source/bin/Release/Xamarin.Android.Support.CustomTabs.dll" },
				new OutputFileCopy { FromFile = "./design/source/bin/Release/Xamarin.Android.Support.Design.dll" },
				new OutputFileCopy { FromFile = "./percent/source/bin/Release/Xamarin.Android.Support.Percent.dll" },
				new OutputFileCopy { FromFile = "./recommendation/source/bin/Release/Xamarin.Android.Support.Recommendation.dll" },
				//new OutputFileCopy { FromFile = "./v4/source/bin/Release/Xamarin.Android.Support.v4.dll" },
				new OutputFileCopy { FromFile = "./v7-appcompat/source/bin/Release/Xamarin.Android.Support.v7.AppCompat.dll" },
				new OutputFileCopy { FromFile = "./v7-cardview/source/bin/Release/Xamarin.Android.Support.v7.CardView.dll" },
				new OutputFileCopy { FromFile = "./v7-gridlayout/source/bin/Release/Xamarin.Android.Support.v7.GridLayout.dll" },
				new OutputFileCopy { FromFile = "./v7-mediarouter/source/bin/Release/Xamarin.Android.Support.v7.MediaRouter.dll" },
				new OutputFileCopy { FromFile = "./v7-palette/source/bin/Release/Xamarin.Android.Support.v7.Palette.dll" },
				new OutputFileCopy { FromFile = "./v7-preference/source/bin/Release/Xamarin.Android.Support.v7.Preference.dll" },
				new OutputFileCopy { FromFile = "./v7-recyclerview/source/bin/Release/Xamarin.Android.Support.v7.RecyclerView.dll" },
				new OutputFileCopy { FromFile = "./v8-renderscript/source/bin/Release/Xamarin.Android.Support.v8.RenderScript.dll" },
				new OutputFileCopy { FromFile = "./v13/source/bin/Release/Xamarin.Android.Support.v13.dll" },
				new OutputFileCopy { FromFile = "./v14-preference/source/bin/Release/Xamarin.Android.Support.v14.Preference.dll" },
				new OutputFileCopy { FromFile = "./v17-leanback/source/bin/Release/Xamarin.Android.Support.v17.Leanback.dll" },
				new OutputFileCopy { FromFile = "./v17-preference-leanback/source/bin/Release/Xamarin.Android.Support.v17.Preference.Leanback.dll" },
				new OutputFileCopy { FromFile = "./animated-vector-drawable/source/bin/Release/Xamarin.Android.Support.Animated.Vector.Drawable.dll" },
				new OutputFileCopy { FromFile = "./vector-drawable/source/bin/Release/Xamarin.Android.Support.Vector.Drawable.dll" },
				new OutputFileCopy { FromFile = "./support-compat/source/bin/Release/Xamarin.Android.Support.Compat.dll" },
				new OutputFileCopy { FromFile = "./support-core-utils/source/bin/Release/Xamarin.Android.Support.Core.Utils.dll" },
				new OutputFileCopy { FromFile = "./support-core-ui/source/bin/Release/Xamarin.Android.Support.Core.UI.dll" },
				new OutputFileCopy { FromFile = "./support-fragment/source/bin/Release/Xamarin.Android.Support.Fragment.dll" },
				new OutputFileCopy { FromFile = "./support-media-compat/source/bin/Release/Xamarin.Android.Support.Media.Compat.dll" },
				new OutputFileCopy { FromFile = "./transition/source/bin/Release/Xamarin.Android.Support.Transition.dll" },
				new OutputFileCopy { FromFile = "./exifinterface/source/bin/Release/Xamarin.Android.Support.Exif.dll" },

				new OutputFileCopy { FromFile = "./support-annotations/source/bin/Release/Xamarin.Android.Support.Annotations.dll" },
			}
		}
	},

	Samples = new [] {
		new DefaultSolutionBuilder { SolutionPath = "./customtabs/samples/ChromeCustomTabsSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT },
		new DefaultSolutionBuilder { SolutionPath = "./design/samples/Cheesesquare.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT },
		new DefaultSolutionBuilder { SolutionPath = "./percent/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT },
		new DefaultSolutionBuilder { SolutionPath = "./recommendation/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT },
		new DefaultSolutionBuilder { SolutionPath = "./v4/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT },
		new DefaultSolutionBuilder { SolutionPath = "./v7-appcompat/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT },
		new DefaultSolutionBuilder { SolutionPath = "./v7-cardview/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT },
		new DefaultSolutionBuilder { SolutionPath = "./v7-gridlayout/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT },
		new DefaultSolutionBuilder { SolutionPath = "./v7-mediarouter/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT },
		new DefaultSolutionBuilder { SolutionPath = "./v7-palette/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT },
		new DefaultSolutionBuilder { SolutionPath = "./v7-preference/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT },
		new DefaultSolutionBuilder { SolutionPath = "./v7-recyclerview/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT },
		new DefaultSolutionBuilder { SolutionPath = "./v8-renderscript/samples/RenderScriptSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT },
		new DefaultSolutionBuilder { SolutionPath = "./v13/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT },
		new DefaultSolutionBuilder { SolutionPath = "./v17-leanback/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT },
		new DefaultSolutionBuilder { SolutionPath = "./vector-drawable/samples/VectorDrawableSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT },
		new DefaultSolutionBuilder { SolutionPath = "./animated-vector-drawable/samples/VectorDrawableSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac, MaxCpuCount = CPU_COUNT },
	},

	NuGets = new [] {
		new NuGetInfo { NuSpec = "./customtabs/nuget/Xamarin.Android.Support.CustomTabs.nuspec", Version = NUGET_VERSION, RequireLicenseAcceptance = true },
		new NuGetInfo { NuSpec = "./design/nuget/Xamarin.Android.Support.Design.nuspec", Version = NUGET_VERSION, RequireLicenseAcceptance = true },
		new NuGetInfo { NuSpec = "./percent/nuget/Xamarin.Android.Support.Percent.nuspec", Version = NUGET_VERSION, RequireLicenseAcceptance = true },
		new NuGetInfo { NuSpec = "./recommendation/nuget/Xamarin.Android.Support.Recommendation.nuspec", Version = NUGET_VERSION, RequireLicenseAcceptance = true },
		new NuGetInfo { NuSpec = "./v4/nuget/Xamarin.Android.Support.v4.nuspec", Version = NUGET_VERSION, RequireLicenseAcceptance = true },
		new NuGetInfo { NuSpec = "./v7-appcompat/nuget/Xamarin.Android.Support.v7.AppCompat.nuspec", Version = NUGET_VERSION, RequireLicenseAcceptance = true },
		new NuGetInfo { NuSpec = "./v7-cardview/nuget/Xamarin.Android.Support.v7.CardView.nuspec", Version = NUGET_VERSION, RequireLicenseAcceptance = true },
		new NuGetInfo { NuSpec = "./v7-gridlayout/nuget/Xamarin.Android.Support.v7.GridLayout.nuspec", Version = NUGET_VERSION, RequireLicenseAcceptance = true },
		new NuGetInfo { NuSpec = "./v7-mediarouter/nuget/Xamarin.Android.Support.v7.MediaRouter.nuspec", Version = NUGET_VERSION, RequireLicenseAcceptance = true },
		new NuGetInfo { NuSpec = "./v7-palette/nuget/Xamarin.Android.Support.v7.Palette.nuspec", Version = NUGET_VERSION, RequireLicenseAcceptance = true },
		new NuGetInfo { NuSpec = "./v7-preference/nuget/Xamarin.Android.Support.v7.Preference.nuspec", Version = NUGET_VERSION, RequireLicenseAcceptance = true },
		new NuGetInfo { NuSpec = "./v7-recyclerview/nuget/Xamarin.Android.Support.v7.RecyclerView.nuspec", Version = NUGET_VERSION, RequireLicenseAcceptance = true },
		new NuGetInfo { NuSpec = "./v8-renderscript/nuget/Xamarin.Android.Support.v8.RenderScript.nuspec", Version = NUGET_VERSION, RequireLicenseAcceptance = true },
		new NuGetInfo { NuSpec = "./v13/nuget/Xamarin.Android.Support.v13.nuspec", Version = NUGET_VERSION, RequireLicenseAcceptance = true },
		new NuGetInfo { NuSpec = "./v14-preference/nuget/Xamarin.Android.Support.v14.Preference.nuspec", Version = NUGET_VERSION, RequireLicenseAcceptance = true },
		new NuGetInfo { NuSpec = "./v17-leanback/nuget/Xamarin.Android.Support.v17.Leanback.nuspec", Version = NUGET_VERSION, RequireLicenseAcceptance = true },
		new NuGetInfo { NuSpec = "./v17-preference-leanback/nuget/Xamarin.Android.Support.v17.Preference.Leanback.nuspec", Version = NUGET_VERSION, RequireLicenseAcceptance = true },
		new NuGetInfo { NuSpec = "./animated-vector-drawable/nuget/Xamarin.Android.Support.Animated.Vector.Drawable.nuspec", Version = NUGET_VERSION, RequireLicenseAcceptance = true },
		new NuGetInfo { NuSpec = "./vector-drawable/nuget/Xamarin.Android.Support.Vector.Drawable.nuspec", Version = NUGET_VERSION, RequireLicenseAcceptance = true },
		new NuGetInfo { NuSpec = "./support-compat/nuget/Xamarin.Android.Support.Compat.nuspec", Version = NUGET_VERSION, RequireLicenseAcceptance = true },
		new NuGetInfo { NuSpec = "./support-core-utils/nuget/Xamarin.Android.Support.Core.Utils.nuspec", Version = NUGET_VERSION, RequireLicenseAcceptance = true },
		new NuGetInfo { NuSpec = "./support-core-ui/nuget/Xamarin.Android.Support.Core.UI.nuspec", Version = NUGET_VERSION, RequireLicenseAcceptance = true },
		new NuGetInfo { NuSpec = "./support-fragment/nuget/Xamarin.Android.Support.Fragment.nuspec", Version = NUGET_VERSION, RequireLicenseAcceptance = true },
		new NuGetInfo { NuSpec = "./support-media-compat/nuget/Xamarin.Android.Support.Media.Compat.nuspec", Version = NUGET_VERSION, RequireLicenseAcceptance = true },
		new NuGetInfo { NuSpec = "./transition/nuget/Xamarin.Android.Support.Transition.nuspec", Version = NUGET_VERSION, RequireLicenseAcceptance = true },
		new NuGetInfo { NuSpec = "./exifinterface/nuget/Xamarin.Android.Support.Exif.nuspec", Version = NUGET_VERSION, RequireLicenseAcceptance = true },
		new NuGetInfo { NuSpec = "./support-annotations/nuget/Xamarin.Android.Support.Annotations.nuspec", Version = NUGET_VERSION, RequireLicenseAcceptance = true },
	},

	Components = new [] {
		new Component { ManifestDirectory = "./animated-vector-drawable/component" },
		new Component { ManifestDirectory = "./customtabs/component" },
		new Component { ManifestDirectory = "./design/component" },
		new Component { ManifestDirectory = "./percent/component" },
		new Component { ManifestDirectory = "./recommendation/component" },
		new Component { ManifestDirectory = "./v4/component" },
		new Component { ManifestDirectory = "./v7-appcompat/component" },
		new Component { ManifestDirectory = "./v7-cardview/component" },
		new Component { ManifestDirectory = "./v7-gridlayout/component" },
		new Component { ManifestDirectory = "./v7-palette/component" },
		new Component { ManifestDirectory = "./v7-preference/component" },
		new Component { ManifestDirectory = "./v7-recyclerview/component" },
		new Component { ManifestDirectory = "./v8-renderscript/component" },
		new Component { ManifestDirectory = "./v13/component" },
		new Component { ManifestDirectory = "./v17-leanback/component" },
		new Component { ManifestDirectory = "./vector-drawable/component" },
	}

};


var NUGET_SOURCES = EnvironmentVariable ("NUGET_SOURCES") ?? string.Empty;
if (!string.IsNullOrEmpty (NUGET_SOURCES))
	buildSpec.NuGetSources = NUGET_SOURCES.Split (';',',').Select (ns => new NuGetSource { Url = ns }).ToArray ();

// You shouldn't have to configure anything below here
// ######################################################

Task ("externals")
	.IsDependentOn ("externals-base")
	.WithCriteria (() => !FileExists ("./externals/support-v4/classes.jar")).Does (() =>
{
	var path = "./externals/";

	if (!DirectoryExists (path))
		CreateDirectory (path);

	// Get the actual GPS .aar files and extract
	if (!FileExists (path + "m2repository.zip"))
		DownloadFile (M2_REPOSITORY_URL, path + "m2repository.zip");
	if (!FileExists (path + "m2repository/source.properties"))
		Unzip(path + "m2repository.zip", path);

	// Copy the .aar's to a better location
	foreach (var aar in AAR_INFOS) {
		var aarDir = aar.Dir;
		CopyFile (string.Format (path + "m2repository/com/android/support/{0}/{1}/{2}-{3}.aar", aarDir, AAR_VERSION, aarDir, AAR_VERSION),
			string.Format (path + "{0}.aar", aarDir));
		Unzip (string.Format (path + "{0}.aar", aarDir), path + aarDir);

		var implFile = path + aarDir + "/libs/internal_impl-" + AAR_VERSION + ".jar";

		if (FileExists (implFile))
			MoveFile (implFile, path + aarDir + "/libs/internal_impl.jar");
	}

	CopyFile (string.Format (path + "m2repository/com/android/support/support-annotations/{0}/support-annotations-{0}.jar", AAR_VERSION), path + "support-annotations.jar");
	// We get docs a different way now
 //  // Get android docs
	// if (!FileExists (path + "docs.zip")) {
	// 	DownloadFile (DOCS_URL, path + "docs.zip");
	// 	Unzip (path + "docs.zip", path);
 //  }

	// Get Renderscript
	if (!FileExists (path + "buildtools.zip"))
		DownloadFile (BUILD_TOOLS_URL, path + "buildtools.zip");
	if (!FileExists (path + "build-tools/renderscript/lib/renderscript-v8.jar")) {
		Unzip (path + "buildtools.zip", path);
		CopyDirectory (path + RENDERSCRIPT_FOLDER, path + "build-tools");
		DeleteDirectory (path + RENDERSCRIPT_FOLDER, true);
	}
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
	.WithCriteria (!FileExists ("./generated.targets")).Does (() => 
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

	if (FileExists ("./generated.targets"))
		DeleteFile ("./generated.targets");

	// Get the zip file offsets for the relevant aar's
	var downloadParts = FindZipEntries ("./externals/m2repository.zip")
		.Where (e => e.EntryName.Contains (AAR_VERSION)
			&& (e.EntryName.Contains (".aar") || e.EntryName.Contains (".jar")))
		.Select (e => new PartialZipInfo {
			RangeStart = e.RangeStart,
			RangeEnd = e.RangeEnd,
			Url = M2_REPOSITORY_URL,
			LocalPath = e.EntryName,
			Md5 = ReadZipEntryText ("./externals/m2repository.zip", e.EntryName + ".md5", readBinaryAsHex: false)
		}).ToList ();

	foreach (var aar in AAR_INFOS) {

		var part = downloadParts.FirstOrDefault (p => p.LocalPath.EndsWith ("/" + aar.Dir + "-" + aar.AarVersion + ".aar"));

		if (part == null)
			throw new Exception ("Now matching part found for '" + aar.Dir + "-" + aar.AarVersion + "' in partial-download-info.json ");

		Information ("Found Part for: {0}-{1}, {2}", aar.Dir, aar.AarVersion, part.LocalPath);
		var msName = aar.Dir.Replace("-", "");

		var items = new Dictionary<string, string> {
			{ "_XbdUrl_", "_XbdUrl_" + msName },
			{ "_XbdKey_", "_XbdKey_" + msName },
			{ "_XbdAarFile_", "_XbdAarFile_" + msName },
			{ "_XbdAarFileInSdk_", "_XbdAarFileInSdk_" + msName },
			{ "_XbdAssemblyName_", "_XbdAssemblyName_" + msName },
			{ "_XbdAarFileFullPath_", "_XbdAarFileFullPath_" + msName },
			{ "_XbdRestoreItems_", "_XbdRestoreItems_" + msName },
			{ "$XbdUrl$", M2_REPOSITORY_URL },
			{ "$XbdMd5$", part.Md5 },
			{ "$XbdKey$", "androidsupport-" + AAR_VERSION + "/" + msName },
			{ "$XbdAssemblyName$", aar.NugetId },
			{ "$XbdRangeStart$", part.RangeStart.ToString() },
			{ "$XbdRangeEnd$", part.RangeEnd.ToString() },
			{ "$AarKey$", aar.Dir },
			{ "$AarVersion$", aar.AarVersion}
		};

		var targetsText = templateText;

		foreach (var kvp in items)
			targetsText = targetsText.Replace (kvp.Key, kvp.Value);

		var targetsFile = new FilePath(string.Format ("{0}/nuget/{1}.targets", aar.Path, aar.NugetId));
		FileWriteText (targetsFile, targetsText);

		// Merge each generated targets file into one main one
		// this makes one file to import into our actual binding projects
		// which is much easier/less maintenance
		if (!FileExists ("./generated.targets"))
			FileWriteText ("./generated.targets", "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<Project ToolsVersion=\"4.0\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">\n</Project>");

		// Load the doc to append to, and the doc to append
		var xFileRoot = System.Xml.Linq.XDocument.Load ("./generated.targets");
		System.Xml.Linq.XNamespace nsRoot = xFileRoot.Root.Name.Namespace;
		var xFileChild = System.Xml.Linq.XDocument.Load (MakeAbsolute(targetsFile).FullPath);
		System.Xml.Linq.XNamespace nsChild = xFileRoot.Root.Name.Namespace;

		// Add all the elements under <Project> into the existing file's <Project> node
		foreach (var xItemToAdd in xFileChild.Element (nsChild + "Project").Elements ())
			xFileRoot.Element (nsRoot + "Project").Add (xItemToAdd);

		// Inject a property to prevent errors from missing assemblies in .targets
		// this allows us to use one big .targets file in all the projects and not have to figure out which specific
		// ones each project needs to reference for development purposes
		if (!xFileRoot.Descendants (nsRoot + "XamarinBuildResourceMergeThrowOnMissingAssembly").Any ()) {
			xFileRoot.Element (nsRoot + "Project")
				.AddFirst (new System.Xml.Linq.XElement (nsRoot + "PropertyGroup", 
					new System.Xml.Linq.XElement (nsRoot + "XamarinBuildResourceMergeThrowOnMissingAssembly", false)));
		}

		xFileRoot.Save ("./generated.targets");

		// Check for an existing .targets file in this nuget package
		// we need to merge the generated one with it if it exists
		// nuget only allows one automatic .targets file in the build/ folder
		// of the nuget package, which must be named {nuget-package-id}.targets
		// so we need to merge them all into one
		var mergeFile = new FilePath (aar.Path + "/nuget/merge.targets");

		if (FileExists (mergeFile)) {
			Information ("merge.targets found, merging into generated file...");
			mergeTargetsFiles (mergeFile, targetsFile);
		}
	}

	// Support annotations needs merging tool
	var annotationsPart = downloadParts.FirstOrDefault (p => p.LocalPath.EndsWith ("/support-annotations-" + AAR_VERSION + ".jar"));

	var annotationsTemplateText = FileReadText ("./support-annotations/nuget/template.targets");
	annotationsTemplateText = annotationsTemplateText.Replace ("$AarVersion$", AAR_VERSION)
								.Replace ("$XbdRangeStart$", annotationsPart.RangeStart.ToString())
								.Replace ("$XbdRangeEnd$", annotationsPart.RangeEnd.ToString())
								.Replace ("$XbdMd5$", annotationsPart.Md5)
								.Replace ("$XbdUrl$", M2_REPOSITORY_URL);
								
	FileWriteText ("./support-annotations/nuget/Xamarin.Android.Support.Annotations.targets", annotationsTemplateText);
	mergeTargetsFiles ("./support-annotations/nuget/Xamarin.Android.Support.Annotations.targets", "./generated.targets");
});

Task ("nuget").IsDependentOn ("nuget-setup").IsDependentOn ("nuget-base").IsDependentOn ("libs");

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

Task ("libs").IsDependentOn ("nuget-setup").IsDependentOn ("genapi").IsDependentOn ("libs-base");

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

	DotNetBuild ("./AndroidSupport.TypeForwarders.sln", c => c.Configuration = "Release");

	CopyFile ("./v4/source/bin/Release/Xamarin.Android.Support.v4.dll", "./output/Xamarin.Android.Support.v4.dll");
});

Task ("buildtasks").Does (() => 
{
	NuGetRestore ("./vector-drawable/buildtask/Vector-Drawable-BuildTasks.csproj");

	DotNetBuild ("./vector-drawable/buildtask/Vector-Drawable-BuildTasks.csproj", c => c.Configuration = "Release");

	CopyFile ("./vector-drawable/buildtask/bin/Release/Xamarin.Android.Support.Tasks.VectorDrawable.targets", "./vector-drawable/nuget/merge.targets");
});

SetupXamarinBuildTasks (buildSpec, Tasks, Task);

RunTarget (TARGET);
