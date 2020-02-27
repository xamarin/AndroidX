using System;
using System.Collections.Generic;
using System.IO;

namespace Xamarin.AndroidX.Migration
{
	public class AndroidXAssembliesCsvMapping : CsvMapping
	{
		private readonly SortedDictionary<string, string> assemblyMapping = new SortedDictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		private readonly SortedDictionary<string, string> packageMapping = new SortedDictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		private readonly SortedDictionary<string, string> versionMapping = new SortedDictionary<string, string>(StringComparer.OrdinalIgnoreCase);

		public AndroidXAssembliesCsvMapping()
		{
			LoadMapping(Resources.AssembliesMappingPath);
		}

		public AndroidXAssembliesCsvMapping(string mappingFile)
			: base(mappingFile)
		{
		}

		public AndroidXAssembliesCsvMapping(Stream csv)
			: base(csv)
		{
		}

		protected override void OnLoadRecord(string[] record)
		{
			if (record.Length < (int)Column.AndroidXNuGet)
				return;

			var supportAssembly = record[(int)Column.SupportNetAssembly];
			var xAssembly = record[(int)Column.AndroidXNetAssembly];
			var xPackage = record[(int)Column.AndroidXNuGet];
			var xVersion = record[(int)Column.AndroidXVersion];

			if (string.IsNullOrWhiteSpace(supportAssembly) ||
				string.IsNullOrWhiteSpace(xAssembly) ||
				string.IsNullOrWhiteSpace(xPackage) ||
				string.IsNullOrWhiteSpace(xVersion))
				return;

			assemblyMapping[supportAssembly] = xAssembly;
			packageMapping[xAssembly] = xPackage;
			versionMapping[xAssembly] = xVersion;
		}

		public bool TryGetAndroidXAssembly(string supportAssembly, out string xAssembly) =>
			assemblyMapping.TryGetValue(supportAssembly, out xAssembly);

		public bool TryGetAndroidXPackage(string xAssembly, out string xPackage) =>
			packageMapping.TryGetValue(xAssembly, out xPackage);

		public bool TryGetAndroidXVersion(string xAssembly, out string xVersion) =>
			versionMapping.TryGetValue(xAssembly, out xVersion);

		public bool ContainsSupportAssembly(string supportAssembly) =>
			assemblyMapping.ContainsKey(supportAssembly);

		public enum Column
		{
			SupportNetAssembly,
			AndroidXNetAssembly,
			SupportNuGet,
			AndroidXNuGet,
			AndroidXVersion
		}
	}
}
