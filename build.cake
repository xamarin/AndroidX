// Tools needed by cake addins
#tool nuget:?package=vswhere&version=3.1.7

#tool nuget:?package=Cake.CoreCLR
#tool nuget:?package=Microsoft.Android.Sdk.Windows&version=34.0.95

// Cake Addins
#addin nuget:?package=Cake.FileHelpers&version=7.0.0
#addin nuget:?package=Newtonsoft.Json&version=13.0.3
#addin nuget:?package=Cake.MonoApiTools&version=3.0.5
#addin nuget:?package=CsvHelper&version=31.0.3
#addin nuget:?package=SharpZipLib&version=1.4.2

// #addin nuget:?package=NuGet.Protocol&loaddependencies=true&version=5.6.0
// #addin nuget:?package=NuGet.Versioning&loaddependencies=true&version=5.6.0
// #addin nuget:?package=Microsoft.Extensions.Logging&loaddependencies=true&version=3.0.0

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

void RunGradle(DirectoryPath root, string target)
{
    root = MakeAbsolute(root);
    var proc = IsRunningOnWindows()
        ? root.CombineWithFilePath("gradlew.bat").FullPath
        : "bash";
    var args = IsRunningOnWindows()
        ? ""
        : root.CombineWithFilePath("gradlew").FullPath;
    args += $" {target} -p {root}";

    var exitCode = StartProcess(proc, args);
    if (exitCode != 0)
        throw new Exception($"Gradle exited with code {exitCode}.");
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

// Preparation

Task("inject-variables")
    .WithCriteria(!BuildSystem.IsLocalBuild)
    .Does(() =>
{
    var glob = "./source/AssemblyInfo.cs";

    ReplaceTextInFiles(glob, "{BUILD_COMMIT}", BUILD_COMMIT);
    ReplaceTextInFiles(glob, "{BUILD_NUMBER}", BUILD_NUMBER);
    ReplaceTextInFiles(glob, "{BUILD_TIMESTAMP}", BUILD_TIMESTAMP);
});

Task("check-tools")
    .Does(() =>
{
    var installedTools = RunProcessWithOutput("dotnet", "tool list -g");
    foreach (var toolName in REQUIRED_DOTNET_TOOLS) {
        if (installedTools.All(l => l.IndexOf(toolName, StringComparison.OrdinalIgnoreCase) == -1))
            throw new Exception ($"Missing dotnet tool: {toolName}");
    }
});


Task("tools-update")
	.Does
	(
		() =>
		{
			/*
			dotnet tool uninstall   -g Cake.Tool
			dotnet tool install     -g Cake.Tool
			dotnet tool uninstall   -g xamarin.androidbinderator.tool
			dotnet tool install     -g xamarin.androidbinderator.tool

			StartProcess("dotnet", "tool uninstall   -g Cake.Tool");
			StartProcess("dotnet", "tool install     -g Cake.Tool");
			*/
			StartProcess("dotnet", "tool uninstall   -g xamarin.androidbinderator.tool");
			StartProcess("dotnet", "tool install     -g xamarin.androidbinderator.tool");
		}
	);

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

Task ("binderate")
    .IsDependentOn("binderate-config-verify")
    .Does (() =>
{
    var configFile = MakeAbsolute(new FilePath("./config.json")).FullPath;
    var basePath = MakeAbsolute(new DirectoryPath ("./")).FullPath;

    // Run the dotnet tool for binderator
    RunProcess("xamarin-android-binderator",
        $"--config=\"{configFile}\" --basepath=\"{basePath}\"");

    // format the targets file so they are pretty in the package
    var targetsFiles = GetFiles("generated/**/*.targets");
    var xmlns = (XNamespace)"http://schemas.microsoft.com/developer/msbuild/2003";
    foreach (var targets in targetsFiles) {
        var xdoc = XDocument.Load(targets.FullPath);
        xdoc.Save(targets.FullPath);
    }

    // different lint.jar files in artifacts causing R8 errors
    foreach (var file in GetFiles("./externals/**/lint.jar")) {
        Information($"Deleting: {file}");
        DeleteFile(file);

        foreach (var aar in GetFiles($"{file.GetDirectory()}/../*.aar")) {
            Information($"Deleting: lint.jar from {aar}");
            using (var zipFile = new ICSharpCode.SharpZipLib.Zip.ZipFile(aar.ToString())) {
                zipFile.BeginUpdate();
                var entry = zipFile.GetEntry("lint.jar");
                if (entry != null) {
                    Information($"		Deleting lint.jar from {aar}");
                    zipFile.Delete(entry);
                }
                zipFile.CommitUpdate();
            }
        }
    }
});

string version_suffix = "";
string nuget_version_template = $"x.y.z.w{version_suffix}";
JArray binderator_json_array = null;

Task("binderate-config-verify")
    .IsDependentOn("binderate-fix")
    .Does
    (
        () =>
        {
            if (!(binderator_json_array?.Count > 0)) 
            {
                using (StreamReader reader = System.IO.File.OpenText(@"./config.json"))
                {
                    JsonTextReader jtr = new JsonTextReader(reader);
                    binderator_json_array = (JArray)JToken.ReadFrom(jtr);
                }
            }

            Information("config.json verification...");
            foreach(JObject jo in binderator_json_array[0]["artifacts"])
            {
                bool? dependency_only = (bool?) jo["dependencyOnly"];
                if ( dependency_only == true)
                {
                    continue;
                }
                string artifact_version = (string) jo["version"];
                string nuget_version  	= (string) jo["nugetVersion"];

                string[] artifact_version_parts = artifact_version.Split(new string[]{ "-" }, StringSplitOptions.RemoveEmptyEntries);
                string[] nuget_version_parts = nuget_version.Split(new string[]{ "-" }, StringSplitOptions.RemoveEmptyEntries);

                string nuget_version_prefix  	= nuget_version_parts[0];
                string artifact_version_prefix  = artifact_version_parts[0];
                string nuget_version_suffix  	= null;
                string artifact_version_suffix  = null;

                if (nuget_version_parts.Length > 1)
                {
                    nuget_version_suffix  	= nuget_version_parts[1];
                }
                if (artifact_version_parts.Length > 1)
                {
                    artifact_version_suffix  = artifact_version_parts[1];
                }

                Information($"groupId                   = {jo["groupId"]}");
                Information($"artifactId                = {jo["artifactId"]}");
                Information($"artifact_version          = {artifact_version}");
                Information($"artifact_version_prefix   = {artifact_version_prefix}");
                Information($"artifact_version_suffix   = {artifact_version_suffix}");
                Information($"nuget_version             = {nuget_version}");
                Information($"nuget_version_prefix      = {nuget_version_prefix}");
                Information($"nuget_version_suffix      = {nuget_version_suffix}");
                Information($"nugetId                   = {jo["nugetId"]}");


                string[] artifact_version_prefix_parts = artifact_version_prefix.Split(new string[]{ "." }, StringSplitOptions.RemoveEmptyEntries);
                string[] nuget_version_prefix_parts = nuget_version_prefix.Split(new string[]{ "." }, StringSplitOptions.RemoveEmptyEntries);
                string x = nuget_version_prefix_parts[0];
                string y = nuget_version_prefix_parts[1];
                string z = nuget_version_prefix_parts[2];

                string w = null;
                if (nuget_version_prefix_parts.Length > 3)
                {
                    w = nuget_version_prefix_parts[3];
                }

                string nuget_version_new = nuget_version_template;
                nuget_version_new = nuget_version_new.Replace("x", x);
                nuget_version_new = nuget_version_new.Replace("y", y);
                nuget_version_new = nuget_version_new.Replace("z", z);
                nuget_version_new = nuget_version_new.Replace("w", w);

                if ( ! string.IsNullOrEmpty(nuget_version_suffix) )
                {
                    nuget_version_new    += $"-{nuget_version_suffix}";
                }

                Information($"nuget_version_new         = {nuget_version_new}");

                if
                    (
                        ! nuget_version_new.StartsWith($"{artifact_version_prefix}")
                        &&
                        ! nuget_version_new.EndsWith($"{artifact_version_suffix}")
                    )
                {
                    Error("check config.json for nuget id");
                    Error  ($"		groupId           = {jo["groupId"]}");
                    Error  ($"		artifactId        = {jo["artifactId"]}");
                    Error  ($"		artifact_version  = {artifact_version}");
                    Error  ($"		nuget_version     = {nuget_version}");
                    Error  ($"		nuget_version_new = {nuget_version_new}");
                    Error  ($"		nugetId           = {jo["nugetId"]}");

                    Warning($"	expected : ");
                    Warning($"		nuget_version = {nuget_version_new}");
                    throw new Exception("check config.json for nuget id");
                }
            }

            return;
        }
    );

Task("binderate-diff")
	.IsDependentOn("binderate")
    .Does
    (
        () =>
        {
			EnsureDirectoryExists("./output/");

			// "git diff master:config.json config.json" > ./output/config.json.diff-from-master.txt"
			string process = "git";
			string process_args = "diff master:config.json config.json";
			IEnumerable<string> redirectedStandardOutput;
			ProcessSettings process_settings = new ProcessSettings ()
			{
             Arguments = process_args,
             RedirectStandardOutput = true
         	};
			int exitCodeWithoutArguments = StartProcess(process, process_settings, out redirectedStandardOutput);
			System.IO.File.WriteAllLines("./output/config.json.diff-from-master.txt", redirectedStandardOutput.ToArray());
			Information("Exit code: {0}", exitCodeWithoutArguments);
		}
	);

Task("binderate-fix")
    .Does
    (
        () =>
        {
            if (!(binderator_json_array?.Count > 0)) 
            {
                using (StreamReader reader = System.IO.File.OpenText(@"./config.json"))
                {
                    JsonTextReader jtr = new JsonTextReader(reader);
                    binderator_json_array = (JArray)JToken.ReadFrom(jtr);
                }
            }

            Warning("config.json fixing missing folder strucutre ...");
            foreach(JObject jo in binderator_json_array[0]["artifacts"])
            {
                string groupId      = (string) jo["groupId"];
                string artifactId   = (string) jo["artifactId"];

                Information($"  Verifying files for     :");
                Information($"              group       : {groupId}");
                Information($"              artifact    : {artifactId}");

                bool? dependency_only = (bool?) jo["dependencyOnly"];
                if ( dependency_only == true)
                {
                    continue;
                }


                string dir_group = $"source/{groupId}";
                if ( ! DirectoryExists(dir_group) )
                {
                    Warning($"  Creating {dir_group}");
                    CreateDirectory(dir_group);
                }
                string dir_artifact = $"{dir_group}/artifactId";
                if ( ! DirectoryExists(dir_group) )
                {
                    Warning($"      Creating artifact folder : {dir_artifact}");
                    CreateDirectory(dir_group);
                }

            }

            return;
        }
    );


// using System.Threading;
// using Microsoft.Extensions.Logging;
// using Microsoft.Extensions.Logging.Abstractions;

// using NuGet.Protocol.Core.Types;
// using NuGet.Versioning;
// using NuGet.Protocol.Core.Types;

Task("binderate-nuget-check")
    .Does
    (
        () =>
        {
            if (!(binderator_json_array?.Count > 0)) 
            {
                using (StreamReader reader = System.IO.File.OpenText(@"./config.json"))
                {
                    JsonTextReader jtr = new JsonTextReader(reader);
                    binderator_json_array = (JArray)JToken.ReadFrom(jtr);
                }
            }

            Warning("config.json fixing missing folder structure ...");
            foreach(JObject jo in binderator_json_array[0]["artifacts"])
            {
                string groupId      = (string) jo["groupId"];
                string artifactId   = (string) jo["artifactId"];
                string nugetId      = (string) jo["nugetId"];
                string nugetVersion = (string) jo["nugetVersion"];

                Information($"  Verifying nuget                 :");
                Information($"            nugetId               : {nugetId}");
                Information($"            config.json veriosn   : {nugetVersion}");

                // ILogger logger = NullLogger.Instance;
                // CancellationToken cancellationToken = CancellationToken.None;

                // SourceCacheContext cache = new SourceCacheContext();
                // SourceRepository repository = Repository.Factory.GetCoreV3("https://api.nuget.org/v3/index.json");
                // FindPackageByIdResource resource = await repository.GetResourceAsync<FindPackageByIdResource>().Result;

                // IEnumerable<NuGetVersion> versions = resource.GetAllVersionsAsync
                //                                                         (
                //                                                             nugetId,
                //                                                             cache,
                //                                                             logger,
                //                                                             cancellationToken
                //                                                         ).Result;

                // foreach (NuGetVersion version in versions)
                // {
                //     Information($"              Found version {version}");
                // }

            }

            return;
        }
    );


System.Xml.XmlDocument xmldoc = null;
System.Xml.XmlNamespaceManager ns = null;

Task("metadata-verify")
    .Does
    (
        () =>
        {
            FilePathCollection metadata_files = null;

            //  namespace is required, otherwise NRE
            string xml_namespace_name = "ax"; // could be "apixml" but it is irrelevant, keeping it short

            string xpath_expression_nodes_to_find =
                        //$@"//attr[contains(@path,'interface') and contains(@name ,'visibility')]"
                        $@"//attr[contains(@path,'interface')]"
                        ;

            metadata_files = GetFiles($"./generated/**/Metadata*.xml");
            foreach(FilePath fp in metadata_files)
            {
                Information($"Metadata = {fp}");
                throw new Exception("Move this file to source");
            }
            metadata_files = GetFiles($"./source/**/Metadata*.xml");
            foreach(FilePath fp in metadata_files)
            {
                Information($"Metadata = {fp}");
                xmldoc = new System.Xml.XmlDocument();
                xmldoc.Load(fp.ToString());
                ns = new System.Xml.XmlNamespaceManager(xmldoc.NameTable);

                List<(string Path, bool IsPublic)> result = GetXmlMetadata(xpath_expression_nodes_to_find, ns).ToList();
                foreach((string Path, bool IsPublic) r in result)
                {
                    Information($"		Found:");
                    Information($"			Path: {r.Path}");
                    Information($"			IsPublic: {r.IsPublic}");
                    if (r.IsPublic)
                    {
                        throw new Exception("Preventing exposing/surfacing interfaces with default package accessibility as public");
                    }
                }
            }
        }
    );

private IEnumerable<(string Path, bool IsPublic)> GetXmlMetadata(string xpath, System.Xml.XmlNamespaceManager xml_namespace)
{
    System.Xml.XmlNodeList node_list = xmldoc.SelectNodes(xpath, xml_namespace);

    foreach (System.Xml.XmlNode node in node_list)
    {
        string name = node.Attributes["name"].Value;
        string inner_text = node.InnerText;	//.Value;
        string path = node.Attributes["path"].Value;

        Information($"	path        = {path}");

        if (path.Contains("MediaRouteProvider.DynamicGroupRouteController"))
        {
            Information($"		Found:");
            Information($"			Name: {name}");
            Information($"			Visibility: {inner_text}");
            throw new Exception("MediaRouteProvider.DynamicGroupRouteController");
        }

        if (string.Equals(name, "visibility") && inner_text.Contains("public"))
        {
            Information($"		Visibility  = {inner_text}");

            bool is_public = inner_text.Contains("public") ? true : false;

            yield return (Path: path, IsPublic: is_public);
        }
    }
}

Task("libs")
    .IsDependentOn("metadata-verify")
    .IsDependentOn("libs-native")
    .Does(() =>
{
    DotNetMSBuildSettings settings = new DotNetMSBuildSettings()
        .SetConfiguration(CONFIGURATION)
        .SetMaxCpuCount(0)
        .EnableBinaryLogger($"./output/libs.{CONFIGURATION}.binlog")
        .WithProperty("MigrationPackageVersion", MIGRATION_PACKAGE_VERSION)
        .WithProperty("Verbosity", VERBOSITY.ToString())
        .WithProperty("DesignTimeBuild", "false")
        .WithProperty("AndroidSdkBuildToolsVersion", $"{AndroidSdkBuildTools}");

    if (!string.IsNullOrEmpty(ANDROID_HOME))
        settings.WithProperty("AndroidSdkDirectory", $"{ANDROID_HOME}");

    DotNetRestore("./generated/AndroidX.sln", new DotNetRestoreSettings
    {
        MSBuildSettings = settings.EnableBinaryLogger("./output/restore.binlog")
    });

    DotNetBuild
        (
            "./generated/AndroidX.sln", 
            new DotNetBuildSettings
            {
                MSBuildSettings = settings
            }
        );
});

Task("libs-native")
    .Does(() =>
{
    string root = "./source/com.google.android.material/material.extensions/";

    RunGradle(root, "build");

    string outputDir = "./externals/com.xamarin.google.android.material.extensions/";
    EnsureDirectoryExists(outputDir);
    CleanDirectories(outputDir);

    CopyFileToDirectory($"{root}/extensions-aar/build/outputs/aar/extensions-aar-release.aar", outputDir);
    Unzip($"{outputDir}/extensions-aar-release.aar", outputDir);
});

Task("nuget")
    .IsDependentOn("libs")
    .Does(() =>
{
    var settings = new DotNetMSBuildSettings()
        .SetConfiguration(CONFIGURATION)
        .SetMaxCpuCount(0)
        .EnableBinaryLogger($"./output/nuget.{CONFIGURATION}.binlog")
        .WithProperty("MigrationPackageVersion", MIGRATION_PACKAGE_VERSION)
        .WithProperty("NoBuild", "true")
        .WithProperty("PackageRequireLicenseAcceptance", "true")
        .WithProperty("PackageOutputPath", MakeAbsolute ((DirectoryPath)"./output/").FullPath)
        .WithTarget("Pack");

    if (!string.IsNullOrEmpty(ANDROID_HOME))
        settings.WithProperty("AndroidSdkDirectory", $"{ANDROID_HOME}");

    DotNetBuild
        (
            "./generated/AndroidX.sln", 
            new DotNetBuildSettings
            {
                MSBuildSettings = settings
            }
        );
});

Task("samples-generate-all-targets")
    .Does(() =>
{
    // make a big .targets file that pulls in everything
    var xmlns = (XNamespace)"http://schemas.microsoft.com/developer/msbuild/2003";
    var itemGroup1 = new XElement(xmlns + "ItemGroup");
    var itemGroup2 = new XElement(xmlns + "ItemGroup");
    foreach (var nupkg in GetFiles("./output/*.nupkg").OrderBy(fp => fp.FullPath)) {
        Information($"NuGet package = {nupkg}");

        // Skip Wear as it has special implications requiring more packages to be used properly in an app
        if (nupkg.FullPath.Contains(".Wear."))
            continue;
        // Skip the migration packages as that is not meant forto be used here
        if (nupkg.FullPath.Contains("Xamarin.AndroidX.Migration"))
            continue;
        // Skip Guava.ListenableFuture as it cannot be used in the same project as Guava itself
        if (nupkg.FullPath.Contains("Xamarin.Google.Guava.ListenableFuture"))
            continue;
        // Skip XBD because packages do not automatically reference the in-tree version
        if (nupkg.FullPath.Contains("Xamarin.Build.Download"))
            continue;
        // Skip Binderator because it is not a binding package
        if (nupkg.FullPath.Contains("Xamarin.AndroidBinderator"))
            continue;
        // skip because of multiple classes
        if 
            (
                nupkg.FullPath.Contains("Xamarin.AndroidX.DataStore.")
                &&
                ( nupkg.FullPath.Contains(".Jvm") || nupkg.FullPath.Contains(".Android") )
            )
            continue;

        var filename = nupkg.GetFilenameWithoutExtension();
        var match = Regex.Match(filename.ToString(), @"(.+?)\.(\d+[\.0-9\-a-zA-Z]+)");

        if ( match.Groups[1].Value == "Xamarin.AndroidX.Security.SecurityCrypto" )
        {
            // MAUI uses pinned/locked/exact preview version 1.1.0-alpha03 - skipit
            continue;
        }

        itemGroup1.Add(new XElement(xmlns + "PackageVersion",
            new XAttribute("Include", match.Groups[1]),
            new XAttribute("Version", match.Groups[2])));
        itemGroup2.Add(new XElement(xmlns + "PackageReference",
            new XAttribute("Include", match.Groups[1])));

    }

    var xdoc1 = new XDocument(new XElement(xmlns + "Project", itemGroup1));
    xdoc1.Save("./output/Directory.Packages.props");

    var xdoc2 = new XDocument(new XElement(xmlns + "Project", itemGroup2));
    xdoc2.Save("./output/Directory.Packages.targets");
});


Task("samples-dotnet")
    .IsDependentOn("nuget")
    .IsDependentOn("samples-only-dotnet");

Task("samples-only-dotnet")
    .IsDependentOn("samples-generate-all-targets")
    .Does(() =>
{
    // clear the packages folder so we always use the latest
    var packagesPath = MakeAbsolute((DirectoryPath)"./samples/packages-dotnet").FullPath;
    EnsureDirectoryExists(packagesPath);
    CleanDirectories(packagesPath);

    var settings = new DotNetMSBuildSettings()
        .SetConfiguration("Debug") // We don't need to run linking
        .WithProperty("Verbosity", VERBOSITY.ToString())
        .WithProperty("RestorePackagesPath", packagesPath)
        .WithProperty("AndroidSdkBuildToolsVersion", $"{AndroidSdkBuildTools}");

    if (!string.IsNullOrEmpty(ANDROID_HOME))
        settings.WithProperty("AndroidSdkDirectory", $"{ANDROID_HOME}");

    string[] solutions = new string[]
    {
        "./samples/dotnet/BuildAllDotNet.sln",
        "./samples/dotnet/BuildAllMauiApp.sln",
    };

    foreach(string solution in solutions)
    {
        FilePath fp_solution = new FilePath(solution);
        string filename = fp_solution.GetFilenameWithoutExtension().ToString();
        Information($"=====================================================================================================");
        Information($"DotNetBuild           {solution} / {filename}");    
        DotNetBuild(solution, new DotNetBuildSettings
        {
            MSBuildSettings = settings.EnableBinaryLogger($"./output/samples-dotnet-dotnet-msbuild-{filename}.binlog")
        });
    }
});

Task("tools-executive-order")
    .Does
    (
        () =>
        {
            CakeExecuteScript
                        (
                            "./utilities.cake",
                            new CakeSettings
                            { 
                                Arguments = new Dictionary<string, string>() 
                                { 
                                    { "target", "tools-executive-order" } 
                                } 
                            }
                        );        
        }
    );

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

Task ("clean")
    .Does (() =>
{
    if (DirectoryExists ("./externals"))
        DeleteDirectory ("./externals", new DeleteDirectorySettings { Recursive = true, Force = true });

    if (DirectoryExists ("./generated"))
        DeleteDirectory ("./generated", new DeleteDirectorySettings { Recursive = true, Force = true });

    CleanDirectories ("./**/packages");
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
    .IsDependentOn ("check-tools")
    .IsDependentOn ("inject-variables")
    .IsDependentOn ("binderate")
    .IsDependentOn ("nuget")
    .IsDependentOn ("tools-executive-order")
    ;

// Runs samples without building packages
Task ("ci-samples")
    .IsDependentOn ("samples-only-dotnet")
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
