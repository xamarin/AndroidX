using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace Firebase.AppCheck.Internal 
{
	// Metadata.xml XPath class reference: path="/api/package[@name='com.google.firebase.appcheck.internal']/class[@name='DefaultFirebaseAppCheck']"
	// [global::Android.Runtime.Register ("com/google/firebase/appcheck/internal/DefaultFirebaseAppCheck", DoNotGenerateAcw=true)]
	public partial class DefaultFirebaseAppCheck // : global::Firebase.AppCheck.FirebaseAppCheck 
    {
		public override global::Android.Gms.Tasks.Task LimitedUseToken
        {
            get
            {
                return GetLimitedUseToken();
            }
        }

    }
}