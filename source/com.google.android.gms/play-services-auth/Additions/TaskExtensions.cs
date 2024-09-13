using System;
using System.Threading.Tasks;
using Android.Content;
using Android.Gms.Extensions;

namespace Android.Gms.Auth.Api.SignIn
{

    public partial class GoogleSignIn
    {
        public static Task<GoogleSignInAccount> GetSignedInAccountFromIntentAsync (Intent intent)
        {
            return GetSignedInAccountFromIntent (intent).AsAsync<GoogleSignInAccount>();
        }
    }

    public partial class GoogleSignInClient
    {
        public Task RevokeAccessAsync ()
        {
            return RevokeAccess ().AsAsync ();
        }

        public Task SignOutAsync ()
        {
            return SignOut ().AsAsync ();
        }

        public Task<GoogleSignInAccount> SilentSignInAsync ()
        {
            return SilentSignIn ().AsAsync<GoogleSignInAccount> ();
        }
    }
}
