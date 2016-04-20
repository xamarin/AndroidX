using System.Reflection;
using System.Runtime.CompilerServices;
using Android.App;

// Information about this assembly is defined by the following attributes.
// Change them to the values specific to your project.
[assembly: AssemblyTitle ("Xamarin.Android.Support.v7.CardView")]
[assembly: AssemblyDescription ("")]
[assembly: AssemblyConfiguration ("")]
[assembly: AssemblyCompany ("Xamarin Inc.")]
[assembly: AssemblyProduct ("")]
[assembly: AssemblyCopyright ("Xamarin Inc.")]
[assembly: AssemblyTrademark ("")]
[assembly: AssemblyCulture ("")]
// The assembly version has the format "{Major}.{Minor}.{Build}.{Revision}".
// The form "{Major}.{Minor}.*" will automatically update the build and revision,
// and "{Major}.{Minor}.{Build}.*" will update just the revision.
[assembly: AssemblyVersion ("1.0.0")]
// The following attributes are used to specify the signing key for the assembly,
// if desired. See the Mono documentation for more information about signing.
//[assembly: AssemblyDelaySign(false)]
//[assembly: AssemblyKeyFile("")]


//TODO: Fix me - we need to download the binaries at runtime but these attributes
// 		currently aren't working so i'm including the .aar file directly for now
// CardView-v7
[assembly: Java.Interop.JavaLibraryReference ("classes.jar",
	PackageName = __Consts.PackageName,
    SourceUrl = __SupportConsts.Url,
	EmbeddedArchive = __Consts.AarPath,
    Version = __SupportConsts.Version)]
// CardView-v7 resources
[assembly: Android.IncludeAndroidResourcesFromAttribute ("./",
	PackageName = __Consts.PackageName,
    SourceUrl   = __SupportConsts.Url,
	EmbeddedArchive = __Consts.AarPath,
    Version     = __SupportConsts.Version)]

static class __Consts {	
	public const string PackageName = "Xamarin.Android.Support.v7.CardView";
    public const string AarPath = "m2repository/com/android/support/cardview-v7/" + __SupportConsts.AarVersion + "/cardview-v7-" + __SupportConsts.AarVersion + ".aar";
}

