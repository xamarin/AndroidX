using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Xamarin.AndroidX.Migration.BuildTasks
{
	public class CollectAllFiles : Task
	{
		[Required]
		public ITaskItem[] Directories { get; set; }

		[Output]
		public ITaskItem[] OutputFiles { get; set; }

		public override bool Execute()
		{
			var output = new List<ITaskItem>();

			foreach (var directory in Directories)
			{
				if (!Directory.Exists(directory.ItemSpec))
					continue;

				var files = Directory.EnumerateFiles(directory.ItemSpec, "*.*", SearchOption.AllDirectories);

				var taskItems = files.Select(f => 
				{
					var item = new TaskItem(f, new Dictionary<string, string>
					{
						{ "OriginalDirectory", directory.ItemSpec},
					});
					directory.CopyMetadataTo(item);
					return item;
				});

				output.AddRange(taskItems);
			}

			OutputFiles = output.ToArray();

			return true;
		}
	}
}
