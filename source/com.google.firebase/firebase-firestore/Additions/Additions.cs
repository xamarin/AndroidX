using System;
using Android.Runtime;
using Android.Gms.Extensions;


namespace Firebase.Firestore
{

    // Metadata.xml XPath class reference: path="/api/package[@name='com.google.firebase.firestore']/class[@name='LoadBundleTask']"
    //[global::Android.Runtime.Register("com/google/firebase/firestore/LoadBundleTask", DoNotGenerateAcw = true)]
    public partial class LoadBundleTask // : global::Android.Gms.Tasks.Task
    {
		protected override unsafe global::Java.Lang.Object RawResult
		{
			// Metadata.xml XPath method reference: path="/api/package[@name='com.google.android.gms.tasks']/class[@name='Task']/method[@name='getResult' and count(parameter)=0]"
			[Register("getResult", "()Ljava/lang/Object;", "GetGetResultHandler")]
			get
			{
				const string __id = "getResult.()Ljava/lang/Object;";
				try
				{
					var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod(__id, this, null);
					return (Java.Lang.Object)global::Java.Lang.Object.GetObject<global::Java.Lang.Object>(__rm.Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
				}
			}
		}
	}
}
