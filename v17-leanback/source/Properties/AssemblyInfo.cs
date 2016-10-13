using System.Reflection;
using System.Runtime.CompilerServices;
using Android.App;
using Java.Interop;

// Information about this assembly is defined by the following attributes.
// Change them to the values specific to your project.

[assembly: AssemblyTitle("Xamarin.Android.Support.v17.Leanback")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany ("Microsoft Corporation")]
[assembly: AssemblyProduct("")]
[assembly: AssemblyCopyright ("Copyright © Microsoft Corporation")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// The assembly version has the format "{Major}.{Minor}.{Build}.{Revision}".
// The form "{Major}.{Minor}.*" will automatically update the build and revision,
// and "{Major}.{Minor}.{Build}.*" will update just the revision.

[assembly: AssemblyVersion("1.0.0")]

// The following attributes are used to specify the signing key for the assembly,
// if desired. See the Mono documentation for more information about signing.

//[assembly: AssemblyDelaySign(false)]
//[assembly: AssemblyKeyFile("")]

// Leanback-v17
[assembly: JavaLibraryReference ("classes.jar",
	PackageName = __SupportConsts.PackageName,
    SourceUrl = __SupportConsts.Url,
	EmbeddedArchive = __Consts.AarPath,
    Version = __SupportConsts.Version,
    Sha1sum = __SupportConsts.Sha1sum)]
// Leanback-v17 resources
[assembly: Android.IncludeAndroidResourcesFromAttribute ("./",
	PackageName = __SupportConsts.PackageName,
    SourceUrl   = __SupportConsts.Url,
	EmbeddedArchive = __Consts.AarPath,
    Version     = __SupportConsts.Version,
    Sha1sum = __SupportConsts.Sha1sum)]

static class __Consts {
    public const string AarPath = "m2repository/com/android/support/leanback-v17/" + __SupportConsts.AarVersion + "/leanback-v17-" + __SupportConsts.AarVersion + ".aar";
}
