using System;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Sharetarget
{

    // Metadata.xml XPath class reference: path="/api/package[@name='androidx.sharetarget']/class[@name='ShortcutInfoCompatSaverImpl']"
    //[global::Android.Runtime.Register("androidx/sharetarget/ShortcutInfoCompatSaverImpl", DoNotGenerateAcw = true)]
    /*
	public partial class ShortcutInfoCompatSaverImpl
	{
		static Delegate cb_addShortcuts_Ljava_util_List_;
	#pragma warning disable 0169
		static Delegate GetAddShortcuts_Ljava_util_List_Handler()
		{
			if (cb_addShortcuts_Ljava_util_List_ == null)
				cb_addShortcuts_Ljava_util_List_ = JNINativeWrapper.CreateDelegate((_JniMarshal_PPL_L)n_AddShortcuts_Ljava_util_List_);
			return cb_addShortcuts_Ljava_util_List_;
		}

		static IntPtr n_AddShortcuts_Ljava_util_List_(IntPtr jnienv, IntPtr native__this, IntPtr native_shortcuts)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Core.Content.PM.ShortcutInfoCompatSaver.NoopImpl>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			var shortcuts = global::Android.Runtime.JavaList<global::AndroidX.Core.Content.PM.ShortcutInfoCompat>.FromJniHandle(native_shortcuts, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle(__this.AddShortcuts(shortcuts));
			return __ret;
		}
	#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.core.content.pm']/class[@name='ShortcutInfoCompatSaver.NoopImpl']/method[@name='addShortcuts' and count(parameter)=1 and parameter[1][@type='java.util.List&lt;androidx.core.content.pm.ShortcutInfoCompat&gt;']]"
		[Register("addShortcuts", "(Ljava/util/List;)Ljava/lang/Void;", "GetAddShortcuts_Ljava_util_List_Handler")]
		public override unsafe global::Java.Lang.Object AddShortcuts(global::System.Collections.Generic.IList<global::AndroidX.Core.Content.PM.ShortcutInfoCompat> shortcuts)
		{
			const string __id = "addShortcuts.(Ljava/util/List;)Ljava/lang/Void;";
			IntPtr native_shortcuts = global::Android.Runtime.JavaList<global::AndroidX.Core.Content.PM.ShortcutInfoCompat>.ToLocalJniHandle(shortcuts);
			try
			{
				JniArgumentValue* __args = stackalloc JniArgumentValue[1];
				__args[0] = new JniArgumentValue(native_shortcuts);
				var __rm = _members.InstanceMethods.InvokeVirtualObjectMethod(__id, this, __args);
				return global::Java.Lang.Object.GetObject<global::Java.Lang.Object>(__rm.Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(native_shortcuts);
			}
		}

		static Delegate cb_removeAllShortcuts;
	#pragma warning disable 0169
		static Delegate GetRemoveAllShortcutsHandler()
		{
			if (cb_removeAllShortcuts == null)
				cb_removeAllShortcuts = JNINativeWrapper.CreateDelegate((_JniMarshal_PP_L)n_RemoveAllShortcuts);
			return cb_removeAllShortcuts;
		}

		static IntPtr n_RemoveAllShortcuts(IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Core.Content.PM.ShortcutInfoCompatSaver.NoopImpl>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(__this.RemoveAllShortcuts());
		}
	#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.core.content.pm']/class[@name='ShortcutInfoCompatSaver.NoopImpl']/method[@name='removeAllShortcuts' and count(parameter)=0]"
		[Register("removeAllShortcuts", "()Ljava/lang/Void;", "GetRemoveAllShortcutsHandler")]
		public override unsafe global::Java.Lang.Object RemoveAllShortcuts()
		{
			const string __id = "removeAllShortcuts.()Ljava/lang/Void;";
			try
			{
				var __rm = _members.InstanceMethods.InvokeVirtualObjectMethod(__id, this, null);
				return global::Java.Lang.Object.GetObject<global::Java.Lang.Object>(__rm.Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
			}
		}

		static Delegate cb_removeShortcuts_Ljava_util_List_;
	#pragma warning disable 0169
		static Delegate GetRemoveShortcuts_Ljava_util_List_Handler()
		{
			if (cb_removeShortcuts_Ljava_util_List_ == null)
				cb_removeShortcuts_Ljava_util_List_ = JNINativeWrapper.CreateDelegate((_JniMarshal_PPL_L)n_RemoveShortcuts_Ljava_util_List_);
			return cb_removeShortcuts_Ljava_util_List_;
		}

		static IntPtr n_RemoveShortcuts_Ljava_util_List_(IntPtr jnienv, IntPtr native__this, IntPtr native_shortcutIds)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Core.Content.PM.ShortcutInfoCompatSaver.NoopImpl>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			var shortcutIds = global::Android.Runtime.JavaList<string>.FromJniHandle(native_shortcutIds, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle(__this.RemoveShortcuts(shortcutIds));
			return __ret;
		}
	#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.core.content.pm']/class[@name='ShortcutInfoCompatSaver.NoopImpl']/method[@name='removeShortcuts' and count(parameter)=1 and parameter[1][@type='java.util.List&lt;java.lang.String&gt;']]"
		[Register ("removeShortcuts", "(Ljava/util/List;)Ljava/lang/Void;", "GetRemoveShortcuts_Ljava_util_List_Handler")]
		public override unsafe global::Java.Lang.Object RemoveShortcuts (global::System.Collections.Generic.IList<string> shortcutIds)
		{
			const string __id = "removeShortcuts.(Ljava/util/List;)Ljava/lang/Void;";
			IntPtr native_shortcutIds = global::Android.Runtime.JavaList<string>.ToLocalJniHandle (shortcutIds);
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [1];
				__args [0] = new JniArgumentValue (native_shortcutIds);
				var __rm = _members.InstanceMethods.InvokeVirtualObjectMethod (__id, this, __args);
				return global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (__rm.Handle, JniHandleOwnership.TransferLocalRef);
			} finally {
				JNIEnv.DeleteLocalRef (native_shortcutIds);
			}
		}

	}
	*/
}
