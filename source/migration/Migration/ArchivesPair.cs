using System.Collections.Generic;

namespace Xamarin.AndroidX.Migration
{
	public class ArchivesPair
	{
		public string Source { get; private set; }
		public IEnumerable<string> Archives { get; private set; }

		public ArchivesPair(string source, IEnumerable<string> archives)
		{
			Source = source;
			Archives = archives;
		}

		public override bool Equals(object obj) =>
			obj is ArchivesPair other &&
			Source == other.Source &&
			Archives == other.Archives;

		public override int GetHashCode() =>
			(Source, Archives).GetHashCode();

		public override string ToString() =>
			$"{Source} => {{\r\t{string.Join("\r\t", Archives)}\r}}";

		public void Deconstruct(out string source, out IEnumerable<string> archives)
		{
			source = Source;
			archives = Archives;
		}

		public static implicit operator (string Source, IEnumerable<string> Archives)(ArchivesPair value) =>
			(value.Source, value.Archives);

		public static implicit operator ArchivesPair((string Source, IEnumerable<string> Archives) value) =>
			new ArchivesPair(value.Source, value.Archives);
	}
}
