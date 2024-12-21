﻿using System;
using Android.Runtime;
using Java.Interop;

#if ! NET9_0_OR_GREATER
namespace Xamarin.Google.MLKit.Vision.Label.AutoML
{

    // Metadata.xml XPath class reference: path="/api/package[@name='com.google.mlkit.vision.label.automl']/class[@name='AutoMLImageLabelerOptions']"
    //[global::Android.Runtime.Register("com/google/mlkit/vision/label/automl/AutoMLImageLabelerOptions", DoNotGenerateAcw = true)]
    public partial class AutoMLImageLabelerOptions //: global::Xamarin.Google.MLKit.Vision.Label.ImageLabelerOptionsBase
    {
		static Delegate cb_build;
#pragma warning disable 0169
		static Delegate GetBuildHandler()
		{
			if (cb_build == null)
				cb_build = JNINativeWrapper.CreateDelegate((Func<IntPtr, IntPtr, IntPtr>)n_Build);
			return cb_build;
		}

		static IntPtr n_Build(IntPtr jnienv, IntPtr native__this)
		{
			global::Xamarin.Google.MLKit.Vision.Label.AutoML.AutoMLImageLabelerOptions.Builder __this = global::Java.Lang.Object.GetObject<global::Xamarin.Google.MLKit.Vision.Label.AutoML.AutoMLImageLabelerOptions.Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(__this.Build());
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='com.google.mlkit.vision.label.automl']/class[@name='AutoMLImageLabelerOptions.Builder']/method[@name='build' and count(parameter)=0]"
		[Register("build", "()Lcom/google/mlkit/vision/label/ImageLabelerOptionsBase;", "GetBuildHandler")]
		public virtual unsafe global::Xamarin.Google.MLKit.Vision.Label.ImageLabelerOptionsBase Build()
		{
			const string __id = "build.()Lcom/google/mlkit/vision/label/ImageLabelerOptionsBase;";
			try
			{
				var __rm = _members.InstanceMethods.InvokeVirtualObjectMethod(__id, this, null);
				return global::Java.Lang.Object.GetObject<global::Xamarin.Google.MLKit.Vision.Label.ImageLabelerOptionsBase>(__rm.Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
			}
		}





		static Delegate cb_setConfidenceThreshold_F;
#pragma warning disable 0169
		static Delegate GetSetConfidenceThreshold_FHandler()
		{
			if (cb_setConfidenceThreshold_F == null)
				cb_setConfidenceThreshold_F = JNINativeWrapper.CreateDelegate((Func<IntPtr, IntPtr, float, IntPtr>)n_SetConfidenceThreshold_F);
			return cb_setConfidenceThreshold_F;
		}

		static IntPtr n_SetConfidenceThreshold_F(IntPtr jnienv, IntPtr native__this, float p0)
		{
			global::Xamarin.Google.MLKit.Vision.Label.AutoML.AutoMLImageLabelerOptions.Builder __this = global::Java.Lang.Object.GetObject<global::Xamarin.Google.MLKit.Vision.Label.AutoML.AutoMLImageLabelerOptions.Builder>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(__this.SetConfidenceThreshold(p0));
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='com.google.mlkit.vision.label.automl']/class[@name='AutoMLImageLabelerOptions.Builder']/method[@name='setConfidenceThreshold' and count(parameter)=1 and parameter[1][@type='float']]"
		[Register("setConfidenceThreshold", "(F)Ljava/lang/Object;", "GetSetConfidenceThreshold_FHandler")]
		public virtual unsafe global::Java.Lang.Object SetConfidenceThreshold(float p0)
		{
			const string __id = "setConfidenceThreshold.(F)Ljava/lang/Object;";
			try
			{
				JniArgumentValue* __args = stackalloc JniArgumentValue[1];
				__args[0] = new JniArgumentValue(p0);
				var __rm = _members.InstanceMethods.InvokeVirtualObjectMethod(__id, this, __args);
				return global::Java.Lang.Object.GetObject<global::Java.Lang.Object>(__rm.Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
			}
		}

	}
}
#endif
