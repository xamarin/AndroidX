using System;
using Android.Gms.Common.Apis;

namespace Android.Gms.Location
{
    public partial class ActivityRecognition
    {
        [Obsolete ("Use API instead")]
        public static Android.Gms.Common.Apis.Api Api {
            get { return ActivityRecognition.API; }
        }
    }

    public partial class LocationServices
    {
        [Obsolete ("Use API instead")]
        public static Android.Gms.Common.Apis.Api Api {
            get { return LocationServices.API; }
        }
    }


    public static class IFusedLocationApiProviderExtensions
    {
        public static PendingResult RequestLocationUpdates (this IFusedLocationProviderApi p, GoogleApiClient googleApiClient, LocationRequest locationRequest, LocationListener listener)
        {
            return p.RequestLocationUpdates (googleApiClient, locationRequest, listener);
        }
    }

    public class LocationListener : Java.Lang.Object, ILocationListener
    {        
        public delegate void LocationChangedDelegate (Android.Locations.Location location);
        public event LocationChangedDelegate LocationChanged;

        public void OnLocationChanged (Android.Locations.Location location)
        {
            var evt = LocationChanged;
            if (evt != null)
                evt (location);
        }
    }

	public class LocationCallbackResultEventArgs : EventArgs
	{
		public LocationCallbackResultEventArgs (LocationResult result)
		{
			Result = result;
		}
		public LocationResult Result { get; private set; }
	}

	public class LocationCallbackAvailabilityEventArgs : EventArgs
	{
		public LocationCallbackAvailabilityEventArgs(LocationAvailability availability)
		{
			Availability = availability;
		}
		public LocationAvailability Availability { get; private set; }
	}

	public class LocationCallback : LocationCallbackBase
	{
		public event EventHandler<LocationCallbackResultEventArgs> LocationResult;
		public event EventHandler<LocationCallbackAvailabilityEventArgs> LocationAvailability;

		public override void OnLocationResult(LocationResult result)
		{
			base.OnLocationResult(result);
			LocationResult?.Invoke(this, new LocationCallbackResultEventArgs(result));
		}

		public override void OnLocationAvailability (LocationAvailability locationAvailability)
		{
			base.OnLocationAvailability(locationAvailability);
			LocationAvailability?.Invoke(this, new LocationCallbackAvailabilityEventArgs(locationAvailability));
		}
	}
}

