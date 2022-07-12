using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace Google.Android.Material.Snackbar 
{
	// Metadata.xml XPath class reference: path="/api/package[@name='com.google.android.material.snackbar']/class[@name='Snackbar']"
	// [global::Android.Runtime.Register ("com/google/android/material/snackbar/Snackbar", DoNotGenerateAcw=true)]
	public partial class Snackbar // : global::Google.Android.Material.Snackbar.BaseTransientBottomBar 
	{
		// Metadata.xml XPath class reference: path="/api/package[@name='com.google.android.material.snackbar']/class[@name='Snackbar.SnackbarLayout']"
		// [global::Android.Runtime.Register ("com/google/android/material/snackbar/Snackbar$SnackbarLayout", DoNotGenerateAcw=true)]
		public sealed partial class SnackbarLayout //: global::Android.Widget.FrameLayout 
		{
			// Metadata.xml XPath method reference: path="/api/package[@name='com.google.android.material.snackbar']/class[@name='Snackbar.SnackbarLayout']/method[@name='setLayoutParams' and count(parameter)=1 and parameter[1][@type='android.view.ViewGroup.LayoutParams']]"
			[Register ("setLayoutParams", "(Landroid/view/ViewGroup$LayoutParams;)V", "")]
			public unsafe void SetLayoutParams (global::Android.Views.ViewGroup.LayoutParams this_)
			{
				const string __id = "setLayoutParams.(Landroid/view/ViewGroup$LayoutParams;)V";
				try {
					JniArgumentValue* __args = stackalloc JniArgumentValue [1];
					__args [0] = new JniArgumentValue ((this_ == null) ? IntPtr.Zero : ((global::Java.Lang.Object) this_).Handle);
					_members.InstanceMethods.InvokeAbstractVoidMethod (__id, this, __args);
				} finally {
					global::System.GC.KeepAlive (this_);
				}
			}
		}
	}
}