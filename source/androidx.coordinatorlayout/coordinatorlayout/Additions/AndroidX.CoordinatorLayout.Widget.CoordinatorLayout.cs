using System;
using System.Collections.Generic;
using Android.Runtime;

namespace AndroidX.CoordinatorLayout.Widget
{
	public partial class CoordinatorLayout
	{
        public virtual void OnNestedScrollAccepted (Android.Views.View child, Android.Views.View target, int nestedScrollAxes, int @type)
        {
            Android.Views.ScrollAxis scroll_axes = (Android.Views.ScrollAxis) nestedScrollAxes;

            OnNestedScrollAccepted (child, target, scroll_axes, @type);

            return;
        }

        public virtual bool OnStartNestedScroll (Android.Views.View child, Android.Views.View target, int axes, int @type)
        {
            Android.Views.ScrollAxis scroll_axes = (Android.Views.ScrollAxis) axes;

            return OnStartNestedScroll (child, target, scroll_axes, @type);
        }
	}
}
