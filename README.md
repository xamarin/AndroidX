# AndroidX for Xamarin.Android

[![GitHub License](https://img.shields.io/badge/license-MIT-lightgrey.svg)](https://github.com/xamarin/AndroidX/blob/master/LICENSE)
[![contributions welcome](https://img.shields.io/badge/contributions-welcome-brightgreen.svg?style=flat)](https://github.com/xamarin/AndroidX/issues)
[![GitHub contributors](https://img.shields.io/github/contributors/xamarin/AndroidX.svg)](https://github.com/xamarin/AndroidX/graphs/contributors)
[![Build Status](https://dev.azure.com/devdiv/DevDiv/_apis/build/status/Xamarin/Components/AndroidX?branchName=master)](https://dev.azure.com/devdiv/DevDiv/_build/latest?definitionId=12322&branchName=master)

Xamarin creates and maintains Xamarin.Android bindings for AndroidX.

## What is AndroidX

AndroidX (also called Jetpack) is a major improvement to the original [Android Support Library](https://github.com/xamarin/AndroidSupportComponents). AndroidX packages fully replace the Android Support Library by providing feature parity and new libraries.

With the release of AndroidX, Android Support is now considered deprecated and will no longer receive new feature updates. Version 28.0.0 is the last release of the Android Support Library.

## Binding Policies

- This repository binds over 200 (2022-09) AndroidX libraries that are published to [NuGet.org](https://nuget.org). The full 
  package list can be found in [config.json](config.json).
- AndroidX Java artifacts come from [Google's Maven Respository](https://maven.google.com/web/index.html#).
- Google's release notes for AndroidX libraries are available [here](https://developer.android.com/jetpack/androidx/versions/stable-channel).
- The major/minor/patch version numbers mirror the AndroidX library version. For example, the NuGet `Xamarin.AndroidX.Core 1.3.2.1` 
  binds version `1.3.2` of the AndroidX library `androidx.core:core`.
  - The revision version number is used when a new NuGet needs to be built but the AndroidX library has not been updated.
- We endeavor to release updated NuGets within a few weeks after new AndroidX releases, however large changes occasionally require 
  more time.
- In general, we do not bind pre-release libraries. As their API is not stable yet, it results in too much rework.

### Details

Full list of maven artifact to NuGet mappings:

[./docs/artifact-list.md](./docs/artifact-list.md)

Full list of maven artifact with versions to NuGet mappings with versions:

[./docs/artifact-list-with-versions.md](./docs/artifact-list-with-versions.md)

## License

The license for this repository is specified in [LICENSE.md](LICENSE.md)

## Building

Instructions for building this repository are specified in [BUILDING.md](BUILDING.md)


## Contribution Guidelines

The Contribution Guidelines for this repository are listed in [CONTRIBUTING.md](.github/CONTRIBUTING.md)

## .NET Foundation

This project is part of the [.NET Foundation](http://www.dotnetfoundation.org/projects)
