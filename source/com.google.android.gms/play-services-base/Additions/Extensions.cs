using System;
using System.Threading.Tasks;
using Android.Gms.Common;
using Android.Gms.Common.Apis;

namespace Android.Gms.Extensions
{
    public static class GoogleApiClientExtensions
    {
        public static Task<GoogleApiClient> BuildAndConnectAsync (this GoogleApiClient.Builder builder, Action<int> connectionPausedHandler = null)
        {
            GoogleApiClient client = null;
            var tcsConnected = new TaskCompletionSource<GoogleApiClient> ();

            builder.AddConnectionCallbacks (hint => {
                tcsConnected.SetResult (client);
            }, connectionPausedHandler);
            builder.AddOnConnectionFailedListener (connectionResult => {
                tcsConnected.SetException (new GoogleApiClientConnectionException (connectionResult));
            });

            client = builder.Build ();

            return tcsConnected.Task;
        }

        public class GoogleApiClientConnectionException : Exception
        {
            public GoogleApiClientConnectionException (ConnectionResult connectionResult)
                : base (connectionResult.ErrorMessage)
            {
                ConnectionResult = connectionResult;
            }

            public ConnectionResult ConnectionResult { get; private set; }
        }
    }
}

