using System;
using System.Collections.Generic;
using Android.Runtime;

namespace AndroidX.Core.View
{
	public partial class NestedScrollingParentHelper
	{
		public virtual void OnNestedScrollAccepted (Android.Views.View child, Android.Views.View target, int axis, int @type)
		{
			Android.Views.ScrollAxis scroll_axis = (Android.Views.ScrollAxis) axis;

			OnNestedScrollAccepted(child, target, scroll_axis, @type);

			return;
		}

		public virtual void OnNestedScrollAccepted(Android.Views.View child, Android.Views.View target, int axes)
		{
			Android.Views.ScrollAxis scroll_axis = (Android.Views.ScrollAxis) axes;

			OnNestedScrollAccepted(child, target, scroll_axis);

			return;
		}

		//public bool OnStartNestedScroll (Android.Views.View child, Android.Views.View target, int axes, int @type)
		//{
		//	Android.Views.ScrollAxis scroll_axes = (Android.Views.ScrollAxis) axes;

		//	return OnStartNestedScroll(child, target, scroll_axes, @type);
		//}
	}
}
