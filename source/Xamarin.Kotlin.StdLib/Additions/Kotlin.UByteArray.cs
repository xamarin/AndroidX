using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace Kotlin 
{
	// Metadata.xml XPath class reference: path="/api/package[@name='kotlin']/class[@name='UByteArray']"
	// [global::Android.Runtime.Register ("kotlin/UByteArray", DoNotGenerateAcw=true)]
	public sealed partial class UByteArray // : global::Java.Lang.Object, global::Kotlin.Jvm.Internal.Markers.IKMappedMarker 
    {
		// Metadata.xml XPath method reference: path="/api/package[@name='kotlin']/class[@name='UByteArray']/method[@name='contains-7apg3OU' and count(parameter)=1 and parameter[1][@type='ubyte']]"
		[Register ("contains-7apg3OU", "(B)Z", "")]
		public unsafe bool Contains (byte? element)
		{
			const string __id = "contains-7apg3OU.(B)Z";
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