using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace AndroidXMapper
{
	public class MappingGenerator
	{
		private readonly Dictionary<BindingType, BindingType> typeMappings = new Dictionary<BindingType, BindingType>();

		public string SupportApiPath { get; }

		public string AndroidXApiPath { get; }

		public string OverridesPath { get; }

		public string JavaMappingPath { get; }

		public MappingGenerator(string supportApiPath, string androidXApiPath, string overridesPath, string javaMappingPath)
		{
			SupportApiPath = supportApiPath ?? throw new ArgumentNullException(nameof(supportApiPath));
			AndroidXApiPath = androidXApiPath ?? throw new ArgumentNullException(nameof(androidXApiPath));
			OverridesPath = overridesPath;
			JavaMappingPath = javaMappingPath;
		}

		public void Generate(TextWriter writer, bool includeWarnings)
		{
			var supportTypes = GetAllTypes(SupportApiPath);
			var xTypes = GetAllTypes(AndroidXApiPath);
			var overrideMappings = LoadMapping(OverridesPath);
			var javaMappings = LoadMapping(JavaMappingPath);

			const string Prefix = ",,,,,,,,,";

			writer.WriteLine(
				"Support .NET namespace," +
				"Support .NET type name," +
				"AndroidX .NET namespace," +
				"AndroidX .NET type name," +
				"AndroidX .NET assembly," +
				"Support Java package," +
				"Support Java class," +
				"AndroidX Java package," +
				"AndroidX Java class," +
				"Messages");

			foreach (var supportType in supportTypes)
			{
				var useJavaType = !supportType.JavaType.IsEmpty && javaMappings.Count > 0;

				if (TryGetMapping(overrideMappings, supportType.NetType, out var overrideType))
				{
					var matched = xTypes.Where(t => t.NetType.FullName == overrideType).ToList();
					if (matched.Count == 1)
					{
						typeMappings[supportType] = matched[0];
					}
					else if (matched.Count > 1)
					{
						if (includeWarnings)
							writer.WriteLine($"{Prefix}WARNING: Too many override types found for type {overrideType}: {string.Join(", ", matched)}.");
					}
					else
					{
						if (includeWarnings)
							writer.WriteLine($"{Prefix}WARNING: Unable to find override type for type {overrideType}.");
					}
				}
				else if (TryGetExactMatch(xTypes, supportType, out var exactMatch))
				{
					typeMappings[supportType] = exactMatch;
				}
				else if (useJavaType && TryGetMapping(javaMappings, supportType.JavaType, out var androidx))
				{
					var matched = xTypes.Where(t => t.JavaType.FullName == androidx).ToList();

					// a special case for the XxxConsts types
					const string ConstsSuffix = "Consts";
					if (matched.Count == 2 && matched.Any(m => m.NetType.Name.EndsWith(ConstsSuffix)))
					{
						matched.RemoveAll(m => m.NetType.Name.EndsWith(ConstsSuffix) != supportType.NetType.Name.EndsWith(ConstsSuffix));
					}

					if (matched.Count == 1)
					{
						typeMappings[supportType] = matched[0];
					}
					else if (matched.Count > 1)
					{
						if (includeWarnings)
							writer.WriteLine($"{Prefix}WARNING: Too many AndroidX types found for Java type {androidx}: {string.Join(", ", matched)}.");
					}
					else
					{
						if (includeWarnings)
							writer.WriteLine($"{Prefix}WARNING: Unable to find AndroidX type for Java type {androidx}.");
					}
				}
				else
				{
					if (includeWarnings && useJavaType)
						writer.WriteLine($"{Prefix}WARNING: Unable to find a Java mapping for {supportType}. Trying managed mapping...");

					var matched = xTypes.Where(xt => xt.NetType.Name == supportType.NetType.Name).ToList();
					if (matched.Count == 1)
					{
						typeMappings[supportType] = matched[0];

						if (includeWarnings && useJavaType)
							writer.WriteLine($"{Prefix}WARNING:   Found a type that appears to match {matched[0]}.");
					}
					else if (matched.Count > 1)
					{
						if (includeWarnings)
							writer.WriteLine($"{Prefix}WARNING: Too many AndroidX types found for .NET type {supportType.NetType}: {string.Join(", ", matched)}.");
					}
					else
					{
						if (includeWarnings)
							writer.WriteLine($"{Prefix}WARNING: Unable to find AndroidX type for .NET type {supportType.NetType}.");
					}
				}

				if (typeMappings.TryGetValue(supportType, out var androidXType))
				{
					writer.WriteLine(
						$"{supportType.NetType.Namespace}," +
						$"{supportType.NetType.Name}," +
						$"{androidXType.NetType.Namespace}," +
						$"{androidXType.NetType.Name}," +
						$"{androidXType.NetType.Container}," +
						$"{supportType.JavaType.Namespace}," +
						$"{supportType.JavaType.Name}," +
						$"{androidXType.JavaType.Namespace}," +
						$"{androidXType.JavaType.Name},");
				}
			}
		}

		private bool TryGetExactMatch(IEnumerable<BindingType> xTypes, BindingType supportType, out BindingType exactMatch)
		{
			var netMatches = xTypes.Where(t => t.NetType.FullName == supportType.NetType.FullName).ToList();
			if (netMatches.Count == 1)
			{
				exactMatch = netMatches[0];
				return true;
			}

			var javaMatches = xTypes.Where(t => t.JavaType.FullName == supportType.JavaType.FullName).ToList();
			if (javaMatches.Count == 1)
			{
				exactMatch = javaMatches[0];
				return true;
			}

			exactMatch = BindingType.Empty;
			return false;
		}

		private bool TryGetMapping(Dictionary<string, string> mappings, FullType type, out string androidx)
		{
			if (mappings.TryGetValue(type.FullName, out androidx))
				return true;

			string nested = "";
			while (type.Name.Contains("."))
			{
				nested = type.Name.Substring(type.Name.LastIndexOf(".")) + nested;
				type.Name = type.Name.Substring(0, type.Name.LastIndexOf("."));

				if (mappings.TryGetValue(type.FullName, out androidx))
				{
					androidx += nested;
					return true;
				}
			}

			return false;
		}

		private Dictionary<string, string> LoadMapping(string mapping)
		{
			var dic = new Dictionary<string, string>();

			if (!string.IsNullOrWhiteSpace(mapping) && File.Exists(mapping))
			{
				var lines = File.ReadAllLines(mapping);
				foreach (var line in lines)
				{
					var parts = line.Split(',');
					dic.Add(parts[0], parts[1]);
				}
			}

			return dic;
		}

		private List<BindingType> GetAllTypes(string api)
		{
			if (string.IsNullOrWhiteSpace(api))
				throw new ArgumentException($"Invalid api.xml path: {api}", nameof(api));
			if (!File.Exists(api))
				throw new FileNotFoundException($"The api.xml does not exist: {api}");

			var xdoc = XDocument.Load(api);
			var classes = xdoc.Descendants("class");
			return classes.Select(GetFullType).ToList();
		}

		private BindingType GetFullType(XElement element)
		{
			var assembly = GetAttributeValue(element, "Xamarin.AndroidX.Internal.InjectedAssemblyNameAttribute", "AssemblyName");
			var ns = "";
			var name = element.Attribute("name").Value;
			var java = GetJavaType(element);

			var parent = element.Parent?.Parent;
			while (parent != null)
			{
				if (parent.Name == "class")
				{
					name = parent.Attribute("name").Value + "." + name;
					assembly = GetAttributeValue(parent, "Xamarin.AndroidX.Internal.InjectedAssemblyNameAttribute", "AssemblyName");
				}
				else if (parent.Name == "namespace")
				{
					ns = parent.Attribute("name").Value;
				}

				parent = parent.Parent?.Parent;
			}

			return new BindingType(new FullType(assembly, ns, name), java);
		}

		private static string GetAttributeValue(XElement element, string attributeType, string propertyName)
		{
			var attributeElement = element
				?.Element("attributes")
				?.Elements("attribute")
				?.FirstOrDefault(e => e.Attribute("name")?.Value == attributeType);

			var value = attributeElement
				?.Element("properties")
				?.Elements("property")
				?.FirstOrDefault(e => e.Attribute("name")?.Value == propertyName)
				?.Attribute("value")?.Value ?? string.Empty;

			return value;
		}

		private FullType GetJavaType(XElement element)
		{
			var javaType = GetAttributeValue(element, "Android.Runtime.RegisterAttribute", "Name");
			var parts = javaType?.Split('/');
			var type = parts?.LastOrDefault()?.Split('$');
			if (parts?.Length > 0 && type?.Length > 0)
				return new FullType(string.Join(".", parts.Take(parts.Length - 1)), string.Join(".", type));
			else
				return FullType.Empty;
		}
	}
}
