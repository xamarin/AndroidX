using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using AndroidBinderator;
using Newtonsoft.Json;

namespace Xamarin.AndroidBinderator.Tool;

static class BinderateCommand
{
	public static Command Build ()
	{
		var binderate_command = new Command ("binderate", "Run the binderator process.");

		var config_file_option = new Option<string []> (["--config-file", "-c", "-config="], "JSON config file(s)") { AllowMultipleArgumentsPerToken = true, IsRequired = true };
		var base_dir_option = new Option<string?> (["--base-path", "-b", "-basepath="], "Default base path");

		binderate_command.Add (config_file_option);
		binderate_command.Add (base_dir_option);

		binderate_command.SetHandler (
			RunBinderateVerb,
			config_file_option, base_dir_option
		);

		return binderate_command;
	}

	public static async Task RunBinderateVerb (string [] configFiles, string? basePath)
	{
		Console.WriteLine ("Arguments:");

		foreach (var c in configFiles)
			Console.WriteLine ($"- Config File: {c}");
		Console.WriteLine ($"- Default Base Path: {basePath}");
		Console.WriteLine ();

		basePath ??= "AppDomain.CurrentDomain.BaseDirectory";

		try {
			foreach (var config in configFiles) {
				var cfgs = JsonConvert.DeserializeObject<List<BindingConfig>> (File.ReadAllText (config));

				foreach (var c in cfgs ?? []) {
					if (string.IsNullOrEmpty (c.BasePath))
						c.BasePath = basePath;

					await Engine.BinderateAsync (c);
				}
			}
		} catch (AggregateException exc_a) {
			var sb = new StringBuilder ();

			sb.AppendLine ();
			sb.AppendLine ($"Dependency errors : {exc_a.InnerExceptions.Count}");

			var i = 1;

			foreach (var exc in exc_a.InnerExceptions) {
				sb.AppendLine ($"{i}");
				sb.AppendLine ($"	{exc.ToString ()}");
				i++;
			}

			Trace.WriteLine (sb.ToString ());
		}
	}
}
