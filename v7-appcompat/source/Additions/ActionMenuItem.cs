//using System;
//using Android.Runtime;
//
//namespace Android.Support.V7.Internal.View.Menu 
//{
//    public partial class ActionMenuItem
//    {
//        static IntPtr id_setShowAsActionINT_I;
//        // Metadata.xml XPath method reference: path="/api/package[@name='android.support.v7.internal.view.menu']/class[@name='ActionMenuItem']/method[@name='setShowAsAction' and count(parameter)=1 and parameter[1][@type='int']]"
//        [Register ("setShowAsAction", "(I)V", "GetSetShowAsAction_IHandler")]
//        //public virtual void SetShowAsAction ([global::Android.Runtime.GeneratedEnum] global::Android.Views.ShowAsAction show)
//        public virtual void SetShowAsAction (int show)
//        {
//            if (id_setShowAsActionINT_I == IntPtr.Zero)
//                id_setShowAsActionINT_I = JNIEnv.GetMethodID (class_ref, "setShowAsAction", "(I)V");
//            try {
//
//                if (GetType () == ThresholdType)
//                    JNIEnv.CallVoidMethod  (Handle, id_setShowAsActionINT_I, new JValue ((int) show));
//                else
//                    JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setShowAsAction", "(I)V"), new JValue ((int) show));
//            } finally {
//            }
//        }
//
//
////        static IntPtr id_setShowAsActionFlagsENUM_I;
////        // Metadata.xml XPath method reference: path="/api/package[@name='android.support.v7.internal.view.menu']/class[@name='ActionMenuItem']/method[@name='setShowAsActionFlags' and count(parameter)=1 and parameter[1][@type='int']]"
////        [Register ("setShowAsActionFlags", "(I)Landroid/support/v4/internal/view/SupportMenuItem;", "GetSetShowAsActionFlags_IHandler")]
////        public virtual global::Android.Views.IMenuItem SetShowAsActionFlags (Android.Views.ShowAsAction showAsAction)
////        {
////            if (id_setShowAsActionFlagsENUM_I == IntPtr.Zero)
////                id_setShowAsActionFlagsENUM_I = JNIEnv.GetMethodID (class_ref, "setShowAsActionFlags", "(I)Landroid/support/v4/internal/view/SupportMenuItem;");
////            try {
////
////                if (GetType () == ThresholdType)
////                    return global::Java.Lang.Object.GetObject<global::Android.Support.V4.Internal.View.ISupportMenuItem> (JNIEnv.CallObjectMethod  (Handle, id_setShowAsActionFlagsENUM_I, new JValue ((int)showAsAction)), JniHandleOwnership.TransferLocalRef);
////                else
////                    return global::Java.Lang.Object.GetObject<global::Android.Support.V4.Internal.View.ISupportMenuItem> (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setShowAsActionFlags", "(I)Landroid/support/v4/internal/view/SupportMenuItem;"), new JValue ((int)showAsAction)), JniHandleOwnership.TransferLocalRef);
////            } finally {
////            }
////        }
//    }
//
//    public partial class ActionMenuItemView 
//    {
//        public void SetEnabled (bool enabled) {
//            Enabled = enabled;
//        }
//    }
//}
