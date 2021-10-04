using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Compose.Animation.Core {

	// Metadata.xml XPath interface reference: path="/api/package[@name='androidx.compose.animation.core']/interface[@name='DecayAnimationSpec']"
	[Register ("androidx/compose/animation/core/DecayAnimationSpec", "", "AndroidX.Compose.Animation.Core.IDecayAnimationSpecInvoker")]
	[global::Java.Interop.JavaTypeParameters (new string [] {"T"})]
	public partial interface IDecayAnimationSpec : IJavaObject, IJavaPeerable {
		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.compose.animation.core']/interface[@name='DecayAnimationSpec']/method[@name='vectorize' and count(parameter)=1 and parameter[1][@type='androidx.compose.animation.core.TwoWayConverter&lt;T, V&gt;']]"
		[Register ("vectorize", "(Landroidx/compose/animation/core/TwoWayConverter;)Landroidx/compose/animation/core/VectorizedDecayAnimationSpec;", "GetVectorize_Landroidx_compose_animation_core_TwoWayConverter_Handler:AndroidX.Compose.Animation.Core.IDecayAnimationSpecInvoker, Xamarin.AndroidX.Compose.Animation.Animation.Core")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"V extends androidx.compose.animation.core.AnimationVector"})]
		global::Java.Lang.Object Vectorize (global::AndroidX.Compose.Animation.Core.ITwoWayConverter typeConverter);

	}

	[global::Android.Runtime.Register ("androidx/compose/animation/core/DecayAnimationSpec", DoNotGenerateAcw=true)]
	internal partial class IDecayAnimationSpecInvoker : global::Java.Lang.Object, IDecayAnimationSpec {
	    
		static readonly JniPeerMembers _members = new XAPeerMembers ("androidx/compose/animation/core/DecayAnimationSpec", typeof (IDecayAnimationSpecInvoker));

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

		public static IDecayAnimationSpec GetObject (IntPtr handle, JniHandleOwnership transfer)
		{
			return global::Java.Lang.Object.GetObject<IDecayAnimationSpec> (handle, transfer);
		}

		static IntPtr Validate (IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf (handle, java_class_ref))
				throw new InvalidCastException ($"Unable to convert instance of type '{JNIEnv.GetClassNameFromInstance (handle)}' to type 'androidx.compose.animation.core.DecayAnimationSpec'.");
			return handle;
		}

		protected override void Dispose (bool disposing)
		{
			if (this.class_ref != IntPtr.Zero)
				JNIEnv.DeleteGlobalRef (this.class_ref);
			this.class_ref = IntPtr.Zero;
			base.Dispose (disposing);
		}

		public IDecayAnimationSpecInvoker (IntPtr handle, JniHandleOwnership transfer) : base (Validate (handle), transfer)
		{
			IntPtr local_ref = JNIEnv.GetObjectClass (((global::Java.Lang.Object) this).Handle);
			this.class_ref = JNIEnv.NewGlobalRef (local_ref);
			JNIEnv.DeleteLocalRef (local_ref);
		}

		static Delegate cb_vectorize_Landroidx_compose_animation_core_TwoWayConverter_;
#pragma warning disable 0169
		static Delegate GetVectorize_Landroidx_compose_animation_core_TwoWayConverter_Handler ()
		{
			if (cb_vectorize_Landroidx_compose_animation_core_TwoWayConverter_ == null)
				cb_vectorize_Landroidx_compose_animation_core_TwoWayConverter_ = JNINativeWrapper.CreateDelegate ((_JniMarshal_PPL_L) n_Vectorize_Landroidx_compose_animation_core_TwoWayConverter_);
			return cb_vectorize_Landroidx_compose_animation_core_TwoWayConverter_;
		}

		static IntPtr n_Vectorize_Landroidx_compose_animation_core_TwoWayConverter_ (IntPtr jnienv, IntPtr native__this, IntPtr native_typeConverter)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Compose.Animation.Core.IDecayAnimationSpec> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			var typeConverter = (global::AndroidX.Compose.Animation.Core.ITwoWayConverter)global::Java.Lang.Object.GetObject<global::AndroidX.Compose.Animation.Core.ITwoWayConverter> (native_typeConverter, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.Vectorize (typeConverter));
			return __ret;
		}
#pragma warning restore 0169

		IntPtr id_vectorize_Landroidx_compose_animation_core_TwoWayConverter_;
		public unsafe global::Java.Lang.Object Vectorize (global::AndroidX.Compose.Animation.Core.ITwoWayConverter typeConverter)
		{
			if (id_vectorize_Landroidx_compose_animation_core_TwoWayConverter_ == IntPtr.Zero)
				id_vectorize_Landroidx_compose_animation_core_TwoWayConverter_ = JNIEnv.GetMethodID (class_ref, "vectorize", "(Landroidx/compose/animation/core/TwoWayConverter;)Landroidx/compose/animation/core/VectorizedDecayAnimationSpec;");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((typeConverter == null) ? IntPtr.Zero : ((global::Java.Lang.Object) typeConverter).Handle);
			var __ret = (Java.Lang.Object) global::Java.Lang.Object.GetObject<global::AndroidX.Compose.Animation.Core.IVectorizedDecayAnimationSpec> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_vectorize_Landroidx_compose_animation_core_TwoWayConverter_, __args), JniHandleOwnership.TransferLocalRef);
			return __ret;
		}

	}
}
