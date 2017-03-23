using System.Reflection;
using System.Runtime.CompilerServices;
using Android.App;
using Java.Interop;

// Information about this assembly is defined by the following attributes.
// Change them to the values specific to your project.

[assembly: AssemblyTitle("Xamarin.Android.Support.Annotations")]
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

// This is needed for compiling javac in apps, but the actual lib is not needed in the app itself
// only for the compilation stage, so we don't need to actually package it in the app
[assembly: DoNotPackage ("support-annotations.jar")]