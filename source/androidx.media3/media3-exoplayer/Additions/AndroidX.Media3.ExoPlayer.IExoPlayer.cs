using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Media3.ExoPlayer {

	// Metadata.xml XPath interface reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.AudioComponent']"
	[ObsoleteAttribute (@"This class is obsoleted in this android platform")]
	[Register ("androidx/media3/exoplayer/ExoPlayer$AudioComponent", "", "AndroidX.Media3.ExoPlayer.IExoPlayerAudioComponentInvoker")]
	public partial interface IExoPlayerAudioComponent : IJavaObject, IJavaPeerable {
		global::AndroidX.Media3.Common.AudioAttributes? AudioAttributes {
			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.AudioComponent']/method[@name='getAudioAttributes' and count(parameter)=0]"
			[Register ("getAudioAttributes", "()Landroidx/media3/common/AudioAttributes;", "GetGetAudioAttributesHandler:AndroidX.Media3.ExoPlayer.IExoPlayerAudioComponentInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			get; 
		}

		int AudioSessionId {
			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.AudioComponent']/method[@name='getAudioSessionId' and count(parameter)=0]"
			[Register ("getAudioSessionId", "()I", "GetGetAudioSessionIdHandler:AndroidX.Media3.ExoPlayer.IExoPlayerAudioComponentInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			get; 

			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.AudioComponent']/method[@name='setAudioSessionId' and count(parameter)=1 and parameter[1][@type='int']]"
			[Register ("setAudioSessionId", "(I)V", "GetSetAudioSessionId_IHandler:AndroidX.Media3.ExoPlayer.IExoPlayerAudioComponentInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			set; 
		}

		bool SkipSilenceEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.AudioComponent']/method[@name='getSkipSilenceEnabled' and count(parameter)=0]"
			[Register ("getSkipSilenceEnabled", "()Z", "GetGetSkipSilenceEnabledHandler:AndroidX.Media3.ExoPlayer.IExoPlayerAudioComponentInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			get; 

			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.AudioComponent']/method[@name='setSkipSilenceEnabled' and count(parameter)=1 and parameter[1][@type='boolean']]"
			[Register ("setSkipSilenceEnabled", "(Z)V", "GetSetSkipSilenceEnabled_ZHandler:AndroidX.Media3.ExoPlayer.IExoPlayerAudioComponentInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			set; 
		}

		float Volume {
			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.AudioComponent']/method[@name='getVolume' and count(parameter)=0]"
			[Register ("getVolume", "()F", "GetGetVolumeHandler:AndroidX.Media3.ExoPlayer.IExoPlayerAudioComponentInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			get; 

			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.AudioComponent']/method[@name='setVolume' and count(parameter)=1 and parameter[1][@type='float']]"
			[Register ("setVolume", "(F)V", "GetSetVolume_FHandler:AndroidX.Media3.ExoPlayer.IExoPlayerAudioComponentInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			set; 
		}

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.AudioComponent']/method[@name='clearAuxEffectInfo' and count(parameter)=0]"
		[Obsolete (@"deprecated")]
		[Register ("clearAuxEffectInfo", "()V", "GetClearAuxEffectInfoHandler:AndroidX.Media3.ExoPlayer.IExoPlayerAudioComponentInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void ClearAuxEffectInfo ();

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.AudioComponent']/method[@name='setAudioAttributes' and count(parameter)=2 and parameter[1][@type='androidx.media3.common.AudioAttributes'] and parameter[2][@type='boolean']]"
		[Obsolete (@"deprecated")]
		[Register ("setAudioAttributes", "(Landroidx/media3/common/AudioAttributes;Z)V", "GetSetAudioAttributes_Landroidx_media3_common_AudioAttributes_ZHandler:AndroidX.Media3.ExoPlayer.IExoPlayerAudioComponentInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void SetAudioAttributes (global::AndroidX.Media3.Common.AudioAttributes? p0, bool p1);

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.AudioComponent']/method[@name='setAuxEffectInfo' and count(parameter)=1 and parameter[1][@type='androidx.media3.common.AuxEffectInfo']]"
		[Obsolete (@"deprecated")]
		[Register ("setAuxEffectInfo", "(Landroidx/media3/common/AuxEffectInfo;)V", "GetSetAuxEffectInfo_Landroidx_media3_common_AuxEffectInfo_Handler:AndroidX.Media3.ExoPlayer.IExoPlayerAudioComponentInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void SetAuxEffectInfo (global::AndroidX.Media3.Common.AuxEffectInfo? p0);

	}

	[global::Android.Runtime.Register ("androidx/media3/exoplayer/ExoPlayer$AudioComponent", DoNotGenerateAcw=true)]
	internal partial class IExoPlayerAudioComponentInvoker : global::Java.Lang.Object, IExoPlayerAudioComponent {
		static readonly JniPeerMembers _members = new XAPeerMembers ("androidx/media3/exoplayer/ExoPlayer$AudioComponent", typeof (IExoPlayerAudioComponentInvoker));

		static IntPtr java_class_ref {
			get { return _members.JniPeerType.PeerReference.Handle; }
		}

		[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]
		[global::System.ComponentModel.EditorBrowsable (global::System.ComponentModel.EditorBrowsableState.Never)]
		public override global::Java.Interop.JniPeerMembers JniPeerMembers {
			get { return _members; }
		}

		[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]
		[global::System.ComponentModel.EditorBrowsable (global::System.ComponentModel.EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]
		[global::System.ComponentModel.EditorBrowsable (global::System.ComponentModel.EditorBrowsableState.Never)]
		protected override global::System.Type ThresholdType {
			get { return _members.ManagedPeerType; }
		}

		IntPtr class_ref;

		public static IExoPlayerAudioComponent? GetObject (IntPtr handle, JniHandleOwnership transfer)
		{
			return global::Java.Lang.Object.GetObject<IExoPlayerAudioComponent> (handle, transfer);
		}

		static IntPtr Validate (IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf (handle, java_class_ref))
				throw new InvalidCastException ($"Unable to convert instance of type '{JNIEnv.GetClassNameFromInstance (handle)}' to type 'androidx.media3.exoplayer.ExoPlayer.AudioComponent'.");
			return handle;
		}

		protected override void Dispose (bool disposing)
		{
			if (this.class_ref != IntPtr.Zero)
				JNIEnv.DeleteGlobalRef (this.class_ref);
			this.class_ref = IntPtr.Zero;
			base.Dispose (disposing);
		}

		public IExoPlayerAudioComponentInvoker (IntPtr handle, JniHandleOwnership transfer) : base (Validate (handle), transfer)
		{
			IntPtr local_ref = JNIEnv.GetObjectClass (((global::Java.Lang.Object) this).Handle);
			this.class_ref = JNIEnv.NewGlobalRef (local_ref);
			JNIEnv.DeleteLocalRef (local_ref);
		}

		static Delegate? cb_getAudioAttributes;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetGetAudioAttributesHandler ()
		{
			if (cb_getAudioAttributes == null)
				cb_getAudioAttributes = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_L) n_GetAudioAttributes);
			return cb_getAudioAttributes;
		}

		[Obsolete]
		static IntPtr n_GetAudioAttributes (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerAudioComponent> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return JNIEnv.ToLocalJniHandle (__this.AudioAttributes);
		}
#pragma warning restore 0169

		IntPtr id_getAudioAttributes;
		public unsafe global::AndroidX.Media3.Common.AudioAttributes? AudioAttributes {
			get {
				if (id_getAudioAttributes == IntPtr.Zero)
					id_getAudioAttributes = JNIEnv.GetMethodID (class_ref, "getAudioAttributes", "()Landroidx/media3/common/AudioAttributes;");
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.Common.AudioAttributes> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getAudioAttributes), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate? cb_getAudioSessionId;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetGetAudioSessionIdHandler ()
		{
			if (cb_getAudioSessionId == null)
				cb_getAudioSessionId = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_I) n_GetAudioSessionId);
			return cb_getAudioSessionId;
		}

		[Obsolete]
		static int n_GetAudioSessionId (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerAudioComponent> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.AudioSessionId;
		}
#pragma warning restore 0169

		static Delegate? cb_setAudioSessionId_I;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetSetAudioSessionId_IHandler ()
		{
			if (cb_setAudioSessionId_I == null)
				cb_setAudioSessionId_I = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPI_V) n_SetAudioSessionId_I);
			return cb_setAudioSessionId_I;
		}

		[Obsolete]
		static void n_SetAudioSessionId_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerAudioComponent> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.AudioSessionId = p0;
		}
#pragma warning restore 0169

		IntPtr id_getAudioSessionId;
		IntPtr id_setAudioSessionId_I;
		public unsafe int AudioSessionId {
			get {
				if (id_getAudioSessionId == IntPtr.Zero)
					id_getAudioSessionId = JNIEnv.GetMethodID (class_ref, "getAudioSessionId", "()I");
				return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getAudioSessionId);
			}
			set {
				if (id_setAudioSessionId_I == IntPtr.Zero)
					id_setAudioSessionId_I = JNIEnv.GetMethodID (class_ref, "setAudioSessionId", "(I)V");
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (value);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setAudioSessionId_I, __args);
			}
		}

		static Delegate? cb_getSkipSilenceEnabled;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetGetSkipSilenceEnabledHandler ()
		{
			if (cb_getSkipSilenceEnabled == null)
				cb_getSkipSilenceEnabled = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_Z) n_GetSkipSilenceEnabled);
			return cb_getSkipSilenceEnabled;
		}

		[Obsolete]
		static bool n_GetSkipSilenceEnabled (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerAudioComponent> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.SkipSilenceEnabled;
		}
#pragma warning restore 0169

		static Delegate? cb_setSkipSilenceEnabled_Z;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetSetSkipSilenceEnabled_ZHandler ()
		{
			if (cb_setSkipSilenceEnabled_Z == null)
				cb_setSkipSilenceEnabled_Z = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPZ_V) n_SetSkipSilenceEnabled_Z);
			return cb_setSkipSilenceEnabled_Z;
		}

		[Obsolete]
		static void n_SetSkipSilenceEnabled_Z (IntPtr jnienv, IntPtr native__this, bool p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerAudioComponent> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.SkipSilenceEnabled = p0;
		}
#pragma warning restore 0169

		IntPtr id_getSkipSilenceEnabled;
		IntPtr id_setSkipSilenceEnabled_Z;
		public unsafe bool SkipSilenceEnabled {
			get {
				if (id_getSkipSilenceEnabled == IntPtr.Zero)
					id_getSkipSilenceEnabled = JNIEnv.GetMethodID (class_ref, "getSkipSilenceEnabled", "()Z");
				return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_getSkipSilenceEnabled);
			}
			set {
				if (id_setSkipSilenceEnabled_Z == IntPtr.Zero)
					id_setSkipSilenceEnabled_Z = JNIEnv.GetMethodID (class_ref, "setSkipSilenceEnabled", "(Z)V");
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (value);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setSkipSilenceEnabled_Z, __args);
			}
		}

		static Delegate? cb_getVolume;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetGetVolumeHandler ()
		{
			if (cb_getVolume == null)
				cb_getVolume = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_F) n_GetVolume);
			return cb_getVolume;
		}

		[Obsolete]
		static float n_GetVolume (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerAudioComponent> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.Volume;
		}
#pragma warning restore 0169

		static Delegate? cb_setVolume_F;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetSetVolume_FHandler ()
		{
			if (cb_setVolume_F == null)
				cb_setVolume_F = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPF_V) n_SetVolume_F);
			return cb_setVolume_F;
		}

		[Obsolete]
		static void n_SetVolume_F (IntPtr jnienv, IntPtr native__this, float p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerAudioComponent> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.Volume = p0;
		}
#pragma warning restore 0169

		IntPtr id_getVolume;
		IntPtr id_setVolume_F;
		public unsafe float Volume {
			get {
				if (id_getVolume == IntPtr.Zero)
					id_getVolume = JNIEnv.GetMethodID (class_ref, "getVolume", "()F");
				return JNIEnv.CallFloatMethod (((global::Java.Lang.Object) this).Handle, id_getVolume);
			}
			set {
				if (id_setVolume_F == IntPtr.Zero)
					id_setVolume_F = JNIEnv.GetMethodID (class_ref, "setVolume", "(F)V");
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (value);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setVolume_F, __args);
			}
		}

		static Delegate? cb_clearAuxEffectInfo;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetClearAuxEffectInfoHandler ()
		{
			if (cb_clearAuxEffectInfo == null)
				cb_clearAuxEffectInfo = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_V) n_ClearAuxEffectInfo);
			return cb_clearAuxEffectInfo;
		}

		[Obsolete]
		static void n_ClearAuxEffectInfo (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerAudioComponent> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.ClearAuxEffectInfo ();
		}
#pragma warning restore 0169

		IntPtr id_clearAuxEffectInfo;
		public unsafe void ClearAuxEffectInfo ()
		{
			if (id_clearAuxEffectInfo == IntPtr.Zero)
				id_clearAuxEffectInfo = JNIEnv.GetMethodID (class_ref, "clearAuxEffectInfo", "()V");
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_clearAuxEffectInfo);
		}

		static Delegate? cb_setAudioAttributes_Landroidx_media3_common_AudioAttributes_Z;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetSetAudioAttributes_Landroidx_media3_common_AudioAttributes_ZHandler ()
		{
			if (cb_setAudioAttributes_Landroidx_media3_common_AudioAttributes_Z == null)
				cb_setAudioAttributes_Landroidx_media3_common_AudioAttributes_Z = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPLZ_V) n_SetAudioAttributes_Landroidx_media3_common_AudioAttributes_Z);
			return cb_setAudioAttributes_Landroidx_media3_common_AudioAttributes_Z;
		}

		[Obsolete]
		static void n_SetAudioAttributes_Landroidx_media3_common_AudioAttributes_Z (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerAudioComponent> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.Common.AudioAttributes> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetAudioAttributes (p0, p1);
		}
#pragma warning restore 0169

		IntPtr id_setAudioAttributes_Landroidx_media3_common_AudioAttributes_Z;
		public unsafe void SetAudioAttributes (global::AndroidX.Media3.Common.AudioAttributes? p0, bool p1)
		{
			if (id_setAudioAttributes_Landroidx_media3_common_AudioAttributes_Z == IntPtr.Zero)
				id_setAudioAttributes_Landroidx_media3_common_AudioAttributes_Z = JNIEnv.GetMethodID (class_ref, "setAudioAttributes", "(Landroidx/media3/common/AudioAttributes;Z)V");
			JValue* __args = stackalloc JValue [2];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			__args [1] = new JValue (p1);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setAudioAttributes_Landroidx_media3_common_AudioAttributes_Z, __args);
		}

		static Delegate? cb_setAuxEffectInfo_Landroidx_media3_common_AuxEffectInfo_;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetSetAuxEffectInfo_Landroidx_media3_common_AuxEffectInfo_Handler ()
		{
			if (cb_setAuxEffectInfo_Landroidx_media3_common_AuxEffectInfo_ == null)
				cb_setAuxEffectInfo_Landroidx_media3_common_AuxEffectInfo_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_SetAuxEffectInfo_Landroidx_media3_common_AuxEffectInfo_);
			return cb_setAuxEffectInfo_Landroidx_media3_common_AuxEffectInfo_;
		}

		[Obsolete]
		static void n_SetAuxEffectInfo_Landroidx_media3_common_AuxEffectInfo_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerAudioComponent> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.Common.AuxEffectInfo> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetAuxEffectInfo (p0);
		}
#pragma warning restore 0169

		IntPtr id_setAuxEffectInfo_Landroidx_media3_common_AuxEffectInfo_;
		public unsafe void SetAuxEffectInfo (global::AndroidX.Media3.Common.AuxEffectInfo? p0)
		{
			if (id_setAuxEffectInfo_Landroidx_media3_common_AuxEffectInfo_ == IntPtr.Zero)
				id_setAuxEffectInfo_Landroidx_media3_common_AuxEffectInfo_ = JNIEnv.GetMethodID (class_ref, "setAuxEffectInfo", "(Landroidx/media3/common/AuxEffectInfo;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setAuxEffectInfo_Landroidx_media3_common_AuxEffectInfo_, __args);
		}

	}

	// Metadata.xml XPath interface reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.AudioOffloadListener']"
	[Register ("androidx/media3/exoplayer/ExoPlayer$AudioOffloadListener", "", "AndroidX.Media3.ExoPlayer.IExoPlayerAudioOffloadListenerInvoker")]
	public partial interface IExoPlayerAudioOffloadListener : IJavaObject, IJavaPeerable {
		private static readonly JniPeerMembers _members = new XAPeerMembers ("androidx/media3/exoplayer/ExoPlayer$AudioOffloadListener", typeof (IExoPlayerAudioOffloadListener), isInterface: true);

		private static Delegate? cb_onExperimentalOffloadSchedulingEnabledChanged_Z;
#pragma warning disable 0169
		private static Delegate GetOnExperimentalOffloadSchedulingEnabledChanged_ZHandler ()
		{
			if (cb_onExperimentalOffloadSchedulingEnabledChanged_Z == null)
				cb_onExperimentalOffloadSchedulingEnabledChanged_Z = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPZ_V) n_OnExperimentalOffloadSchedulingEnabledChanged_Z);
			return cb_onExperimentalOffloadSchedulingEnabledChanged_Z;
		}

		private static void n_OnExperimentalOffloadSchedulingEnabledChanged_Z (IntPtr jnienv, IntPtr native__this, bool offloadSchedulingEnabled)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerAudioOffloadListener> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.OnExperimentalOffloadSchedulingEnabledChanged (offloadSchedulingEnabled);
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.AudioOffloadListener']/method[@name='onExperimentalOffloadSchedulingEnabledChanged' and count(parameter)=1 and parameter[1][@type='boolean']]"
		[Register ("onExperimentalOffloadSchedulingEnabledChanged", "(Z)V", "GetOnExperimentalOffloadSchedulingEnabledChanged_ZHandler:AndroidX.Media3.ExoPlayer.IExoPlayerAudioOffloadListener, Xamarin.AndroidX.Media3.ExoPlayer")]
		virtual unsafe void OnExperimentalOffloadSchedulingEnabledChanged (bool offloadSchedulingEnabled)
		{
			const string __id = "onExperimentalOffloadSchedulingEnabledChanged.(Z)V";
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [1];
				__args [0] = new JniArgumentValue (offloadSchedulingEnabled);
				_members.InstanceMethods.InvokeVirtualVoidMethod (__id, this, __args);
			} finally {
			}
		}

		private static Delegate? cb_onExperimentalOffloadedPlayback_Z;
#pragma warning disable 0169
		private static Delegate GetOnExperimentalOffloadedPlayback_ZHandler ()
		{
			if (cb_onExperimentalOffloadedPlayback_Z == null)
				cb_onExperimentalOffloadedPlayback_Z = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPZ_V) n_OnExperimentalOffloadedPlayback_Z);
			return cb_onExperimentalOffloadedPlayback_Z;
		}

		private static void n_OnExperimentalOffloadedPlayback_Z (IntPtr jnienv, IntPtr native__this, bool offloadedPlayback)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerAudioOffloadListener> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.OnExperimentalOffloadedPlayback (offloadedPlayback);
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.AudioOffloadListener']/method[@name='onExperimentalOffloadedPlayback' and count(parameter)=1 and parameter[1][@type='boolean']]"
		[Register ("onExperimentalOffloadedPlayback", "(Z)V", "GetOnExperimentalOffloadedPlayback_ZHandler:AndroidX.Media3.ExoPlayer.IExoPlayerAudioOffloadListener, Xamarin.AndroidX.Media3.ExoPlayer")]
		virtual unsafe void OnExperimentalOffloadedPlayback (bool offloadedPlayback)
		{
			const string __id = "onExperimentalOffloadedPlayback.(Z)V";
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [1];
				__args [0] = new JniArgumentValue (offloadedPlayback);
				_members.InstanceMethods.InvokeVirtualVoidMethod (__id, this, __args);
			} finally {
			}
		}

		private static Delegate? cb_onExperimentalSleepingForOffloadChanged_Z;
#pragma warning disable 0169
		private static Delegate GetOnExperimentalSleepingForOffloadChanged_ZHandler ()
		{
			if (cb_onExperimentalSleepingForOffloadChanged_Z == null)
				cb_onExperimentalSleepingForOffloadChanged_Z = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPZ_V) n_OnExperimentalSleepingForOffloadChanged_Z);
			return cb_onExperimentalSleepingForOffloadChanged_Z;
		}

		private static void n_OnExperimentalSleepingForOffloadChanged_Z (IntPtr jnienv, IntPtr native__this, bool sleepingForOffload)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerAudioOffloadListener> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.OnExperimentalSleepingForOffloadChanged (sleepingForOffload);
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.AudioOffloadListener']/method[@name='onExperimentalSleepingForOffloadChanged' and count(parameter)=1 and parameter[1][@type='boolean']]"
		[Register ("onExperimentalSleepingForOffloadChanged", "(Z)V", "GetOnExperimentalSleepingForOffloadChanged_ZHandler:AndroidX.Media3.ExoPlayer.IExoPlayerAudioOffloadListener, Xamarin.AndroidX.Media3.ExoPlayer")]
		virtual unsafe void OnExperimentalSleepingForOffloadChanged (bool sleepingForOffload)
		{
			const string __id = "onExperimentalSleepingForOffloadChanged.(Z)V";
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [1];
				__args [0] = new JniArgumentValue (sleepingForOffload);
				_members.InstanceMethods.InvokeVirtualVoidMethod (__id, this, __args);
			} finally {
			}
		}

	}

	[global::Android.Runtime.Register ("androidx/media3/exoplayer/ExoPlayer$AudioOffloadListener", DoNotGenerateAcw=true)]
	internal partial class IExoPlayerAudioOffloadListenerInvoker : global::Java.Lang.Object, IExoPlayerAudioOffloadListener {
		static readonly JniPeerMembers _members = new XAPeerMembers ("androidx/media3/exoplayer/ExoPlayer$AudioOffloadListener", typeof (IExoPlayerAudioOffloadListenerInvoker));

		static IntPtr java_class_ref {
			get { return _members.JniPeerType.PeerReference.Handle; }
		}

		[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]
		[global::System.ComponentModel.EditorBrowsable (global::System.ComponentModel.EditorBrowsableState.Never)]
		public override global::Java.Interop.JniPeerMembers JniPeerMembers {
			get { return _members; }
		}

		[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]
		[global::System.ComponentModel.EditorBrowsable (global::System.ComponentModel.EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]
		[global::System.ComponentModel.EditorBrowsable (global::System.ComponentModel.EditorBrowsableState.Never)]
		protected override global::System.Type ThresholdType {
			get { return _members.ManagedPeerType; }
		}

		IntPtr class_ref;

		public static IExoPlayerAudioOffloadListener? GetObject (IntPtr handle, JniHandleOwnership transfer)
		{
			return global::Java.Lang.Object.GetObject<IExoPlayerAudioOffloadListener> (handle, transfer);
		}

		static IntPtr Validate (IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf (handle, java_class_ref))
				throw new InvalidCastException ($"Unable to convert instance of type '{JNIEnv.GetClassNameFromInstance (handle)}' to type 'androidx.media3.exoplayer.ExoPlayer.AudioOffloadListener'.");
			return handle;
		}

		protected override void Dispose (bool disposing)
		{
			if (this.class_ref != IntPtr.Zero)
				JNIEnv.DeleteGlobalRef (this.class_ref);
			this.class_ref = IntPtr.Zero;
			base.Dispose (disposing);
		}

		public IExoPlayerAudioOffloadListenerInvoker (IntPtr handle, JniHandleOwnership transfer) : base (Validate (handle), transfer)
		{
			IntPtr local_ref = JNIEnv.GetObjectClass (((global::Java.Lang.Object) this).Handle);
			this.class_ref = JNIEnv.NewGlobalRef (local_ref);
			JNIEnv.DeleteLocalRef (local_ref);
		}

	}

	// event args for androidx.media3.exoplayer.ExoPlayer.AudioOffloadListener.onExperimentalOffloadSchedulingEnabledChanged
	public partial class ExperimentalOffloadSchedulingEnabledChangedEventArgs : global::System.EventArgs {
		public ExperimentalOffloadSchedulingEnabledChangedEventArgs (bool offloadSchedulingEnabled)
		{
			this.offloadSchedulingEnabled = offloadSchedulingEnabled;
		}

		bool offloadSchedulingEnabled;

		public bool OffloadSchedulingEnabled {
			get { return offloadSchedulingEnabled; }
		}

	}

	// event args for androidx.media3.exoplayer.ExoPlayer.AudioOffloadListener.onExperimentalOffloadedPlayback
	public partial class ExperimentalOffloadedPlaybackEventArgs : global::System.EventArgs {
		public ExperimentalOffloadedPlaybackEventArgs (bool offloadedPlayback)
		{
			this.offloadedPlayback = offloadedPlayback;
		}

		bool offloadedPlayback;

		public bool OffloadedPlayback {
			get { return offloadedPlayback; }
		}

	}

	// event args for androidx.media3.exoplayer.ExoPlayer.AudioOffloadListener.onExperimentalSleepingForOffloadChanged
	public partial class ExperimentalSleepingForOffloadChangedEventArgs : global::System.EventArgs {
		public ExperimentalSleepingForOffloadChangedEventArgs (bool sleepingForOffload)
		{
			this.sleepingForOffload = sleepingForOffload;
		}

		bool sleepingForOffload;

		public bool SleepingForOffload {
			get { return sleepingForOffload; }
		}

	}

	[global::Android.Runtime.Register ("mono/androidx/media3/exoplayer/ExoPlayer_AudioOffloadListenerImplementor")]
	internal sealed partial class IExoPlayerAudioOffloadListenerImplementor : global::Java.Lang.Object, IExoPlayerAudioOffloadListener {

		object sender;

		public IExoPlayerAudioOffloadListenerImplementor (object sender) : base (global::Android.Runtime.JNIEnv.StartCreateInstance ("mono/androidx/media3/exoplayer/ExoPlayer_AudioOffloadListenerImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
		{
			global::Android.Runtime.JNIEnv.FinishCreateInstance (((global::Java.Lang.Object) this).Handle, "()V");
			this.sender = sender;
		}

		#pragma warning disable 0649
		public EventHandler<ExperimentalOffloadSchedulingEnabledChangedEventArgs>? OnExperimentalOffloadSchedulingEnabledChangedHandler;
		#pragma warning restore 0649

		public void OnExperimentalOffloadSchedulingEnabledChanged (bool offloadSchedulingEnabled)
		{
			var __h = OnExperimentalOffloadSchedulingEnabledChangedHandler;
			if (__h != null)
				__h (sender, new ExperimentalOffloadSchedulingEnabledChangedEventArgs (offloadSchedulingEnabled));
		}

		#pragma warning disable 0649
		public EventHandler<ExperimentalOffloadedPlaybackEventArgs>? OnExperimentalOffloadedPlaybackHandler;
		#pragma warning restore 0649

		public void OnExperimentalOffloadedPlayback (bool offloadedPlayback)
		{
			var __h = OnExperimentalOffloadedPlaybackHandler;
			if (__h != null)
				__h (sender, new ExperimentalOffloadedPlaybackEventArgs (offloadedPlayback));
		}

		#pragma warning disable 0649
		public EventHandler<ExperimentalSleepingForOffloadChangedEventArgs>? OnExperimentalSleepingForOffloadChangedHandler;
		#pragma warning restore 0649

		public void OnExperimentalSleepingForOffloadChanged (bool sleepingForOffload)
		{
			var __h = OnExperimentalSleepingForOffloadChangedHandler;
			if (__h != null)
				__h (sender, new ExperimentalSleepingForOffloadChangedEventArgs (sleepingForOffload));
		}

		internal static bool __IsEmpty (IExoPlayerAudioOffloadListenerImplementor value)
		{
			return value.OnExperimentalOffloadSchedulingEnabledChangedHandler == null && value.OnExperimentalOffloadedPlaybackHandler == null && value.OnExperimentalSleepingForOffloadChangedHandler == null;
		}

	}

	// Metadata.xml XPath class reference: path="/api/package[@name='androidx.media3.exoplayer']/class[@name='ExoPlayer.Builder']"
	[global::Android.Runtime.Register ("androidx/media3/exoplayer/ExoPlayer$Builder", DoNotGenerateAcw=true)]
	public sealed partial class ExoPlayerBuilder : global::Java.Lang.Object {
		static readonly JniPeerMembers _members = new XAPeerMembers ("androidx/media3/exoplayer/ExoPlayer$Builder", typeof (ExoPlayerBuilder));

		internal static IntPtr class_ref {
			get { return _members.JniPeerType.PeerReference.Handle; }
		}

		[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]
		[global::System.ComponentModel.EditorBrowsable (global::System.ComponentModel.EditorBrowsableState.Never)]
		public override global::Java.Interop.JniPeerMembers JniPeerMembers {
			get { return _members; }
		}

		[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]
		[global::System.ComponentModel.EditorBrowsable (global::System.ComponentModel.EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass {
			get { return _members.JniPeerType.PeerReference.Handle; }
		}

		[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]
		[global::System.ComponentModel.EditorBrowsable (global::System.ComponentModel.EditorBrowsableState.Never)]
		protected override global::System.Type ThresholdType {
			get { return _members.ManagedPeerType; }
		}

		internal ExoPlayerBuilder (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer)
		{
		}

		// Metadata.xml XPath constructor reference: path="/api/package[@name='androidx.media3.exoplayer']/class[@name='ExoPlayer.Builder']/constructor[@name='ExoPlayer.Builder' and count(parameter)=1 and parameter[1][@type='android.content.Context']]"
		[Register (".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe ExoPlayerBuilder (global::Android.Content.Context? context) : base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			const string __id = "(Landroid/content/Context;)V";

			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [1];
				__args [0] = new JniArgumentValue ((context == null) ? IntPtr.Zero : ((global::Java.Lang.Object) context).Handle);
				var __r = _members.InstanceMethods.StartCreateInstance (__id, ((object) this).GetType (), __args);
				SetHandle (__r.Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance (__id, this, __args);
			} finally {
				global::System.GC.KeepAlive (context);
			}
		}

		/*
		// Metadata.xml XPath constructor reference: path="/api/package[@name='androidx.media3.exoplayer']/class[@name='ExoPlayer.Builder']/constructor[@name='ExoPlayer.Builder' and count(parameter)=2 and parameter[1][@type='android.content.Context'] and parameter[2][@type='androidx.media3.exoplayer.RenderersFactory']]"
		[Register (".ctor", "(Landroid/content/Context;Landroidx/media3/exoplayer/RenderersFactory;)V", "")]
		public unsafe ExoPlayerBuilder (global::Android.Content.Context? context, global::AndroidX.Media3.ExoPlayer.IRenderersFactory? renderersFactory) : base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			const string __id = "(Landroid/content/Context;Landroidx/media3/exoplayer/RenderersFactory;)V";

			if (((global::Java.Lang.Object) this).Handle != IntPtr.Zero)
				return;

			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [2];
				__args [0] = new JniArgumentValue ((context == null) ? IntPtr.Zero : ((global::Java.Lang.Object) context).Handle);
				__args [1] = new JniArgumentValue ((renderersFactory == null) ? IntPtr.Zero : ((global::Java.Lang.Object) renderersFactory).Handle);
				var __r = _members.InstanceMethods.StartCreateInstance (__id, ((object) this).GetType (), __args);
				SetHandle (__r.Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance (__id, this, __args);
			} finally {
				global::System.GC.KeepAlive (context);
				global::System.GC.KeepAlive (renderersFactory);
			}
		}
		*/

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/class[@name='ExoPlayer.Builder']/method[@name='build' and count(parameter)=0]"
		[Register ("build", "()Landroidx/media3/exoplayer/ExoPlayer;", "")]
		public unsafe global::AndroidX.Media3.ExoPlayer.IExoPlayer? Build ()
		{
			const string __id = "build.()Landroidx/media3/exoplayer/ExoPlayer;";
			try {
				var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod (__id, this, null);
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (__rm.Handle, JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/class[@name='ExoPlayer.Builder']/method[@name='experimentalSetForegroundModeTimeoutMs' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("experimentalSetForegroundModeTimeoutMs", "(J)Landroidx/media3/exoplayer/ExoPlayer$Builder;", "")]
		public unsafe global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder? ExperimentalSetForegroundModeTimeoutMs (long timeoutMs)
		{
			const string __id = "experimentalSetForegroundModeTimeoutMs.(J)Landroidx/media3/exoplayer/ExoPlayer$Builder;";
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [1];
				__args [0] = new JniArgumentValue (timeoutMs);
				var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod (__id, this, __args);
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder> (__rm.Handle, JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		/*
		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/class[@name='ExoPlayer.Builder']/method[@name='setAnalyticsCollector' and count(parameter)=1 and parameter[1][@type='androidx.media3.exoplayer.analytics.AnalyticsCollector']]"
		[Register ("setAnalyticsCollector", "(Landroidx/media3/exoplayer/analytics/AnalyticsCollector;)Landroidx/media3/exoplayer/ExoPlayer$Builder;", "")]
		public unsafe global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder? SetAnalyticsCollector (global::AndroidX.Media3.ExoPlayer.Analytics.IAnalyticsCollector? analyticsCollector)
		{
			const string __id = "setAnalyticsCollector.(Landroidx/media3/exoplayer/analytics/AnalyticsCollector;)Landroidx/media3/exoplayer/ExoPlayer$Builder;";
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [1];
				__args [0] = new JniArgumentValue ((analyticsCollector == null) ? IntPtr.Zero : ((global::Java.Lang.Object) analyticsCollector).Handle);
				var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod (__id, this, __args);
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder> (__rm.Handle, JniHandleOwnership.TransferLocalRef);
			} finally {
				global::System.GC.KeepAlive (analyticsCollector);
			}
		}
		*/

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/class[@name='ExoPlayer.Builder']/method[@name='setAudioAttributes' and count(parameter)=2 and parameter[1][@type='androidx.media3.common.AudioAttributes'] and parameter[2][@type='boolean']]"
		[Register ("setAudioAttributes", "(Landroidx/media3/common/AudioAttributes;Z)Landroidx/media3/exoplayer/ExoPlayer$Builder;", "")]
		public unsafe global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder? SetAudioAttributes (global::AndroidX.Media3.Common.AudioAttributes? audioAttributes, bool handleAudioFocus)
		{
			const string __id = "setAudioAttributes.(Landroidx/media3/common/AudioAttributes;Z)Landroidx/media3/exoplayer/ExoPlayer$Builder;";
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [2];
				__args [0] = new JniArgumentValue ((audioAttributes == null) ? IntPtr.Zero : ((global::Java.Lang.Object) audioAttributes).Handle);
				__args [1] = new JniArgumentValue (handleAudioFocus);
				var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod (__id, this, __args);
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder> (__rm.Handle, JniHandleOwnership.TransferLocalRef);
			} finally {
				global::System.GC.KeepAlive (audioAttributes);
			}
		}

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/class[@name='ExoPlayer.Builder']/method[@name='setBandwidthMeter' and count(parameter)=1 and parameter[1][@type='androidx.media3.exoplayer.upstream.BandwidthMeter']]"
		[Register ("setBandwidthMeter", "(Landroidx/media3/exoplayer/upstream/BandwidthMeter;)Landroidx/media3/exoplayer/ExoPlayer$Builder;", "")]
		public unsafe global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder? SetBandwidthMeter (global::AndroidX.Media3.ExoPlayer.Upstream.IBandwidthMeter? bandwidthMeter)
		{
			const string __id = "setBandwidthMeter.(Landroidx/media3/exoplayer/upstream/BandwidthMeter;)Landroidx/media3/exoplayer/ExoPlayer$Builder;";
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [1];
				__args [0] = new JniArgumentValue ((bandwidthMeter == null) ? IntPtr.Zero : ((global::Java.Lang.Object) bandwidthMeter).Handle);
				var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod (__id, this, __args);
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder> (__rm.Handle, JniHandleOwnership.TransferLocalRef);
			} finally {
				global::System.GC.KeepAlive (bandwidthMeter);
			}
		}

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/class[@name='ExoPlayer.Builder']/method[@name='setClock' and count(parameter)=1 and parameter[1][@type='androidx.media3.common.util.Clock']]"
		[Register ("setClock", "(Landroidx/media3/common/util/Clock;)Landroidx/media3/exoplayer/ExoPlayer$Builder;", "")]
		public unsafe global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder? SetClock (global::AndroidX.Media3.Common.Util.IClock? clock)
		{
			const string __id = "setClock.(Landroidx/media3/common/util/Clock;)Landroidx/media3/exoplayer/ExoPlayer$Builder;";
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [1];
				__args [0] = new JniArgumentValue ((clock == null) ? IntPtr.Zero : ((global::Java.Lang.Object) clock).Handle);
				var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod (__id, this, __args);
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder> (__rm.Handle, JniHandleOwnership.TransferLocalRef);
			} finally {
				global::System.GC.KeepAlive (clock);
			}
		}

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/class[@name='ExoPlayer.Builder']/method[@name='setDetachSurfaceTimeoutMs' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("setDetachSurfaceTimeoutMs", "(J)Landroidx/media3/exoplayer/ExoPlayer$Builder;", "")]
		public unsafe global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder? SetDetachSurfaceTimeoutMs (long detachSurfaceTimeoutMs)
		{
			const string __id = "setDetachSurfaceTimeoutMs.(J)Landroidx/media3/exoplayer/ExoPlayer$Builder;";
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [1];
				__args [0] = new JniArgumentValue (detachSurfaceTimeoutMs);
				var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod (__id, this, __args);
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder> (__rm.Handle, JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/class[@name='ExoPlayer.Builder']/method[@name='setHandleAudioBecomingNoisy' and count(parameter)=1 and parameter[1][@type='boolean']]"
		[Register ("setHandleAudioBecomingNoisy", "(Z)Landroidx/media3/exoplayer/ExoPlayer$Builder;", "")]
		public unsafe global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder? SetHandleAudioBecomingNoisy (bool handleAudioBecomingNoisy)
		{
			const string __id = "setHandleAudioBecomingNoisy.(Z)Landroidx/media3/exoplayer/ExoPlayer$Builder;";
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [1];
				__args [0] = new JniArgumentValue (handleAudioBecomingNoisy);
				var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod (__id, this, __args);
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder> (__rm.Handle, JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/class[@name='ExoPlayer.Builder']/method[@name='setLivePlaybackSpeedControl' and count(parameter)=1 and parameter[1][@type='androidx.media3.exoplayer.LivePlaybackSpeedControl']]"
		[Register ("setLivePlaybackSpeedControl", "(Landroidx/media3/exoplayer/LivePlaybackSpeedControl;)Landroidx/media3/exoplayer/ExoPlayer$Builder;", "")]
		public unsafe global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder? SetLivePlaybackSpeedControl (global::AndroidX.Media3.ExoPlayer.ILivePlaybackSpeedControl? livePlaybackSpeedControl)
		{
			const string __id = "setLivePlaybackSpeedControl.(Landroidx/media3/exoplayer/LivePlaybackSpeedControl;)Landroidx/media3/exoplayer/ExoPlayer$Builder;";
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [1];
				__args [0] = new JniArgumentValue ((livePlaybackSpeedControl == null) ? IntPtr.Zero : ((global::Java.Lang.Object) livePlaybackSpeedControl).Handle);
				var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod (__id, this, __args);
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder> (__rm.Handle, JniHandleOwnership.TransferLocalRef);
			} finally {
				global::System.GC.KeepAlive (livePlaybackSpeedControl);
			}
		}

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/class[@name='ExoPlayer.Builder']/method[@name='setLoadControl' and count(parameter)=1 and parameter[1][@type='androidx.media3.exoplayer.LoadControl']]"
		[Register ("setLoadControl", "(Landroidx/media3/exoplayer/LoadControl;)Landroidx/media3/exoplayer/ExoPlayer$Builder;", "")]
		public unsafe global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder? SetLoadControl (global::AndroidX.Media3.ExoPlayer.ILoadControl? loadControl)
		{
			const string __id = "setLoadControl.(Landroidx/media3/exoplayer/LoadControl;)Landroidx/media3/exoplayer/ExoPlayer$Builder;";
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [1];
				__args [0] = new JniArgumentValue ((loadControl == null) ? IntPtr.Zero : ((global::Java.Lang.Object) loadControl).Handle);
				var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod (__id, this, __args);
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder> (__rm.Handle, JniHandleOwnership.TransferLocalRef);
			} finally {
				global::System.GC.KeepAlive (loadControl);
			}
		}

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/class[@name='ExoPlayer.Builder']/method[@name='setLooper' and count(parameter)=1 and parameter[1][@type='android.os.Looper']]"
		[Register ("setLooper", "(Landroid/os/Looper;)Landroidx/media3/exoplayer/ExoPlayer$Builder;", "")]
		public unsafe global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder? SetLooper (global::Android.OS.Looper? looper)
		{
			const string __id = "setLooper.(Landroid/os/Looper;)Landroidx/media3/exoplayer/ExoPlayer$Builder;";
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [1];
				__args [0] = new JniArgumentValue ((looper == null) ? IntPtr.Zero : ((global::Java.Lang.Object) looper).Handle);
				var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod (__id, this, __args);
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder> (__rm.Handle, JniHandleOwnership.TransferLocalRef);
			} finally {
				global::System.GC.KeepAlive (looper);
			}
		}

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/class[@name='ExoPlayer.Builder']/method[@name='setPauseAtEndOfMediaItems' and count(parameter)=1 and parameter[1][@type='boolean']]"
		[Register ("setPauseAtEndOfMediaItems", "(Z)Landroidx/media3/exoplayer/ExoPlayer$Builder;", "")]
		public unsafe global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder? SetPauseAtEndOfMediaItems (bool pauseAtEndOfMediaItems)
		{
			const string __id = "setPauseAtEndOfMediaItems.(Z)Landroidx/media3/exoplayer/ExoPlayer$Builder;";
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [1];
				__args [0] = new JniArgumentValue (pauseAtEndOfMediaItems);
				var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod (__id, this, __args);
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder> (__rm.Handle, JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/class[@name='ExoPlayer.Builder']/method[@name='setPlaybackLooper' and count(parameter)=1 and parameter[1][@type='android.os.Looper']]"
		[Register ("setPlaybackLooper", "(Landroid/os/Looper;)Landroidx/media3/exoplayer/ExoPlayer$Builder;", "")]
		public unsafe global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder? SetPlaybackLooper (global::Android.OS.Looper? playbackLooper)
		{
			const string __id = "setPlaybackLooper.(Landroid/os/Looper;)Landroidx/media3/exoplayer/ExoPlayer$Builder;";
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [1];
				__args [0] = new JniArgumentValue ((playbackLooper == null) ? IntPtr.Zero : ((global::Java.Lang.Object) playbackLooper).Handle);
				var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod (__id, this, __args);
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder> (__rm.Handle, JniHandleOwnership.TransferLocalRef);
			} finally {
				global::System.GC.KeepAlive (playbackLooper);
			}
		}

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/class[@name='ExoPlayer.Builder']/method[@name='setPriorityTaskManager' and count(parameter)=1 and parameter[1][@type='androidx.media3.common.PriorityTaskManager']]"
		[Register ("setPriorityTaskManager", "(Landroidx/media3/common/PriorityTaskManager;)Landroidx/media3/exoplayer/ExoPlayer$Builder;", "")]
		public unsafe global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder? SetPriorityTaskManager (global::AndroidX.Media3.Common.PriorityTaskManager? priorityTaskManager)
		{
			const string __id = "setPriorityTaskManager.(Landroidx/media3/common/PriorityTaskManager;)Landroidx/media3/exoplayer/ExoPlayer$Builder;";
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [1];
				__args [0] = new JniArgumentValue ((priorityTaskManager == null) ? IntPtr.Zero : ((global::Java.Lang.Object) priorityTaskManager).Handle);
				var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod (__id, this, __args);
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder> (__rm.Handle, JniHandleOwnership.TransferLocalRef);
			} finally {
				global::System.GC.KeepAlive (priorityTaskManager);
			}
		}

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/class[@name='ExoPlayer.Builder']/method[@name='setReleaseTimeoutMs' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("setReleaseTimeoutMs", "(J)Landroidx/media3/exoplayer/ExoPlayer$Builder;", "")]
		public unsafe global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder? SetReleaseTimeoutMs (long releaseTimeoutMs)
		{
			const string __id = "setReleaseTimeoutMs.(J)Landroidx/media3/exoplayer/ExoPlayer$Builder;";
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [1];
				__args [0] = new JniArgumentValue (releaseTimeoutMs);
				var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod (__id, this, __args);
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder> (__rm.Handle, JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		/*
		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/class[@name='ExoPlayer.Builder']/method[@name='setRenderersFactory' and count(parameter)=1 and parameter[1][@type='androidx.media3.exoplayer.RenderersFactory']]"
		[Register ("setRenderersFactory", "(Landroidx/media3/exoplayer/RenderersFactory;)Landroidx/media3/exoplayer/ExoPlayer$Builder;", "")]
		public unsafe global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder? SetRenderersFactory (global::AndroidX.Media3.ExoPlayer.IRenderersFactory? renderersFactory)
		{
			const string __id = "setRenderersFactory.(Landroidx/media3/exoplayer/RenderersFactory;)Landroidx/media3/exoplayer/ExoPlayer$Builder;";
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [1];
				__args [0] = new JniArgumentValue ((renderersFactory == null) ? IntPtr.Zero : ((global::Java.Lang.Object) renderersFactory).Handle);
				var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod (__id, this, __args);
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder> (__rm.Handle, JniHandleOwnership.TransferLocalRef);
			} finally {
				global::System.GC.KeepAlive (renderersFactory);
			}
		}
		*/

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/class[@name='ExoPlayer.Builder']/method[@name='setSeekBackIncrementMs' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("setSeekBackIncrementMs", "(J)Landroidx/media3/exoplayer/ExoPlayer$Builder;", "")]
		public unsafe global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder? SetSeekBackIncrementMs (long seekBackIncrementMs)
		{
			const string __id = "setSeekBackIncrementMs.(J)Landroidx/media3/exoplayer/ExoPlayer$Builder;";
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [1];
				__args [0] = new JniArgumentValue (seekBackIncrementMs);
				var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod (__id, this, __args);
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder> (__rm.Handle, JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/class[@name='ExoPlayer.Builder']/method[@name='setSeekForwardIncrementMs' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("setSeekForwardIncrementMs", "(J)Landroidx/media3/exoplayer/ExoPlayer$Builder;", "")]
		public unsafe global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder? SetSeekForwardIncrementMs (long seekForwardIncrementMs)
		{
			const string __id = "setSeekForwardIncrementMs.(J)Landroidx/media3/exoplayer/ExoPlayer$Builder;";
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [1];
				__args [0] = new JniArgumentValue (seekForwardIncrementMs);
				var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod (__id, this, __args);
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder> (__rm.Handle, JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/class[@name='ExoPlayer.Builder']/method[@name='setSeekParameters' and count(parameter)=1 and parameter[1][@type='androidx.media3.exoplayer.SeekParameters']]"
		[Register ("setSeekParameters", "(Landroidx/media3/exoplayer/SeekParameters;)Landroidx/media3/exoplayer/ExoPlayer$Builder;", "")]
		public unsafe global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder? SetSeekParameters (global::AndroidX.Media3.ExoPlayer.SeekParameters? seekParameters)
		{
			const string __id = "setSeekParameters.(Landroidx/media3/exoplayer/SeekParameters;)Landroidx/media3/exoplayer/ExoPlayer$Builder;";
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [1];
				__args [0] = new JniArgumentValue ((seekParameters == null) ? IntPtr.Zero : ((global::Java.Lang.Object) seekParameters).Handle);
				var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod (__id, this, __args);
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder> (__rm.Handle, JniHandleOwnership.TransferLocalRef);
			} finally {
				global::System.GC.KeepAlive (seekParameters);
			}
		}

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/class[@name='ExoPlayer.Builder']/method[@name='setSkipSilenceEnabled' and count(parameter)=1 and parameter[1][@type='boolean']]"
		[Register ("setSkipSilenceEnabled", "(Z)Landroidx/media3/exoplayer/ExoPlayer$Builder;", "")]
		public unsafe global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder? SetSkipSilenceEnabled (bool skipSilenceEnabled)
		{
			const string __id = "setSkipSilenceEnabled.(Z)Landroidx/media3/exoplayer/ExoPlayer$Builder;";
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [1];
				__args [0] = new JniArgumentValue (skipSilenceEnabled);
				var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod (__id, this, __args);
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder> (__rm.Handle, JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/class[@name='ExoPlayer.Builder']/method[@name='setTrackSelector' and count(parameter)=1 and parameter[1][@type='androidx.media3.exoplayer.trackselection.TrackSelector']]"
		[Register ("setTrackSelector", "(Landroidx/media3/exoplayer/trackselection/TrackSelector;)Landroidx/media3/exoplayer/ExoPlayer$Builder;", "")]
		public unsafe global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder? SetTrackSelector (global::AndroidX.Media3.ExoPlayer.Trackselection.TrackSelector? trackSelector)
		{
			const string __id = "setTrackSelector.(Landroidx/media3/exoplayer/trackselection/TrackSelector;)Landroidx/media3/exoplayer/ExoPlayer$Builder;";
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [1];
				__args [0] = new JniArgumentValue ((trackSelector == null) ? IntPtr.Zero : ((global::Java.Lang.Object) trackSelector).Handle);
				var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod (__id, this, __args);
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder> (__rm.Handle, JniHandleOwnership.TransferLocalRef);
			} finally {
				global::System.GC.KeepAlive (trackSelector);
			}
		}

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/class[@name='ExoPlayer.Builder']/method[@name='setUseLazyPreparation' and count(parameter)=1 and parameter[1][@type='boolean']]"
		[Register ("setUseLazyPreparation", "(Z)Landroidx/media3/exoplayer/ExoPlayer$Builder;", "")]
		public unsafe global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder? SetUseLazyPreparation (bool useLazyPreparation)
		{
			const string __id = "setUseLazyPreparation.(Z)Landroidx/media3/exoplayer/ExoPlayer$Builder;";
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [1];
				__args [0] = new JniArgumentValue (useLazyPreparation);
				var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod (__id, this, __args);
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder> (__rm.Handle, JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/class[@name='ExoPlayer.Builder']/method[@name='setUsePlatformDiagnostics' and count(parameter)=1 and parameter[1][@type='boolean']]"
		[Register ("setUsePlatformDiagnostics", "(Z)Landroidx/media3/exoplayer/ExoPlayer$Builder;", "")]
		public unsafe global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder? SetUsePlatformDiagnostics (bool usePlatformDiagnostics)
		{
			const string __id = "setUsePlatformDiagnostics.(Z)Landroidx/media3/exoplayer/ExoPlayer$Builder;";
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [1];
				__args [0] = new JniArgumentValue (usePlatformDiagnostics);
				var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod (__id, this, __args);
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder> (__rm.Handle, JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/class[@name='ExoPlayer.Builder']/method[@name='setVideoChangeFrameRateStrategy' and count(parameter)=1 and parameter[1][@type='int']]"
		[Register ("setVideoChangeFrameRateStrategy", "(I)Landroidx/media3/exoplayer/ExoPlayer$Builder;", "")]
		public unsafe global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder? SetVideoChangeFrameRateStrategy (int videoChangeFrameRateStrategy)
		{
			const string __id = "setVideoChangeFrameRateStrategy.(I)Landroidx/media3/exoplayer/ExoPlayer$Builder;";
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [1];
				__args [0] = new JniArgumentValue (videoChangeFrameRateStrategy);
				var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod (__id, this, __args);
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder> (__rm.Handle, JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/class[@name='ExoPlayer.Builder']/method[@name='setVideoScalingMode' and count(parameter)=1 and parameter[1][@type='int']]"
		[Register ("setVideoScalingMode", "(I)Landroidx/media3/exoplayer/ExoPlayer$Builder;", "")]
		public unsafe global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder? SetVideoScalingMode (int videoScalingMode)
		{
			const string __id = "setVideoScalingMode.(I)Landroidx/media3/exoplayer/ExoPlayer$Builder;";
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [1];
				__args [0] = new JniArgumentValue (videoScalingMode);
				var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod (__id, this, __args);
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder> (__rm.Handle, JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/class[@name='ExoPlayer.Builder']/method[@name='setWakeMode' and count(parameter)=1 and parameter[1][@type='int']]"
		[Register ("setWakeMode", "(I)Landroidx/media3/exoplayer/ExoPlayer$Builder;", "")]
		public unsafe global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder? SetWakeMode (int wakeMode)
		{
			const string __id = "setWakeMode.(I)Landroidx/media3/exoplayer/ExoPlayer$Builder;";
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [1];
				__args [0] = new JniArgumentValue (wakeMode);
				var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod (__id, this, __args);
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.ExoPlayerBuilder> (__rm.Handle, JniHandleOwnership.TransferLocalRef);
			} finally {
			}
		}

	}

	// Metadata.xml XPath interface reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.DeviceComponent']"
	[ObsoleteAttribute (@"This class is obsoleted in this android platform")]
	[Register ("androidx/media3/exoplayer/ExoPlayer$DeviceComponent", "", "AndroidX.Media3.ExoPlayer.IExoPlayerDeviceComponentInvoker")]
	public partial interface IExoPlayerDeviceComponent : IJavaObject, IJavaPeerable {
		global::AndroidX.Media3.Common.DeviceInfo? DeviceInfo {
			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.DeviceComponent']/method[@name='getDeviceInfo' and count(parameter)=0]"
			[Register ("getDeviceInfo", "()Landroidx/media3/common/DeviceInfo;", "GetGetDeviceInfoHandler:AndroidX.Media3.ExoPlayer.IExoPlayerDeviceComponentInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			get; 
		}

		bool DeviceMuted {
			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.DeviceComponent']/method[@name='isDeviceMuted' and count(parameter)=0]"
			[Register ("isDeviceMuted", "()Z", "GetIsDeviceMutedHandler:AndroidX.Media3.ExoPlayer.IExoPlayerDeviceComponentInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			get; 

			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.DeviceComponent']/method[@name='setDeviceMuted' and count(parameter)=1 and parameter[1][@type='boolean']]"
			[Register ("setDeviceMuted", "(Z)V", "GetSetDeviceMuted_ZHandler:AndroidX.Media3.ExoPlayer.IExoPlayerDeviceComponentInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			set; 
		}

		int DeviceVolume {
			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.DeviceComponent']/method[@name='getDeviceVolume' and count(parameter)=0]"
			[Register ("getDeviceVolume", "()I", "GetGetDeviceVolumeHandler:AndroidX.Media3.ExoPlayer.IExoPlayerDeviceComponentInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			get; 

			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.DeviceComponent']/method[@name='setDeviceVolume' and count(parameter)=1 and parameter[1][@type='int']]"
			[Register ("setDeviceVolume", "(I)V", "GetSetDeviceVolume_IHandler:AndroidX.Media3.ExoPlayer.IExoPlayerDeviceComponentInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			set; 
		}

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.DeviceComponent']/method[@name='decreaseDeviceVolume' and count(parameter)=0]"
		[Obsolete (@"deprecated")]
		[Register ("decreaseDeviceVolume", "()V", "GetDecreaseDeviceVolumeHandler:AndroidX.Media3.ExoPlayer.IExoPlayerDeviceComponentInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void DecreaseDeviceVolume ();

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.DeviceComponent']/method[@name='increaseDeviceVolume' and count(parameter)=0]"
		[Obsolete (@"deprecated")]
		[Register ("increaseDeviceVolume", "()V", "GetIncreaseDeviceVolumeHandler:AndroidX.Media3.ExoPlayer.IExoPlayerDeviceComponentInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void IncreaseDeviceVolume ();

	}

	[global::Android.Runtime.Register ("androidx/media3/exoplayer/ExoPlayer$DeviceComponent", DoNotGenerateAcw=true)]
	internal partial class IExoPlayerDeviceComponentInvoker : global::Java.Lang.Object, IExoPlayerDeviceComponent {
		static readonly JniPeerMembers _members = new XAPeerMembers ("androidx/media3/exoplayer/ExoPlayer$DeviceComponent", typeof (IExoPlayerDeviceComponentInvoker));

		static IntPtr java_class_ref {
			get { return _members.JniPeerType.PeerReference.Handle; }
		}

		[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]
		[global::System.ComponentModel.EditorBrowsable (global::System.ComponentModel.EditorBrowsableState.Never)]
		public override global::Java.Interop.JniPeerMembers JniPeerMembers {
			get { return _members; }
		}

		[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]
		[global::System.ComponentModel.EditorBrowsable (global::System.ComponentModel.EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]
		[global::System.ComponentModel.EditorBrowsable (global::System.ComponentModel.EditorBrowsableState.Never)]
		protected override global::System.Type ThresholdType {
			get { return _members.ManagedPeerType; }
		}

		IntPtr class_ref;

		public static IExoPlayerDeviceComponent? GetObject (IntPtr handle, JniHandleOwnership transfer)
		{
			return global::Java.Lang.Object.GetObject<IExoPlayerDeviceComponent> (handle, transfer);
		}

		static IntPtr Validate (IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf (handle, java_class_ref))
				throw new InvalidCastException ($"Unable to convert instance of type '{JNIEnv.GetClassNameFromInstance (handle)}' to type 'androidx.media3.exoplayer.ExoPlayer.DeviceComponent'.");
			return handle;
		}

		protected override void Dispose (bool disposing)
		{
			if (this.class_ref != IntPtr.Zero)
				JNIEnv.DeleteGlobalRef (this.class_ref);
			this.class_ref = IntPtr.Zero;
			base.Dispose (disposing);
		}

		public IExoPlayerDeviceComponentInvoker (IntPtr handle, JniHandleOwnership transfer) : base (Validate (handle), transfer)
		{
			IntPtr local_ref = JNIEnv.GetObjectClass (((global::Java.Lang.Object) this).Handle);
			this.class_ref = JNIEnv.NewGlobalRef (local_ref);
			JNIEnv.DeleteLocalRef (local_ref);
		}

		static Delegate? cb_getDeviceInfo;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetGetDeviceInfoHandler ()
		{
			if (cb_getDeviceInfo == null)
				cb_getDeviceInfo = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_L) n_GetDeviceInfo);
			return cb_getDeviceInfo;
		}

		[Obsolete]
		static IntPtr n_GetDeviceInfo (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerDeviceComponent> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return JNIEnv.ToLocalJniHandle (__this.DeviceInfo);
		}
#pragma warning restore 0169

		IntPtr id_getDeviceInfo;
		public unsafe global::AndroidX.Media3.Common.DeviceInfo? DeviceInfo {
			get {
				if (id_getDeviceInfo == IntPtr.Zero)
					id_getDeviceInfo = JNIEnv.GetMethodID (class_ref, "getDeviceInfo", "()Landroidx/media3/common/DeviceInfo;");
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.Common.DeviceInfo> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getDeviceInfo), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate? cb_isDeviceMuted;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetIsDeviceMutedHandler ()
		{
			if (cb_isDeviceMuted == null)
				cb_isDeviceMuted = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_Z) n_IsDeviceMuted);
			return cb_isDeviceMuted;
		}

		[Obsolete]
		static bool n_IsDeviceMuted (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerDeviceComponent> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.DeviceMuted;
		}
#pragma warning restore 0169

		static Delegate? cb_setDeviceMuted_Z;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetSetDeviceMuted_ZHandler ()
		{
			if (cb_setDeviceMuted_Z == null)
				cb_setDeviceMuted_Z = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPZ_V) n_SetDeviceMuted_Z);
			return cb_setDeviceMuted_Z;
		}

		[Obsolete]
		static void n_SetDeviceMuted_Z (IntPtr jnienv, IntPtr native__this, bool p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerDeviceComponent> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.DeviceMuted = p0;
		}
#pragma warning restore 0169

		IntPtr id_isDeviceMuted;
		IntPtr id_setDeviceMuted_Z;
		public unsafe bool DeviceMuted {
			get {
				if (id_isDeviceMuted == IntPtr.Zero)
					id_isDeviceMuted = JNIEnv.GetMethodID (class_ref, "isDeviceMuted", "()Z");
				return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isDeviceMuted);
			}
			set {
				if (id_setDeviceMuted_Z == IntPtr.Zero)
					id_setDeviceMuted_Z = JNIEnv.GetMethodID (class_ref, "setDeviceMuted", "(Z)V");
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (value);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setDeviceMuted_Z, __args);
			}
		}

		static Delegate? cb_getDeviceVolume;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetGetDeviceVolumeHandler ()
		{
			if (cb_getDeviceVolume == null)
				cb_getDeviceVolume = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_I) n_GetDeviceVolume);
			return cb_getDeviceVolume;
		}

		[Obsolete]
		static int n_GetDeviceVolume (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerDeviceComponent> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.DeviceVolume;
		}
#pragma warning restore 0169

		static Delegate? cb_setDeviceVolume_I;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetSetDeviceVolume_IHandler ()
		{
			if (cb_setDeviceVolume_I == null)
				cb_setDeviceVolume_I = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPI_V) n_SetDeviceVolume_I);
			return cb_setDeviceVolume_I;
		}

		[Obsolete]
		static void n_SetDeviceVolume_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerDeviceComponent> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.DeviceVolume = p0;
		}
#pragma warning restore 0169

		IntPtr id_getDeviceVolume;
		IntPtr id_setDeviceVolume_I;
		public unsafe int DeviceVolume {
			get {
				if (id_getDeviceVolume == IntPtr.Zero)
					id_getDeviceVolume = JNIEnv.GetMethodID (class_ref, "getDeviceVolume", "()I");
				return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getDeviceVolume);
			}
			set {
				if (id_setDeviceVolume_I == IntPtr.Zero)
					id_setDeviceVolume_I = JNIEnv.GetMethodID (class_ref, "setDeviceVolume", "(I)V");
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (value);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setDeviceVolume_I, __args);
			}
		}

		static Delegate? cb_decreaseDeviceVolume;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetDecreaseDeviceVolumeHandler ()
		{
			if (cb_decreaseDeviceVolume == null)
				cb_decreaseDeviceVolume = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_V) n_DecreaseDeviceVolume);
			return cb_decreaseDeviceVolume;
		}

		[Obsolete]
		static void n_DecreaseDeviceVolume (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerDeviceComponent> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.DecreaseDeviceVolume ();
		}
#pragma warning restore 0169

		IntPtr id_decreaseDeviceVolume;
		public unsafe void DecreaseDeviceVolume ()
		{
			if (id_decreaseDeviceVolume == IntPtr.Zero)
				id_decreaseDeviceVolume = JNIEnv.GetMethodID (class_ref, "decreaseDeviceVolume", "()V");
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_decreaseDeviceVolume);
		}

		static Delegate? cb_increaseDeviceVolume;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetIncreaseDeviceVolumeHandler ()
		{
			if (cb_increaseDeviceVolume == null)
				cb_increaseDeviceVolume = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_V) n_IncreaseDeviceVolume);
			return cb_increaseDeviceVolume;
		}

		[Obsolete]
		static void n_IncreaseDeviceVolume (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerDeviceComponent> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.IncreaseDeviceVolume ();
		}
#pragma warning restore 0169

		IntPtr id_increaseDeviceVolume;
		public unsafe void IncreaseDeviceVolume ()
		{
			if (id_increaseDeviceVolume == IntPtr.Zero)
				id_increaseDeviceVolume = JNIEnv.GetMethodID (class_ref, "increaseDeviceVolume", "()V");
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_increaseDeviceVolume);
		}

	}

	// Metadata.xml XPath interface reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.TextComponent']"
	[ObsoleteAttribute (@"This class is obsoleted in this android platform")]
	[Register ("androidx/media3/exoplayer/ExoPlayer$TextComponent", "", "AndroidX.Media3.ExoPlayer.IExoPlayerTextComponentInvoker")]
	public partial interface IExoPlayerTextComponent : IJavaObject, IJavaPeerable {
		global::AndroidX.Media3.Common.Text.CueGroup? CurrentCues {
			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.TextComponent']/method[@name='getCurrentCues' and count(parameter)=0]"
			[Register ("getCurrentCues", "()Landroidx/media3/common/text/CueGroup;", "GetGetCurrentCuesHandler:AndroidX.Media3.ExoPlayer.IExoPlayerTextComponentInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			get; 
		}

	}

	[global::Android.Runtime.Register ("androidx/media3/exoplayer/ExoPlayer$TextComponent", DoNotGenerateAcw=true)]
	internal partial class IExoPlayerTextComponentInvoker : global::Java.Lang.Object, IExoPlayerTextComponent {
		static readonly JniPeerMembers _members = new XAPeerMembers ("androidx/media3/exoplayer/ExoPlayer$TextComponent", typeof (IExoPlayerTextComponentInvoker));

		static IntPtr java_class_ref {
			get { return _members.JniPeerType.PeerReference.Handle; }
		}

		[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]
		[global::System.ComponentModel.EditorBrowsable (global::System.ComponentModel.EditorBrowsableState.Never)]
		public override global::Java.Interop.JniPeerMembers JniPeerMembers {
			get { return _members; }
		}

		[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]
		[global::System.ComponentModel.EditorBrowsable (global::System.ComponentModel.EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]
		[global::System.ComponentModel.EditorBrowsable (global::System.ComponentModel.EditorBrowsableState.Never)]
		protected override global::System.Type ThresholdType {
			get { return _members.ManagedPeerType; }
		}

		IntPtr class_ref;

		public static IExoPlayerTextComponent? GetObject (IntPtr handle, JniHandleOwnership transfer)
		{
			return global::Java.Lang.Object.GetObject<IExoPlayerTextComponent> (handle, transfer);
		}

		static IntPtr Validate (IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf (handle, java_class_ref))
				throw new InvalidCastException ($"Unable to convert instance of type '{JNIEnv.GetClassNameFromInstance (handle)}' to type 'androidx.media3.exoplayer.ExoPlayer.TextComponent'.");
			return handle;
		}

		protected override void Dispose (bool disposing)
		{
			if (this.class_ref != IntPtr.Zero)
				JNIEnv.DeleteGlobalRef (this.class_ref);
			this.class_ref = IntPtr.Zero;
			base.Dispose (disposing);
		}

		public IExoPlayerTextComponentInvoker (IntPtr handle, JniHandleOwnership transfer) : base (Validate (handle), transfer)
		{
			IntPtr local_ref = JNIEnv.GetObjectClass (((global::Java.Lang.Object) this).Handle);
			this.class_ref = JNIEnv.NewGlobalRef (local_ref);
			JNIEnv.DeleteLocalRef (local_ref);
		}

		static Delegate? cb_getCurrentCues;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetGetCurrentCuesHandler ()
		{
			if (cb_getCurrentCues == null)
				cb_getCurrentCues = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_L) n_GetCurrentCues);
			return cb_getCurrentCues;
		}

		[Obsolete]
		static IntPtr n_GetCurrentCues (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerTextComponent> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return JNIEnv.ToLocalJniHandle (__this.CurrentCues);
		}
#pragma warning restore 0169

		IntPtr id_getCurrentCues;
		public unsafe global::AndroidX.Media3.Common.Text.CueGroup? CurrentCues {
			get {
				if (id_getCurrentCues == IntPtr.Zero)
					id_getCurrentCues = JNIEnv.GetMethodID (class_ref, "getCurrentCues", "()Landroidx/media3/common/text/CueGroup;");
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.Common.Text.CueGroup> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getCurrentCues), JniHandleOwnership.TransferLocalRef);
			}
		}

	}

	// Metadata.xml XPath interface reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.VideoComponent']"
	[ObsoleteAttribute (@"This class is obsoleted in this android platform")]
	[Register ("androidx/media3/exoplayer/ExoPlayer$VideoComponent", "", "AndroidX.Media3.ExoPlayer.IExoPlayerVideoComponentInvoker")]
	public partial interface IExoPlayerVideoComponent : IJavaObject, IJavaPeerable {
		int VideoChangeFrameRateStrategy {
			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.VideoComponent']/method[@name='getVideoChangeFrameRateStrategy' and count(parameter)=0]"
			[Register ("getVideoChangeFrameRateStrategy", "()I", "GetGetVideoChangeFrameRateStrategyHandler:AndroidX.Media3.ExoPlayer.IExoPlayerVideoComponentInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			get; 

			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.VideoComponent']/method[@name='setVideoChangeFrameRateStrategy' and count(parameter)=1 and parameter[1][@type='int']]"
			[Register ("setVideoChangeFrameRateStrategy", "(I)V", "GetSetVideoChangeFrameRateStrategy_IHandler:AndroidX.Media3.ExoPlayer.IExoPlayerVideoComponentInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			set; 
		}

		int VideoScalingMode {
			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.VideoComponent']/method[@name='getVideoScalingMode' and count(parameter)=0]"
			[Register ("getVideoScalingMode", "()I", "GetGetVideoScalingModeHandler:AndroidX.Media3.ExoPlayer.IExoPlayerVideoComponentInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			get; 

			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.VideoComponent']/method[@name='setVideoScalingMode' and count(parameter)=1 and parameter[1][@type='int']]"
			[Register ("setVideoScalingMode", "(I)V", "GetSetVideoScalingMode_IHandler:AndroidX.Media3.ExoPlayer.IExoPlayerVideoComponentInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			set; 
		}

		global::AndroidX.Media3.Common.VideoSize? VideoSize {
			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.VideoComponent']/method[@name='getVideoSize' and count(parameter)=0]"
			[Register ("getVideoSize", "()Landroidx/media3/common/VideoSize;", "GetGetVideoSizeHandler:AndroidX.Media3.ExoPlayer.IExoPlayerVideoComponentInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			get; 
		}

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.VideoComponent']/method[@name='clearCameraMotionListener' and count(parameter)=1 and parameter[1][@type='androidx.media3.exoplayer.video.spherical.CameraMotionListener']]"
		[Obsolete (@"deprecated")]
		[Register ("clearCameraMotionListener", "(Landroidx/media3/exoplayer/video/spherical/CameraMotionListener;)V", "GetClearCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_Handler:AndroidX.Media3.ExoPlayer.IExoPlayerVideoComponentInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void ClearCameraMotionListener (global::AndroidX.Media3.ExoPlayer.Video.Spherical.ICameraMotionListener? p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.VideoComponent']/method[@name='clearVideoFrameMetadataListener' and count(parameter)=1 and parameter[1][@type='androidx.media3.exoplayer.video.VideoFrameMetadataListener']]"
		[Obsolete (@"deprecated")]
		[Register ("clearVideoFrameMetadataListener", "(Landroidx/media3/exoplayer/video/VideoFrameMetadataListener;)V", "GetClearVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_Handler:AndroidX.Media3.ExoPlayer.IExoPlayerVideoComponentInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void ClearVideoFrameMetadataListener (global::AndroidX.Media3.ExoPlayer.Video.IVideoFrameMetadataListener? p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.VideoComponent']/method[@name='clearVideoSurface' and count(parameter)=0]"
		[Obsolete (@"deprecated")]
		[Register ("clearVideoSurface", "()V", "GetClearVideoSurfaceHandler:AndroidX.Media3.ExoPlayer.IExoPlayerVideoComponentInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void ClearVideoSurface ();

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.VideoComponent']/method[@name='clearVideoSurface' and count(parameter)=1 and parameter[1][@type='android.view.Surface']]"
		[Obsolete (@"deprecated")]
		[Register ("clearVideoSurface", "(Landroid/view/Surface;)V", "GetClearVideoSurface_Landroid_view_Surface_Handler:AndroidX.Media3.ExoPlayer.IExoPlayerVideoComponentInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void ClearVideoSurface (global::Android.Views.Surface? p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.VideoComponent']/method[@name='clearVideoSurfaceHolder' and count(parameter)=1 and parameter[1][@type='android.view.SurfaceHolder']]"
		[Obsolete (@"deprecated")]
		[Register ("clearVideoSurfaceHolder", "(Landroid/view/SurfaceHolder;)V", "GetClearVideoSurfaceHolder_Landroid_view_SurfaceHolder_Handler:AndroidX.Media3.ExoPlayer.IExoPlayerVideoComponentInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void ClearVideoSurfaceHolder (global::Android.Views.ISurfaceHolder? p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.VideoComponent']/method[@name='clearVideoSurfaceView' and count(parameter)=1 and parameter[1][@type='android.view.SurfaceView']]"
		[Obsolete (@"deprecated")]
		[Register ("clearVideoSurfaceView", "(Landroid/view/SurfaceView;)V", "GetClearVideoSurfaceView_Landroid_view_SurfaceView_Handler:AndroidX.Media3.ExoPlayer.IExoPlayerVideoComponentInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void ClearVideoSurfaceView (global::Android.Views.SurfaceView? p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.VideoComponent']/method[@name='clearVideoTextureView' and count(parameter)=1 and parameter[1][@type='android.view.TextureView']]"
		[Obsolete (@"deprecated")]
		[Register ("clearVideoTextureView", "(Landroid/view/TextureView;)V", "GetClearVideoTextureView_Landroid_view_TextureView_Handler:AndroidX.Media3.ExoPlayer.IExoPlayerVideoComponentInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void ClearVideoTextureView (global::Android.Views.TextureView? p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.VideoComponent']/method[@name='setCameraMotionListener' and count(parameter)=1 and parameter[1][@type='androidx.media3.exoplayer.video.spherical.CameraMotionListener']]"
		[Obsolete (@"deprecated")]
		[Register ("setCameraMotionListener", "(Landroidx/media3/exoplayer/video/spherical/CameraMotionListener;)V", "GetSetCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_Handler:AndroidX.Media3.ExoPlayer.IExoPlayerVideoComponentInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void SetCameraMotionListener (global::AndroidX.Media3.ExoPlayer.Video.Spherical.ICameraMotionListener? p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.VideoComponent']/method[@name='setVideoFrameMetadataListener' and count(parameter)=1 and parameter[1][@type='androidx.media3.exoplayer.video.VideoFrameMetadataListener']]"
		[Obsolete (@"deprecated")]
		[Register ("setVideoFrameMetadataListener", "(Landroidx/media3/exoplayer/video/VideoFrameMetadataListener;)V", "GetSetVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_Handler:AndroidX.Media3.ExoPlayer.IExoPlayerVideoComponentInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void SetVideoFrameMetadataListener (global::AndroidX.Media3.ExoPlayer.Video.IVideoFrameMetadataListener? p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.VideoComponent']/method[@name='setVideoSurface' and count(parameter)=1 and parameter[1][@type='android.view.Surface']]"
		[Obsolete (@"deprecated")]
		[Register ("setVideoSurface", "(Landroid/view/Surface;)V", "GetSetVideoSurface_Landroid_view_Surface_Handler:AndroidX.Media3.ExoPlayer.IExoPlayerVideoComponentInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void SetVideoSurface (global::Android.Views.Surface? p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.VideoComponent']/method[@name='setVideoSurfaceHolder' and count(parameter)=1 and parameter[1][@type='android.view.SurfaceHolder']]"
		[Obsolete (@"deprecated")]
		[Register ("setVideoSurfaceHolder", "(Landroid/view/SurfaceHolder;)V", "GetSetVideoSurfaceHolder_Landroid_view_SurfaceHolder_Handler:AndroidX.Media3.ExoPlayer.IExoPlayerVideoComponentInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void SetVideoSurfaceHolder (global::Android.Views.ISurfaceHolder? p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.VideoComponent']/method[@name='setVideoSurfaceView' and count(parameter)=1 and parameter[1][@type='android.view.SurfaceView']]"
		[Obsolete (@"deprecated")]
		[Register ("setVideoSurfaceView", "(Landroid/view/SurfaceView;)V", "GetSetVideoSurfaceView_Landroid_view_SurfaceView_Handler:AndroidX.Media3.ExoPlayer.IExoPlayerVideoComponentInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void SetVideoSurfaceView (global::Android.Views.SurfaceView? p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer.VideoComponent']/method[@name='setVideoTextureView' and count(parameter)=1 and parameter[1][@type='android.view.TextureView']]"
		[Obsolete (@"deprecated")]
		[Register ("setVideoTextureView", "(Landroid/view/TextureView;)V", "GetSetVideoTextureView_Landroid_view_TextureView_Handler:AndroidX.Media3.ExoPlayer.IExoPlayerVideoComponentInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void SetVideoTextureView (global::Android.Views.TextureView? p0);

	}

	[global::Android.Runtime.Register ("androidx/media3/exoplayer/ExoPlayer$VideoComponent", DoNotGenerateAcw=true)]
	internal partial class IExoPlayerVideoComponentInvoker : global::Java.Lang.Object, IExoPlayerVideoComponent {
		static readonly JniPeerMembers _members = new XAPeerMembers ("androidx/media3/exoplayer/ExoPlayer$VideoComponent", typeof (IExoPlayerVideoComponentInvoker));

		static IntPtr java_class_ref {
			get { return _members.JniPeerType.PeerReference.Handle; }
		}

		[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]
		[global::System.ComponentModel.EditorBrowsable (global::System.ComponentModel.EditorBrowsableState.Never)]
		public override global::Java.Interop.JniPeerMembers JniPeerMembers {
			get { return _members; }
		}

		[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]
		[global::System.ComponentModel.EditorBrowsable (global::System.ComponentModel.EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]
		[global::System.ComponentModel.EditorBrowsable (global::System.ComponentModel.EditorBrowsableState.Never)]
		protected override global::System.Type ThresholdType {
			get { return _members.ManagedPeerType; }
		}

		IntPtr class_ref;

		public static IExoPlayerVideoComponent? GetObject (IntPtr handle, JniHandleOwnership transfer)
		{
			return global::Java.Lang.Object.GetObject<IExoPlayerVideoComponent> (handle, transfer);
		}

		static IntPtr Validate (IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf (handle, java_class_ref))
				throw new InvalidCastException ($"Unable to convert instance of type '{JNIEnv.GetClassNameFromInstance (handle)}' to type 'androidx.media3.exoplayer.ExoPlayer.VideoComponent'.");
			return handle;
		}

		protected override void Dispose (bool disposing)
		{
			if (this.class_ref != IntPtr.Zero)
				JNIEnv.DeleteGlobalRef (this.class_ref);
			this.class_ref = IntPtr.Zero;
			base.Dispose (disposing);
		}

		public IExoPlayerVideoComponentInvoker (IntPtr handle, JniHandleOwnership transfer) : base (Validate (handle), transfer)
		{
			IntPtr local_ref = JNIEnv.GetObjectClass (((global::Java.Lang.Object) this).Handle);
			this.class_ref = JNIEnv.NewGlobalRef (local_ref);
			JNIEnv.DeleteLocalRef (local_ref);
		}

		static Delegate? cb_getVideoChangeFrameRateStrategy;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetGetVideoChangeFrameRateStrategyHandler ()
		{
			if (cb_getVideoChangeFrameRateStrategy == null)
				cb_getVideoChangeFrameRateStrategy = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_I) n_GetVideoChangeFrameRateStrategy);
			return cb_getVideoChangeFrameRateStrategy;
		}

		[Obsolete]
		static int n_GetVideoChangeFrameRateStrategy (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerVideoComponent> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.VideoChangeFrameRateStrategy;
		}
#pragma warning restore 0169

		static Delegate? cb_setVideoChangeFrameRateStrategy_I;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetSetVideoChangeFrameRateStrategy_IHandler ()
		{
			if (cb_setVideoChangeFrameRateStrategy_I == null)
				cb_setVideoChangeFrameRateStrategy_I = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPI_V) n_SetVideoChangeFrameRateStrategy_I);
			return cb_setVideoChangeFrameRateStrategy_I;
		}

		[Obsolete]
		static void n_SetVideoChangeFrameRateStrategy_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerVideoComponent> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.VideoChangeFrameRateStrategy = p0;
		}
#pragma warning restore 0169

		IntPtr id_getVideoChangeFrameRateStrategy;
		IntPtr id_setVideoChangeFrameRateStrategy_I;
		public unsafe int VideoChangeFrameRateStrategy {
			get {
				if (id_getVideoChangeFrameRateStrategy == IntPtr.Zero)
					id_getVideoChangeFrameRateStrategy = JNIEnv.GetMethodID (class_ref, "getVideoChangeFrameRateStrategy", "()I");
				return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getVideoChangeFrameRateStrategy);
			}
			set {
				if (id_setVideoChangeFrameRateStrategy_I == IntPtr.Zero)
					id_setVideoChangeFrameRateStrategy_I = JNIEnv.GetMethodID (class_ref, "setVideoChangeFrameRateStrategy", "(I)V");
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (value);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setVideoChangeFrameRateStrategy_I, __args);
			}
		}

		static Delegate? cb_getVideoScalingMode;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetGetVideoScalingModeHandler ()
		{
			if (cb_getVideoScalingMode == null)
				cb_getVideoScalingMode = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_I) n_GetVideoScalingMode);
			return cb_getVideoScalingMode;
		}

		[Obsolete]
		static int n_GetVideoScalingMode (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerVideoComponent> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.VideoScalingMode;
		}
#pragma warning restore 0169

		static Delegate? cb_setVideoScalingMode_I;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetSetVideoScalingMode_IHandler ()
		{
			if (cb_setVideoScalingMode_I == null)
				cb_setVideoScalingMode_I = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPI_V) n_SetVideoScalingMode_I);
			return cb_setVideoScalingMode_I;
		}

		[Obsolete]
		static void n_SetVideoScalingMode_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerVideoComponent> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.VideoScalingMode = p0;
		}
#pragma warning restore 0169

		IntPtr id_getVideoScalingMode;
		IntPtr id_setVideoScalingMode_I;
		public unsafe int VideoScalingMode {
			get {
				if (id_getVideoScalingMode == IntPtr.Zero)
					id_getVideoScalingMode = JNIEnv.GetMethodID (class_ref, "getVideoScalingMode", "()I");
				return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getVideoScalingMode);
			}
			set {
				if (id_setVideoScalingMode_I == IntPtr.Zero)
					id_setVideoScalingMode_I = JNIEnv.GetMethodID (class_ref, "setVideoScalingMode", "(I)V");
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (value);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setVideoScalingMode_I, __args);
			}
		}

		static Delegate? cb_getVideoSize;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetGetVideoSizeHandler ()
		{
			if (cb_getVideoSize == null)
				cb_getVideoSize = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_L) n_GetVideoSize);
			return cb_getVideoSize;
		}

		[Obsolete]
		static IntPtr n_GetVideoSize (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerVideoComponent> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return JNIEnv.ToLocalJniHandle (__this.VideoSize);
		}
#pragma warning restore 0169

		IntPtr id_getVideoSize;
		public unsafe global::AndroidX.Media3.Common.VideoSize? VideoSize {
			get {
				if (id_getVideoSize == IntPtr.Zero)
					id_getVideoSize = JNIEnv.GetMethodID (class_ref, "getVideoSize", "()Landroidx/media3/common/VideoSize;");
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.Common.VideoSize> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getVideoSize), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate? cb_clearCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetClearCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_Handler ()
		{
			if (cb_clearCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_ == null)
				cb_clearCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_ClearCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_);
			return cb_clearCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_;
		}

		[Obsolete]
		static void n_ClearCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerVideoComponent> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = (global::AndroidX.Media3.ExoPlayer.Video.Spherical.ICameraMotionListener?)global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.Video.Spherical.ICameraMotionListener> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ClearCameraMotionListener (p0);
		}
#pragma warning restore 0169

		IntPtr id_clearCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_;
		public unsafe void ClearCameraMotionListener (global::AndroidX.Media3.ExoPlayer.Video.Spherical.ICameraMotionListener? p0)
		{
			if (id_clearCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_ == IntPtr.Zero)
				id_clearCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_ = JNIEnv.GetMethodID (class_ref, "clearCameraMotionListener", "(Landroidx/media3/exoplayer/video/spherical/CameraMotionListener;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_clearCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_, __args);
		}

		static Delegate? cb_clearVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetClearVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_Handler ()
		{
			if (cb_clearVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_ == null)
				cb_clearVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_ClearVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_);
			return cb_clearVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_;
		}

		[Obsolete]
		static void n_ClearVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerVideoComponent> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = (global::AndroidX.Media3.ExoPlayer.Video.IVideoFrameMetadataListener?)global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.Video.IVideoFrameMetadataListener> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ClearVideoFrameMetadataListener (p0);
		}
#pragma warning restore 0169

		IntPtr id_clearVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_;
		public unsafe void ClearVideoFrameMetadataListener (global::AndroidX.Media3.ExoPlayer.Video.IVideoFrameMetadataListener? p0)
		{
			if (id_clearVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_ == IntPtr.Zero)
				id_clearVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_ = JNIEnv.GetMethodID (class_ref, "clearVideoFrameMetadataListener", "(Landroidx/media3/exoplayer/video/VideoFrameMetadataListener;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_clearVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_, __args);
		}

		static Delegate? cb_clearVideoSurface;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetClearVideoSurfaceHandler ()
		{
			if (cb_clearVideoSurface == null)
				cb_clearVideoSurface = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_V) n_ClearVideoSurface);
			return cb_clearVideoSurface;
		}

		[Obsolete]
		static void n_ClearVideoSurface (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerVideoComponent> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.ClearVideoSurface ();
		}
#pragma warning restore 0169

		IntPtr id_clearVideoSurface;
		public unsafe void ClearVideoSurface ()
		{
			if (id_clearVideoSurface == IntPtr.Zero)
				id_clearVideoSurface = JNIEnv.GetMethodID (class_ref, "clearVideoSurface", "()V");
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_clearVideoSurface);
		}

		static Delegate? cb_clearVideoSurface_Landroid_view_Surface_;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetClearVideoSurface_Landroid_view_Surface_Handler ()
		{
			if (cb_clearVideoSurface_Landroid_view_Surface_ == null)
				cb_clearVideoSurface_Landroid_view_Surface_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_ClearVideoSurface_Landroid_view_Surface_);
			return cb_clearVideoSurface_Landroid_view_Surface_;
		}

		[Obsolete]
		static void n_ClearVideoSurface_Landroid_view_Surface_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerVideoComponent> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = global::Java.Lang.Object.GetObject<global::Android.Views.Surface> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ClearVideoSurface (p0);
		}
#pragma warning restore 0169

		IntPtr id_clearVideoSurface_Landroid_view_Surface_;
		public unsafe void ClearVideoSurface (global::Android.Views.Surface? p0)
		{
			if (id_clearVideoSurface_Landroid_view_Surface_ == IntPtr.Zero)
				id_clearVideoSurface_Landroid_view_Surface_ = JNIEnv.GetMethodID (class_ref, "clearVideoSurface", "(Landroid/view/Surface;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_clearVideoSurface_Landroid_view_Surface_, __args);
		}

		static Delegate? cb_clearVideoSurfaceHolder_Landroid_view_SurfaceHolder_;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetClearVideoSurfaceHolder_Landroid_view_SurfaceHolder_Handler ()
		{
			if (cb_clearVideoSurfaceHolder_Landroid_view_SurfaceHolder_ == null)
				cb_clearVideoSurfaceHolder_Landroid_view_SurfaceHolder_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_ClearVideoSurfaceHolder_Landroid_view_SurfaceHolder_);
			return cb_clearVideoSurfaceHolder_Landroid_view_SurfaceHolder_;
		}

		[Obsolete]
		static void n_ClearVideoSurfaceHolder_Landroid_view_SurfaceHolder_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerVideoComponent> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = (global::Android.Views.ISurfaceHolder?)global::Java.Lang.Object.GetObject<global::Android.Views.ISurfaceHolder> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ClearVideoSurfaceHolder (p0);
		}
#pragma warning restore 0169

		IntPtr id_clearVideoSurfaceHolder_Landroid_view_SurfaceHolder_;
		public unsafe void ClearVideoSurfaceHolder (global::Android.Views.ISurfaceHolder? p0)
		{
			if (id_clearVideoSurfaceHolder_Landroid_view_SurfaceHolder_ == IntPtr.Zero)
				id_clearVideoSurfaceHolder_Landroid_view_SurfaceHolder_ = JNIEnv.GetMethodID (class_ref, "clearVideoSurfaceHolder", "(Landroid/view/SurfaceHolder;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_clearVideoSurfaceHolder_Landroid_view_SurfaceHolder_, __args);
		}

		static Delegate? cb_clearVideoSurfaceView_Landroid_view_SurfaceView_;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetClearVideoSurfaceView_Landroid_view_SurfaceView_Handler ()
		{
			if (cb_clearVideoSurfaceView_Landroid_view_SurfaceView_ == null)
				cb_clearVideoSurfaceView_Landroid_view_SurfaceView_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_ClearVideoSurfaceView_Landroid_view_SurfaceView_);
			return cb_clearVideoSurfaceView_Landroid_view_SurfaceView_;
		}

		[Obsolete]
		static void n_ClearVideoSurfaceView_Landroid_view_SurfaceView_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerVideoComponent> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = global::Java.Lang.Object.GetObject<global::Android.Views.SurfaceView> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ClearVideoSurfaceView (p0);
		}
#pragma warning restore 0169

		IntPtr id_clearVideoSurfaceView_Landroid_view_SurfaceView_;
		public unsafe void ClearVideoSurfaceView (global::Android.Views.SurfaceView? p0)
		{
			if (id_clearVideoSurfaceView_Landroid_view_SurfaceView_ == IntPtr.Zero)
				id_clearVideoSurfaceView_Landroid_view_SurfaceView_ = JNIEnv.GetMethodID (class_ref, "clearVideoSurfaceView", "(Landroid/view/SurfaceView;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_clearVideoSurfaceView_Landroid_view_SurfaceView_, __args);
		}

		static Delegate? cb_clearVideoTextureView_Landroid_view_TextureView_;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetClearVideoTextureView_Landroid_view_TextureView_Handler ()
		{
			if (cb_clearVideoTextureView_Landroid_view_TextureView_ == null)
				cb_clearVideoTextureView_Landroid_view_TextureView_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_ClearVideoTextureView_Landroid_view_TextureView_);
			return cb_clearVideoTextureView_Landroid_view_TextureView_;
		}

		[Obsolete]
		static void n_ClearVideoTextureView_Landroid_view_TextureView_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerVideoComponent> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = global::Java.Lang.Object.GetObject<global::Android.Views.TextureView> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ClearVideoTextureView (p0);
		}
#pragma warning restore 0169

		IntPtr id_clearVideoTextureView_Landroid_view_TextureView_;
		public unsafe void ClearVideoTextureView (global::Android.Views.TextureView? p0)
		{
			if (id_clearVideoTextureView_Landroid_view_TextureView_ == IntPtr.Zero)
				id_clearVideoTextureView_Landroid_view_TextureView_ = JNIEnv.GetMethodID (class_ref, "clearVideoTextureView", "(Landroid/view/TextureView;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_clearVideoTextureView_Landroid_view_TextureView_, __args);
		}

		static Delegate? cb_setCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetSetCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_Handler ()
		{
			if (cb_setCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_ == null)
				cb_setCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_SetCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_);
			return cb_setCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_;
		}

		[Obsolete]
		static void n_SetCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerVideoComponent> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = (global::AndroidX.Media3.ExoPlayer.Video.Spherical.ICameraMotionListener?)global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.Video.Spherical.ICameraMotionListener> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetCameraMotionListener (p0);
		}
#pragma warning restore 0169

		IntPtr id_setCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_;
		public unsafe void SetCameraMotionListener (global::AndroidX.Media3.ExoPlayer.Video.Spherical.ICameraMotionListener? p0)
		{
			if (id_setCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_ == IntPtr.Zero)
				id_setCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_ = JNIEnv.GetMethodID (class_ref, "setCameraMotionListener", "(Landroidx/media3/exoplayer/video/spherical/CameraMotionListener;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_, __args);
		}

		static Delegate? cb_setVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetSetVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_Handler ()
		{
			if (cb_setVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_ == null)
				cb_setVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_SetVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_);
			return cb_setVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_;
		}

		[Obsolete]
		static void n_SetVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerVideoComponent> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = (global::AndroidX.Media3.ExoPlayer.Video.IVideoFrameMetadataListener?)global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.Video.IVideoFrameMetadataListener> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetVideoFrameMetadataListener (p0);
		}
#pragma warning restore 0169

		IntPtr id_setVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_;
		public unsafe void SetVideoFrameMetadataListener (global::AndroidX.Media3.ExoPlayer.Video.IVideoFrameMetadataListener? p0)
		{
			if (id_setVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_ == IntPtr.Zero)
				id_setVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_ = JNIEnv.GetMethodID (class_ref, "setVideoFrameMetadataListener", "(Landroidx/media3/exoplayer/video/VideoFrameMetadataListener;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_, __args);
		}

		static Delegate? cb_setVideoSurface_Landroid_view_Surface_;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetSetVideoSurface_Landroid_view_Surface_Handler ()
		{
			if (cb_setVideoSurface_Landroid_view_Surface_ == null)
				cb_setVideoSurface_Landroid_view_Surface_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_SetVideoSurface_Landroid_view_Surface_);
			return cb_setVideoSurface_Landroid_view_Surface_;
		}

		[Obsolete]
		static void n_SetVideoSurface_Landroid_view_Surface_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerVideoComponent> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = global::Java.Lang.Object.GetObject<global::Android.Views.Surface> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetVideoSurface (p0);
		}
#pragma warning restore 0169

		IntPtr id_setVideoSurface_Landroid_view_Surface_;
		public unsafe void SetVideoSurface (global::Android.Views.Surface? p0)
		{
			if (id_setVideoSurface_Landroid_view_Surface_ == IntPtr.Zero)
				id_setVideoSurface_Landroid_view_Surface_ = JNIEnv.GetMethodID (class_ref, "setVideoSurface", "(Landroid/view/Surface;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setVideoSurface_Landroid_view_Surface_, __args);
		}

		static Delegate? cb_setVideoSurfaceHolder_Landroid_view_SurfaceHolder_;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetSetVideoSurfaceHolder_Landroid_view_SurfaceHolder_Handler ()
		{
			if (cb_setVideoSurfaceHolder_Landroid_view_SurfaceHolder_ == null)
				cb_setVideoSurfaceHolder_Landroid_view_SurfaceHolder_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_SetVideoSurfaceHolder_Landroid_view_SurfaceHolder_);
			return cb_setVideoSurfaceHolder_Landroid_view_SurfaceHolder_;
		}

		[Obsolete]
		static void n_SetVideoSurfaceHolder_Landroid_view_SurfaceHolder_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerVideoComponent> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = (global::Android.Views.ISurfaceHolder?)global::Java.Lang.Object.GetObject<global::Android.Views.ISurfaceHolder> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetVideoSurfaceHolder (p0);
		}
#pragma warning restore 0169

		IntPtr id_setVideoSurfaceHolder_Landroid_view_SurfaceHolder_;
		public unsafe void SetVideoSurfaceHolder (global::Android.Views.ISurfaceHolder? p0)
		{
			if (id_setVideoSurfaceHolder_Landroid_view_SurfaceHolder_ == IntPtr.Zero)
				id_setVideoSurfaceHolder_Landroid_view_SurfaceHolder_ = JNIEnv.GetMethodID (class_ref, "setVideoSurfaceHolder", "(Landroid/view/SurfaceHolder;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setVideoSurfaceHolder_Landroid_view_SurfaceHolder_, __args);
		}

		static Delegate? cb_setVideoSurfaceView_Landroid_view_SurfaceView_;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetSetVideoSurfaceView_Landroid_view_SurfaceView_Handler ()
		{
			if (cb_setVideoSurfaceView_Landroid_view_SurfaceView_ == null)
				cb_setVideoSurfaceView_Landroid_view_SurfaceView_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_SetVideoSurfaceView_Landroid_view_SurfaceView_);
			return cb_setVideoSurfaceView_Landroid_view_SurfaceView_;
		}

		[Obsolete]
		static void n_SetVideoSurfaceView_Landroid_view_SurfaceView_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerVideoComponent> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = global::Java.Lang.Object.GetObject<global::Android.Views.SurfaceView> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetVideoSurfaceView (p0);
		}
#pragma warning restore 0169

		IntPtr id_setVideoSurfaceView_Landroid_view_SurfaceView_;
		public unsafe void SetVideoSurfaceView (global::Android.Views.SurfaceView? p0)
		{
			if (id_setVideoSurfaceView_Landroid_view_SurfaceView_ == IntPtr.Zero)
				id_setVideoSurfaceView_Landroid_view_SurfaceView_ = JNIEnv.GetMethodID (class_ref, "setVideoSurfaceView", "(Landroid/view/SurfaceView;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setVideoSurfaceView_Landroid_view_SurfaceView_, __args);
		}

		static Delegate? cb_setVideoTextureView_Landroid_view_TextureView_;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetSetVideoTextureView_Landroid_view_TextureView_Handler ()
		{
			if (cb_setVideoTextureView_Landroid_view_TextureView_ == null)
				cb_setVideoTextureView_Landroid_view_TextureView_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_SetVideoTextureView_Landroid_view_TextureView_);
			return cb_setVideoTextureView_Landroid_view_TextureView_;
		}

		[Obsolete]
		static void n_SetVideoTextureView_Landroid_view_TextureView_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerVideoComponent> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = global::Java.Lang.Object.GetObject<global::Android.Views.TextureView> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetVideoTextureView (p0);
		}
#pragma warning restore 0169

		IntPtr id_setVideoTextureView_Landroid_view_TextureView_;
		public unsafe void SetVideoTextureView (global::Android.Views.TextureView? p0)
		{
			if (id_setVideoTextureView_Landroid_view_TextureView_ == IntPtr.Zero)
				id_setVideoTextureView_Landroid_view_TextureView_ = JNIEnv.GetMethodID (class_ref, "setVideoTextureView", "(Landroid/view/TextureView;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setVideoTextureView_Landroid_view_TextureView_, __args);
		}

	}

	[Register ("androidx/media3/exoplayer/ExoPlayer", DoNotGenerateAcw=true)]
	public abstract class ExoPlayer : Java.Lang.Object {
		internal ExoPlayer ()
		{
		}

		// Metadata.xml XPath field reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/field[@name='DEFAULT_DETACH_SURFACE_TIMEOUT_MS']"
		[Register ("DEFAULT_DETACH_SURFACE_TIMEOUT_MS")]
		public const long DefaultDetachSurfaceTimeoutMs = (long) 2000;

		// Metadata.xml XPath field reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/field[@name='DEFAULT_RELEASE_TIMEOUT_MS']"
		[Register ("DEFAULT_RELEASE_TIMEOUT_MS")]
		public const long DefaultReleaseTimeoutMs = (long) 500;

		// The following are fields from: androidx.media3.common.Player

		// The following are fields from: Android.Runtime.IJavaObject

		// The following are fields from: System.IDisposable

		// The following are fields from: Java.Interop.IJavaPeerable

	}

	[Register ("androidx/media3/exoplayer/ExoPlayer", DoNotGenerateAcw=true)]
	[global::System.Obsolete ("Use the 'ExoPlayer' type. This type will be removed in a future release.", error: true)]
	public abstract class ExoPlayerConsts : ExoPlayer {
		private ExoPlayerConsts ()
		{
		}

	}

	// Metadata.xml XPath interface reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']"
	[Register ("androidx/media3/exoplayer/ExoPlayer", "", "AndroidX.Media3.ExoPlayer.IExoPlayerInvoker")]
	public partial interface IExoPlayer : global::AndroidX.Media3.Common.IPlayer {
		/*
		global::AndroidX.Media3.ExoPlayer.Analytics.IAnalyticsCollector? AnalyticsCollector {
			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='getAnalyticsCollector' and count(parameter)=0]"
			[Register ("getAnalyticsCollector", "()Landroidx/media3/exoplayer/analytics/AnalyticsCollector;", "GetGetAnalyticsCollectorHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			get; 
		}
		*/

		global::AndroidX.Media3.ExoPlayer.IExoPlayerAudioComponent? AudioComponent {
			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='getAudioComponent' and count(parameter)=0]"
			[Register ("getAudioComponent", "()Landroidx/media3/exoplayer/ExoPlayer$AudioComponent;", "GetGetAudioComponentHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			get; 
		}

		global::AndroidX.Media3.ExoPlayer.DecoderCounters? AudioDecoderCounters {
			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='getAudioDecoderCounters' and count(parameter)=0]"
			[Register ("getAudioDecoderCounters", "()Landroidx/media3/exoplayer/DecoderCounters;", "GetGetAudioDecoderCountersHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			get; 
		}

		global::AndroidX.Media3.Common.Format? AudioFormat {
			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='getAudioFormat' and count(parameter)=0]"
			[Register ("getAudioFormat", "()Landroidx/media3/common/Format;", "GetGetAudioFormatHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			get; 
		}

		int AudioSessionId {
			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='getAudioSessionId' and count(parameter)=0]"
			[Register ("getAudioSessionId", "()I", "GetGetAudioSessionIdHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			get; 

			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='setAudioSessionId' and count(parameter)=1 and parameter[1][@type='int']]"
			[Register ("setAudioSessionId", "(I)V", "GetSetAudioSessionId_IHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			set; 
		}

		global::AndroidX.Media3.Common.Util.IClock? Clock {
			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='getClock' and count(parameter)=0]"
			[Register ("getClock", "()Landroidx/media3/common/util/Clock;", "GetGetClockHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			get; 
		}

		global::AndroidX.Media3.ExoPlayer.Source.TrackGroupArray? CurrentTrackGroups {
			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='getCurrentTrackGroups' and count(parameter)=0]"
			[Register ("getCurrentTrackGroups", "()Landroidx/media3/exoplayer/source/TrackGroupArray;", "GetGetCurrentTrackGroupsHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			get; 
		}

		global::AndroidX.Media3.ExoPlayer.Trackselection.TrackSelectionArray? CurrentTrackSelections {
			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='getCurrentTrackSelections' and count(parameter)=0]"
			[Register ("getCurrentTrackSelections", "()Landroidx/media3/exoplayer/trackselection/TrackSelectionArray;", "GetGetCurrentTrackSelectionsHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			get; 
		}

		global::AndroidX.Media3.ExoPlayer.IExoPlayerDeviceComponent? DeviceComponent {
			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='getDeviceComponent' and count(parameter)=0]"
			[Register ("getDeviceComponent", "()Landroidx/media3/exoplayer/ExoPlayer$DeviceComponent;", "GetGetDeviceComponentHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			get; 
		}

		bool IsTunnelingEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='isTunnelingEnabled' and count(parameter)=0]"
			[Register ("isTunnelingEnabled", "()Z", "GetIsTunnelingEnabledHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			get; 
		}

		bool PauseAtEndOfMediaItems {
			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='getPauseAtEndOfMediaItems' and count(parameter)=0]"
			[Register ("getPauseAtEndOfMediaItems", "()Z", "GetGetPauseAtEndOfMediaItemsHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			get; 

			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='setPauseAtEndOfMediaItems' and count(parameter)=1 and parameter[1][@type='boolean']]"
			[Register ("setPauseAtEndOfMediaItems", "(Z)V", "GetSetPauseAtEndOfMediaItems_ZHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			set; 
		}

		global::Android.OS.Looper? PlaybackLooper {
			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='getPlaybackLooper' and count(parameter)=0]"
			[Register ("getPlaybackLooper", "()Landroid/os/Looper;", "GetGetPlaybackLooperHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			get; 
		}

		// global::AndroidX.Media3.ExoPlayer.ExoPlaybackException? PlayerError {
		global::AndroidX.Media3.Common.PlaybackException? PlayerError {
			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='getPlayerError' and count(parameter)=0]"
			[Register ("getPlayerError", "()Landroidx/media3/exoplayer/ExoPlaybackException;", "GetGetPlayerErrorHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			get; 
		}

		int RendererCount {
			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='getRendererCount' and count(parameter)=0]"
			[Register ("getRendererCount", "()I", "GetGetRendererCountHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			get; 
		}

		global::AndroidX.Media3.ExoPlayer.SeekParameters? SeekParameters {
			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='getSeekParameters' and count(parameter)=0]"
			[Register ("getSeekParameters", "()Landroidx/media3/exoplayer/SeekParameters;", "GetGetSeekParametersHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			get; 

			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='setSeekParameters' and count(parameter)=1 and parameter[1][@type='androidx.media3.exoplayer.SeekParameters']]"
			[Register ("setSeekParameters", "(Landroidx/media3/exoplayer/SeekParameters;)V", "GetSetSeekParameters_Landroidx_media3_exoplayer_SeekParameters_Handler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			set; 
		}

		bool SkipSilenceEnabled {
			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='getSkipSilenceEnabled' and count(parameter)=0]"
			[Register ("getSkipSilenceEnabled", "()Z", "GetGetSkipSilenceEnabledHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			get; 

			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='setSkipSilenceEnabled' and count(parameter)=1 and parameter[1][@type='boolean']]"
			[Register ("setSkipSilenceEnabled", "(Z)V", "GetSetSkipSilenceEnabled_ZHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			set; 
		}

		global::AndroidX.Media3.ExoPlayer.IExoPlayerTextComponent? TextComponent {
			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='getTextComponent' and count(parameter)=0]"
			[Register ("getTextComponent", "()Landroidx/media3/exoplayer/ExoPlayer$TextComponent;", "GetGetTextComponentHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			get; 
		}

		global::AndroidX.Media3.ExoPlayer.Trackselection.TrackSelector? TrackSelector {
			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='getTrackSelector' and count(parameter)=0]"
			[Register ("getTrackSelector", "()Landroidx/media3/exoplayer/trackselection/TrackSelector;", "GetGetTrackSelectorHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			get; 
		}

		int VideoChangeFrameRateStrategy {
			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='getVideoChangeFrameRateStrategy' and count(parameter)=0]"
			[Register ("getVideoChangeFrameRateStrategy", "()I", "GetGetVideoChangeFrameRateStrategyHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			get; 

			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='setVideoChangeFrameRateStrategy' and count(parameter)=1 and parameter[1][@type='int']]"
			[Register ("setVideoChangeFrameRateStrategy", "(I)V", "GetSetVideoChangeFrameRateStrategy_IHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			set; 
		}

		global::AndroidX.Media3.ExoPlayer.IExoPlayerVideoComponent? VideoComponent {
			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='getVideoComponent' and count(parameter)=0]"
			[Register ("getVideoComponent", "()Landroidx/media3/exoplayer/ExoPlayer$VideoComponent;", "GetGetVideoComponentHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			get; 
		}

		global::AndroidX.Media3.ExoPlayer.DecoderCounters? VideoDecoderCounters {
			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='getVideoDecoderCounters' and count(parameter)=0]"
			[Register ("getVideoDecoderCounters", "()Landroidx/media3/exoplayer/DecoderCounters;", "GetGetVideoDecoderCountersHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			get; 
		}

		global::AndroidX.Media3.Common.Format? VideoFormat {
			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='getVideoFormat' and count(parameter)=0]"
			[Register ("getVideoFormat", "()Landroidx/media3/common/Format;", "GetGetVideoFormatHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			get; 
		}

		int VideoScalingMode {
			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='getVideoScalingMode' and count(parameter)=0]"
			[Register ("getVideoScalingMode", "()I", "GetGetVideoScalingModeHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			get; 

			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='setVideoScalingMode' and count(parameter)=1 and parameter[1][@type='int']]"
			[Register ("setVideoScalingMode", "(I)V", "GetSetVideoScalingMode_IHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
			set; 
		}

		/*
		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='addAnalyticsListener' and count(parameter)=1 and parameter[1][@type='androidx.media3.exoplayer.analytics.AnalyticsListener']]"
		[Register ("addAnalyticsListener", "(Landroidx/media3/exoplayer/analytics/AnalyticsListener;)V", "GetAddAnalyticsListener_Landroidx_media3_exoplayer_analytics_AnalyticsListener_Handler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void AddAnalyticsListener (global::AndroidX.Media3.ExoPlayer.Analytics.IAnalyticsListener? p0);
		*/

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='addAudioOffloadListener' and count(parameter)=1 and parameter[1][@type='androidx.media3.exoplayer.ExoPlayer.AudioOffloadListener']]"
		[Register ("addAudioOffloadListener", "(Landroidx/media3/exoplayer/ExoPlayer$AudioOffloadListener;)V", "GetAddAudioOffloadListener_Landroidx_media3_exoplayer_ExoPlayer_AudioOffloadListener_Handler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void AddAudioOffloadListener (global::AndroidX.Media3.ExoPlayer.IExoPlayerAudioOffloadListener? p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='addMediaSource' and count(parameter)=1 and parameter[1][@type='androidx.media3.exoplayer.source.MediaSource']]"
		[Register ("addMediaSource", "(Landroidx/media3/exoplayer/source/MediaSource;)V", "GetAddMediaSource_Landroidx_media3_exoplayer_source_MediaSource_Handler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void AddMediaSource (global::AndroidX.Media3.ExoPlayer.Source.IMediaSource? p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='addMediaSource' and count(parameter)=2 and parameter[1][@type='int'] and parameter[2][@type='androidx.media3.exoplayer.source.MediaSource']]"
		[Register ("addMediaSource", "(ILandroidx/media3/exoplayer/source/MediaSource;)V", "GetAddMediaSource_ILandroidx_media3_exoplayer_source_MediaSource_Handler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void AddMediaSource (int p0, global::AndroidX.Media3.ExoPlayer.Source.IMediaSource? p1);

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='addMediaSources' and count(parameter)=2 and parameter[1][@type='int'] and parameter[2][@type='java.util.List&lt;androidx.media3.exoplayer.source.MediaSource&gt;']]"
		[Register ("addMediaSources", "(ILjava/util/List;)V", "GetAddMediaSources_ILjava_util_List_Handler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void AddMediaSources (int p0, global::System.Collections.Generic.IList<global::AndroidX.Media3.ExoPlayer.Source.IMediaSource>? p1);

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='addMediaSources' and count(parameter)=1 and parameter[1][@type='java.util.List&lt;androidx.media3.exoplayer.source.MediaSource&gt;']]"
		[Register ("addMediaSources", "(Ljava/util/List;)V", "GetAddMediaSources_Ljava_util_List_Handler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void AddMediaSources (global::System.Collections.Generic.IList<global::AndroidX.Media3.ExoPlayer.Source.IMediaSource>? p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='clearAuxEffectInfo' and count(parameter)=0]"
		[Register ("clearAuxEffectInfo", "()V", "GetClearAuxEffectInfoHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void ClearAuxEffectInfo ();

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='clearCameraMotionListener' and count(parameter)=1 and parameter[1][@type='androidx.media3.exoplayer.video.spherical.CameraMotionListener']]"
		[Register ("clearCameraMotionListener", "(Landroidx/media3/exoplayer/video/spherical/CameraMotionListener;)V", "GetClearCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_Handler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void ClearCameraMotionListener (global::AndroidX.Media3.ExoPlayer.Video.Spherical.ICameraMotionListener? p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='clearVideoFrameMetadataListener' and count(parameter)=1 and parameter[1][@type='androidx.media3.exoplayer.video.VideoFrameMetadataListener']]"
		[Register ("clearVideoFrameMetadataListener", "(Landroidx/media3/exoplayer/video/VideoFrameMetadataListener;)V", "GetClearVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_Handler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void ClearVideoFrameMetadataListener (global::AndroidX.Media3.ExoPlayer.Video.IVideoFrameMetadataListener? p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='createMessage' and count(parameter)=1 and parameter[1][@type='androidx.media3.exoplayer.PlayerMessage.Target']]"
		[Register ("createMessage", "(Landroidx/media3/exoplayer/PlayerMessage$Target;)Landroidx/media3/exoplayer/PlayerMessage;", "GetCreateMessage_Landroidx_media3_exoplayer_PlayerMessage_Target_Handler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		global::AndroidX.Media3.ExoPlayer.PlayerMessage? CreateMessage (global::AndroidX.Media3.ExoPlayer.PlayerMessage.ITarget? p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='experimentalIsSleepingForOffload' and count(parameter)=0]"
		[Register ("experimentalIsSleepingForOffload", "()Z", "GetExperimentalIsSleepingForOffloadHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		bool ExperimentalIsSleepingForOffload ();

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='experimentalSetOffloadSchedulingEnabled' and count(parameter)=1 and parameter[1][@type='boolean']]"
		[Register ("experimentalSetOffloadSchedulingEnabled", "(Z)V", "GetExperimentalSetOffloadSchedulingEnabled_ZHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void ExperimentalSetOffloadSchedulingEnabled (bool p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='getRenderer' and count(parameter)=1 and parameter[1][@type='int']]"
		[Register ("getRenderer", "(I)Landroidx/media3/exoplayer/Renderer;", "GetGetRenderer_IHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		global::AndroidX.Media3.ExoPlayer.IRenderer? GetRenderer (int p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='getRendererType' and count(parameter)=1 and parameter[1][@type='int']]"
		[Register ("getRendererType", "(I)I", "GetGetRendererType_IHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		int GetRendererType (int p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='prepare' and count(parameter)=1 and parameter[1][@type='androidx.media3.exoplayer.source.MediaSource']]"
		[Obsolete (@"deprecated")]
		[Register ("prepare", "(Landroidx/media3/exoplayer/source/MediaSource;)V", "GetPrepare_Landroidx_media3_exoplayer_source_MediaSource_Handler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void Prepare (global::AndroidX.Media3.ExoPlayer.Source.IMediaSource? p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='prepare' and count(parameter)=3 and parameter[1][@type='androidx.media3.exoplayer.source.MediaSource'] and parameter[2][@type='boolean'] and parameter[3][@type='boolean']]"
		[Obsolete (@"deprecated")]
		[Register ("prepare", "(Landroidx/media3/exoplayer/source/MediaSource;ZZ)V", "GetPrepare_Landroidx_media3_exoplayer_source_MediaSource_ZZHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void Prepare (global::AndroidX.Media3.ExoPlayer.Source.IMediaSource? p0, bool p1, bool p2);

		/*
		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='removeAnalyticsListener' and count(parameter)=1 and parameter[1][@type='androidx.media3.exoplayer.analytics.AnalyticsListener']]"
		[Register ("removeAnalyticsListener", "(Landroidx/media3/exoplayer/analytics/AnalyticsListener;)V", "GetRemoveAnalyticsListener_Landroidx_media3_exoplayer_analytics_AnalyticsListener_Handler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void RemoveAnalyticsListener (global::AndroidX.Media3.ExoPlayer.Analytics.IAnalyticsListener? p0);
		*/

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='removeAudioOffloadListener' and count(parameter)=1 and parameter[1][@type='androidx.media3.exoplayer.ExoPlayer.AudioOffloadListener']]"
		[Register ("removeAudioOffloadListener", "(Landroidx/media3/exoplayer/ExoPlayer$AudioOffloadListener;)V", "GetRemoveAudioOffloadListener_Landroidx_media3_exoplayer_ExoPlayer_AudioOffloadListener_Handler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void RemoveAudioOffloadListener (global::AndroidX.Media3.ExoPlayer.IExoPlayerAudioOffloadListener? p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='retry' and count(parameter)=0]"
		[Obsolete (@"deprecated")]
		[Register ("retry", "()V", "GetRetryHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void Retry ();

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='setAudioAttributes' and count(parameter)=2 and parameter[1][@type='androidx.media3.common.AudioAttributes'] and parameter[2][@type='boolean']]"
		[Register ("setAudioAttributes", "(Landroidx/media3/common/AudioAttributes;Z)V", "GetSetAudioAttributes_Landroidx_media3_common_AudioAttributes_ZHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void SetAudioAttributes (global::AndroidX.Media3.Common.AudioAttributes? p0, bool p1);

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='setAuxEffectInfo' and count(parameter)=1 and parameter[1][@type='androidx.media3.common.AuxEffectInfo']]"
		[Register ("setAuxEffectInfo", "(Landroidx/media3/common/AuxEffectInfo;)V", "GetSetAuxEffectInfo_Landroidx_media3_common_AuxEffectInfo_Handler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void SetAuxEffectInfo (global::AndroidX.Media3.Common.AuxEffectInfo? p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='setCameraMotionListener' and count(parameter)=1 and parameter[1][@type='androidx.media3.exoplayer.video.spherical.CameraMotionListener']]"
		[Register ("setCameraMotionListener", "(Landroidx/media3/exoplayer/video/spherical/CameraMotionListener;)V", "GetSetCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_Handler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void SetCameraMotionListener (global::AndroidX.Media3.ExoPlayer.Video.Spherical.ICameraMotionListener? p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='setForegroundMode' and count(parameter)=1 and parameter[1][@type='boolean']]"
		[Register ("setForegroundMode", "(Z)V", "GetSetForegroundMode_ZHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void SetForegroundMode (bool p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='setHandleAudioBecomingNoisy' and count(parameter)=1 and parameter[1][@type='boolean']]"
		[Register ("setHandleAudioBecomingNoisy", "(Z)V", "GetSetHandleAudioBecomingNoisy_ZHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void SetHandleAudioBecomingNoisy (bool p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='setHandleWakeLock' and count(parameter)=1 and parameter[1][@type='boolean']]"
		[Obsolete (@"deprecated")]
		[Register ("setHandleWakeLock", "(Z)V", "GetSetHandleWakeLock_ZHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void SetHandleWakeLock (bool p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='setMediaSource' and count(parameter)=1 and parameter[1][@type='androidx.media3.exoplayer.source.MediaSource']]"
		[Register ("setMediaSource", "(Landroidx/media3/exoplayer/source/MediaSource;)V", "GetSetMediaSource_Landroidx_media3_exoplayer_source_MediaSource_Handler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void SetMediaSource (global::AndroidX.Media3.ExoPlayer.Source.IMediaSource? p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='setMediaSource' and count(parameter)=2 and parameter[1][@type='androidx.media3.exoplayer.source.MediaSource'] and parameter[2][@type='boolean']]"
		[Register ("setMediaSource", "(Landroidx/media3/exoplayer/source/MediaSource;Z)V", "GetSetMediaSource_Landroidx_media3_exoplayer_source_MediaSource_ZHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void SetMediaSource (global::AndroidX.Media3.ExoPlayer.Source.IMediaSource? p0, bool p1);

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='setMediaSource' and count(parameter)=2 and parameter[1][@type='androidx.media3.exoplayer.source.MediaSource'] and parameter[2][@type='long']]"
		[Register ("setMediaSource", "(Landroidx/media3/exoplayer/source/MediaSource;J)V", "GetSetMediaSource_Landroidx_media3_exoplayer_source_MediaSource_JHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void SetMediaSource (global::AndroidX.Media3.ExoPlayer.Source.IMediaSource? p0, long p1);

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='setMediaSources' and count(parameter)=1 and parameter[1][@type='java.util.List&lt;androidx.media3.exoplayer.source.MediaSource&gt;']]"
		[Register ("setMediaSources", "(Ljava/util/List;)V", "GetSetMediaSources_Ljava_util_List_Handler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void SetMediaSources (global::System.Collections.Generic.IList<global::AndroidX.Media3.ExoPlayer.Source.IMediaSource>? p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='setMediaSources' and count(parameter)=2 and parameter[1][@type='java.util.List&lt;androidx.media3.exoplayer.source.MediaSource&gt;'] and parameter[2][@type='boolean']]"
		[Register ("setMediaSources", "(Ljava/util/List;Z)V", "GetSetMediaSources_Ljava_util_List_ZHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void SetMediaSources (global::System.Collections.Generic.IList<global::AndroidX.Media3.ExoPlayer.Source.IMediaSource>? p0, bool p1);

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='setMediaSources' and count(parameter)=3 and parameter[1][@type='java.util.List&lt;androidx.media3.exoplayer.source.MediaSource&gt;'] and parameter[2][@type='int'] and parameter[3][@type='long']]"
		[Register ("setMediaSources", "(Ljava/util/List;IJ)V", "GetSetMediaSources_Ljava_util_List_IJHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void SetMediaSources (global::System.Collections.Generic.IList<global::AndroidX.Media3.ExoPlayer.Source.IMediaSource>? p0, int p1, long p2);

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='setPreferredAudioDevice' and count(parameter)=1 and parameter[1][@type='android.media.AudioDeviceInfo']]"
		[Register ("setPreferredAudioDevice", "(Landroid/media/AudioDeviceInfo;)V", "GetSetPreferredAudioDevice_Landroid_media_AudioDeviceInfo_Handler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void SetPreferredAudioDevice (global::Android.Media.AudioDeviceInfo? p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='setPriorityTaskManager' and count(parameter)=1 and parameter[1][@type='androidx.media3.common.PriorityTaskManager']]"
		[Register ("setPriorityTaskManager", "(Landroidx/media3/common/PriorityTaskManager;)V", "GetSetPriorityTaskManager_Landroidx_media3_common_PriorityTaskManager_Handler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void SetPriorityTaskManager (global::AndroidX.Media3.Common.PriorityTaskManager? p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='setShuffleOrder' and count(parameter)=1 and parameter[1][@type='androidx.media3.exoplayer.source.ShuffleOrder']]"
		[Register ("setShuffleOrder", "(Landroidx/media3/exoplayer/source/ShuffleOrder;)V", "GetSetShuffleOrder_Landroidx_media3_exoplayer_source_ShuffleOrder_Handler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void SetShuffleOrder (global::AndroidX.Media3.ExoPlayer.Source.IShuffleOrder? p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='setVideoFrameMetadataListener' and count(parameter)=1 and parameter[1][@type='androidx.media3.exoplayer.video.VideoFrameMetadataListener']]"
		[Register ("setVideoFrameMetadataListener", "(Landroidx/media3/exoplayer/video/VideoFrameMetadataListener;)V", "GetSetVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_Handler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void SetVideoFrameMetadataListener (global::AndroidX.Media3.ExoPlayer.Video.IVideoFrameMetadataListener? p0);

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer']/interface[@name='ExoPlayer']/method[@name='setWakeMode' and count(parameter)=1 and parameter[1][@type='int']]"
		[Register ("setWakeMode", "(I)V", "GetSetWakeMode_IHandler:AndroidX.Media3.ExoPlayer.IExoPlayerInvoker, Xamarin.AndroidX.Media3.ExoPlayer")]
		void SetWakeMode (int p0);

	}

	[global::Android.Runtime.Register ("androidx/media3/exoplayer/ExoPlayer", DoNotGenerateAcw=true)]
	internal partial class IExoPlayerInvoker : global::Java.Lang.Object, IExoPlayer {
		static readonly JniPeerMembers _members = new XAPeerMembers ("androidx/media3/exoplayer/ExoPlayer", typeof (IExoPlayerInvoker));

		static IntPtr java_class_ref {
			get { return _members.JniPeerType.PeerReference.Handle; }
		}

		[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]
		[global::System.ComponentModel.EditorBrowsable (global::System.ComponentModel.EditorBrowsableState.Never)]
		public override global::Java.Interop.JniPeerMembers JniPeerMembers {
			get { return _members; }
		}

		[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]
		[global::System.ComponentModel.EditorBrowsable (global::System.ComponentModel.EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		[global::System.Diagnostics.DebuggerBrowsable (global::System.Diagnostics.DebuggerBrowsableState.Never)]
		[global::System.ComponentModel.EditorBrowsable (global::System.ComponentModel.EditorBrowsableState.Never)]
		protected override global::System.Type ThresholdType {
			get { return _members.ManagedPeerType; }
		}

		IntPtr class_ref;

		public static IExoPlayer? GetObject (IntPtr handle, JniHandleOwnership transfer)
		{
			return global::Java.Lang.Object.GetObject<IExoPlayer> (handle, transfer);
		}

		static IntPtr Validate (IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf (handle, java_class_ref))
				throw new InvalidCastException ($"Unable to convert instance of type '{JNIEnv.GetClassNameFromInstance (handle)}' to type 'androidx.media3.exoplayer.ExoPlayer'.");
			return handle;
		}

		protected override void Dispose (bool disposing)
		{
			if (this.class_ref != IntPtr.Zero)
				JNIEnv.DeleteGlobalRef (this.class_ref);
			this.class_ref = IntPtr.Zero;
			base.Dispose (disposing);
		}

		public IExoPlayerInvoker (IntPtr handle, JniHandleOwnership transfer) : base (Validate (handle), transfer)
		{
			IntPtr local_ref = JNIEnv.GetObjectClass (((global::Java.Lang.Object) this).Handle);
			this.class_ref = JNIEnv.NewGlobalRef (local_ref);
			JNIEnv.DeleteLocalRef (local_ref);
		}

		/*
		static Delegate? cb_getAnalyticsCollector;
#pragma warning disable 0169
		static Delegate GetGetAnalyticsCollectorHandler ()
		{
			if (cb_getAnalyticsCollector == null)
				cb_getAnalyticsCollector = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_L) n_GetAnalyticsCollector);
			return cb_getAnalyticsCollector;
		}

		static IntPtr n_GetAnalyticsCollector (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return JNIEnv.ToLocalJniHandle (__this.AnalyticsCollector);
		}
#pragma warning restore 0169

		IntPtr id_getAnalyticsCollector;
		public unsafe global::AndroidX.Media3.ExoPlayer.Analytics.IAnalyticsCollector? AnalyticsCollector {
			get {
				if (id_getAnalyticsCollector == IntPtr.Zero)
					id_getAnalyticsCollector = JNIEnv.GetMethodID (class_ref, "getAnalyticsCollector", "()Landroidx/media3/exoplayer/analytics/AnalyticsCollector;");
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.Analytics.IAnalyticsCollector> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getAnalyticsCollector), JniHandleOwnership.TransferLocalRef);
			}
		}
		*/

		static Delegate? cb_getAudioComponent;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetGetAudioComponentHandler ()
		{
			if (cb_getAudioComponent == null)
				cb_getAudioComponent = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_L) n_GetAudioComponent);
			return cb_getAudioComponent;
		}

		[Obsolete]
		static IntPtr n_GetAudioComponent (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return JNIEnv.ToLocalJniHandle (__this.AudioComponent);
		}
#pragma warning restore 0169

		IntPtr id_getAudioComponent;
		public unsafe global::AndroidX.Media3.ExoPlayer.IExoPlayerAudioComponent? AudioComponent {
			get {
				if (id_getAudioComponent == IntPtr.Zero)
					id_getAudioComponent = JNIEnv.GetMethodID (class_ref, "getAudioComponent", "()Landroidx/media3/exoplayer/ExoPlayer$AudioComponent;");
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerAudioComponent> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getAudioComponent), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate? cb_getAudioDecoderCounters;
#pragma warning disable 0169
		static Delegate GetGetAudioDecoderCountersHandler ()
		{
			if (cb_getAudioDecoderCounters == null)
				cb_getAudioDecoderCounters = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_L) n_GetAudioDecoderCounters);
			return cb_getAudioDecoderCounters;
		}

		static IntPtr n_GetAudioDecoderCounters (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return JNIEnv.ToLocalJniHandle (__this.AudioDecoderCounters);
		}
#pragma warning restore 0169

		IntPtr id_getAudioDecoderCounters;
		public unsafe global::AndroidX.Media3.ExoPlayer.DecoderCounters? AudioDecoderCounters {
			get {
				if (id_getAudioDecoderCounters == IntPtr.Zero)
					id_getAudioDecoderCounters = JNIEnv.GetMethodID (class_ref, "getAudioDecoderCounters", "()Landroidx/media3/exoplayer/DecoderCounters;");
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.DecoderCounters> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getAudioDecoderCounters), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate? cb_getAudioFormat;
#pragma warning disable 0169
		static Delegate GetGetAudioFormatHandler ()
		{
			if (cb_getAudioFormat == null)
				cb_getAudioFormat = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_L) n_GetAudioFormat);
			return cb_getAudioFormat;
		}

		static IntPtr n_GetAudioFormat (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return JNIEnv.ToLocalJniHandle (__this.AudioFormat);
		}
#pragma warning restore 0169

		IntPtr id_getAudioFormat;
		public unsafe global::AndroidX.Media3.Common.Format? AudioFormat {
			get {
				if (id_getAudioFormat == IntPtr.Zero)
					id_getAudioFormat = JNIEnv.GetMethodID (class_ref, "getAudioFormat", "()Landroidx/media3/common/Format;");
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.Common.Format> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getAudioFormat), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate? cb_getAudioSessionId;
#pragma warning disable 0169
		static Delegate GetGetAudioSessionIdHandler ()
		{
			if (cb_getAudioSessionId == null)
				cb_getAudioSessionId = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_I) n_GetAudioSessionId);
			return cb_getAudioSessionId;
		}

		static int n_GetAudioSessionId (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.AudioSessionId;
		}
#pragma warning restore 0169

		static Delegate? cb_setAudioSessionId_I;
#pragma warning disable 0169
		static Delegate GetSetAudioSessionId_IHandler ()
		{
			if (cb_setAudioSessionId_I == null)
				cb_setAudioSessionId_I = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPI_V) n_SetAudioSessionId_I);
			return cb_setAudioSessionId_I;
		}

		static void n_SetAudioSessionId_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.AudioSessionId = p0;
		}
#pragma warning restore 0169

		IntPtr id_getAudioSessionId;
		IntPtr id_setAudioSessionId_I;
		public unsafe int AudioSessionId {
			get {
				if (id_getAudioSessionId == IntPtr.Zero)
					id_getAudioSessionId = JNIEnv.GetMethodID (class_ref, "getAudioSessionId", "()I");
				return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getAudioSessionId);
			}
			set {
				if (id_setAudioSessionId_I == IntPtr.Zero)
					id_setAudioSessionId_I = JNIEnv.GetMethodID (class_ref, "setAudioSessionId", "(I)V");
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (value);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setAudioSessionId_I, __args);
			}
		}

		static Delegate? cb_getClock;
#pragma warning disable 0169
		static Delegate GetGetClockHandler ()
		{
			if (cb_getClock == null)
				cb_getClock = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_L) n_GetClock);
			return cb_getClock;
		}

		static IntPtr n_GetClock (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return JNIEnv.ToLocalJniHandle (__this.Clock);
		}
#pragma warning restore 0169

		IntPtr id_getClock;
		public unsafe global::AndroidX.Media3.Common.Util.IClock? Clock {
			get {
				if (id_getClock == IntPtr.Zero)
					id_getClock = JNIEnv.GetMethodID (class_ref, "getClock", "()Landroidx/media3/common/util/Clock;");
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.Common.Util.IClock> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getClock), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate? cb_getCurrentTrackGroups;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetGetCurrentTrackGroupsHandler ()
		{
			if (cb_getCurrentTrackGroups == null)
				cb_getCurrentTrackGroups = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_L) n_GetCurrentTrackGroups);
			return cb_getCurrentTrackGroups;
		}

		[Obsolete]
		static IntPtr n_GetCurrentTrackGroups (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return JNIEnv.ToLocalJniHandle (__this.CurrentTrackGroups);
		}
#pragma warning restore 0169

		IntPtr id_getCurrentTrackGroups;
		public unsafe global::AndroidX.Media3.ExoPlayer.Source.TrackGroupArray? CurrentTrackGroups {
			get {
				if (id_getCurrentTrackGroups == IntPtr.Zero)
					id_getCurrentTrackGroups = JNIEnv.GetMethodID (class_ref, "getCurrentTrackGroups", "()Landroidx/media3/exoplayer/source/TrackGroupArray;");
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.Source.TrackGroupArray> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getCurrentTrackGroups), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate? cb_getCurrentTrackSelections;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetGetCurrentTrackSelectionsHandler ()
		{
			if (cb_getCurrentTrackSelections == null)
				cb_getCurrentTrackSelections = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_L) n_GetCurrentTrackSelections);
			return cb_getCurrentTrackSelections;
		}

		[Obsolete]
		static IntPtr n_GetCurrentTrackSelections (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return JNIEnv.ToLocalJniHandle (__this.CurrentTrackSelections);
		}
#pragma warning restore 0169

		IntPtr id_getCurrentTrackSelections;
		public unsafe global::AndroidX.Media3.ExoPlayer.Trackselection.TrackSelectionArray? CurrentTrackSelections {
			get {
				if (id_getCurrentTrackSelections == IntPtr.Zero)
					id_getCurrentTrackSelections = JNIEnv.GetMethodID (class_ref, "getCurrentTrackSelections", "()Landroidx/media3/exoplayer/trackselection/TrackSelectionArray;");
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.Trackselection.TrackSelectionArray> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getCurrentTrackSelections), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate? cb_getDeviceComponent;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetGetDeviceComponentHandler ()
		{
			if (cb_getDeviceComponent == null)
				cb_getDeviceComponent = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_L) n_GetDeviceComponent);
			return cb_getDeviceComponent;
		}

		[Obsolete]
		static IntPtr n_GetDeviceComponent (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return JNIEnv.ToLocalJniHandle (__this.DeviceComponent);
		}
#pragma warning restore 0169

		IntPtr id_getDeviceComponent;
		public unsafe global::AndroidX.Media3.ExoPlayer.IExoPlayerDeviceComponent? DeviceComponent {
			get {
				if (id_getDeviceComponent == IntPtr.Zero)
					id_getDeviceComponent = JNIEnv.GetMethodID (class_ref, "getDeviceComponent", "()Landroidx/media3/exoplayer/ExoPlayer$DeviceComponent;");
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerDeviceComponent> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getDeviceComponent), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate? cb_isTunnelingEnabled;
#pragma warning disable 0169
		static Delegate GetIsTunnelingEnabledHandler ()
		{
			if (cb_isTunnelingEnabled == null)
				cb_isTunnelingEnabled = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_Z) n_IsTunnelingEnabled);
			return cb_isTunnelingEnabled;
		}

		static bool n_IsTunnelingEnabled (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.IsTunnelingEnabled;
		}
#pragma warning restore 0169

		IntPtr id_isTunnelingEnabled;
		public unsafe bool IsTunnelingEnabled {
			get {
				if (id_isTunnelingEnabled == IntPtr.Zero)
					id_isTunnelingEnabled = JNIEnv.GetMethodID (class_ref, "isTunnelingEnabled", "()Z");
				return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isTunnelingEnabled);
			}
		}

		static Delegate? cb_getPauseAtEndOfMediaItems;
#pragma warning disable 0169
		static Delegate GetGetPauseAtEndOfMediaItemsHandler ()
		{
			if (cb_getPauseAtEndOfMediaItems == null)
				cb_getPauseAtEndOfMediaItems = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_Z) n_GetPauseAtEndOfMediaItems);
			return cb_getPauseAtEndOfMediaItems;
		}

		static bool n_GetPauseAtEndOfMediaItems (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.PauseAtEndOfMediaItems;
		}
#pragma warning restore 0169

		static Delegate? cb_setPauseAtEndOfMediaItems_Z;
#pragma warning disable 0169
		static Delegate GetSetPauseAtEndOfMediaItems_ZHandler ()
		{
			if (cb_setPauseAtEndOfMediaItems_Z == null)
				cb_setPauseAtEndOfMediaItems_Z = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPZ_V) n_SetPauseAtEndOfMediaItems_Z);
			return cb_setPauseAtEndOfMediaItems_Z;
		}

		static void n_SetPauseAtEndOfMediaItems_Z (IntPtr jnienv, IntPtr native__this, bool p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.PauseAtEndOfMediaItems = p0;
		}
#pragma warning restore 0169

		IntPtr id_getPauseAtEndOfMediaItems;
		IntPtr id_setPauseAtEndOfMediaItems_Z;
		public unsafe bool PauseAtEndOfMediaItems {
			get {
				if (id_getPauseAtEndOfMediaItems == IntPtr.Zero)
					id_getPauseAtEndOfMediaItems = JNIEnv.GetMethodID (class_ref, "getPauseAtEndOfMediaItems", "()Z");
				return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_getPauseAtEndOfMediaItems);
			}
			set {
				if (id_setPauseAtEndOfMediaItems_Z == IntPtr.Zero)
					id_setPauseAtEndOfMediaItems_Z = JNIEnv.GetMethodID (class_ref, "setPauseAtEndOfMediaItems", "(Z)V");
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (value);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setPauseAtEndOfMediaItems_Z, __args);
			}
		}

		static Delegate? cb_getPlaybackLooper;
#pragma warning disable 0169
		static Delegate GetGetPlaybackLooperHandler ()
		{
			if (cb_getPlaybackLooper == null)
				cb_getPlaybackLooper = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_L) n_GetPlaybackLooper);
			return cb_getPlaybackLooper;
		}

		static IntPtr n_GetPlaybackLooper (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return JNIEnv.ToLocalJniHandle (__this.PlaybackLooper);
		}
#pragma warning restore 0169

		IntPtr id_getPlaybackLooper;
		public unsafe global::Android.OS.Looper? PlaybackLooper {
			get {
				if (id_getPlaybackLooper == IntPtr.Zero)
					id_getPlaybackLooper = JNIEnv.GetMethodID (class_ref, "getPlaybackLooper", "()Landroid/os/Looper;");
				return global::Java.Lang.Object.GetObject<global::Android.OS.Looper> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getPlaybackLooper), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate? cb_getPlayerError;
#pragma warning disable 0169
		static Delegate GetGetPlayerErrorHandler ()
		{
			if (cb_getPlayerError == null)
				cb_getPlayerError = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_L) n_GetPlayerError);
			return cb_getPlayerError;
		}

		static IntPtr n_GetPlayerError (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return JNIEnv.ToLocalJniHandle (__this.PlayerError);
		}
#pragma warning restore 0169

		IntPtr id_getPlayerError;
		// public unsafe global::AndroidX.Media3.ExoPlayer.ExoPlaybackException? PlayerError {
		public unsafe global::AndroidX.Media3.Common.PlaybackException? PlayerError {
			get {
				if (id_getPlayerError == IntPtr.Zero)
					id_getPlayerError = JNIEnv.GetMethodID (class_ref, "getPlayerError", "()Landroidx/media3/exoplayer/ExoPlaybackException;");
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.ExoPlaybackException> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getPlayerError), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate? cb_getRendererCount;
#pragma warning disable 0169
		static Delegate GetGetRendererCountHandler ()
		{
			if (cb_getRendererCount == null)
				cb_getRendererCount = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_I) n_GetRendererCount);
			return cb_getRendererCount;
		}

		static int n_GetRendererCount (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.RendererCount;
		}
#pragma warning restore 0169

		IntPtr id_getRendererCount;
		public unsafe int RendererCount {
			get {
				if (id_getRendererCount == IntPtr.Zero)
					id_getRendererCount = JNIEnv.GetMethodID (class_ref, "getRendererCount", "()I");
				return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getRendererCount);
			}
		}

		static Delegate? cb_getSeekParameters;
#pragma warning disable 0169
		static Delegate GetGetSeekParametersHandler ()
		{
			if (cb_getSeekParameters == null)
				cb_getSeekParameters = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_L) n_GetSeekParameters);
			return cb_getSeekParameters;
		}

		static IntPtr n_GetSeekParameters (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return JNIEnv.ToLocalJniHandle (__this.SeekParameters);
		}
#pragma warning restore 0169

		static Delegate? cb_setSeekParameters_Landroidx_media3_exoplayer_SeekParameters_;
#pragma warning disable 0169
		static Delegate GetSetSeekParameters_Landroidx_media3_exoplayer_SeekParameters_Handler ()
		{
			if (cb_setSeekParameters_Landroidx_media3_exoplayer_SeekParameters_ == null)
				cb_setSeekParameters_Landroidx_media3_exoplayer_SeekParameters_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_SetSeekParameters_Landroidx_media3_exoplayer_SeekParameters_);
			return cb_setSeekParameters_Landroidx_media3_exoplayer_SeekParameters_;
		}

		static void n_SetSeekParameters_Landroidx_media3_exoplayer_SeekParameters_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.SeekParameters> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SeekParameters = p0;
		}
#pragma warning restore 0169

		IntPtr id_getSeekParameters;
		IntPtr id_setSeekParameters_Landroidx_media3_exoplayer_SeekParameters_;
		public unsafe global::AndroidX.Media3.ExoPlayer.SeekParameters? SeekParameters {
			get {
				if (id_getSeekParameters == IntPtr.Zero)
					id_getSeekParameters = JNIEnv.GetMethodID (class_ref, "getSeekParameters", "()Landroidx/media3/exoplayer/SeekParameters;");
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.SeekParameters> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getSeekParameters), JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (id_setSeekParameters_Landroidx_media3_exoplayer_SeekParameters_ == IntPtr.Zero)
					id_setSeekParameters_Landroidx_media3_exoplayer_SeekParameters_ = JNIEnv.GetMethodID (class_ref, "setSeekParameters", "(Landroidx/media3/exoplayer/SeekParameters;)V");
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue ((value == null) ? IntPtr.Zero : ((global::Java.Lang.Object) value).Handle);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setSeekParameters_Landroidx_media3_exoplayer_SeekParameters_, __args);
			}
		}

		static Delegate? cb_getSkipSilenceEnabled;
#pragma warning disable 0169
		static Delegate GetGetSkipSilenceEnabledHandler ()
		{
			if (cb_getSkipSilenceEnabled == null)
				cb_getSkipSilenceEnabled = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_Z) n_GetSkipSilenceEnabled);
			return cb_getSkipSilenceEnabled;
		}

		static bool n_GetSkipSilenceEnabled (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.SkipSilenceEnabled;
		}
#pragma warning restore 0169

		static Delegate? cb_setSkipSilenceEnabled_Z;
#pragma warning disable 0169
		static Delegate GetSetSkipSilenceEnabled_ZHandler ()
		{
			if (cb_setSkipSilenceEnabled_Z == null)
				cb_setSkipSilenceEnabled_Z = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPZ_V) n_SetSkipSilenceEnabled_Z);
			return cb_setSkipSilenceEnabled_Z;
		}

		static void n_SetSkipSilenceEnabled_Z (IntPtr jnienv, IntPtr native__this, bool p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.SkipSilenceEnabled = p0;
		}
#pragma warning restore 0169

		IntPtr id_getSkipSilenceEnabled;
		IntPtr id_setSkipSilenceEnabled_Z;
		public unsafe bool SkipSilenceEnabled {
			get {
				if (id_getSkipSilenceEnabled == IntPtr.Zero)
					id_getSkipSilenceEnabled = JNIEnv.GetMethodID (class_ref, "getSkipSilenceEnabled", "()Z");
				return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_getSkipSilenceEnabled);
			}
			set {
				if (id_setSkipSilenceEnabled_Z == IntPtr.Zero)
					id_setSkipSilenceEnabled_Z = JNIEnv.GetMethodID (class_ref, "setSkipSilenceEnabled", "(Z)V");
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (value);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setSkipSilenceEnabled_Z, __args);
			}
		}

		static Delegate? cb_getTextComponent;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetGetTextComponentHandler ()
		{
			if (cb_getTextComponent == null)
				cb_getTextComponent = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_L) n_GetTextComponent);
			return cb_getTextComponent;
		}

		[Obsolete]
		static IntPtr n_GetTextComponent (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return JNIEnv.ToLocalJniHandle (__this.TextComponent);
		}
#pragma warning restore 0169

		IntPtr id_getTextComponent;
		public unsafe global::AndroidX.Media3.ExoPlayer.IExoPlayerTextComponent? TextComponent {
			get {
				if (id_getTextComponent == IntPtr.Zero)
					id_getTextComponent = JNIEnv.GetMethodID (class_ref, "getTextComponent", "()Landroidx/media3/exoplayer/ExoPlayer$TextComponent;");
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerTextComponent> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getTextComponent), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate? cb_getTrackSelector;
#pragma warning disable 0169
		static Delegate GetGetTrackSelectorHandler ()
		{
			if (cb_getTrackSelector == null)
				cb_getTrackSelector = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_L) n_GetTrackSelector);
			return cb_getTrackSelector;
		}

		static IntPtr n_GetTrackSelector (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return JNIEnv.ToLocalJniHandle (__this.TrackSelector);
		}
#pragma warning restore 0169

		IntPtr id_getTrackSelector;
		public unsafe global::AndroidX.Media3.ExoPlayer.Trackselection.TrackSelector? TrackSelector {
			get {
				if (id_getTrackSelector == IntPtr.Zero)
					id_getTrackSelector = JNIEnv.GetMethodID (class_ref, "getTrackSelector", "()Landroidx/media3/exoplayer/trackselection/TrackSelector;");
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.Trackselection.TrackSelector> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getTrackSelector), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate? cb_getVideoChangeFrameRateStrategy;
#pragma warning disable 0169
		static Delegate GetGetVideoChangeFrameRateStrategyHandler ()
		{
			if (cb_getVideoChangeFrameRateStrategy == null)
				cb_getVideoChangeFrameRateStrategy = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_I) n_GetVideoChangeFrameRateStrategy);
			return cb_getVideoChangeFrameRateStrategy;
		}

		static int n_GetVideoChangeFrameRateStrategy (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.VideoChangeFrameRateStrategy;
		}
#pragma warning restore 0169

		static Delegate? cb_setVideoChangeFrameRateStrategy_I;
#pragma warning disable 0169
		static Delegate GetSetVideoChangeFrameRateStrategy_IHandler ()
		{
			if (cb_setVideoChangeFrameRateStrategy_I == null)
				cb_setVideoChangeFrameRateStrategy_I = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPI_V) n_SetVideoChangeFrameRateStrategy_I);
			return cb_setVideoChangeFrameRateStrategy_I;
		}

		static void n_SetVideoChangeFrameRateStrategy_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.VideoChangeFrameRateStrategy = p0;
		}
#pragma warning restore 0169

		IntPtr id_getVideoChangeFrameRateStrategy;
		IntPtr id_setVideoChangeFrameRateStrategy_I;
		public unsafe int VideoChangeFrameRateStrategy {
			get {
				if (id_getVideoChangeFrameRateStrategy == IntPtr.Zero)
					id_getVideoChangeFrameRateStrategy = JNIEnv.GetMethodID (class_ref, "getVideoChangeFrameRateStrategy", "()I");
				return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getVideoChangeFrameRateStrategy);
			}
			set {
				if (id_setVideoChangeFrameRateStrategy_I == IntPtr.Zero)
					id_setVideoChangeFrameRateStrategy_I = JNIEnv.GetMethodID (class_ref, "setVideoChangeFrameRateStrategy", "(I)V");
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (value);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setVideoChangeFrameRateStrategy_I, __args);
			}
		}

		static Delegate? cb_getVideoComponent;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetGetVideoComponentHandler ()
		{
			if (cb_getVideoComponent == null)
				cb_getVideoComponent = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_L) n_GetVideoComponent);
			return cb_getVideoComponent;
		}

		[Obsolete]
		static IntPtr n_GetVideoComponent (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return JNIEnv.ToLocalJniHandle (__this.VideoComponent);
		}
#pragma warning restore 0169

		IntPtr id_getVideoComponent;
		public unsafe global::AndroidX.Media3.ExoPlayer.IExoPlayerVideoComponent? VideoComponent {
			get {
				if (id_getVideoComponent == IntPtr.Zero)
					id_getVideoComponent = JNIEnv.GetMethodID (class_ref, "getVideoComponent", "()Landroidx/media3/exoplayer/ExoPlayer$VideoComponent;");
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerVideoComponent> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getVideoComponent), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate? cb_getVideoDecoderCounters;
#pragma warning disable 0169
		static Delegate GetGetVideoDecoderCountersHandler ()
		{
			if (cb_getVideoDecoderCounters == null)
				cb_getVideoDecoderCounters = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_L) n_GetVideoDecoderCounters);
			return cb_getVideoDecoderCounters;
		}

		static IntPtr n_GetVideoDecoderCounters (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return JNIEnv.ToLocalJniHandle (__this.VideoDecoderCounters);
		}
#pragma warning restore 0169

		IntPtr id_getVideoDecoderCounters;
		public unsafe global::AndroidX.Media3.ExoPlayer.DecoderCounters? VideoDecoderCounters {
			get {
				if (id_getVideoDecoderCounters == IntPtr.Zero)
					id_getVideoDecoderCounters = JNIEnv.GetMethodID (class_ref, "getVideoDecoderCounters", "()Landroidx/media3/exoplayer/DecoderCounters;");
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.DecoderCounters> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getVideoDecoderCounters), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate? cb_getVideoFormat;
#pragma warning disable 0169
		static Delegate GetGetVideoFormatHandler ()
		{
			if (cb_getVideoFormat == null)
				cb_getVideoFormat = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_L) n_GetVideoFormat);
			return cb_getVideoFormat;
		}

		static IntPtr n_GetVideoFormat (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return JNIEnv.ToLocalJniHandle (__this.VideoFormat);
		}
#pragma warning restore 0169

		IntPtr id_getVideoFormat;
		public unsafe global::AndroidX.Media3.Common.Format? VideoFormat {
			get {
				if (id_getVideoFormat == IntPtr.Zero)
					id_getVideoFormat = JNIEnv.GetMethodID (class_ref, "getVideoFormat", "()Landroidx/media3/common/Format;");
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.Common.Format> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getVideoFormat), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate? cb_getVideoScalingMode;
#pragma warning disable 0169
		static Delegate GetGetVideoScalingModeHandler ()
		{
			if (cb_getVideoScalingMode == null)
				cb_getVideoScalingMode = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_I) n_GetVideoScalingMode);
			return cb_getVideoScalingMode;
		}

		static int n_GetVideoScalingMode (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.VideoScalingMode;
		}
#pragma warning restore 0169

		static Delegate? cb_setVideoScalingMode_I;
#pragma warning disable 0169
		static Delegate GetSetVideoScalingMode_IHandler ()
		{
			if (cb_setVideoScalingMode_I == null)
				cb_setVideoScalingMode_I = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPI_V) n_SetVideoScalingMode_I);
			return cb_setVideoScalingMode_I;
		}

		static void n_SetVideoScalingMode_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.VideoScalingMode = p0;
		}
#pragma warning restore 0169

		IntPtr id_getVideoScalingMode;
		IntPtr id_setVideoScalingMode_I;
		public unsafe int VideoScalingMode {
			get {
				if (id_getVideoScalingMode == IntPtr.Zero)
					id_getVideoScalingMode = JNIEnv.GetMethodID (class_ref, "getVideoScalingMode", "()I");
				return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getVideoScalingMode);
			}
			set {
				if (id_setVideoScalingMode_I == IntPtr.Zero)
					id_setVideoScalingMode_I = JNIEnv.GetMethodID (class_ref, "setVideoScalingMode", "(I)V");
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (value);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setVideoScalingMode_I, __args);
			}
		}

		/*
		static Delegate? cb_addAnalyticsListener_Landroidx_media3_exoplayer_analytics_AnalyticsListener_;
#pragma warning disable 0169
		static Delegate GetAddAnalyticsListener_Landroidx_media3_exoplayer_analytics_AnalyticsListener_Handler ()
		{
			if (cb_addAnalyticsListener_Landroidx_media3_exoplayer_analytics_AnalyticsListener_ == null)
				cb_addAnalyticsListener_Landroidx_media3_exoplayer_analytics_AnalyticsListener_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_AddAnalyticsListener_Landroidx_media3_exoplayer_analytics_AnalyticsListener_);
			return cb_addAnalyticsListener_Landroidx_media3_exoplayer_analytics_AnalyticsListener_;
		}

		static void n_AddAnalyticsListener_Landroidx_media3_exoplayer_analytics_AnalyticsListener_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = (global::AndroidX.Media3.ExoPlayer.Analytics.IAnalyticsListener?)global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.Analytics.IAnalyticsListener> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.AddAnalyticsListener (p0);
		}
#pragma warning restore 0169

		IntPtr id_addAnalyticsListener_Landroidx_media3_exoplayer_analytics_AnalyticsListener_;
		public unsafe void AddAnalyticsListener (global::AndroidX.Media3.ExoPlayer.Analytics.IAnalyticsListener? p0)
		{
			if (id_addAnalyticsListener_Landroidx_media3_exoplayer_analytics_AnalyticsListener_ == IntPtr.Zero)
				id_addAnalyticsListener_Landroidx_media3_exoplayer_analytics_AnalyticsListener_ = JNIEnv.GetMethodID (class_ref, "addAnalyticsListener", "(Landroidx/media3/exoplayer/analytics/AnalyticsListener;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_addAnalyticsListener_Landroidx_media3_exoplayer_analytics_AnalyticsListener_, __args);
		}
		*/

		static Delegate? cb_addAudioOffloadListener_Landroidx_media3_exoplayer_ExoPlayer_AudioOffloadListener_;
#pragma warning disable 0169
		static Delegate GetAddAudioOffloadListener_Landroidx_media3_exoplayer_ExoPlayer_AudioOffloadListener_Handler ()
		{
			if (cb_addAudioOffloadListener_Landroidx_media3_exoplayer_ExoPlayer_AudioOffloadListener_ == null)
				cb_addAudioOffloadListener_Landroidx_media3_exoplayer_ExoPlayer_AudioOffloadListener_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_AddAudioOffloadListener_Landroidx_media3_exoplayer_ExoPlayer_AudioOffloadListener_);
			return cb_addAudioOffloadListener_Landroidx_media3_exoplayer_ExoPlayer_AudioOffloadListener_;
		}

		static void n_AddAudioOffloadListener_Landroidx_media3_exoplayer_ExoPlayer_AudioOffloadListener_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = (global::AndroidX.Media3.ExoPlayer.IExoPlayerAudioOffloadListener?)global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerAudioOffloadListener> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.AddAudioOffloadListener (p0);
		}
#pragma warning restore 0169

		IntPtr id_addAudioOffloadListener_Landroidx_media3_exoplayer_ExoPlayer_AudioOffloadListener_;
		public unsafe void AddAudioOffloadListener (global::AndroidX.Media3.ExoPlayer.IExoPlayerAudioOffloadListener? p0)
		{
			if (id_addAudioOffloadListener_Landroidx_media3_exoplayer_ExoPlayer_AudioOffloadListener_ == IntPtr.Zero)
				id_addAudioOffloadListener_Landroidx_media3_exoplayer_ExoPlayer_AudioOffloadListener_ = JNIEnv.GetMethodID (class_ref, "addAudioOffloadListener", "(Landroidx/media3/exoplayer/ExoPlayer$AudioOffloadListener;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_addAudioOffloadListener_Landroidx_media3_exoplayer_ExoPlayer_AudioOffloadListener_, __args);
		}

		static Delegate? cb_addMediaSource_Landroidx_media3_exoplayer_source_MediaSource_;
#pragma warning disable 0169
		static Delegate GetAddMediaSource_Landroidx_media3_exoplayer_source_MediaSource_Handler ()
		{
			if (cb_addMediaSource_Landroidx_media3_exoplayer_source_MediaSource_ == null)
				cb_addMediaSource_Landroidx_media3_exoplayer_source_MediaSource_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_AddMediaSource_Landroidx_media3_exoplayer_source_MediaSource_);
			return cb_addMediaSource_Landroidx_media3_exoplayer_source_MediaSource_;
		}

		static void n_AddMediaSource_Landroidx_media3_exoplayer_source_MediaSource_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = (global::AndroidX.Media3.ExoPlayer.Source.IMediaSource?)global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.Source.IMediaSource> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.AddMediaSource (p0);
		}
#pragma warning restore 0169

		IntPtr id_addMediaSource_Landroidx_media3_exoplayer_source_MediaSource_;
		public unsafe void AddMediaSource (global::AndroidX.Media3.ExoPlayer.Source.IMediaSource? p0)
		{
			if (id_addMediaSource_Landroidx_media3_exoplayer_source_MediaSource_ == IntPtr.Zero)
				id_addMediaSource_Landroidx_media3_exoplayer_source_MediaSource_ = JNIEnv.GetMethodID (class_ref, "addMediaSource", "(Landroidx/media3/exoplayer/source/MediaSource;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_addMediaSource_Landroidx_media3_exoplayer_source_MediaSource_, __args);
		}

		static Delegate? cb_addMediaSource_ILandroidx_media3_exoplayer_source_MediaSource_;
#pragma warning disable 0169
		static Delegate GetAddMediaSource_ILandroidx_media3_exoplayer_source_MediaSource_Handler ()
		{
			if (cb_addMediaSource_ILandroidx_media3_exoplayer_source_MediaSource_ == null)
				cb_addMediaSource_ILandroidx_media3_exoplayer_source_MediaSource_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPIL_V) n_AddMediaSource_ILandroidx_media3_exoplayer_source_MediaSource_);
			return cb_addMediaSource_ILandroidx_media3_exoplayer_source_MediaSource_;
		}

		static void n_AddMediaSource_ILandroidx_media3_exoplayer_source_MediaSource_ (IntPtr jnienv, IntPtr native__this, int p0, IntPtr native_p1)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p1 = (global::AndroidX.Media3.ExoPlayer.Source.IMediaSource?)global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.Source.IMediaSource> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.AddMediaSource (p0, p1);
		}
#pragma warning restore 0169

		IntPtr id_addMediaSource_ILandroidx_media3_exoplayer_source_MediaSource_;
		public unsafe void AddMediaSource (int p0, global::AndroidX.Media3.ExoPlayer.Source.IMediaSource? p1)
		{
			if (id_addMediaSource_ILandroidx_media3_exoplayer_source_MediaSource_ == IntPtr.Zero)
				id_addMediaSource_ILandroidx_media3_exoplayer_source_MediaSource_ = JNIEnv.GetMethodID (class_ref, "addMediaSource", "(ILandroidx/media3/exoplayer/source/MediaSource;)V");
			JValue* __args = stackalloc JValue [2];
			__args [0] = new JValue (p0);
			__args [1] = new JValue ((p1 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p1).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_addMediaSource_ILandroidx_media3_exoplayer_source_MediaSource_, __args);
		}

		static Delegate? cb_addMediaSources_ILjava_util_List_;
#pragma warning disable 0169
		static Delegate GetAddMediaSources_ILjava_util_List_Handler ()
		{
			if (cb_addMediaSources_ILjava_util_List_ == null)
				cb_addMediaSources_ILjava_util_List_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPIL_V) n_AddMediaSources_ILjava_util_List_);
			return cb_addMediaSources_ILjava_util_List_;
		}

		static void n_AddMediaSources_ILjava_util_List_ (IntPtr jnienv, IntPtr native__this, int p0, IntPtr native_p1)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p1 = global::Android.Runtime.JavaList<global::AndroidX.Media3.ExoPlayer.Source.IMediaSource>.FromJniHandle (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.AddMediaSources (p0, p1);
		}
#pragma warning restore 0169

		IntPtr id_addMediaSources_ILjava_util_List_;
		public unsafe void AddMediaSources (int p0, global::System.Collections.Generic.IList<global::AndroidX.Media3.ExoPlayer.Source.IMediaSource>? p1)
		{
			if (id_addMediaSources_ILjava_util_List_ == IntPtr.Zero)
				id_addMediaSources_ILjava_util_List_ = JNIEnv.GetMethodID (class_ref, "addMediaSources", "(ILjava/util/List;)V");
			IntPtr native_p1 = global::Android.Runtime.JavaList<global::AndroidX.Media3.ExoPlayer.Source.IMediaSource>.ToLocalJniHandle (p1);
			JValue* __args = stackalloc JValue [2];
			__args [0] = new JValue (p0);
			__args [1] = new JValue (native_p1);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_addMediaSources_ILjava_util_List_, __args);
			JNIEnv.DeleteLocalRef (native_p1);
		}

		static Delegate? cb_addMediaSources_Ljava_util_List_;
#pragma warning disable 0169
		static Delegate GetAddMediaSources_Ljava_util_List_Handler ()
		{
			if (cb_addMediaSources_Ljava_util_List_ == null)
				cb_addMediaSources_Ljava_util_List_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_AddMediaSources_Ljava_util_List_);
			return cb_addMediaSources_Ljava_util_List_;
		}

		static void n_AddMediaSources_Ljava_util_List_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = global::Android.Runtime.JavaList<global::AndroidX.Media3.ExoPlayer.Source.IMediaSource>.FromJniHandle (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.AddMediaSources (p0);
		}
#pragma warning restore 0169

		IntPtr id_addMediaSources_Ljava_util_List_;
		public unsafe void AddMediaSources (global::System.Collections.Generic.IList<global::AndroidX.Media3.ExoPlayer.Source.IMediaSource>? p0)
		{
			if (id_addMediaSources_Ljava_util_List_ == IntPtr.Zero)
				id_addMediaSources_Ljava_util_List_ = JNIEnv.GetMethodID (class_ref, "addMediaSources", "(Ljava/util/List;)V");
			IntPtr native_p0 = global::Android.Runtime.JavaList<global::AndroidX.Media3.ExoPlayer.Source.IMediaSource>.ToLocalJniHandle (p0);
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (native_p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_addMediaSources_Ljava_util_List_, __args);
			JNIEnv.DeleteLocalRef (native_p0);
		}

		static Delegate? cb_clearAuxEffectInfo;
#pragma warning disable 0169
		static Delegate GetClearAuxEffectInfoHandler ()
		{
			if (cb_clearAuxEffectInfo == null)
				cb_clearAuxEffectInfo = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_V) n_ClearAuxEffectInfo);
			return cb_clearAuxEffectInfo;
		}

		static void n_ClearAuxEffectInfo (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.ClearAuxEffectInfo ();
		}
#pragma warning restore 0169

		IntPtr id_clearAuxEffectInfo;
		public unsafe void ClearAuxEffectInfo ()
		{
			if (id_clearAuxEffectInfo == IntPtr.Zero)
				id_clearAuxEffectInfo = JNIEnv.GetMethodID (class_ref, "clearAuxEffectInfo", "()V");
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_clearAuxEffectInfo);
		}

		static Delegate? cb_clearCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_;
#pragma warning disable 0169
		static Delegate GetClearCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_Handler ()
		{
			if (cb_clearCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_ == null)
				cb_clearCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_ClearCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_);
			return cb_clearCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_;
		}

		static void n_ClearCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = (global::AndroidX.Media3.ExoPlayer.Video.Spherical.ICameraMotionListener?)global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.Video.Spherical.ICameraMotionListener> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ClearCameraMotionListener (p0);
		}
#pragma warning restore 0169

		IntPtr id_clearCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_;
		public unsafe void ClearCameraMotionListener (global::AndroidX.Media3.ExoPlayer.Video.Spherical.ICameraMotionListener? p0)
		{
			if (id_clearCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_ == IntPtr.Zero)
				id_clearCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_ = JNIEnv.GetMethodID (class_ref, "clearCameraMotionListener", "(Landroidx/media3/exoplayer/video/spherical/CameraMotionListener;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_clearCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_, __args);
		}

		static Delegate? cb_clearVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_;
#pragma warning disable 0169
		static Delegate GetClearVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_Handler ()
		{
			if (cb_clearVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_ == null)
				cb_clearVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_ClearVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_);
			return cb_clearVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_;
		}

		static void n_ClearVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = (global::AndroidX.Media3.ExoPlayer.Video.IVideoFrameMetadataListener?)global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.Video.IVideoFrameMetadataListener> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ClearVideoFrameMetadataListener (p0);
		}
#pragma warning restore 0169

		IntPtr id_clearVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_;
		public unsafe void ClearVideoFrameMetadataListener (global::AndroidX.Media3.ExoPlayer.Video.IVideoFrameMetadataListener? p0)
		{
			if (id_clearVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_ == IntPtr.Zero)
				id_clearVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_ = JNIEnv.GetMethodID (class_ref, "clearVideoFrameMetadataListener", "(Landroidx/media3/exoplayer/video/VideoFrameMetadataListener;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_clearVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_, __args);
		}

		static Delegate? cb_createMessage_Landroidx_media3_exoplayer_PlayerMessage_Target_;
#pragma warning disable 0169
		static Delegate GetCreateMessage_Landroidx_media3_exoplayer_PlayerMessage_Target_Handler ()
		{
			if (cb_createMessage_Landroidx_media3_exoplayer_PlayerMessage_Target_ == null)
				cb_createMessage_Landroidx_media3_exoplayer_PlayerMessage_Target_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_L) n_CreateMessage_Landroidx_media3_exoplayer_PlayerMessage_Target_);
			return cb_createMessage_Landroidx_media3_exoplayer_PlayerMessage_Target_;
		}

		static IntPtr n_CreateMessage_Landroidx_media3_exoplayer_PlayerMessage_Target_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = (global::AndroidX.Media3.ExoPlayer.PlayerMessage.ITarget?)global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.PlayerMessage.ITarget> (native_p0, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.CreateMessage (p0));
			return __ret;
		}
#pragma warning restore 0169

		IntPtr id_createMessage_Landroidx_media3_exoplayer_PlayerMessage_Target_;
		public unsafe global::AndroidX.Media3.ExoPlayer.PlayerMessage? CreateMessage (global::AndroidX.Media3.ExoPlayer.PlayerMessage.ITarget? p0)
		{
			if (id_createMessage_Landroidx_media3_exoplayer_PlayerMessage_Target_ == IntPtr.Zero)
				id_createMessage_Landroidx_media3_exoplayer_PlayerMessage_Target_ = JNIEnv.GetMethodID (class_ref, "createMessage", "(Landroidx/media3/exoplayer/PlayerMessage$Target;)Landroidx/media3/exoplayer/PlayerMessage;");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			var __ret = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.PlayerMessage> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_createMessage_Landroidx_media3_exoplayer_PlayerMessage_Target_, __args), JniHandleOwnership.TransferLocalRef);
			return __ret;
		}

		static Delegate? cb_experimentalIsSleepingForOffload;
#pragma warning disable 0169
		static Delegate GetExperimentalIsSleepingForOffloadHandler ()
		{
			if (cb_experimentalIsSleepingForOffload == null)
				cb_experimentalIsSleepingForOffload = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_Z) n_ExperimentalIsSleepingForOffload);
			return cb_experimentalIsSleepingForOffload;
		}

		static bool n_ExperimentalIsSleepingForOffload (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.ExperimentalIsSleepingForOffload ();
		}
#pragma warning restore 0169

		IntPtr id_experimentalIsSleepingForOffload;
		public unsafe bool ExperimentalIsSleepingForOffload ()
		{
			if (id_experimentalIsSleepingForOffload == IntPtr.Zero)
				id_experimentalIsSleepingForOffload = JNIEnv.GetMethodID (class_ref, "experimentalIsSleepingForOffload", "()Z");
			return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_experimentalIsSleepingForOffload);
		}

		static Delegate? cb_experimentalSetOffloadSchedulingEnabled_Z;
#pragma warning disable 0169
		static Delegate GetExperimentalSetOffloadSchedulingEnabled_ZHandler ()
		{
			if (cb_experimentalSetOffloadSchedulingEnabled_Z == null)
				cb_experimentalSetOffloadSchedulingEnabled_Z = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPZ_V) n_ExperimentalSetOffloadSchedulingEnabled_Z);
			return cb_experimentalSetOffloadSchedulingEnabled_Z;
		}

		static void n_ExperimentalSetOffloadSchedulingEnabled_Z (IntPtr jnienv, IntPtr native__this, bool p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.ExperimentalSetOffloadSchedulingEnabled (p0);
		}
#pragma warning restore 0169

		IntPtr id_experimentalSetOffloadSchedulingEnabled_Z;
		public unsafe void ExperimentalSetOffloadSchedulingEnabled (bool p0)
		{
			if (id_experimentalSetOffloadSchedulingEnabled_Z == IntPtr.Zero)
				id_experimentalSetOffloadSchedulingEnabled_Z = JNIEnv.GetMethodID (class_ref, "experimentalSetOffloadSchedulingEnabled", "(Z)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_experimentalSetOffloadSchedulingEnabled_Z, __args);
		}

		static Delegate? cb_getRenderer_I;
#pragma warning disable 0169
		static Delegate GetGetRenderer_IHandler ()
		{
			if (cb_getRenderer_I == null)
				cb_getRenderer_I = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPI_L) n_GetRenderer_I);
			return cb_getRenderer_I;
		}

		static IntPtr n_GetRenderer_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return JNIEnv.ToLocalJniHandle (__this.GetRenderer (p0));
		}
#pragma warning restore 0169

		IntPtr id_getRenderer_I;
		public unsafe global::AndroidX.Media3.ExoPlayer.IRenderer? GetRenderer (int p0)
		{
			if (id_getRenderer_I == IntPtr.Zero)
				id_getRenderer_I = JNIEnv.GetMethodID (class_ref, "getRenderer", "(I)Landroidx/media3/exoplayer/Renderer;");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IRenderer> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getRenderer_I, __args), JniHandleOwnership.TransferLocalRef);
		}

		static Delegate? cb_getRendererType_I;
#pragma warning disable 0169
		static Delegate GetGetRendererType_IHandler ()
		{
			if (cb_getRendererType_I == null)
				cb_getRendererType_I = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPI_I) n_GetRendererType_I);
			return cb_getRendererType_I;
		}

		static int n_GetRendererType_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.GetRendererType (p0);
		}
#pragma warning restore 0169

		IntPtr id_getRendererType_I;
		public unsafe int GetRendererType (int p0)
		{
			if (id_getRendererType_I == IntPtr.Zero)
				id_getRendererType_I = JNIEnv.GetMethodID (class_ref, "getRendererType", "(I)I");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getRendererType_I, __args);
		}

		static Delegate? cb_prepare_Landroidx_media3_exoplayer_source_MediaSource_;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetPrepare_Landroidx_media3_exoplayer_source_MediaSource_Handler ()
		{
			if (cb_prepare_Landroidx_media3_exoplayer_source_MediaSource_ == null)
				cb_prepare_Landroidx_media3_exoplayer_source_MediaSource_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_Prepare_Landroidx_media3_exoplayer_source_MediaSource_);
			return cb_prepare_Landroidx_media3_exoplayer_source_MediaSource_;
		}

		[Obsolete]
		static void n_Prepare_Landroidx_media3_exoplayer_source_MediaSource_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = (global::AndroidX.Media3.ExoPlayer.Source.IMediaSource?)global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.Source.IMediaSource> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Prepare (p0);
		}
#pragma warning restore 0169

		IntPtr id_prepare_Landroidx_media3_exoplayer_source_MediaSource_;
		public unsafe void Prepare (global::AndroidX.Media3.ExoPlayer.Source.IMediaSource? p0)
		{
			if (id_prepare_Landroidx_media3_exoplayer_source_MediaSource_ == IntPtr.Zero)
				id_prepare_Landroidx_media3_exoplayer_source_MediaSource_ = JNIEnv.GetMethodID (class_ref, "prepare", "(Landroidx/media3/exoplayer/source/MediaSource;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_prepare_Landroidx_media3_exoplayer_source_MediaSource_, __args);
		}

		static Delegate? cb_prepare_Landroidx_media3_exoplayer_source_MediaSource_ZZ;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetPrepare_Landroidx_media3_exoplayer_source_MediaSource_ZZHandler ()
		{
			if (cb_prepare_Landroidx_media3_exoplayer_source_MediaSource_ZZ == null)
				cb_prepare_Landroidx_media3_exoplayer_source_MediaSource_ZZ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPLZZ_V) n_Prepare_Landroidx_media3_exoplayer_source_MediaSource_ZZ);
			return cb_prepare_Landroidx_media3_exoplayer_source_MediaSource_ZZ;
		}

		[Obsolete]
		static void n_Prepare_Landroidx_media3_exoplayer_source_MediaSource_ZZ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1, bool p2)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = (global::AndroidX.Media3.ExoPlayer.Source.IMediaSource?)global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.Source.IMediaSource> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.Prepare (p0, p1, p2);
		}
#pragma warning restore 0169

		IntPtr id_prepare_Landroidx_media3_exoplayer_source_MediaSource_ZZ;
		public unsafe void Prepare (global::AndroidX.Media3.ExoPlayer.Source.IMediaSource? p0, bool p1, bool p2)
		{
			if (id_prepare_Landroidx_media3_exoplayer_source_MediaSource_ZZ == IntPtr.Zero)
				id_prepare_Landroidx_media3_exoplayer_source_MediaSource_ZZ = JNIEnv.GetMethodID (class_ref, "prepare", "(Landroidx/media3/exoplayer/source/MediaSource;ZZ)V");
			JValue* __args = stackalloc JValue [3];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			__args [1] = new JValue (p1);
			__args [2] = new JValue (p2);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_prepare_Landroidx_media3_exoplayer_source_MediaSource_ZZ, __args);
		}

		/*
		static Delegate? cb_removeAnalyticsListener_Landroidx_media3_exoplayer_analytics_AnalyticsListener_;
#pragma warning disable 0169
		static Delegate GetRemoveAnalyticsListener_Landroidx_media3_exoplayer_analytics_AnalyticsListener_Handler ()
		{
			if (cb_removeAnalyticsListener_Landroidx_media3_exoplayer_analytics_AnalyticsListener_ == null)
				cb_removeAnalyticsListener_Landroidx_media3_exoplayer_analytics_AnalyticsListener_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_RemoveAnalyticsListener_Landroidx_media3_exoplayer_analytics_AnalyticsListener_);
			return cb_removeAnalyticsListener_Landroidx_media3_exoplayer_analytics_AnalyticsListener_;
		}

		static void n_RemoveAnalyticsListener_Landroidx_media3_exoplayer_analytics_AnalyticsListener_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = (global::AndroidX.Media3.ExoPlayer.Analytics.IAnalyticsListener?)global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.Analytics.IAnalyticsListener> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.RemoveAnalyticsListener (p0);
		}
#pragma warning restore 0169

		IntPtr id_removeAnalyticsListener_Landroidx_media3_exoplayer_analytics_AnalyticsListener_;
		public unsafe void RemoveAnalyticsListener (global::AndroidX.Media3.ExoPlayer.Analytics.IAnalyticsListener? p0)
		{
			if (id_removeAnalyticsListener_Landroidx_media3_exoplayer_analytics_AnalyticsListener_ == IntPtr.Zero)
				id_removeAnalyticsListener_Landroidx_media3_exoplayer_analytics_AnalyticsListener_ = JNIEnv.GetMethodID (class_ref, "removeAnalyticsListener", "(Landroidx/media3/exoplayer/analytics/AnalyticsListener;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_removeAnalyticsListener_Landroidx_media3_exoplayer_analytics_AnalyticsListener_, __args);
		}
		*/

		static Delegate? cb_removeAudioOffloadListener_Landroidx_media3_exoplayer_ExoPlayer_AudioOffloadListener_;
#pragma warning disable 0169
		static Delegate GetRemoveAudioOffloadListener_Landroidx_media3_exoplayer_ExoPlayer_AudioOffloadListener_Handler ()
		{
			if (cb_removeAudioOffloadListener_Landroidx_media3_exoplayer_ExoPlayer_AudioOffloadListener_ == null)
				cb_removeAudioOffloadListener_Landroidx_media3_exoplayer_ExoPlayer_AudioOffloadListener_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_RemoveAudioOffloadListener_Landroidx_media3_exoplayer_ExoPlayer_AudioOffloadListener_);
			return cb_removeAudioOffloadListener_Landroidx_media3_exoplayer_ExoPlayer_AudioOffloadListener_;
		}

		static void n_RemoveAudioOffloadListener_Landroidx_media3_exoplayer_ExoPlayer_AudioOffloadListener_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = (global::AndroidX.Media3.ExoPlayer.IExoPlayerAudioOffloadListener?)global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayerAudioOffloadListener> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.RemoveAudioOffloadListener (p0);
		}
#pragma warning restore 0169

		IntPtr id_removeAudioOffloadListener_Landroidx_media3_exoplayer_ExoPlayer_AudioOffloadListener_;
		public unsafe void RemoveAudioOffloadListener (global::AndroidX.Media3.ExoPlayer.IExoPlayerAudioOffloadListener? p0)
		{
			if (id_removeAudioOffloadListener_Landroidx_media3_exoplayer_ExoPlayer_AudioOffloadListener_ == IntPtr.Zero)
				id_removeAudioOffloadListener_Landroidx_media3_exoplayer_ExoPlayer_AudioOffloadListener_ = JNIEnv.GetMethodID (class_ref, "removeAudioOffloadListener", "(Landroidx/media3/exoplayer/ExoPlayer$AudioOffloadListener;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_removeAudioOffloadListener_Landroidx_media3_exoplayer_ExoPlayer_AudioOffloadListener_, __args);
		}

		static Delegate? cb_retry;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetRetryHandler ()
		{
			if (cb_retry == null)
				cb_retry = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_V) n_Retry);
			return cb_retry;
		}

		[Obsolete]
		static void n_Retry (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.Retry ();
		}
#pragma warning restore 0169

		IntPtr id_retry;
		public unsafe void Retry ()
		{
			if (id_retry == IntPtr.Zero)
				id_retry = JNIEnv.GetMethodID (class_ref, "retry", "()V");
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_retry);
		}

		static Delegate? cb_setAudioAttributes_Landroidx_media3_common_AudioAttributes_Z;
#pragma warning disable 0169
		static Delegate GetSetAudioAttributes_Landroidx_media3_common_AudioAttributes_ZHandler ()
		{
			if (cb_setAudioAttributes_Landroidx_media3_common_AudioAttributes_Z == null)
				cb_setAudioAttributes_Landroidx_media3_common_AudioAttributes_Z = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPLZ_V) n_SetAudioAttributes_Landroidx_media3_common_AudioAttributes_Z);
			return cb_setAudioAttributes_Landroidx_media3_common_AudioAttributes_Z;
		}

		static void n_SetAudioAttributes_Landroidx_media3_common_AudioAttributes_Z (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.Common.AudioAttributes> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetAudioAttributes (p0, p1);
		}
#pragma warning restore 0169

		IntPtr id_setAudioAttributes_Landroidx_media3_common_AudioAttributes_Z;
		public unsafe void SetAudioAttributes (global::AndroidX.Media3.Common.AudioAttributes? p0, bool p1)
		{
			if (id_setAudioAttributes_Landroidx_media3_common_AudioAttributes_Z == IntPtr.Zero)
				id_setAudioAttributes_Landroidx_media3_common_AudioAttributes_Z = JNIEnv.GetMethodID (class_ref, "setAudioAttributes", "(Landroidx/media3/common/AudioAttributes;Z)V");
			JValue* __args = stackalloc JValue [2];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			__args [1] = new JValue (p1);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setAudioAttributes_Landroidx_media3_common_AudioAttributes_Z, __args);
		}

		static Delegate? cb_setAuxEffectInfo_Landroidx_media3_common_AuxEffectInfo_;
#pragma warning disable 0169
		static Delegate GetSetAuxEffectInfo_Landroidx_media3_common_AuxEffectInfo_Handler ()
		{
			if (cb_setAuxEffectInfo_Landroidx_media3_common_AuxEffectInfo_ == null)
				cb_setAuxEffectInfo_Landroidx_media3_common_AuxEffectInfo_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_SetAuxEffectInfo_Landroidx_media3_common_AuxEffectInfo_);
			return cb_setAuxEffectInfo_Landroidx_media3_common_AuxEffectInfo_;
		}

		static void n_SetAuxEffectInfo_Landroidx_media3_common_AuxEffectInfo_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.Common.AuxEffectInfo> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetAuxEffectInfo (p0);
		}
#pragma warning restore 0169

		IntPtr id_setAuxEffectInfo_Landroidx_media3_common_AuxEffectInfo_;
		public unsafe void SetAuxEffectInfo (global::AndroidX.Media3.Common.AuxEffectInfo? p0)
		{
			if (id_setAuxEffectInfo_Landroidx_media3_common_AuxEffectInfo_ == IntPtr.Zero)
				id_setAuxEffectInfo_Landroidx_media3_common_AuxEffectInfo_ = JNIEnv.GetMethodID (class_ref, "setAuxEffectInfo", "(Landroidx/media3/common/AuxEffectInfo;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setAuxEffectInfo_Landroidx_media3_common_AuxEffectInfo_, __args);
		}

		static Delegate? cb_setCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_;
#pragma warning disable 0169
		static Delegate GetSetCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_Handler ()
		{
			if (cb_setCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_ == null)
				cb_setCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_SetCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_);
			return cb_setCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_;
		}

		static void n_SetCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = (global::AndroidX.Media3.ExoPlayer.Video.Spherical.ICameraMotionListener?)global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.Video.Spherical.ICameraMotionListener> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetCameraMotionListener (p0);
		}
#pragma warning restore 0169

		IntPtr id_setCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_;
		public unsafe void SetCameraMotionListener (global::AndroidX.Media3.ExoPlayer.Video.Spherical.ICameraMotionListener? p0)
		{
			if (id_setCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_ == IntPtr.Zero)
				id_setCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_ = JNIEnv.GetMethodID (class_ref, "setCameraMotionListener", "(Landroidx/media3/exoplayer/video/spherical/CameraMotionListener;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setCameraMotionListener_Landroidx_media3_exoplayer_video_spherical_CameraMotionListener_, __args);
		}

		static Delegate? cb_setForegroundMode_Z;
#pragma warning disable 0169
		static Delegate GetSetForegroundMode_ZHandler ()
		{
			if (cb_setForegroundMode_Z == null)
				cb_setForegroundMode_Z = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPZ_V) n_SetForegroundMode_Z);
			return cb_setForegroundMode_Z;
		}

		static void n_SetForegroundMode_Z (IntPtr jnienv, IntPtr native__this, bool p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.SetForegroundMode (p0);
		}
#pragma warning restore 0169

		IntPtr id_setForegroundMode_Z;
		public unsafe void SetForegroundMode (bool p0)
		{
			if (id_setForegroundMode_Z == IntPtr.Zero)
				id_setForegroundMode_Z = JNIEnv.GetMethodID (class_ref, "setForegroundMode", "(Z)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setForegroundMode_Z, __args);
		}

		static Delegate? cb_setHandleAudioBecomingNoisy_Z;
#pragma warning disable 0169
		static Delegate GetSetHandleAudioBecomingNoisy_ZHandler ()
		{
			if (cb_setHandleAudioBecomingNoisy_Z == null)
				cb_setHandleAudioBecomingNoisy_Z = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPZ_V) n_SetHandleAudioBecomingNoisy_Z);
			return cb_setHandleAudioBecomingNoisy_Z;
		}

		static void n_SetHandleAudioBecomingNoisy_Z (IntPtr jnienv, IntPtr native__this, bool p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.SetHandleAudioBecomingNoisy (p0);
		}
#pragma warning restore 0169

		IntPtr id_setHandleAudioBecomingNoisy_Z;
		public unsafe void SetHandleAudioBecomingNoisy (bool p0)
		{
			if (id_setHandleAudioBecomingNoisy_Z == IntPtr.Zero)
				id_setHandleAudioBecomingNoisy_Z = JNIEnv.GetMethodID (class_ref, "setHandleAudioBecomingNoisy", "(Z)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setHandleAudioBecomingNoisy_Z, __args);
		}

		static Delegate? cb_setHandleWakeLock_Z;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetSetHandleWakeLock_ZHandler ()
		{
			if (cb_setHandleWakeLock_Z == null)
				cb_setHandleWakeLock_Z = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPZ_V) n_SetHandleWakeLock_Z);
			return cb_setHandleWakeLock_Z;
		}

		[Obsolete]
		static void n_SetHandleWakeLock_Z (IntPtr jnienv, IntPtr native__this, bool p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.SetHandleWakeLock (p0);
		}
#pragma warning restore 0169

		IntPtr id_setHandleWakeLock_Z;
		public unsafe void SetHandleWakeLock (bool p0)
		{
			if (id_setHandleWakeLock_Z == IntPtr.Zero)
				id_setHandleWakeLock_Z = JNIEnv.GetMethodID (class_ref, "setHandleWakeLock", "(Z)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setHandleWakeLock_Z, __args);
		}

		static Delegate? cb_setMediaSource_Landroidx_media3_exoplayer_source_MediaSource_;
#pragma warning disable 0169
		static Delegate GetSetMediaSource_Landroidx_media3_exoplayer_source_MediaSource_Handler ()
		{
			if (cb_setMediaSource_Landroidx_media3_exoplayer_source_MediaSource_ == null)
				cb_setMediaSource_Landroidx_media3_exoplayer_source_MediaSource_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_SetMediaSource_Landroidx_media3_exoplayer_source_MediaSource_);
			return cb_setMediaSource_Landroidx_media3_exoplayer_source_MediaSource_;
		}

		static void n_SetMediaSource_Landroidx_media3_exoplayer_source_MediaSource_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = (global::AndroidX.Media3.ExoPlayer.Source.IMediaSource?)global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.Source.IMediaSource> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetMediaSource (p0);
		}
#pragma warning restore 0169

		IntPtr id_setMediaSource_Landroidx_media3_exoplayer_source_MediaSource_;
		public unsafe void SetMediaSource (global::AndroidX.Media3.ExoPlayer.Source.IMediaSource? p0)
		{
			if (id_setMediaSource_Landroidx_media3_exoplayer_source_MediaSource_ == IntPtr.Zero)
				id_setMediaSource_Landroidx_media3_exoplayer_source_MediaSource_ = JNIEnv.GetMethodID (class_ref, "setMediaSource", "(Landroidx/media3/exoplayer/source/MediaSource;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setMediaSource_Landroidx_media3_exoplayer_source_MediaSource_, __args);
		}

		static Delegate? cb_setMediaSource_Landroidx_media3_exoplayer_source_MediaSource_Z;
#pragma warning disable 0169
		static Delegate GetSetMediaSource_Landroidx_media3_exoplayer_source_MediaSource_ZHandler ()
		{
			if (cb_setMediaSource_Landroidx_media3_exoplayer_source_MediaSource_Z == null)
				cb_setMediaSource_Landroidx_media3_exoplayer_source_MediaSource_Z = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPLZ_V) n_SetMediaSource_Landroidx_media3_exoplayer_source_MediaSource_Z);
			return cb_setMediaSource_Landroidx_media3_exoplayer_source_MediaSource_Z;
		}

		static void n_SetMediaSource_Landroidx_media3_exoplayer_source_MediaSource_Z (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = (global::AndroidX.Media3.ExoPlayer.Source.IMediaSource?)global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.Source.IMediaSource> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetMediaSource (p0, p1);
		}
#pragma warning restore 0169

		IntPtr id_setMediaSource_Landroidx_media3_exoplayer_source_MediaSource_Z;
		public unsafe void SetMediaSource (global::AndroidX.Media3.ExoPlayer.Source.IMediaSource? p0, bool p1)
		{
			if (id_setMediaSource_Landroidx_media3_exoplayer_source_MediaSource_Z == IntPtr.Zero)
				id_setMediaSource_Landroidx_media3_exoplayer_source_MediaSource_Z = JNIEnv.GetMethodID (class_ref, "setMediaSource", "(Landroidx/media3/exoplayer/source/MediaSource;Z)V");
			JValue* __args = stackalloc JValue [2];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			__args [1] = new JValue (p1);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setMediaSource_Landroidx_media3_exoplayer_source_MediaSource_Z, __args);
		}

		static Delegate? cb_setMediaSource_Landroidx_media3_exoplayer_source_MediaSource_J;
#pragma warning disable 0169
		static Delegate GetSetMediaSource_Landroidx_media3_exoplayer_source_MediaSource_JHandler ()
		{
			if (cb_setMediaSource_Landroidx_media3_exoplayer_source_MediaSource_J == null)
				cb_setMediaSource_Landroidx_media3_exoplayer_source_MediaSource_J = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPLJ_V) n_SetMediaSource_Landroidx_media3_exoplayer_source_MediaSource_J);
			return cb_setMediaSource_Landroidx_media3_exoplayer_source_MediaSource_J;
		}

		static void n_SetMediaSource_Landroidx_media3_exoplayer_source_MediaSource_J (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, long p1)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = (global::AndroidX.Media3.ExoPlayer.Source.IMediaSource?)global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.Source.IMediaSource> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetMediaSource (p0, p1);
		}
#pragma warning restore 0169

		IntPtr id_setMediaSource_Landroidx_media3_exoplayer_source_MediaSource_J;
		public unsafe void SetMediaSource (global::AndroidX.Media3.ExoPlayer.Source.IMediaSource? p0, long p1)
		{
			if (id_setMediaSource_Landroidx_media3_exoplayer_source_MediaSource_J == IntPtr.Zero)
				id_setMediaSource_Landroidx_media3_exoplayer_source_MediaSource_J = JNIEnv.GetMethodID (class_ref, "setMediaSource", "(Landroidx/media3/exoplayer/source/MediaSource;J)V");
			JValue* __args = stackalloc JValue [2];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			__args [1] = new JValue (p1);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setMediaSource_Landroidx_media3_exoplayer_source_MediaSource_J, __args);
		}

		static Delegate? cb_setMediaSources_Ljava_util_List_;
#pragma warning disable 0169
		static Delegate GetSetMediaSources_Ljava_util_List_Handler ()
		{
			if (cb_setMediaSources_Ljava_util_List_ == null)
				cb_setMediaSources_Ljava_util_List_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_SetMediaSources_Ljava_util_List_);
			return cb_setMediaSources_Ljava_util_List_;
		}

		static void n_SetMediaSources_Ljava_util_List_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = global::Android.Runtime.JavaList<global::AndroidX.Media3.ExoPlayer.Source.IMediaSource>.FromJniHandle (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetMediaSources (p0);
		}
#pragma warning restore 0169

		IntPtr id_setMediaSources_Ljava_util_List_;
		public unsafe void SetMediaSources (global::System.Collections.Generic.IList<global::AndroidX.Media3.ExoPlayer.Source.IMediaSource>? p0)
		{
			if (id_setMediaSources_Ljava_util_List_ == IntPtr.Zero)
				id_setMediaSources_Ljava_util_List_ = JNIEnv.GetMethodID (class_ref, "setMediaSources", "(Ljava/util/List;)V");
			IntPtr native_p0 = global::Android.Runtime.JavaList<global::AndroidX.Media3.ExoPlayer.Source.IMediaSource>.ToLocalJniHandle (p0);
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (native_p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setMediaSources_Ljava_util_List_, __args);
			JNIEnv.DeleteLocalRef (native_p0);
		}

		static Delegate? cb_setMediaSources_Ljava_util_List_Z;
#pragma warning disable 0169
		static Delegate GetSetMediaSources_Ljava_util_List_ZHandler ()
		{
			if (cb_setMediaSources_Ljava_util_List_Z == null)
				cb_setMediaSources_Ljava_util_List_Z = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPLZ_V) n_SetMediaSources_Ljava_util_List_Z);
			return cb_setMediaSources_Ljava_util_List_Z;
		}

		static void n_SetMediaSources_Ljava_util_List_Z (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = global::Android.Runtime.JavaList<global::AndroidX.Media3.ExoPlayer.Source.IMediaSource>.FromJniHandle (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetMediaSources (p0, p1);
		}
#pragma warning restore 0169

		IntPtr id_setMediaSources_Ljava_util_List_Z;
		public unsafe void SetMediaSources (global::System.Collections.Generic.IList<global::AndroidX.Media3.ExoPlayer.Source.IMediaSource>? p0, bool p1)
		{
			if (id_setMediaSources_Ljava_util_List_Z == IntPtr.Zero)
				id_setMediaSources_Ljava_util_List_Z = JNIEnv.GetMethodID (class_ref, "setMediaSources", "(Ljava/util/List;Z)V");
			IntPtr native_p0 = global::Android.Runtime.JavaList<global::AndroidX.Media3.ExoPlayer.Source.IMediaSource>.ToLocalJniHandle (p0);
			JValue* __args = stackalloc JValue [2];
			__args [0] = new JValue (native_p0);
			__args [1] = new JValue (p1);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setMediaSources_Ljava_util_List_Z, __args);
			JNIEnv.DeleteLocalRef (native_p0);
		}

		static Delegate? cb_setMediaSources_Ljava_util_List_IJ;
#pragma warning disable 0169
		static Delegate GetSetMediaSources_Ljava_util_List_IJHandler ()
		{
			if (cb_setMediaSources_Ljava_util_List_IJ == null)
				cb_setMediaSources_Ljava_util_List_IJ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPLIJ_V) n_SetMediaSources_Ljava_util_List_IJ);
			return cb_setMediaSources_Ljava_util_List_IJ;
		}

		static void n_SetMediaSources_Ljava_util_List_IJ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1, long p2)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = global::Android.Runtime.JavaList<global::AndroidX.Media3.ExoPlayer.Source.IMediaSource>.FromJniHandle (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetMediaSources (p0, p1, p2);
		}
#pragma warning restore 0169

		IntPtr id_setMediaSources_Ljava_util_List_IJ;
		public unsafe void SetMediaSources (global::System.Collections.Generic.IList<global::AndroidX.Media3.ExoPlayer.Source.IMediaSource>? p0, int p1, long p2)
		{
			if (id_setMediaSources_Ljava_util_List_IJ == IntPtr.Zero)
				id_setMediaSources_Ljava_util_List_IJ = JNIEnv.GetMethodID (class_ref, "setMediaSources", "(Ljava/util/List;IJ)V");
			IntPtr native_p0 = global::Android.Runtime.JavaList<global::AndroidX.Media3.ExoPlayer.Source.IMediaSource>.ToLocalJniHandle (p0);
			JValue* __args = stackalloc JValue [3];
			__args [0] = new JValue (native_p0);
			__args [1] = new JValue (p1);
			__args [2] = new JValue (p2);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setMediaSources_Ljava_util_List_IJ, __args);
			JNIEnv.DeleteLocalRef (native_p0);
		}

		static Delegate? cb_setPreferredAudioDevice_Landroid_media_AudioDeviceInfo_;
#pragma warning disable 0169
		static Delegate GetSetPreferredAudioDevice_Landroid_media_AudioDeviceInfo_Handler ()
		{
			if (cb_setPreferredAudioDevice_Landroid_media_AudioDeviceInfo_ == null)
				cb_setPreferredAudioDevice_Landroid_media_AudioDeviceInfo_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_SetPreferredAudioDevice_Landroid_media_AudioDeviceInfo_);
			return cb_setPreferredAudioDevice_Landroid_media_AudioDeviceInfo_;
		}

		static void n_SetPreferredAudioDevice_Landroid_media_AudioDeviceInfo_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = global::Java.Lang.Object.GetObject<global::Android.Media.AudioDeviceInfo> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetPreferredAudioDevice (p0);
		}
#pragma warning restore 0169

		IntPtr id_setPreferredAudioDevice_Landroid_media_AudioDeviceInfo_;
		public unsafe void SetPreferredAudioDevice (global::Android.Media.AudioDeviceInfo? p0)
		{
			if (id_setPreferredAudioDevice_Landroid_media_AudioDeviceInfo_ == IntPtr.Zero)
				id_setPreferredAudioDevice_Landroid_media_AudioDeviceInfo_ = JNIEnv.GetMethodID (class_ref, "setPreferredAudioDevice", "(Landroid/media/AudioDeviceInfo;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setPreferredAudioDevice_Landroid_media_AudioDeviceInfo_, __args);
		}

		static Delegate? cb_setPriorityTaskManager_Landroidx_media3_common_PriorityTaskManager_;
#pragma warning disable 0169
		static Delegate GetSetPriorityTaskManager_Landroidx_media3_common_PriorityTaskManager_Handler ()
		{
			if (cb_setPriorityTaskManager_Landroidx_media3_common_PriorityTaskManager_ == null)
				cb_setPriorityTaskManager_Landroidx_media3_common_PriorityTaskManager_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_SetPriorityTaskManager_Landroidx_media3_common_PriorityTaskManager_);
			return cb_setPriorityTaskManager_Landroidx_media3_common_PriorityTaskManager_;
		}

		static void n_SetPriorityTaskManager_Landroidx_media3_common_PriorityTaskManager_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.Common.PriorityTaskManager> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetPriorityTaskManager (p0);
		}
#pragma warning restore 0169

		IntPtr id_setPriorityTaskManager_Landroidx_media3_common_PriorityTaskManager_;
		public unsafe void SetPriorityTaskManager (global::AndroidX.Media3.Common.PriorityTaskManager? p0)
		{
			if (id_setPriorityTaskManager_Landroidx_media3_common_PriorityTaskManager_ == IntPtr.Zero)
				id_setPriorityTaskManager_Landroidx_media3_common_PriorityTaskManager_ = JNIEnv.GetMethodID (class_ref, "setPriorityTaskManager", "(Landroidx/media3/common/PriorityTaskManager;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setPriorityTaskManager_Landroidx_media3_common_PriorityTaskManager_, __args);
		}

		static Delegate? cb_setShuffleOrder_Landroidx_media3_exoplayer_source_ShuffleOrder_;
#pragma warning disable 0169
		static Delegate GetSetShuffleOrder_Landroidx_media3_exoplayer_source_ShuffleOrder_Handler ()
		{
			if (cb_setShuffleOrder_Landroidx_media3_exoplayer_source_ShuffleOrder_ == null)
				cb_setShuffleOrder_Landroidx_media3_exoplayer_source_ShuffleOrder_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_SetShuffleOrder_Landroidx_media3_exoplayer_source_ShuffleOrder_);
			return cb_setShuffleOrder_Landroidx_media3_exoplayer_source_ShuffleOrder_;
		}

		static void n_SetShuffleOrder_Landroidx_media3_exoplayer_source_ShuffleOrder_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = (global::AndroidX.Media3.ExoPlayer.Source.IShuffleOrder?)global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.Source.IShuffleOrder> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetShuffleOrder (p0);
		}
#pragma warning restore 0169

		IntPtr id_setShuffleOrder_Landroidx_media3_exoplayer_source_ShuffleOrder_;
		public unsafe void SetShuffleOrder (global::AndroidX.Media3.ExoPlayer.Source.IShuffleOrder? p0)
		{
			if (id_setShuffleOrder_Landroidx_media3_exoplayer_source_ShuffleOrder_ == IntPtr.Zero)
				id_setShuffleOrder_Landroidx_media3_exoplayer_source_ShuffleOrder_ = JNIEnv.GetMethodID (class_ref, "setShuffleOrder", "(Landroidx/media3/exoplayer/source/ShuffleOrder;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setShuffleOrder_Landroidx_media3_exoplayer_source_ShuffleOrder_, __args);
		}

		static Delegate? cb_setVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_;
#pragma warning disable 0169
		static Delegate GetSetVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_Handler ()
		{
			if (cb_setVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_ == null)
				cb_setVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_SetVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_);
			return cb_setVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_;
		}

		static void n_SetVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = (global::AndroidX.Media3.ExoPlayer.Video.IVideoFrameMetadataListener?)global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.Video.IVideoFrameMetadataListener> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetVideoFrameMetadataListener (p0);
		}
#pragma warning restore 0169

		IntPtr id_setVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_;
		public unsafe void SetVideoFrameMetadataListener (global::AndroidX.Media3.ExoPlayer.Video.IVideoFrameMetadataListener? p0)
		{
			if (id_setVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_ == IntPtr.Zero)
				id_setVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_ = JNIEnv.GetMethodID (class_ref, "setVideoFrameMetadataListener", "(Landroidx/media3/exoplayer/video/VideoFrameMetadataListener;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setVideoFrameMetadataListener_Landroidx_media3_exoplayer_video_VideoFrameMetadataListener_, __args);
		}

		static Delegate? cb_setWakeMode_I;
#pragma warning disable 0169
		static Delegate GetSetWakeMode_IHandler ()
		{
			if (cb_setWakeMode_I == null)
				cb_setWakeMode_I = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPI_V) n_SetWakeMode_I);
			return cb_setWakeMode_I;
		}

		static void n_SetWakeMode_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.SetWakeMode (p0);
		}
#pragma warning restore 0169

		IntPtr id_setWakeMode_I;
		public unsafe void SetWakeMode (int p0)
		{
			if (id_setWakeMode_I == IntPtr.Zero)
				id_setWakeMode_I = JNIEnv.GetMethodID (class_ref, "setWakeMode", "(I)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setWakeMode_I, __args);
		}

		static Delegate? cb_getApplicationLooper;
#pragma warning disable 0169
		static Delegate GetGetApplicationLooperHandler ()
		{
			if (cb_getApplicationLooper == null)
				cb_getApplicationLooper = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_L) n_GetApplicationLooper);
			return cb_getApplicationLooper;
		}

		static IntPtr n_GetApplicationLooper (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return JNIEnv.ToLocalJniHandle (__this.ApplicationLooper);
		}
#pragma warning restore 0169

		IntPtr id_getApplicationLooper;
		public unsafe global::Android.OS.Looper? ApplicationLooper {
			get {
				if (id_getApplicationLooper == IntPtr.Zero)
					id_getApplicationLooper = JNIEnv.GetMethodID (class_ref, "getApplicationLooper", "()Landroid/os/Looper;");
				return global::Java.Lang.Object.GetObject<global::Android.OS.Looper> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getApplicationLooper), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate? cb_getAudioAttributes;
#pragma warning disable 0169
		static Delegate GetGetAudioAttributesHandler ()
		{
			if (cb_getAudioAttributes == null)
				cb_getAudioAttributes = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_L) n_GetAudioAttributes);
			return cb_getAudioAttributes;
		}

		static IntPtr n_GetAudioAttributes (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return JNIEnv.ToLocalJniHandle (__this.AudioAttributes);
		}
#pragma warning restore 0169

		IntPtr id_getAudioAttributes;
		public unsafe global::AndroidX.Media3.Common.AudioAttributes? AudioAttributes {
			get {
				if (id_getAudioAttributes == IntPtr.Zero)
					id_getAudioAttributes = JNIEnv.GetMethodID (class_ref, "getAudioAttributes", "()Landroidx/media3/common/AudioAttributes;");
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.Common.AudioAttributes> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getAudioAttributes), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate? cb_getAvailableCommands;
#pragma warning disable 0169
		static Delegate GetGetAvailableCommandsHandler ()
		{
			if (cb_getAvailableCommands == null)
				cb_getAvailableCommands = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_L) n_GetAvailableCommands);
			return cb_getAvailableCommands;
		}

		static IntPtr n_GetAvailableCommands (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return JNIEnv.ToLocalJniHandle (__this.AvailableCommands);
		}
#pragma warning restore 0169

		IntPtr id_getAvailableCommands;
		public unsafe global::AndroidX.Media3.Common.PlayerCommands? AvailableCommands {
			get {
				if (id_getAvailableCommands == IntPtr.Zero)
					id_getAvailableCommands = JNIEnv.GetMethodID (class_ref, "getAvailableCommands", "()Landroidx/media3/common/Player$Commands;");
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.Common.PlayerCommands> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getAvailableCommands), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate? cb_getBufferedPercentage;
#pragma warning disable 0169
		static Delegate GetGetBufferedPercentageHandler ()
		{
			if (cb_getBufferedPercentage == null)
				cb_getBufferedPercentage = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_I) n_GetBufferedPercentage);
			return cb_getBufferedPercentage;
		}

		static int n_GetBufferedPercentage (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.BufferedPercentage;
		}
#pragma warning restore 0169

		IntPtr id_getBufferedPercentage;
		public unsafe int BufferedPercentage {
			get {
				if (id_getBufferedPercentage == IntPtr.Zero)
					id_getBufferedPercentage = JNIEnv.GetMethodID (class_ref, "getBufferedPercentage", "()I");
				return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getBufferedPercentage);
			}
		}

		static Delegate? cb_getBufferedPosition;
#pragma warning disable 0169
		static Delegate GetGetBufferedPositionHandler ()
		{
			if (cb_getBufferedPosition == null)
				cb_getBufferedPosition = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_J) n_GetBufferedPosition);
			return cb_getBufferedPosition;
		}

		static long n_GetBufferedPosition (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.BufferedPosition;
		}
#pragma warning restore 0169

		IntPtr id_getBufferedPosition;
		public unsafe long BufferedPosition {
			get {
				if (id_getBufferedPosition == IntPtr.Zero)
					id_getBufferedPosition = JNIEnv.GetMethodID (class_ref, "getBufferedPosition", "()J");
				return JNIEnv.CallLongMethod (((global::Java.Lang.Object) this).Handle, id_getBufferedPosition);
			}
		}

		static Delegate? cb_getContentBufferedPosition;
#pragma warning disable 0169
		static Delegate GetGetContentBufferedPositionHandler ()
		{
			if (cb_getContentBufferedPosition == null)
				cb_getContentBufferedPosition = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_J) n_GetContentBufferedPosition);
			return cb_getContentBufferedPosition;
		}

		static long n_GetContentBufferedPosition (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.ContentBufferedPosition;
		}
#pragma warning restore 0169

		IntPtr id_getContentBufferedPosition;
		public unsafe long ContentBufferedPosition {
			get {
				if (id_getContentBufferedPosition == IntPtr.Zero)
					id_getContentBufferedPosition = JNIEnv.GetMethodID (class_ref, "getContentBufferedPosition", "()J");
				return JNIEnv.CallLongMethod (((global::Java.Lang.Object) this).Handle, id_getContentBufferedPosition);
			}
		}

		static Delegate? cb_getContentDuration;
#pragma warning disable 0169
		static Delegate GetGetContentDurationHandler ()
		{
			if (cb_getContentDuration == null)
				cb_getContentDuration = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_J) n_GetContentDuration);
			return cb_getContentDuration;
		}

		static long n_GetContentDuration (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.ContentDuration;
		}
#pragma warning restore 0169

		IntPtr id_getContentDuration;
		public unsafe long ContentDuration {
			get {
				if (id_getContentDuration == IntPtr.Zero)
					id_getContentDuration = JNIEnv.GetMethodID (class_ref, "getContentDuration", "()J");
				return JNIEnv.CallLongMethod (((global::Java.Lang.Object) this).Handle, id_getContentDuration);
			}
		}

		static Delegate? cb_getContentPosition;
#pragma warning disable 0169
		static Delegate GetGetContentPositionHandler ()
		{
			if (cb_getContentPosition == null)
				cb_getContentPosition = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_J) n_GetContentPosition);
			return cb_getContentPosition;
		}

		static long n_GetContentPosition (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.ContentPosition;
		}
#pragma warning restore 0169

		IntPtr id_getContentPosition;
		public unsafe long ContentPosition {
			get {
				if (id_getContentPosition == IntPtr.Zero)
					id_getContentPosition = JNIEnv.GetMethodID (class_ref, "getContentPosition", "()J");
				return JNIEnv.CallLongMethod (((global::Java.Lang.Object) this).Handle, id_getContentPosition);
			}
		}

		static Delegate? cb_getCurrentAdGroupIndex;
#pragma warning disable 0169
		static Delegate GetGetCurrentAdGroupIndexHandler ()
		{
			if (cb_getCurrentAdGroupIndex == null)
				cb_getCurrentAdGroupIndex = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_I) n_GetCurrentAdGroupIndex);
			return cb_getCurrentAdGroupIndex;
		}

		static int n_GetCurrentAdGroupIndex (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.CurrentAdGroupIndex;
		}
#pragma warning restore 0169

		IntPtr id_getCurrentAdGroupIndex;
		public unsafe int CurrentAdGroupIndex {
			get {
				if (id_getCurrentAdGroupIndex == IntPtr.Zero)
					id_getCurrentAdGroupIndex = JNIEnv.GetMethodID (class_ref, "getCurrentAdGroupIndex", "()I");
				return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getCurrentAdGroupIndex);
			}
		}

		static Delegate? cb_getCurrentAdIndexInAdGroup;
#pragma warning disable 0169
		static Delegate GetGetCurrentAdIndexInAdGroupHandler ()
		{
			if (cb_getCurrentAdIndexInAdGroup == null)
				cb_getCurrentAdIndexInAdGroup = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_I) n_GetCurrentAdIndexInAdGroup);
			return cb_getCurrentAdIndexInAdGroup;
		}

		static int n_GetCurrentAdIndexInAdGroup (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.CurrentAdIndexInAdGroup;
		}
#pragma warning restore 0169

		IntPtr id_getCurrentAdIndexInAdGroup;
		public unsafe int CurrentAdIndexInAdGroup {
			get {
				if (id_getCurrentAdIndexInAdGroup == IntPtr.Zero)
					id_getCurrentAdIndexInAdGroup = JNIEnv.GetMethodID (class_ref, "getCurrentAdIndexInAdGroup", "()I");
				return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getCurrentAdIndexInAdGroup);
			}
		}

		static Delegate? cb_getCurrentCues;
#pragma warning disable 0169
		static Delegate GetGetCurrentCuesHandler ()
		{
			if (cb_getCurrentCues == null)
				cb_getCurrentCues = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_L) n_GetCurrentCues);
			return cb_getCurrentCues;
		}

		static IntPtr n_GetCurrentCues (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return JNIEnv.ToLocalJniHandle (__this.CurrentCues);
		}
#pragma warning restore 0169

		IntPtr id_getCurrentCues;
		public unsafe global::AndroidX.Media3.Common.Text.CueGroup? CurrentCues {
			get {
				if (id_getCurrentCues == IntPtr.Zero)
					id_getCurrentCues = JNIEnv.GetMethodID (class_ref, "getCurrentCues", "()Landroidx/media3/common/text/CueGroup;");
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.Common.Text.CueGroup> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getCurrentCues), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate? cb_getCurrentLiveOffset;
#pragma warning disable 0169
		static Delegate GetGetCurrentLiveOffsetHandler ()
		{
			if (cb_getCurrentLiveOffset == null)
				cb_getCurrentLiveOffset = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_J) n_GetCurrentLiveOffset);
			return cb_getCurrentLiveOffset;
		}

		static long n_GetCurrentLiveOffset (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.CurrentLiveOffset;
		}
#pragma warning restore 0169

		IntPtr id_getCurrentLiveOffset;
		public unsafe long CurrentLiveOffset {
			get {
				if (id_getCurrentLiveOffset == IntPtr.Zero)
					id_getCurrentLiveOffset = JNIEnv.GetMethodID (class_ref, "getCurrentLiveOffset", "()J");
				return JNIEnv.CallLongMethod (((global::Java.Lang.Object) this).Handle, id_getCurrentLiveOffset);
			}
		}

		static Delegate? cb_getCurrentManifest;
#pragma warning disable 0169
		static Delegate GetGetCurrentManifestHandler ()
		{
			if (cb_getCurrentManifest == null)
				cb_getCurrentManifest = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_L) n_GetCurrentManifest);
			return cb_getCurrentManifest;
		}

		static IntPtr n_GetCurrentManifest (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return JNIEnv.ToLocalJniHandle (__this.CurrentManifest);
		}
#pragma warning restore 0169

		IntPtr id_getCurrentManifest;
		public unsafe global::Java.Lang.Object? CurrentManifest {
			get {
				if (id_getCurrentManifest == IntPtr.Zero)
					id_getCurrentManifest = JNIEnv.GetMethodID (class_ref, "getCurrentManifest", "()Ljava/lang/Object;");
				return global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getCurrentManifest), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate? cb_getCurrentMediaItem;
#pragma warning disable 0169
		static Delegate GetGetCurrentMediaItemHandler ()
		{
			if (cb_getCurrentMediaItem == null)
				cb_getCurrentMediaItem = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_L) n_GetCurrentMediaItem);
			return cb_getCurrentMediaItem;
		}

		static IntPtr n_GetCurrentMediaItem (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return JNIEnv.ToLocalJniHandle (__this.CurrentMediaItem);
		}
#pragma warning restore 0169

		IntPtr id_getCurrentMediaItem;
		public unsafe global::AndroidX.Media3.Common.MediaItem? CurrentMediaItem {
			get {
				if (id_getCurrentMediaItem == IntPtr.Zero)
					id_getCurrentMediaItem = JNIEnv.GetMethodID (class_ref, "getCurrentMediaItem", "()Landroidx/media3/common/MediaItem;");
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.Common.MediaItem> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getCurrentMediaItem), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate? cb_getCurrentMediaItemIndex;
#pragma warning disable 0169
		static Delegate GetGetCurrentMediaItemIndexHandler ()
		{
			if (cb_getCurrentMediaItemIndex == null)
				cb_getCurrentMediaItemIndex = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_I) n_GetCurrentMediaItemIndex);
			return cb_getCurrentMediaItemIndex;
		}

		static int n_GetCurrentMediaItemIndex (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.CurrentMediaItemIndex;
		}
#pragma warning restore 0169

		IntPtr id_getCurrentMediaItemIndex;
		public unsafe int CurrentMediaItemIndex {
			get {
				if (id_getCurrentMediaItemIndex == IntPtr.Zero)
					id_getCurrentMediaItemIndex = JNIEnv.GetMethodID (class_ref, "getCurrentMediaItemIndex", "()I");
				return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getCurrentMediaItemIndex);
			}
		}

		static Delegate? cb_getCurrentPeriodIndex;
#pragma warning disable 0169
		static Delegate GetGetCurrentPeriodIndexHandler ()
		{
			if (cb_getCurrentPeriodIndex == null)
				cb_getCurrentPeriodIndex = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_I) n_GetCurrentPeriodIndex);
			return cb_getCurrentPeriodIndex;
		}

		static int n_GetCurrentPeriodIndex (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.CurrentPeriodIndex;
		}
#pragma warning restore 0169

		IntPtr id_getCurrentPeriodIndex;
		public unsafe int CurrentPeriodIndex {
			get {
				if (id_getCurrentPeriodIndex == IntPtr.Zero)
					id_getCurrentPeriodIndex = JNIEnv.GetMethodID (class_ref, "getCurrentPeriodIndex", "()I");
				return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getCurrentPeriodIndex);
			}
		}

		static Delegate? cb_getCurrentPosition;
#pragma warning disable 0169
		static Delegate GetGetCurrentPositionHandler ()
		{
			if (cb_getCurrentPosition == null)
				cb_getCurrentPosition = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_J) n_GetCurrentPosition);
			return cb_getCurrentPosition;
		}

		static long n_GetCurrentPosition (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.CurrentPosition;
		}
#pragma warning restore 0169

		IntPtr id_getCurrentPosition;
		public unsafe long CurrentPosition {
			get {
				if (id_getCurrentPosition == IntPtr.Zero)
					id_getCurrentPosition = JNIEnv.GetMethodID (class_ref, "getCurrentPosition", "()J");
				return JNIEnv.CallLongMethod (((global::Java.Lang.Object) this).Handle, id_getCurrentPosition);
			}
		}

		static Delegate? cb_getCurrentTimeline;
#pragma warning disable 0169
		static Delegate GetGetCurrentTimelineHandler ()
		{
			if (cb_getCurrentTimeline == null)
				cb_getCurrentTimeline = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_L) n_GetCurrentTimeline);
			return cb_getCurrentTimeline;
		}

		static IntPtr n_GetCurrentTimeline (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return JNIEnv.ToLocalJniHandle (__this.CurrentTimeline);
		}
#pragma warning restore 0169

		IntPtr id_getCurrentTimeline;
		public unsafe global::AndroidX.Media3.Common.Timeline? CurrentTimeline {
			get {
				if (id_getCurrentTimeline == IntPtr.Zero)
					id_getCurrentTimeline = JNIEnv.GetMethodID (class_ref, "getCurrentTimeline", "()Landroidx/media3/common/Timeline;");
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.Common.Timeline> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getCurrentTimeline), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate? cb_getCurrentTracks;
#pragma warning disable 0169
		static Delegate GetGetCurrentTracksHandler ()
		{
			if (cb_getCurrentTracks == null)
				cb_getCurrentTracks = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_L) n_GetCurrentTracks);
			return cb_getCurrentTracks;
		}

		static IntPtr n_GetCurrentTracks (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return JNIEnv.ToLocalJniHandle (__this.CurrentTracks);
		}
#pragma warning restore 0169

		IntPtr id_getCurrentTracks;
		public unsafe global::AndroidX.Media3.Common.Tracks? CurrentTracks {
			get {
				if (id_getCurrentTracks == IntPtr.Zero)
					id_getCurrentTracks = JNIEnv.GetMethodID (class_ref, "getCurrentTracks", "()Landroidx/media3/common/Tracks;");
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.Common.Tracks> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getCurrentTracks), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate? cb_getCurrentWindowIndex;
#pragma warning disable 0169
		static Delegate GetGetCurrentWindowIndexHandler ()
		{
			if (cb_getCurrentWindowIndex == null)
				cb_getCurrentWindowIndex = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_I) n_GetCurrentWindowIndex);
			return cb_getCurrentWindowIndex;
		}

		static int n_GetCurrentWindowIndex (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.CurrentWindowIndex;
		}
#pragma warning restore 0169

		IntPtr id_getCurrentWindowIndex;
		public unsafe int CurrentWindowIndex {
			get {
				if (id_getCurrentWindowIndex == IntPtr.Zero)
					id_getCurrentWindowIndex = JNIEnv.GetMethodID (class_ref, "getCurrentWindowIndex", "()I");
				return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getCurrentWindowIndex);
			}
		}

		static Delegate? cb_getDeviceInfo;
#pragma warning disable 0169
		static Delegate GetGetDeviceInfoHandler ()
		{
			if (cb_getDeviceInfo == null)
				cb_getDeviceInfo = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_L) n_GetDeviceInfo);
			return cb_getDeviceInfo;
		}

		static IntPtr n_GetDeviceInfo (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return JNIEnv.ToLocalJniHandle (__this.DeviceInfo);
		}
#pragma warning restore 0169

		IntPtr id_getDeviceInfo;
		public unsafe global::AndroidX.Media3.Common.DeviceInfo? DeviceInfo {
			get {
				if (id_getDeviceInfo == IntPtr.Zero)
					id_getDeviceInfo = JNIEnv.GetMethodID (class_ref, "getDeviceInfo", "()Landroidx/media3/common/DeviceInfo;");
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.Common.DeviceInfo> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getDeviceInfo), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate? cb_isDeviceMuted;
#pragma warning disable 0169
		static Delegate GetGetDeviceMutedHandler ()
		{
			if (cb_isDeviceMuted == null)
				cb_isDeviceMuted = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_Z) n_GetDeviceMuted);
			return cb_isDeviceMuted;
		}

		static bool n_GetDeviceMuted (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.DeviceMuted;
		}
#pragma warning restore 0169

		static Delegate? cb_setDeviceMuted_Z;
#pragma warning disable 0169
		static Delegate GetSetDeviceMuted_ZHandler ()
		{
			if (cb_setDeviceMuted_Z == null)
				cb_setDeviceMuted_Z = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPZ_V) n_SetDeviceMuted_Z);
			return cb_setDeviceMuted_Z;
		}

		static void n_SetDeviceMuted_Z (IntPtr jnienv, IntPtr native__this, bool value)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.DeviceMuted = value;
		}
#pragma warning restore 0169

		IntPtr id_isDeviceMuted;
		IntPtr id_setDeviceMuted_Z;
		public unsafe bool DeviceMuted {
			get {
				if (id_isDeviceMuted == IntPtr.Zero)
					id_isDeviceMuted = JNIEnv.GetMethodID (class_ref, "isDeviceMuted", "()Z");
				return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isDeviceMuted);
			}
			set {
				if (id_setDeviceMuted_Z == IntPtr.Zero)
					id_setDeviceMuted_Z = JNIEnv.GetMethodID (class_ref, "setDeviceMuted", "(Z)V");
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (value);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setDeviceMuted_Z, __args);
			}
		}

		static Delegate? cb_getDeviceVolume;
#pragma warning disable 0169
		static Delegate GetGetDeviceVolumeHandler ()
		{
			if (cb_getDeviceVolume == null)
				cb_getDeviceVolume = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_I) n_GetDeviceVolume);
			return cb_getDeviceVolume;
		}

		static int n_GetDeviceVolume (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.DeviceVolume;
		}
#pragma warning restore 0169

		static Delegate? cb_setDeviceVolume_I;
#pragma warning disable 0169
		static Delegate GetSetDeviceVolume_IHandler ()
		{
			if (cb_setDeviceVolume_I == null)
				cb_setDeviceVolume_I = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPI_V) n_SetDeviceVolume_I);
			return cb_setDeviceVolume_I;
		}

		static void n_SetDeviceVolume_I (IntPtr jnienv, IntPtr native__this, int value)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.DeviceVolume = value;
		}
#pragma warning restore 0169

		IntPtr id_getDeviceVolume;
		IntPtr id_setDeviceVolume_I;
		public unsafe int DeviceVolume {
			get {
				if (id_getDeviceVolume == IntPtr.Zero)
					id_getDeviceVolume = JNIEnv.GetMethodID (class_ref, "getDeviceVolume", "()I");
				return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getDeviceVolume);
			}
			set {
				if (id_setDeviceVolume_I == IntPtr.Zero)
					id_setDeviceVolume_I = JNIEnv.GetMethodID (class_ref, "setDeviceVolume", "(I)V");
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (value);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setDeviceVolume_I, __args);
			}
		}

		static Delegate? cb_getDuration;
#pragma warning disable 0169
		static Delegate GetGetDurationHandler ()
		{
			if (cb_getDuration == null)
				cb_getDuration = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_J) n_GetDuration);
			return cb_getDuration;
		}

		static long n_GetDuration (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.Duration;
		}
#pragma warning restore 0169

		IntPtr id_getDuration;
		public unsafe long Duration {
			get {
				if (id_getDuration == IntPtr.Zero)
					id_getDuration = JNIEnv.GetMethodID (class_ref, "getDuration", "()J");
				return JNIEnv.CallLongMethod (((global::Java.Lang.Object) this).Handle, id_getDuration);
			}
		}

		static Delegate? cb_hasNext;
#pragma warning disable 0169
		static Delegate GetGetHasNextHandler ()
		{
			if (cb_hasNext == null)
				cb_hasNext = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_Z) n_GetHasNext);
			return cb_hasNext;
		}

		static bool n_GetHasNext (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.HasNext;
		}
#pragma warning restore 0169

		IntPtr id_hasNext;
		public unsafe bool HasNext {
			get {
				if (id_hasNext == IntPtr.Zero)
					id_hasNext = JNIEnv.GetMethodID (class_ref, "hasNext", "()Z");
				return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_hasNext);
			}
		}

		static Delegate? cb_hasNextMediaItem;
#pragma warning disable 0169
		static Delegate GetGetHasNextMediaItemHandler ()
		{
			if (cb_hasNextMediaItem == null)
				cb_hasNextMediaItem = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_Z) n_GetHasNextMediaItem);
			return cb_hasNextMediaItem;
		}

		static bool n_GetHasNextMediaItem (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.HasNextMediaItem;
		}
#pragma warning restore 0169

		IntPtr id_hasNextMediaItem;
		public unsafe bool HasNextMediaItem {
			get {
				if (id_hasNextMediaItem == IntPtr.Zero)
					id_hasNextMediaItem = JNIEnv.GetMethodID (class_ref, "hasNextMediaItem", "()Z");
				return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_hasNextMediaItem);
			}
		}

		static Delegate? cb_hasNextWindow;
#pragma warning disable 0169
		static Delegate GetGetHasNextWindowHandler ()
		{
			if (cb_hasNextWindow == null)
				cb_hasNextWindow = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_Z) n_GetHasNextWindow);
			return cb_hasNextWindow;
		}

		static bool n_GetHasNextWindow (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.HasNextWindow;
		}
#pragma warning restore 0169

		IntPtr id_hasNextWindow;
		public unsafe bool HasNextWindow {
			get {
				if (id_hasNextWindow == IntPtr.Zero)
					id_hasNextWindow = JNIEnv.GetMethodID (class_ref, "hasNextWindow", "()Z");
				return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_hasNextWindow);
			}
		}

		static Delegate? cb_hasPrevious;
#pragma warning disable 0169
		static Delegate GetGetHasPreviousHandler ()
		{
			if (cb_hasPrevious == null)
				cb_hasPrevious = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_Z) n_GetHasPrevious);
			return cb_hasPrevious;
		}

		static bool n_GetHasPrevious (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.HasPrevious;
		}
#pragma warning restore 0169

		IntPtr id_hasPrevious;
		public unsafe bool HasPrevious {
			get {
				if (id_hasPrevious == IntPtr.Zero)
					id_hasPrevious = JNIEnv.GetMethodID (class_ref, "hasPrevious", "()Z");
				return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_hasPrevious);
			}
		}

		static Delegate? cb_hasPreviousMediaItem;
#pragma warning disable 0169
		static Delegate GetGetHasPreviousMediaItemHandler ()
		{
			if (cb_hasPreviousMediaItem == null)
				cb_hasPreviousMediaItem = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_Z) n_GetHasPreviousMediaItem);
			return cb_hasPreviousMediaItem;
		}

		static bool n_GetHasPreviousMediaItem (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.HasPreviousMediaItem;
		}
#pragma warning restore 0169

		IntPtr id_hasPreviousMediaItem;
		public unsafe bool HasPreviousMediaItem {
			get {
				if (id_hasPreviousMediaItem == IntPtr.Zero)
					id_hasPreviousMediaItem = JNIEnv.GetMethodID (class_ref, "hasPreviousMediaItem", "()Z");
				return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_hasPreviousMediaItem);
			}
		}

		static Delegate? cb_hasPreviousWindow;
#pragma warning disable 0169
		static Delegate GetGetHasPreviousWindowHandler ()
		{
			if (cb_hasPreviousWindow == null)
				cb_hasPreviousWindow = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_Z) n_GetHasPreviousWindow);
			return cb_hasPreviousWindow;
		}

		static bool n_GetHasPreviousWindow (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.HasPreviousWindow;
		}
#pragma warning restore 0169

		IntPtr id_hasPreviousWindow;
		public unsafe bool HasPreviousWindow {
			get {
				if (id_hasPreviousWindow == IntPtr.Zero)
					id_hasPreviousWindow = JNIEnv.GetMethodID (class_ref, "hasPreviousWindow", "()Z");
				return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_hasPreviousWindow);
			}
		}

		static Delegate? cb_isCurrentMediaItemDynamic;
#pragma warning disable 0169
		static Delegate GetIsCurrentMediaItemDynamicHandler ()
		{
			if (cb_isCurrentMediaItemDynamic == null)
				cb_isCurrentMediaItemDynamic = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_Z) n_IsCurrentMediaItemDynamic);
			return cb_isCurrentMediaItemDynamic;
		}

		static bool n_IsCurrentMediaItemDynamic (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.IsCurrentMediaItemDynamic;
		}
#pragma warning restore 0169

		IntPtr id_isCurrentMediaItemDynamic;
		public unsafe bool IsCurrentMediaItemDynamic {
			get {
				if (id_isCurrentMediaItemDynamic == IntPtr.Zero)
					id_isCurrentMediaItemDynamic = JNIEnv.GetMethodID (class_ref, "isCurrentMediaItemDynamic", "()Z");
				return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isCurrentMediaItemDynamic);
			}
		}

		static Delegate? cb_isCurrentMediaItemLive;
#pragma warning disable 0169
		static Delegate GetIsCurrentMediaItemLiveHandler ()
		{
			if (cb_isCurrentMediaItemLive == null)
				cb_isCurrentMediaItemLive = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_Z) n_IsCurrentMediaItemLive);
			return cb_isCurrentMediaItemLive;
		}

		static bool n_IsCurrentMediaItemLive (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.IsCurrentMediaItemLive;
		}
#pragma warning restore 0169

		IntPtr id_isCurrentMediaItemLive;
		public unsafe bool IsCurrentMediaItemLive {
			get {
				if (id_isCurrentMediaItemLive == IntPtr.Zero)
					id_isCurrentMediaItemLive = JNIEnv.GetMethodID (class_ref, "isCurrentMediaItemLive", "()Z");
				return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isCurrentMediaItemLive);
			}
		}

		static Delegate? cb_isCurrentMediaItemSeekable;
#pragma warning disable 0169
		static Delegate GetIsCurrentMediaItemSeekableHandler ()
		{
			if (cb_isCurrentMediaItemSeekable == null)
				cb_isCurrentMediaItemSeekable = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_Z) n_IsCurrentMediaItemSeekable);
			return cb_isCurrentMediaItemSeekable;
		}

		static bool n_IsCurrentMediaItemSeekable (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.IsCurrentMediaItemSeekable;
		}
#pragma warning restore 0169

		IntPtr id_isCurrentMediaItemSeekable;
		public unsafe bool IsCurrentMediaItemSeekable {
			get {
				if (id_isCurrentMediaItemSeekable == IntPtr.Zero)
					id_isCurrentMediaItemSeekable = JNIEnv.GetMethodID (class_ref, "isCurrentMediaItemSeekable", "()Z");
				return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isCurrentMediaItemSeekable);
			}
		}

		static Delegate? cb_isCurrentWindowDynamic;
#pragma warning disable 0169
		static Delegate GetIsCurrentWindowDynamicHandler ()
		{
			if (cb_isCurrentWindowDynamic == null)
				cb_isCurrentWindowDynamic = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_Z) n_IsCurrentWindowDynamic);
			return cb_isCurrentWindowDynamic;
		}

		static bool n_IsCurrentWindowDynamic (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.IsCurrentWindowDynamic;
		}
#pragma warning restore 0169

		IntPtr id_isCurrentWindowDynamic;
		public unsafe bool IsCurrentWindowDynamic {
			get {
				if (id_isCurrentWindowDynamic == IntPtr.Zero)
					id_isCurrentWindowDynamic = JNIEnv.GetMethodID (class_ref, "isCurrentWindowDynamic", "()Z");
				return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isCurrentWindowDynamic);
			}
		}

		static Delegate? cb_isCurrentWindowLive;
#pragma warning disable 0169
		static Delegate GetIsCurrentWindowLiveHandler ()
		{
			if (cb_isCurrentWindowLive == null)
				cb_isCurrentWindowLive = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_Z) n_IsCurrentWindowLive);
			return cb_isCurrentWindowLive;
		}

		static bool n_IsCurrentWindowLive (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.IsCurrentWindowLive;
		}
#pragma warning restore 0169

		IntPtr id_isCurrentWindowLive;
		public unsafe bool IsCurrentWindowLive {
			get {
				if (id_isCurrentWindowLive == IntPtr.Zero)
					id_isCurrentWindowLive = JNIEnv.GetMethodID (class_ref, "isCurrentWindowLive", "()Z");
				return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isCurrentWindowLive);
			}
		}

		static Delegate? cb_isCurrentWindowSeekable;
#pragma warning disable 0169
		static Delegate GetIsCurrentWindowSeekableHandler ()
		{
			if (cb_isCurrentWindowSeekable == null)
				cb_isCurrentWindowSeekable = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_Z) n_IsCurrentWindowSeekable);
			return cb_isCurrentWindowSeekable;
		}

		static bool n_IsCurrentWindowSeekable (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.IsCurrentWindowSeekable;
		}
#pragma warning restore 0169

		IntPtr id_isCurrentWindowSeekable;
		public unsafe bool IsCurrentWindowSeekable {
			get {
				if (id_isCurrentWindowSeekable == IntPtr.Zero)
					id_isCurrentWindowSeekable = JNIEnv.GetMethodID (class_ref, "isCurrentWindowSeekable", "()Z");
				return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isCurrentWindowSeekable);
			}
		}

		static Delegate? cb_isLoading;
#pragma warning disable 0169
		static Delegate GetIsLoadingHandler ()
		{
			if (cb_isLoading == null)
				cb_isLoading = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_Z) n_IsLoading);
			return cb_isLoading;
		}

		static bool n_IsLoading (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.IsLoading;
		}
#pragma warning restore 0169

		IntPtr id_isLoading;
		public unsafe bool IsLoading {
			get {
				if (id_isLoading == IntPtr.Zero)
					id_isLoading = JNIEnv.GetMethodID (class_ref, "isLoading", "()Z");
				return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isLoading);
			}
		}

		static Delegate? cb_isPlaying;
#pragma warning disable 0169
		static Delegate GetIsPlayingHandler ()
		{
			if (cb_isPlaying == null)
				cb_isPlaying = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_Z) n_IsPlaying);
			return cb_isPlaying;
		}

		static bool n_IsPlaying (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.IsPlaying;
		}
#pragma warning restore 0169

		IntPtr id_isPlaying;
		public unsafe bool IsPlaying {
			get {
				if (id_isPlaying == IntPtr.Zero)
					id_isPlaying = JNIEnv.GetMethodID (class_ref, "isPlaying", "()Z");
				return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isPlaying);
			}
		}

		static Delegate? cb_isPlayingAd;
#pragma warning disable 0169
		static Delegate GetIsPlayingAdHandler ()
		{
			if (cb_isPlayingAd == null)
				cb_isPlayingAd = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_Z) n_IsPlayingAd);
			return cb_isPlayingAd;
		}

		static bool n_IsPlayingAd (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.IsPlayingAd;
		}
#pragma warning restore 0169

		IntPtr id_isPlayingAd;
		public unsafe bool IsPlayingAd {
			get {
				if (id_isPlayingAd == IntPtr.Zero)
					id_isPlayingAd = JNIEnv.GetMethodID (class_ref, "isPlayingAd", "()Z");
				return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isPlayingAd);
			}
		}

		static Delegate? cb_getMaxSeekToPreviousPosition;
#pragma warning disable 0169
		static Delegate GetGetMaxSeekToPreviousPositionHandler ()
		{
			if (cb_getMaxSeekToPreviousPosition == null)
				cb_getMaxSeekToPreviousPosition = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_J) n_GetMaxSeekToPreviousPosition);
			return cb_getMaxSeekToPreviousPosition;
		}

		static long n_GetMaxSeekToPreviousPosition (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.MaxSeekToPreviousPosition;
		}
#pragma warning restore 0169

		IntPtr id_getMaxSeekToPreviousPosition;
		public unsafe long MaxSeekToPreviousPosition {
			get {
				if (id_getMaxSeekToPreviousPosition == IntPtr.Zero)
					id_getMaxSeekToPreviousPosition = JNIEnv.GetMethodID (class_ref, "getMaxSeekToPreviousPosition", "()J");
				return JNIEnv.CallLongMethod (((global::Java.Lang.Object) this).Handle, id_getMaxSeekToPreviousPosition);
			}
		}

		static Delegate? cb_getMediaItemCount;
#pragma warning disable 0169
		static Delegate GetGetMediaItemCountHandler ()
		{
			if (cb_getMediaItemCount == null)
				cb_getMediaItemCount = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_I) n_GetMediaItemCount);
			return cb_getMediaItemCount;
		}

		static int n_GetMediaItemCount (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.MediaItemCount;
		}
#pragma warning restore 0169

		IntPtr id_getMediaItemCount;
		public unsafe int MediaItemCount {
			get {
				if (id_getMediaItemCount == IntPtr.Zero)
					id_getMediaItemCount = JNIEnv.GetMethodID (class_ref, "getMediaItemCount", "()I");
				return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getMediaItemCount);
			}
		}

		static Delegate? cb_getMediaMetadata;
#pragma warning disable 0169
		static Delegate GetGetMediaMetadataHandler ()
		{
			if (cb_getMediaMetadata == null)
				cb_getMediaMetadata = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_L) n_GetMediaMetadata);
			return cb_getMediaMetadata;
		}

		static IntPtr n_GetMediaMetadata (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return JNIEnv.ToLocalJniHandle (__this.MediaMetadata);
		}
#pragma warning restore 0169

		IntPtr id_getMediaMetadata;
		public unsafe global::AndroidX.Media3.Common.MediaMetadata? MediaMetadata {
			get {
				if (id_getMediaMetadata == IntPtr.Zero)
					id_getMediaMetadata = JNIEnv.GetMethodID (class_ref, "getMediaMetadata", "()Landroidx/media3/common/MediaMetadata;");
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.Common.MediaMetadata> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getMediaMetadata), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate? cb_getNextMediaItemIndex;
#pragma warning disable 0169
		static Delegate GetGetNextMediaItemIndexHandler ()
		{
			if (cb_getNextMediaItemIndex == null)
				cb_getNextMediaItemIndex = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_I) n_GetNextMediaItemIndex);
			return cb_getNextMediaItemIndex;
		}

		static int n_GetNextMediaItemIndex (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.NextMediaItemIndex;
		}
#pragma warning restore 0169

		IntPtr id_getNextMediaItemIndex;
		public unsafe int NextMediaItemIndex {
			get {
				if (id_getNextMediaItemIndex == IntPtr.Zero)
					id_getNextMediaItemIndex = JNIEnv.GetMethodID (class_ref, "getNextMediaItemIndex", "()I");
				return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getNextMediaItemIndex);
			}
		}

		static Delegate? cb_getNextWindowIndex;
#pragma warning disable 0169
		static Delegate GetGetNextWindowIndexHandler ()
		{
			if (cb_getNextWindowIndex == null)
				cb_getNextWindowIndex = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_I) n_GetNextWindowIndex);
			return cb_getNextWindowIndex;
		}

		static int n_GetNextWindowIndex (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.NextWindowIndex;
		}
#pragma warning restore 0169

		IntPtr id_getNextWindowIndex;
		public unsafe int NextWindowIndex {
			get {
				if (id_getNextWindowIndex == IntPtr.Zero)
					id_getNextWindowIndex = JNIEnv.GetMethodID (class_ref, "getNextWindowIndex", "()I");
				return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getNextWindowIndex);
			}
		}

		static Delegate? cb_getPlayWhenReady;
#pragma warning disable 0169
		static Delegate GetGetPlayWhenReadyHandler ()
		{
			if (cb_getPlayWhenReady == null)
				cb_getPlayWhenReady = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_Z) n_GetPlayWhenReady);
			return cb_getPlayWhenReady;
		}

		static bool n_GetPlayWhenReady (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.PlayWhenReady;
		}
#pragma warning restore 0169

		static Delegate? cb_setPlayWhenReady_Z;
#pragma warning disable 0169
		static Delegate GetSetPlayWhenReady_ZHandler ()
		{
			if (cb_setPlayWhenReady_Z == null)
				cb_setPlayWhenReady_Z = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPZ_V) n_SetPlayWhenReady_Z);
			return cb_setPlayWhenReady_Z;
		}

		static void n_SetPlayWhenReady_Z (IntPtr jnienv, IntPtr native__this, bool value)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.PlayWhenReady = value;
		}
#pragma warning restore 0169

		IntPtr id_getPlayWhenReady;
		IntPtr id_setPlayWhenReady_Z;
		public unsafe bool PlayWhenReady {
			get {
				if (id_getPlayWhenReady == IntPtr.Zero)
					id_getPlayWhenReady = JNIEnv.GetMethodID (class_ref, "getPlayWhenReady", "()Z");
				return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_getPlayWhenReady);
			}
			set {
				if (id_setPlayWhenReady_Z == IntPtr.Zero)
					id_setPlayWhenReady_Z = JNIEnv.GetMethodID (class_ref, "setPlayWhenReady", "(Z)V");
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (value);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setPlayWhenReady_Z, __args);
			}
		}

		static Delegate? cb_getPlaybackParameters;
#pragma warning disable 0169
		static Delegate GetGetPlaybackParametersHandler ()
		{
			if (cb_getPlaybackParameters == null)
				cb_getPlaybackParameters = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_L) n_GetPlaybackParameters);
			return cb_getPlaybackParameters;
		}

		static IntPtr n_GetPlaybackParameters (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return JNIEnv.ToLocalJniHandle (__this.PlaybackParameters);
		}
#pragma warning restore 0169

		static Delegate? cb_setPlaybackParameters_Landroidx_media3_common_PlaybackParameters_;
#pragma warning disable 0169
		static Delegate GetSetPlaybackParameters_Landroidx_media3_common_PlaybackParameters_Handler ()
		{
			if (cb_setPlaybackParameters_Landroidx_media3_common_PlaybackParameters_ == null)
				cb_setPlaybackParameters_Landroidx_media3_common_PlaybackParameters_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_SetPlaybackParameters_Landroidx_media3_common_PlaybackParameters_);
			return cb_setPlaybackParameters_Landroidx_media3_common_PlaybackParameters_;
		}

		static void n_SetPlaybackParameters_Landroidx_media3_common_PlaybackParameters_ (IntPtr jnienv, IntPtr native__this, IntPtr native_value)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var value = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.Common.PlaybackParameters> (native_value, JniHandleOwnership.DoNotTransfer);
			__this.PlaybackParameters = value;
		}
#pragma warning restore 0169

		IntPtr id_getPlaybackParameters;
		IntPtr id_setPlaybackParameters_Landroidx_media3_common_PlaybackParameters_;
		public unsafe global::AndroidX.Media3.Common.PlaybackParameters? PlaybackParameters {
			get {
				if (id_getPlaybackParameters == IntPtr.Zero)
					id_getPlaybackParameters = JNIEnv.GetMethodID (class_ref, "getPlaybackParameters", "()Landroidx/media3/common/PlaybackParameters;");
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.Common.PlaybackParameters> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getPlaybackParameters), JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (id_setPlaybackParameters_Landroidx_media3_common_PlaybackParameters_ == IntPtr.Zero)
					id_setPlaybackParameters_Landroidx_media3_common_PlaybackParameters_ = JNIEnv.GetMethodID (class_ref, "setPlaybackParameters", "(Landroidx/media3/common/PlaybackParameters;)V");
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue ((value == null) ? IntPtr.Zero : ((global::Java.Lang.Object) value).Handle);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setPlaybackParameters_Landroidx_media3_common_PlaybackParameters_, __args);
			}
		}

		static Delegate? cb_getPlaybackState;
#pragma warning disable 0169
		static Delegate GetGetPlaybackStateHandler ()
		{
			if (cb_getPlaybackState == null)
				cb_getPlaybackState = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_I) n_GetPlaybackState);
			return cb_getPlaybackState;
		}

		static int n_GetPlaybackState (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.PlaybackState;
		}
#pragma warning restore 0169

		IntPtr id_getPlaybackState;
		public unsafe int PlaybackState {
			get {
				if (id_getPlaybackState == IntPtr.Zero)
					id_getPlaybackState = JNIEnv.GetMethodID (class_ref, "getPlaybackState", "()I");
				return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getPlaybackState);
			}
		}

		static Delegate? cb_getPlaybackSuppressionReason;
#pragma warning disable 0169
		static Delegate GetGetPlaybackSuppressionReasonHandler ()
		{
			if (cb_getPlaybackSuppressionReason == null)
				cb_getPlaybackSuppressionReason = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_I) n_GetPlaybackSuppressionReason);
			return cb_getPlaybackSuppressionReason;
		}

		static int n_GetPlaybackSuppressionReason (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.PlaybackSuppressionReason;
		}
#pragma warning restore 0169

		IntPtr id_getPlaybackSuppressionReason;
		public unsafe int PlaybackSuppressionReason {
			get {
				if (id_getPlaybackSuppressionReason == IntPtr.Zero)
					id_getPlaybackSuppressionReason = JNIEnv.GetMethodID (class_ref, "getPlaybackSuppressionReason", "()I");
				return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getPlaybackSuppressionReason);
			}
		}

		static Delegate? cb_getPlaylistMetadata;
#pragma warning disable 0169
		static Delegate GetGetPlaylistMetadataHandler ()
		{
			if (cb_getPlaylistMetadata == null)
				cb_getPlaylistMetadata = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_L) n_GetPlaylistMetadata);
			return cb_getPlaylistMetadata;
		}

		static IntPtr n_GetPlaylistMetadata (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return JNIEnv.ToLocalJniHandle (__this.PlaylistMetadata);
		}
#pragma warning restore 0169

		static Delegate? cb_setPlaylistMetadata_Landroidx_media3_common_MediaMetadata_;
#pragma warning disable 0169
		static Delegate GetSetPlaylistMetadata_Landroidx_media3_common_MediaMetadata_Handler ()
		{
			if (cb_setPlaylistMetadata_Landroidx_media3_common_MediaMetadata_ == null)
				cb_setPlaylistMetadata_Landroidx_media3_common_MediaMetadata_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_SetPlaylistMetadata_Landroidx_media3_common_MediaMetadata_);
			return cb_setPlaylistMetadata_Landroidx_media3_common_MediaMetadata_;
		}

		static void n_SetPlaylistMetadata_Landroidx_media3_common_MediaMetadata_ (IntPtr jnienv, IntPtr native__this, IntPtr native_value)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var value = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.Common.MediaMetadata> (native_value, JniHandleOwnership.DoNotTransfer);
			__this.PlaylistMetadata = value;
		}
#pragma warning restore 0169

		IntPtr id_getPlaylistMetadata;
		IntPtr id_setPlaylistMetadata_Landroidx_media3_common_MediaMetadata_;
		public unsafe global::AndroidX.Media3.Common.MediaMetadata? PlaylistMetadata {
			get {
				if (id_getPlaylistMetadata == IntPtr.Zero)
					id_getPlaylistMetadata = JNIEnv.GetMethodID (class_ref, "getPlaylistMetadata", "()Landroidx/media3/common/MediaMetadata;");
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.Common.MediaMetadata> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getPlaylistMetadata), JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (id_setPlaylistMetadata_Landroidx_media3_common_MediaMetadata_ == IntPtr.Zero)
					id_setPlaylistMetadata_Landroidx_media3_common_MediaMetadata_ = JNIEnv.GetMethodID (class_ref, "setPlaylistMetadata", "(Landroidx/media3/common/MediaMetadata;)V");
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue ((value == null) ? IntPtr.Zero : ((global::Java.Lang.Object) value).Handle);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setPlaylistMetadata_Landroidx_media3_common_MediaMetadata_, __args);
			}
		}

		static Delegate? cb_getPreviousMediaItemIndex;
#pragma warning disable 0169
		static Delegate GetGetPreviousMediaItemIndexHandler ()
		{
			if (cb_getPreviousMediaItemIndex == null)
				cb_getPreviousMediaItemIndex = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_I) n_GetPreviousMediaItemIndex);
			return cb_getPreviousMediaItemIndex;
		}

		static int n_GetPreviousMediaItemIndex (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.PreviousMediaItemIndex;
		}
#pragma warning restore 0169

		IntPtr id_getPreviousMediaItemIndex;
		public unsafe int PreviousMediaItemIndex {
			get {
				if (id_getPreviousMediaItemIndex == IntPtr.Zero)
					id_getPreviousMediaItemIndex = JNIEnv.GetMethodID (class_ref, "getPreviousMediaItemIndex", "()I");
				return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getPreviousMediaItemIndex);
			}
		}

		static Delegate? cb_getPreviousWindowIndex;
#pragma warning disable 0169
		static Delegate GetGetPreviousWindowIndexHandler ()
		{
			if (cb_getPreviousWindowIndex == null)
				cb_getPreviousWindowIndex = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_I) n_GetPreviousWindowIndex);
			return cb_getPreviousWindowIndex;
		}

		static int n_GetPreviousWindowIndex (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.PreviousWindowIndex;
		}
#pragma warning restore 0169

		IntPtr id_getPreviousWindowIndex;
		public unsafe int PreviousWindowIndex {
			get {
				if (id_getPreviousWindowIndex == IntPtr.Zero)
					id_getPreviousWindowIndex = JNIEnv.GetMethodID (class_ref, "getPreviousWindowIndex", "()I");
				return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getPreviousWindowIndex);
			}
		}

		static Delegate? cb_getRepeatMode;
#pragma warning disable 0169
		static Delegate GetGetRepeatModeHandler ()
		{
			if (cb_getRepeatMode == null)
				cb_getRepeatMode = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_I) n_GetRepeatMode);
			return cb_getRepeatMode;
		}

		static int n_GetRepeatMode (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.RepeatMode;
		}
#pragma warning restore 0169

		static Delegate? cb_setRepeatMode_I;
#pragma warning disable 0169
		static Delegate GetSetRepeatMode_IHandler ()
		{
			if (cb_setRepeatMode_I == null)
				cb_setRepeatMode_I = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPI_V) n_SetRepeatMode_I);
			return cb_setRepeatMode_I;
		}

		static void n_SetRepeatMode_I (IntPtr jnienv, IntPtr native__this, int value)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.RepeatMode = value;
		}
#pragma warning restore 0169

		IntPtr id_getRepeatMode;
		IntPtr id_setRepeatMode_I;
		public unsafe int RepeatMode {
			get {
				if (id_getRepeatMode == IntPtr.Zero)
					id_getRepeatMode = JNIEnv.GetMethodID (class_ref, "getRepeatMode", "()I");
				return JNIEnv.CallIntMethod (((global::Java.Lang.Object) this).Handle, id_getRepeatMode);
			}
			set {
				if (id_setRepeatMode_I == IntPtr.Zero)
					id_setRepeatMode_I = JNIEnv.GetMethodID (class_ref, "setRepeatMode", "(I)V");
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (value);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setRepeatMode_I, __args);
			}
		}

		static Delegate? cb_getSeekBackIncrement;
#pragma warning disable 0169
		static Delegate GetGetSeekBackIncrementHandler ()
		{
			if (cb_getSeekBackIncrement == null)
				cb_getSeekBackIncrement = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_J) n_GetSeekBackIncrement);
			return cb_getSeekBackIncrement;
		}

		static long n_GetSeekBackIncrement (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.SeekBackIncrement;
		}
#pragma warning restore 0169

		IntPtr id_getSeekBackIncrement;
		public unsafe long SeekBackIncrement {
			get {
				if (id_getSeekBackIncrement == IntPtr.Zero)
					id_getSeekBackIncrement = JNIEnv.GetMethodID (class_ref, "getSeekBackIncrement", "()J");
				return JNIEnv.CallLongMethod (((global::Java.Lang.Object) this).Handle, id_getSeekBackIncrement);
			}
		}

		static Delegate? cb_getSeekForwardIncrement;
#pragma warning disable 0169
		static Delegate GetGetSeekForwardIncrementHandler ()
		{
			if (cb_getSeekForwardIncrement == null)
				cb_getSeekForwardIncrement = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_J) n_GetSeekForwardIncrement);
			return cb_getSeekForwardIncrement;
		}

		static long n_GetSeekForwardIncrement (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.SeekForwardIncrement;
		}
#pragma warning restore 0169

		IntPtr id_getSeekForwardIncrement;
		public unsafe long SeekForwardIncrement {
			get {
				if (id_getSeekForwardIncrement == IntPtr.Zero)
					id_getSeekForwardIncrement = JNIEnv.GetMethodID (class_ref, "getSeekForwardIncrement", "()J");
				return JNIEnv.CallLongMethod (((global::Java.Lang.Object) this).Handle, id_getSeekForwardIncrement);
			}
		}

		static Delegate? cb_getShuffleModeEnabled;
#pragma warning disable 0169
		static Delegate GetGetShuffleModeEnabledHandler ()
		{
			if (cb_getShuffleModeEnabled == null)
				cb_getShuffleModeEnabled = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_Z) n_GetShuffleModeEnabled);
			return cb_getShuffleModeEnabled;
		}

		static bool n_GetShuffleModeEnabled (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.ShuffleModeEnabled;
		}
#pragma warning restore 0169

		static Delegate? cb_setShuffleModeEnabled_Z;
#pragma warning disable 0169
		static Delegate GetSetShuffleModeEnabled_ZHandler ()
		{
			if (cb_setShuffleModeEnabled_Z == null)
				cb_setShuffleModeEnabled_Z = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPZ_V) n_SetShuffleModeEnabled_Z);
			return cb_setShuffleModeEnabled_Z;
		}

		static void n_SetShuffleModeEnabled_Z (IntPtr jnienv, IntPtr native__this, bool value)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.ShuffleModeEnabled = value;
		}
#pragma warning restore 0169

		IntPtr id_getShuffleModeEnabled;
		IntPtr id_setShuffleModeEnabled_Z;
		public unsafe bool ShuffleModeEnabled {
			get {
				if (id_getShuffleModeEnabled == IntPtr.Zero)
					id_getShuffleModeEnabled = JNIEnv.GetMethodID (class_ref, "getShuffleModeEnabled", "()Z");
				return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_getShuffleModeEnabled);
			}
			set {
				if (id_setShuffleModeEnabled_Z == IntPtr.Zero)
					id_setShuffleModeEnabled_Z = JNIEnv.GetMethodID (class_ref, "setShuffleModeEnabled", "(Z)V");
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (value);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setShuffleModeEnabled_Z, __args);
			}
		}

		static Delegate? cb_getSurfaceSize;
#pragma warning disable 0169
		static Delegate GetGetSurfaceSizeHandler ()
		{
			if (cb_getSurfaceSize == null)
				cb_getSurfaceSize = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_L) n_GetSurfaceSize);
			return cb_getSurfaceSize;
		}

		static IntPtr n_GetSurfaceSize (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return JNIEnv.ToLocalJniHandle (__this.SurfaceSize);
		}
#pragma warning restore 0169

		IntPtr id_getSurfaceSize;
		public unsafe global::AndroidX.Media3.Common.Util.Size? SurfaceSize {
			get {
				if (id_getSurfaceSize == IntPtr.Zero)
					id_getSurfaceSize = JNIEnv.GetMethodID (class_ref, "getSurfaceSize", "()Landroidx/media3/common/util/Size;");
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.Common.Util.Size> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getSurfaceSize), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate? cb_getTotalBufferedDuration;
#pragma warning disable 0169
		static Delegate GetGetTotalBufferedDurationHandler ()
		{
			if (cb_getTotalBufferedDuration == null)
				cb_getTotalBufferedDuration = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_J) n_GetTotalBufferedDuration);
			return cb_getTotalBufferedDuration;
		}

		static long n_GetTotalBufferedDuration (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.TotalBufferedDuration;
		}
#pragma warning restore 0169

		IntPtr id_getTotalBufferedDuration;
		public unsafe long TotalBufferedDuration {
			get {
				if (id_getTotalBufferedDuration == IntPtr.Zero)
					id_getTotalBufferedDuration = JNIEnv.GetMethodID (class_ref, "getTotalBufferedDuration", "()J");
				return JNIEnv.CallLongMethod (((global::Java.Lang.Object) this).Handle, id_getTotalBufferedDuration);
			}
		}

		static Delegate? cb_getTrackSelectionParameters;
#pragma warning disable 0169
		static Delegate GetGetTrackSelectionParametersHandler ()
		{
			if (cb_getTrackSelectionParameters == null)
				cb_getTrackSelectionParameters = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_L) n_GetTrackSelectionParameters);
			return cb_getTrackSelectionParameters;
		}

		static IntPtr n_GetTrackSelectionParameters (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return JNIEnv.ToLocalJniHandle (__this.TrackSelectionParameters);
		}
#pragma warning restore 0169

		static Delegate? cb_setTrackSelectionParameters_Landroidx_media3_common_TrackSelectionParameters_;
#pragma warning disable 0169
		static Delegate GetSetTrackSelectionParameters_Landroidx_media3_common_TrackSelectionParameters_Handler ()
		{
			if (cb_setTrackSelectionParameters_Landroidx_media3_common_TrackSelectionParameters_ == null)
				cb_setTrackSelectionParameters_Landroidx_media3_common_TrackSelectionParameters_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_SetTrackSelectionParameters_Landroidx_media3_common_TrackSelectionParameters_);
			return cb_setTrackSelectionParameters_Landroidx_media3_common_TrackSelectionParameters_;
		}

		static void n_SetTrackSelectionParameters_Landroidx_media3_common_TrackSelectionParameters_ (IntPtr jnienv, IntPtr native__this, IntPtr native_value)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var value = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.Common.TrackSelectionParameters> (native_value, JniHandleOwnership.DoNotTransfer);
			__this.TrackSelectionParameters = value;
		}
#pragma warning restore 0169

		IntPtr id_getTrackSelectionParameters;
		IntPtr id_setTrackSelectionParameters_Landroidx_media3_common_TrackSelectionParameters_;
		public unsafe global::AndroidX.Media3.Common.TrackSelectionParameters? TrackSelectionParameters {
			get {
				if (id_getTrackSelectionParameters == IntPtr.Zero)
					id_getTrackSelectionParameters = JNIEnv.GetMethodID (class_ref, "getTrackSelectionParameters", "()Landroidx/media3/common/TrackSelectionParameters;");
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.Common.TrackSelectionParameters> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getTrackSelectionParameters), JniHandleOwnership.TransferLocalRef);
			}
			set {
				if (id_setTrackSelectionParameters_Landroidx_media3_common_TrackSelectionParameters_ == IntPtr.Zero)
					id_setTrackSelectionParameters_Landroidx_media3_common_TrackSelectionParameters_ = JNIEnv.GetMethodID (class_ref, "setTrackSelectionParameters", "(Landroidx/media3/common/TrackSelectionParameters;)V");
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue ((value == null) ? IntPtr.Zero : ((global::Java.Lang.Object) value).Handle);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setTrackSelectionParameters_Landroidx_media3_common_TrackSelectionParameters_, __args);
			}
		}

		static Delegate? cb_getVideoSize;
#pragma warning disable 0169
		static Delegate GetGetVideoSizeHandler ()
		{
			if (cb_getVideoSize == null)
				cb_getVideoSize = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_L) n_GetVideoSize);
			return cb_getVideoSize;
		}

		static IntPtr n_GetVideoSize (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return JNIEnv.ToLocalJniHandle (__this.VideoSize);
		}
#pragma warning restore 0169

		IntPtr id_getVideoSize;
		public unsafe global::AndroidX.Media3.Common.VideoSize? VideoSize {
			get {
				if (id_getVideoSize == IntPtr.Zero)
					id_getVideoSize = JNIEnv.GetMethodID (class_ref, "getVideoSize", "()Landroidx/media3/common/VideoSize;");
				return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.Common.VideoSize> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getVideoSize), JniHandleOwnership.TransferLocalRef);
			}
		}

		static Delegate? cb_getVolume;
#pragma warning disable 0169
		static Delegate GetGetVolumeHandler ()
		{
			if (cb_getVolume == null)
				cb_getVolume = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_F) n_GetVolume);
			return cb_getVolume;
		}

		static float n_GetVolume (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.Volume;
		}
#pragma warning restore 0169

		static Delegate? cb_setVolume_F;
#pragma warning disable 0169
		static Delegate GetSetVolume_FHandler ()
		{
			if (cb_setVolume_F == null)
				cb_setVolume_F = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPF_V) n_SetVolume_F);
			return cb_setVolume_F;
		}

		static void n_SetVolume_F (IntPtr jnienv, IntPtr native__this, float value)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.Volume = value;
		}
#pragma warning restore 0169

		IntPtr id_getVolume;
		IntPtr id_setVolume_F;
		public unsafe float Volume {
			get {
				if (id_getVolume == IntPtr.Zero)
					id_getVolume = JNIEnv.GetMethodID (class_ref, "getVolume", "()F");
				return JNIEnv.CallFloatMethod (((global::Java.Lang.Object) this).Handle, id_getVolume);
			}
			set {
				if (id_setVolume_F == IntPtr.Zero)
					id_setVolume_F = JNIEnv.GetMethodID (class_ref, "setVolume", "(F)V");
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (value);
				JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setVolume_F, __args);
			}
		}

		static Delegate? cb_addListener_Landroidx_media3_common_Player_Listener_;
#pragma warning disable 0169
		static Delegate GetAddListener_Landroidx_media3_common_Player_Listener_Handler ()
		{
			if (cb_addListener_Landroidx_media3_common_Player_Listener_ == null)
				cb_addListener_Landroidx_media3_common_Player_Listener_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_AddListener_Landroidx_media3_common_Player_Listener_);
			return cb_addListener_Landroidx_media3_common_Player_Listener_;
		}

		static void n_AddListener_Landroidx_media3_common_Player_Listener_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = (global::AndroidX.Media3.Common.IPlayerListener?)global::Java.Lang.Object.GetObject<global::AndroidX.Media3.Common.IPlayerListener> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.AddListener (p0);
		}
#pragma warning restore 0169

		IntPtr id_addListener_Landroidx_media3_common_Player_Listener_;
		public unsafe void AddListener (global::AndroidX.Media3.Common.IPlayerListener? p0)
		{
			if (id_addListener_Landroidx_media3_common_Player_Listener_ == IntPtr.Zero)
				id_addListener_Landroidx_media3_common_Player_Listener_ = JNIEnv.GetMethodID (class_ref, "addListener", "(Landroidx/media3/common/Player$Listener;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_addListener_Landroidx_media3_common_Player_Listener_, __args);
		}

		static Delegate? cb_addMediaItem_Landroidx_media3_common_MediaItem_;
#pragma warning disable 0169
		static Delegate GetAddMediaItem_Landroidx_media3_common_MediaItem_Handler ()
		{
			if (cb_addMediaItem_Landroidx_media3_common_MediaItem_ == null)
				cb_addMediaItem_Landroidx_media3_common_MediaItem_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_AddMediaItem_Landroidx_media3_common_MediaItem_);
			return cb_addMediaItem_Landroidx_media3_common_MediaItem_;
		}

		static void n_AddMediaItem_Landroidx_media3_common_MediaItem_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.Common.MediaItem> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.AddMediaItem (p0);
		}
#pragma warning restore 0169

		IntPtr id_addMediaItem_Landroidx_media3_common_MediaItem_;
		public unsafe void AddMediaItem (global::AndroidX.Media3.Common.MediaItem? p0)
		{
			if (id_addMediaItem_Landroidx_media3_common_MediaItem_ == IntPtr.Zero)
				id_addMediaItem_Landroidx_media3_common_MediaItem_ = JNIEnv.GetMethodID (class_ref, "addMediaItem", "(Landroidx/media3/common/MediaItem;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_addMediaItem_Landroidx_media3_common_MediaItem_, __args);
		}

		static Delegate? cb_addMediaItem_ILandroidx_media3_common_MediaItem_;
#pragma warning disable 0169
		static Delegate GetAddMediaItem_ILandroidx_media3_common_MediaItem_Handler ()
		{
			if (cb_addMediaItem_ILandroidx_media3_common_MediaItem_ == null)
				cb_addMediaItem_ILandroidx_media3_common_MediaItem_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPIL_V) n_AddMediaItem_ILandroidx_media3_common_MediaItem_);
			return cb_addMediaItem_ILandroidx_media3_common_MediaItem_;
		}

		static void n_AddMediaItem_ILandroidx_media3_common_MediaItem_ (IntPtr jnienv, IntPtr native__this, int p0, IntPtr native_p1)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p1 = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.Common.MediaItem> (native_p1, JniHandleOwnership.DoNotTransfer);
			__this.AddMediaItem (p0, p1);
		}
#pragma warning restore 0169

		IntPtr id_addMediaItem_ILandroidx_media3_common_MediaItem_;
		public unsafe void AddMediaItem (int p0, global::AndroidX.Media3.Common.MediaItem? p1)
		{
			if (id_addMediaItem_ILandroidx_media3_common_MediaItem_ == IntPtr.Zero)
				id_addMediaItem_ILandroidx_media3_common_MediaItem_ = JNIEnv.GetMethodID (class_ref, "addMediaItem", "(ILandroidx/media3/common/MediaItem;)V");
			JValue* __args = stackalloc JValue [2];
			__args [0] = new JValue (p0);
			__args [1] = new JValue ((p1 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p1).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_addMediaItem_ILandroidx_media3_common_MediaItem_, __args);
		}

		static Delegate? cb_addMediaItems_LSystem_Collections_Generic_IList_1_;
#pragma warning disable 0169
		static Delegate GetAddMediaItems_LSystem_Collections_Generic_IList_1_Handler ()
		{
			if (cb_addMediaItems_LSystem_Collections_Generic_IList_1_ == null)
				cb_addMediaItems_LSystem_Collections_Generic_IList_1_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_AddMediaItems_LSystem_Collections_Generic_IList_1_);
			return cb_addMediaItems_LSystem_Collections_Generic_IList_1_;
		}

		static void n_AddMediaItems_LSystem_Collections_Generic_IList_1_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			// var p0 = (/* global::System.Collections.Generic.IList`1 */ global::System.Collections.Generic.IList<global::AndroidX.Media3.ExoPlayer.Source.IMediaSource>?)global::Java.Lang.Object.GetObject</* global::System.Collections.Generic.IList`1 */ global::System.Collections.Generic.IList<global::AndroidX.Media3.ExoPlayer.Source.IMediaSource>> (native_p0, JniHandleOwnership.DoNotTransfer);
			var p0 = (/* global::System.Collections.Generic.IList`1 */ global::System.Collections.Generic.IList<global::AndroidX.Media3.Common.MediaItem>?)global::Java.Lang.Object.GetObject</* global::System.Collections.Generic.IList`1 */ Java.Lang.Object> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.AddMediaItems (p0);
		}
#pragma warning restore 0169

		IntPtr id_addMediaItems_LSystem_Collections_Generic_IList_1_;
		// public unsafe void AddMediaItems (/* global::System.Collections.Generic.IList`1 */ global::System.Collections.Generic.IList<global::AndroidX.Media3.ExoPlayer.Source.IMediaSource>? p0)
		public unsafe void AddMediaItems (/* global::System.Collections.Generic.IList`1 */ global::System.Collections.Generic.IList<global::AndroidX.Media3.Common.MediaItem>? p0)
		{
			if (id_addMediaItems_LSystem_Collections_Generic_IList_1_ == IntPtr.Zero)
				id_addMediaItems_LSystem_Collections_Generic_IList_1_ = JNIEnv.GetMethodID (class_ref, "addMediaItems", "(LSystem/Collections/Generic/IList`1;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_addMediaItems_LSystem_Collections_Generic_IList_1_, __args);
		}
		
		static Delegate? cb_canAdvertiseSession;
#pragma warning disable 0169
		static Delegate GetCanAdvertiseSessionHandler ()
		{
			if (cb_canAdvertiseSession == null)
				cb_canAdvertiseSession = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_Z) n_CanAdvertiseSession);
			return cb_canAdvertiseSession;
		}

		static bool n_CanAdvertiseSession (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.CanAdvertiseSession ();
		}
#pragma warning restore 0169

		IntPtr id_canAdvertiseSession;
		public unsafe bool CanAdvertiseSession ()
		{
			if (id_canAdvertiseSession == IntPtr.Zero)
				id_canAdvertiseSession = JNIEnv.GetMethodID (class_ref, "canAdvertiseSession", "()Z");
			return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_canAdvertiseSession);
		}

		static Delegate? cb_clearMediaItems;
#pragma warning disable 0169
		static Delegate GetClearMediaItemsHandler ()
		{
			if (cb_clearMediaItems == null)
				cb_clearMediaItems = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_V) n_ClearMediaItems);
			return cb_clearMediaItems;
		}

		static void n_ClearMediaItems (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.ClearMediaItems ();
		}
#pragma warning restore 0169

		IntPtr id_clearMediaItems;
		public unsafe void ClearMediaItems ()
		{
			if (id_clearMediaItems == IntPtr.Zero)
				id_clearMediaItems = JNIEnv.GetMethodID (class_ref, "clearMediaItems", "()V");
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_clearMediaItems);
		}

		static Delegate? cb_clearVideoSurface;
#pragma warning disable 0169
		static Delegate GetClearVideoSurfaceHandler ()
		{
			if (cb_clearVideoSurface == null)
				cb_clearVideoSurface = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_V) n_ClearVideoSurface);
			return cb_clearVideoSurface;
		}

		static void n_ClearVideoSurface (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.ClearVideoSurface ();
		}
#pragma warning restore 0169

		IntPtr id_clearVideoSurface;
		public unsafe void ClearVideoSurface ()
		{
			if (id_clearVideoSurface == IntPtr.Zero)
				id_clearVideoSurface = JNIEnv.GetMethodID (class_ref, "clearVideoSurface", "()V");
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_clearVideoSurface);
		}

		static Delegate? cb_clearVideoSurface_Landroid_view_Surface_;
#pragma warning disable 0169
		static Delegate GetClearVideoSurface_Landroid_view_Surface_Handler ()
		{
			if (cb_clearVideoSurface_Landroid_view_Surface_ == null)
				cb_clearVideoSurface_Landroid_view_Surface_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_ClearVideoSurface_Landroid_view_Surface_);
			return cb_clearVideoSurface_Landroid_view_Surface_;
		}

		static void n_ClearVideoSurface_Landroid_view_Surface_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = global::Java.Lang.Object.GetObject<global::Android.Views.Surface> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ClearVideoSurface (p0);
		}
#pragma warning restore 0169

		IntPtr id_clearVideoSurface_Landroid_view_Surface_;
		public unsafe void ClearVideoSurface (global::Android.Views.Surface? p0)
		{
			if (id_clearVideoSurface_Landroid_view_Surface_ == IntPtr.Zero)
				id_clearVideoSurface_Landroid_view_Surface_ = JNIEnv.GetMethodID (class_ref, "clearVideoSurface", "(Landroid/view/Surface;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_clearVideoSurface_Landroid_view_Surface_, __args);
		}

		static Delegate? cb_clearVideoSurfaceHolder_Landroid_view_SurfaceHolder_;
#pragma warning disable 0169
		static Delegate GetClearVideoSurfaceHolder_Landroid_view_SurfaceHolder_Handler ()
		{
			if (cb_clearVideoSurfaceHolder_Landroid_view_SurfaceHolder_ == null)
				cb_clearVideoSurfaceHolder_Landroid_view_SurfaceHolder_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_ClearVideoSurfaceHolder_Landroid_view_SurfaceHolder_);
			return cb_clearVideoSurfaceHolder_Landroid_view_SurfaceHolder_;
		}

		static void n_ClearVideoSurfaceHolder_Landroid_view_SurfaceHolder_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = (global::Android.Views.ISurfaceHolder?)global::Java.Lang.Object.GetObject<global::Android.Views.ISurfaceHolder> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ClearVideoSurfaceHolder (p0);
		}
#pragma warning restore 0169

		IntPtr id_clearVideoSurfaceHolder_Landroid_view_SurfaceHolder_;
		public unsafe void ClearVideoSurfaceHolder (global::Android.Views.ISurfaceHolder? p0)
		{
			if (id_clearVideoSurfaceHolder_Landroid_view_SurfaceHolder_ == IntPtr.Zero)
				id_clearVideoSurfaceHolder_Landroid_view_SurfaceHolder_ = JNIEnv.GetMethodID (class_ref, "clearVideoSurfaceHolder", "(Landroid/view/SurfaceHolder;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_clearVideoSurfaceHolder_Landroid_view_SurfaceHolder_, __args);
		}

		static Delegate? cb_clearVideoSurfaceView_Landroid_view_SurfaceView_;
#pragma warning disable 0169
		static Delegate GetClearVideoSurfaceView_Landroid_view_SurfaceView_Handler ()
		{
			if (cb_clearVideoSurfaceView_Landroid_view_SurfaceView_ == null)
				cb_clearVideoSurfaceView_Landroid_view_SurfaceView_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_ClearVideoSurfaceView_Landroid_view_SurfaceView_);
			return cb_clearVideoSurfaceView_Landroid_view_SurfaceView_;
		}

		static void n_ClearVideoSurfaceView_Landroid_view_SurfaceView_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = global::Java.Lang.Object.GetObject<global::Android.Views.SurfaceView> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ClearVideoSurfaceView (p0);
		}
#pragma warning restore 0169

		IntPtr id_clearVideoSurfaceView_Landroid_view_SurfaceView_;
		public unsafe void ClearVideoSurfaceView (global::Android.Views.SurfaceView? p0)
		{
			if (id_clearVideoSurfaceView_Landroid_view_SurfaceView_ == IntPtr.Zero)
				id_clearVideoSurfaceView_Landroid_view_SurfaceView_ = JNIEnv.GetMethodID (class_ref, "clearVideoSurfaceView", "(Landroid/view/SurfaceView;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_clearVideoSurfaceView_Landroid_view_SurfaceView_, __args);
		}

		static Delegate? cb_clearVideoTextureView_Landroid_view_TextureView_;
#pragma warning disable 0169
		static Delegate GetClearVideoTextureView_Landroid_view_TextureView_Handler ()
		{
			if (cb_clearVideoTextureView_Landroid_view_TextureView_ == null)
				cb_clearVideoTextureView_Landroid_view_TextureView_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_ClearVideoTextureView_Landroid_view_TextureView_);
			return cb_clearVideoTextureView_Landroid_view_TextureView_;
		}

		static void n_ClearVideoTextureView_Landroid_view_TextureView_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = global::Java.Lang.Object.GetObject<global::Android.Views.TextureView> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.ClearVideoTextureView (p0);
		}
#pragma warning restore 0169

		IntPtr id_clearVideoTextureView_Landroid_view_TextureView_;
		public unsafe void ClearVideoTextureView (global::Android.Views.TextureView? p0)
		{
			if (id_clearVideoTextureView_Landroid_view_TextureView_ == IntPtr.Zero)
				id_clearVideoTextureView_Landroid_view_TextureView_ = JNIEnv.GetMethodID (class_ref, "clearVideoTextureView", "(Landroid/view/TextureView;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_clearVideoTextureView_Landroid_view_TextureView_, __args);
		}

		static Delegate? cb_decreaseDeviceVolume;
#pragma warning disable 0169
		static Delegate GetDecreaseDeviceVolumeHandler ()
		{
			if (cb_decreaseDeviceVolume == null)
				cb_decreaseDeviceVolume = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_V) n_DecreaseDeviceVolume);
			return cb_decreaseDeviceVolume;
		}

		static void n_DecreaseDeviceVolume (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.DecreaseDeviceVolume ();
		}
#pragma warning restore 0169

		IntPtr id_decreaseDeviceVolume;
		public unsafe void DecreaseDeviceVolume ()
		{
			if (id_decreaseDeviceVolume == IntPtr.Zero)
				id_decreaseDeviceVolume = JNIEnv.GetMethodID (class_ref, "decreaseDeviceVolume", "()V");
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_decreaseDeviceVolume);
		}

		static Delegate? cb_getMediaItemAt_I;
#pragma warning disable 0169
		static Delegate GetGetMediaItemAt_IHandler ()
		{
			if (cb_getMediaItemAt_I == null)
				cb_getMediaItemAt_I = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPI_L) n_GetMediaItemAt_I);
			return cb_getMediaItemAt_I;
		}

		static IntPtr n_GetMediaItemAt_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return JNIEnv.ToLocalJniHandle (__this.GetMediaItemAt (p0));
		}
#pragma warning restore 0169

		IntPtr id_getMediaItemAt_I;
		public unsafe global::AndroidX.Media3.Common.MediaItem? GetMediaItemAt (int p0)
		{
			if (id_getMediaItemAt_I == IntPtr.Zero)
				id_getMediaItemAt_I = JNIEnv.GetMethodID (class_ref, "getMediaItemAt", "(I)Landroidx/media3/common/MediaItem;");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			return global::Java.Lang.Object.GetObject<global::AndroidX.Media3.Common.MediaItem> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_getMediaItemAt_I, __args), JniHandleOwnership.TransferLocalRef);
		}

		static Delegate? cb_increaseDeviceVolume;
#pragma warning disable 0169
		static Delegate GetIncreaseDeviceVolumeHandler ()
		{
			if (cb_increaseDeviceVolume == null)
				cb_increaseDeviceVolume = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_V) n_IncreaseDeviceVolume);
			return cb_increaseDeviceVolume;
		}

		static void n_IncreaseDeviceVolume (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.IncreaseDeviceVolume ();
		}
#pragma warning restore 0169

		IntPtr id_increaseDeviceVolume;
		public unsafe void IncreaseDeviceVolume ()
		{
			if (id_increaseDeviceVolume == IntPtr.Zero)
				id_increaseDeviceVolume = JNIEnv.GetMethodID (class_ref, "increaseDeviceVolume", "()V");
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_increaseDeviceVolume);
		}

		static Delegate? cb_isCommandAvailable_I;
#pragma warning disable 0169
		static Delegate GetIsCommandAvailable_IHandler ()
		{
			if (cb_isCommandAvailable_I == null)
				cb_isCommandAvailable_I = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPI_Z) n_IsCommandAvailable_I);
			return cb_isCommandAvailable_I;
		}

		static bool n_IsCommandAvailable_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			return __this.IsCommandAvailable (p0);
		}
#pragma warning restore 0169

		IntPtr id_isCommandAvailable_I;
		public unsafe bool IsCommandAvailable (int p0)
		{
			if (id_isCommandAvailable_I == IntPtr.Zero)
				id_isCommandAvailable_I = JNIEnv.GetMethodID (class_ref, "isCommandAvailable", "(I)Z");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			return JNIEnv.CallBooleanMethod (((global::Java.Lang.Object) this).Handle, id_isCommandAvailable_I, __args);
		}

		static Delegate? cb_moveMediaItem_II;
#pragma warning disable 0169
		static Delegate GetMoveMediaItem_IIHandler ()
		{
			if (cb_moveMediaItem_II == null)
				cb_moveMediaItem_II = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPII_V) n_MoveMediaItem_II);
			return cb_moveMediaItem_II;
		}

		static void n_MoveMediaItem_II (IntPtr jnienv, IntPtr native__this, int p0, int p1)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.MoveMediaItem (p0, p1);
		}
#pragma warning restore 0169

		IntPtr id_moveMediaItem_II;
		public unsafe void MoveMediaItem (int p0, int p1)
		{
			if (id_moveMediaItem_II == IntPtr.Zero)
				id_moveMediaItem_II = JNIEnv.GetMethodID (class_ref, "moveMediaItem", "(II)V");
			JValue* __args = stackalloc JValue [2];
			__args [0] = new JValue (p0);
			__args [1] = new JValue (p1);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_moveMediaItem_II, __args);
		}

		static Delegate? cb_moveMediaItems_III;
#pragma warning disable 0169
		static Delegate GetMoveMediaItems_IIIHandler ()
		{
			if (cb_moveMediaItems_III == null)
				cb_moveMediaItems_III = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPIII_V) n_MoveMediaItems_III);
			return cb_moveMediaItems_III;
		}

		static void n_MoveMediaItems_III (IntPtr jnienv, IntPtr native__this, int p0, int p1, int p2)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.MoveMediaItems (p0, p1, p2);
		}
#pragma warning restore 0169

		IntPtr id_moveMediaItems_III;
		public unsafe void MoveMediaItems (int p0, int p1, int p2)
		{
			if (id_moveMediaItems_III == IntPtr.Zero)
				id_moveMediaItems_III = JNIEnv.GetMethodID (class_ref, "moveMediaItems", "(III)V");
			JValue* __args = stackalloc JValue [3];
			__args [0] = new JValue (p0);
			__args [1] = new JValue (p1);
			__args [2] = new JValue (p2);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_moveMediaItems_III, __args);
		}

		static Delegate? cb_next;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetNextHandler ()
		{
			if (cb_next == null)
				cb_next = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_V) n_Next);
			return cb_next;
		}

		[Obsolete]
		static void n_Next (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.Next ();
		}
#pragma warning restore 0169

		IntPtr id_next;
		public unsafe void Next ()
		{
			if (id_next == IntPtr.Zero)
				id_next = JNIEnv.GetMethodID (class_ref, "next", "()V");
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_next);
		}

		static Delegate? cb_pause;
#pragma warning disable 0169
		static Delegate GetPauseHandler ()
		{
			if (cb_pause == null)
				cb_pause = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_V) n_Pause);
			return cb_pause;
		}

		static void n_Pause (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.Pause ();
		}
#pragma warning restore 0169

		IntPtr id_pause;
		public unsafe void Pause ()
		{
			if (id_pause == IntPtr.Zero)
				id_pause = JNIEnv.GetMethodID (class_ref, "pause", "()V");
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_pause);
		}

		static Delegate? cb_play;
#pragma warning disable 0169
		static Delegate GetPlayHandler ()
		{
			if (cb_play == null)
				cb_play = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_V) n_Play);
			return cb_play;
		}

		static void n_Play (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.Play ();
		}
#pragma warning restore 0169

		IntPtr id_play;
		public unsafe void Play ()
		{
			if (id_play == IntPtr.Zero)
				id_play = JNIEnv.GetMethodID (class_ref, "play", "()V");
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_play);
		}

		static Delegate? cb_prepare;
#pragma warning disable 0169
		static Delegate GetPrepareHandler ()
		{
			if (cb_prepare == null)
				cb_prepare = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_V) n_Prepare);
			return cb_prepare;
		}

		static void n_Prepare (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.Prepare ();
		}
#pragma warning restore 0169

		IntPtr id_prepare;
		public unsafe void Prepare ()
		{
			if (id_prepare == IntPtr.Zero)
				id_prepare = JNIEnv.GetMethodID (class_ref, "prepare", "()V");
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_prepare);
		}

		static Delegate? cb_previous;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetPreviousHandler ()
		{
			if (cb_previous == null)
				cb_previous = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_V) n_Previous);
			return cb_previous;
		}

		[Obsolete]
		static void n_Previous (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.Previous ();
		}
#pragma warning restore 0169

		IntPtr id_previous;
		public unsafe void Previous ()
		{
			if (id_previous == IntPtr.Zero)
				id_previous = JNIEnv.GetMethodID (class_ref, "previous", "()V");
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_previous);
		}

		static Delegate? cb_release;
#pragma warning disable 0169
		static Delegate GetReleaseHandler ()
		{
			if (cb_release == null)
				cb_release = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_V) n_Release);
			return cb_release;
		}

		static void n_Release (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.Release ();
		}
#pragma warning restore 0169

		IntPtr id_release;
		public unsafe void Release ()
		{
			if (id_release == IntPtr.Zero)
				id_release = JNIEnv.GetMethodID (class_ref, "release", "()V");
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_release);
		}

		static Delegate? cb_removeListener_Landroidx_media3_common_Player_Listener_;
#pragma warning disable 0169
		static Delegate GetRemoveListener_Landroidx_media3_common_Player_Listener_Handler ()
		{
			if (cb_removeListener_Landroidx_media3_common_Player_Listener_ == null)
				cb_removeListener_Landroidx_media3_common_Player_Listener_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_RemoveListener_Landroidx_media3_common_Player_Listener_);
			return cb_removeListener_Landroidx_media3_common_Player_Listener_;
		}

		static void n_RemoveListener_Landroidx_media3_common_Player_Listener_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = (global::AndroidX.Media3.Common.IPlayerListener?)global::Java.Lang.Object.GetObject<global::AndroidX.Media3.Common.IPlayerListener> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.RemoveListener (p0);
		}
#pragma warning restore 0169

		IntPtr id_removeListener_Landroidx_media3_common_Player_Listener_;
		public unsafe void RemoveListener (global::AndroidX.Media3.Common.IPlayerListener? p0)
		{
			if (id_removeListener_Landroidx_media3_common_Player_Listener_ == IntPtr.Zero)
				id_removeListener_Landroidx_media3_common_Player_Listener_ = JNIEnv.GetMethodID (class_ref, "removeListener", "(Landroidx/media3/common/Player$Listener;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_removeListener_Landroidx_media3_common_Player_Listener_, __args);
		}

		static Delegate? cb_removeMediaItem_I;
#pragma warning disable 0169
		static Delegate GetRemoveMediaItem_IHandler ()
		{
			if (cb_removeMediaItem_I == null)
				cb_removeMediaItem_I = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPI_V) n_RemoveMediaItem_I);
			return cb_removeMediaItem_I;
		}

		static void n_RemoveMediaItem_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.RemoveMediaItem (p0);
		}
#pragma warning restore 0169

		IntPtr id_removeMediaItem_I;
		public unsafe void RemoveMediaItem (int p0)
		{
			if (id_removeMediaItem_I == IntPtr.Zero)
				id_removeMediaItem_I = JNIEnv.GetMethodID (class_ref, "removeMediaItem", "(I)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_removeMediaItem_I, __args);
		}

		static Delegate? cb_removeMediaItems_II;
#pragma warning disable 0169
		static Delegate GetRemoveMediaItems_IIHandler ()
		{
			if (cb_removeMediaItems_II == null)
				cb_removeMediaItems_II = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPII_V) n_RemoveMediaItems_II);
			return cb_removeMediaItems_II;
		}

		static void n_RemoveMediaItems_II (IntPtr jnienv, IntPtr native__this, int p0, int p1)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.RemoveMediaItems (p0, p1);
		}
#pragma warning restore 0169

		IntPtr id_removeMediaItems_II;
		public unsafe void RemoveMediaItems (int p0, int p1)
		{
			if (id_removeMediaItems_II == IntPtr.Zero)
				id_removeMediaItems_II = JNIEnv.GetMethodID (class_ref, "removeMediaItems", "(II)V");
			JValue* __args = stackalloc JValue [2];
			__args [0] = new JValue (p0);
			__args [1] = new JValue (p1);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_removeMediaItems_II, __args);
		}

		static Delegate? cb_seekBack;
#pragma warning disable 0169
		static Delegate GetSeekBackHandler ()
		{
			if (cb_seekBack == null)
				cb_seekBack = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_V) n_SeekBack);
			return cb_seekBack;
		}

		static void n_SeekBack (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.SeekBack ();
		}
#pragma warning restore 0169

		IntPtr id_seekBack;
		public unsafe void SeekBack ()
		{
			if (id_seekBack == IntPtr.Zero)
				id_seekBack = JNIEnv.GetMethodID (class_ref, "seekBack", "()V");
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_seekBack);
		}

		static Delegate? cb_seekForward;
#pragma warning disable 0169
		static Delegate GetSeekForwardHandler ()
		{
			if (cb_seekForward == null)
				cb_seekForward = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_V) n_SeekForward);
			return cb_seekForward;
		}

		static void n_SeekForward (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.SeekForward ();
		}
#pragma warning restore 0169

		IntPtr id_seekForward;
		public unsafe void SeekForward ()
		{
			if (id_seekForward == IntPtr.Zero)
				id_seekForward = JNIEnv.GetMethodID (class_ref, "seekForward", "()V");
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_seekForward);
		}

		static Delegate? cb_seekTo_IJ;
#pragma warning disable 0169
		static Delegate GetSeekTo_IJHandler ()
		{
			if (cb_seekTo_IJ == null)
				cb_seekTo_IJ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPIJ_V) n_SeekTo_IJ);
			return cb_seekTo_IJ;
		}

		static void n_SeekTo_IJ (IntPtr jnienv, IntPtr native__this, int p0, long p1)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.SeekTo (p0, p1);
		}
#pragma warning restore 0169

		IntPtr id_seekTo_IJ;
		public unsafe void SeekTo (int p0, long p1)
		{
			if (id_seekTo_IJ == IntPtr.Zero)
				id_seekTo_IJ = JNIEnv.GetMethodID (class_ref, "seekTo", "(IJ)V");
			JValue* __args = stackalloc JValue [2];
			__args [0] = new JValue (p0);
			__args [1] = new JValue (p1);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_seekTo_IJ, __args);
		}

		static Delegate? cb_seekTo_J;
#pragma warning disable 0169
		static Delegate GetSeekTo_JHandler ()
		{
			if (cb_seekTo_J == null)
				cb_seekTo_J = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPJ_V) n_SeekTo_J);
			return cb_seekTo_J;
		}

		static void n_SeekTo_J (IntPtr jnienv, IntPtr native__this, long p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.SeekTo (p0);
		}
#pragma warning restore 0169

		IntPtr id_seekTo_J;
		public unsafe void SeekTo (long p0)
		{
			if (id_seekTo_J == IntPtr.Zero)
				id_seekTo_J = JNIEnv.GetMethodID (class_ref, "seekTo", "(J)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_seekTo_J, __args);
		}

		static Delegate? cb_seekToDefaultPosition;
#pragma warning disable 0169
		static Delegate GetSeekToDefaultPositionHandler ()
		{
			if (cb_seekToDefaultPosition == null)
				cb_seekToDefaultPosition = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_V) n_SeekToDefaultPosition);
			return cb_seekToDefaultPosition;
		}

		static void n_SeekToDefaultPosition (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.SeekToDefaultPosition ();
		}
#pragma warning restore 0169

		IntPtr id_seekToDefaultPosition;
		public unsafe void SeekToDefaultPosition ()
		{
			if (id_seekToDefaultPosition == IntPtr.Zero)
				id_seekToDefaultPosition = JNIEnv.GetMethodID (class_ref, "seekToDefaultPosition", "()V");
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_seekToDefaultPosition);
		}

		static Delegate? cb_seekToDefaultPosition_I;
#pragma warning disable 0169
		static Delegate GetSeekToDefaultPosition_IHandler ()
		{
			if (cb_seekToDefaultPosition_I == null)
				cb_seekToDefaultPosition_I = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPI_V) n_SeekToDefaultPosition_I);
			return cb_seekToDefaultPosition_I;
		}

		static void n_SeekToDefaultPosition_I (IntPtr jnienv, IntPtr native__this, int p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.SeekToDefaultPosition (p0);
		}
#pragma warning restore 0169

		IntPtr id_seekToDefaultPosition_I;
		public unsafe void SeekToDefaultPosition (int p0)
		{
			if (id_seekToDefaultPosition_I == IntPtr.Zero)
				id_seekToDefaultPosition_I = JNIEnv.GetMethodID (class_ref, "seekToDefaultPosition", "(I)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_seekToDefaultPosition_I, __args);
		}

		static Delegate? cb_seekToNext;
#pragma warning disable 0169
		static Delegate GetSeekToNextHandler ()
		{
			if (cb_seekToNext == null)
				cb_seekToNext = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_V) n_SeekToNext);
			return cb_seekToNext;
		}

		static void n_SeekToNext (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.SeekToNext ();
		}
#pragma warning restore 0169

		IntPtr id_seekToNext;
		public unsafe void SeekToNext ()
		{
			if (id_seekToNext == IntPtr.Zero)
				id_seekToNext = JNIEnv.GetMethodID (class_ref, "seekToNext", "()V");
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_seekToNext);
		}

		static Delegate? cb_seekToNextMediaItem;
#pragma warning disable 0169
		static Delegate GetSeekToNextMediaItemHandler ()
		{
			if (cb_seekToNextMediaItem == null)
				cb_seekToNextMediaItem = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_V) n_SeekToNextMediaItem);
			return cb_seekToNextMediaItem;
		}

		static void n_SeekToNextMediaItem (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.SeekToNextMediaItem ();
		}
#pragma warning restore 0169

		IntPtr id_seekToNextMediaItem;
		public unsafe void SeekToNextMediaItem ()
		{
			if (id_seekToNextMediaItem == IntPtr.Zero)
				id_seekToNextMediaItem = JNIEnv.GetMethodID (class_ref, "seekToNextMediaItem", "()V");
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_seekToNextMediaItem);
		}

		static Delegate? cb_seekToNextWindow;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetSeekToNextWindowHandler ()
		{
			if (cb_seekToNextWindow == null)
				cb_seekToNextWindow = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_V) n_SeekToNextWindow);
			return cb_seekToNextWindow;
		}

		[Obsolete]
		static void n_SeekToNextWindow (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.SeekToNextWindow ();
		}
#pragma warning restore 0169

		IntPtr id_seekToNextWindow;
		public unsafe void SeekToNextWindow ()
		{
			if (id_seekToNextWindow == IntPtr.Zero)
				id_seekToNextWindow = JNIEnv.GetMethodID (class_ref, "seekToNextWindow", "()V");
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_seekToNextWindow);
		}

		static Delegate? cb_seekToPrevious;
#pragma warning disable 0169
		static Delegate GetSeekToPreviousHandler ()
		{
			if (cb_seekToPrevious == null)
				cb_seekToPrevious = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_V) n_SeekToPrevious);
			return cb_seekToPrevious;
		}

		static void n_SeekToPrevious (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.SeekToPrevious ();
		}
#pragma warning restore 0169

		IntPtr id_seekToPrevious;
		public unsafe void SeekToPrevious ()
		{
			if (id_seekToPrevious == IntPtr.Zero)
				id_seekToPrevious = JNIEnv.GetMethodID (class_ref, "seekToPrevious", "()V");
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_seekToPrevious);
		}

		static Delegate? cb_seekToPreviousMediaItem;
#pragma warning disable 0169
		static Delegate GetSeekToPreviousMediaItemHandler ()
		{
			if (cb_seekToPreviousMediaItem == null)
				cb_seekToPreviousMediaItem = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_V) n_SeekToPreviousMediaItem);
			return cb_seekToPreviousMediaItem;
		}

		static void n_SeekToPreviousMediaItem (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.SeekToPreviousMediaItem ();
		}
#pragma warning restore 0169

		IntPtr id_seekToPreviousMediaItem;
		public unsafe void SeekToPreviousMediaItem ()
		{
			if (id_seekToPreviousMediaItem == IntPtr.Zero)
				id_seekToPreviousMediaItem = JNIEnv.GetMethodID (class_ref, "seekToPreviousMediaItem", "()V");
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_seekToPreviousMediaItem);
		}

		static Delegate? cb_seekToPreviousWindow;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetSeekToPreviousWindowHandler ()
		{
			if (cb_seekToPreviousWindow == null)
				cb_seekToPreviousWindow = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_V) n_SeekToPreviousWindow);
			return cb_seekToPreviousWindow;
		}

		[Obsolete]
		static void n_SeekToPreviousWindow (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.SeekToPreviousWindow ();
		}
#pragma warning restore 0169

		IntPtr id_seekToPreviousWindow;
		public unsafe void SeekToPreviousWindow ()
		{
			if (id_seekToPreviousWindow == IntPtr.Zero)
				id_seekToPreviousWindow = JNIEnv.GetMethodID (class_ref, "seekToPreviousWindow", "()V");
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_seekToPreviousWindow);
		}

		static Delegate? cb_setMediaItem_Landroidx_media3_common_MediaItem_;
#pragma warning disable 0169
		static Delegate GetSetMediaItem_Landroidx_media3_common_MediaItem_Handler ()
		{
			if (cb_setMediaItem_Landroidx_media3_common_MediaItem_ == null)
				cb_setMediaItem_Landroidx_media3_common_MediaItem_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_SetMediaItem_Landroidx_media3_common_MediaItem_);
			return cb_setMediaItem_Landroidx_media3_common_MediaItem_;
		}

		static void n_SetMediaItem_Landroidx_media3_common_MediaItem_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.Common.MediaItem> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetMediaItem (p0);
		}
#pragma warning restore 0169

		IntPtr id_setMediaItem_Landroidx_media3_common_MediaItem_;
		public unsafe void SetMediaItem (global::AndroidX.Media3.Common.MediaItem? p0)
		{
			if (id_setMediaItem_Landroidx_media3_common_MediaItem_ == IntPtr.Zero)
				id_setMediaItem_Landroidx_media3_common_MediaItem_ = JNIEnv.GetMethodID (class_ref, "setMediaItem", "(Landroidx/media3/common/MediaItem;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setMediaItem_Landroidx_media3_common_MediaItem_, __args);
		}

		static Delegate? cb_setMediaItem_Landroidx_media3_common_MediaItem_Z;
#pragma warning disable 0169
		static Delegate GetSetMediaItem_Landroidx_media3_common_MediaItem_ZHandler ()
		{
			if (cb_setMediaItem_Landroidx_media3_common_MediaItem_Z == null)
				cb_setMediaItem_Landroidx_media3_common_MediaItem_Z = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPLZ_V) n_SetMediaItem_Landroidx_media3_common_MediaItem_Z);
			return cb_setMediaItem_Landroidx_media3_common_MediaItem_Z;
		}

		static void n_SetMediaItem_Landroidx_media3_common_MediaItem_Z (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.Common.MediaItem> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetMediaItem (p0, p1);
		}
#pragma warning restore 0169

		IntPtr id_setMediaItem_Landroidx_media3_common_MediaItem_Z;
		public unsafe void SetMediaItem (global::AndroidX.Media3.Common.MediaItem? p0, bool p1)
		{
			if (id_setMediaItem_Landroidx_media3_common_MediaItem_Z == IntPtr.Zero)
				id_setMediaItem_Landroidx_media3_common_MediaItem_Z = JNIEnv.GetMethodID (class_ref, "setMediaItem", "(Landroidx/media3/common/MediaItem;Z)V");
			JValue* __args = stackalloc JValue [2];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			__args [1] = new JValue (p1);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setMediaItem_Landroidx_media3_common_MediaItem_Z, __args);
		}

		static Delegate? cb_setMediaItem_Landroidx_media3_common_MediaItem_J;
#pragma warning disable 0169
		static Delegate GetSetMediaItem_Landroidx_media3_common_MediaItem_JHandler ()
		{
			if (cb_setMediaItem_Landroidx_media3_common_MediaItem_J == null)
				cb_setMediaItem_Landroidx_media3_common_MediaItem_J = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPLJ_V) n_SetMediaItem_Landroidx_media3_common_MediaItem_J);
			return cb_setMediaItem_Landroidx_media3_common_MediaItem_J;
		}

		static void n_SetMediaItem_Landroidx_media3_common_MediaItem_J (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, long p1)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.Common.MediaItem> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetMediaItem (p0, p1);
		}
#pragma warning restore 0169

		IntPtr id_setMediaItem_Landroidx_media3_common_MediaItem_J;
		public unsafe void SetMediaItem (global::AndroidX.Media3.Common.MediaItem? p0, long p1)
		{
			if (id_setMediaItem_Landroidx_media3_common_MediaItem_J == IntPtr.Zero)
				id_setMediaItem_Landroidx_media3_common_MediaItem_J = JNIEnv.GetMethodID (class_ref, "setMediaItem", "(Landroidx/media3/common/MediaItem;J)V");
			JValue* __args = stackalloc JValue [2];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			__args [1] = new JValue (p1);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setMediaItem_Landroidx_media3_common_MediaItem_J, __args);
		}

		static Delegate? cb_setMediaItems_LSystem_Collections_Generic_IList_1_;
#pragma warning disable 0169
		static Delegate GetSetMediaItems_LSystem_Collections_Generic_IList_1_Handler ()
		{
			if (cb_setMediaItems_LSystem_Collections_Generic_IList_1_ == null)
				cb_setMediaItems_LSystem_Collections_Generic_IList_1_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_SetMediaItems_LSystem_Collections_Generic_IList_1_);
			return cb_setMediaItems_LSystem_Collections_Generic_IList_1_;
		}

		static void n_SetMediaItems_LSystem_Collections_Generic_IList_1_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			// var p0 = (/* global::System.Collections.Generic.IList`1 */ global::System.Collections.Generic.IList<global::AndroidX.Media3.ExoPlayer.Source.IMediaSource>?)global::Java.Lang.Object.GetObject</* global::System.Collections.Generic.IList`1 */ global::System.Collections.Generic.IList<global::AndroidX.Media3.ExoPlayer.Source.IMediaSource>> (native_p0, JniHandleOwnership.DoNotTransfer);
			var p0 = (/* global::System.Collections.Generic.IList`1 */ global::System.Collections.Generic.IList<global::AndroidX.Media3.Common.MediaItem>?)global::Java.Lang.Object.GetObject</* global::System.Collections.Generic.IList`1 */ Java.Lang.Object> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetMediaItems (p0);
		}
#pragma warning restore 0169

		IntPtr id_setMediaItems_LSystem_Collections_Generic_IList_1_;
		// public unsafe void SetMediaItems (/* global::System.Collections.Generic.IList`1 */ global::System.Collections.Generic.IList<global::AndroidX.Media3.ExoPlayer.Source.IMediaSource>? p0)
		public unsafe void SetMediaItems (/* global::System.Collections.Generic.IList`1 */ global::System.Collections.Generic.IList<global::AndroidX.Media3.Common.MediaItem>? p0)
		{
			if (id_setMediaItems_LSystem_Collections_Generic_IList_1_ == IntPtr.Zero)
				id_setMediaItems_LSystem_Collections_Generic_IList_1_ = JNIEnv.GetMethodID (class_ref, "setMediaItems", "(LSystem/Collections/Generic/IList`1;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setMediaItems_LSystem_Collections_Generic_IList_1_, __args);
		}

		static Delegate? cb_setPlaybackSpeed_F;
#pragma warning disable 0169
		static Delegate GetSetPlaybackSpeed_FHandler ()
		{
			if (cb_setPlaybackSpeed_F == null)
				cb_setPlaybackSpeed_F = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPF_V) n_SetPlaybackSpeed_F);
			return cb_setPlaybackSpeed_F;
		}

		static void n_SetPlaybackSpeed_F (IntPtr jnienv, IntPtr native__this, float p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.SetPlaybackSpeed (p0);
		}
#pragma warning restore 0169

		IntPtr id_setPlaybackSpeed_F;
		public unsafe void SetPlaybackSpeed (float p0)
		{
			if (id_setPlaybackSpeed_F == IntPtr.Zero)
				id_setPlaybackSpeed_F = JNIEnv.GetMethodID (class_ref, "setPlaybackSpeed", "(F)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setPlaybackSpeed_F, __args);
		}

		static Delegate? cb_setVideoSurface_Landroid_view_Surface_;
#pragma warning disable 0169
		static Delegate GetSetVideoSurface_Landroid_view_Surface_Handler ()
		{
			if (cb_setVideoSurface_Landroid_view_Surface_ == null)
				cb_setVideoSurface_Landroid_view_Surface_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_SetVideoSurface_Landroid_view_Surface_);
			return cb_setVideoSurface_Landroid_view_Surface_;
		}

		static void n_SetVideoSurface_Landroid_view_Surface_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = global::Java.Lang.Object.GetObject<global::Android.Views.Surface> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetVideoSurface (p0);
		}
#pragma warning restore 0169

		IntPtr id_setVideoSurface_Landroid_view_Surface_;
		public unsafe void SetVideoSurface (global::Android.Views.Surface? p0)
		{
			if (id_setVideoSurface_Landroid_view_Surface_ == IntPtr.Zero)
				id_setVideoSurface_Landroid_view_Surface_ = JNIEnv.GetMethodID (class_ref, "setVideoSurface", "(Landroid/view/Surface;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setVideoSurface_Landroid_view_Surface_, __args);
		}

		static Delegate? cb_setVideoSurfaceHolder_Landroid_view_SurfaceHolder_;
#pragma warning disable 0169
		static Delegate GetSetVideoSurfaceHolder_Landroid_view_SurfaceHolder_Handler ()
		{
			if (cb_setVideoSurfaceHolder_Landroid_view_SurfaceHolder_ == null)
				cb_setVideoSurfaceHolder_Landroid_view_SurfaceHolder_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_SetVideoSurfaceHolder_Landroid_view_SurfaceHolder_);
			return cb_setVideoSurfaceHolder_Landroid_view_SurfaceHolder_;
		}

		static void n_SetVideoSurfaceHolder_Landroid_view_SurfaceHolder_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = (global::Android.Views.ISurfaceHolder?)global::Java.Lang.Object.GetObject<global::Android.Views.ISurfaceHolder> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetVideoSurfaceHolder (p0);
		}
#pragma warning restore 0169

		IntPtr id_setVideoSurfaceHolder_Landroid_view_SurfaceHolder_;
		public unsafe void SetVideoSurfaceHolder (global::Android.Views.ISurfaceHolder? p0)
		{
			if (id_setVideoSurfaceHolder_Landroid_view_SurfaceHolder_ == IntPtr.Zero)
				id_setVideoSurfaceHolder_Landroid_view_SurfaceHolder_ = JNIEnv.GetMethodID (class_ref, "setVideoSurfaceHolder", "(Landroid/view/SurfaceHolder;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setVideoSurfaceHolder_Landroid_view_SurfaceHolder_, __args);
		}

		static Delegate? cb_setVideoSurfaceView_Landroid_view_SurfaceView_;
#pragma warning disable 0169
		static Delegate GetSetVideoSurfaceView_Landroid_view_SurfaceView_Handler ()
		{
			if (cb_setVideoSurfaceView_Landroid_view_SurfaceView_ == null)
				cb_setVideoSurfaceView_Landroid_view_SurfaceView_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_SetVideoSurfaceView_Landroid_view_SurfaceView_);
			return cb_setVideoSurfaceView_Landroid_view_SurfaceView_;
		}

		static void n_SetVideoSurfaceView_Landroid_view_SurfaceView_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = global::Java.Lang.Object.GetObject<global::Android.Views.SurfaceView> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetVideoSurfaceView (p0);
		}
#pragma warning restore 0169

		IntPtr id_setVideoSurfaceView_Landroid_view_SurfaceView_;
		public unsafe void SetVideoSurfaceView (global::Android.Views.SurfaceView? p0)
		{
			if (id_setVideoSurfaceView_Landroid_view_SurfaceView_ == IntPtr.Zero)
				id_setVideoSurfaceView_Landroid_view_SurfaceView_ = JNIEnv.GetMethodID (class_ref, "setVideoSurfaceView", "(Landroid/view/SurfaceView;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setVideoSurfaceView_Landroid_view_SurfaceView_, __args);
		}

		static Delegate? cb_setVideoTextureView_Landroid_view_TextureView_;
#pragma warning disable 0169
		static Delegate GetSetVideoTextureView_Landroid_view_TextureView_Handler ()
		{
			if (cb_setVideoTextureView_Landroid_view_TextureView_ == null)
				cb_setVideoTextureView_Landroid_view_TextureView_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_V) n_SetVideoTextureView_Landroid_view_TextureView_);
			return cb_setVideoTextureView_Landroid_view_TextureView_;
		}

		static void n_SetVideoTextureView_Landroid_view_TextureView_ (IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			var p0 = global::Java.Lang.Object.GetObject<global::Android.Views.TextureView> (native_p0, JniHandleOwnership.DoNotTransfer);
			__this.SetVideoTextureView (p0);
		}
#pragma warning restore 0169

		IntPtr id_setVideoTextureView_Landroid_view_TextureView_;
		public unsafe void SetVideoTextureView (global::Android.Views.TextureView? p0)
		{
			if (id_setVideoTextureView_Landroid_view_TextureView_ == IntPtr.Zero)
				id_setVideoTextureView_Landroid_view_TextureView_ = JNIEnv.GetMethodID (class_ref, "setVideoTextureView", "(Landroid/view/TextureView;)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((p0 == null) ? IntPtr.Zero : ((global::Java.Lang.Object) p0).Handle);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_setVideoTextureView_Landroid_view_TextureView_, __args);
		}

		static Delegate? cb_stop;
#pragma warning disable 0169
		static Delegate GetStopHandler ()
		{
			if (cb_stop == null)
				cb_stop = JNINativeWrapper.CreateDelegate ((_JniMarshal_PP_V) n_Stop);
			return cb_stop;
		}

		static void n_Stop (IntPtr jnienv, IntPtr native__this)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.Stop ();
		}
#pragma warning restore 0169

		IntPtr id_stop;
		public unsafe void Stop ()
		{
			if (id_stop == IntPtr.Zero)
				id_stop = JNIEnv.GetMethodID (class_ref, "stop", "()V");
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_stop);
		}

		static Delegate? cb_stop_Z;
#pragma warning disable 0169
		[Obsolete]
		static Delegate GetStop_ZHandler ()
		{
			if (cb_stop_Z == null)
				cb_stop_Z = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPZ_V) n_Stop_Z);
			return cb_stop_Z;
		}

		[Obsolete]
		static void n_Stop_Z (IntPtr jnienv, IntPtr native__this, bool p0)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Media3.ExoPlayer.IExoPlayer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer)!;
			__this.Stop (p0);
		}
#pragma warning restore 0169

		IntPtr id_stop_Z;
		public unsafe void Stop (bool p0)
		{
			if (id_stop_Z == IntPtr.Zero)
				id_stop_Z = JNIEnv.GetMethodID (class_ref, "stop", "(Z)V");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue (p0);
			JNIEnv.CallVoidMethod (((global::Java.Lang.Object) this).Handle, id_stop_Z, __args);
		}

	}
}
