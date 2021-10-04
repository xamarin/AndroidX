using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace Xamarin.Google.Crypto.Tink.Shaded.Protobuf 
{

	// Metadata.xml XPath class reference: path="/api/package[@name='com.google.crypto.tink.shaded.protobuf']/class[@name='LazyStringArrayList']"
	// [global::Android.Runtime.Register ("com/google/crypto/tink/shaded/protobuf/LazyStringArrayList", DoNotGenerateAcw=true)]
	public partial class LazyStringArrayList //: global::Java.Util.AbstractList, global::Xamarin.Google.Crypto.Tink.Shaded.Protobuf.ILazyStringList, global::Java.Util.IRandomAccess {
    {
		[Register ("get", "(I)Ljava/lang/Object;", "GetGet_IHandler")]
		public override unsafe Java.Lang.Object Get (int index)
		{
			const string __id = "get.(I)Ljava/lang/String;";
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [1];
				__args [0] = new JniArgumentValue (index);
				var __rm = _members.InstanceMethods.InvokeVirtualObjectMethod (__id, this, __args);
				return (Java.Lang.Object) JNIEnv.GetString (__rm.Handle, JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

    }
}
