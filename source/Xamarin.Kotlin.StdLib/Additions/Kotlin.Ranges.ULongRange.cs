using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace Kotlin.Ranges
{
	// Metadata.xml XPath class reference: path="/api/package[@name='kotlin.ranges']/class[@name='ULongRange']"
	// [global::Android.Runtime.Register ("kotlin/ranges/ULongRange", DoNotGenerateAcw=true)]
	public sealed partial class ULongRange // : global::Kotlin.Ranges.ULongProgression 
    {
		// Metadata.xml XPath method reference: path="/api/package[@name='kotlin.ranges']/class[@name='ULongRange']/method[@name='contains-VKZWuLQ' and count(parameter)=1 and parameter[1][@type='ulong']]"
		[Register ("contains-VKZWuLQ", "(J)Z", "")]
		public unsafe bool Contains (ulong? value)
		{
			const string __id = "contains-VKZWuLQ.(J)Z";
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [1];
				__args [0] = new JniArgumentValue (value.Value);
				var __rm = _members.InstanceMethods.InvokeNonvirtualBooleanMethod (__id, this, __args);
				return __rm;
			} finally {
			}
		}
    }
}