using System.CommandLine;
using System.Threading.Tasks;
using AndroidBinderator;

namespace Xamarin.AndroidBinderator.Tool;

static class SortCommand
{
	public static Command Build ()
	{
		var update_command = new Command ("sort", "Sorts a config.json file using the canonical sort.");

		var config_file_option = new Option<string> (["--config-file", "-c", "-config="], "JSON config file") { IsRequired = true };

		update_command.Add (config_file_option);

		update_command.SetHandler (
			RunSortCommand,
			config_file_option
		);

		return update_command;
	}

	static async Task RunSortCommand (string configFile)
	{
		// BindingConfig.Load automatically sorts the file, so we just need to write the file back to disk
		var config = await BindingConfig.Load (configFile);

		config.Save (configFile);
	}
}
