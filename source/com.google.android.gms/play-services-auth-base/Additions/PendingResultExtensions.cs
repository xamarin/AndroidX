using System;
using System.Threading.Tasks;
using Android.Gms.Common.Apis;
using Android.Gms.Common;
using Android.Runtime;

namespace Android.Gms.Auth.Api.Proxy
{
    public static partial class IProxyApiExtensions 
    {
        public static async Task<IProxyApiProxyResult> PerformProxyRequestAsync (this IProxyApi api, GoogleApiClient client, Android.Gms.Auth.Api.Proxy.ProxyRequest request) 
        {
            return (await api.PerformProxyRequest (client, request)).JavaCast<IProxyApiProxyResult> ();
        }
    }
}

namespace Android.Gms.Auth.Account
{
	public static partial class IWorkAccountApiExtensions
	{
		public static async Task<IWorkAccountApiAddAccountResult> AddWorkAccountAsync(this IWorkAccountApi api, GoogleApiClient client, string token)
		{
			return (await api.AddWorkAccount(client, token)).JavaCast<IWorkAccountApiAddAccountResult>();
		}

		public static async Task<IResult> PerformProxyRequestAsync(this IWorkAccountApi api, GoogleApiClient client, Accounts.Account account)
		{
			return (await api.RemoveWorkAccount(client, account)).JavaCast<IResult>();
		}

		public static async Task<IResult> SetWorkAuthenticatorEnabledWithResultAsync(this IWorkAccountApi api, Android.Gms.Common.Apis.GoogleApiClient client, bool enabled)
		{
			return (await api.SetWorkAuthenticatorEnabledWithResult(client, enabled)).JavaCast<IResult>();
		}
	}
}


