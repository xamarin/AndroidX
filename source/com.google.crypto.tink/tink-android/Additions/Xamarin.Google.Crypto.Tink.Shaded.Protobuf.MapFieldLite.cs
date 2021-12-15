

using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace Xamarin.Google.Crypto.Tink.Shaded.Protobuf 
{

	// Metadata.xml XPath class reference: path="/api/package[@name='com.google.crypto.tink.shaded.protobuf']/class[@name='MapFieldLite']"
	// [global::Android.Runtime.Register ("com/google/crypto/tink/shaded/protobuf/MapFieldLite", DoNotGenerateAcw=true)]
	// [global::Java.Interop.JavaTypeParameters (new string [] {"K", "V"})]
	public sealed partial class MapFieldLite // : global::Java.Util.LinkedHashMap 
    {
		// Metadata.xml XPath method reference: path="/api/package[@name='com.google.crypto.tink.shaded.protobuf']/class[@name='MapFieldLite']/method[@name='entrySet' and count(parameter)=0]"
		[Register ("entrySet", "()Ljava/util/Set;", "")]
		public override unsafe global::System.Collections.ICollection EntrySet ()
		{
			const string __id = "entrySet.()Ljava/util/Set;";
			try {
				var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod (__id, this, null);
				return (System.Collections.ICollection) global::Android.Runtime.JavaSet<global::Java.Util.IMapEntry>.FromJniHandle (__rm.Handle, JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

    }
}