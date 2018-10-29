using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using Android.Support.CustomTabs;

namespace Android.Support.CustomTabs
{

    class CustomTabsServiceConnectionImpl : CustomTabsServiceConnection
    {
        public Action<ComponentName, CustomTabsClient> CustomTabsServiceConnectedHandler { get; set; }
        public Action<ComponentName> OnServiceDisconnectedHandler { get; set; }

        public override void OnCustomTabsServiceConnected (ComponentName name, CustomTabsClient customTabsClient)
        {
            var h = CustomTabsServiceConnectedHandler;
            if (h != null)
                h (name, customTabsClient);
        }

        public override void OnServiceDisconnected (ComponentName name)
        {
            var h = OnServiceDisconnectedHandler;
            if (h != null)
                h (name);
        }
    }
}
