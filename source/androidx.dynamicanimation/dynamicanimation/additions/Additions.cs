// using System;
// using Android.Runtime;

// namespace Android.Support.Animation
// {
// 	internal static class __JniCtorUtil
// 	{
// 		internal static unsafe void CtorImpl(Java.Lang.Object sender, Type classType, IntPtr classRef, IntPtr methodId, string jniSignature, JValue* args, Action<IntPtr, JniHandleOwnership> setHandle)
// 		{
// 			if (sender.Handle != IntPtr.Zero)
// 				return;

// 			try
// 			{
// 				if (((object)sender).GetType() != classType)
// 				{
// 					setHandle(
// 						global::Android.Runtime.JNIEnv.StartCreateInstance(((object)sender).GetType(), jniSignature, args),
// 							JniHandleOwnership.TransferLocalRef);
// 					global::Android.Runtime.JNIEnv.FinishCreateInstance(((global::Java.Lang.Object)sender).Handle, jniSignature, args);
// 					return;
// 				}

// 				if (methodId == IntPtr.Zero)
// 					methodId = JNIEnv.GetMethodID(classRef, "<init>", jniSignature);
// 				setHandle(
// 					global::Android.Runtime.JNIEnv.StartCreateInstance(classRef, methodId, args),
// 						JniHandleOwnership.TransferLocalRef);
// 				JNIEnv.FinishCreateInstance(((global::Java.Lang.Object)sender).Handle, classRef, methodId, args);
// 			}
// 			finally
// 			{
// 			}
// 		}
// 	}

// 	public partial class SpringAnimation
// 	{
// 		private const string CTOR_1 = "(Ljava/lang/Object;Landroid/support/animation/FloatPropertyCompat;)V";
// 		static IntPtr id_ctor_1;

// 		[Register(".ctor", CTOR_1, "")]
// 		public unsafe SpringAnimation(global::Java.Lang.Object @object, FloatPropertyCompat @property)
// 			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
// 		{
// 			JValue* __args = stackalloc JValue[2];
// 			__args[0] = new JValue(@object);
// 			__args[1] = new JValue(@property);

// 			__JniCtorUtil.CtorImpl(this, typeof(SpringAnimation), class_ref, id_ctor_1, CTOR_1, __args, SetHandle);
// 		}


// 		private const string JNI_CTOR_2 = "(Ljava/lang/Object;Landroid/support/animation/FloatPropertyCompat;F)V";
// 		static IntPtr id_ctor_2;

// 		[Register(".ctor", JNI_CTOR_2, "")]
// 		public unsafe SpringAnimation(global::Java.Lang.Object @object, FloatPropertyCompat @property, float finalPosition)
// 			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
// 		{
// 			JValue* __args = stackalloc JValue[3];
// 			__args[0] = new JValue(@object);
// 			__args[1] = new JValue(@property);
// 			__args[2] = new JValue(finalPosition);

// 			__JniCtorUtil.CtorImpl(this, typeof(SpringAnimation), class_ref, id_ctor_2, JNI_CTOR_2, __args, SetHandle);
// 		}
// 	}

// 	public partial class FlingAnimation
// 	{
// 		private const string JNI_CTOR_1 = "(Ljava/lang/Object;Landroid/support/animation/FloatPropertyCompat;)V";
// 		static IntPtr id_ctor_1;

// 		[Register(".ctor", JNI_CTOR_1, "")]
// 		public unsafe FlingAnimation(global::Java.Lang.Object @object, FloatPropertyCompat @property)
// 			: base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
// 		{
// 			JValue* __args = stackalloc JValue[2];
// 			__args[0] = new JValue(@object);
// 			__args[1] = new JValue(@property);

// 			__JniCtorUtil.CtorImpl(this, typeof(FlingAnimation), class_ref, id_ctor_1, JNI_CTOR_1, __args, SetHandle);
// 		}
// 	}
// }
