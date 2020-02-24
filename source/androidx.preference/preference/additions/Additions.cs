using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Preference
{
     public partial class PreferenceGroupAdapter
     {

static Delegate cb_onBindViewHolder_Landroidx_preference_PreferenceViewHolder_I;
#pragma warning disable 0169
		static Delegate GetOnBindViewHolder_Landroidx_preference_PreferenceViewHolder_IHandler ()
		{
			if (cb_onBindViewHolder_Landroidx_preference_PreferenceViewHolder_I == null)
				cb_onBindViewHolder_Landroidx_preference_PreferenceViewHolder_I = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, int>) n_OnBindViewHolder_Landroidx_preference_PreferenceViewHolder_I);
			return cb_onBindViewHolder_Landroidx_preference_PreferenceViewHolder_I;
		}

		static void n_OnBindViewHolder_Landroidx_preference_PreferenceViewHolder_I (IntPtr jnienv, IntPtr native__this, IntPtr native_holder, int position)
		{
			global::AndroidX.Preference.PreferenceGroupAdapter __this = global::Java.Lang.Object.GetObject<global::AndroidX.Preference.PreferenceGroupAdapter> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::AndroidX.Preference.PreferenceViewHolder holder = global::Java.Lang.Object.GetObject<global::AndroidX.Preference.PreferenceViewHolder> (native_holder, JniHandleOwnership.DoNotTransfer);
			__this.OnBindViewHolder (holder, position);
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.preference']/class[@name='PreferenceGroupAdapter']/method[@name='onBindViewHolder' and count(parameter)=2 and parameter[1][@type='androidx.preference.PreferenceViewHolder'] and parameter[2][@type='int']]"
		[Register ("onBindViewHolder", "(Landroidx/preference/PreferenceViewHolder;I)V", "GetOnBindViewHolder_Landroidx_preference_PreferenceViewHolder_IHandler")]
		public override unsafe void OnBindViewHolder (global::AndroidX.RecyclerView.Widget.RecyclerView.ViewHolder holder, int position)
		{
			const string __id = "onBindViewHolder.(Landroidx/preference/PreferenceViewHolder;I)V";
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [2];
				__args [0] = new JniArgumentValue ((holder == null) ? IntPtr.Zero : ((global::Java.Lang.Object) holder).Handle);
				__args [1] = new JniArgumentValue (position);
				_members.InstanceMethods.InvokeVirtualVoidMethod (__id, this, __args);
			} finally {
			}
		}
     }
}
