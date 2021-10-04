using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Compose.Animation.Core {

	// Metadata.xml XPath interface reference: path="/api/package[@name='androidx.compose.animation.core']/interface[@name='FiniteAnimationSpec']"
	[Register ("androidx/compose/animation/core/FiniteAnimationSpec", "", "AndroidX.Compose.Animation.Core.IFiniteAnimationSpecInvoker")]
	[global::Java.Interop.JavaTypeParameters (new string [] {"T"})]
	public partial interface IFiniteAnimationSpec : global::AndroidX.Compose.Animation.Core.IAnimationSpec {
		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.compose.animation.core']/interface[@name='FiniteAnimationSpec']/method[@name='vectorize' and count(parameter)=1 and parameter[1][@type='androidx.compose.animation.core.TwoWayConverter&lt;T, V&gt;']]"
		[Register ("vectorize", "(Landroidx/compose/animation/core/TwoWayConverter;)Landroidx/compose/animation/core/VectorizedFiniteAnimationSpec;", "GetVectorize_Landroidx_compose_animation_core_TwoWayConverter_Handler:AndroidX.Compose.Animation.Core.IFiniteAnimationSpecInvoker, Xamarin.AndroidX.Compose.Animation.Animation.Core")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"V extends androidx.compose.animation.core.AnimationVector"})]
		global::Java.Lang.Object Vectorize (global::AndroidX.Compose.Animation.Core.ITwoWayConverter converter);

	}

	[global::Android.Runtime.Register ("androidx/compose/animation/core/FiniteAnimationSpec", DoNotGenerateAcw=true)]
	internal partial class IFiniteAnimationSpecInvoker : global::Java.Lang.Object, IFiniteAnimationSpec {
		static readonly JniPeerMembers _members = new XAPeerMembers ("androidx/compose/animation/core/FiniteAnimationSpec", typeof (IFiniteAnimationSpecInvoker));

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

		public static IFiniteAnimationSpec GetObject (IntPtr handle, JniHandleOwnership transfer)
		{
			return global::Java.Lang.Object.GetObject<IFiniteAnimationSpec> (handle, transfer);
		}

		static IntPtr Validate (IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf (handle, java_class_ref))
				throw new InvalidCastException ($"Unable to convert instance of type '{JNIEnv.GetClassNameFromInstance (handle)}' to type 'androidx.compose.animation.core.FiniteAnimationSpec'.");
			return handle;
		}

		protected override void Dispose (bool disposing)
		{
			if (this.class_ref != IntPtr.Zero)
				JNIEnv.DeleteGlobalRef (this.class_ref);
			this.class_ref = IntPtr.Zero;
			base.Dispose (disposing);
		}

		public IFiniteAnimationSpecInvoker (IntPtr handle, JniHandleOwnership transfer) : base (Validate (handle), transfer)
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

		static IntPtr n_Vectorize_Landroidx_compose_animation_core_TwoWayConverter_ (IntPtr jnienv, IntPtr native__this, IntPtr native_converter)
		{
			var __this = global::Java.Lang.Object.GetObject<global::AndroidX.Compose.Animation.Core.IFiniteAnimationSpec> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			var converter = (global::AndroidX.Compose.Animation.Core.ITwoWayConverter)global::Java.Lang.Object.GetObject<global::AndroidX.Compose.Animation.Core.ITwoWayConverter> (native_converter, JniHandleOwnership.DoNotTransfer);
			IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.Vectorize (converter));
			return __ret;
		}
#pragma warning restore 0169

		IntPtr id_vectorize_Landroidx_compose_animation_core_TwoWayConverter_;
		public unsafe global::Java.Lang.Object Vectorize (global::AndroidX.Compose.Animation.Core.ITwoWayConverter converter)
		{
			if (id_vectorize_Landroidx_compose_animation_core_TwoWayConverter_ == IntPtr.Zero)
				id_vectorize_Landroidx_compose_animation_core_TwoWayConverter_ = JNIEnv.GetMethodID (class_ref, "vectorize", "(Landroidx/compose/animation/core/TwoWayConverter;)Landroidx/compose/animation/core/VectorizedFiniteAnimationSpec;");
			JValue* __args = stackalloc JValue [1];
			__args [0] = new JValue ((converter == null) ? IntPtr.Zero : ((global::Java.Lang.Object) converter).Handle);
			var __ret = (Java.Lang.Object) global::Java.Lang.Object.GetObject<global::AndroidX.Compose.Animation.Core.IVectorizedFiniteAnimationSpec> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object) this).Handle, id_vectorize_Landroidx_compose_animation_core_TwoWayConverter_, __args), JniHandleOwnership.TransferLocalRef);
			return __ret;
		}

	}
}
