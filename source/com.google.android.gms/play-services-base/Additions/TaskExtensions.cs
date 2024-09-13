using System;
using System.Threading.Tasks;
using Android.Gms.Extensions;

namespace Android.Gms.Common
{
	public partial class GoogleApiAvailability
	{
		public Task CheckApiAvailabilityAsync(Apis.GoogleApi apiClient, Apis.GoogleApi[] apis)
		{
			return CheckApiAvailability(apiClient, apis).AsAsync();
		}

	}
}
