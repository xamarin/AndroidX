using System;
using Android.Runtime;

namespace AndroidX.Lifecycle
{
	public partial class Lifecycle
	{
		public partial class Event
		{
			[Annotation("androidx.lifecycle.OnLifecycleEvent(androidx.lifecycle.Lifecycle.Event.ON_CREATE)")]
			public class OnCreateAttribute : Attribute
			{ }

			[Annotation("androidx.lifecycle.OnLifecycleEvent(androidx.lifecycle.Lifecycle.Event.ON_START)")]
			public class OnStartAttribute : Attribute
			{ }

			[Annotation("androidx.lifecycle.OnLifecycleEvent(androidx.lifecycle.Lifecycle.Event.ON_RESUME)")]
			public class OnResumeAttribute : Attribute
			{ }

			[Annotation("androidx.lifecycle.OnLifecycleEvent(androidx.lifecycle.Lifecycle.Event.ON_PAUSE)")]
			public class OnPauseAttribute : Attribute
			{ }

			[Annotation("androidx.lifecycle.OnLifecycleEvent(androidx.lifecycle.Lifecycle.Event.ON_STOP)")]
			public class OnStopAttribute : Attribute
			{ }

			[Annotation("androidx.lifecycle.OnLifecycleEvent(androidx.lifecycle.Lifecycle.Event.ON_DESTROY)")]
			public class OnDestroyAttribute : Attribute
			{ }

			[Annotation("androidx.lifecycle.OnLifecycleEvent(androidx.lifecycle.Lifecycle.Event.ON_ANY)")]
			public class OnAnyAttribute : Attribute
			{ }
		}
	}
}