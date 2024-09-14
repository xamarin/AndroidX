using System;
using System.Threading.Tasks;
using Android.Gms.Common.Apis;
using Android.Runtime;

namespace Android.Gms.Panorama
{
    public static partial class IPanoramaApiExtensions
    {
        public static async Task<IPanoramaApiPanoramaResult> LoadPanoramaInfoAsync (this IPanoramaApi api, GoogleApiClient client, Android.Net.Uri uri)
        {
            return (await api.LoadPanoramaInfo (client, uri)).JavaCast<IPanoramaApiPanoramaResult> ();
        }
        public static async Task<IPanoramaApiPanoramaResult> LoadPanoramaInfoAndGrantAccessAsync (this IPanoramaApi api, GoogleApiClient client, Android.Net.Uri uri)
        {
            return (await api.LoadPanoramaInfoAndGrantAccess (client, uri)).JavaCast<IPanoramaApiPanoramaResult> ();
        }
    }
}
