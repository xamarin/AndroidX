using System;
using System.Collections.Generic;
using Android.Runtime;

namespace AndroidX.Core.View
{
	public partial interface INestedScrollingParent2
	{
		public virtual void OnNestedScrollAccepted (Android.Views.View child, Android.Views.View target, int axis, int @type)
		{

			OnNestedScrollAccepted2(child, target, axis, @type);

			return;
		}

		public virtual bool OnStartNestedScroll (Android.Views.View child, Android.Views.View target, int axis, int @type)
		{
			return OnStartNestedScroll2(child, target, axis, @type);
		}
	}
}
