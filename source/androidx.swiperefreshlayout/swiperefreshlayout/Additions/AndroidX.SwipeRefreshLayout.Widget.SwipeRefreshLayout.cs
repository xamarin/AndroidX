using System;
using System.Collections.Generic;
using Android.Runtime;

namespace AndroidX.SwipeRefreshLayout.Widget
{
	public partial class SwipeRefreshLayout
	{
        public virtual void OnNestedScrollAccepted (Android.Views.View child, Android.Views.View target, int axes, int @type)
        {
            // Android.Views.ScrollAxis scroll_axes = (Android.Views.ScrollAxis) axes;

            OnNestedScrollAccepted (child, target, axes, @type);

            return;
        }

        public virtual bool OnStartNestedScroll (Android.Views.View child, Android.Views.View target, int axes, int @type)
        {
            // Android.Views.ScrollAxis scroll_axes = (Android.Views.ScrollAxis) axes;

            return OnStartNestedScroll (child, target, axes, @type);
        }
	}
}
