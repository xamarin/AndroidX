#! "netcoreapp3.1"

#r "nuget: MavenNet, 2.2.0"
#r "nuget: Newtonsoft.Json, 12.0.3"
#r "nuget: NuGet.Versioning, 5.8.0"

// Usage:
//   dotnet tool install -g dotnet-script
//   dotnet script update-config.csx -- ../../config.json <update|bump>
// This script compares the versions of Java packages we are currently binding to the
// stable versions available in Google's Maven repository.  The specified configuration
// file can be automatically updated by including the "update" argument.  A revision bump
// can be applied to all packages with the "bump" argument, which is mutually exclusive
// with "update".
using MavenNet;
using MavenNet.Models;
using Newtonsoft.Json;
using NuGet.Versioning;

// Parse the configuration file
var config_file = Args[0];

if (string.IsNullOrWhiteSpace (config_file) || !File.Exists (config_file)) {
	System.Console.WriteLine ($"Could not find configuration file: '{config_file}'");
	return -1;
}

var config_json = File.ReadAllText (config_file);
var config = JsonConvert.DeserializeObject<List<MyArray>> (config_json);
var should_update = Args.Count > 1 && Args[1].ToLowerInvariant () == "update";
var should_minor_bump = Args.Count > 1 && Args[1].ToLowerInvariant () == "bump";

// Query Maven
var repo = MavenRepository.FromGoogle ();
await repo.Refresh ();

Console.WriteLine ("| Package (* = Needs Update)                                   | Currently Bound | Latest Stable   |");
Console.WriteLine ("|--------------------------------------------------------------|-----------------|-----------------|");

// Find the Maven artifact for each package in our configuration file
foreach (var art in config[0].Artifacts.Where(a => !a.DependencyOnly)) {
	var a = FindMavenArtifact (repo, art);

	if (a is null)
		continue;

	var package_name = $"{art.GroupId}.{art.ArtifactId}";
	var current_version = art.Version;

	if (NeedsUpdate (art, a))
	{
		package_name = "* " + package_name;

		// Update the JSON objects
		if (should_update)
		{
			var new_version = GetLatestVersion (a)?.ToString ();
			var prefix = art.NugetVersion.StartsWith ("1" + art.Version + ".") ? "1" : string.Empty;

			art.Version = new_version;
			art.NugetVersion = prefix + new_version;
		}
	}

	// Bump the revision version of all NuGet versions
	// If there isn't currently a revision version, make it ".1"
	if (should_minor_bump)
	{
		string version = "";
		string release = "";
		int revision = 0;

		var str = art.NugetVersion;

		if (str.Contains ('-')) {
			release = str.Substring (str.IndexOf ('-'));
			str = str.Substring (0, str.LastIndexOf ('-'));
		}

		var period_count = str.Count (c => c == '.');

		if (period_count == 2) {
			version = str;
			revision = 1;
		} else if (period_count == 3) {
			version = str.Substring (0, str.LastIndexOf ('.'));
			revision = int.Parse (str.Substring (str.LastIndexOf ('.') + 1));
			revision++;
		}

		art.NugetVersion = $"{version}.{revision}{release}";
	}

	Console.WriteLine ($"| {package_name.PadRight (60)} | {current_version.PadRight (15)} | {(GetLatestVersion (a)?.ToString () ?? string.Empty).PadRight (15)} |");

	if (should_update || should_minor_bump)
	{
		// Write update config.json back to disk
		var output = JsonConvert.SerializeObject (config, Formatting.Indented);
		File.WriteAllText (config_file, output + Environment.NewLine);
	}
}

static Artifact FindMavenArtifact (MavenRepository repo, ArtifactModel artifact)
{
	var group = repo.Groups.FirstOrDefault (g => artifact.GroupId == g.Id);

	return group?.Artifacts?.FirstOrDefault (a => artifact.ArtifactId == a.Id);
}

static bool NeedsUpdate (ArtifactModel model, Artifact artifact)
{
	// Get latest stable version
	var latest = GetLatestVersion (artifact);

	// No stable version
	if (latest is null)
		return false;

	// Already on latest
	var current = SemanticVersion.Parse (model.Version);

	if (latest <= current)
		return false;

	return true;
}

public static SemanticVersion GetLatestVersion (Artifact artifact, bool includePrerelease = false)
{
	var versions = artifact.Versions.Select(v => GetVersion (v));

	if (!includePrerelease)
		versions = versions.Where (v => !v.IsPrerelease);

	if (!versions.Any ())
		return null;

	return versions.Max ();
}

static SemanticVersion GetVersion (string s)
{
	var hyphen = s.IndexOf ('-');
	var version = hyphen >= 0 ? s.Substring (0, hyphen) : s;
	var tag = hyphen >= 0 ? s.Substring (hyphen) : string.Empty;

	// Stuff like: 1.1.1d-alpha-1
	if (version.Any (c => char.IsLetter (c)))
		return new SemanticVersion (0, 0, 0);

	if (version.Count (c => c == '.') == 1)
		version += ".0";

	return SemanticVersion.Parse (version + tag);
}

// Configuration File Model
public class Template
{
	[JsonProperty ("templateFile")]
	public string TemplateFile { get; set; }

	[JsonProperty ("outputFileRule")]
	public string OutputFileRule { get; set; }
}

public class ArtifactModel
{
	[JsonProperty ("groupId")]
	public string GroupId { get; set; }

	[JsonProperty ("artifactId")]
	public string ArtifactId { get; set; }

	[JsonProperty ("version")]
	public string Version { get; set; }

	[JsonProperty ("nugetVersion")]
	public string NugetVersion { get; set; }

	[JsonProperty ("nugetId")]
	public string NugetId { get; set; }

	[JsonProperty ("dependencyOnly")]
	public bool DependencyOnly { get; set; }
}

public class MyArray
{
	[JsonProperty ("mavenRepositoryType")]
	public string MavenRepositoryType { get; set; }

	[JsonProperty ("slnFile")]
	public string SlnFile { get; set; }

	[JsonProperty ("additionalProjects")]
	public List<string> AdditionalProjects { get; set; }

	[JsonProperty ("templates")]
	public List<Template> Templates { get; set; }

	[JsonProperty ("artifacts")]
	public List<ArtifactModel> Artifacts { get; set; }
}

public class Root
{
	[JsonProperty ("MyArray")]
	public List<MyArray> MyArray { get; set; }
}
