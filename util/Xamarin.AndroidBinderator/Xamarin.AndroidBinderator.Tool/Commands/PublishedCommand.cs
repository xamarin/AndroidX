using System;
using System.CommandLine;
using System.Linq;
using System.Threading.Tasks;
using AndroidBinderator;

namespace Xamarin.AndroidBinderator.Tool;

static class PublishedCommand
{
	public static Command Build ()
	{
		var update_command = new Command ("published", "Shows which NuGet package versions in a config.json have been published to NuGet.org.");

		var config_file_option = new Option<string> (["--config-file", "-c", "-config="], "JSON config file") { IsRequired = true };

		update_command.Add (config_file_option);

		update_command.SetHandler (
			RunPublishedCommand,
			config_file_option
		);

		return update_command;
	}

	static async Task RunPublishedCommand (string configFile)
	{
		var config = await BindingConfig.Load (configFile);

		var column1 = "Package".PadRight (58);
		var column2 = "Version".PadRight (17);
		var column3 = "Status".PadRight (15);

		Console.WriteLine ($"| {column1} | {column2} | {column3} |");
		Console.WriteLine ("|------------------------------------------------------------|-------------------|-----------------|");

		foreach (var art in config.MavenArtifacts.Where (a => !a.DependencyOnly)) {
			if (art.NugetPackageId is null || art.NugetVersion is null)
				continue;

			var status = (await ConfigUpdater.DoesNuGetPackageAlreadyExist (art.NugetPackageId, art.NugetVersion)) ? "Published" : "Not Published";
			Console.WriteLine ($"| {art.NugetPackageId.PadRight (58)} | {art.NugetVersion.PadRight (17)} | {status.PadRight (15)} |");
		}
	}
}
