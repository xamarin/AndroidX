using System;
using System.Threading.Tasks;
using Android.Gms.Extensions;

namespace Android.Gms.Location
{
	public partial interface IFusedLocationProviderClient
	{
        [Obsolete]
        public Android.Gms.Tasks.Task LastLocation { get { return GetLastLocation (); } }
		public Task<Android.Locations.Location> GetLastLocationAsync ()
		{
			return GetLastLocation().AsAsync<Android.Locations.Location>();
		}

        [Obsolete]
        public Android.Gms.Tasks.Task LocationAvailability { get { return GetLocationAvailability (); } }
		public Task<Android.Gms.Location.LocationAvailability> GetLocationAvailabilityAsync()
		{
			return GetLocationAvailability().AsAsync<Android.Gms.Location.LocationAvailability>();
		}

		public Task FlushLocationsAsync ()
		{
			return FlushLocations().AsAsync();
		}

		public Task RemoveLocationUpdatesAsync (LocationCallback callback)
		{
			return RemoveLocationUpdates(callback).AsAsync();
		}

		public Task RemoveLocationUpdatesAsync(Android.App.PendingIntent pendingIntent)
		{
			return RemoveLocationUpdates(pendingIntent).AsAsync();
		}

		public Task RequestLocationUpdatesAsync (LocationRequest locationRequest, LocationCallback callback, Android.OS.Looper looper = null)
		{
			return RequestLocationUpdates(locationRequest, callback, looper).AsAsync(); ;
		}

		public Task RequestLocationUpdatesAsync(LocationRequest locationRequest, Android.App.PendingIntent pendingIntent)
		{
			return RequestLocationUpdates(locationRequest, pendingIntent).AsAsync(); ;
		}

		public Task SetMockLocationAsync (Android.Locations.Location location)
		{
			return SetMockLocation(location).AsAsync();
		}

		public Task SetMockModeAsync(bool mock)
		{
			return SetMockMode(mock).AsAsync();
		}
	}

	public partial interface IGeofencingClient
	{
		public Task AddGeofencesAsync (GeofencingRequest geofenceRequest, Android.App.PendingIntent pendingIntent)
		{
			return AddGeofences(geofenceRequest, pendingIntent).AsAsync();
		}

		public Task RemoveGeofencesAsync(Android.App.PendingIntent pendingIntent)
		{
			return RemoveGeofences(pendingIntent).AsAsync();
		}

		public Task RemoveGeofencesAsync(System.Collections.Generic.IList<string> geofenceRequestIds)
		{
			return RemoveGeofences(geofenceRequestIds).AsAsync();
		}
	}

	public partial interface ISettingsClient
	{
		public Task<LocationSettingsResponse> CheckLocationSettingsAsync (LocationSettingsRequest locationSettings)
		{
			return CheckLocationSettings(locationSettings).AsAsync<LocationSettingsResponse>();
		}
	}

	public partial interface IActivityRecognitionClient
	{
		public Task RemoveActivityUpdatesAsync(Android.App.PendingIntent callbackIntent)
		{
			return RemoveActivityUpdates(callbackIntent).AsAsync();
		}

		public Task RequestActivityUpdatesAsync(long detectionIntervalMillis, Android.App.PendingIntent callbackIntent)
		{
			return RequestActivityUpdates(detectionIntervalMillis, callbackIntent).AsAsync();
		}
	}
}
