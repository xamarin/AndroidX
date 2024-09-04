using System;
using System.Threading.Tasks;
using Android.Gms.Extensions;

namespace Android.Gms.Cast
{
	public partial class CastRemoteDisplayClient
	{
		public Task<Android.Views.Display> StartRemoteDisplayAsync(CastDevice castDevice, string applicationId, int configPreset, Android.App.PendingIntent sessionEndedPendingIntent)
		{
			return StartRemoteDisplay(castDevice, applicationId, configPreset, sessionEndedPendingIntent).AsAsync<Android.Views.Display>();
		}

		public Task StopRemoteDisplayAsync()
		{
			return StopRemoteDisplay().AsAsync();
		}
	}
}
