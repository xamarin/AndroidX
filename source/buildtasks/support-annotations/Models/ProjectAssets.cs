using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Xamarin.Android.Support.BuildTasks.Models
{
	[DataContract]
	[Serializable]
	public partial class ProjectAssets
	{
		[DataMember(Name="version")]
		public long Version { get; set; }

		[DataMember(Name = "targets")]
		public Dictionary<string, Dictionary<string, TargetReference>> Targets { get; set; }
	}

	[DataContract]
	[Serializable]
	public class TargetReference
	{
		[DataMember(Name = "type")]
		public string Type { get; set; }

		//[DataMember(Name = "dependencies")]
		//public Dictionary<string, string> Dependencies { get; set; } = new Dictionary<string, string>();

		//[DataMember(Name = "compile")]
		//public object Compile { get; set; }

		//[DataMember(Name = "runtime")]
		//public object Runtime { get; set; }

		//[DataMember(Name = "build")]
		//public object Build { get; set; }
	}
}
