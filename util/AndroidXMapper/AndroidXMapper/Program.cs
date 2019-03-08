using Mono.Options;

namespace AndroidXMapper
{
	public class Program
	{
		public const string Name = "androidxmapper";

		public static bool Verbose;

		static int Main(string[] args)
		{
			var commands = new CommandSet(Name)
			{
				$"usage: {Name} COMMAND [OPTIONS]",
				"",
				"A utility that helps create the Android.Support to AndroidX mapping file.",
				"",
				"Global options:",
				{ "v|verbose", "Use a more verbose output", _ => Verbose = true },
				"",
				"Available commands:",
				new GenerateCommand(),
				new MergeCommand(),
			};
			return commands.Run(args);
		}
	}
}
