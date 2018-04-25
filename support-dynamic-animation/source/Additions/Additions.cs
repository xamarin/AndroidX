using System;
using Android.Runtime;

namespace Android.Support.Animation
{
	internal static class __JniCtorUtil
	{
		internal static unsafe void CtorImpl(Java.Lang.Object sender, Type classType, IntPtr classRef, IntPtr methodId, string jniSignature, JValue* args, Action<IntPtr, JniHandleOwnership> setHandle)
		{
			if (sender.Handle != IntPtr.Zero)
				return;

			try
			{
				if (((object)sender).GetType() != classType)
				{
					setHandle(
						global::Android.Runtime.JNIEnv.StartCreateInstance(((object)sender).GetType(), jniSignature, args),
							JniHandleOwnership.TransferLocalRef);
					global::Android.Runtime.JNIEnv.FinishCreateInstance(((global::Java.Lang.Object)sender).Handle, jniSignature, args);
					return;
				}

				if (methodId == IntPtr.Zero)
					methodId = JNIEnv.GetMethodID(classRef, "<init>", jniSignature);
				setHandle(
					global::Android.Runtime.JNIEnv.StartCreateInstance(classRef, methodId, args),
						JniHandleOwnership.TransferLocalRef);
				JNIEnv.FinishCreateInstance(((global::Java.Lang.Object)sender).Handle, classRef, methodId, args);
			}
			finally
			{
			}
		}
	}
}
