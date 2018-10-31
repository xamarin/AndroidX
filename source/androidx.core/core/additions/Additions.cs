using System;
using System.Collections;
using Android.Runtime;

//namespace Android.Support.V4.Util
//{
//	public partial class ArrayMap
//	{
//		static Delegate cb_entrySet;
//#pragma warning disable 0169
//		static Delegate GetEntrySetHandler()
//		{
//			if (cb_entrySet == null)
//				cb_entrySet = JNINativeWrapper.CreateDelegate((Func<IntPtr, IntPtr, IntPtr>)n_EntrySet);
//			return cb_entrySet;
//		}

//		static IntPtr n_EntrySet(IntPtr jnienv, IntPtr native__this)
//		{
//			global::Android.Support.V4.Util.ArrayMap __this = global::Java.Lang.Object.GetObject<global::Android.Support.V4.Util.ArrayMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//			return global::Android.Runtime.JavaSet<global::Java.Util.IMapEntry>.ToLocalJniHandle(__this.EntrySet());
//		}
//#pragma warning restore 0169

//		static IntPtr id_entrySet;
//		// Metadata.xml XPath method reference: path="/api/package[@name='android.support.v4.util']/class[@name='ArrayMap']/method[@name='entrySet' and count(parameter)=0]"
//		[Register("entrySet", "()Ljava/util/Set;", "GetEntrySetHandler")]
//		public virtual unsafe global::System.Collections.ICollection EntrySet()
//		{
//			if (id_entrySet == IntPtr.Zero)
//				id_entrySet = JNIEnv.GetMethodID(class_ref, "entrySet", "()Ljava/util/Set;");
//			try
//			{

//				if (GetType() == ThresholdType)
//					return (ICollection)global::Android.Runtime.JavaSet<global::Java.Util.IMapEntry>.FromJniHandle(JNIEnv.CallObjectMethod(Handle, id_entrySet), JniHandleOwnership.TransferLocalRef);
//				else
//					return (ICollection)global::Android.Runtime.JavaSet<global::Java.Util.IMapEntry>.FromJniHandle(JNIEnv.CallNonvirtualObjectMethod(Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "entrySet", "()Ljava/util/Set;")), JniHandleOwnership.TransferLocalRef);
//			}
//			finally
//			{
//			}
//		}
//	}
//}

namespace Android.Support.V4.Text
{
	public partial class PrecomputedTextCompat
	{
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public System.Collections.Generic.IEnumerator<char> GetEnumerator()
		{
			// TODO: Fix
			throw new NotImplementedException();
		}
	}
}



