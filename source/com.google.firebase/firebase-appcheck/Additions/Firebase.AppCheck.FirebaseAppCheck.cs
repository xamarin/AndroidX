using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace Firebase.AppCheck 
{

	// Metadata.xml XPath class reference: path="/api/package[@name='com.google.firebase.appcheck']/class[@name='FirebaseAppCheck']"
	// [global::Android.Runtime.Register ("com/google/firebase/appcheck/FirebaseAppCheck", DoNotGenerateAcw=true)]
	public abstract partial class FirebaseAppCheck // : global::Java.Lang.Object, global::Firebase.AppCheck.Interop.IInteropAppCheckTokenProvider 
    {
		public global::Android.Gms.Tasks.Task GetLimitedUseToken()
        {
            return this.LimitedUseToken;
        }
    }
}