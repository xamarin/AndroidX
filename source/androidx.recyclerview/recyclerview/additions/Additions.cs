//using System;
//using Android.Runtime;

//namespace Android.Support.V7.Widget
//{
//    public partial class RecyclerView
//    {
//        public partial class InterceptTouchEventEventArgs
//        {
//            public RecyclerView RecyclerView {
//                get { return this.Rv; }
//            }
//        }

//        public partial class RequestDisallowInterceptTouchEventEventArgs
//        {
//            public bool Disallow {
//                get { return this.DisallowIntercept; }
//            }
//        }

//        public partial class TouchEventEventArgs
//        {
//            public RecyclerView RecyclerView {
//                get { return this.Rv; }
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
