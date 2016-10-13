using System;
using Android.OS;

namespace Android.Support.CustomTabs
{
    public partial class CustomTabsClient
    {
        public delegate void OnNavigationEventDelegate (int navigationEvent, Bundle extras);
        public delegate void ExtraCallbackDelegate (string callbackName, Bundle args);

        public CustomTabsSession NewSession (OnNavigationEventDelegate onNavigationEventHandler)
        {
            return NewSession (new CustomTabsCallbackImpl (onNavigationEventHandler));
        }

        public CustomTabsSession NewSession (OnNavigationEventDelegate onNavigationEventHandler, ExtraCallbackDelegate extraCallbackHandler)
        {
            return NewSession (new CustomTabsCallbackImpl (onNavigationEventHandler, extraCallbackHandler));
        }

        internal class CustomTabsCallbackImpl : CustomTabsCallback
        {
            OnNavigationEventDelegate onNavigationEventHandler;
            ExtraCallbackDelegate extraCallbackHandler;


            public CustomTabsCallbackImpl (OnNavigationEventDelegate onNavigationEventHandler)
            {
                this.onNavigationEventHandler = onNavigationEventHandler;
            }

            public CustomTabsCallbackImpl (OnNavigationEventDelegate onNavigationEventHandler, ExtraCallbackDelegate extraCallbackHandler)
            {
                this.onNavigationEventHandler = onNavigationEventHandler;
                this.extraCallbackHandler = extraCallbackHandler;
            }

            public override void OnNavigationEvent (int navigationEvent, Bundle extras)
            {
                if (onNavigationEventHandler != null)
                    onNavigationEventHandler (navigationEvent, extras);
            }

            public override void ExtraCallback (string callbackName, Bundle args)
            {
                if (extraCallbackHandler != null)
                    extraCallbackHandler (callbackName, args);
            }
        }
    }
}

