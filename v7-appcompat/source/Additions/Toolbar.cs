using System;

namespace Android.Support.V7.Widget
{
    public partial class Toolbar
    {        
        internal WeakReference weakNavigationOnClickDispatcher;
        internal NavigationOnClickEventDispatcher NavigationOnClickDispatcher
        {
            get {
                if (weakNavigationOnClickDispatcher == null || !weakNavigationOnClickDispatcher.IsAlive) {
                    var d = new NavigationOnClickEventDispatcher (this);
                    SetNavigationOnClickListener (d);
                    weakNavigationOnClickDispatcher = new WeakReference(d);
                }
                return (NavigationOnClickEventDispatcher) weakNavigationOnClickDispatcher.Target;
            }
        }

        public event EventHandler<NavigationClickEventArgs> NavigationClick
        {
            add {
                NavigationOnClickDispatcher.NavigationClick += value;
            }

            remove {
                NavigationOnClickDispatcher.NavigationClick -= value;
            }
        }

        internal partial class NavigationOnClickEventDispatcher : Java.Lang.Object, Views.View.IOnClickListener
        {
            Toolbar sender;

            public NavigationOnClickEventDispatcher (Toolbar sender)
            {
                this.sender = sender;
            }

            internal EventHandler<NavigationClickEventArgs> NavigationClick;

            public void OnClick (Android.Views.View v)
            {
                var h = NavigationClick;
                if (h != null)
                    h (sender, new NavigationClickEventArgs { View = v });
            }
        }

        public class NavigationClickEventArgs : EventArgs
        {
            public Views.View View { get; internal set; }
        }
    }
}

