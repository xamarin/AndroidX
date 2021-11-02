using System;
using System.Collections.Generic;
using Android.Runtime;

namespace AndroidX.ConstraintLayout.Motion.Widget
{
	public partial class MotionLayout
	{
        public virtual void OnNestedScrollAccepted (Android.Views.View child, Android.Views.View target, int axes)
        {
            Android.Views.ScrollAxis scroll_axes = (Android.Views.ScrollAxis) axes;

            OnNestedScrollAccepted (child, target, axes);

            return;
        }

        public virtual void OnNestedScrollAccepted2 (Android.Views.View child, Android.Views.View target, int axes, int @type)
        {
            Android.Views.ScrollAxis scroll_axes = (Android.Views.ScrollAxis) axes;

            OnNestedScrollAccepted2 (child, target, axes, @type);

            return;
        }

        public virtual bool OnStartNestedScroll (Android.Views.View child, Android.Views.View target, int axes)
        {
            Android.Views.ScrollAxis scroll_axes = (Android.Views.ScrollAxis) axes;

            return OnStartNestedScroll (child, target, scroll_axes);
        }

        public virtual bool OnStartNestedScroll2 (Android.Views.View child, Android.Views.View target, int axes, int @type)
        {
            Android.Views.ScrollAxis scroll_axes = (Android.Views.ScrollAxis) axes;

            return OnStartNestedScroll2 (child, target, axes, @type);
        }
	}
}
