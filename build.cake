// Tools needed by cake addins
#tool nuget:?package=vswhere&version=3.1.7

// Used by binderator, "Windows" is fine because we only use managed code from it
#tool nuget:?package=Microsoft.Android.Sdk.Windows&version=35.0.0-rc.1.80

// Cake Addins
#addin nuget:?package=Cake.FileHelpers&version=7.0.0
#addin nuget:?package=Newtonsoft.Json&version=13.0.3
#addin nuget:?package=Cake.MonoApiTools&version=3.0.5
#addin nuget:?package=CsvHelper&version=31.0.3
#addin nuget:?package=SharpZipLib&version=1.4.2

// #addin nuget:?package=NuGet.Protocol&loaddependencies=true&version=5.6.0
// #addin nuget:?package=NuGet.Versioning&loaddependencies=true&version=5.6.0
// #addin nuget:?package=Microsoft.Extensions.Logging&loaddependencies=true&version=3.0.0

#load "build/cake/setup-environment.cake"
#load "build/cake/update-config.cake"
#load "build/cake/tests.cake"
#load "build/cake/gps-parameters.cake"
#load "build/cake/dotnet-next.cake"
#load "build/cake/binderate.cake"
#load "build/cake/build-and-package.cake"
#load "build/cake/validations.cake"
#load "build/cake/executive-order.cake"
#load "build/cake/clean.cake"

using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CsvHelper;

// The main configuration points
var TARGET = Argument ("t", Argument ("target", "Default"));
var CONFIGURATION = Argument ("c", Argument ("configuration", "Release"));
var VERBOSITY = Argument ("v", Argument ("verbosity", Verbosity.Normal));

// Lists all the artifacts and their versions for com.android.support.*
// https://dl.google.com/dl/android/maven2/com/android/support/group-index.xml
// Master list of all the packages in the repo:
// https://dl.google.com/dl/android/maven2/master-index.xml

var binderator_project = "util/Xamarin.AndroidBinderator/Xamarin.AndroidBinderator.Tool/Xamarin.AndroidBinderator.Tool.csproj";

var REF_DOCS_URL = "https://bosstoragemirror.blob.core.windows.net/android-docs-scraper/a7/a712886a8b4ee709f32d51823223039883d38734/androidx.zip";

var JAVA_INTEROP_ZIP_URL = "https://github.com/xamarin/java.interop/archive/d17-2.zip";

var SUPPORT_CONFIG_URL = "https://raw.githubusercontent.com/xamarin/AndroidSupportComponents/master/config.json";

var VISUAL_STUDIO_ROOT = EnvironmentVariable ("VISUAL_STUDIO_ROOT") ?? Argument ("vs", "");
if (IsRunningOnWindows() && string.IsNullOrEmpty(VISUAL_STUDIO_ROOT))
    VISUAL_STUDIO_ROOT = VSWhereLatest(new VSWhereLatestSettings { Requires = "Component.Xamarin", IncludePrerelease = true }).FullPath;

// Resolve Xamarin.Android installation
var XAMARIN_ANDROID_PATH = EnvironmentVariable ("XAMARIN_ANDROID_PATH");
var ANDROID_SDK_BASE_VERSION = "v1.0";
var ANDROID_SDK_VERSION = "v12.0";
var AndroidSdkBuildTools = $"32.0.0";

if (string.IsNullOrEmpty(XAMARIN_ANDROID_PATH)) {
    if (IsRunningOnWindows()) {
        XAMARIN_ANDROID_PATH = VISUAL_STUDIO_ROOT + @"\Common7\IDE\ReferenceAssemblies\Microsoft\Framework\MonoAndroid";
    } else {
        if (DirectoryExists("/Library/Frameworks/Xamarin.Android.framework/Versions/Current/lib/xamarin.android/xbuild-frameworks/MonoAndroid"))
            XAMARIN_ANDROID_PATH = "/Library/Frameworks/Xamarin.Android.framework/Versions/Current/lib/xamarin.android/xbuild-frameworks/MonoAndroid";
        else
            XAMARIN_ANDROID_PATH = "/Library/Frameworks/Xamarin.Android.framework/Versions/Current/lib/xbuild-frameworks/MonoAndroid";
    }
}
if (!DirectoryExists($"{XAMARIN_ANDROID_PATH}/{ANDROID_SDK_VERSION}"))
    throw new Exception($"Unable to find Xamarin.Android {ANDROID_SDK_VERSION} at {XAMARIN_ANDROID_PATH}.");

// Load all the git variables
var BUILD_COMMIT = EnvironmentVariable("BUILD_COMMIT") ?? "DEV";
var BUILD_NUMBER = EnvironmentVariable("BUILD_NUMBER") ?? "DEBUG";
var BUILD_TIMESTAMP = DateTime.UtcNow.ToString();

var REQUIRED_DOTNET_TOOLS = new [] {
    "xamarin-android-binderator"
};

string JAVA_HOME = EnvironmentVariable ("JAVA_HOME") ?? Argument ("java_home", "");
string ANDROID_HOME = EnvironmentVariable ("ANDROID_HOME") ?? Argument ("android_home", "");
string ANDROID_SDK_ROOT = EnvironmentVariable ("ANDROID_SDK_ROOT") ?? Argument ("android_sdk_root", "");
string MSBUILD_PATH = IsRunningOnWindows() && !string.IsNullOrEmpty(VISUAL_STUDIO_ROOT)
    ? VISUAL_STUDIO_ROOT + @"\MSBuild\Current\Bin\MSBuild.exe"
    : null;

// Log some variables
Information ($"JAVA_HOME            : {JAVA_HOME}");
Information ($"ANDROID_HOME         : {ANDROID_HOME}");
Information ($"ANDROID_SDK_ROOT     : {ANDROID_SDK_ROOT}");
Information ($"VISUAL_STUDIO_ROOT   : {VISUAL_STUDIO_ROOT}");
Information ($"XAMARIN_ANDROID_PATH : {XAMARIN_ANDROID_PATH}");
Information ($"MSBUILD_PATH         : {MSBUILD_PATH}");
Information ($"ANDROID_SDK_VERSION  : {ANDROID_SDK_VERSION}");
Information ($"BUILD_COMMIT         : {BUILD_COMMIT}");
Information ($"BUILD_NUMBER         : {BUILD_NUMBER}");
Information ($"BUILD_TIMESTAMP      : {BUILD_TIMESTAMP}");


// You shouldn't have to configure anything below here
// ######################################################

var MIGRATION_PACKAGE_VERSION = GetNuGetVersion("Xamarin.AndroidX.Migration");
var MULTIDEX_PACKAGE_VERSION = GetNuGetVersion("Xamarin.AndroidX.MultiDex");

void RunProcess(FilePath fileName, string processArguments)
{
    var exitCode = StartProcess(fileName, processArguments);
    if (exitCode != 0)
        throw new Exception ($"Process {fileName} exited with code {exitCode}.");
}

string[] RunProcessWithOutput(FilePath fileName, string processArguments)
{
    var exitCode = StartProcess(fileName, new ProcessSettings {
        Arguments = processArguments,
        RedirectStandardOutput = true,
        RedirectStandardError = true
    }, out var procOut);
    if (exitCode != 0)
        throw new Exception ($"Process {fileName} exited with code {exitCode}.");
    return procOut.ToArray();;
}

string GetNuGetVersion(string nugetId, string configJson = "./config.json")
{
    var json = JToken.Parse(FileReadText(configJson));

    if (json.Type == JTokenType.Array)
        json = ((JArray)json)[0];

    var artifacts = json["artifacts"];
    var artifact = artifacts.FirstOrDefault(j => (string)j["nugetId"] == nugetId);

    if (artifact == null)
    {
        /*
        NEEDS INVESTIGATION
        nugetID Xamarin.Jetbrains.Annotations was found as dependency, but it was not listed in config.json

        buildTransitive might be the issue.
        
        workaround was to add following snippet to config.json:

        {
            "groupId": "org.jetbrains",
            "artifactId": "annotations",
            "version": "13.0",
            "nugetVersion": "13.0.0.4",
            "nugetId": "Xamarin.Jetbrains.Annotations",
            "dependencyOnly": true
        },
        */
    }

    return (string)(artifact["nugetVersion"] ?? artifact["version"]);
}

string GetNuGetId(string assemblyName, string configJson = "./config.json")
{
    var json = JToken.Parse(FileReadText(configJson));

    if (json.Type == JTokenType.Array)
        json = ((JArray)json)[0];

    var artifacts = json["artifacts"];
    var artifact =
        artifacts.FirstOrDefault(j => (string)j["assemblyName"] == assemblyName) ??
        artifacts.FirstOrDefault(j => (string)j["nugetId"] == assemblyName);

    if (artifact == null)
        return assemblyName;

    return (string)artifact["nugetId"];
}

IEnumerable<string> GetArtifacts(string configJson = "./config.json")
{
    var json = JToken.Parse(FileReadText(configJson));

    if (json.Type == JTokenType.Array)
        json = ((JArray)json)[0];

    var artifacts = json["artifacts"];
    foreach (var artifact in artifacts) {
        yield return $"{artifact["groupId"]}.{artifact["artifactId"]}";
    }
}

// Android X

Task("javadocs")
    .Does(() =>
{
    EnsureDirectoryExists("./externals/");

    if (!FileExists("./externals/docs.zip"))
        DownloadFile(REF_DOCS_URL, "./externals/docs.zip");

    if (!DirectoryExists("./externals/docs"))
        Unzip ("./externals/docs.zip", "./externals/docs");

    var astJar = new FilePath("./util/JavaASTParameterNames-1.0.jar");
    var sourcesJars = GetFiles("./externals/**/*-sources.jar");

    foreach (var srcJar in sourcesJars) {
        var srcJarPath = MakeAbsolute(srcJar).FullPath;
        var outTxtPath = srcJarPath.Replace("-sources.jar", "-paramnames.txt");
        var outXmlPath = srcJarPath.Replace("-sources.jar", "-paramnames.xml");

        RunProcess("java", "-jar \"" + MakeAbsolute(astJar).FullPath + "\" --text \"" + srcJarPath + "\" \"" + outTxtPath + "\"");
        RunProcess("java", "-jar \"" + MakeAbsolute(astJar).FullPath + "\" --xml \"" + srcJarPath + "\" \"" + outXmlPath + "\"");
    }
});


Task("api-diff")
    .Does
    (
        () =>
        { /*
            // https://github.com/Redth/Cake.MonoApiTools/
            MonoApiDiff(API_INFO_OLD_MIGRATED, API_INFO_NEW, "./output/api-info-diff.xml");
            string[] lines_xml = FileReadLines("./output/api-info-diff.xml");
            List<string> lines_xml_new = new List<string>();
            foreach(string line in lines_xml)
            {
                if (line.Contains(@"Java.Interop.IJavaPeerable"))
                {
                    continue;
                }

                lines_xml_new.Add(line);
            }
            FileWriteLines("./output/api-info-diff.cleaned.xml", lines_xml_new.ToArray());


            MonoApiHtmlColorized(API_INFO_OLD_MIGRATED, API_INFO_NEW, "./output/api-info-diff.html");
            string[] lines_html = FileReadLines("./output/api-info-diff.html");

            List<string> lines_html_new = new List<string>();
            List<(string Class, string ClassFullyQualified)> removed_types = new List<(string Class, string ClassFullyQualified)>();
            List<(string Class, string ClassFullyQualified)> new_types = new List<(string Class, string ClassFullyQualified)>();

            foreach(string line in lines_html)
            {
                if (line.Contains(@"Java.Interop.IJavaPeerable"))
                {
                    continue;
                }
                if (line.Contains("<h3>Removed Type <span class='breaking' data-is-breaking>"))
                {
                    string t = line.Replace("<h3>Removed Type <span class='breaking' data-is-breaking>", "");
                    t = t.Replace("</span></h3>",",");
                    t = Regex.Replace(t, ",</div> <!-- (.*?) -->", "");
                    t = Regex.Replace(t, ",<div> <!-- (.*?) -->", "");
                    string[] types = t.Split( new string[] { "," }, StringSplitOptions.RemoveEmptyEntries );
                    foreach(string t1 in types)
                    {
                        string c  = t1.Substring(t1.LastIndexOf(".") + 1);
                        removed_types.Add((Class: c, ClassFullyQualified: t1));
                    }
                }
                if (line.Contains("<h3>New Type "))
                {
                    string t = line.Replace("<h3>New Type ", "");
                    t = t.Replace("</h3>", "");
                    Information($"{t}");
                    string c  = t.Substring(t.LastIndexOf(".") + 1);
                    new_types.Add((Class: c, ClassFullyQualified:t));
                }
                lines_html_new.Add(line);
            }

            FileWriteLines("./output/api-info-diff.cleaned.html", lines_html_new.ToArray());
            FileWriteLines("./output/removed-types.csv", removed_types.Select(i => $"{i.Class},{i.ClassFullyQualified}").ToArray());
            FileWriteLines("./output/new-types.csv", new_types.Select(i => $"{i.Class},{i.ClassFullyQualified}").ToArray());

            List<int> indices_new = new List<int>();
            List<int> indices_removed = new List<int>();
            List<string> moved_types = new List<string>();
            moved_types.Add($"# Class,ClassFullyQualified Removed, ClassFullyQualified New");

            for( int idx1 = 0; idx1 < removed_types.Count; idx1++)
            {
                (string Class, string ClassFullyQualified) tr = removed_types[idx1];
                int idx2 = new_types.FindIndex(tn => tn.Class == tr.Class);
                if (idx2 < 0)
                {
                    continue;
                }
                indices_removed.Add(idx1);
                indices_new.Add(idx2);
                string c = removed_types[idx1].Class;
                string cr_fq = removed_types[idx1].ClassFullyQualified;
                string cn_fq = new_types[idx2].ClassFullyQualified;
                moved_types.Add($"{c},{cr_fq},{cn_fq}");
            }

            var indices_new_sorted = indices_new.OrderByDescending(t => t);
            for (int i = 0; i < indices_new_sorted.Count(); i++)
            {
                new_types.RemoveAt(indices_new_sorted.ElementAt(i));
            }
            var indices_removed_sorted = indices_removed.OrderByDescending(t => t);
            for (int i = 0; i < indices_removed_sorted.Count(); i++)
            {
                removed_types.RemoveAt(indices_removed_sorted.ElementAt(i));
            }

            FileWriteLines("./output/removed-types.final.csv", removed_types.Select(i => $"{i.Class},{i.ClassFullyQualified}").ToArray());
            FileWriteLines("./output/new-types.final.csv", new_types.Select(i => $"{i.Class},{i.ClassFullyQualified}").ToArray());
            FileWriteLines("./output/moved-types.final.csv", moved_types.ToArray());

            return;
            */
        }
    );

var MONODROID_BASE_PATH = (DirectoryPath)"/Library/Frameworks/Xamarin.Android.framework/Versions/Current/lib/xbuild-frameworks/MonoAndroid/";
if (IsRunningOnWindows ()) {
    var vsInstallPath = VSWhereLatest (new VSWhereLatestSettings { Requires = "Component.Xamarin", IncludePrerelease = true });
    MONODROID_BASE_PATH = vsInstallPath.Combine ("Common7/IDE/ReferenceAssemblies/Microsoft/Framework/MonoAndroid/");
}
var MONODROID_PATH = MONODROID_BASE_PATH.Combine(ANDROID_SDK_VERSION);

Task ("diff")
    .Does (() =>
{
    var SEARCH_DIRS = new DirectoryPath [] {
        MONODROID_BASE_PATH.Combine("v1.0"),
        MONODROID_PATH,
    };

    EnsureDirectoryExists("./output/");
    MonoApiInfo ("./output/AndroidX.Merged.dll", "./output/api-info.xml", new MonoApiInfoToolSettings {
        SearchPaths = SEARCH_DIRS
    });

    //DownloadFile (BASE_API_INFO_URL, "./output/api-info.previous.xml");

    // Now diff against current released api info
    MonoApiDiff ("./output/api-info.previous.xml", "./output/api-info.xml", "./output/api-diff.xml");

    // Now let's make pretty files
    MonoApiHtml ("./output/api-info.previous.xml", "./output/api-info.xml", "./output/api-diff.html");
    MonoApiMarkdown ("./output/api-info.previous.xml", "./output/api-info.xml", "./output/api-diff.md");
});

Task ("packages")
    .IsDependentOn ("binderate")
    .IsDependentOn ("nuget");

Task ("full-run")
    .IsDependentOn ("binderate")
    .IsDependentOn ("nuget")
    .IsDependentOn ("samples-dotnet")
    .IsDependentOn ("tools-executive-order")
    ;

Task ("ci")
    .IsDependentOn ("ci-build")
    .IsDependentOn ("ci-samples")
    ;

// Builds packages but does not run samples
Task ("ci-build")
    .IsDependentOn ("inject-variables")
    .IsDependentOn ("binderate")
    .IsDependentOn ("nuget")
    .IsDependentOn ("tools-executive-order")
    ;

// for local builds, conditionally do the first binderate
if (FileExists ("./generated/AndroidX.sln")) {
    Task ("Default")
        .IsDependentOn ("nuget");
} else {
    Task ("Default")
        .IsDependentOn ("binderate")
        .IsDependentOn ("nuget");
}

RunTarget (TARGET);
