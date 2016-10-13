using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Android.Support.V4.Widget
{
    // Metadata.xml XPath class reference: path="/api/package[@name='android.support.v4.widget']/class[@name='SwipeRefreshLayout']"
    public partial class SwipeRefreshLayout
    {
        static Delegate cb_setEnabled_Z;
#pragma warning disable 0169
        static Delegate GetSetEnabled_ZHandler ()
        {
            if (cb_setEnabled_Z == null)
                cb_setEnabled_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, bool>)n_SetEnabled_Z);
            return cb_setEnabled_Z;
        }

        static void n_SetEnabled_Z (IntPtr jnienv, IntPtr native__this, bool enabled)
        {
            global::Android.Support.V4.Widget.SwipeRefreshLayout __this = global::Java.Lang.Object.GetObject<global::Android.Support.V4.Widget.SwipeRefreshLayout> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            __this.SetEnabled (enabled);
        }
#pragma warning restore 0169

        static IntPtr id_setEnabled_Z;
        // Metadata.xml XPath method reference: path="/api/package[@name='android.support.v4.widget']/class[@name='SwipeRefreshLayout']/method[@name='setEnabled' and count(parameter)=1 and parameter[1][@type='boolean']]"
        [Register ("setEnabled", "(Z)V", "GetSetEnabled_ZHandler")]
        public unsafe void SetEnabled (bool enabled)
        {
            if (id_setEnabled_Z == IntPtr.Zero)
                id_setEnabled_Z = JNIEnv.GetMethodID (class_ref, "setEnabled", "(Z)V");
            try {
                JValue* __args = stackalloc JValue [1];
                __args [0] = new JValue (enabled);

                if (GetType () == ThresholdType)
                    JNIEnv.CallVoidMethod (Handle, id_setEnabled_Z, __args);
                else
                    JNIEnv.CallNonvirtualVoidMethod (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setEnabled", "(Z)V"), __args);
            } finally {

            }
        }
    }
}



namespace Android.Support.V4.View
{
    // Metadata.xml XPath class reference: path="/api/package[@name='android.support.v4.view']/class[@name='PagerTabStrip']"
    public partial class PagerTabStrip
    {
        static Delegate cb_setBackgroundColor_I;
#pragma warning disable 0169
        static Delegate GetSetBackgroundColor_IHandler ()
        {
            if (cb_setBackgroundColor_I == null)
                cb_setBackgroundColor_I = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, int>)n_SetBackgroundColor_I);
            return cb_setBackgroundColor_I;
        }

        static void n_SetBackgroundColor_I (IntPtr jnienv, IntPtr native__this, int color)
        {
            global::Android.Support.V4.View.PagerTabStrip __this = global::Java.Lang.Object.GetObject<global::Android.Support.V4.View.PagerTabStrip> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            __this.SetBackgroundColor (color);
        }
#pragma warning restore 0169

        static IntPtr id_setBackgroundColor_I;
        // Metadata.xml XPath method reference: path="/api/package[@name='android.support.v4.view']/class[@name='PagerTabStrip']/method[@name='setBackgroundColor' and count(parameter)=1 and parameter[1][@type='int']]"
        [Register ("setBackgroundColor", "(I)V", "GetSetBackgroundColor_IHandler")]
        public unsafe void SetBackgroundColor (int color)
        {
            if (id_setBackgroundColor_I == IntPtr.Zero)
                id_setBackgroundColor_I = JNIEnv.GetMethodID (class_ref, "setBackgroundColor", "(I)V");
            try {
                JValue* __args = stackalloc JValue [1];
                __args [0] = new JValue (color);

                if (GetType () == ThresholdType)
                    JNIEnv.CallVoidMethod (Handle, id_setBackgroundColor_I, __args);
                else
                    JNIEnv.CallNonvirtualVoidMethod (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setBackgroundColor", "(I)V"), __args);
            } finally {
            }
        }
    }
}