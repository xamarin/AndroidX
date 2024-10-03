using System;
using System.Threading.Tasks;
using Android.Gms.Extensions;

namespace Android.Gms.InstantApp
{
	public partial class InstantAppsClient
	{
        [Obsolete]
        public Android.Gms.Tasks.Task InstantAppDate { get { return GetInstantAppData (); } }
		public Task<Android.OS.ParcelFileDescriptor> GetInstantAppDataAsync ()
		{
			return GetInstantAppData().AsAsync<Android.OS.ParcelFileDescriptor>();
		}
	}
}
