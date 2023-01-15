using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Wear.Watchface.Style 
{
	// Metadata.xml XPath class reference: path="/api/package[@name='androidx.wear.watchface.style']/class[@name='UserStyle']"
	// [global::Android.Runtime.Register ("androidx/wear/watchface/style/UserStyle", DoNotGenerateAcw=true)]
	public sealed partial class UserStyle // : global::Java.Lang.Object, global::Java.Util.IMap, global::Kotlin.Jvm.Internal.Markers.IKMappedMarker 
    {
 		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.wear.watchface.style']/class[@name='UserStyle']/method[@name='entrySet' and count(parameter)=0]"
		[Register ("entrySet", "()Ljava/util/Set;", "")]
		public unsafe global::System.Collections.ICollection? EntrySet ()
		{
			const string __id = "entrySet.()Ljava/util/Set;";
			try {
				var __rm = _members.InstanceMethods.InvokeNonvirtualObjectMethod (__id, this, null);
				return (System.Collections.ICollection?) global::Android.Runtime.JavaSet<global::Java.Util.IMapEntry>.FromJniHandle (__rm.Handle, JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.wear.watchface.style']/class[@name='UserStyle']/method[@name='keySet' and count(parameter)=0]"
		[Register ("keySet", "()Ljava/util/Set;", "")]
		public unsafe global::System.Collections.ICollection? KeySet ()
		{
			const string __id = "keySet.()Ljava/util/Set;";
			try {
				var __rm = _members.InstanceMethods.InvokeNonvirtualObjectMethod (__id, this, null);
				return (System.Collections.ICollection?) global::Android.Runtime.JavaSet<global::AndroidX.Wear.Watchface.Style.UserStyleSetting>.FromJniHandle (__rm.Handle, JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.wear.watchface.style']/class[@name='UserStyle']/method[@name='values' and count(parameter)=0]"
		[Register ("values", "()Ljava/util/Collection;", "")]
		public unsafe global::System.Collections.ICollection? Values ()
		{
			const string __id = "values.()Ljava/util/Collection;";
			try {
				var __rm = _members.InstanceMethods.InvokeNonvirtualObjectMethod (__id, this, null);
				return (System.Collections.ICollection?) global::Android.Runtime.JavaCollection<global::AndroidX.Wear.Watchface.Style.UserStyleSetting.Option>.FromJniHandle (__rm.Handle, JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}
   }
}