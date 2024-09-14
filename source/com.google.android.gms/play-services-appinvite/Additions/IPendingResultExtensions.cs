using System;
using System.Threading.Tasks;
using Android.Runtime;
using Android.Gms.Common.Apis;
using Android.App;

namespace Android.Gms.AppInvite 
{
    public static partial class IAppInviteApiExtensions 
    {
        public static async Task<Statuses> ConvertInvitationAsync (this IAppInviteApi api, GoogleApiClient client, string invitationId) {
            return (await api.ConvertInvitation (client, invitationId)).JavaCast<Statuses> ();
        }

        [Obsolete]
        public static async Task<Statuses> UpdateInvitationOnInstallAsync (this IAppInviteApi api, GoogleApiClient client, string invitationId) {
            return (await api.UpdateInvitationOnInstall (client, invitationId)).JavaCast<Statuses> ();
        }

        [Obsolete]
        public static async Task<IAppInviteInvitationResult> GetInvitationAsync (this IAppInviteApi api, GoogleApiClient client, Activity activity, bool flag) {
            return (await api.GetInvitation(client, activity, flag)).JavaCast<IAppInviteInvitationResult>();
        }
    }
}


