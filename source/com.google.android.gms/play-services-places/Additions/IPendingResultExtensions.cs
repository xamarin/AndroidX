using System;
using System.Threading.Tasks;
using Android.Gms.Common.Apis;
using System.Collections.Generic;
using Android.Runtime;

namespace Android.Gms.Location.Places
{
    public static partial class IGeoDataApiExtensions
    {
        public static async Task<PlaceBuffer> AddPlaceAsync (this IGeoDataApi api, GoogleApiClient client, AddPlaceRequest addPlaceRequest)
        {
            return (await api.AddPlace (client, addPlaceRequest)).JavaCast<PlaceBuffer> ();
        }

        public static async Task<Android.Gms.Location.Places.AutocompletePredictionBuffer> GetAutocompletePredictionsAsync (this IGeoDataApi api, GoogleApiClient client, string query, Android.Gms.Maps.Model.LatLngBounds bounds, AutocompleteFilter filter)
        {
            return (await api.GetAutocompletePredictions (client, query, bounds, filter)).JavaCast<AutocompletePredictionBuffer> ();
        }

        public static async Task<Android.Gms.Location.Places.PlaceBuffer> GetPlaceByIdAsync (this IGeoDataApi api, GoogleApiClient client, params string [] placeIds)
        {
            return (await api.GetPlaceById (client, placeIds)).JavaCast<PlaceBuffer> ();
        }

        public static async Task<Android.Gms.Location.Places.PlacePhotoMetadataResult> GetPlacePhotosAsync (this IGeoDataApi api, GoogleApiClient client, string placeId)
        {
            return (await api.GetPlacePhotos (client, placeId)).JavaCast<PlacePhotoMetadataResult> ();
        }
    }

    public static partial class IPlaceDetectionApiExtensions
    {
        public static async Task<PlaceLikelihoodBuffer> GetCurrentPlaceAsync (this IPlaceDetectionApi api, GoogleApiClient client, PlaceFilter filter)
        {
            return (await api.GetCurrentPlace (client, filter)).JavaCast<PlaceLikelihoodBuffer> ();
        }

        public static async Task<Statuses> ReportDeviceAtPlaceAsync (this IPlaceDetectionApi api, GoogleApiClient client, PlaceReport report)
        {
            return (await api.ReportDeviceAtPlace (client, report)).JavaCast<Statuses> ();
        }
    }

    public static partial class IPlacePhotoMetadataExtensions
    {
        public static async Task<Android.Gms.Location.Places.PlacePhotoResult> GetPhotoAsync (this IPlacePhotoMetadata api, GoogleApiClient client)
        {
            return (await api.GetPhoto (client)).JavaCast<Android.Gms.Location.Places.PlacePhotoResult> ();
        }

        public static async Task<Android.Gms.Location.Places.PlacePhotoResult> GetScaledPhotoAsync (this IPlacePhotoMetadata api, GoogleApiClient client, int width, int height)
        {
            return (await api.GetScaledPhoto (client, width, height)).JavaCast<PlacePhotoResult> ();
        }
    }
}
