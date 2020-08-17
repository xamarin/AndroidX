### Xamarin.Android Version (eg: 6.0):


### Operating System & Version (eg: Mac OSX 10.11):


### AndroidX Version

### Describe your Issue

### Relevant information

Add relevant project settings from `*.csproj` file:

Packages used:

```
    <PackageReference Include="Xamarin.Forms" Version="4.4.0.991265" />
    <PackageReference Include="Xamarin.Essentials" Version="1.3.1" />
```

Build settings (tools)

```
    <AndroidDexTool>d8</AndroidDexTool>
    <AndroidLinkTool>r8</AndroidLinkTool>
    <AndroidUseAapt2>true</AndroidUseAapt2>
    <AndroidEnableDesugar>true</AndroidEnableDesugar>
```


or even better - links to the existing code:

*   https://github.com/xamarin/AndroidX/blob/master/samples/BuildAll/BuildAll/BuildAll.csproj#L41-L44

*   https://github.com/xamarin/AndroidX/blob/master/samples/BuildXamarinFormsApp/BuildXamarinFormsApp/BuildXamarinFormsApp.Android/BuildXamarinFormsApp.Android.csproj#L57-L58

NOTE: Please DO NOT submit screenshot images. Images are not searchable! 

### Minimal Repro Code Sample

If you want to speed up investigation and bug fixing: please provide minimal repro sample for tests.

### Steps to Reproduce (with link to sample solution if possible):

### Include any relevant Exception Stack traces, build logs, adb logs:
