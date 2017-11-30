using System.Reflection;
using System.Runtime.CompilerServices;
using Android.App;

// Information about this assembly is defined by the following attributes.
// Change them to the values specific to your project.

[assembly: AssemblyTitle ("Xamarin.Android.Support.V8")]
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

[assembly: AssemblyMetadata ("BUILD_COMMIT",      "{BUILD_COMMIT}")]
[assembly: AssemblyMetadata ("BUILD_NUMBER",    "{BUILD_NUMBER}")]
[assembly: AssemblyMetadata ("BUILD_TIMESTAMP", "{BUILD_TIMESTAMP}")]

[assembly: AssemblyInformationalVersion ("{NUGET_VERSION}")]

// The following attributes are used to specify the signing key for the assembly,
// if desired. See the Mono documentation for more information about signing.

//[assembly: AssemblyDelaySign(false)]
//[assembly: AssemblyKeyFile("")]

[assembly: Java.Interop.JavaLibraryReference (__Consts.RootDir + "/renderscript/lib/renderscript-v8.jar",
	SourceUrl = __Consts.SupportUrl,
	Version = __Consts.Version,
	PackageName = __Consts.PackageName)]

[assembly: Android.NativeLibraryReferenceAttribute (__Consts.RootDir + "/renderscript/lib/packaged/armeabi-v7a/librsjni.so",
	SourceUrl = __Consts.SupportUrl,
	Version = __Consts.Version,
	PackageName = __Consts.PackageName)]

[assembly: Android.NativeLibraryReferenceAttribute (__Consts.RootDir + "/renderscript/lib/packaged/armeabi-v7a/libRSSupport.so",
	SourceUrl = __Consts.SupportUrl,
	Version = __Consts.Version,
	PackageName = __Consts.PackageName)]

// Due to a bug, if some unknown platforms are found, everything is ignored (in this case MIPS)
// BUG: https://bugzilla.xamarin.com/show_bug.cgi?id=24480
// Let's just leave MIPS out since we don't target it anyway
/*
[assembly: Android.NativeLibraryReferenceAttribute (__Consts.RootDir + "/renderscript/lib/packaged/mips/librsjni.so",
	SourceUrl = __Consts.SupportUrl,
	Version = __Consts.Version,
	PackageName = __Consts.PackageName)]

[assembly: Android.NativeLibraryReferenceAttribute (__Consts.RootDir + "/renderscript/lib/packaged/mips/libRSSupport.so",
	SourceUrl = __Consts.SupportUrl,
	Version = __Consts.Version,
	PackageName = __Consts.PackageName)]
*/

[assembly: Android.NativeLibraryReferenceAttribute (__Consts.RootDir + "/renderscript/lib/packaged/x86/librsjni.so",
	SourceUrl = __Consts.SupportUrl,
	Version = __Consts.Version,
	PackageName = __Consts.PackageName)]

[assembly: Android.NativeLibraryReferenceAttribute (__Consts.RootDir + "/renderscript/lib/packaged/x86/libRSSupport.so",
	SourceUrl = __Consts.SupportUrl,
	Version = __Consts.Version,
	PackageName = __Consts.PackageName)]

static class __Consts {
	public const string RootDir = "android-N"; // Root dir might change on updates
	public const string SupportUrl  = "http://dl-ssl.google.com/android/repository/build-tools_r24-macosx.zip";
	public const string Version     = "24";
	public const string PackageName = "Xamarin.Android.Support.v8";
}
