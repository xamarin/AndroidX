#! "net6.0"

#r "nuget: MavenNet, 2.2.13"
#r "nuget: Newtonsoft.Json, 13.0.1"
#r "nuget: NuGet.Versioning, 5.11.0"

// Usage:
//   dotnet tool install -g dotnet-script
//   dotnet script update-config.csx -- ../../config.json <update|bump|published|sort>
// This script compares the versions of Java packages we are currently binding to the
// stable versions available in Google's Maven repository.  
// update - Automatically update the specified configuration file
// bump - Apply NuGet revision bump to *all* packages
// published - Display which NuGet package versions are already published on NuGet.org
// sort - Sort the provided config.json without making any updates

using MavenNet;
using MavenNet.Models;
using Newtonsoft.Json;
using NuGet.Versioning;
using System.ComponentModel;
using System.Net.Http;

var options = new Options (Args);
var config = await ParseConfigurationFile (options.ConfigFile);
var external_deps = await GetExternalDependencies (options);

var serializer_settings = new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore };
serializer_settings.Converters.Add (new Newtonsoft.Json.Converters.StringEnumConverter ());

// Keep file sorted by dependency only, then by groupid then by artifactid
foreach (var array in config)
	array.Artifacts.Sort ((ArtifactModel a, ArtifactModel b) => string.Compare ($"{a.DependencyOnly}-{a.GroupId} {a.ArtifactId}", $"{b.DependencyOnly}-{b.GroupId} {b.ArtifactId}"));

// Query Maven
await MavenFactory.Initialize (config);

var column1 = ("Package" + (options.Published ? "" : " (* = Needs Update)")).PadRight (58);
var column2 = (options.Published ? "Version" : "Currently Bound").PadRight (17);
var column3 = (options.Published ? "Status" : "Latest Stable").PadRight (15);

Console.WriteLine ($"| {column1} | {column2} | {column3} |");
Console.WriteLine ("|------------------------------------------------------------|-------------------|-----------------|");

// Find the Maven artifact for each package in our configuration file
foreach (var art in config[0].Artifacts.Where (a => !a.DependencyOnly)) {
	var a = FindMavenArtifact (config, art);

	if (a is null)
		continue;

	var package_name = $"{art.GroupId}.{art.ArtifactId}";
	var current_version = art.Version;

	// Update packages we are binding
	if (NeedsUpdate (art, a))
	{
		package_name = "* " + package_name;

		// Update the JSON objects
		if (options.Update)
		{
			var new_version = GetLatestVersion (a)?.ToString ();
			var prefix = art.NugetVersion.StartsWith ("1" + art.Version + ".") ? "1" : string.Empty;

			art.Version = new_version;
			art.NugetVersion = prefix + new_version;
		}
	}

	if (art.Frozen)
		package_name = "# " + package_name;
  
	// Bump the revision version of all NuGet versions
	// If there isn't currently a revision version, make it ".1"
	if (options.Bump)
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

  if (options.Published) {
    var status = (await DoesNuGetPackageAlreadyExist (art.NugetId, art.NugetVersion)) ? "Published" : "Not Published";
	  Console.WriteLine ($"| {art.NugetId.PadRight (58)} | {art.NugetVersion.PadRight (17)} | {status.PadRight (15)} |");  
  } else {
	  Console.WriteLine ($"| {package_name.PadRight (58)} | {current_version.PadRight (17)} | {(GetLatestVersion (a)?.ToString () ?? string.Empty).PadRight (15)} |");  
  }
}

// Update any "dependencyOnly: true" packages to the latest we can find
if (external_deps.Any ()) {

	Console.WriteLine ();

	var column1 = "Dependencies (* = Needs Update)".PadRight (58);
	var column2 = (options.Published ? "Version" : "Current Reference").PadRight (17);
	var column3 = (options.Published ? "Status" : "Latest Stable").PadRight (15);

	Console.WriteLine ($"| {column1} | {column2} | {column3} |");
	Console.WriteLine ("|------------------------------------------------------------|-------------------|-----------------|");

	foreach (var art in config[0].Artifacts.Where (a => a.DependencyOnly && !a.Frozen)) {
		var dep = external_deps.FirstOrDefault (d => d.NugetId == art.NugetId);
	  var current_version = art.NugetVersion;
		
		// We need to ensure the NuGet dependency has actually been published
		if (dep != null && await DoesNuGetPackageAlreadyExist (dep.NugetId, dep.NugetVersion)) {
		  art.Version = dep.Version;
		  art.NugetVersion = dep.NugetVersion;
		}

	  var package_name = $"{art.GroupId}.{art.ArtifactId}";
	  
	  if (current_version != art.NugetVersion)
	    package_name = "* " + package_name;
		
		if (!options.Published) 
	    Console.WriteLine ($"| {package_name.PadRight (58)} | {current_version.PadRight (17)} | {art.NugetVersion.PadRight (15)} |");  
	}
}

if (options.ShouldWriteOutput)
{
	// Write updated config.json back to disk
	var output = JsonConvert.SerializeObject (config, Formatting.Indented, serializer_settings);
	File.WriteAllText (options.ConfigFile, output + Environment.NewLine);
}

static Artifact FindMavenArtifact (List<MyArray> config, ArtifactModel artifact)
{
	var repo = MavenFactory.GetMavenRepository (config, artifact);
	var group = repo.Groups.FirstOrDefault (g => artifact.GroupId == g.Id);

	return group?.Artifacts?.FirstOrDefault (a => artifact.ArtifactId == a.Id);
}

static bool NeedsUpdate (ArtifactModel model, Artifact artifact)
{
	// Don't update package if it's "Frozen"
	if (model.Frozen)
		return false;
    
	// Get latest stable version
	var latest = GetLatestVersion (artifact);

	// No stable version
	if (latest is null)
		return false;

	// Already on latest
	var current = GetVersion (model.Version);

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

	if (version.Count (c => c == '.') == 0)
		version += ".0.0";

	if (version.Count (c => c == '.') == 1)
		version += ".0";

	// SemanticVersion can't handle more than 3 parts, like '0.11.91.1'
	if (version.Count (c => c == '.') > 2)
		return new SemanticVersion (0, 0, 0);

	return SemanticVersion.Parse (version + tag);
}
	
public static async Task<bool> DoesNuGetPackageAlreadyExist (string package, string version)
{
  var url = $"https://www.nuget.org/api/v2/package/{package}/{version}";
  
  using (var client = new HttpClient ()) {
    var result = await client.GetAsync (url);
    return result.StatusCode != System.Net.HttpStatusCode.NotFound;
  }
}

static async Task<List<MyArray>> ParseConfigurationFile (string filename)
{
  string json;
  
	if (filename.StartsWith ("http")) {
	
	  // Configuration file URL
	  using (var client = new HttpClient ())
			json = await client.GetStringAsync (filename);
	
	} else {
	
		// Local configuration file
		if (string.IsNullOrWhiteSpace (filename) || !File.Exists (filename)) {
			System.Console.WriteLine ($"Could not find configuration file: '{filename}'");
			Environment.Exit (-1);
		}
		
		json = File.ReadAllText (filename);
	}

	return JsonConvert.DeserializeObject<List<MyArray>> (json);
}

static async Task<List<ArtifactModel>> GetExternalDependencies (Options options)
{
  var list = new List<ArtifactModel> ();
  
  foreach (var file in options.DependencyConfigs) {
    var config = await ParseConfigurationFile (file);
    
    list.AddRange (config.SelectMany (arr => arr.Artifacts.Where (a => !a.DependencyOnly)));
  }
  
  return list;
}

public static class MavenFactory
{
	static readonly Dictionary<string, MavenRepository> repositories = new Dictionary<string, MavenRepository> ();

	public static async Task Initialize (List<MyArray> config)
	{
		var artifact_mavens = new List<(MavenRepository, ArtifactModel)> ();

		foreach (var artifact in config[0].Artifacts.Where (ma => !ma.DependencyOnly)) {
			var (type, location) = GetMavenInfoForArtifact (config, artifact);
			var repo = GetOrCreateRepository (type, location);

			artifact_mavens.Add ((repo, artifact));
		}

		foreach (var maven_group in artifact_mavens.GroupBy (a => a.Item1)) {
			var maven = maven_group.Key;
			var artifacts = maven_group.Select (a => a.Item2);

			foreach (var artifact_group in artifacts.GroupBy (a => a.GroupId)) {
				var gid = artifact_group.Key;
				var artifact_ids = artifact_group.Select (a => a.ArtifactId).ToArray ();

				await maven.Populate (gid, artifact_ids);
			}
		}
	}

	public static MavenRepository GetMavenRepository (List<MyArray> config, ArtifactModel artifact)
	{
		var (type, location) = GetMavenInfoForArtifact (config, artifact);
		var repo = GetOrCreateRepository (type, location);

		return repo;
	}

	static (MavenRepoType type, string location) GetMavenInfoForArtifact (List<MyArray> config, ArtifactModel artifact)
	{
		var template = config[0].GetTemplateSet (artifact.TemplateSet);

		if (template.MavenRepositoryType.HasValue)
			return (template.MavenRepositoryType.Value, template.MavenRepositoryLocation);

		return (config[0].MavenRepositoryType, config[0].MavenRepositoryLocation);
	}

	static MavenRepository GetOrCreateRepository (MavenRepoType type, string location)
	{
		var key = $"{type}|{location}";

		if (repositories.TryGetValue (key, out MavenRepository repository))
			return repository;

		MavenRepository maven;

		if (type == MavenRepoType.Directory)
			maven = MavenRepository.FromDirectory (location);
		else if (type == MavenRepoType.Url)
			maven = MavenRepository.FromUrl (location);
		else if (type == MavenRepoType.MavenCentral)
			maven = MavenRepository.FromMavenCentral ();
		else
			maven = MavenRepository.FromGoogle ();

		repositories.Add (key, maven);

		return maven;
	}
}

// Configuration File Model
public class Template
{
	[JsonProperty ("templateFile")]
	public string TemplateFile { get; set; }

	[JsonProperty ("outputFileRule")]
	public string OutputFileRule { get; set; }
}

public class TemplateSetModel
{
	[JsonProperty ("name")]
	public string Name { get; set; }

	[JsonProperty ("mavenRepositoryType")]
	public MavenRepoType? MavenRepositoryType { get; set; }

	[JsonProperty ("mavenRepositoryLocation")]
	public string MavenRepositoryLocation { get; set; } = null;

	[JsonProperty ("templates")]
	public List<Template> Templates { get; set; } = new List<Template> ();
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

	[DefaultValue ("")]
	[JsonProperty ("dependencyOnly")]
	public bool DependencyOnly { get; set; }

	[JsonProperty ("frozen")]
	public bool Frozen { get; set; }

	[JsonProperty ("excludedRuntimeDependencies")]
	public string ExcludedRuntimeDependencies { get; set; }

	[JsonProperty ("templateSet")]
	public string TemplateSet { get; set; }

	[JsonProperty ("metadata")]
	public Dictionary<string, string> Metadata { get; set; } = new Dictionary<string, string> ();

	public bool ShouldSerializeMetadata () => Metadata.Any ();
}

public class MyArray
{
	[JsonProperty ("mavenRepositoryType")]
	public MavenRepoType MavenRepositoryType { get; set; }

	[JsonProperty ("mavenRepositoryLocation")]
	public string MavenRepositoryLocation { get; set; }

	[JsonProperty ("slnFile")]
	public string SlnFile { get; set; }

	[JsonProperty ("strictRuntimeDependencies")]
	public bool StrictRuntimeDependencies { get; set; }

	[JsonProperty ("excludedRuntimeDependencies")]
	public string ExcludedRuntimeDependencies { get; set; }

	[JsonProperty ("additionalProjects")]
	public List<string> AdditionalProjects { get; set; }

	[JsonProperty ("templates")]
	public List<Template> Templates { get; set; }

	[JsonProperty ("artifacts")]
	public List<ArtifactModel> Artifacts { get; set; }

	[JsonProperty ("templateSets")]
	public List<TemplateSetModel> TemplateSets { get; set; } = new List<TemplateSetModel> ();

	public TemplateSetModel GetTemplateSet (string name)
	{
		// If an artifact doesn't specify a template set, first try using the original
		// single template list if it exists.  If not, look for a template set called "default".
		if (string.IsNullOrEmpty (name)) {
			if (Templates.Any ())
				return new TemplateSetModel { Templates = Templates };

			name = "default";
		}

		var set = TemplateSets.FirstOrDefault (s => s.Name == name);

		if (set == null)
			throw new ArgumentException ($"Could not find requested template set '{name}'");

		return set;
	}
}

public class Root
{
	[JsonProperty ("MyArray")]
	public List<MyArray> MyArray { get; set; }
}

public enum MavenRepoType
{
	Url,
	Directory,
	Google,
	MavenCentral
}

public class Options
{
  public string ConfigFile { get; }
  public bool Update { get; }
  public bool Bump { get; }
  public bool Sort { get; }
  public bool Published { get; }
  public List<string> DependencyConfigs { get; }
  
  public Options (IList<string> args)
  {
    // Config file must always be the first argument
    ConfigFile = args[0];
    
    Update = args.Any (a => a.ToLowerInvariant () == "update");
    Bump = args.Any (a => a.ToLowerInvariant () == "bump");
    Sort = args.Any (a => a.ToLowerInvariant () == "sort");
    Published = args.Any (a => a.ToLowerInvariant () == "published");
    
    DependencyConfigs = args.Where (a => a.StartsWith ("-dep:")).Select (a => a.Substring (5)).ToList ();
  }
  
  public bool ShouldWriteOutput => Update || Bump || Sort;
}