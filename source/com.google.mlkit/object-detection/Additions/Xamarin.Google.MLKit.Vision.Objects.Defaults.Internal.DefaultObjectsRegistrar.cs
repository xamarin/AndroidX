using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace Xamarin.Google.MLKit.Vision.Objects.Defaults.Internal 
{

	// Metadata.xml XPath class reference: path="/api/package[@name='com.google.mlkit.vision.objects.defaults.internal']/class[@name='DefaultObjectsRegistrar']"
	// [global::Android.Runtime.Register ("com/google/mlkit/vision/objects/defaults/internal/DefaultObjectsRegistrar", DoNotGenerateAcw=true)]
	public partial class DefaultObjectsRegistrar //: global::Java.Lang.Object, global::Firebase.Components.IComponentRegistrar 
    {
		public unsafe System.Collections.Generic.IList <Firebase.Components.Component> Components 
        {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.google.mlkit.vision.objects.defaults.internal']/class[@name='DefaultObjectsRegistrar']/method[@name='getComponents' and count(parameter)=0]"
			[Register ("getComponents", "()Ljava/util/List;", "")]
			get {
				const string __id = "getComponents.()Ljava/util/List;";
				try {
					var __rm = _members.InstanceMethods.InvokeNonvirtualObjectMethod (__id, this, null);
					return (System.Collections.Generic.IList<Firebase.Components.Component>) global::Android.Runtime.JavaList.FromJniHandle (__rm.Handle, JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
		}
    }
}