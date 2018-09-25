///////////////////////////////////////////////////////////////////////////////
// COMMAND LINE ARGUMENTS
//
// --localSource             [a directory path or URL to a NuGet source]
//                           This can be used to provide access to the build
//                               artifacts to use as the base for the fat
//                               packages.
// --packagesPath            [a directory path to download NuGet packages to]
//                           This can be used to change where the existing
//                               packages get downloaded to temporarily.
// --workingPath             [a directory path to perform work inside of]
//                           This can be used to change the directory which
//                               is used to process files for packaging.
// --outputPath              [a directory path to output processed packages to]
//                           This can be used to change the output path of the
//                               processed packages.
// --keepLatestVersion       [True|False]
//                           This can be used to indicate that the latest
//                               version should not be incremented, rather use
//                               the version in the fat package.
// --incrementVersion        [True|False]
//                           This can be used to indicate that the fat packages
//                               should have new versions.
// --packLatestOnly          [True|False]
//                           This can be used to indicate that only the latest
//                               version should be packed.
// --useExplicitVersion      [True|False]
//                           This can be used to indicate that the dependencies
//                               should use hard/exact versions: [x.x.x]
// --prereleaseLabel        [Prelease label to use for the new package version]
//                           This can be used to add a prerelease label to the
//                               nuget package version being created
///////////////////////////////////////////////////////////////////////////////
// EXAMPLE USE CASE
//
// In order to have this script run as part of CI to make fat packages, use the
// following options:
//
//     .\build.ps1 `
//       --localSource="<path-to-build-directory>" `
//       --incrementVersion=False `
//       --packLatestOnly=True `
//       --useExplicitVersion=True
//       --prereleaseLabel=rc1
//       --packagesPath="./externals/packages"
//       --workingPath="./working/packages"
//       --outputPath="./output/packages"
//
///////////////////////////////////////////////////////////////////////////////

#addin nuget:?package=Cake.FileHelpers&version=3.0.0
#addin nuget:?package=NuGet.Packaging&version=4.7.0&loaddependencies=true
#addin nuget:?package=NuGet.Protocol&version=4.7.0&loaddependencies=true

using System.Linq;
using System.Xml;
using System.Xml.Linq;
using NuGet.Common;
using NuGet.Frameworks;
using NuGet.Packaging;
using NuGet.Packaging.Core;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;

var target = Argument("target", "Default");
var localSource = Argument("localSource", "");
var keepLatestVersion = Argument("keepLatestVersion", false);
var incrementVersion = Argument("incrementVersion", true);
var packLatestOnly = Argument("packLatestOnly", false);
var useExplicitVersion = Argument("useExplicitVersion", true);
var prereleaseLabel = Argument("prereleaseLabel", (string)null);

var packagesPath = (DirectoryPath)Argument("packagesPath", "externals/packages");
var workingPath = (DirectoryPath)Argument("workingPath", "working/packages");
var outputPath = (DirectoryPath)Argument("outputPath", "output/packages");

var apiLevelVersion = new Dictionary<int, NuGetFramework> {
    // {  1, NuGetFramework.Parse("monoandroid1.0") },
    // { 15, NuGetFramework.Parse("monoandroid4.0.3") },
    // { 19, NuGetFramework.Parse("monoandroid4.4") },
    // { 21, NuGetFramework.Parse("monoandroid5.0") },
    // { 22, NuGetFramework.Parse("monoandroid5.1") },
    { 23, NuGetFramework.Parse("monoandroid6.0") },
    { 24, NuGetFramework.Parse("monoandroid7.0") },
    { 25, NuGetFramework.Parse("monoandroid7.1") },
    { 26, NuGetFramework.Parse("monoandroid8.0") },
    { 27, NuGetFramework.Parse("monoandroid8.1") },
    { 28, NuGetFramework.Parse("monoandroid9.0") },
};

var minimumVersion = new Dictionary<string, NuGetVersion> {
    { "xamarin.android.arch", new NuGetVersion(1, 0, 0) },
    { "xamarin.android.support", new NuGetVersion(23, 4, 0) },
};

var blacklistIdPrefix = new List<string> {
    "xamarin.build.download",
};

var seedPackages = new [] {
    "Xamarin.Android.Support.Animated.Vector.Drawable",
    "Xamarin.Android.Support.Annotations",
    "Xamarin.Android.Support.Compat",
    // "Xamarin.Android.Support.Constraint.Layout",
    // "Xamarin.Android.Support.Constraint.Layout.Solver",
    "Xamarin.Android.Support.Content",
    "Xamarin.Android.Support.Core.UI",
    "Xamarin.Android.Support.Core.Utils",
    "Xamarin.Android.Support.CustomTabs",
    "Xamarin.Android.Support.Design",
    "Xamarin.Android.Support.Dynamic.Animation",
    "Xamarin.Android.Support.Emoji",
    "Xamarin.Android.Support.Emoji.AppCompat",
    "Xamarin.Android.Support.Emoji.Bundled",
    "Xamarin.Android.Support.Exif",
    "Xamarin.Android.Support.Fragment",
    "Xamarin.Android.Support.InstantVideo",
    "Xamarin.Android.Support.Media.Compat",
    "Xamarin.Android.Support.Percent",
    "Xamarin.Android.Support.Recommendation",
    "Xamarin.Android.Support.TV.Provider",
    "Xamarin.Android.Support.Transition",
    "Xamarin.Android.Support.Vector.Drawable",
    "Xamarin.Android.Support.Wear",
    "Xamarin.Android.Support.Wearable",
    "Xamarin.Android.Support.v13",
    "Xamarin.Android.Support.v14.Preference",
    "Xamarin.Android.Support.v17.Leanback",
    "Xamarin.Android.Support.v17.Preference.Leanback",
    "Xamarin.Android.Support.v4",
    "Xamarin.Android.Support.v7.AppCompat",
    "Xamarin.Android.Support.v7.CardView",
    "Xamarin.Android.Support.v7.GridLayout",
    "Xamarin.Android.Support.v7.MediaRouter",
    "Xamarin.Android.Support.v7.Palette",
    "Xamarin.Android.Support.v7.Preference",
    "Xamarin.Android.Support.v7.RecyclerView",
    "Xamarin.Android.Support.v8.RenderScript",
};

bool IsBlacklisted(string id)
{
    id = id.ToLower();

    if (blacklistIdPrefix.Contains(id))
        return true;

    if (blacklistIdPrefix.Any(p => id.StartsWith(p)))
        return true;

    return false;
}

NuGetVersion GetSupportVersion(FilePath nuspec)
{
    var range = GetSupportVersionRange(nuspec);
    return range.MinVersion ?? range.MaxVersion;
}

VersionRange GetSupportVersionRange(FilePath nuspec)
{
    var xdoc = XDocument.Load(nuspec.FullPath);
    var ns = xdoc.Root.Name.Namespace;

    var xmd = xdoc.Root.Element(ns + "metadata");
    var xid = xmd.Element(ns + "id");

    string version;
    if (xid.Value.ToLower().StartsWith("xamarin.android.arch")) {
        version = xmd
            .Descendants(ns + "dependency")
            .First(e => e.Attribute("id").Value.ToLower().StartsWith("xamarin.android.support"))
            .Attribute("version")
            .Value;
    } else {
        version = xmd.Element(ns + "version").Value;
    }

    return VersionRange.Parse(version);
}

NuGetVersion GetArchVersion(FilePath nuspec)
{
    var range = GetArchVersionRange(nuspec);
    return range.MinVersion ?? range.MaxVersion;
}

VersionRange GetArchVersionRange(FilePath nuspec)
{
    var xdoc = XDocument.Load(nuspec.FullPath);
    var ns = xdoc.Root.Name.Namespace;

    var xmd = xdoc.Root.Element(ns + "metadata");
    var xid = xmd.Element(ns + "id");

    string version;
    if (xid.Value.ToLower().StartsWith("xamarin.android.support")) {
        version = xmd
            .Descendants(ns + "dependency")
            .First(e => e.Attribute("id").Value.ToLower().StartsWith("xamarin.android.arch"))
            .Attribute("version")
            .Value;
    } else {
        version = xmd.Element(ns + "version").Value;
    }

    return VersionRange.Parse(version);
}

NuGetVersion GetNewVersion(string id, string old)
{
    return GetNewVersion(id, NuGetVersion.Parse(old));
}

NuGetVersion GetNewVersion(string id, NuGetVersion old)
{
    if (keepLatestVersion) {
        var latest = GetLatestVersion(id);
        if (old == latest)
            return old;
    }

    return new NuGetVersion(
        old.Major,
        old.Minor,
        old.Patch,
        incrementVersion ? 990 + old.Revision : old.Revision,
        prereleaseLabel,
        (string)null);
}

NuGetVersion GetNewVersion(string id, VersionRange old)
{
    return GetNewVersion(id, old.MinVersion ?? old.MaxVersion);
}

NuGetVersion GetLatestVersion(string id)
{
    return GetDirectories($"{packagesPath}/{id}/*")
        .Select(d => NuGetVersion.Parse(d.GetDirectoryName()))
        .OrderByDescending(v => v)
        .FirstOrDefault();
}

Task("DownloadNuGets")
    .Does(async () =>
{
    var nugetSources = new List<SourceRepository> {
        Repository.Factory.GetCoreV3("https://api.nuget.org/v3/index.json")
    };

    if (!string.IsNullOrEmpty(localSource)) {
        nugetSources.Add(Repository.Factory.GetCoreV3(MakeAbsolute((DirectoryPath)localSource).FullPath));
    }

    var nugetCache = new SourceCacheContext();
    var nugetLogger = NullLogger.Instance;

    var processedIds = new List<string>();

    // download the bits from nuget.org and any local packages
    await DownloadNuGetsAsync(seedPackages);

    async Task DownloadNuGetsAsync(IEnumerable<string> ids)
    {
        EnsureDirectoryExists(packagesPath);

        foreach (var id in ids.Select(i => i.ToLower())) {
            // skip ids that have already been downloaded
            if (processedIds.Contains(id))
                continue;

            // skip packages that we don't want
            if (IsBlacklisted(id))
                continue;

            // mark this id as processed
            processedIds.Add(id);

            // get the versions for each nuget
            Information($"Making sure that all the versions of '{id}' are available for processing...");

            foreach (var nugetSource in nugetSources) {
                var mdRes = await nugetSource.GetResourceAsync<MetadataResource>();
                var allVersions = await mdRes.GetVersions(id, false, false, nugetCache, nugetLogger, default);

                // process the versions
                foreach (var version in allVersions) {
                    // skip versions tht are lower than what we want to support
                    var min = minimumVersion[minimumVersion.Keys.First(k => id.StartsWith(k))];
                    if (version < min)
                        continue;

                    var identity = new PackageIdentity(id, version);
                    var dest = packagesPath.Combine(id).Combine(version.ToNormalizedString());
                    var destFile = dest.CombineWithFilePath($"{id}.{version.ToNormalizedString()}.nupkg");

                    // download the packages, if needed
                    if (!FileExists(destFile)) {
                        Information($" - Downloading '{identity}'...");
                        EnsureDirectoryExists(dest);
                        var byIdRes = await nugetSource.GetResourceAsync<FindPackageByIdResource>();
                        using (var downloader = await byIdRes.GetPackageDownloaderAsync(identity, nugetCache, nugetLogger, default)) {
                            await downloader.CopyNupkgFileToAsync(destFile.FullPath, default);
                        }
                        Unzip(destFile, dest);
                    }

                    // download dependencies
                    var packageRes = await nugetSource.GetResourceAsync<PackageMetadataResource>();
                    var metadata = await packageRes.GetMetadataAsync(identity, nugetCache, nugetLogger, default);
                    var deps = metadata.DependencySets.SelectMany(g => g.Packages).Select(p => p.Id);
                    await DownloadNuGetsAsync(deps);
                }
            }
        }
    }
});

Task("PrepareWorkingDirectory")
    .IsDependentOn("DownloadNuGets")
    .Does(() =>
{
    EnsureDirectoryExists(workingPath);
    CleanDirectories(workingPath.FullPath);

    // copy the downloaded files into the working directory
    Information($"Copying packages...");
    foreach (var idDir in GetDirectories($"{packagesPath}/*")) {
        var id = idDir.GetDirectoryName();

        // skip packages that don't want
        if (IsBlacklisted(id))
            continue;

        Information($" - Copying all versions of '{id}'...");

        // we only want to copy the latest of each major version
        var versions = GetFiles($"{idDir}/*/*.nuspec")
            .Select(n => new { Dir = n.GetDirectory().GetDirectoryName(), Ver = GetSupportVersion(n) })
            .OrderByDescending(n => n.Ver)
            .GroupBy(n => n.Ver.Major, n => n.Dir)
            .Select(g => g.FirstOrDefault());
        foreach (var version in versions) {
            CopyDirectory($"{packagesPath}/{id}/{version}", $"{workingPath}/{id}/{GetNewVersion(id, version)}");
        }
    }

    // remove all the files we do not want in the nugets
    Information($"Removing junk...");
    var junkFiles =
        GetFiles($"{workingPath}/*/*.json") +
        GetFiles($"{workingPath}/*/*/*.nupkg") +
        GetFiles($"{workingPath}/*/*/.signature.p7s") +
        GetFiles($"{workingPath}/*/*/[Content_Types].xml");
    foreach (var junk in junkFiles) {
        DeleteFile(junk);
    }
    var junkDirs =
        GetDirectories($"{workingPath}/*/*/_rels") +
        GetDirectories($"{workingPath}/*/*/package");
    foreach (var junk in junkDirs) {
        DeleteDirectory(junk, new DeleteDirectorySettings {
            Force = true,
            Recursive = true
         });
    }

    // put all the nuspecs and contents into a standard format for processing
    Information($"Normalizing packages...");
    foreach (var idDir in GetDirectories($"{workingPath}/*")) {
        var id = idDir.GetDirectoryName();

        // skip packages that don't want
        if (IsBlacklisted(id))
            continue;

        Information($" - Normalizing all versions of '{id}'...");

        var nuspecs = GetFiles($"{idDir}/*/*.nuspec");
        foreach (var nuspec in nuspecs) {
            var targetFw = NormalizeNuspec(nuspec);
            NormalizeContents(nuspec.GetDirectory(), targetFw, "lib");
            NormalizeContents(nuspec.GetDirectory(), targetFw, "build");
            NormalizeContents(nuspec.GetDirectory(), targetFw, "proguard");

            // change the path to the proguard.txt files, nothing clever, just a replace
            var oldLink = @"..\..\proguard\proguard.txt";
            var newLink = $@"..\..\proguard\{targetFw.GetShortFolderName()}\proguard.txt";
            var targets = $"{nuspec.GetDirectory()}/build/{targetFw.GetShortFolderName()}/*.targets";
            ReplaceTextInFiles(targets, oldLink, newLink);
        }
    }

    void NormalizeContents(DirectoryPath dir, NuGetFramework fw, string subdir)
    {
        if (!DirectoryExists($"{dir}/{subdir}"))
            return;

        // temp checks
        if (GetDirectories($"{dir}/{subdir}/*/*").Any())
            throw new Exception($"'{dir}' contains sub directories.");

        // make sure the files are in the right folder:
        //  - 0 means that this is a thin package
        //      probably not the core build/lib folders (probably proguard)
        //  - 1 means that this is a thin package
        //  - 2+ more means this is already a fat package
        if (GetDirectories($"{dir}/{subdir}/*").Count() <= 1) {
            EnsureDirectoryExists(dir.Combine("temp"));
            MoveFiles($"{dir}/{subdir}/**/*", dir.Combine("temp"));
            CleanDirectories($"{dir}/{subdir}");
            MoveDirectory(dir.Combine("temp"), dir.Combine(subdir).Combine(fw.GetShortFolderName()));
        }
    }

    NuGetFramework NormalizeNuspec(FilePath nuspec)
    {
        var supportVersion = GetSupportVersion(nuspec);
        var targetFw = apiLevelVersion[supportVersion.Major];

        var xdoc = XDocument.Load(nuspec.FullPath);
        var ns = xdoc.Root.Name.Namespace;
        var xmd = xdoc.Root.Element(ns + "metadata");

        // set the new version of the package
        var xv = xmd.Element(ns + "version");
        var version = NuGetVersion.Parse(xv.Value);
        xv.Value = GetNewVersion(xmd.Element(ns + "id").Value, version).ToNormalizedString();

        // make sure the <dependencies> element exists
        var xdeps = xmd.Element(ns + "dependencies");
        if (xdeps == null) {
            xdeps = new XElement(ns + "dependencies");
            xmd.Add(xdeps);
        }

        // move the loose dependencies into a group
        var xlooseDeps = xdeps.Elements(ns + "dependency");
        if (xlooseDeps.Any()) {
            xdeps.Add(new XElement(ns + "group",
                new XAttribute("targetFramework", targetFw.GetShortFolderName()),
                xlooseDeps));
        }

        // some packages have the wrong <group> targets, so recreate everything
        var xnewGroups = new Dictionary<int, XElement>();
        foreach (var pair in apiLevelVersion) {
            if (pair.Key > supportVersion.Major)
                continue;
            xnewGroups.Add(pair.Key, new XElement(ns + "group",
                new XAttribute("targetFramework", pair.Value.GetShortFolderName())));
        }

        // move the old dependencies into the new groups if they contain a support version
        // if not, then just use the version of the nuspec
        var xgroups = xdeps.Elements(ns + "group");
        foreach (var xoldGroup in xgroups) {
            var xgroupDeps = xoldGroup.Elements(ns + "dependency");
            var firstSupportVersion = xgroupDeps
                .Where(x => x.Attribute("id").Value.ToLower().StartsWith("xamarin.android.support"))
                .Select(x => VersionRange.Parse(x.Attribute("version").Value))
                .FirstOrDefault();
            var minVersion = firstSupportVersion?.MinVersion ?? supportVersion;
            xnewGroups[minVersion.Major].Add(xgroupDeps);
        }

        // set the new versions of the dependencies
        foreach (var xdep in xnewGroups.Values.Elements(ns + "dependency")) {
            if (IsBlacklisted(xdep.Attribute("id").Value))
                continue;

            var xdv = xdep.Attribute("version");
            var range = VersionRange.Parse(xdv.Value);
            xdv.Value = GetNewVersion(xdep.Attribute("id").Value.ToLower(), range).ToNormalizedString();
            if (useExplicitVersion) {
                xdv.Value = $"[{xdv.Value}]";
            }
        }

        // swap out the old dependencies for the new ones
        xdeps.RemoveAll();
        xdeps.Add(xnewGroups.Values);

        xdoc.Save(nuspec.FullPath);

        return targetFw;
    }
});

Task("CreateFatNuGets")
    .IsDependentOn("PrepareWorkingDirectory")
    .Does(async () =>
{
    var idDirs = GetDirectories($"{workingPath}/*");
    foreach (var idDir in idDirs) {
        var id = idDir.GetDirectoryName();

        // skip packages that don't want
        if (IsBlacklisted(id))
            continue;

        Information($"Processing all versions of '{id}'...");

        var versions = GetDirectories($"{idDir}/*")
            .Select(d => d.GetDirectoryName())
            .Select(v => NuGetVersion.Parse(v))
            .OrderByDescending(v => v)
            .ToList();

        // merge the older packages into the latest
        foreach (var cutoffVersion in versions) {
            Information($" - Processing version '{cutoffVersion}' of '{id}'...");

            var includedVersions = versions.Where(v => v < cutoffVersion).ToArray();

            MergeNuspecs(id, cutoffVersion, includedVersions);
            MergeContents(id, cutoffVersion, includedVersions, "lib");
            MergeContents(id, cutoffVersion, includedVersions, "build");
            MergeContents(id, cutoffVersion, includedVersions, "proguard");
            CreateDummyLibs(id, cutoffVersion);
        }
    }

    void CreateDummyLibs(string id, NuGetVersion version)
    {
        var root = $"{workingPath}/{id}/{version.ToNormalizedString()}/lib";

        foreach (var pair in apiLevelVersion) {
            var dir = $"{root}/{pair.Value.GetShortFolderName()}";
            if (!DirectoryExists(dir)) {
                EnsureDirectoryExists(dir);
                FileWriteText($"{dir}/_._", "");
            } else {
                // jump out as soon as we find a folder because we don't
                // want to add newer dummy folders
                break;
            }
        }
    }

    void MergeContents(string id, NuGetVersion version, NuGetVersion[] includedVersions, string subdir)
    {
        var dest = $"{workingPath}/{id}/{version.ToNormalizedString()}/{subdir}";

        foreach (var included in includedVersions) {
            var src = $"{workingPath}/{id}/{included.ToNormalizedString()}/{subdir}";
            if (DirectoryExists(src)) {
                CopyDirectory(src, dest);
            }
        }
    }

    void MergeNuspecs(string id, NuGetVersion version, NuGetVersion[] includedVersions)
    {
        var nuspec = $"{workingPath}/{id}/{version.ToNormalizedString()}/{id}.nuspec";
        var xdoc = XDocument.Load(nuspec);
        var ns = xdoc.Root.Name.Namespace;
        var xmd = xdoc.Root.Element(ns + "metadata");
        var xversion = xmd.Element(ns + "version");
        var xdeps = xmd.Element(ns + "dependencies");
        var xgroups = xdeps.Elements(ns + "group");
        var isArch = id.ToLower().StartsWith("xamarin.android.arch");

        foreach (var included in includedVersions) {
            var includedNuspec = $"{workingPath}/{id}/{included.ToNormalizedString()}/{id}.nuspec";
            var xincluded = XDocument.Load(includedNuspec);

            var ins = xincluded.Root.Name.Namespace;
            var ixmd = xincluded.Root.Element(ins + "metadata");
            var ixdeps = ixmd.Element(ins + "dependencies");
            var ixgroups = ixdeps.Elements(ins + "group");

            foreach (var ixgroup in ixgroups) {
                var xgroup = xgroups.FirstOrDefault(g => g.Attribute("targetFramework").Value == ixgroup.Attribute("targetFramework").Value);
                foreach (var ixdep in ixgroup.Elements(ins + "dependency")) {
                    var includedArch = ixdep.Attribute("id").Value.ToLower().StartsWith("xamarin.android.arch");
                    string newVersion = null;
                    if (isArch == includedArch) {
                        // if both are arch, or both are support, use the current version
                        newVersion = xversion.Value;
                    } else if (isArch) {
                        // if the main is arch, but this is support
                        newVersion = GetSupportVersion(nuspec).ToNormalizedString();
                    } else {
                        // if the main is support and this is arch
                        newVersion = GetArchVersion(nuspec).ToNormalizedString();
                    }
                    ixdep.SetAttributeValue("version", useExplicitVersion ? $"[{newVersion}]" : newVersion);
                }
                xgroup.Add(ixgroup.Elements());
            }
        }

        xdoc.Save(nuspec);
    }
});

Task("PackNuGets")
    .IsDependentOn("CreateFatNuGets")
    .Does(async () =>
{
    EnsureDirectoryExists(outputPath);
    CleanDirectories(outputPath.FullPath);

    var idDirs = GetDirectories($"{workingPath}/*");
    foreach (var idDir in idDirs) {
        var id = idDir.GetDirectoryName();

        // skip packages that don't want
        if (IsBlacklisted(id))
            continue;

        var versions = GetDirectories($"{workingPath}/{id}/*")
            .Select(d => new { Dir = d, Ver = NuGetVersion.Parse(d.GetDirectoryName()) })
            .OrderByDescending(v => v.Ver);

        foreach (var version in versions) {
            var nuspec = GetFiles($"{version.Dir}/*.nuspec").FirstOrDefault();
            Information($"Packing {nuspec}...");
            NuGetPack(nuspec, new NuGetPackSettings {
                BasePath = nuspec.GetDirectory(),
                OutputDirectory = outputPath
            });

            if (packLatestOnly)
                break;
        }
    }
});

Task("Default")
    .IsDependentOn("DownloadNuGets")
    .IsDependentOn("PrepareWorkingDirectory")
    .IsDependentOn("CreateFatNuGets")
    .IsDependentOn("PackNuGets");

RunTarget(target);
