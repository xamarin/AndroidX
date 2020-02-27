namespace Xamarin.AndroidX.Migration
{
	public struct MigrationPair
	{
		public readonly string Source;
		public readonly string Destination;

		public MigrationPair(string source, string destination)
		{
			Source = source;
			Destination = destination;
		}

		public override bool Equals(object obj) =>
			obj is MigrationPair other &&
			Source == other.Source &&
			Destination == other.Destination;

		public override int GetHashCode() =>
			(Source, Destination).GetHashCode();

		public override string ToString() =>
			$"{Source} => {Destination}";

		public void Deconstruct(out string source, out string destination)
		{
			source = Source;
			destination = Destination;
		}

		public static implicit operator (string Source, string Destination) (MigrationPair value) =>
			(value.Source, value.Destination);

		public static implicit operator MigrationPair((string Source, string Destination) value) =>
			new MigrationPair(value.Source, value.Destination);
	}
}
