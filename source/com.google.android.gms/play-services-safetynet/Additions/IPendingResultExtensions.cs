using System;
using System.Threading.Tasks;
using Android.Gms.Common.Apis;
using Android.Runtime;
using System.Collections.Generic;

namespace Android.Gms.SafetyNet
{
    public static partial class ISafetyNetApiExtensions
    {
        [Obsolete]
        public static async Task<SafetyNetApiAttestationResponse> AttestAsync(this ISafetyNetApi api, GoogleApiClient googleApiClient, byte[] nonce)
        {
            return (await api.Attest(googleApiClient, nonce)).JavaCast<SafetyNetApiAttestationResponse>();
        }
        public static async Task<SafetyNetApiSafeBrowsingResponse> LookupUriAsync(this ISafetyNetApi api, GoogleApiClient googleApiClient, IList<Java.Lang.Integer> threatTypes, string uri)
        {
            return (await api.LookupUri(googleApiClient, threatTypes, uri)).JavaCast<SafetyNetApiSafeBrowsingResponse>();
        }

        [Obsolete]
        public static async Task<SafetyNetApiSafeBrowsingResponse> LookupUriAsync(this ISafetyNetApi api, GoogleApiClient client, string str1, string str2, params int[] threatTypes)
        {
            return (await api.LookupUri(client, str1, str2, threatTypes)).JavaCast<SafetyNetApiSafeBrowsingResponse>();
        }

        [Obsolete]
        public static async Task<IResult> VerifyWithRecaptchaAsync(this ISafetyNetApi api, GoogleApiClient client, string recaptcha)
        {
            return (await api.VerifyWithRecaptcha(client, recaptcha)).JavaCast<IResult>();
        }

		[Obsolete]
		public static async Task<SafetyNetApiVerifyAppsUserResponse> IsVerifyAppsEnabledAsync(this ISafetyNetApi api, GoogleApiClient client)
		{
            return (await api.IsVerifyAppsEnabled(client)).JavaCast<SafetyNetApiVerifyAppsUserResponse>();
		}

		[Obsolete]
        public static async Task<SafetyNetApiVerifyAppsUserResponse> EnableVerifyAppsAsync(this ISafetyNetApi api, GoogleApiClient client)
		{
            return (await api.EnableVerifyApps(client)).JavaCast<SafetyNetApiVerifyAppsUserResponse>();
		}

		[Obsolete]
        public static async Task<SafetyNetApiVerifyAppsUserResponse> ListHarmfulAppsAsync(this ISafetyNetApi api, GoogleApiClient client)
		{
            return (await api.ListHarmfulApps(client)).JavaCast<SafetyNetApiVerifyAppsUserResponse>();
		}
    }
}
