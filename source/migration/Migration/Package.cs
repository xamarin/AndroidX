using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Xamarin.AndroidX.Migration
{
	[DataContract]
	public class Package
	{
		public Package()
		{
		}

		public Package(string id)
		{
			Id = id;
		}

		[DataMember(Name = "id", Order = 0)]
		public string Id { get; set; }

		[DataMember(Name = "dependencies", Order = 1)]
		public List<string> Dependencies { get; set; } = new List<string>();

		public override string ToString() =>
			$"{Id}: {Dependencies?.Count ?? 0}";
	}
}
