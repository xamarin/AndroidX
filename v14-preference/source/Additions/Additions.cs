using System;
using Android.Runtime;

namespace Android.Support.V14.Preferences
{
    public partial class MultiSelectListPreference
    {

        public override System.Collections.Generic.ICollection<string> Values {
            get { return GetValues (); }
            set { SetValues (value); }
        }


        static Delegate cb_getValues;
#pragma warning disable 0169
        static Delegate GetGetValuesHandler ()
        {
            if (cb_getValues == null)
                cb_getValues = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>)n_GetValues);
            return cb_getValues;
        }

        static IntPtr n_GetValues (IntPtr jnienv, IntPtr native__this)
        {
            global::Android.Support.V14.Preferences.MultiSelectListPreference __this = global::Java.Lang.Object.GetObject<global::Android.Support.V14.Preferences.MultiSelectListPreference> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            return global::Android.Runtime.JavaSet<string>.ToLocalJniHandle (__this.GetValues ());
        }
#pragma warning restore 0169

        static IntPtr id_getValues;
        // Metadata.xml XPath method reference: path="/api/package[@name='android.support.v14.preference']/class[@name='MultiSelectListPreference']/method[@name='getValues' and count(parameter)=0]"
        [Register ("getValues", "()Ljava/util/Set;", "GetGetValuesHandler")]
        public unsafe global::System.Collections.Generic.ICollection<string> GetValues ()
        {
            if (id_getValues == IntPtr.Zero)
                id_getValues = JNIEnv.GetMethodID (class_ref, "getValues", "()Ljava/util/Set;");
            try {

                if (GetType () == ThresholdType)
                    return global::Android.Runtime.JavaSet<string>.FromJniHandle (JNIEnv.CallObjectMethod (((global::Java.Lang.Object)this).Handle, id_getValues), JniHandleOwnership.TransferLocalRef);
                else
                    return global::Android.Runtime.JavaSet<string>.FromJniHandle (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getValues", "()Ljava/util/Set;")), JniHandleOwnership.TransferLocalRef);
            } finally {
            }
        }
    }



}