using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace Kotlin 
{
	// Metadata.xml XPath class reference: path="/api/package[@name='kotlin']/class[@name='ULongArray']"
	// [global::Android.Runtime.Register ("kotlin/ULongArray", DoNotGenerateAcw=true)]
	public sealed partial class ULongArray // : global::Java.Lang.Object, global::Kotlin.Jvm.Internal.Markers.IKMappedMarker 
    {
		// Metadata.xml XPath method reference: path="/api/package[@name='kotlin']/class[@name='ULongArray']/method[@name='contains-VKZWuLQ' and count(parameter)=1 and parameter[1][@type='ulong']]"
		[Register ("contains-VKZWuLQ", "(J)Z", "")]
		public unsafe bool Contains (ulong? element)
		{
			const string __id = "contains-VKZWuLQ.(J)Z";
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [1];
				__args [0] = new JniArgumentValue (element.Value);
				var __rm = _members.InstanceMethods.InvokeNonvirtualBooleanMethod (__id, this, __args);
				return __rm;
			} finally {
			}
		}
    }
}