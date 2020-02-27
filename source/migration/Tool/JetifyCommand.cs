using Mono.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.AndroidX.Migration;

namespace AndroidXMigrator
{
	public class JetifyCommand : BaseCommand
	{
		public JetifyCommand()
			: base("jetify", "Migrates a Java .aar or .jar file to AndroidX.")
		{
		}

		public Dictionary<string, string> Archives { get; } = new Dictionary<string, string>();

		public string JavaPath { get; set; } = "java";

		public bool Parallel { get; set; }

		public bool UseIntermediateFile { get; set; }

		protected override OptionSet OnCreateOptions() => new OptionSet
		{
			{ "a|archive=", "One or more .jar/.aar files to jetify", v => AddArchive(v) },
			{ "java=", "The path to the Java executable", v => JavaPath = v },
			{ "parallel", "Execute in parallel", v => Parallel = true },
			{ "intermediate", "Use an intermediate file (for long paths)", v => UseIntermediateFile = true },
		};

		protected override bool OnValidateArguments(IEnumerable<string> extras)
		{
			var hasError = false;

			if (Archives.Count == 0)
			{
				Console.Error.WriteLine($"{Program.Name}: At least one archive is required `--archive=PATH` or `--archive=PATH|OUTPUT` or `--archive=PATH=OUTPUT`.");
				hasError = true;
			}

			var missing = Archives.Keys.Where(i => !File.Exists(i));
			if (missing.Any())
			{
				foreach (var file in missing)
					Console.Error.WriteLine($"{Program.Name}: File does not exist: `{file}`.");
				hasError = true;
			}

			return !hasError;
		}

		protected override bool OnInvoke(IEnumerable<string> extras)
		{
			var archivePairs = Archives.Select(a => new MigrationPair(a.Key, a.Value)).ToArray();

			var jetifier = new Jetifier
			{
				Verbose = Program.Verbose,
				JavaPath = JavaPath,
				Parallel = Parallel,
				UseIntermediateFile = UseIntermediateFile,
			};

			jetifier.MessageLogged += (sender, e) => LogToolMessage(e);

			return jetifier.Jetify(archivePairs);
		}

		private void AddArchive(string archive)
		{
			if (string.IsNullOrWhiteSpace(archive))
				return;

			var parts = archive.Split('|', '=');

			if (parts.Length < 1)
				return;

			var input = parts[0];
			var output = parts.Length == 1 ? input : parts[1];

			Archives.Add(input, output);
		}
	}
}
