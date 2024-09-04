using System;
using System.Threading.Tasks;
using Android.Gms.Extensions;

namespace Firebase.RemoteConfig
{
    public partial class FirebaseRemoteConfig
    {
        public Task FetchAsync ()
        {
            return Fetch ().AsAsync ();
        }

        public Task FetchAsync (long timeout)
        {
            return Fetch (timeout).AsAsync ();
        }
    }
}
