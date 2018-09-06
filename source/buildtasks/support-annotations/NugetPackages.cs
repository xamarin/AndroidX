using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Runtime.Versioning;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml.Linq;
using System.Xml.XPath;
using Microsoft.Build.Utilities;

namespace Xamarin.Android.Support.BuildTasks
{
	public static class NugetPackages
	{
		public static readonly Dictionary<int, Version> AndroidApiLevelsAndVersions = new Dictionary<int, Version>
		{
			{ 23, new Version(6, 0) },
			{ 24, new Version(7, 0) },
			{ 25, new Version(7, 1) },
			{ 26, new Version(8, 0) },
			{ 27, new Version(8, 1) },
			{ 28, new Version(9, 0) },
		};

		public static int GetMajorVersion(string version)
		{
			const string rxMajor = "^[0-9]+(\\.|$)";

			var match = Regex.Match(version, rxMajor);

			var cleanMatch = match?.Value?.Trim()?.Trim('.');

			if (int.TryParse(cleanMatch, out var major))
				return major;

			return -1;
		}

		public static Version FrameworkVersionForSupportVersion(string supportVersion)
		{
			var apiLevel = GetMajorVersion(supportVersion);

			if (AndroidApiLevelsAndVersions.ContainsKey(apiLevel))
				return AndroidApiLevelsAndVersions[apiLevel];

			return new Version(0, 0);
		}

		public static void GatherPackagesConfigVersions(string packageIdPrefix, string projectPath, IEnumerable<string> excludedPackages, Dictionary<string, string> packageVersions)
		{
			var path = Path.Combine(projectPath, "packages.config");

			var xdoc = XDocument.Load(path);

			var packageNodes = xdoc.XPathSelectElements("/packages/package");

			foreach (var pkgNode in packageNodes)
			{
				var nugetId = pkgNode?.Attribute("id")?.Value;
				var nugetVersion = pkgNode?.Attribute("version")?.Value;

				if (!nugetId.StartsWith(packageIdPrefix, StringComparison.InvariantCultureIgnoreCase))
					continue;
				if (excludedPackages.Contains(nugetId.ToLowerInvariant()))
					continue;

				packageVersions[nugetId] = nugetVersion;
			}
		}

		public static void GatherProjectJsonVersions(string packageIdPrefix, string projectExtensionsPath, IEnumerable<string> excludedPackages, Version monoandroidVersion, Dictionary<string, string> packageVersions, TaskLoggingHelper log = null)
		{
			var path = Path.Combine(projectExtensionsPath, "project.assets.json");

			var js = new JavaScriptSerializer();
			var json = js.Deserialize<dynamic>(File.ReadAllText(path));

			var tfm = new FrameworkName("MonoAndroid", monoandroidVersion);

			var targets = json?["targets"];
			var projTarget = targets?[tfm.FullName];

			foreach (var rf in projTarget) {

				if (!rf?.Value?["type"]?.ToString()?.Equals("package", StringComparison.InvariantCultureIgnoreCase))
					continue;

				var parts = rf.Key.Split(new[] { '/' }, 2);

				string nugetId = parts[0];
				string nugetVersion = parts[1];

				if (!nugetId.StartsWith(packageIdPrefix, StringComparison.InvariantCultureIgnoreCase))
					continue;
				if (excludedPackages.Contains(nugetId?.ToString()?.ToLowerInvariant()))
					continue;

				packageVersions[nugetId] = nugetVersion;
			}
		}

		public static int GetDistinctVersions(string packageIdPrefix, IEnumerable<string> excludedPackages, Dictionary<string, string> packageVersions)
		{
			// Get the number of support library versions encountered for all support library packages
			var distinctSupportVersions = packageVersions
				.Where(kvp => kvp.Key.StartsWith(packageIdPrefix, StringComparison.InvariantCultureIgnoreCase)
					   && !excludedPackages.Contains(kvp.Key.ToLowerInvariant()))
				.Select(kvp => kvp.Value)
				.Distinct()
				.Count();

			return distinctSupportVersions;
		}

		public static string GetSupportVersion(string packageIdPrefix, Dictionary<string, string> packageVersions)
		{
			// Get the number of support library versions encountered for all support library packages
			var supportVersion = packageVersions
				.Where(kvp => kvp.Key.StartsWith(packageIdPrefix, StringComparison.InvariantCultureIgnoreCase))
				.Select(kvp => kvp.Value)
				.FirstOrDefault();

			return supportVersion;
		}

		static readonly HttpClient http = new HttpClient();

		public static async Task<string> GetRecommendedSupportPackageVersion(int apiLevel)
		{
			// Default to the apilevel.x since this is displayed as a suggestion in a message
			var bestVersion = apiLevel.ToString() + ".x";

			try
			{
				var searchUrl = await GetNuGetSearchUrl();

				var queryUrl = searchUrl + "?q=packageid:Xamarin.Android.Support.Annotations&prerelease=false";

				var data = await http.GetStringAsync(queryUrl);

				var js = new JavaScriptSerializer();
				var json = js.Deserialize<dynamic>(data);

				var versions = json["data"][0]["versions"];

				foreach (var version in versions)
				{
					var v = version["version"].ToString();

					if (v.StartsWith(apiLevel.ToString() + ".", StringComparison.InvariantCultureIgnoreCase))
						bestVersion = v;
				}
			} catch (Exception ex) {
				Console.WriteLine(ex);
			}

			return bestVersion;
		}

		static async Task<string> GetNuGetSearchUrl()
		{
			var data = await http.GetStringAsync("https://api.nuget.org/v3/index.json");

			var js = new JavaScriptSerializer();
			var json = js.Deserialize<dynamic>(data);

			foreach (var item in json["resources"]) {
				if (item["@type"] == "SearchQueryService")
					return item["@id"];
			}

			return null;
		}
	}
}
