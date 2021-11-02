using System;
using System.Collections.Generic;
using Android.Runtime;

namespace AndroidX.CoordinatorLayout.Widget
{
	public partial class CoordinatorLayout
	{
        public virtual void OnNestedScrollAccepted (Android.Views.View child, Android.Views.View target, int nestedScrollAxes)
        {
            Android.Views.ScrollAxis scroll_axes = (Android.Views.ScrollAxis) nestedScrollAxes;

            OnNestedScrollAccepted (child, target, scroll_axes);

            return;
        }

        public virtual void OnNestedScrollAccepted2 (Android.Views.View child, Android.Views.View target, int nestedScrollAxes, int @type)
        {
            OnNestedScrollAccepted (child, target, nestedScrollAxes, @type);

            return;
        }

        public virtual bool OnStartNestedScroll (Android.Views.View child, Android.Views.View target, int axes)
        {
            Android.Views.ScrollAxis scroll_axes = (Android.Views.ScrollAxis) axes;

            return OnStartNestedScroll (child, target, scroll_axes);
        }

        public virtual bool OnStartNestedScroll2 (Android.Views.View child, Android.Views.View target, int axes, int @type)
        {
            return OnStartNestedScroll2 (child, target, axes, @type);
        }
	}
}
