#tool nuget:?package=XamarinComponent

#addin nuget:?package=Cake.Xamarin
#addin nuget:?package=Cake.Xamarin.Build

var TARGET = Argument ("target", Argument ("t", "Default"));


var NUGET_VERSION = "1.0.0-beta5";
var AAR_VERSION = "1.0.0-beta5";

var CONSTRAINT_LAYOUT_URL = string.Format ("https://dl-ssl.google.com/android/repository/com.android.support.constraint-constraint-layout-{0}.zip", AAR_VERSION);
var CONSTRAINT_LAYOUT_SOLVER_URL = string.Format ("https://dl-ssl.google.com/android/repository/com.android.support.constraint-constraint-layout-solver-{0}.zip", AAR_VERSION);


var buildSpec = new BuildSpec {
	Libs = new [] {
		new DefaultSolutionBuilder {
			SolutionPath = "./ConstraintLayout.sln",
			BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac,
			OutputFiles = new [] {
				new OutputFileCopy { FromFile = "./source/bin/Release/Xamarin.Android.Support.Constraint.Layout.dll", ToDirectory = "./output/" },
				new OutputFileCopy { FromFile = "../constraint-layout-solver/source/bin/Release/Xamarin.Android.Support.Constraint.Layout.Solver.dll", ToDirectory = "./output/" },
			}
		}
	},

	Samples = new [] {
		new DefaultSolutionBuilder { SolutionPath = "./samples/ConstraintLayoutSample.sln", BuildsOn = BuildPlatforms.Windows | BuildPlatforms.Mac },
	},

	NuGets = new [] {
		new NuGetInfo { NuSpec = "./nuget/Xamarin.Android.Support.Constraint.Layout.nuspec", Version = NUGET_VERSION, RequireLicenseAcceptance = true },
		new NuGetInfo { NuSpec = "../constraint-layout-solver/nuget/Xamarin.Android.Support.Constraint.Layout.Solver.nuspec", Version = NUGET_VERSION, RequireLicenseAcceptance = true },
	},
};


Task ("externals")
	.WithCriteria (() => !FileExists ("../externals/constraintlayout/classes.jar")).Does (() =>
{
	var path = "../externals/";

	EnsureDirectoryExists (path);

	// Get the actual .aar files and extract
	if (!FileExists (path + "constraintlayout.zip"))
		DownloadFile (CONSTRAINT_LAYOUT_URL, path + "constraintlayout.zip");
	if (!FileExists (path + "constraintlayout/source.properties"))
		Unzip(path + "constraintlayout.zip", path);
	Unzip (path + "constraintlayout/constraint-layout-" + AAR_VERSION + ".aar", path + "constraintlayout/");

	if (!FileExists (path + "constraintlayoutsolver.zip"))
		DownloadFile (CONSTRAINT_LAYOUT_SOLVER_URL, path + "constraintlayoutsolver.zip");
	if (!FileExists (path + "solver/source.properties"))
		Unzip(path + "constraintlayoutsolver.zip", path);
});

Task ("clean").IsDependentOn ("clean-base").Does (() => 
{
	if (DirectoryExists ("../externals/constraintlayout"))
		DeleteDirectory ("../externals/constraintlayout", true);
	if (FileExists ("../externals/constraintlayout.zip"))
		DeleteFile ("../externals/constraintlayout.zip");

	if (DirectoryExists ("../externals/solver"))
		DeleteDirectory ("../externals/solver", true);
	if (FileExists ("../externals/solver.zip"))
		DeleteFile ("../externals/solver.zip");

	if (DirectoryExists ("./output"))
		DeleteDirectory ("./output", true);
});

SetupXamarinBuildTasks (buildSpec, Tasks, Task);

RunTarget (TARGET);
