#nullable restore
using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace Xamarin.TensorFlow.Lite.Support.Image 
{

	// Metadata.xml XPath class reference: path="/api/package[@name='org.tensorflow.lite.support.image']/class[@name='ImageProcessor']"
	// [global::Android.Runtime.Register ("org/tensorflow/lite/support/image/ImageProcessor", DoNotGenerateAcw=true)]
	public partial class ImageProcessor // : global::Xamarin.TensorFlow.Lite.Support.Common.SequentialProcessor 
	{
		// Metadata.xml XPath class reference: path="/api/package[@name='org.tensorflow.lite.support.image']/class[@name='ImageProcessor.Builder']"
		// [global::Android.Runtime.Register ("org/tensorflow/lite/support/image/ImageProcessor$Builder", DoNotGenerateAcw=true)]
		public new partial class Builder // : global::Java.Lang.Object 
		{
			static Delegate cb_buildImageProcessor;
#pragma warning disable 0169
			static Delegate GetBuildImageProcessorHandler ()
			{
				if (cb_buildImageProcessor == null)
					cb_buildImageProcessor = JNINativeWrapper.CreateDelegate (new _JniMarshal_PP_L (n_BuildImageProcessor));
				return cb_buildImageProcessor;
			}

			static IntPtr n_BuildImageProcessor (IntPtr jnienv, IntPtr native__this)
			{
				var __this = global::Java.Lang.Object.GetObject<global::Xamarin.TensorFlow.Lite.Support.Image.ImageProcessor.Builder> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.ToLocalJniHandle (__this.BuildImageProcessor ());
			}
#pragma warning restore 0169

			// Metadata.xml XPath method reference: path="/api/package[@name='org.tensorflow.lite.support.image']/class[@name='ImageProcessor.Builder']/method[@name='build' and count(parameter)=0]"
			[Register ("build", "()Lorg/tensorflow/lite/support/image/ImageProcessor;", "GetBuildImageProcessorHandler")]
			public virtual unsafe global::Xamarin.TensorFlow.Lite.Support.Image.ImageProcessor BuildImageProcessor ()
			{
				const string __id = "build.()Lorg/tensorflow/lite/support/image/ImageProcessor;";
				try {
					var __rm = _members.InstanceMethods.InvokeVirtualObjectMethod (__id, this, null);
					return global::Java.Lang.Object.GetObject<global::Xamarin.TensorFlow.Lite.Support.Image.ImageProcessor> (__rm.Handle, JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}
	}
}