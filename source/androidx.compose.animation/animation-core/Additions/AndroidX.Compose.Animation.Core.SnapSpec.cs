using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Compose.Animation.Core 
{
	// Metadata.xml XPath class reference: path="/api/package[@name='androidx.compose.animation.core']/class[@name='SnapSpec']"
	// [global::Android.Runtime.Register ("androidx/compose/animation/core/SnapSpec", DoNotGenerateAcw=true)]
	// [global::Java.Interop.JavaTypeParameters (new string [] {"T"})]
	public sealed partial class SnapSpec //: global::Java.Lang.Object, global::AndroidX.Compose.Animation.Core.IDurationBasedAnimationSpec 
    {
		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.compose.animation.core']/class[@name='SnapSpec']/method[@name='vectorize' and count(parameter)=1 and parameter[1][@type='androidx.compose.animation.core.TwoWayConverter&lt;T, V&gt;']]"
		[Register ("vectorize", "(Landroidx/compose/animation/core/TwoWayConverter;)Landroidx/compose/animation/core/VectorizedDurationBasedAnimationSpec;", "")]
		[global::Java.Interop.JavaTypeParameters (new string [] {"V extends androidx.compose.animation.core.AnimationVector"})]
		public unsafe global::Java.Lang.Object Vectorize (global::AndroidX.Compose.Animation.Core.ITwoWayConverter converter)
		{
			const string __id = "vectorize.(Landroidx/compose/animation/core/TwoWayConverter;)Landroidx/compose/animation/core/VectorizedDurationBasedAnimationSpec;";
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [1];
				__args [0] = new JniArgumentValue ((converter == null) ? IntPtr.Zero : ((global::Java.Lang.Object) converter).Handle);
				var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod (__id, this, __args);
				return (Java.Lang.Object) global::Java.Lang.Object.GetObject<global::AndroidX.Compose.Animation.Core.IVectorizedDurationBasedAnimationSpec> (__rm.Handle, JniHandleOwnership.TransferLocalRef);
			} finally {
				global::System.GC.KeepAlive (converter);
			}
		}
    }
}