using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace Kotlin 
{
	// Metadata.xml XPath class reference: path="/api/package[@name='kotlin']/class[@name='UIntArray']"
	// [global::Android.Runtime.Register ("kotlin/UIntArray", DoNotGenerateAcw=true)]
	public sealed partial class UIntArray // : global::Java.Lang.Object, global::Kotlin.Jvm.Internal.Markers.IKMappedMarker 
    {
		// Metadata.xml XPath method reference: path="/api/package[@name='kotlin']/class[@name='UIntArray']/method[@name='contains-WZ4Q5Ns' and count(parameter)=1 and parameter[1][@type='uint']]"
		[Register ("contains-WZ4Q5Ns", "(I)Z", "")]
		public unsafe bool Contains (uint? element)
		{
			const string __id = "contains-WZ4Q5Ns.(I)Z";
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