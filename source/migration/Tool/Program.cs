using Mono.Options;

namespace AndroidXMigrator
{
	public class Program
	{
		public const string Name = "androidx-migrator";

		public static bool Verbose { get; private set; }

		static int Main(string[] args)
		{
			var commands = new CommandSet(Name)
			{
				$"usage: {Name} COMMAND [OPTIONS]",
				"",
				"A set of utilities that aids in the migration of assemblies, jars and aars to AndroidX.",
				"",
				"Global options:",
				{ "v|verbose", "Use a more verbose output", _ => Verbose = true },
				"",
				"Available commands:",
				new CecilfyCommand(),
				new CompareCommand(),
				new DependencyTreeCommand(),
				new GenerateCommand(),
				new JetifyCommand(),
				new MergeCommand(),
				new SearchCommand(),
			};
			return commands.Run(args);
		}
	}
}
