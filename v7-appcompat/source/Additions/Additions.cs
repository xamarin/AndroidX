using System;
using Android.Runtime;

namespace Android.Support.V7.View.Menu
{
    public partial class MenuAdapter
    {
        static Delegate cb_getItem_I;
#pragma warning disable 0169
        static Delegate GetGetItem_IHandler ()
        {
            if (cb_getItem_I == null)
                cb_getItem_I = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, int, Java.Lang.Object>)n_GetItem_I);
            return cb_getItem_I;
        }

        static Java.Lang.Object n_GetItem_I (IntPtr jnienv, IntPtr native__this, int position)
        {
            global::Android.Support.V7.View.Menu.MenuAdapter __this = global::Java.Lang.Object.GetObject<global::Android.Support.V7.View.Menu.MenuAdapter> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            return __this.GetItem (position);
        }
#pragma warning restore 0169

        static IntPtr id_getItem_I;
        // Metadata.xml XPath method reference: path="/api/package[@name='android.support.v7.view.menu']/class[@name='MenuAdapter']/method[@name='getItemId' and count(parameter)=1 and parameter[1][@type='int']]"
        [Register ("getItemId", "(I)Ljava/lang/Object;", "GetGetItem_IHandler")]
        public override unsafe Java.Lang.Object GetItem (int position)
        {
            if (id_getItem_I == IntPtr.Zero)
                id_getItem_I = JNIEnv.GetMethodID (class_ref, "getItem", "(I)Ljava/lang/Object;");
            try {
                JValue* __args = stackalloc JValue [1];
                __args [0] = new JValue (position);


                Java.Lang.Object __ret;
                if (GetType () == ThresholdType)
                    __ret = global::Java.Lang.Object.GetObject<Java.Lang.Object> (
                        JNIEnv.CallObjectMethod (((global::Java.Lang.Object)this).Handle, id_getItem_I, __args), 
                        JniHandleOwnership.TransferLocalRef);
                else
                    __ret = global::Java.Lang.Object.GetObject<Java.Lang.Object> (
                        JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object)this).Handle, 
                        ThresholdClass, 
                         JNIEnv.GetMethodID (ThresholdClass, "getItem", "(I)Ljava/lang/Object;"), __args), JniHandleOwnership.TransferLocalRef);
                return __ret;
            } finally {
            }
        }
    }
}