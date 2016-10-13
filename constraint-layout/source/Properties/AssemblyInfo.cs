using System.Reflection;
using System.Runtime.CompilerServices;
using Android.App;

// Information about this assembly is defined by the following attributes. 
// Change them to the values specific to your project.

[assembly: AssemblyTitle ("Xamarin.Android.Support.Constraint.Layout")]
[assembly: AssemblyDescription ("")]
[assembly: AssemblyConfiguration ("")]
[assembly: AssemblyCompany ("Microsoft Corporation")]
[assembly: AssemblyProduct ("")]
[assembly: AssemblyCopyright ("Copyright © Microsoft Corporation")]
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

[assembly: Java.Interop.JavaLibraryReference ("classes.jar",
    PackageName = __Consts.PackageName,
    SourceUrl = __Consts.Url,
    EmbeddedArchive = __Consts.AarPath,
    Version = __Consts.Version,
    Sha1sum = __Consts.Sha1sum)]

[assembly: Android.IncludeAndroidResourcesFromAttribute ("./",
    PackageName = __Consts.PackageName,
    SourceUrl = __Consts.Url,
    EmbeddedArchive = __Consts.AarPath,
    Version = __Consts.Version,
    Sha1sum = __Consts.Sha1sum)]

static class __Consts
{
    public const string AarVersion = "1.0.0-alpha9";
    public const string Version = AarVersion;
    public const string PackageName = "Xamarin.Android.Support.Constraint.Layout";
    public const string Url = "https://dl-ssl.google.com/android/repository/com.android.support.constraint-constraint-layout-" + __Consts.AarVersion + ".zip";
    public const string AarPath = "constraintlayout/constraint-layout-" + __Consts.AarVersion + ".aar";
    public const string Sha1sum = "89c2bbc005d4731c7a830a4d5aa98dae121a46a4";
}
