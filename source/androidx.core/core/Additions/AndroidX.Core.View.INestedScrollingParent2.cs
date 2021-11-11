using System;
using System.Collections.Generic;
using Android.Runtime;

namespace AndroidX.Core.View
{
	public partial interface INestedScrollingParent2
	{
		public virtual void OnNestedScrollAccepted (Android.Views.View child, Android.Views.View target, int axis, int @type)
		{
			Android.Views.ScrollAxis scroll_axis = (Android.Views.ScrollAxis) axis;

			OnNestedScrollAccepted(child, target, scroll_axis, @type);

			return;
		}

		public virtual bool OnStartNestedScroll (Android.Views.View child, Android.Views.View target, int axis, int @type)
		{
			Android.Views.ScrollAxis scroll_axis = (Android.Views.ScrollAxis) axis;

			return OnStartNestedScroll(child, target, scroll_axis, @type);
		}
	}
}
