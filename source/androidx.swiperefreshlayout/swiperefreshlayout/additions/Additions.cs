//using System;
//using System.Collections.Generic;
//using Android.Runtime;

//namespace Android.Support.V4.Widget
//{
//    // Metadata.xml XPath class reference: path="/api/package[@name='android.support.v4.widget']/class[@name='SwipeRefreshLayout']"
//    public partial class SwipeRefreshLayout
//    {
//        static Delegate cb_setEnabled_Z;
//#pragma warning disable 0169
//        static Delegate GetSetEnabled_ZHandler ()
//        {
//            if (cb_setEnabled_Z == null)
//                cb_setEnabled_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, bool>)n_SetEnabled_Z);
//            return cb_setEnabled_Z;
//        }

//        static void n_SetEnabled_Z (IntPtr jnienv, IntPtr native__this, bool enabled)
//        {
//            global::Android.Support.V4.Widget.SwipeRefreshLayout __this = global::Java.Lang.Object.GetObject<global::Android.Support.V4.Widget.SwipeRefreshLayout> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//            __this.SetEnabled (enabled);
//        }
//#pragma warning restore 0169

//        static IntPtr id_setEnabled_Z;
//        // Metadata.xml XPath method reference: path="/api/package[@name='android.support.v4.widget']/class[@name='SwipeRefreshLayout']/method[@name='setEnabled' and count(parameter)=1 and parameter[1][@type='boolean']]"
//        [Register ("setEnabled", "(Z)V", "GetSetEnabled_ZHandler")]
//        public unsafe void SetEnabled (bool enabled)
//        {
//            if (id_setEnabled_Z == IntPtr.Zero)
//                id_setEnabled_Z = JNIEnv.GetMethodID (class_ref, "setEnabled", "(Z)V");
//            try {
//                JValue* __args = stackalloc JValue [1];
//                __args [0] = new JValue (enabled);

//                if (GetType () == ThresholdType)
//                    JNIEnv.CallVoidMethod (Handle, id_setEnabled_Z, __args);
//                else
//                    JNIEnv.CallNonvirtualVoidMethod (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setEnabled", "(Z)V"), __args);
//            } finally {

//            }
//        }


//        private static IntPtr id_isNestedScrollingEnabled = IntPtr.Zero;
//        private static IntPtr id_setNestedScrollingEnabled = IntPtr.Zero;

//        public unsafe virtual bool NestedScrollingEnabled {
//            [Register("isNestedScrollingEnabled", "()Z", "GetIsNestedScrollingEnabledHandler")]
//            get {
//                if (id_isNestedScrollingEnabled == IntPtr.Zero) {
//                    id_isNestedScrollingEnabled = JNIEnv.GetMethodID(class_ref, "isNestedScrollingEnabled", "()Z");
//                }
//                if (base.GetType() == ThresholdType) {
//                    return JNIEnv.CallBooleanMethod(base.Handle, id_isNestedScrollingEnabled);
//                }
//                return JNIEnv.CallNonvirtualBooleanMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "isNestedScrollingEnabled", "()Z"));
//            }

//            [Register("setNestedScrollingEnabled", "(Z)V", "GetSetNestedScrollingEnabledHandler")]
//            set {
//                if (id_setNestedScrollingEnabled == IntPtr.Zero) {
//                    id_setNestedScrollingEnabled = JNIEnv.GetMethodID(class_ref, "setNestedScrollingEnabled", "(Z)V");
//                }
//                JValue* ptr = stackalloc JValue[1];
//                *ptr = new JValue(value);
//                if (base.GetType() == ThresholdType) {
//                    JNIEnv.CallVoidMethod(base.Handle, id_setNestedScrollingEnabled, ptr);
//                    return;
//                }
//                JNIEnv.CallNonvirtualVoidMethod(base.Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setNestedScrollingEnabled", "(Z)V"), ptr);
//            }
//        }
//    }
//}