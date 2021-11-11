using System;

namespace AndroidX.AppCompat.Widget
{
    public partial class ActionBarOverlayLayout
    {
		public virtual void OnNestedScrollAccepted(Android.Views.View child, Android.Views.View target, int axes, int @type)
		{
			Android.Views.ScrollAxis scroll_axes = (Android.Views.ScrollAxis) axes;

			OnNestedScrollAccepted(child, target, scroll_axes, @type);

			return;
		}

		public virtual bool OnStartNestedScroll(Android.Views.View child, Android.Views.View target, int axes, int @type)
		{
			Android.Views.ScrollAxis scroll_axes = (Android.Views.ScrollAxis) axes;

			return OnStartNestedScroll(child, target, scroll_axes, @type);
		}
	}
}

