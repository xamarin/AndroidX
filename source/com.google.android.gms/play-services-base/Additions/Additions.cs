using System;
using Android.Runtime;

namespace Android.Gms.Common
{
	public partial class SignInButton
	{
		static IntPtr id_setEnabled_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.google.android.gms.common']/class[@name='SignInButton']/method[@name='setEnabled' and count(parameter)=1 and parameter[1][@type='boolean']]"
		[Register("setEnabled", "(Z)V", "")]
		public unsafe void SetEnabled(bool enabled)
		{
			if (id_setEnabled_Z == IntPtr.Zero)
				id_setEnabled_Z = JNIEnv.GetMethodID(class_ref, "setEnabled", "(Z)V");
			try
			{
				JValue* __args = stackalloc JValue[1];
				__args[0] = new JValue(enabled);
				JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_setEnabled_Z, __args);
			}
			finally
			{
			}
		}
	}
}
namespace Android.Gms.Common.Data
{
	public partial class DataHolder
	{
		static IntPtr id_finalize;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.google.android.gms.common.data']/class[@name='DataHolder']/method[@name='finalize' and count(parameter)=0]"
		[Register("finalize", "()V", "")]
		protected unsafe void Finalize()
		{
			if (id_finalize == IntPtr.Zero)
				id_finalize = JNIEnv.GetMethodID(class_ref, "finalize", "()V");
			try
			{
				JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_finalize);
			}
			finally
			{
			}
		}
	}
}
