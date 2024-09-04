using System;
using Android.Runtime;
using Java.Interop;

namespace Android.Gms.Ads.Formats
{
	public partial interface IShouldDelayBannerRenderingListener
	{
        // Metadata.xml XPath method reference: path="/api/package[@name='com.google.android.gms.ads.formats']/interface[@name='ShouldDelayBannerRenderingListener']/method[@name='zzb' and count(parameter)=1 and parameter[1][@type='java.lang.Runnable']]"
        //[Register("zzb", "(Ljava/lang/Runnable;)Z", "GetZzb_Ljava_lang_Runnable_Handler:Android.Gms.Ads.Formats.IShouldDelayBannerRenderingListenerInvoker, Xamarin.GooglePlayServices.Ads.Lite")]
        //bool Zzb(global::Java.Lang.IRunnable p0);
    }

    internal partial class IShouldDelayBannerRenderingListenerInvoker : global::Java.Lang.Object //, IShouldDelayBannerRenderingListener
    {
        //		static Delegate cb_zzb_Ljava_lang_Runnable_;
        //#pragma warning disable 0169
        //		static Delegate GetZzb_Ljava_lang_Runnable_Handler()
        //		{
        //			if (cb_zzb_Ljava_lang_Runnable_ == null)
        //				cb_zzb_Ljava_lang_Runnable_ = JNINativeWrapper.CreateDelegate((_JniMarshal_PPL_Z)n_Zzb_Ljava_lang_Runnable_);
        //			return cb_zzb_Ljava_lang_Runnable_;
        //		}

        //		static bool n_Zzb_Ljava_lang_Runnable_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
        //		{
        //			var __this = global::Java.Lang.Object.GetObject<global::Android.Gms.Ads.Formats.IShouldDelayBannerRenderingListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
        //			var p0 = (global::Java.Lang.IRunnable)global::Java.Lang.Object.GetObject<global::Java.Lang.IRunnable>(native_p0, JniHandleOwnership.DoNotTransfer);
        //			bool __ret = __this.Zzb(p0);
        //			return __ret;
        //		}
        //#pragma warning restore 0169

        //		IntPtr id_zzb_Ljava_lang_Runnable_;
        //		public unsafe bool Zzb(global::Java.Lang.IRunnable p0)
        //		{
        //			if (id_zzb_Ljava_lang_Runnable_ == IntPtr.Zero)
        //				id_zzb_Ljava_lang_Runnable_ = JNIEnv.GetMethodID(class_ref, "zzb", "(Ljava/lang/Runnable;)Z");
        //			JValue* __args = stackalloc JValue[1];
        //			__args[0] = new JValue((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object)p0).Handle);
        //			var __ret = JNIEnv.CallBooleanMethod(((global::Java.Lang.Object)this).Handle, id_zzb_Ljava_lang_Runnable_, __args);
        //			return __ret;
        //		}

        //public unsafe bool Zzb(global::Java.Lang.IRunnable p0)
        //{
        //    throw new NotImplementedException();
        //}
    }

    internal sealed partial class IShouldDelayBannerRenderingListenerImplementor
    {
        //public bool Zzb(global::Java.Lang.IRunnable p0)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
