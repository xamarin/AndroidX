using System.Collections.Generic;

namespace AndroidXMapper
{
	public struct TypeMapping
	{
		public BindingType SupportType;
		public BindingType AndroidXType;

		public TypeMapping(BindingType supportType, BindingType androidXType)
		{
			SupportType = supportType;
			AndroidXType = androidXType;
		}

		public override bool Equals(object obj) =>
			obj is TypeMapping other &&
			EqualityComparer<BindingType>.Default.Equals(SupportType, other.SupportType) &&
			EqualityComparer<BindingType>.Default.Equals(AndroidXType, other.AndroidXType);

		public override int GetHashCode() =>
			(SupportType, AndroidXType).GetHashCode();

		public override string ToString() =>
			$"{SupportType} => {AndroidXType}";

		public void Deconstruct(out BindingType supportType, out BindingType androidXType)
		{
			supportType = SupportType;
			androidXType = AndroidXType;
		}

		public static implicit operator (BindingType SupportType, BindingType AndroidXType) (TypeMapping value) =>
			(value.SupportType, value.AndroidXType);

		public static implicit operator TypeMapping((BindingType SupportType, BindingType AndroidXType) value) =>
			new TypeMapping(value.SupportType, value.AndroidXType);
	}
}
