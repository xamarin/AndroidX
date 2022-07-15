using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace Kotlin.Ranges 
{
	// Metadata.xml XPath class reference: path="/api/package[@name='kotlin.ranges']/class[@name='UIntProgression']"
	// [global::Android.Runtime.Register ("kotlin/ranges/UIntProgression", DoNotGenerateAcw=true)]
	public partial class UIntProgression // : global::Java.Lang.Object, global::Java.Lang.IIterable, global::Kotlin.Jvm.Internal.Markers.IKMappedMarker 
    {
			// Metadata.xml XPath method reference: path="/api/package[@name='kotlin.ranges']/class[@name='UIntProgression.Companion']/method[@name='fromClosedRange-Nkh28Cs' and count(parameter)=3 and parameter[1][@type='uint'] and parameter[2][@type='uint'] and parameter[3][@type='int']]"
			[Register ("fromClosedRange-Nkh28Cs", "(III)Lkotlin/ranges/UIntProgression;", "")]
			public unsafe global::Kotlin.Ranges.UIntProgression FromClosedRange (uint? rangeStart, uint? rangeEnd, int step)
			{
				const string __id = "fromClosedRange-Nkh28Cs.(III)Lkotlin/ranges/UIntProgression;";
				try {
					JniArgumentValue* __args = stackalloc JniArgumentValue [3];
					__args [0] = new JniArgumentValue (rangeStart.Value);
					__args [1] = new JniArgumentValue (rangeEnd.Value);
					__args [2] = new JniArgumentValue (step);
					var __rm = _members.InstanceMethods.InvokeNonvirtualObjectMethod (__id, this, __args);
					return global::Java.Lang.Object.GetObject<global::Kotlin.Ranges.UIntProgression> (__rm.Handle, JniHandleOwnership.TransferLocalRef)!;
				} finally {
				}
			}
    }
}