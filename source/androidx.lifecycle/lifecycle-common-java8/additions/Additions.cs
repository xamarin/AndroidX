using System;
using Android.Runtime;

namespace Android.Arch.Lifecycle
{
	public partial class Lifecycle
	{
		public partial class Event
		{
			[Annotation("android.arch.lifecycle.OnLifecycleEvent(android.arch.lifecycle.Lifecycle.Event.ON_CREATE)")]
			public class OnCreateAttribute : Attribute
			{ }

			[Annotation("android.arch.lifecycle.OnLifecycleEvent(android.arch.lifecycle.Lifecycle.Event.ON_START)")]
			public class OnStartAttribute : Attribute
			{ }

			[Annotation("android.arch.lifecycle.OnLifecycleEvent(android.arch.lifecycle.Lifecycle.Event.ON_RESUME)")]
			public class OnResumeAttribute : Attribute
			{ }

			[Annotation("android.arch.lifecycle.OnLifecycleEvent(android.arch.lifecycle.Lifecycle.Event.ON_PAUSE)")]
			public class OnPauseAttribute : Attribute
			{ }

			[Annotation("android.arch.lifecycle.OnLifecycleEvent(android.arch.lifecycle.Lifecycle.Event.ON_STOP)")]
			public class OnStopAttribute : Attribute
			{ }

			[Annotation("android.arch.lifecycle.OnLifecycleEvent(android.arch.lifecycle.Lifecycle.Event.ON_DESTROY)")]
			public class OnDestroyAttribute : Attribute
			{ }

			[Annotation("android.arch.lifecycle.OnLifecycleEvent(android.arch.lifecycle.Lifecycle.Event.ON_ANY)")]
			public class OnAnyAttribute : Attribute
			{ }
		}
	}
}