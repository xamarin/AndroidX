#nullable restore
using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace Xamarin.TensorFlow.Lite.Support.Common 
{

	// Metadata.xml XPath class reference: path="/api/package[@name='org.tensorflow.lite.support.common']/class[@name='TensorProcessor']"
	// [global::Android.Runtime.Register ("org/tensorflow/lite/support/common/TensorProcessor", DoNotGenerateAcw=true)]
	public partial class TensorProcessor // : global::Xamarin.TensorFlow.Lite.Support.Common.SequentialProcessor 
	{
		// [global::Android.Runtime.Register ("org/tensorflow/lite/support/common/TensorProcessor$Builder", DoNotGenerateAcw=true)]
		public new partial class Builder // : global::Java.Lang.Object 
		{
			static Delegate cb_buildTensorProcessor;
#pragma warning disable 0169
			static Delegate GetBuildTensorProcessorHandler ()
			{
				if (cb_buildTensorProcessor == null)
					cb_buildTensorProcessor = JNINativeWrapper.CreateDelegate (new _JniMarshal_PP_L (n_BuildTensorProcessor));
				return cb_buildTensorProcessor;
			}

			static IntPtr n_BuildTensorProcessor (IntPtr jnienv, IntPtr native__this)
			{
				var __this = global::Java.Lang.Object.GetObject<global::Xamarin.TensorFlow.Lite.Support.Common.TensorProcessor.Builder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle (__this.BuildTensorProcessor ());
			}
#pragma warning restore 0169

			// Metadata.xml XPath method reference: path="/api/package[@name='org.tensorflow.lite.support.common']/class[@name='TensorProcessor.Builder']/method[@name='build' and count(parameter)=0]"
			[Register ("build", "()Lorg/tensorflow/lite/support/common/TensorProcessor;", "GetBuildTensorProcessorHandler")]
			public virtual unsafe global::Xamarin.TensorFlow.Lite.Support.Common.TensorProcessor BuildTensorProcessor ()
			{
				const string __id = "build.()Lorg/tensorflow/lite/support/common/TensorProcessor;";
				try {
					var __rm = _members.InstanceMethods.InvokeVirtualObjectMethod (__id, this, null);
					return global::Java.Lang.Object.GetObject<global::Xamarin.TensorFlow.Lite.Support.Common.TensorProcessor> (__rm.Handle, JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}
	}
}