# Tests Directory

This directory contains all the test code and assets.

## Assets

Because the tests use dynamic assemblies and Android assets, it has to be built
first - either as part of MSBuild or via a Cake script.

**Native Java**

> These artifacts need to be built using 
> `.\build.ps1 --target=NativeAssets`.

 - `Aarxersise.Java.AndroidX` - this is a native Java library that uses
   AndroidX
 - `Aarxersise.Java.Support` - this is a native Java library that uses Android
   Support

**Managed**

> These assets are build as part of the MSBuild process.

 - `Aarxercise.Binding.AndroidX` - this is a binding project for
   `Aarxersise.Java.AndroidX`
 - `Aarxercise.Binding.Support` - this is a binding project for
   `Aarxersise.Java.Support`
 - `Aarxercise.Managed.AndroidX` - this is a Xamarin.Android project that does
   not use any native code and uses AndroidX
 - `Aarxercise.Managed.Support` - this is a Xamarin.Android project that does
   not use any native code and uses Android Support
 - `Aarxercise.Old.AndroidX` - this is a Xamarin.Android project that uses types
   that are type-forwarded and uses AndroidX
 - `Aarxercise.Old.Support` - this is a Xamarin.Android project that uses types
   that are type-forwarded and uses Android Support

## Tests

 - `Xamarin.AndroidX.Migration.Tests` - this is a test project that makes sure
   everything is working as expected
