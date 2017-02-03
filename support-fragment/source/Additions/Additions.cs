using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Android.Support.V4.App
{
    public partial class FragmentActivity
    {
        static Delegate cb_onRequestPermissionsResult_IarrayLjava_lang_String_arrayI;
#pragma warning disable 0169
        static Delegate GetOnRequestPermissionsResult_IarrayLjava_lang_String_arrayIHandler()
        {
            if (cb_onRequestPermissionsResult_IarrayLjava_lang_String_arrayI == null)
                cb_onRequestPermissionsResult_IarrayLjava_lang_String_arrayI = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, int, IntPtr, IntPtr>)n_OnRequestPermissionsResult_IarrayLjava_lang_String_arrayI);
            return cb_onRequestPermissionsResult_IarrayLjava_lang_String_arrayI;
        }

        static void n_OnRequestPermissionsResult_IarrayLjava_lang_String_arrayI(IntPtr jnienv, IntPtr native__this, int requestCode, IntPtr native_permissions, IntPtr native_grantResults)
        {
            global::Android.Support.V4.App.FragmentActivity __this = global::Java.Lang.Object.GetObject<global::Android.Support.V4.App.FragmentActivity>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            string[] permissions = (string[])JNIEnv.GetArray(native_permissions, JniHandleOwnership.DoNotTransfer, typeof(string));
            global::Android.Content.PM.Permission[] grantResults = (global::Android.Content.PM.Permission[])JNIEnv.GetArray(native_grantResults, JniHandleOwnership.DoNotTransfer, typeof(global::Android.Content.PM.Permission));
            __this.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            if (permissions != null)
                JNIEnv.CopyArray(permissions, native_permissions);
        }
#pragma warning restore 0169

        static IntPtr id_onRequestPermissionsResult_IarrayLjava_lang_String_arrayI;
        // Metadata.xml XPath method reference: path="/api/package[@name='android.support.v4.app']/class[@name='FragmentActivity']/method[@name='onRequestPermissionsResult' and count(parameter)=3 and parameter[1][@type='int'] and parameter[2][@type='java.lang.String[]'] and parameter[3][@type='int[]']]"
        [Register("onRequestPermissionsResult", "(I[Ljava/lang/String;[I)V", "GetOnRequestPermissionsResult_IarrayLjava_lang_String_arrayIHandler")]
        public override unsafe void OnRequestPermissionsResult(int requestCode, string[] permissions, [global::Android.Runtime.GeneratedEnum] global::Android.Content.PM.Permission[] grantResults)
        {
            if (id_onRequestPermissionsResult_IarrayLjava_lang_String_arrayI == IntPtr.Zero)
                id_onRequestPermissionsResult_IarrayLjava_lang_String_arrayI = JNIEnv.GetMethodID(class_ref, "onRequestPermissionsResult", "(I[Ljava/lang/String;[I)V");
            IntPtr native_permissions = JNIEnv.NewArray(permissions);
            try
            {
                JValue* __args = stackalloc JValue[3];
                __args[0] = new JValue(requestCode);
                __args[1] = new JValue(native_permissions);
                __args[2] = new JValue(JNIEnv.NewArray(grantResults));

                if (GetType() == ThresholdType)
                    JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_onRequestPermissionsResult_IarrayLjava_lang_String_arrayI, __args);
                else
                    JNIEnv.CallNonvirtualVoidMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "onRequestPermissionsResult", "(I[Ljava/lang/String;[I)V"), __args);
            }
            finally
            {
                if (permissions != null)
                {
                    JNIEnv.CopyArray(native_permissions, permissions);
                    JNIEnv.DeleteLocalRef(native_permissions);
                }
            }
        }
    }
}
