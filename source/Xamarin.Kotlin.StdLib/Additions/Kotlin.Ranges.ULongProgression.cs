using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace Kotlin.Ranges 
{
	// Metadata.xml XPath class reference: path="/api/package[@name='kotlin.ranges']/class[@name='ULongProgression']"
	// [global::Android.Runtime.Register ("kotlin/ranges/ULongProgression", DoNotGenerateAcw=true)]
	public partial class ULongProgression // : global::Java.Lang.Object, global::Java.Lang.IIterable, global::Kotlin.Jvm.Internal.Markers.IKMappedMarker 
    {
			// Metadata.xml XPath method reference: path="/api/package[@name='kotlin.ranges']/class[@name='ULongProgression.Companion']/method[@name='fromClosedRange-7ftBX0g' and count(parameter)=3 and parameter[1][@type='ulong'] and parameter[2][@type='ulong'] and parameter[3][@type='long']]"
			[Register ("fromClosedRange-7ftBX0g", "(JJJ)Lkotlin/ranges/ULongProgression;", "")]
			public unsafe global::Kotlin.Ranges.ULongProgression FromClosedRange (ulong? rangeStart, ulong? rangeEnd, long step)
			{
				const string __id = "fromClosedRange-7ftBX0g.(JJJ)Lkotlin/ranges/ULongProgression;";
				try {
					JniArgumentValue* __args = stackalloc JniArgumentValue [3];
					__args [0] = new JniArgumentValue (rangeStart.Value);
					__args [1] = new JniArgumentValue (rangeEnd.Value);
					__args [2] = new JniArgumentValue (step);
					var __rm = _members.InstanceMethods.InvokeNonvirtualObjectMethod (__id, this, __args);
					return global::Java.Lang.Object.GetObject<global::Kotlin.Ranges.ULongProgression> (__rm.Handle, JniHandleOwnership.TransferLocalRef)!;
				} finally {
				}
			}
    }
}