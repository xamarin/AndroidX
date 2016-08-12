using System.Reflection;
using System.Runtime.CompilerServices;
using Android.App;

// Information about this assembly is defined by the following attributes.
// Change them to the values specific to your project.

[assembly: AssemblyTitle ("Xamarin.Android.Support.Design")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Xamarin Inc.")]
[assembly: AssemblyProduct("")]
[assembly: AssemblyCopyright("Xamarin Inc.")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// The assembly version has the format "{Major}.{Minor}.{Build}.{Revision}".
// The form "{Major}.{Minor}.*" will automatically update the build and revision,
// and "{Major}.{Minor}.{Build}.*" will update just the revision.

[assembly: AssemblyVersion ("1.0.0")]

// The following attributes are used to specify the signing key for the assembly,
// if desired. See the Mono documentation for more information about signing.

//[assembly: AssemblyDelaySign(false)]
//[assembly: AssemblyKeyFile("")]

[assembly: Java.Interop.JavaLibraryReference ("classes.jar",
	PackageName     = __Consts.PackageName,
	SourceUrl       = __SupportConsts.Url,
	EmbeddedArchive = __Consts.AarPath,
	Version         = __SupportConsts.Version,
    Sha1sum = __SupportConsts.Sha1sum)]

[assembly: Android.IncludeAndroidResourcesFromAttribute ("./",
	PackageName     = __Consts.PackageName,
	SourceUrl       = __SupportConsts.Url,
	EmbeddedArchive = __Consts.AarPath,
	Version         = __SupportConsts.Version,
    Sha1sum = __SupportConsts.Sha1sum)]

static class __Consts {
	public const string PackageName = "Xamarin.Android.Support.Design";
	public const string AarPath = "m2repository/com/android/support/design/" + __SupportConsts.AarVersion + "/design-" + __SupportConsts.AarVersion + ".aar";
}