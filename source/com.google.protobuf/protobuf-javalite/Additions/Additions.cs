#nullable restore
using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace Xamarin.Protobuf.Lite 
{
	// Metadata.xml XPath class reference: path="/api/package[@name='com.google.protobuf']/class[@name='LazyStringArrayList']"
	// [global::Android.Runtime.Register ("com/google/protobuf/LazyStringArrayList", DoNotGenerateAcw=true)]
	public partial class LazyStringArrayList // : global::Java.Util.AbstractList 
    {
        // changed 
        //  cb_remove_I to cb_remove_Is
		static Delegate cb_remove_Is;
#pragma warning disable 0169
		static Delegate GetRemove_IsHandler ()
		{
			if (cb_remove_Is == null)
				cb_remove_Is = JNINativeWrapper.CreateDelegate (new _JniMarshal_PPI_L (n_Remove_Is));
			return cb_remove_Is;
		}

		static IntPtr n_Remove_Is (IntPtr jnienv, IntPtr native__this, int index)
		{
			var __this = global::Java.Lang.Object.GetObject<global::Xamarin.Protobuf.Lite.LazyStringArrayList> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString (__this.RemoveAndReturnString (index));
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='com.google.protobuf']/class[@name='LazyStringArrayList']/method[@name='remove' and count(parameter)=1 and parameter[1][@type='int']]"
		[Register ("remove", "(I)Ljava/lang/String;", "GetRemove_IsHandler")]
		public virtual unsafe string RemoveAndReturnString (int index)
		{
			const string __id = "remove.(I)Ljava/lang/String;";
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [1];
				__args [0] = new JniArgumentValue (index);
				var __rm = _members.InstanceMethods.InvokeVirtualObjectMethod (__id, this, __args);
				return JNIEnv.GetString (__rm.Handle, JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}


		static Delegate cb_remove_I;
#pragma warning disable 0169
		static Delegate GetRemove_IHandler ()
		{
			if (cb_remove_I == null)
				cb_remove_I = JNINativeWrapper.CreateDelegate (new _JniMarshal_PPI_L (n_Remove_I));
			return cb_remove_I;
		}

		static IntPtr n_Remove_I (IntPtr jnienv, IntPtr native__this, int index)
		{
			var __this = global::Java.Lang.Object.GetObject<global::Xamarin.Protobuf.Lite.LazyStringArrayList> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle (__this.Remove (index));
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='com.google.protobuf']/class[@name='LazyStringArrayList']/method[@name='remove' and count(parameter)=1 and parameter[1][@type='int']]"
		[Register ("remove", "(I)Ljava/lang/Object;", "GetRemove_IHandler")]
		public override unsafe global::Java.Lang.Object Remove (int index)
		{
			const string __id = "remove.(I)Ljava/lang/Object;";
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [1];
				__args [0] = new JniArgumentValue (index);
				var __rm = _members.InstanceMethods.InvokeVirtualObjectMethod (__id, this, __args);
				return global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (__rm.Handle, JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}
    }
}