using Mono.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.AndroidX.Migration;

namespace AndroidXMigrator
{
	public class CecilfyCommand : BaseCommand
	{
		private bool skipEmbeddedResources;
		private bool renameTypes;

		public CecilfyCommand()
			: base("cecilfy", "Migrates a .NET assembly to AndroidX.")
		{
		}

		public Dictionary<string, string> Assemblies { get; } = new Dictionary<string, string>();

		public string JavaPath { get; set; } = "java";

		protected override OptionSet OnCreateOptions() => new OptionSet
		{
			{ "a|assembly=", "One or more assemblies to cecilfy", v => AddAssembly(v) },
			{ "skip-embedded", "Do not Jetify the embedded resources", v => skipEmbeddedResources = true },
			{ "rename-types", "Rename the types inside the assembly (INTERNAL)", v => renameTypes = true },
			{ "java=", "The path to the Java executable", v => JavaPath = v },
		};

		protected override bool OnValidateArguments(IEnumerable<string> extras)
		{
			var hasError = false;

			if (Assemblies.Count == 0)
			{
				Console.Error.WriteLine($"{Program.Name}: At least one assembly is required `--assembly=PATH` or `--assembly=PATH|OUTPUT` or `--assembly=PATH=OUTPUT`.");
				hasError = true;
			}

			var missing = Assemblies.Keys.Where(i => !File.Exists(i));
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
			var assemblyPairs = Assemblies.Select(a => new MigrationPair(a.Key, a.Value)).ToArray();

			var migrator = new CecilMigrator
			{
				Verbose = Program.Verbose,
				SkipEmbeddedResources = skipEmbeddedResources,
				RenameTypes = renameTypes,
				JavaPath = JavaPath,
			};

			migrator.MessageLogged += (sender, e) => LogToolMessage(e);

			migrator.Migrate(assemblyPairs);

			return true;
		}

		private void AddAssembly(string assembly)
		{
			if (string.IsNullOrWhiteSpace(assembly))
				return;

			var parts = assembly.Split('|', '=');

			if (parts.Length < 1)
				return;

			var input = parts[0];
			var output = parts.Length == 1 ? input : parts[1];

			Assemblies.Add(input, output);
		}
	}
}
