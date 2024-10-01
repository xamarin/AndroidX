using System;
using System.Threading.Tasks;
using Android.Gms.Extensions;

namespace Android.Gms.SafetyNet
{
	public partial class SafetyNetClient
	{
		public Task<SafetyNetApiAttestationResponse> AttestAsync (byte[] nonce, string apiKey)
		{
			return Attest(nonce, apiKey).AsAsync<SafetyNetApiAttestationResponse>();
		}

		public Task<SafetyNetApiVerifyAppsUserResponse> EnableVerifyAppsAsync ()
		{
			return EnableVerifyApps().AsAsync<SafetyNetApiVerifyAppsUserResponse>();
		}

		public Task InitSafeBrowsingAsync ()
		{
			return InitSafeBrowsing().AsAsync();
		}

		public Task<SafetyNetApiVerifyAppsUserResponse> IsVerifyAppsEnabledAsync ()
		{
			return IsVerifyAppsEnabled().AsAsync<SafetyNetApiVerifyAppsUserResponse>();
		}

		public Task<SafetyNetApiHarmfulAppsResponse> ListHarmfulAppsAsync ()
		{
			return ListHarmfulApps().AsAsync<SafetyNetApiHarmfulAppsResponse>();
		}

		public Task<SafetyNetApiAttestationResponse> LookupUriAsync (string uri, string apiKey, int[] threatTypes)
		{
			return LookupUri(uri, apiKey, threatTypes).AsAsync<SafetyNetApiAttestationResponse>();
		}

		public Task ShutdownSafeBrowsingAsync ()
		{
			return ShutdownSafeBrowsing().AsAsync();
		}

		public Task<SafetyNetApiRecaptchaTokenResponse> VerifyWithRecaptchaAsync (string siteKey)
		{
			return VerifyWithRecaptcha(siteKey).AsAsync<SafetyNetApiRecaptchaTokenResponse>();
		}
	}
}
