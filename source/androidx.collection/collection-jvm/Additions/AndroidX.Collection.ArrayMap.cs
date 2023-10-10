using System;
using System.Linq;

namespace AndroidX.Collection
{
	public partial class ArrayMap
	{
		public System.Collections.ICollection EntrySet()
		{
			return (System.Collections.ICollection)this._EntrySet();
		}
	}
}
