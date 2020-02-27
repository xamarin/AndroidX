using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Xamarin.AndroidX.Migration.BuildTasks
{
	public class CecilfyFiles : MigrationToolTask
	{
		[Required]
		public ITaskItem[] Assemblies { get; set; }

		public ITaskItem[] References { get; set; }

		public bool SkipEmbeddedResources { get; set; }

		public bool Verbose { get; set; }

		public override bool Execute()
		{
			var pairs = new List<MigrationPair>(Assemblies.Length);

			var refs = References.Select(r => r.ItemSpec).ToList();

			foreach (var file in Assemblies)
			{
				var f = file.ItemSpec;

				// create the migration pair
				pairs.Add(new MigrationPair(f, f));

				// replace the original with the migrated assembly
				refs.RemoveAll(r => Path.GetFileName(r) == Path.GetFileName(f));
				refs.Add(f);
			}

			var cecilfier = new CecilMigrator
			{
				SkipEmbeddedResources = SkipEmbeddedResources,
				References = refs,
				Verbose = Verbose
			};

			cecilfier.MessageLogged += (sender, e) => LogToolMessage(e);

			try
			{
				var result = cecilfier.Migrate(pairs);

				Log.LogMessage($"Result of cecilfication: {result}");
			}
			catch (Exception ex)
			{
				Log.LogErrorFromException(ex, true);

				return false;
			}

			return !cecilfier.HasLoggedErrors;
		}
	}
}
