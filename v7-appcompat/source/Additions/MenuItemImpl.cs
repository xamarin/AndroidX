//using System;
//using Android.Runtime;
//
//namespace Android.Support.V7.Internal.View.Menu 
//{
//    public partial class MenuItemImpl
//    {
//        static IntPtr id_setShowAsActionINT_I;
//        // Metadata.xml XPath method reference: path="/api/package[@name='android.support.v7.internal.view.menu']/class[@name='MenuItemImpl']/method[@name='setShowAsAction' and count(parameter)=1 and parameter[1][@type='int']]"
//        [Register ("setShowAsAction", "(I)V", "")]
//        //public void SetShowAsAction ([global::Android.Runtime.GeneratedEnum] global::Android.Views.ShowAsAction actionEnum)
//        public void SetShowAsAction (int actionValue)
//        {
//            if (id_setShowAsActionINT_I == IntPtr.Zero)
//                id_setShowAsActionINT_I = JNIEnv.GetMethodID (class_ref, "setShowAsAction", "(I)V");
//            try {
//                JNIEnv.CallVoidMethod  (Handle, id_setShowAsActionINT_I, new JValue ((int) actionValue));
//            } finally {
//            }
//        }
//
//
//
////        static IntPtr id_setShowAsActionFlagsENUM_I;
////        // Metadata.xml XPath method reference: path="/api/package[@name='android.support.v7.internal.view.menu']/class[@name='MenuItemImpl']/method[@name='setShowAsActionFlags' and count(parameter)=1 and parameter[1][@type='int']]"
////        [Register ("setShowAsActionFlags", "(I)Landroid/support/v4/internal/view/SupportMenuItem;", "")]
////        public global::Android.Views.IMenuItem SetShowAsActionFlags (Android.Views.ShowAsAction showAsAction)
////        {
////            if (id_setShowAsActionFlagsENUM_I == IntPtr.Zero)
////                id_setShowAsActionFlagsENUM_I = JNIEnv.GetMethodID (class_ref, "setShowAsActionFlags", "(I)Landroid/support/v4/internal/view/SupportMenuItem;");
////            try {
////                return global::Java.Lang.Object.GetObject<global::Android.Views.IMenuItem> (JNIEnv.CallObjectMethod  (Handle, id_setShowAsActionFlagsENUM_I, new JValue ((int)showAsAction)), JniHandleOwnership.TransferLocalRef);
////            } finally {
////            }
////        }
//    }
//}
//
