using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mono.Options;

namespace Xamarin.AndroidBinderator.Tool;

class LegacyCommandLine
{
	public static async Task Run (string [] args)
	{
		var configs = new List<string> ();
		string? basePath = null;
		var shouldShowHelp = false;

		// thses are the available options, not that they set the variables
		var options = new OptionSet {
			{ "c|config=", "JSON Config File.", configs.Add },
			{ "b|basepath=", "Default Base Path.", (string b) => basePath= b },
			{ "h|help", "show this message and exit", h => shouldShowHelp = h != null },
		};

		List<string> extra;

		try {
			// parse the command line
			extra = options.Parse (args);
		} catch (OptionException e) {
			// output some error message
			Console.Write ("android-binderator: ");
			Console.WriteLine (e.Message);
			Console.WriteLine ("Try `android-binderator --help' for more information.");
			return;
		}

		if (shouldShowHelp) {
			options.WriteOptionDescriptions (Console.Out);
			return;
		}

		await BinderateCommand.RunBinderateVerb (configs.ToArray (), basePath);
	}
}
