using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Car.Widget
{

	// Metadata.xml XPath class reference: path="/api/package[@name='androidx.car.widget']/class[@name='ListItemAdapter']"
	//[global::Android.Runtime.Register("androidx/car/widget/ListItemAdapter", DoNotGenerateAcw = true)]
	public partial class ListItemAdapter //: global::AndroidX.RecyclerView.Widget.RecyclerView.Adapter, global::AndroidX.Car.Widget.PagedListView.IDividerVisibilityManager, global::AndroidX.Car.Widget.PagedListView.IItemCap
	{

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.car.widget']/class[@name='ListItemAdapter']/method[@name='onBindViewHolder' and count(parameter)=2 and parameter[1][@type='androidx.car.widget.ListItem.ViewHolder'] and parameter[2][@type='int']]"
		[Register("onBindViewHolder", "(Landroidx/car/widget/ListItem$ViewHolder;I)V", "")]
		public override unsafe void OnBindViewHolder(global::AndroidX.RecyclerView.Widget.RecyclerView.ViewHolder holder, int position)
		{
			const string __id = "onBindViewHolder.(Landroidx/car/widget/ListItem$ViewHolder;I)V";
			try
			{
				JniArgumentValue* __args = stackalloc JniArgumentValue[2];
				__args[0] = new JniArgumentValue((holder == null) ? IntPtr.Zero : ((global::Java.Lang.Object)holder).Handle);
				__args[1] = new JniArgumentValue(position);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod(__id, this, __args);
			}
			finally
			{
			}
		}
	}
}