using System;
using System.CommandLine;
using System.Linq;
using System.Threading.Tasks;
using AndroidBinderator;

namespace Xamarin.AndroidBinderator.Tool;

static class UpdateCommand
{
	public static Command Build ()
	{
		var update_command = new Command ("update", "Updates a config.json to the latest versions found in Maven.");

		var config_file_option = new Option<string> (["--config-file", "-c", "-config="], "JSON config file") { IsRequired = true };
		var dependency_file_option = new Option<string []> (["--dependency-file", "-d"], "Dependency JSON config file") { AllowMultipleArgumentsPerToken = true };

		update_command.Add (config_file_option);
		update_command.Add (dependency_file_option);

		update_command.SetHandler (
			RunUpdateCommand,
			config_file_option,
			dependency_file_option
		);

		return update_command;
	}

	static async Task RunUpdateCommand (string configFile, string [] dependencyFiles)
	{
		var config = await BindingConfig.Load (configFile);

		await ConfigUpdater.Update (config, dependencyFiles.ToList ());

		OutputArtifactTable (config);
		Console.WriteLine ();
		OutputDependencyTable (config);

		// Write updated values back to original locations so they get serialized
		foreach (var a in config.MavenArtifacts) {
			a.Version = a.LatestVersion;
			a.NugetVersion = a.LatestNuGetVersion;
		}

		config.Save (configFile);
	}

	static void OutputArtifactTable (BindingConfig config)
	{
		var column1 = "Package (* = Has Update)".PadRight (58);
		var column2 = "Currently Bound".PadRight (17);
		var column3 = "Latest Stable".PadRight (15);

		Console.WriteLine ($"| {column1} | {column2} | {column3} |");
		Console.WriteLine ("|------------------------------------------------------------|-------------------|-----------------|");

		foreach (var art in config.MavenArtifacts.Where (a => !a.DependencyOnly)) {
			var package_name = $"{art.GroupId}.{art.ArtifactId}";

			if (art.NewVersionAvailable)
				package_name = "* " + package_name;

			if (art.Frozen)
				package_name = "# " + package_name;

			Console.WriteLine ($"| {package_name.PadRight (58)} | {art.Version.PadRight (17)} | {art.LatestVersion.PadRight (15)} |");
		}
	}

	static void OutputDependencyTable (BindingConfig config)
	{
		var column1 = "Dependencies (* = Has Update)".PadRight (58);
		var column2 = "Current Reference".PadRight (17);
		var column3 = "Latest Publish".PadRight (15);

		Console.WriteLine ($"| {column1} | {column2} | {column3} |");
		Console.WriteLine ("|------------------------------------------------------------|-------------------|-----------------|");

		foreach (var art in config.MavenArtifacts.Where (a => a.DependencyOnly)) {
			var package_name = art.NugetPackageId ?? $"{art.GroupId}.{art.ArtifactId}";

			if (art.NewNuGetVersionAvailable)
				package_name = "* " + package_name;

			Console.WriteLine ($"| {package_name.PadRight (58)} | {art.NugetVersion.OrEmpty ().PadRight (17)} | {art.LatestNuGetVersion.PadRight (15)} |");
		}
	}
}
