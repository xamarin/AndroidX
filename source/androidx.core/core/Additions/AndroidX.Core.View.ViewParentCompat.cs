using System;
using System.Collections.Generic;
using Android.Runtime;

namespace AndroidX.Core.View
{
	public sealed partial class ViewParentCompat
	{
        public static void OnNestedScrollAccepted(Android.Views.IViewParent parent, Android.Views.View child, Android.Views.View target, int nestedScrollAxes)
        {
            Android.Views.ScrollAxis scroll_axes = (Android.Views.ScrollAxis)nestedScrollAxes;

            OnNestedScrollAccepted(parent, child, target, scroll_axes);

            return;
        }

        public static void OnNestedScrollAccepted(Android.Views.IViewParent parent, Android.Views.View child, Android.Views.View target, int nestedScrollAxes, int type)
        {
            Android.Views.ScrollAxis scroll_axes = (Android.Views.ScrollAxis)nestedScrollAxes;

            OnNestedScrollAccepted(parent, child, target, scroll_axes, @type);

            return;

        }

        public static bool OnStartNestedScroll(Android.Views.IViewParent parent, Android.Views.View child, Android.Views.View target, int nestedScrollAxes)
        {
            Android.Views.ScrollAxis scroll_axes = (Android.Views.ScrollAxis)nestedScrollAxes;

            return OnStartNestedScroll(parent, child, target, scroll_axes);

        }

        public static bool OnStartNestedScroll(Android.Views.IViewParent parent, Android.Views.View child, Android.Views.View target, int nestedScrollAxes, int type)
		{
			Android.Views.ScrollAxis scroll_axes = (Android.Views.ScrollAxis)nestedScrollAxes;

			return OnStartNestedScroll(parent, child, target, scroll_axes);

		}

	}
}
