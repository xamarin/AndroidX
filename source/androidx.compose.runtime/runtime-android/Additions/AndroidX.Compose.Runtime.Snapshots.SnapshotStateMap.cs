using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Compose.Runtime.Snapshots
{
	// Metadata.xml XPath class reference: path="/api/package[@name='androidx.compose.runtime.snapshots']/class[@name='SnapshotStateMap']"
	// [global::Android.Runtime.Register ("androidx/compose/runtime/snapshots/SnapshotStateMap", DoNotGenerateAcw=true)]
	// [global::Java.Interop.JavaTypeParameters (new string [] {"K", "V"})]
	public sealed partial class SnapshotStateMap //: global::Java.Lang.Object, global::AndroidX.Compose.Runtime.Snapshots.IStateObject, global::Java.Util.IMap, global::Kotlin.Jvm.Internal.Markers.IKMutableMap 
    {
		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.compose.runtime.snapshots']/class[@name='SnapshotStateMap']/method[@name='entrySet' and count(parameter)=0]"
		[Register ("entrySet", "()Ljava/util/Set;", "")]
		public unsafe global::System.Collections.ICollection EntrySet ()
		{
			const string __id = "entrySet.()Ljava/util/Set;";
			try {
				var __rm = _members.InstanceMethods.InvokeNonvirtualObjectMethod (__id, this, null);
				return (System.Collections.ICollection) global::Android.Runtime.JavaSet<global::Java.Util.IMapEntry>.FromJniHandle (__rm.Handle, JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}
    }
}