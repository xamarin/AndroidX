using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Google.Android.Material.Navigation
{

    // Metadata.xml XPath class reference: path="/api/package[@name='com.google.android.material.navigation']/class[@name='NavigationBarItemView']"
    //[global::Android.Runtime.Register("com/google/android/material/navigation/NavigationBarItemView", DoNotGenerateAcw = true)]
    public abstract partial class NavigationBarItemView //: global::Android.Widget.FrameLayout, global::AndroidX.AppCompat.View.Menu.IMenuViewItemView
    {
		// Metadata.xml XPath method reference: path="/api/package[@name='com.google.android.material.navigation']/class[@name='NavigationBarItemView']/method[@name='setEnabled' and count(parameter)=1 and parameter[1][@type='boolean']]"
		[Register("setEnabled", "(Z)V", "")]
		public unsafe void SetEnabled(bool p0)
		{
			const string __id = "setEnabled.(Z)V";
			try
			{
				JniArgumentValue* __args = stackalloc JniArgumentValue[1];
				__args[0] = new JniArgumentValue(p0);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod(__id, this, __args);
			}
			finally
			{
			}
		}
	}
}