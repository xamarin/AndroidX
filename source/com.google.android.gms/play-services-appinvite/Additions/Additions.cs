
using System;
using Android.Runtime;

namespace Android.Gms.People.ProtoModel
{
	internal static class FreezeMethodImplementor
	{
		internal static Java.Lang.Object Freeze(ref IntPtr id_freeze, IntPtr class_ref, IntPtr Handle)
		{
			if (id_freeze == IntPtr.Zero)
				id_freeze = JNIEnv.GetMethodID(class_ref, "freeze", "()Ljava/lang/Object;");
			return (Java.Lang.Object)global::Java.Lang.Object.GetObject<global::Java.Lang.Object>(JNIEnv.CallObjectMethod(Handle, id_freeze), JniHandleOwnership.TransferLocalRef);
		}
	}
}
