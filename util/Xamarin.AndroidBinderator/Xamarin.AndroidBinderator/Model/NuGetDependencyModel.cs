using System.Collections.Generic;

namespace AndroidBinderator
{
	public class NuGetDependencyModel
	{
		public bool IsProjectReference { get; set; }

		public string? NuGetPackageId { get; set; }
		public string? NuGetVersionBase { get; set; }
		public string? NuGetVersionSuffix { get; set; }
		public MavenArtifactConfig? MavenArtifactConfig { get; set; }

		public string? NuGetVersion =>
			!IsProjectReference || string.IsNullOrWhiteSpace(NuGetVersionSuffix)
				? NuGetVersionBase
				: NuGetVersionBase + NuGetVersionSuffix;

		public MavenArtifactModel? MavenArtifact { get; set; }

		public Dictionary<string, string> Metadata { get; set; } = new Dictionary<string, string>();

		// Gets the version string needed for a NuGet package dependency, which we adjust to allow floating revisions
		public string GetPackageVersionString ()
		{
			var mavenVersion = MavenArtifact!.MavenArtifactVersion!;
			var nugetVersion = NuGetVersion!;

			// If this isn't an exact version we don't use this code
			if (!mavenVersion.StartsWith ('[') || !mavenVersion.EndsWith (']') || mavenVersion.Contains (','))
				return nugetVersion;

			// An exact version is requested like "1.2.0", however we want to let the revision (4th NuGet number) float,
			// so that our updates that don't change the Java artifact can still be used.
			// That is, if the POM specifies "1.2.0" and the dependency NuGet is already "1.2.0.4", we want to allow:
			// 1.2.0.4 >= x < 1.2.1
			// NuGet expresses that as "[1.2.0.4, 1.2.1)", so that's what we need to create.
			var lower_bound = nugetVersion;

			var nuget_first = 0;
			var nuget_second = 0;
			var nuget_third = 0;

			var nuget_parts = nugetVersion.Split ('.');

			if (nuget_parts.Length > 0 && int.TryParse (nuget_parts [0], out var p1))
				nuget_first = p1;

			if (nuget_parts.Length > 1 && int.TryParse (nuget_parts [1], out var p2))
				nuget_second = p2;

			if (nuget_parts.Length > 2 && int.TryParse (nuget_parts [2], out var p3))
				nuget_third = p3;

			// Bump the third number
			nuget_third++;

			var upper_bound = $"{nuget_first}.{nuget_second}.{nuget_third}";

			// Put it all together
			return $"[{lower_bound}, {upper_bound})";
		}

		// Gets the version string needed for a project dependency, which we adjust to allow floating revisions
		public string? GetProjectVersionString ()
		{
			var nugetVersion = NuGetVersion!;
			var adjusted_string = GetPackageVersionString ();

			// If nothing changed, return empty string
			if (adjusted_string == nugetVersion)
				return null;

			return adjusted_string;
		}
	}
}
