using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace AndroidBinderator
{
	public class BindingConfig
	{
		static HttpClient? client;

		[JsonProperty("basePath")]
		public string? BasePath { get; set; }

		[JsonProperty("mavenRepositoryType")]
		public MavenRepoType MavenRepositoryType { get; set; } = MavenRepoType.Google;

		[JsonProperty("mavenRepositoryLocation")]
		public string? MavenRepositoryLocation { get; set; }

		[JsonProperty("slnFile")]
		public string? SolutionFile { get; set; }

		/// True to consider 'Runtime' dependencies from a POM file, False to ignore them.
		[JsonProperty ("strictRuntimeDependencies")]
		public bool StrictRuntimeDependencies { get; set; }

		[JsonProperty ("defaultBindingsType")]
		public BindingType DefaultBindingsType { get; set; } = BindingType.Targets;

		[JsonProperty ("excludedRuntimeDependencies")]
		public string? ExcludedRuntimeDependencies { get; set; }

		[JsonProperty ("additionalProjects")]
		public List<string> AdditionalProjects { get; set; } = new List<string> ();

		[JsonProperty ("downloadExternalsWithFullName")]
		public bool DownloadExternalsWithFullName { get; set; } = false;

		[DefaultValue ("generated")]
		[JsonProperty ("generatedDir")]
		public string GeneratedDir { get; set; } = "generated";

		[DefaultValue (true)]
		[JsonProperty ("downloadExternals")]
		public bool DownloadExternals { get; set; } = true;

		[DefaultValue (true)]
		[JsonProperty ("downloadJavaSourceJars")]
		public bool DownloadJavaSourceJars { get; set; } = true;

		[DefaultValue (true)]
		[JsonProperty ("downloadJavaDocJars")]
		public bool DownloadJavaDocJars { get; set; } = true;

		[DefaultValue (true)]
		[JsonProperty ("downloadMetadataFiles")]
		public bool DownloadMetadataFiles { get; set; } = true;

		[DefaultValue(true)]
		[JsonProperty("downloadPoms")]
		public bool DownloadPoms { get; set; } = true;

		[DefaultValue ("externals")]
		[JsonProperty ("externalsDir")]
		public string ExternalsDir { get; set; } = "externals";

		[JsonProperty("nugetVersionSuffix")]
		public string? NugetVersionSuffix { get; set; }

		public bool ShouldSerializeDebug () => false;

		[JsonProperty("debug")]
		public BindingConfigDebug Debug { get; set; } = new BindingConfigDebug();

		[JsonProperty("templates")]
		public List<TemplateConfig> Templates { get; set; } = new List<TemplateConfig>();

		[JsonProperty("artifacts")]
		public List<MavenArtifactConfig> MavenArtifacts { get; set; } = new List<MavenArtifactConfig>();

		public bool ShouldSerializeMetadata () => Metadata.Count > 0;

		[JsonProperty ("metadata")]
		public Dictionary<string, string> Metadata { get; set; } = new Dictionary<string, string>();

		[JsonProperty ("licenses")]
		public List<LicenseConfig> Licenses { get; set; } = new List<LicenseConfig> ();

		[JsonProperty("templateSets")]
		public List<TemplateSetModel> TemplateSets { get; set; } = new List<TemplateSetModel>();

		public TemplateSetModel GetTemplateSet(string? name)
		{
			// If an artifact doesn't specify a template set, first try using the original
			// single template list if it exists.  If not, look for a template set called "default".
			if (string.IsNullOrEmpty(name)) {
				if (Templates.Any())
					return new TemplateSetModel { Templates = Templates };

				name = "default";
			}

			var set = TemplateSets.FirstOrDefault(s => s.Name == name);

			if (set == null)
				throw new ArgumentException($"Could not find requested template set '{name}'");

			return set;
		}

		/// <summary>
		/// Load a config.json file from disk or a URL
		/// </summary>
		public static async Task<BindingConfig> Load (string path)
		{
			string? json;

			if (path.StartsWith ("http")) {
				// Remote configuration file URL
				client ??= new HttpClient();
				json = await client.GetStringAsync (path);
			} else {
				json = File.ReadAllText (path);
			}

			var config_list = JsonConvert.DeserializeObject<List<BindingConfig>> (json) ?? throw new InvalidOperationException ("Could not deserialize config file");
			var config = config_list.First ();

			// Keep file sorted by:
			// - Is dependency only
			// - groupid
			// - artifactid
			config.MavenArtifacts.Sort ((MavenArtifactConfig a, MavenArtifactConfig b) => string.Compare ($"{a.DependencyOnly}-{a.GroupId} {a.ArtifactId}", $"{b.DependencyOnly}-{b.GroupId} {b.ArtifactId}"));

			// Licenses are sorted by name
			config.Licenses.Sort ((LicenseConfig a, LicenseConfig b) => string.Compare (a.Name, b.Name));

			return config;
		}

		public void Save (string path)
		{
			var serializer_settings = new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore };
			serializer_settings.Converters.Add (new Newtonsoft.Json.Converters.StringEnumConverter ());

			// Write updated config.json back to disk
			List<BindingConfig> config = [this];
			var output = JsonConvert.SerializeObject (config, Formatting.Indented, serializer_settings);
			File.WriteAllText (path, output + Environment.NewLine);
		}
	}

	public class BindingConfigDebug
	{
		public bool DebugMode { get; set; } = false;
		public bool DumpModels { get; set; } = false;
	}

	public enum MavenRepoType
	{
		Url,
		Directory,
		Google,
		MavenCentral
	}

	public enum BindingType
	{
		[EnumMember (Value = "targets")]
		Targets,
		[EnumMember (Value = "androidlibrary")]
		AndroidLibrary,
		[EnumMember (Value = "no-bindings")]
		NoBindings
	}
}
