# Build Tools Inventory


*   Context: Section 4.e.i.D of 

    https://eng.ms/docs/initiatives/executive-order/executive-order-requirements/executiveorderoncybersecurity/buildinfraops#build-system-security-requirements

*   Context: 

    https://microsoft.sharepoint.com/❌/r/teams/1ES2/_layouts/15/doc2.aspx?sourcedoc=%7B97E1B064-A768-4B0F-BEB5-4BF21577F3D6%7D&file=9d770e15-6208-4284-b347-b2762803623b.xlsx


Adds support to `build.cake` Cake script to generate a `buildtoolsinventory.csv` file
which contains information about various build tools repository depends on.

Items currently included are 

*   dotnet, 

*   Android SDK and NDK packages,

*   Open JDK, 

*   Mono MDK, 

*   various tools (`brew`)


## Build

AndroidX (AX) and GooglePlayServices-Firebase-MLKit (GPS-FB-MLKit) repositories are built and signed
on Azure DevOps infrastructure with `ci` Cake (Cake build tool default `build.cake` script) target.

Build stages:

1.  on CI servers 

    2 stages

    1.   target `ci`

    2.   `api-diff` as default target (`nuget-api-diff` in `nuget-diff.cake`)

        `api-diff` is not target, script is executed

2. local builds have additional script `utilities.cake`

    1.  namespace naming verification (dotnettification/dotnetifying java package names)

    2.  spell checking (nugets, and namespaces)

    3.  report generation

    4.  other

        there are several tools in early preview 

### Versions

*   CI Builds

    All tools are installed from scratch, so the latest versions are used (nuget semver `*`)

*   local builds

    It depends on team members. 
    
    Due to dogfooding user `@moljac` uses previews (nuget semver `*_*`)

https://docs.microsoft.com/en-us/nuget/concepts/package-versioning

### Tools used

```
xamarin-android-binderator,*
xamarin.androidx.migration.tool,*
androidx-migrator,*
```

#### build (`ci` in build.cake)

```
msbuild,*
dotnet build,*
nuget,*
java,*
dotnet tool cake.tool,*
dotnet tool xamarin.androidbinderator.tool,*
dotnet tool xamarin.androidx.migration.tool,*
```


#### `api-diff` (`nuget-diff`)

default in `nuget-diff.cake` (no target is necessary)

```
dotnet tool api-tools,*
```

https://github.com/xamarin/xamarin-android/blob/56d785e0a71aada17a9f4586d76efa5e3b757cb8/build-tools/xaprepare/xaprepare/Application/Context.cs#L942

