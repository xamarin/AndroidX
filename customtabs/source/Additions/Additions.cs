using System;
using Android.OS;

namespace Android.Support.CustomTabs
{
    public partial class CustomTabsClient
    {
        public delegate void OnNavigationEventDelegate (int navigationEvent, Bundle extras);

        public CustomTabsSession NewSession (OnNavigationEventDelegate callback)
        {
            return NewSession (new CustomTabsCallbackImpl (callback));
        }

        internal class CustomTabsCallbackImpl : CustomTabsCallback
        {
            OnNavigationEventDelegate callback;

            public CustomTabsCallbackImpl (OnNavigationEventDelegate callback)
            {
                this.callback = callback;
            }

            public void OnNavigationEvent (int navigationEvent, Bundle extras)
            {
                if (callback != null)
                    callback (navigationEvent, extras);
            }
        }
    }
}

