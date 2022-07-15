using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace Kotlin.Ranges 
{
	// Metadata.xml XPath class reference: path="/api/package[@name='kotlin.ranges']/class[@name='UIntRange']"
	// [global::Android.Runtime.Register ("kotlin/ranges/UIntRange", DoNotGenerateAcw=true)]
	public sealed partial class UIntRange // : global::Kotlin.Ranges.UIntProgression 
    {
		// Metadata.xml XPath method reference: path="/api/package[@name='kotlin.ranges']/class[@name='UIntRange']/method[@name='contains-WZ4Q5Ns' and count(parameter)=1 and parameter[1][@type='uint']]"
		[Register ("contains-WZ4Q5Ns", "(I)Z", "")]
		public unsafe bool Contains (uint? value)
		{
			const string __id = "contains-WZ4Q5Ns.(I)Z";
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