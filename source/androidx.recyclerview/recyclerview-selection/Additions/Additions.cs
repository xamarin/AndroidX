using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.RecyclerView.Selection
{
	public partial class DefaultSelectionTracker
	{
		static Delegate cb_getSelection;
#pragma warning disable 0169
		static Delegate GetGetSelectionHandler()
		{
			if (cb_getSelection == null)
				cb_getSelection = JNINativeWrapper.CreateDelegate((Func<IntPtr, IntPtr, IntPtr>)n_GetSelection);
			return cb_getSelection;
		}

		static IntPtr n_GetSelection(IntPtr jnienv, IntPtr native__this)
		{
			global::AndroidX.RecyclerView.Selection.DefaultSelectionTracker __this = global::Java.Lang.Object.GetObject<global::AndroidX.RecyclerView.Selection.DefaultSelectionTracker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(__this.RawSelection);
		}
#pragma warning restore 0169

		protected override global::AndroidX.RecyclerView.Selection.Selection RawSelection
		{
			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.recyclerview.selection']/class[@name='SelectionTracker']/method[@name='getSelection' and count(parameter)=0]"
			[Register("getSelection", "()Landroidx/recyclerview/selection/Selection;", "GetGetSelectionHandler")]
			get;
		}
	}
}