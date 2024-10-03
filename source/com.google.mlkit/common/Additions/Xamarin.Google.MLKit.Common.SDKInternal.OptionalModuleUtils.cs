using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace Xamarin.Google.MLKit.Common.SDKInternal {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.google.mlkit.common.sdkinternal']/class[@name='OptionalModuleUtils']"
	// [global::Android.Runtime.Register ("com/google/mlkit/common/sdkinternal/OptionalModuleUtils", DoNotGenerateAcw=true)]
	public partial class OptionalModuleUtils : global::Java.Lang.Object 
    {
        /*
        Issue??

        unable to change [return] type of the property

        1.  Does nothing

        <attr
            path="/api/package[@name='com.google.mlkit.common.sdkinternal']/class[@name='OptionalModuleUtils']/field[@name='EMPTY_FEATURES']"
            name="managedType"
            >
            System.Collections.Generic.IList &lt; global::Android.Gms.Common.Feature &gt;
        </attr>

        2.  Removes property completely

        <attr
            path="/api/package[@name='com.google.mlkit.common.sdkinternal']/class[@name='OptionalModuleUtils']/field[@name='EMPTY_FEATURES']"
            name="type"
            >
            System.Collections.Generic.IList &lt; global::Android.Gms.Common.Feature &gt;
        </attr>

        3.  Workaround - copy code + remove-node + change code

        */
		// Metadata.xml XPath field reference: path="/api/package[@name='com.google.mlkit.common.sdkinternal']/class[@name='OptionalModuleUtils']/field[@name='EMPTY_FEATURES']"
		[Register ("EMPTY_FEATURES")]
		public static IList<global::Android.Gms.Common.Feature> EmptyFeatures {
			get {
				const string __id = "EMPTY_FEATURES.[Lcom/google/android/gms/common/Feature;";

				var __v = _members.StaticFields.GetObjectValue (__id);
				return global::Android.Runtime.JavaArray<global::Android.Gms.Common.Feature>.FromJniHandle (__v.Handle, JniHandleOwnership.TransferLocalRef);
			}
		}
    }
}