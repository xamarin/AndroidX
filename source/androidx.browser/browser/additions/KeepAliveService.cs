using System;
using Android.App;
using Android.OS;

namespace Android.Support.CustomTabs
{
    // Empty service to bind to, to raise the application's importance to the OS
    [Service]
    public class KeepAliveService : global::Android.App.Service
    {
        static readonly Binder binder = new Binder();

        public override IBinder OnBind (global::Android.Content.Intent intent)
        {
            return binder;
        }
    }
}

