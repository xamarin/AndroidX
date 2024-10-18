using System;
using System.Collections.Generic;

namespace AndroidBinderator;

static class BindingProjectConsistencyVerifier
{
	public static void Verify (List<BindingProjectModel> artifacts)
	{
		var exceptions = new List<Exception> ();

		foreach (var artifact in artifacts)
			EnsureVersionsMatch (artifact, exceptions);

		if (exceptions.Count > 0)
			throw new AggregateException (exceptions);
	}

	// Ensure our NuGet major/minor/patch versions match the Java versions
	// ie: Java = 1.2.3, NuGet = 1.2.3.9
	// ie: Java = 1.2.3, NuGet = 101.2.3.9  (GPS)
	static void EnsureVersionsMatch (BindingProjectModel projectModel, List<Exception> exceptions)
	{
		var java_version = Extensions.GetThreePartVersionAsIntegers (projectModel.GetArtifactVersion ());
		var nuget_version = Extensions.GetThreePartVersionAsIntegers (projectModel.NuGetVersionBase ?? throw new ArgumentException ("Null NuGet Version"));

		if (java_version == nuget_version)
			return;

		// GPS check
		java_version.x += 100;

		if (java_version == nuget_version)
			return;

		java_version.x -= 100;

		exceptions.Add (new Exception ($"Version mismatch for {projectModel.NuGetPackageId}: Java={java_version}, NuGet={nuget_version}"));
	}
}
