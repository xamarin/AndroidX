#nullable disable

using System.ComponentModel;
using Newtonsoft.Json;

namespace AllPackagesTests;

public class BinderatorConfigFileParser
{
	public static async Task<List<MyArray>> ParseConfigurationFile (string filename)
	{
		string json;

		if (filename.StartsWith ("http")) {

			// Configuration file URL
			using (var client = new HttpClient ())
				json = await client.GetStringAsync (filename);

		} else {

			// Local configuration file
			if (string.IsNullOrWhiteSpace (filename) || !File.Exists (filename)) {
				Console.WriteLine ($"Could not find configuration file: '{filename}'");
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
			ConfigFile = args [0];

			Update = args.Any (a => a.ToLowerInvariant () == "update");
			Bump = args.Any (a => a.ToLowerInvariant () == "bump");
			Sort = args.Any (a => a.ToLowerInvariant () == "sort");
			Published = args.Any (a => a.ToLowerInvariant () == "published");

			DependencyConfigs = args.Where (a => a.StartsWith ("-dep:")).Select (a => a.Substring (5)).ToList ();
		}

		public bool ShouldWriteOutput => Update || Bump || Sort;
	}
}
