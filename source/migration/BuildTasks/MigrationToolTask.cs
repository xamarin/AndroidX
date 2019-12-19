using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Xamarin.AndroidX.Migration.BuildTasks
{
	public abstract class MigrationToolTask : Task
	{
		protected void LogToolMessage(MessageLoggedEventArgs e)
		{
			if (e.Exception != null)
				Log.LogErrorFromException(e.Exception);
			else if (e.IsError)
				Log.LogError(e.Message);
			else if (e.IsVerbose)
				Log.LogMessage(MessageImportance.Low, e.Message);
			else
				Log.LogMessage(e.Message);
		}
	}
}
