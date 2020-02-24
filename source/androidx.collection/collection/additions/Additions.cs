using System;
using System.Linq;

namespace AndroidX.Collection
{
	public partial class ArraySet
	{
		public void Append(Java.Lang.Object value)
			=> Add(value);
	}
	
	public partial class ArrayMap
	{
		public System.Collections.ICollection EntrySet()
		{
			return (System.Collections.ICollection)this._EntrySet();
		}
	}
}
