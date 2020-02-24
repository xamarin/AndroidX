using System.IO;
using System.Reflection;

namespace Xamarin.AndroidX.Migration
{
	public static class Resources
	{
		private static readonly Assembly assembly = typeof(Resources).Assembly;

		private const string assemblyMapping = "Tools/Mappings/androidx-assemblies.csv";
		private const string typeMapping = "Tools/Mappings/androidx-mapping.csv";
		private const string javaMapping = "Tools/Mappings/androidx-class-mapping.csv";
		private const string mappingOverrides = "Tools/Mappings/override-mapping.csv";
		private const string dependencies = "Tools/Mappings/dependencies.json";
		private const string jetiferRoot = "Tools/JetifierWrapper/";

		public static string AssembliesMappingPath = GetFullPath(assemblyMapping);
		public static string TypesMappingFilePath = GetFullPath(typeMapping);
		public static string JavaClassMappingPath = GetFullPath(javaMapping);
		public static string MappingOverridesPath = GetFullPath(mappingOverrides);
		public static string DependenciesPath = GetFullPath(dependencies);
		public static string JetifierWrapperDirectory = GetFullPath(jetiferRoot);

		public static string JetifierWrapperJarPath = Path.Combine(JetifierWrapperDirectory, "JetifierWrapper.jar");
		public static string JetifierWrapperMain = "com.xamarin.androidx.jetifierWrapper.Main";

		public static string GetFullPath(string path) =>
			Path.Combine(Path.GetDirectoryName(assembly.Location), path);
	}
}
