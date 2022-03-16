using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Activity.Result.Contract 
{
	/*
	TODO: remove after virtual vs override support in metadata is added
	must be removed after 16.9 is stable 20210302
	*/
	internal delegate IntPtr _JniMarshal_PPLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);

	// Metadata.xml XPath class reference: path="/api/package[@name='androidx.activity.result.contract']/class[@name='ActivityResultContracts']"
	//[global::Android.Runtime.Register ("androidx/activity/result/contract/ActivityResultContracts", DoNotGenerateAcw=true)]
	public sealed partial class ActivityResultContracts // : global::Java.Lang.Object 
    {
		public partial class OpenDocument // : global::AndroidX.Activity.Result.Contract.ActivityResultContract 
        {
			static Delegate cb_createIntent_Landroid_content_Context_arrayLjava_lang_String_;
#pragma warning disable 0169
			static Delegate GetCreateIntent_Landroid_content_Context_arrayLjava_lang_String_Handler ()
			{
				if (cb_createIntent_Landroid_content_Context_arrayLjava_lang_String_ == null)
					cb_createIntent_Landroid_content_Context_arrayLjava_lang_String_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPLL_L) n_CreateIntent_Landroid_content_Context_arrayLjava_lang_String_);
				return cb_createIntent_Landroid_content_Context_arrayLjava_lang_String_;
			}

			static IntPtr n_CreateIntent_Landroid_content_Context_arrayLjava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_input)
			{
				var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Activity.Result.Contract.ActivityResultContracts.OpenDocument> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				var context = global::Java.Lang.Object.GetObject<global::Android.Content.Context> (native_context, JniHandleOwnership.DoNotTransfer);
				var input = (string[]) JNIEnv.GetArray (native_input, JniHandleOwnership.DoNotTransfer, typeof (string));
				IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.CreateIntent (context, input));
				if (input != null)
					JNIEnv.CopyArray (input, native_input);
				return __ret;
			}
#pragma warning restore 0169

			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.activity.result.contract']/class[@name='ActivityResultContracts.OpenDocument']/method[@name='createIntent' and count(parameter)=2 and parameter[1][@type='android.content.Context'] and parameter[2][@type='java.lang.String[]']]"
			[Register ("createIntent", "(Landroid/content/Context;[Ljava/lang/String;)Landroid/content/Intent;", "GetCreateIntent_Landroid_content_Context_arrayLjava_lang_String_Handler")]
			public 
                //virtual 
                override 
                unsafe global::Android.Content.Intent CreateIntent (global::Android.Content.Context context, global::Java.Lang.Object input)
			{
				const string __id = "createIntent.(Landroid/content/Context;[Ljava/lang/String;)Landroid/content/Intent;";
				IntPtr native_input = JNIEnv.NewArray ((bool[]?)input);
				try {
					JniArgumentValue* __args = stackalloc JniArgumentValue [2];
					__args [0] = new JniArgumentValue ((context == null) ? IntPtr.Zero : ((global::Java.Lang.Object) context).Handle);
					__args [1] = new JniArgumentValue (native_input);
					var __rm = _members.InstanceMethods.InvokeVirtualObjectMethod (__id, this, __args);
					return global::Java.Lang.Object.GetObject<global::Android.Content.Intent> (__rm.Handle, JniHandleOwnership.TransferLocalRef);
				} finally {
					if (input != null) {
						JNIEnv.CopyArray (native_input, (bool[]?) input);
						JNIEnv.DeleteLocalRef (native_input);
					}
					global::System.GC.KeepAlive (context);
					global::System.GC.KeepAlive (input);
				}
			}
        }

		public partial class OpenMultipleDocuments // : global::AndroidX.Activity.Result.Contract.ActivityResultContract 
        {
			static Delegate cb_createIntent_Landroid_content_Context_arrayLjava_lang_String_;
#pragma warning disable 0169
			static Delegate GetCreateIntent_Landroid_content_Context_arrayLjava_lang_String_Handler ()
			{
				if (cb_createIntent_Landroid_content_Context_arrayLjava_lang_String_ == null)
					cb_createIntent_Landroid_content_Context_arrayLjava_lang_String_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPLL_L) n_CreateIntent_Landroid_content_Context_arrayLjava_lang_String_);
				return cb_createIntent_Landroid_content_Context_arrayLjava_lang_String_;
			}

			static IntPtr n_CreateIntent_Landroid_content_Context_arrayLjava_lang_String_ (IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_input)
			{
				var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Activity.Result.Contract.ActivityResultContracts.OpenMultipleDocuments> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				var context = global::Java.Lang.Object.GetObject<global::Android.Content.Context> (native_context, JniHandleOwnership.DoNotTransfer);
				var input = (string[]) JNIEnv.GetArray (native_input, JniHandleOwnership.DoNotTransfer, typeof (string));
				IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.CreateIntent (context, input));
				if (input != null)
					JNIEnv.CopyArray (input, native_input);
				return __ret;
			}
#pragma warning restore 0169

			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.activity.result.contract']/class[@name='ActivityResultContracts.OpenMultipleDocuments']/method[@name='createIntent' and count(parameter)=2 and parameter[1][@type='android.content.Context'] and parameter[2][@type='java.lang.String[]']]"
			[Register ("createIntent", "(Landroid/content/Context;[Ljava/lang/String;)Landroid/content/Intent;", "GetCreateIntent_Landroid_content_Context_arrayLjava_lang_String_Handler")]
			public 
                //virtual 
                override
                unsafe global::Android.Content.Intent CreateIntent (global::Android.Content.Context context, global::Java.Lang.Object input)
			{
				const string __id = "createIntent.(Landroid/content/Context;[Ljava/lang/String;)Landroid/content/Intent;";
				IntPtr native_input = JNIEnv.NewArray ((bool[]?) input);
				try {
					JniArgumentValue* __args = stackalloc JniArgumentValue [2];
					__args [0] = new JniArgumentValue ((context == null) ? IntPtr.Zero : ((global::Java.Lang.Object) context).Handle);
					__args [1] = new JniArgumentValue (native_input);
					var __rm = _members.InstanceMethods.InvokeVirtualObjectMethod (__id, this, __args);
					return global::Java.Lang.Object.GetObject<global::Android.Content.Intent> (__rm.Handle, JniHandleOwnership.TransferLocalRef);
				} finally {
					if (input != null) {
						JNIEnv.CopyArray (native_input, (bool[]?) input);
						JNIEnv.DeleteLocalRef (native_input);
					}
					global::System.GC.KeepAlive (context);
					global::System.GC.KeepAlive (input);
				}
			}



			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.activity.result.contract']/class[@name='ActivityResultContracts.OpenMultipleDocuments']/method[@name='parseResult' and count(parameter)=2 and parameter[1][@type='int'] and parameter[2][@type='android.content.Intent']]"
			[Register("parseResult", "(ILandroid/content/Intent;)Ljava/util/List;", "")]
			public override sealed unsafe global::Java.Lang.Object ParseResult(int resultCode, global::Android.Content.Intent intent)
			{
				const string __id = "parseResult.(ILandroid/content/Intent;)Ljava/util/List;";
				try
				{
					JniArgumentValue* __args = stackalloc JniArgumentValue[2];
					__args[0] = new JniArgumentValue(resultCode);
					__args[1] = new JniArgumentValue((intent == null) ? IntPtr.Zero : ((global::Java.Lang.Object)intent).Handle);
					var __rm = _members.InstanceMethods.InvokeNonvirtualObjectMethod(__id, this, __args);
					return (global::Java.Lang.Object) global::Android.Runtime.JavaList<global::Android.Net.Uri>.FromJniHandle(__rm.Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					global::System.GC.KeepAlive(intent);
				}
			}
		}

		public partial class RequestMultiplePermissions // : global::AndroidX.Activity.Result.Contract.ActivityResultContract 
        {
			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.activity.result.contract']/class[@name='ActivityResultContracts.RequestMultiplePermissions']/method[@name='createIntent' and count(parameter)=2 and parameter[1][@type='android.content.Context'] and parameter[2][@type='java.lang.String[]']]"
			[Register ("createIntent", "(Landroid/content/Context;[Ljava/lang/String;)Landroid/content/Intent;", "")]
			public 
                override
                unsafe global::Android.Content.Intent CreateIntent (global::Android.Content.Context context, global::Java.Lang.Object input)
			{
				const string __id = "createIntent.(Landroid/content/Context;[Ljava/lang/String;)Landroid/content/Intent;";
				IntPtr native_input = JNIEnv.NewArray ((bool[]?)input);
				try {
					JniArgumentValue* __args = stackalloc JniArgumentValue [2];
					__args [0] = new JniArgumentValue ((context == null) ? IntPtr.Zero : ((global::Java.Lang.Object) context).Handle);
					__args [1] = new JniArgumentValue (native_input);
					var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod (__id, this, __args);
					return global::Java.Lang.Object.GetObject<global::Android.Content.Intent> (__rm.Handle, JniHandleOwnership.TransferLocalRef);
				} finally {
					if (input != null) {
						JNIEnv.CopyArray (native_input, (bool[]?) input);
						JNIEnv.DeleteLocalRef (native_input);
					}
					global::System.GC.KeepAlive (context);
					global::System.GC.KeepAlive (input);
				}
			}


			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.activity.result.contract']/class[@name='ActivityResultContracts.RequestMultiplePermissions']/method[@name='parseResult' and count(parameter)=2 and parameter[1][@type='int'] and parameter[2][@type='android.content.Intent']]"
			[Register("parseResult", "(ILandroid/content/Intent;)Ljava/util/Map;", "")]
			public override unsafe global::Java.Lang.Object ParseResult(int resultCode, global::Android.Content.Intent intent)
			{
				const string __id = "parseResult.(ILandroid/content/Intent;)Ljava/util/Map;";
				try
				{
					JniArgumentValue* __args = stackalloc JniArgumentValue[2];
					__args[0] = new JniArgumentValue(resultCode);
					__args[1] = new JniArgumentValue((intent == null) ? IntPtr.Zero : ((global::Java.Lang.Object)intent).Handle);
					var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod(__id, this, __args);
					return (global::Java.Lang.Object) global::Android.Runtime.JavaDictionary<string, global::Java.Lang.Boolean>.FromJniHandle(__rm.Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					global::System.GC.KeepAlive(intent);
				}
			}

		}		
		public partial class CreateDocument //: global::AndroidX.Activity.Result.Contract.ActivityResultContract 
		{
			public global::Android.Content.Intent CreateIntent (global::Android.Content.Context context, string input)
			{
				return CreateIntent (context, (Java.Lang.Object) input);
			}
		}
	}


}
