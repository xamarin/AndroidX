using System;
using System.Threading.Tasks;
using Android.OS;

namespace Android.Gms.Iid
{
    public partial class InstanceID
    {
        public const string IntentFilterAction = "com.google.android.gms.iid.InstanceID";

        public async Task<string> GetTokenAsync (string authorizedEntity, string scope)
        {
            var taskCompletionSource = new TaskCompletionSource<string> ();

            Task.Run (() => {
                var token = this.GetToken (authorizedEntity, scope);
                taskCompletionSource.SetResult (token);
            }).ContinueWith (t => {
                taskCompletionSource.SetException (t.Exception);
            }, TaskContinuationOptions.OnlyOnFaulted);
            return await taskCompletionSource.Task;
        }

        public async Task<string> GetTokenAsync (string authorizedEntity, string scope, Bundle extras)
        {
            var taskCompletionSource = new TaskCompletionSource<string> ();

            Task.Run (() => {
                var token = this.GetToken (authorizedEntity, scope, extras);
                taskCompletionSource.SetResult (token);
            }).ContinueWith (t => {
                taskCompletionSource.SetException (t.Exception);
            }, TaskContinuationOptions.OnlyOnFaulted);

            return await taskCompletionSource.Task;
        }
    }
}
