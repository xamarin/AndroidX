using System;
using System.Collections.Generic;

namespace AndroidBinderator
{
	public class BindingProjectModel
	{
		public string Id { get; private set; } = Guid.NewGuid().ToString().ToUpperInvariant();

		public string? Name { get; set; }

		public string? MavenGroupId { get; set; }

		public List<MavenArtifactModel> MavenArtifacts { get; set; } = new List<MavenArtifactModel>();

		public string? NuGetPackageId { get; set; }
		public string? NuGetVersionBase { get; set; }
		public string? NuGetVersionSuffix { get; set; }

		public string? NuGetVersion =>
			string.IsNullOrWhiteSpace(NuGetVersionSuffix)
				? NuGetVersionBase
				: NuGetVersionBase + NuGetVersionSuffix;

		public string? AssemblyName { get; set; }

		public List<NuGetDependencyModel> NuGetDependencies { get; set; } = new List<NuGetDependencyModel>();

		public List<string> ProjectReferences { get; set; } = new List<string>();

		public Dictionary<string, string> Metadata { get; set; } = new Dictionary<string, string>();

		public BindingConfig? Config { get; set; }

		public string? MavenDescription { get; set; }
		public string? MavenUrl { get; set; }
		public string? JavaSourceRepository { get; set; }

		public List<MavenArtifactLicense> Licenses { get; } = new List<MavenArtifactLicense> ();

		public List<MavenArtifactDeveloper> Developers { get; } = new List<MavenArtifactDeveloper> ();
	}

	public class MavenArtifactLicense
	{
		public string Name { get; set; }
		public string Url { get; set; }

		public MavenArtifactLicense (string name, string url)
		{
			Name = name;
			Url = url;
		}

		public string GetSpdxExpression ()
		{
			switch (Name) {
				case "The Apache Software License, Version 2.0":
				case "Apache License, Version 2.0":
				case "The Apache License, Version 2.0":
				case "Apache-2.0":
				case "Apache 2.0":
					return "Apache-2.0";
				case "BSD License":
					return "BSD-3-Clause";
				case "The MIT License":
					return "MIT";
				case "MIT-0":
					return "MIT-0";
				case "SIL Open Font License, Version 1.1":
					return "OFL-1.1";
				case "Unicode, Inc. License":
					return "Unicode-3.0";
				case "Android Software Development Kit License":
					return "";
			}

			throw new ArgumentException ($"Unknown license: '{Name}', '{Url}'");
		}
	}

	public class MavenArtifactDeveloper
	{
		public string Name { get; set; }

		public MavenArtifactDeveloper (string name)
		{
			Name = name;
		}
	}
}
