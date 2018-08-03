using System;
using Android.Runtime;

namespace Android.Support.V17.Leanback.App
{
	public partial class BackgroundManager 
	{
        public partial class BitmapDrawable
		{
			#pragma warning disable 108
			public partial class ConstantState
			{
				public override global::Android.Content.PM.ConfigChanges ChangingConfigurations 
				{
					get {
						return (global::Android.Content.PM.ConfigChanges)0;
					}
				}
			}

//            static IntPtr id_setColorFilter;
//            [Register ("setColorFilter", "(Landroid.graphics.ColorFilter;)V", "")]
//            public override void SetColorFilter (Android.Graphics.ColorFilter filter)
//            {
//                if (id_setColorFilter == IntPtr.Zero)
//                    id_setColorFilter = JNIEnv.GetMethodID (class_ref, "setColorFilter", "(Landroid.graphics.ColorFilter;)V");
//                try {
//                    JNIEnv.CallVoidMethod  (Handle, id_setColorFilter, new JValue (filter));
//                } finally {
//                }
//            }
		}
	}
}


//namespace Android.Support.V17.Leanback.Animation {
//
//    // Metadata.xml XPath class reference: path="/api/package[@name='android.support.v17.leanback.animation']/class[@name='UntargetableAnimatorSet']"
//    public partial class UntargetableAnimatorSet 
//    {
////        static IntPtr id_getStartDelay;
////        static IntPtr id_setStartDelay_J;
////
////        public override unsafe long StartDelay {
////            // Metadata.xml XPath method reference: path="/api/package[@name='android.support.v17.leanback.animation']/class[@name='UntargetableAnimatorSet']/method[@name='getStartDelay' and count(parameter)=0]"
////            [Register ("getStartDelay", "()J", "GetGetStartDelayHandler")]
////            get {
////                if (id_getStartDelay == IntPtr.Zero)
////                    id_getStartDelay = JNIEnv.GetMethodID (class_ref, "getStartDelay", "()J");
////                try {
////
////                    if (GetType () == ThresholdType)
////                        return JNIEnv.CallLongMethod  (Handle, id_getStartDelay);
////                    else
////                        return JNIEnv.CallNonvirtualLongMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getStartDelay", "()J"));
////                } finally {
////                }
////            }
////            // Metadata.xml XPath method reference: path="/api/package[@name='android.support.v17.leanback.animation']/class[@name='UntargetableAnimatorSet']/method[@name='setStartDelay' and count(parameter)=1 and parameter[1][@type='long']]"
////            [Register ("setStartDelay", "(J)V", "GetSetStartDelay_JHandler")]
////            set {
////                if (id_setStartDelay_J == IntPtr.Zero)
////                    id_setStartDelay_J = JNIEnv.GetMethodID (class_ref, "setStartDelay", "(J)V");
////                try {
////                    JValue* __args = stackalloc JValue [1];
////                    __args [0] = new JValue (value);
////
////                    if (GetType () == ThresholdType)
////                        JNIEnv.CallVoidMethod  (Handle, id_setStartDelay_J, __args);
////                    else
////                        JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setStartDelay", "(J)V"), __args);
////                } finally {
////                }
////            }
////        }
//
//
//        static IntPtr id_getStartDelay;
//        static IntPtr id_setStartDelay;
//
//        public override long StartDelay {
//            [Register ("getStartDelay", "()J", "GetGetStartDelayHandler")]
//            get {
//                if (id_getStartDelay == IntPtr.Zero)
//                    id_getStartDelay = JNIEnv.GetMethodID (class_ref, "getStartDelay", "()J");
//
//                return JNIEnv.CallLongMethod (Handle, id_getStartDelay);
//            }
//
//
//            [Register ("setStartDelay", "(J)V", "")]
//            set {
//                if (id_setStartDelay == IntPtr.Zero)
//                    id_setStartDelay = JNIEnv.GetMethodID (class_ref, "setStartDelay", "(J)V");
//                try {
//                    JNIEnv.CallVoidMethod  (Handle, id_setStartDelay, new JValue ((long) value));
//                } finally {
//                }
//            }
//        }
//
//    }
//}