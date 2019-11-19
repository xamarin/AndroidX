# AndroidX for Xamarin.Android

Xamarin creates and maintains Xamarin.Android bindings for AndroidX.

## Building

### Prerequisites

Before building the libraries and samples in this repository, you will need to install [.NET Core](https://dotnet.microsoft.com/download) and the [Cake .NET Core Tool](http://cakebuild.net):

```sh
dotnet tool install -g cake.tool
```

When building on macOS, you may also need to install [CocoaPods](https://cocoapods.org/):

```sh
# Homebrew
brew install cocoapods

# Ruby Gems
gem install cocoapods
```

### Compiling

You can now build all the packages by running:

```sh
dotnet cake
```

If you are going to make changes to the `config.json`, then you can run the `packages` target to re-generate all the necessary files:

```sh
dotnet cake --target=packages
```

## Android Support -> AndroidX Roadmap

With the release of AndroidX, Android Support is now considered deprecated and will no longer receive new feature updates.  We are committed to helping our developers bring their applications into this new world with minimal effort.

### Goal
Our goal is to allow developers to take an existing application using Android Support libraries, and reference, build, and run against AndroidX libraries without any code changes.

### Phases

**1. Xamarin Bindings / NuGet Packages for AndroidX**

Provide bindings to all of the new AndroidX packages for Xamarin developers.  If you want to migrate your app's code manually to use the new AndroidX API's you can reference these packages.  Keep in mind that all of your app's dependencies must also be compiled against AndroidX bindings to use these.

**2. Tooling for Building apps and dependencies with AndroidX**

Implement build tasks in the AndroidX packages to allow your application to utilize AndroidX without any code changes:
  - Dependencies (.NET as well as binding libraries with java and resources in them) will be migrated to the new API's and cached during your first build
  - Your app's compiled code will be migrated to the new API's before the application is packaged
  - Your app's resource and manifest files will be migrated at build time before the application is packaged

**3. Optional One Time Migration Tool**

If your app's code (C#, Resources, Manifest, etc) has not been migrated from Android Support, your build times will be slightly longer.  

We will provide a migration assistant to help convert your C# code, xml resources, and AndroidManifest to use the new AndroidX API's which you can optionally use to perform a one time migration of your project.

## Migration Tools / Tasks Source Code

The source code for the `Xamarin.AndroidX.Migration` package and other migration tools and utilities are available in: [xamarin/XamarinAndroidXMigration](https://github.com/xamarin/XamarinAndroidXMigration)

## License

The license for this repository is specified in
[LICENSE.md](LICENSE.md)

The `externals` build task downloads some external dependencies from Google which are licensed under and subject to the terms of [Android Software Development Kit License Agreement](http://developer.android.com/sdk/terms.html)

## Contribution Guidelines
The Contribution Guidelines for this repository are listed in [CONTRIBUTING.md](.github/CONTRIBUTING.md)

## .NET Foundation
This project is part of the [.NET Foundation](http://www.dotnetfoundation.org/projects)
