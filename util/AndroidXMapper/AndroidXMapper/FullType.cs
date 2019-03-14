namespace AndroidXMapper
{
	public struct FullType
	{
		public static FullType Empty = new FullType(string.Empty, string.Empty, string.Empty);

		public string Container;
		public string Namespace;
		public string Name;

		public FullType(string ns, string n)
		{
			Container = string.Empty;
			Namespace = ns;
			Name = n;
		}

		public FullType(string container, string ns, string n)
		{
			Container = container;
			Namespace = ns;
			Name = n;
		}

		public string FullName =>
			$"{Namespace}.{Name}";

		public bool IsEmpty =>
			string.IsNullOrEmpty(Namespace) || string.IsNullOrEmpty(Name);

		public override bool Equals(object obj) =>
			obj is FullType other && Container == other.Container && Namespace == other.Namespace && Name == other.Name;

		public override int GetHashCode() =>
			(Container, Namespace, Name).GetHashCode();

		public override string ToString() =>
			FullName;

		public void Deconstruct(out string c, out string ns, out string n)
		{
			c = Container;
			ns = Namespace;
			n = Name;
		}

		public static implicit operator (string Container, string Namespace, string Name) (FullType value) =>
			(value.Container, value.Namespace, value.Name);

		public static implicit operator FullType((string Container, string Namespace, string Name) value) =>
			new FullType(value.Container, value.Namespace, value.Name);
	}
}
