using System;
using Android.Runtime;

namespace Android.Support.Transitions
{
	public partial class FragmentTransitionSupport
	{
		static Delegate cb_addTargets_Ljava_lang_Object_Ljava_util_ArrayList_;
#pragma warning disable 0169
		static Delegate GetAddTargets_Ljava_lang_Object_Ljava_util_ArrayList_Handler()
		{
			if (cb_addTargets_Ljava_lang_Object_Ljava_util_ArrayList_ == null)
				cb_addTargets_Ljava_lang_Object_Ljava_util_ArrayList_ = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, IntPtr, IntPtr>)n_AddTargets_Ljava_lang_Object_Ljava_util_ArrayList_);
			return cb_addTargets_Ljava_lang_Object_Ljava_util_ArrayList_;
		}

		static void n_AddTargets_Ljava_lang_Object_Ljava_util_ArrayList_(IntPtr jnienv, IntPtr native__this, IntPtr native_transitionObj, IntPtr native_views)
		{
			global::Android.Support.Transitions.FragmentTransitionSupport __this = global::Java.Lang.Object.GetObject<global::Android.Support.Transitions.FragmentTransitionSupport>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Object transitionObj = global::Java.Lang.Object.GetObject<global::Java.Lang.Object>(native_transitionObj, JniHandleOwnership.DoNotTransfer);
			var views = global::Android.Runtime.JavaList<global::Android.Views.View>.FromJniHandle(native_views, JniHandleOwnership.DoNotTransfer);
			__this.AddTargets(transitionObj, views);
		}
#pragma warning restore 0169

		static IntPtr id_addTargets_Ljava_lang_Object_Ljava_util_ArrayList_;
		// Metadata.xml XPath method reference: path="/api/package[@name='android.support.transition']/class[@name='FragmentTransitionSupport']/method[@name='addTargets' and count(parameter)=2 and parameter[1][@type='java.lang.Object'] and parameter[2][@type='java.util.ArrayList&lt;android.view.View&gt;']]"
		[Register("addTargets", "(Ljava/lang/Object;Ljava/util/ArrayList;)V", "GetAddTargets_Ljava_lang_Object_Ljava_util_ArrayList_Handler")]
		public override unsafe void AddTargets(global::Java.Lang.Object transitionObj, global::System.Collections.Generic.IList<global::Android.Views.View> views)
		{
			if (id_addTargets_Ljava_lang_Object_Ljava_util_ArrayList_ == IntPtr.Zero)
				id_addTargets_Ljava_lang_Object_Ljava_util_ArrayList_ = JNIEnv.GetMethodID(class_ref, "addTargets", "(Ljava/lang/Object;Ljava/util/ArrayList;)V");
			IntPtr native_views = global::Android.Runtime.JavaList<global::Android.Views.View>.ToLocalJniHandle(views);
			try
			{
				JValue* __args = stackalloc JValue[2];
				__args[0] = new JValue(transitionObj);
				__args[1] = new JValue(native_views);

				if (((object)this).GetType() == ThresholdType)
					JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_addTargets_Ljava_lang_Object_Ljava_util_ArrayList_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "addTargets", "(Ljava/lang/Object;Ljava/util/ArrayList;)V"), __args);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(native_views);
			}
		}




		static Delegate cb_scheduleRemoveTargets_Ljava_lang_Object_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_lang_Object_Ljava_util_ArrayList_;
#pragma warning disable 0169
		static Delegate GetScheduleRemoveTargets_Ljava_lang_Object_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_lang_Object_Ljava_util_ArrayList_Handler()
		{
			if (cb_scheduleRemoveTargets_Ljava_lang_Object_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_lang_Object_Ljava_util_ArrayList_ == null)
				cb_scheduleRemoveTargets_Ljava_lang_Object_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_lang_Object_Ljava_util_ArrayList_ = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>)n_ScheduleRemoveTargets_Ljava_lang_Object_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_lang_Object_Ljava_util_ArrayList_);
			return cb_scheduleRemoveTargets_Ljava_lang_Object_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_lang_Object_Ljava_util_ArrayList_;
		}

		static void n_ScheduleRemoveTargets_Ljava_lang_Object_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_lang_Object_Ljava_util_ArrayList_(IntPtr jnienv, IntPtr native__this, IntPtr native_overallTransitionObj, IntPtr native_enterTransition, IntPtr native_enteringViews, IntPtr native_exitTransition, IntPtr native_exitingViews, IntPtr native_sharedElementTransition, IntPtr native_sharedElementsIn)
		{
			global::Android.Support.Transitions.FragmentTransitionSupport __this = global::Java.Lang.Object.GetObject<global::Android.Support.Transitions.FragmentTransitionSupport>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Object overallTransitionObj = global::Java.Lang.Object.GetObject<global::Java.Lang.Object>(native_overallTransitionObj, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Object enterTransition = global::Java.Lang.Object.GetObject<global::Java.Lang.Object>(native_enterTransition, JniHandleOwnership.DoNotTransfer);
			var enteringViews = global::Android.Runtime.JavaList<global::Android.Views.View>.FromJniHandle(native_enteringViews, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Object exitTransition = global::Java.Lang.Object.GetObject<global::Java.Lang.Object>(native_exitTransition, JniHandleOwnership.DoNotTransfer);
			var exitingViews = global::Android.Runtime.JavaList<global::Android.Views.View>.FromJniHandle(native_exitingViews, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Object sharedElementTransition = global::Java.Lang.Object.GetObject<global::Java.Lang.Object>(native_sharedElementTransition, JniHandleOwnership.DoNotTransfer);
			var sharedElementsIn = global::Android.Runtime.JavaList<global::Android.Views.View>.FromJniHandle(native_sharedElementsIn, JniHandleOwnership.DoNotTransfer);
			__this.ScheduleRemoveTargets(overallTransitionObj, enterTransition, enteringViews, exitTransition, exitingViews, sharedElementTransition, sharedElementsIn);
		}
#pragma warning restore 0169

		static IntPtr id_scheduleRemoveTargets_Ljava_lang_Object_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_lang_Object_Ljava_util_ArrayList_;
		// Metadata.xml XPath method reference: path="/api/package[@name='android.support.transition']/class[@name='FragmentTransitionSupport']/method[@name='scheduleRemoveTargets' and count(parameter)=7 and parameter[1][@type='java.lang.Object'] and parameter[2][@type='java.lang.Object'] and parameter[3][@type='java.util.ArrayList&lt;android.view.View&gt;'] and parameter[4][@type='java.lang.Object'] and parameter[5][@type='java.util.ArrayList&lt;android.view.View&gt;'] and parameter[6][@type='java.lang.Object'] and parameter[7][@type='java.util.ArrayList&lt;android.view.View&gt;']]"
		[Register("scheduleRemoveTargets", "(Ljava/lang/Object;Ljava/lang/Object;Ljava/util/ArrayList;Ljava/lang/Object;Ljava/util/ArrayList;Ljava/lang/Object;Ljava/util/ArrayList;)V", "GetScheduleRemoveTargets_Ljava_lang_Object_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_lang_Object_Ljava_util_ArrayList_Handler")]
		public override unsafe void ScheduleRemoveTargets(global::Java.Lang.Object overallTransitionObj, global::Java.Lang.Object enterTransition, global::System.Collections.Generic.IList<global::Android.Views.View> enteringViews, global::Java.Lang.Object exitTransition, global::System.Collections.Generic.IList<global::Android.Views.View> exitingViews, global::Java.Lang.Object sharedElementTransition, global::System.Collections.Generic.IList<global::Android.Views.View> sharedElementsIn)
		{
			if (id_scheduleRemoveTargets_Ljava_lang_Object_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_lang_Object_Ljava_util_ArrayList_ == IntPtr.Zero)
				id_scheduleRemoveTargets_Ljava_lang_Object_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_lang_Object_Ljava_util_ArrayList_ = JNIEnv.GetMethodID(class_ref, "scheduleRemoveTargets", "(Ljava/lang/Object;Ljava/lang/Object;Ljava/util/ArrayList;Ljava/lang/Object;Ljava/util/ArrayList;Ljava/lang/Object;Ljava/util/ArrayList;)V");
			IntPtr native_enteringViews = global::Android.Runtime.JavaList<global::Android.Views.View>.ToLocalJniHandle(enteringViews);
			IntPtr native_exitingViews = global::Android.Runtime.JavaList<global::Android.Views.View>.ToLocalJniHandle(exitingViews);
			IntPtr native_sharedElementsIn = global::Android.Runtime.JavaList<global::Android.Views.View>.ToLocalJniHandle(sharedElementsIn);
			try
			{
				JValue* __args = stackalloc JValue[7];
				__args[0] = new JValue(overallTransitionObj);
				__args[1] = new JValue(enterTransition);
				__args[2] = new JValue(native_enteringViews);
				__args[3] = new JValue(exitTransition);
				__args[4] = new JValue(native_exitingViews);
				__args[5] = new JValue(sharedElementTransition);
				__args[6] = new JValue(native_sharedElementsIn);

				if (((object)this).GetType() == ThresholdType)
					JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_scheduleRemoveTargets_Ljava_lang_Object_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_lang_Object_Ljava_util_ArrayList_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "scheduleRemoveTargets", "(Ljava/lang/Object;Ljava/lang/Object;Ljava/util/ArrayList;Ljava/lang/Object;Ljava/util/ArrayList;Ljava/lang/Object;Ljava/util/ArrayList;)V"), __args);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(native_enteringViews);
				JNIEnv.DeleteLocalRef(native_exitingViews);
				JNIEnv.DeleteLocalRef(native_sharedElementsIn);
			}
		}



		static Delegate cb_swapSharedElementTargets_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_util_ArrayList_;
#pragma warning disable 0169
		static Delegate GetSwapSharedElementTargets_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_util_ArrayList_Handler()
		{
			if (cb_swapSharedElementTargets_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_util_ArrayList_ == null)
				cb_swapSharedElementTargets_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_util_ArrayList_ = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>)n_SwapSharedElementTargets_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_util_ArrayList_);
			return cb_swapSharedElementTargets_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_util_ArrayList_;
		}

		static void n_SwapSharedElementTargets_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_util_ArrayList_(IntPtr jnienv, IntPtr native__this, IntPtr native_sharedElementTransitionObj, IntPtr native_sharedElementsOut, IntPtr native_sharedElementsIn)
		{
			global::Android.Support.Transitions.FragmentTransitionSupport __this = global::Java.Lang.Object.GetObject<global::Android.Support.Transitions.FragmentTransitionSupport>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Object sharedElementTransitionObj = global::Java.Lang.Object.GetObject<global::Java.Lang.Object>(native_sharedElementTransitionObj, JniHandleOwnership.DoNotTransfer);
			var sharedElementsOut = global::Android.Runtime.JavaList<global::Android.Views.View>.FromJniHandle(native_sharedElementsOut, JniHandleOwnership.DoNotTransfer);
			var sharedElementsIn = global::Android.Runtime.JavaList<global::Android.Views.View>.FromJniHandle(native_sharedElementsIn, JniHandleOwnership.DoNotTransfer);
			__this.SwapSharedElementTargets(sharedElementTransitionObj, sharedElementsOut, sharedElementsIn);
		}
#pragma warning restore 0169

		static IntPtr id_swapSharedElementTargets_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_util_ArrayList_;
		// Metadata.xml XPath method reference: path="/api/package[@name='android.support.transition']/class[@name='FragmentTransitionSupport']/method[@name='swapSharedElementTargets' and count(parameter)=3 and parameter[1][@type='java.lang.Object'] and parameter[2][@type='java.util.ArrayList&lt;android.view.View&gt;'] and parameter[3][@type='java.util.ArrayList&lt;android.view.View&gt;']]"
		[Register("swapSharedElementTargets", "(Ljava/lang/Object;Ljava/util/ArrayList;Ljava/util/ArrayList;)V", "GetSwapSharedElementTargets_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_util_ArrayList_Handler")]
		public override unsafe void SwapSharedElementTargets(global::Java.Lang.Object sharedElementTransitionObj, global::System.Collections.Generic.IList<global::Android.Views.View> sharedElementsOut, global::System.Collections.Generic.IList<global::Android.Views.View> sharedElementsIn)
		{
			if (id_swapSharedElementTargets_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_util_ArrayList_ == IntPtr.Zero)
				id_swapSharedElementTargets_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_util_ArrayList_ = JNIEnv.GetMethodID(class_ref, "swapSharedElementTargets", "(Ljava/lang/Object;Ljava/util/ArrayList;Ljava/util/ArrayList;)V");
			IntPtr native_sharedElementsOut = global::Android.Runtime.JavaList<global::Android.Views.View>.ToLocalJniHandle(sharedElementsOut);
			IntPtr native_sharedElementsIn = global::Android.Runtime.JavaList<global::Android.Views.View>.ToLocalJniHandle(sharedElementsIn);
			try
			{
				JValue* __args = stackalloc JValue[3];
				__args[0] = new JValue(sharedElementTransitionObj);
				__args[1] = new JValue(native_sharedElementsOut);
				__args[2] = new JValue(native_sharedElementsIn);

				if (((object)this).GetType() == ThresholdType)
					JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_swapSharedElementTargets_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_util_ArrayList_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "swapSharedElementTargets", "(Ljava/lang/Object;Ljava/util/ArrayList;Ljava/util/ArrayList;)V"), __args);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(native_sharedElementsOut);
				JNIEnv.DeleteLocalRef(native_sharedElementsIn);
			}
		}



		static Delegate cb_scheduleHideFragmentView_Ljava_lang_Object_Landroid_view_View_Ljava_util_ArrayList_;
#pragma warning disable 0169
		static Delegate GetScheduleHideFragmentView_Ljava_lang_Object_Landroid_view_View_Ljava_util_ArrayList_Handler()
		{
			if (cb_scheduleHideFragmentView_Ljava_lang_Object_Landroid_view_View_Ljava_util_ArrayList_ == null)
				cb_scheduleHideFragmentView_Ljava_lang_Object_Landroid_view_View_Ljava_util_ArrayList_ = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>)n_ScheduleHideFragmentView_Ljava_lang_Object_Landroid_view_View_Ljava_util_ArrayList_);
			return cb_scheduleHideFragmentView_Ljava_lang_Object_Landroid_view_View_Ljava_util_ArrayList_;
		}

		static void n_ScheduleHideFragmentView_Ljava_lang_Object_Landroid_view_View_Ljava_util_ArrayList_(IntPtr jnienv, IntPtr native__this, IntPtr native_exitTransitionObj, IntPtr native_fragmentView, IntPtr native_exitingViews)
		{
			global::Android.Support.Transitions.FragmentTransitionSupport __this = global::Java.Lang.Object.GetObject<global::Android.Support.Transitions.FragmentTransitionSupport>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Object exitTransitionObj = global::Java.Lang.Object.GetObject<global::Java.Lang.Object>(native_exitTransitionObj, JniHandleOwnership.DoNotTransfer);
			global::Android.Views.View fragmentView = global::Java.Lang.Object.GetObject<global::Android.Views.View>(native_fragmentView, JniHandleOwnership.DoNotTransfer);
			var exitingViews = global::Android.Runtime.JavaList<global::Android.Views.View>.FromJniHandle(native_exitingViews, JniHandleOwnership.DoNotTransfer);
			__this.ScheduleHideFragmentView(exitTransitionObj, fragmentView, exitingViews);
		}
#pragma warning restore 0169

		static IntPtr id_scheduleHideFragmentView_Ljava_lang_Object_Landroid_view_View_Ljava_util_ArrayList_;
		// Metadata.xml XPath method reference: path="/api/package[@name='android.support.transition']/class[@name='FragmentTransitionSupport']/method[@name='scheduleHideFragmentView' and count(parameter)=3 and parameter[1][@type='java.lang.Object'] and parameter[2][@type='android.view.View'] and parameter[3][@type='java.util.ArrayList&lt;android.view.View&gt;']]"
		[Register("scheduleHideFragmentView", "(Ljava/lang/Object;Landroid/view/View;Ljava/util/ArrayList;)V", "GetScheduleHideFragmentView_Ljava_lang_Object_Landroid_view_View_Ljava_util_ArrayList_Handler")]
		public override unsafe void ScheduleHideFragmentView(global::Java.Lang.Object exitTransitionObj, global::Android.Views.View fragmentView, global::System.Collections.Generic.IList<global::Android.Views.View> exitingViews)
		{
			if (id_scheduleHideFragmentView_Ljava_lang_Object_Landroid_view_View_Ljava_util_ArrayList_ == IntPtr.Zero)
				id_scheduleHideFragmentView_Ljava_lang_Object_Landroid_view_View_Ljava_util_ArrayList_ = JNIEnv.GetMethodID(class_ref, "scheduleHideFragmentView", "(Ljava/lang/Object;Landroid/view/View;Ljava/util/ArrayList;)V");
			IntPtr native_exitingViews = global::Android.Runtime.JavaList<global::Android.Views.View>.ToLocalJniHandle(exitingViews);
			try
			{
				JValue* __args = stackalloc JValue[3];
				__args[0] = new JValue(exitTransitionObj);
				__args[1] = new JValue(fragmentView);
				__args[2] = new JValue(native_exitingViews);

				if (((object)this).GetType() == ThresholdType)
					JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_scheduleHideFragmentView_Ljava_lang_Object_Landroid_view_View_Ljava_util_ArrayList_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "scheduleHideFragmentView", "(Ljava/lang/Object;Landroid/view/View;Ljava/util/ArrayList;)V"), __args);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(native_exitingViews);
			}
		}





		static Delegate cb_setSharedElementTargets_Ljava_lang_Object_Landroid_view_View_Ljava_util_ArrayList_;
#pragma warning disable 0169
		static Delegate GetSetSharedElementTargets_Ljava_lang_Object_Landroid_view_View_Ljava_util_ArrayList_Handler()
		{
			if (cb_setSharedElementTargets_Ljava_lang_Object_Landroid_view_View_Ljava_util_ArrayList_ == null)
				cb_setSharedElementTargets_Ljava_lang_Object_Landroid_view_View_Ljava_util_ArrayList_ = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>)n_SetSharedElementTargets_Ljava_lang_Object_Landroid_view_View_Ljava_util_ArrayList_);
			return cb_setSharedElementTargets_Ljava_lang_Object_Landroid_view_View_Ljava_util_ArrayList_;
		}

		static void n_SetSharedElementTargets_Ljava_lang_Object_Landroid_view_View_Ljava_util_ArrayList_(IntPtr jnienv, IntPtr native__this, IntPtr native_transitionObj, IntPtr native_nonExistentView, IntPtr native_sharedViews)
		{
			global::Android.Support.Transitions.FragmentTransitionSupport __this = global::Java.Lang.Object.GetObject<global::Android.Support.Transitions.FragmentTransitionSupport>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Object transitionObj = global::Java.Lang.Object.GetObject<global::Java.Lang.Object>(native_transitionObj, JniHandleOwnership.DoNotTransfer);
			global::Android.Views.View nonExistentView = global::Java.Lang.Object.GetObject<global::Android.Views.View>(native_nonExistentView, JniHandleOwnership.DoNotTransfer);
			var sharedViews = global::Android.Runtime.JavaList<global::Android.Views.View>.FromJniHandle(native_sharedViews, JniHandleOwnership.DoNotTransfer);
			__this.SetSharedElementTargets(transitionObj, nonExistentView, sharedViews);
		}
#pragma warning restore 0169

		static IntPtr id_setSharedElementTargets_Ljava_lang_Object_Landroid_view_View_Ljava_util_ArrayList_;
		// Metadata.xml XPath method reference: path="/api/package[@name='android.support.transition']/class[@name='FragmentTransitionSupport']/method[@name='setSharedElementTargets' and count(parameter)=3 and parameter[1][@type='java.lang.Object'] and parameter[2][@type='android.view.View'] and parameter[3][@type='java.util.ArrayList&lt;android.view.View&gt;']]"
		[Register("setSharedElementTargets", "(Ljava/lang/Object;Landroid/view/View;Ljava/util/ArrayList;)V", "GetSetSharedElementTargets_Ljava_lang_Object_Landroid_view_View_Ljava_util_ArrayList_Handler")]
		public override unsafe void SetSharedElementTargets(global::Java.Lang.Object transitionObj, global::Android.Views.View nonExistentView, global::System.Collections.Generic.IList<global::Android.Views.View> sharedViews)
		{
			if (id_setSharedElementTargets_Ljava_lang_Object_Landroid_view_View_Ljava_util_ArrayList_ == IntPtr.Zero)
				id_setSharedElementTargets_Ljava_lang_Object_Landroid_view_View_Ljava_util_ArrayList_ = JNIEnv.GetMethodID(class_ref, "setSharedElementTargets", "(Ljava/lang/Object;Landroid/view/View;Ljava/util/ArrayList;)V");
			IntPtr native_sharedViews = global::Android.Runtime.JavaList<global::Android.Views.View>.ToLocalJniHandle(sharedViews);
			try
			{
				JValue* __args = stackalloc JValue[3];
				__args[0] = new JValue(transitionObj);
				__args[1] = new JValue(nonExistentView);
				__args[2] = new JValue(native_sharedViews);

				if (((object)this).GetType() == ThresholdType)
					JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_setSharedElementTargets_Ljava_lang_Object_Landroid_view_View_Ljava_util_ArrayList_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setSharedElementTargets", "(Ljava/lang/Object;Landroid/view/View;Ljava/util/ArrayList;)V"), __args);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(native_sharedViews);
			}
		}



		static Delegate cb_replaceTargets_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_util_ArrayList_;
#pragma warning disable 0169
		static Delegate GetReplaceTargets_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_util_ArrayList_Handler()
		{
			if (cb_replaceTargets_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_util_ArrayList_ == null)
				cb_replaceTargets_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_util_ArrayList_ = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>)n_ReplaceTargets_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_util_ArrayList_);
			return cb_replaceTargets_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_util_ArrayList_;
		}

		static void n_ReplaceTargets_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_util_ArrayList_(IntPtr jnienv, IntPtr native__this, IntPtr native_transitionObj, IntPtr native_oldTargets, IntPtr native_newTargets)
		{
			global::Android.Support.Transitions.FragmentTransitionSupport __this = global::Java.Lang.Object.GetObject<global::Android.Support.Transitions.FragmentTransitionSupport>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::Java.Lang.Object transitionObj = global::Java.Lang.Object.GetObject<global::Java.Lang.Object>(native_transitionObj, JniHandleOwnership.DoNotTransfer);
			var oldTargets = global::Android.Runtime.JavaList<global::Android.Views.View>.FromJniHandle(native_oldTargets, JniHandleOwnership.DoNotTransfer);
			var newTargets = global::Android.Runtime.JavaList<global::Android.Views.View>.FromJniHandle(native_newTargets, JniHandleOwnership.DoNotTransfer);
			__this.ReplaceTargets(transitionObj, oldTargets, newTargets);
		}
#pragma warning restore 0169

		static IntPtr id_replaceTargets_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_util_ArrayList_;
		// Metadata.xml XPath method reference: path="/api/package[@name='android.support.transition']/class[@name='FragmentTransitionSupport']/method[@name='replaceTargets' and count(parameter)=3 and parameter[1][@type='java.lang.Object'] and parameter[2][@type='java.util.ArrayList&lt;android.view.View&gt;'] and parameter[3][@type='java.util.ArrayList&lt;android.view.View&gt;']]"
		[Register("replaceTargets", "(Ljava/lang/Object;Ljava/util/ArrayList;Ljava/util/ArrayList;)V", "GetReplaceTargets_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_util_ArrayList_Handler")]
		public override unsafe void ReplaceTargets(global::Java.Lang.Object transitionObj, global::System.Collections.Generic.IList<global::Android.Views.View> oldTargets, global::System.Collections.Generic.IList<global::Android.Views.View> newTargets)
		{
			if (id_replaceTargets_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_util_ArrayList_ == IntPtr.Zero)
				id_replaceTargets_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_util_ArrayList_ = JNIEnv.GetMethodID(class_ref, "replaceTargets", "(Ljava/lang/Object;Ljava/util/ArrayList;Ljava/util/ArrayList;)V");
			IntPtr native_oldTargets = global::Android.Runtime.JavaList<global::Android.Views.View>.ToLocalJniHandle(oldTargets);
			IntPtr native_newTargets = global::Android.Runtime.JavaList<global::Android.Views.View>.ToLocalJniHandle(newTargets);
			try
			{
				JValue* __args = stackalloc JValue[3];
				__args[0] = new JValue(transitionObj);
				__args[1] = new JValue(native_oldTargets);
				__args[2] = new JValue(native_newTargets);

				if (((object)this).GetType() == ThresholdType)
					JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_replaceTargets_Ljava_lang_Object_Ljava_util_ArrayList_Ljava_util_ArrayList_, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "replaceTargets", "(Ljava/lang/Object;Ljava/util/ArrayList;Ljava/util/ArrayList;)V"), __args);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(native_oldTargets);
				JNIEnv.DeleteLocalRef(native_newTargets);
			}
		}
	}
}
