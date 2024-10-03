using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace Xamarin.Google.MLKit.Vision.BarCode.Internal 
{

	// Metadata.xml XPath class reference: path="/api/package[@name='com.google.mlkit.vision.barcode.internal']/class[@name='BarcodeRegistrar']"
	// [global::Android.Runtime.Register ("com/google/mlkit/vision/barcode/internal/BarcodeRegistrar", DoNotGenerateAcw=true)]
	public partial class BarcodeRegistrar //: global::Java.Lang.Object, global::Firebase.Components.IComponentRegistrar 
	{
		public unsafe System.Collections.Generic.IList<Firebase.Components.Component> Components 
        {
			// Metadata.xml XPath method reference: path="/api/package[@name='com.google.mlkit.vision.barcode.internal']/class[@name='BarcodeRegistrar']/method[@name='getComponents' and count(parameter)=0]"
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
