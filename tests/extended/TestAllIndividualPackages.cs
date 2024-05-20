using System.Text;
using CliWrap;
using CliWrap.Buffered;
using NUnit.Framework;

namespace ExtendedTests;

[TestFixture]
public class TestAllIndividualPackages
{
	static string base_dir = "";
	static string test_dir = @"output\tests";
	static string configuration = "Release";
	static string platform_version = "28";
	static string net_version = "net7.0";

	static TestAllIndividualPackages ()
	{
		// Find the repo base directory
		while (!File.Exists (Path.Combine (base_dir, "config.json")))
			base_dir = Path.Combine ("..", base_dir);

		// Create the test directory
		Directory.CreateDirectory (Path.Combine (base_dir, test_dir));

		// We need an empty Directory.Build.props file so we don't use the root one
		var directory_props = Path.Combine (base_dir, test_dir, "Directory.Build.props");

		if (!File.Exists (directory_props))
			File.WriteAllText (directory_props, "<Project />");

		// Set up a NuGet.config file to force using the locally built NuGet packages
		var nuget_config_src = Path.Combine (base_dir, "samples", "NuGet.config");
		var nuget_config_dst = Path.Combine (base_dir, test_dir, "NuGet.config");

		if (!File.Exists (nuget_config_dst)) {
			var contents = File.ReadAllText (nuget_config_src);
			contents = contents.Replace ("../output", "..");
			contents = contents.Replace ("../packages", "packages");
			File.WriteAllText (nuget_config_dst, contents);
		}
	}

	//[Test]
	//[TestCaseSource (nameof (GetPackagesToTest))]
	//public Task TestAndroidDotNetPackage (string id, string version)
	//	=> TestPackage (id, version, "android");

	[Test]
	[TestCaseSource (nameof (GetPackagesToTest))]
	public Task TestMauiPackage (string id, string version)
		=> TestPackage (id, version, "maui");

	public static object [] GetPackagesToTest ()
	{
		var config_file = Path.Combine (base_dir, "config.json");
		var config = BinderatorConfigFileParser.ParseConfigurationFile (config_file).Result;

		return config.FirstOrDefault ()?.Artifacts?.Where (a => !a.DependencyOnly).Select (a => new object [] { a.NugetId, a.NugetVersion }).ToArray () ?? Array.Empty<object> ();
	}

	async Task TestPackage (string id, string version, string template)
	{
		var case_dir = Path.Combine (base_dir, test_dir, template, $"{id}Test");

		// Test the package
		if (Directory.Exists (case_dir))
			Directory.Delete (case_dir, true);

		Directory.CreateDirectory (case_dir);

		// Create new dotnet project
		await RunAndAssertSuccess ($"new {template}", case_dir);

		// - Replace <SupportedOSPlatformVersion> with the maximum version some packages require
		// - Remove the target frameworks that are not 'android'
		var proj_file = Directory.GetFiles (case_dir, "*.csproj").FirstOrDefault ();

		if (proj_file is not null) {
			ReplaceInFile (proj_file, ">21</SupportedOSPlatformVersion>", $">{platform_version}</SupportedOSPlatformVersion>");
			ReplaceInFile (proj_file, ">21.0</SupportedOSPlatformVersion>", $">{platform_version}</SupportedOSPlatformVersion>");
			ReplaceInFile (proj_file, $";{net_version}-ios", "");
			ReplaceInFile (proj_file, $";{net_version}-maccatalyst", "");
			ReplaceInFile (proj_file, $";{net_version}-windows10.0.19041.0", "");
		}

		// Add the package
		await RunAndAssertSuccess ($"add package {id} --version {version}", case_dir);

		// Build the project
		await RunAndAssertSuccess ($"build -c {configuration} -bl", case_dir, true);

		// If we're here, everything succeeded, so try to clean up the project directory
		try {
			Directory.Delete (case_dir, true);
		} catch {
			// Ignore
		}
	}

	static void ReplaceInFile (string filename, string oldValue, string newValue)
	{
		var contents = File.ReadAllText (filename);
		contents = contents.Replace (oldValue, newValue);
		File.WriteAllText (filename, contents);
	}

	static async Task RunAndAssertSuccess (string arguments, string workingDir, bool isMSBuild = false)
	{
		var result = await Cli.Wrap ("dotnet")
			.WithArguments (arguments)
			.WithWorkingDirectory (workingDir)
			.WithValidation (CommandResultValidation.None)
			.ExecuteBufferedAsync ();

		if (result.ExitCode == 0)
			return;

		var sb = new StringBuilder ();

		sb.AppendLine ($"Command '{arguments}' failed with exit code {result.ExitCode}.");

		if (!isMSBuild) {
			sb.AppendLine ("Output:");
			sb.AppendLine (result.StandardOutput);
			sb.AppendLine ();
			sb.AppendLine ("Error:");
			sb.AppendLine (result.StandardError);

			Assert.Fail (sb.ToString ());
		}

		var errors = new List<string> ();
		var warnings = new List<string> ();

		using (var sr = new StringReader (result.StandardOutput)) {
			string? line;

			while ((line = sr.ReadLine ()) != null) {

				// MSBuild prints all the messages out again after this message
				if (line == "Build succeeded." || line == "Build FAILED.")
					break;

				if (CanonicalError.Parse (line) is CanonicalError.Parts parts) {
					var message = $"{parts.code}: {parts.text}";

					if (parts.category == CanonicalError.Parts.Category.Warning)
						warnings.Add (message);
					else
						errors.Add (message);
				}
			}
		}

		if (errors.Count > 0) {
			sb.AppendLine ("Errors:");
			errors.ForEach (e => sb.AppendLine (e));
		}

		if (warnings.Count > 0) {
			sb.AppendLine ("Warnings:");
			warnings.ForEach (w => sb.AppendLine (w));
		}

		Assert.Fail (sb.ToString ());
	}
}
