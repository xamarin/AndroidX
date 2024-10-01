using System;
using System.Threading.Tasks;
using Android.Gms.Common.Apis;
using System.Collections.Generic;
using Android.Runtime;

namespace Android.Gms.Location
{
    public static partial class IActivityRecognitionApiExtensions
    {
        public static async Task<Statuses> RemoveActivityUpdatesAsync (this IActivityRecognitionApi api, GoogleApiClient client, Android.App.PendingIntent callbackIntent)
        {
            return (await api.RemoveActivityUpdates (client, callbackIntent)).JavaCast<Statuses> ();
        }

        public static async Task<Statuses> RequestActivityUpdatesAsync (this IActivityRecognitionApi api, GoogleApiClient client, long detectionIntervalMillis, Android.App.PendingIntent callbackIntent)
        {
            return (await api.RequestActivityUpdates (client, detectionIntervalMillis, callbackIntent)).JavaCast<Statuses> ();
        }
    }

    public static partial class IFusedLocationProviderApiExtensions
    {
        public static async Task<Statuses> RemoveLocationUpdatesAsync (this IFusedLocationProviderApi api, GoogleApiClient client, Android.App.PendingIntent callbackIntent)
        {
            return (await api.RemoveLocationUpdates (client, callbackIntent)).JavaCast<Statuses> ();
        }

        public static async Task<Statuses> RemoveLocationUpdatesAsync (this IFusedLocationProviderApi api, GoogleApiClient client, LocationCallbackBase callback)
        {
            return (await api.RemoveLocationUpdates (client, callback)).JavaCast<Statuses> ();
        }

        public static async Task<Statuses> RemoveLocationUpdatesAsync (this IFusedLocationProviderApi api, GoogleApiClient client, ILocationListener listener)
        {
            return (await api.RemoveLocationUpdates (client, listener)).JavaCast<Statuses> ();
        }

        public static async Task<Statuses> RequestLocationUpdatesAsync (this IFusedLocationProviderApi api, GoogleApiClient client, LocationRequest request, Android.App.PendingIntent callbackIntent)
        {
            return (await api.RequestLocationUpdates (client, request, callbackIntent)).JavaCast<Statuses> ();
        }

        public static async Task<Statuses> RequestLocationUpdatesAsync (this IFusedLocationProviderApi api, GoogleApiClient client, LocationRequest request, LocationCallbackBase callback, Android.OS.Looper looper)
        {
            return (await api.RequestLocationUpdates (client, request, callback, looper)).JavaCast<Statuses> ();
        }

        public static async Task<Statuses> RequestLocationUpdatesAsync (this IFusedLocationProviderApi api, GoogleApiClient client, LocationRequest request, ILocationListener listener)
        {
            return (await api.RequestLocationUpdates (client, request, listener)).JavaCast<Statuses> ();
        }

        public static async Task<Statuses> RequestLocationUpdatesAsync (this IFusedLocationProviderApi api, GoogleApiClient client, LocationRequest request, ILocationListener listener, Android.OS.Looper looper)
        {
            return (await api.RequestLocationUpdates (client, request, listener, looper)).JavaCast<Statuses> ();
        }

        public static async Task<Statuses> SetMockLocationAsync (this IFusedLocationProviderApi api, GoogleApiClient client, global::Android.Locations.Location mockLocation)
        {
            return (await api.SetMockLocation (client, mockLocation)).JavaCast<Statuses> ();
        }

        public static async Task<Statuses> SetMockModeAsync (this IFusedLocationProviderApi api, GoogleApiClient client, bool isMockMode)
        {
            return (await api.SetMockMode (client, isMockMode)).JavaCast<Statuses> ();
        }
    }

    public static partial class IGeofencingApiExtensions
    {
        public static async Task<Statuses> AddGeofencesAsync (this IGeofencingApi api, GoogleApiClient client, GeofencingRequest geofencingRequest, Android.App.PendingIntent pendingIntent)
        {
            return (await api.AddGeofences (client, geofencingRequest, pendingIntent)).JavaCast<Statuses> ();
        }

        [Obsolete ("Use overload with GeofencingRequest parameter instead")]
        public static async Task<Statuses> AddGeofencesAsync (this IGeofencingApi api, GoogleApiClient client, IList<IGeofence> geofences, Android.App.PendingIntent pendingIntent)
        {
            return (await api.AddGeofences (client, geofences, pendingIntent)).JavaCast<Statuses> ();
        }

        public static async Task<Statuses> RemoveGeofencesAsync (this IGeofencingApi api, GoogleApiClient client, Android.App.PendingIntent pendingIntent)
        {
            return (await api.RemoveGeofences (client, pendingIntent)).JavaCast<Statuses> ();
        }

        public static async Task<Statuses> RemoveGeofencesAsync (this IGeofencingApi api, GoogleApiClient client, IList<string> geofenceRequestIds)
        {
            return (await api.RemoveGeofences (client, geofenceRequestIds)).JavaCast<Statuses> ();
        }
    }

    public static partial class ISettingsApiExtensions
    {
        public static async Task<LocationSettingsResult> CheckLocationSettingsAsync (this ISettingsApi api, GoogleApiClient client, LocationSettingsRequest request)
        {
            return (await api.CheckLocationSettings (client, request)).JavaCast<Android.Gms.Location.LocationSettingsResult> ();
        }
    }
}
