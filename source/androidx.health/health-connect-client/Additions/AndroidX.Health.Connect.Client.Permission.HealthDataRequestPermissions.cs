using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Health.Connect.Client.Permission 
{

	// Metadata.xml XPath class reference: path="/api/package[@name='androidx.health.connect.client.permission']/class[@name='HealthDataRequestPermissions']"
	// [global::System.Obsolete (@"This class is obsoleted in this android platform")]
	// [global::Android.Runtime.Register ("androidx/health/connect/client/permission/HealthDataRequestPermissions", DoNotGenerateAcw=true)]
	public sealed partial class HealthDataRequestPermissions //: global::AndroidX.Activity.Result.Contract.ActivityResultContract {
    {
		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.health.connect.client.permission']/class[@name='HealthDataRequestPermissions']/method[@name='createIntent' and count(parameter)=2 and parameter[1][@type='android.content.Context'] and parameter[2][@type='java.util.Set&lt;androidx.health.connect.client.permission.Permission&gt;']]"
		/*
		[Register ("createIntent", "(Landroid/content/Context;Ljava/util/Set;)Landroid/content/Intent;", "")]
		public unsafe override global::Android.Content.Intent CreateIntent (global::Android.Content.Context context, Java.Lang.Object? input)
		{
			return base.CreateIntent(context, input);
			const string __id = "createIntent.(Landroid/content/Context;Ljava/util/Set;)Landroid/content/Intent;";
			IntPtr native_input = 
						//global::Android.Runtime.JavaSet<global::AndroidX.Health.Connect.Client.Permission.Permission>.ToLocalJniHandle (input)
						input.ToLocalJniHandle()
						;
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [2];
				__args [0] = new JniArgumentValue ((context == null) ? IntPtr.Zero : ((global::Java.Lang.Object) context).Handle);
				__args [1] = new JniArgumentValue (native_input);
				var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod (__id, this, __args);
				return global::Java.Lang.Object.GetObject<global::Android.Content.Intent> (__rm.Handle, JniHandleOwnership.TransferLocalRef)!;
			} finally {
				JNIEnv.DeleteLocalRef (native_input);
				global::System.GC.KeepAlive (context);
				global::System.GC.KeepAlive (input);

			}
		}    
		*/    
    }
}