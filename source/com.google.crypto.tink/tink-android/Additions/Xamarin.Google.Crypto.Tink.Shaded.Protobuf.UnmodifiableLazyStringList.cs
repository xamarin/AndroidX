using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace Xamarin.Google.Crypto.Tink.Shaded.Protobuf 
{

	// Metadata.xml XPath class reference: path="/api/package[@name='com.google.crypto.tink.shaded.protobuf']/class[@name='UnmodifiableLazyStringList']"
	// [global::Android.Runtime.Register ("com/google/crypto/tink/shaded/protobuf/UnmodifiableLazyStringList", DoNotGenerateAcw=true)]
	public partial class UnmodifiableLazyStringList // : global::Java.Util.AbstractList, global::Xamarin.Google.Crypto.Tink.Shaded.Protobuf.ILazyStringList, global::Java.Util.IRandomAccess 
    {
		// Metadata.xml XPath method reference: path="/api/package[@name='com.google.crypto.tink.shaded.protobuf']/class[@name='UnmodifiableLazyStringList']/method[@name='get' and count(parameter)=1 and parameter[1][@type='int']]"
		[Register ("get", "(I)Ljava/lang/Object;", "GetGet_IHandler")]
		public override unsafe global::Java.Lang.Object Get (int index)
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