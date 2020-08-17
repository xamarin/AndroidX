using System;
using System.Collections;
using Android.Runtime;

namespace AndroidX.Core.Text
{
	public partial class PrecomputedTextCompat
	{
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public System.Collections.Generic.IEnumerator<char> GetEnumerator()
		{
			// TODO: Fix
			throw new NotImplementedException();
		}
	}
}
