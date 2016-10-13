using System.Reflection;
using System.Runtime.CompilerServices;
using Android.App;

// Information about this assembly is defined by the following attributes. 
// Change them to the values specific to your project.

[assembly: AssemblyTitle ("Xamarin.Android.Support.Constraint.Layout.Solver")]
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

[assembly: Java.Interop.JavaLibraryReference (__Consts.JarPath,
    PackageName = __Consts.PackageName,
    SourceUrl = __Consts.Url,
    //EmbeddedArchive = __Consts.JarPath,
    Version = __Consts.Version,
    Sha1sum = __Consts.Sha1sum)]

//[assembly: Android.IncludeAndroidResourcesFromAttribute ("./",
//    PackageName = __Consts.PackageName,
//    SourceUrl = __Consts.Url,
//    EmbeddedArchive = __Consts.AarPath,
//    Version = __Consts.Version,
//    Sha1sum = __Consts.Sha1sum)]

static class __Consts
{
    public const string JarPath = "solver/constraint-layout-solver-" + JarVersion + ".jar";
    public const string JarVersion = "1.0.0-alpha9";
    public const string Version = JarVersion;
    public const string PackageName = "Xamarin.Android.Support.Constraint.Layout.Solver";
    public const string Url = "https://dl-ssl.google.com/android/repository/com.android.support.constraint-constraint-layout-solver-" + JarVersion + ".zip";
    public const string Sha1sum = "2c52ddd883d83230a17042b8f4ba03669f0f5f40";
}
