using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Slice.Widget
{

	// Metadata.xml XPath class reference: path="/api/package[@name='androidx.slice.widget']/class[@name='LargeSliceAdapter']"
	public partial class LargeSliceAdapter
	{

		static Delegate cb_onBindViewHolder_Landroidx_slice_widget_LargeSliceAdapter_SliceViewHolder_I;
#pragma warning disable 0169
		static Delegate GetOnBindViewHolder_Landroidx_slice_widget_LargeSliceAdapter_SliceViewHolder_IHandler()
		{
			if (cb_onBindViewHolder_Landroidx_slice_widget_LargeSliceAdapter_SliceViewHolder_I == null)
				cb_onBindViewHolder_Landroidx_slice_widget_LargeSliceAdapter_SliceViewHolder_I = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, IntPtr, int>)n_OnBindViewHolder_Landroidx_slice_widget_LargeSliceAdapter_SliceViewHolder_I);
			return cb_onBindViewHolder_Landroidx_slice_widget_LargeSliceAdapter_SliceViewHolder_I;
		}

		static void n_OnBindViewHolder_Landroidx_slice_widget_LargeSliceAdapter_SliceViewHolder_I(IntPtr jnienv, IntPtr native__this, IntPtr native_holder, int position)
		{
			global::AndroidX.Slice.Widget.LargeSliceAdapter __this = global::Java.Lang.Object.GetObject<global::AndroidX.Slice.Widget.LargeSliceAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			global::AndroidX.Slice.Widget.LargeSliceAdapter.SliceViewHolder holder = global::Java.Lang.Object.GetObject<global::AndroidX.Slice.Widget.LargeSliceAdapter.SliceViewHolder>(native_holder, JniHandleOwnership.DoNotTransfer);
			__this.OnBindViewHolder(holder, position);
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.slice.widget']/class[@name='LargeSliceAdapter']/method[@name='onBindViewHolder' and count(parameter)=2 and parameter[1][@type='androidx.slice.widget.LargeSliceAdapter.SliceViewHolder'] and parameter[2][@type='int']]"
		[Register("onBindViewHolder", "(Landroidx/slice/widget/LargeSliceAdapter$SliceViewHolder;I)V", "GetOnBindViewHolder_Landroidx_slice_widget_LargeSliceAdapter_SliceViewHolder_IHandler")]
		public override unsafe void OnBindViewHolder(global::Android.Support.V7.Widget.RecyclerView.ViewHolder holder, int position)
		{
			const string __id = "onBindViewHolder.(Landroidx/slice/widget/LargeSliceAdapter$SliceViewHolder;I)V";
			try
			{
				JniArgumentValue* __args = stackalloc JniArgumentValue[2];
				__args[0] = new JniArgumentValue((holder == null) ? IntPtr.Zero : ((global::Java.Lang.Object)holder).Handle);
				__args[1] = new JniArgumentValue(position);
				_members.InstanceMethods.InvokeVirtualVoidMethod(__id, this, __args);
			}
			finally
			{
			}
		}
	}
}