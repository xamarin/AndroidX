using System.Collections.Generic;

namespace AndroidXMapper
{
	public struct BindingType
	{
		public static BindingType Empty = new BindingType(FullType.Empty, FullType.Empty);

		public FullType NetType;
		public FullType JavaType;

		public BindingType(FullType netType, FullType javaType)
		{
			NetType = netType;
			JavaType = javaType;
		}

		public override bool Equals(object obj) =>
			obj is BindingType other &&
			EqualityComparer<FullType>.Default.Equals(NetType, other.NetType) &&
			EqualityComparer<FullType>.Default.Equals(JavaType, other.JavaType);

		public override int GetHashCode() =>
			(NetType, JavaType).GetHashCode();

		public override string ToString() =>
			$"{NetType} ({JavaType})";

		public void Deconstruct(out FullType netType, out FullType javaType)
		{
			netType = NetType;
			javaType = JavaType;
		}

		public static implicit operator (FullType NetType, FullType JavaType) (BindingType value) =>
			(value.NetType, value.JavaType);

		public static implicit operator BindingType((FullType NetType, FullType JavaType) value) =>
			new BindingType(value.NetType, value.JavaType);
	}
}
