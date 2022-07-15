using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace Kotlin 
{
	// Metadata.xml XPath class reference: path="/api/package[@name='kotlin']/class[@name='UShortArray']"
	// [global::Android.Runtime.Register ("kotlin/UShortArray", DoNotGenerateAcw=true)]
	public sealed partial class UShortArray // : global::Java.Lang.Object, global::Kotlin.Jvm.Internal.Markers.IKMappedMarker 
    {
		// Metadata.xml XPath method reference: path="/api/package[@name='kotlin']/class[@name='UShortArray']/method[@name='contains-xj2QHRw' and count(parameter)=1 and parameter[1][@type='ushort']]"
		[Register ("contains-xj2QHRw", "(S)Z", "")]
		public unsafe bool Contains (ushort? element)
		{
			const string __id = "contains-xj2QHRw.(S)Z";
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