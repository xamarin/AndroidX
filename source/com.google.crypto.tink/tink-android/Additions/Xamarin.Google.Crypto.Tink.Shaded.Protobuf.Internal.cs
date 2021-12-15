using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace Xamarin.Google.Crypto.Tink.Shaded.Protobuf 
{
	// Metadata.xml XPath class reference: path="/api/package[@name='com.google.crypto.tink.shaded.protobuf']/class[@name='Internal']"
	// [global::Android.Runtime.Register ("com/google/crypto/tink/shaded/protobuf/Internal", DoNotGenerateAcw=true)]
	public sealed partial class Internal // : global::Java.Lang.Object 
    {
		// Metadata.xml XPath class reference: path="/api/package[@name='com.google.crypto.tink.shaded.protobuf']/class[@name='Internal.MapAdapter']"
		// [global::Android.Runtime.Register ("com/google/crypto/tink/shaded/protobuf/Internal$MapAdapter", DoNotGenerateAcw=true)]
		// [global::Java.Interop.JavaTypeParameters (new string [] {"K", "V", "RealValue"})]
		public partial class MapAdapter // : global::Java.Util.AbstractMap 
        {

			// Metadata.xml XPath method reference: path="/api/package[@name='com.google.crypto.tink.shaded.protobuf']/class[@name='Internal.MapAdapter']/method[@name='entrySet' and count(parameter)=0]"
			[Register ("entrySet", "()Ljava/util/Set;", "GetEntrySetHandler")]
			public override unsafe global::System.Collections.ICollection EntrySet ()
			{
				const string __id = "entrySet.()Ljava/util/Set;";
				try {
					var __rm = _members.InstanceMethods.InvokeVirtualObjectMethod (__id, this, null);
					return (System.Collections.ICollection) global::Android.Runtime.JavaSet<global::Java.Util.IMapEntry>.FromJniHandle (__rm.Handle, JniHandleOwnership.TransferLocalRef);
				} finally {
				}
			}
        }
    }

}