using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace Xamarin.Google.MLKit.Vision.Common.Internal 
{
	// Metadata.xml XPath class reference: path="/api/package[@name='com.google.mlkit.vision.common.internal']/class[@name='VisionCommonRegistrar']"
	//[global::Android.Runtime.Register ("com/google/mlkit/vision/common/internal/VisionCommonRegistrar", DoNotGenerateAcw=true)]
	public partial class VisionCommonRegistrar //: global::Java.Lang.Object, global::Firebase.Components.IComponentRegistrar {
	{

		public unsafe global::System.Collections.Generic.IList <global:: Firebase.Components.Component > Components 
        {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.google.mlkit.vision.common.internal']/class[@name='VisionCommonRegistrar']/method[@name='getComponents' and count(parameter)=0]"
			[Register ("getComponents", "()Ljava/util/List;", "")]
			get {
				const string __id = "getComponents.()Ljava/util/List;";
				try {
					var __rm = _members.InstanceMethods.InvokeNonvirtualObjectMethod (__id, this, null);
					return (global::System.Collections.Generic.IList <global:: Firebase.Components.Component >) global::Android.Runtime.JavaList.FromJniHandle (__rm.Handle, JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}

	}
}
