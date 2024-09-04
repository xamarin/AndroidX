using System;
using System.Threading.Tasks;
using Android.Gms.Common.Apis;
using Android.Runtime;
using System.Collections.Generic;

namespace Android.Gms.AppIndexing 
{
    public static partial class IAppIndexApiExtensions 
    {
        public static async Task<Statuses> EndAsync (this IAppIndexApi api, GoogleApiClient apiClient, global::Android.Gms.AppIndexing.Action action)
        {
            return (await api.End (apiClient, action)).JavaCast<Statuses> ();
        }
        public static async Task<Statuses> StartAsync (this IAppIndexApi api, GoogleApiClient apiClient, global::Android.Gms.AppIndexing.Action action) {
            return (await api.Start (apiClient, action)).JavaCast<Statuses> ();
        }
        [Obsolete]
        public static async Task<Statuses> ViewAsync (this IAppIndexApi api, GoogleApiClient apiClient, Android.App.Activity activity, Android.Content.Intent viewIntent, string title, Android.Net.Uri webUrl, IList<AppIndexApiAppIndexingLink> outLinks) {
            return (await api.View (apiClient, activity, viewIntent, title, webUrl, outLinks)).JavaCast<Statuses> ();
        }
        [Obsolete]
        public static async Task<Statuses> ViewAsync (this IAppIndexApi api, GoogleApiClient apiClient, Android.App.Activity activity, Android.Net.Uri appIndexingUrl, string title, Android.Net.Uri webUrl, IList<AppIndexApiAppIndexingLink> outLinks) {
            return (await api.View (apiClient, activity, appIndexingUrl, title, webUrl, outLinks)).JavaCast<Statuses> ();
        }
        [Obsolete]
        public static async Task<Statuses> ViewEndAsync (this IAppIndexApi api, GoogleApiClient apiClient, Android.App.Activity activity, Android.Content.Intent viewIntent) {
            return (await api.ViewEnd (apiClient, activity, viewIntent)).JavaCast<Statuses> ();
        }
        [Obsolete]
        public static async Task<Statuses> ViewEndAsync (this IAppIndexApi api, GoogleApiClient apiClient, Android.App.Activity activity, Android.Net.Uri appUri) {
            return (await api.ViewEnd (apiClient, activity, appUri)).JavaCast<Statuses> ();
        }
    }

    public static partial class IAppIndexApiActionResultExtensions {
        [Obsolete]
        public static async Task<Statuses> EndAsync (this IAppIndexApiActionResult api, GoogleApiClient apiClient) {
            return (await api.End (apiClient)).JavaCast<Statuses> ();
        }
    }
}

namespace Android.Gms.Search {
    public static partial class ISearchAuthApiExtensions {
        public static async Task<Statuses> ClearTokenAsync (this ISearchAuthApi api, GoogleApiClient client, string accessToken) {
            return (await api.ClearToken (client, accessToken)).JavaCast<Statuses> ();
        }

        public static async Task<ISearchAuthApiGoogleNowAuthResult> GetGoogleNowAuthAsync (this ISearchAuthApi api, GoogleApiClient client, string webAppClientId) {
            return (await api.GetGoogleNowAuth (client, webAppClientId)).JavaCast<ISearchAuthApiGoogleNowAuthResult> ();
        }
    }
}

