#tool nuget:?package=ILRepack&version=2.0.10
#tool nuget:?package=XamarinComponent

#addin nuget:?package=Cake.XCode
#addin nuget:?package=Cake.Xamarin
#addin nuget:?package=Cake.Xamarin.Build
#addin nuget:?package=Cake.FileHelpers

var TARGET = Argument ("t", Argument ("target", "Default"));

var NUGET_VERSION = "23.4.0";
var COMPONENT_VERSION = "23.4.0";
var AAR_VERSION = "23.4.0";

// FROM: https://dl.google.com/android/repository/addon.xml
var M2_REPOSITORY_URL = "https://dl-ssl.google.com/android/repository/android_m2repository_r32.zip";
var BUILD_TOOLS_URL = "https://dl-ssl.google.com/android/repository/build-tools_r23-macosx.zip";
var DOCS_URL = "https://dl-ssl.google.com/android/repository/docs-23_r01.zip";

var AAR_DIRS = new [] {
	"support-v4", "support-v13", "appcompat-v7", "gridlayout-v7", "mediarouter-v7", "recyclerview-v7",
	"palette-v7", "cardview-v7", "leanback-v17", "design", "percent", "customtabs", "preference-v7",
	"preference-v14", "preference-leanback-v17", "recommendation", "animated-vector-drawable",
	"support-vector-drawable"
};

var MONODROID_PATH = "/Library/Frameworks/Xamarin.Android.framework/Versions/Current/lib/mandroid/platforms/android-23/";
if (IsRunningOnWindows ())
	MONODROID_PATH = new DirectoryPath (Environment.GetFolderPath (Environment.SpecialFolder.ProgramFilesX86)).Combine ("Reference Assemblies/Microsoft/Framework/MonoAndroid/v6.0/").FullPath;

var buildSpec = new BuildSpec {
	Libs = new [] {
		new DefaultSolutionBuilder {
			SolutionPath = "./AndroidSupport.sln",
			BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac,
			OutputFiles = new [] {
				new OutputFileCopy { FromFile = "./customtabs/source/bin/Release/Xamarin.Android.Support.CustomTabs.dll" },
				new OutputFileCopy { FromFile = "./design/source/bin/Release/Xamarin.Android.Support.Design.dll" },
				new OutputFileCopy { FromFile = "./percent/source/bin/Release/Xamarin.Android.Support.Percent.dll" },
				new OutputFileCopy { FromFile = "./recommendation/source/bin/Release/Xamarin.Android.Support.Recommendation.dll" },
				new OutputFileCopy { FromFile = "./v4/source/bin/Release/Xamarin.Android.Support.v4.dll" },
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
			}
		}
	},

	Samples = new [] {
		new DefaultSolutionBuilder { SolutionPath = "./customtabs/samples/ChromeCustomTabsSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac },
		new DefaultSolutionBuilder { SolutionPath = "./design/samples/Cheesesquare.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac },
		new DefaultSolutionBuilder { SolutionPath = "./percent/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac },
		new DefaultSolutionBuilder { SolutionPath = "./recommendation/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac },
		new DefaultSolutionBuilder { SolutionPath = "./v4/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac },
		new DefaultSolutionBuilder { SolutionPath = "./v7-appcompat/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac },
		new DefaultSolutionBuilder { SolutionPath = "./v7-cardview/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac },
		new DefaultSolutionBuilder { SolutionPath = "./v7-gridlayout/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac },
		new DefaultSolutionBuilder { SolutionPath = "./v7-mediarouter/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac },
		new DefaultSolutionBuilder { SolutionPath = "./v7-palette/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac },
		new DefaultSolutionBuilder { SolutionPath = "./v7-preference/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac },
		new DefaultSolutionBuilder { SolutionPath = "./v7-recyclerview/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac },
		new DefaultSolutionBuilder { SolutionPath = "./v8-renderscript/samples/RenderScriptSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac },
		new DefaultSolutionBuilder { SolutionPath = "./v13/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac },
		new DefaultSolutionBuilder { SolutionPath = "./v17-leanback/samples/AndroidSupportSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac },
		new DefaultSolutionBuilder { SolutionPath = "./vector-drawable/samples/VectorDrawableSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac },
		new DefaultSolutionBuilder { SolutionPath = "./animated-vector-drawable/samples/VectorDrawableSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac },
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



// You shouldn't have to configure anything below here
// ######################################################

Task ("externals")
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
	foreach (var aar in AAR_DIRS) {
		CopyFile (string.Format (path + "m2repository/com/android/support/{0}/{1}/{2}-{3}.aar", aar, AAR_VERSION, aar, AAR_VERSION),
			string.Format (path + "{0}.aar", aar));
		Unzip (string.Format (path + "{0}.aar", aar), path + aar);

		var implFile = path + aar + "/libs/internal_impl-" + AAR_VERSION + ".jar";

		if (FileExists (implFile))
			MoveFile (implFile, path + aar + "/libs/internal_impl.jar");
	}

  // Get android docs
	if (!FileExists (path + "docs.zip")) {
		DownloadFile (DOCS_URL, path + "docs.zip");
		Unzip (path + "docs.zip", path);
  }

	// Get Renderscript
	if (!FileExists (path + "buildtools.zip"))
		DownloadFile (BUILD_TOOLS_URL, path + "buildtools.zip");
	if (!FileExists (path + "build-tools/renderscript/lib/renderscript-v8.jar")) {
		Unzip (path + "buildtools.zip", path);
		CopyDirectory (path + "android-6.0", path + "build-tools");
		DeleteDirectory (path + "android-6.0", true);
	}
});

Task ("merge").IsDependentOn ("libs").Does (() =>
{
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

	// Don't want to think about what the paths will do to this on windows right now
	if (!IsRunningOnWindows ()) {
		// Next run the mono-api-info.exe to generate xml api info we can later diff with
		var monoApiInfoExe = GetFiles ("../../**/mono-api-info.exe").FirstOrDefault ();
		var monoApiDiffExe = GetFiles ("../../**/mono-api-diff.exe").FirstOrDefault ();
		var monoApiHtmlExe = GetFiles ("../../**/mono-api-html.exe").FirstOrDefault ();

		//eg: mono mono-api-info.exe --search-directory=/Library/Frameworks/Xamarin.Android.framework/Libraries/mandroid/platforms/android-23 ./Some.dll > api-info.xml
		using(var process = StartAndReturnProcess (monoApiInfoExe, new ProcessSettings {
			Arguments = "--search-directory=" + MONODROID_PATH + " ./output/AndroidSupport.Merged.dll",
			RedirectStandardOutput = true,
		})) {
		    process.WaitForExit();
		    FileWriteLines ("./output/AndroidSupport.api-info.xml", process.GetStandardOutput ().ToArray ());
		}

		// Grab the latest published api info from S3
		var latestReleasedApiInfoUrl = "http://xamarin-components-apiinfo.s3.amazonaws.com/Support.Android-Latest.xml";
		DownloadFile (latestReleasedApiInfoUrl, "./output/AndroidSupport.api-info.previous.xml");

		// Now diff against current release'd api info
		// eg: mono mono-api-diff.exe ./gps.r26.xml ./gps.r27.xml > gps.diff.xml
		using(var process = StartAndReturnProcess (monoApiDiffExe, new ProcessSettings {
			Arguments = "./output/AndroidSupport.api-info.previous.xml ./output/AndroidSupport.api-info.xml",
			RedirectStandardOutput = true,
		})) {
		    process.WaitForExit();
		    FileWriteLines ("./output/AndroidSupport.api-diff.xml", process.GetStandardOutput ().ToArray ());
		}

		// Now let's make a purty html file
		// eg: mono mono-api-html.exe -c -x ./gps.previous.info.xml ./gps.current.info.xml > gps.diff.html
		using(var process = StartAndReturnProcess (monoApiHtmlExe, new ProcessSettings {
			Arguments = "-c -x ./output/AndroidSupport.api-info.previous.xml ./output/AndroidSupport.api-info.xml",
			RedirectStandardOutput = true,
		})) {
		    process.WaitForExit();
		    FileWriteLines ("./output/AndroidSupport.api-diff.html", process.GetStandardOutput ().ToArray ());
		}
	}
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

Task ("component").IsDependentOn ("component-docs").IsDependentOn ("component-setup").IsDependentOn ("component-base");

Task ("clean").IsDependentOn ("clean-base").Does (() =>
{
	if (DirectoryExists ("./externals"))
		DeleteDirectory ("./externals", true);
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

SetupXamarinBuildTasks (buildSpec, Tasks, Task);

RunTarget (TARGET);
