using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AndroidXMapper
{
	public class MappingGenerator
	{
		private readonly List<TypeMapping> typeMappings = new List<TypeMapping>();

		public string SupportAssemblyPath { get; }

		public string AndroidXAssemblyPath { get; }

		public string OverridesPath { get; }

		public string JavaMappingPath { get; }

		public MappingGenerator(string supportAssemblyPath, string androidXAssemblyPath, string overridesPath, string javaMappingPath)
		{
			SupportAssemblyPath = supportAssemblyPath ?? throw new ArgumentNullException(nameof(supportAssemblyPath));
			AndroidXAssemblyPath = androidXAssemblyPath ?? throw new ArgumentNullException(nameof(androidXAssemblyPath));
			OverridesPath = overridesPath;
			JavaMappingPath = javaMappingPath;
		}

		public void Generate(TextWriter writer, bool includeWarnings)
		{
			// load all the types and mappings
			var supportTypes = GetAllTypes(SupportAssemblyPath);
			var xTypes = GetAllTypes(AndroidXAssemblyPath);
			var overrideMappings = LoadMapping(OverridesPath);
			var javaMappings = LoadMapping(JavaMappingPath);

			WriteRecord(
				writer,
				new BindingType(
					new FullType("Support .NET assembly", "Support .NET namespace", "Support .NET type name"),
					new FullType("Support Java package", "Support Java class")),
				new BindingType(
					new FullType("AndroidX .NET assembly", "AndroidX .NET namespace", "AndroidX .NET type name"),
					new FullType("AndroidX Java package", "AndroidX Java class")),
				"Messages");

			// PART A: Go through all the types in the Support assembly and
			//         try and find a matching AndroidX type.
			foreach (var supportType in supportTypes)
			{
				var useJavaType = !supportType.JavaType.IsEmpty && javaMappings.Count > 0;

				if (TryGetMapping(overrideMappings, supportType.NetType, out var overrideType))
				{
					// 1. First check the specific/manual overrides provided.

					var matched = xTypes.Where(t => t.NetType.FullName == overrideType).ToList();
					if (matched.Count == 0)
					{
						if (includeWarnings)
							WriteRecord(writer, $"WARNING: Unable to find override type for type {overrideType}.");
					}
					else
					{
						foreach (var m in matched)
						{
							typeMappings.Add(new TypeMapping(supportType, m));
							WriteRecord(writer, supportType, m);
						}
					}
				}
				else if (TryGetExactMatch(xTypes, supportType, out var exactMatch))
				{
					// 2. Then, check to see if there is an exact match for the
					//    full name of the .NET or Java type.

					typeMappings.Add(new TypeMapping(supportType, exactMatch));
					WriteRecord(writer, supportType, exactMatch);
				}
				else if (useJavaType && TryGetMapping(javaMappings, supportType.JavaType, out var androidx))
				{
					// 3. If not, then do a look up based on the Java types.

					var matched = xTypes.Where(t => t.JavaType.FullName == androidx).ToList();

					// a special case for the XxxConsts types
					const string ConstsSuffix = "Consts";
					if (matched.Count == 2 && matched.Any(m => m.NetType.Name.EndsWith(ConstsSuffix)))
					{
						matched.RemoveAll(m => m.NetType.Name.EndsWith(ConstsSuffix) != supportType.NetType.Name.EndsWith(ConstsSuffix));
					}

					if (matched.Count == 0)
					{
						if (includeWarnings)
							WriteRecord(writer, $"WARNING: Unable to find AndroidX type for Java type {androidx}.");
					}
					else
					{
						// if we have an exact name match, then use that
						var exact = matched.Where(m => m.NetType.Name == supportType.NetType.Name).ToList();
						if (exact.Count == 1)
							matched = exact;

						foreach (var m in matched)
						{
							typeMappings.Add(new TypeMapping(supportType, m));
							WriteRecord(writer, supportType, m);
						}
					}
				}
				else
				{
					// 4. As a last resort, use the .NET class name and try
					//    and find a match using just the name.

					var matched = xTypes.Where(xt => xt.NetType.Name == supportType.NetType.Name).ToList();
					if (matched.Count == 0)
					{
						if (includeWarnings)
							WriteRecord(writer, $"WARNING: Unable to find AndroidX type for .NET type {supportType.NetType}.");
					}
					else
					{
						foreach (var m in matched)
						{
							var msg = string.Empty;
							if (includeWarnings && useJavaType)
							{
								msg = $"WARNING: Unable to find a Java mapping, so took a guess.";
								if (matched.Count > 1)
									msg += $" Found more than 1 item: " + string.Join(", ", matched);
							}

							typeMappings.Add(new TypeMapping(supportType, m));
							WriteRecord(writer, supportType, m, msg);
						}
					}
				}
			}

			// PART B: Make sure all the Java mappings exist in the final CSV.
			foreach (var mapping in javaMappings.Skip(1))
			{
				var mapped = typeMappings.FirstOrDefault(k => k.SupportType.JavaType.FullName == mapping.Key);
				if (!mapped.SupportType.JavaType.IsEmpty)
					continue;

				WriteRecord(
					writer,
					new BindingType(FullType.Empty, GetJavaFullType(mapping.Key)),
					new BindingType(FullType.Empty, GetJavaFullType(mapping.Value)),
					$"WARNING: No .NET types found.");
			}
		}

		private static FullType GetJavaFullType(string javaFullName)
		{
			for (var i = 1; i < javaFullName.Length; i++)
			{
				if (char.IsUpper(javaFullName, i) && javaFullName[i - 1] == '.')
					return new FullType(
						javaFullName.Substring(0, i - 1),
						javaFullName.Substring(i));
			}

			return FullType.Empty;
		}

		private static void WriteRecord(TextWriter writer, string message) =>
			WriteRecord(writer, BindingType.Empty, BindingType.Empty, message);

		private static void WriteRecord(TextWriter writer, BindingType supportType, BindingType androidXType, string message = "")
		{
			writer.WriteLine(
				$"{supportType.NetType.Namespace}," +
				$"{supportType.NetType.Name}," +
				$"{androidXType.NetType.Namespace}," +
				$"{androidXType.NetType.Name}," +
				$"{supportType.NetType.Container}," +
				$"{androidXType.NetType.Container}," +
				$"{supportType.JavaType.Namespace}," +
				$"{supportType.JavaType.Name}," +
				$"{androidXType.JavaType.Namespace}," +
				$"{androidXType.JavaType.Name}," +
				message);
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

		private List<BindingType> GetAllTypes(string assemblyPath)
		{
			if (string.IsNullOrWhiteSpace(assemblyPath))
				throw new ArgumentException($"Invalid assembly path: {assemblyPath}", nameof(assemblyPath));
			if (!File.Exists(assemblyPath))
				throw new FileNotFoundException($"The assembly does not exist: {assemblyPath}");

			using (var assembly = AssemblyDefinition.ReadAssembly(assemblyPath))
			{
				var types = assembly.MainModule.GetTypes();
				return types.Where(IsValidType).Select(GetFullType).ToList();
			}
		}

		private bool IsValidType(TypeDefinition typeDefinition)
		{
			if (typeDefinition.Namespace == "Java.Interop" && typeDefinition.Name.EndsWith("__TypeRegistrations"))
				return false;

			if (typeDefinition.Name == "<Module>" || typeDefinition.Name.StartsWith("<>c__DisplayClass"))
				return false;

			return true;
		}

		private BindingType GetFullType(TypeDefinition typeDefinition)
		{
			var assembly = GetAttributeValue(typeDefinition, "Xamarin.AndroidX.Internal.InjectedAssemblyNameAttribute");
			var ns = typeDefinition.Namespace;
			var name = typeDefinition.Name;
			var java = GetJavaType(typeDefinition);

			var parent = typeDefinition.DeclaringType;
			while (parent != null)
			{
				assembly = GetAttributeValue(parent, "Xamarin.AndroidX.Internal.InjectedAssemblyNameAttribute");
				ns = parent.Namespace;
				name = parent.Name + "." + name;
				parent = parent.DeclaringType;
			}

			return new BindingType(new FullType(assembly, ns, name), java);
		}

		private static string GetAttributeValue(TypeDefinition typeDefinition, string attributeType, int index = 0)
		{
			var attribute = typeDefinition
				?.CustomAttributes
				?.FirstOrDefault(a => a.AttributeType.FullName == attributeType);

			var value = attribute
				?.ConstructorArguments
				?.Skip(index)
				?.FirstOrDefault()
				.Value as string ?? string.Empty;

			return value;
		}

		private FullType GetJavaType(TypeDefinition typeDefinition)
		{
			var javaType = GetAttributeValue(typeDefinition, "Android.Runtime.RegisterAttribute");
			var parts = javaType?.Split('/');
			var type = parts?.LastOrDefault()?.Split('$');
			if (parts?.Length > 0 && type?.Length > 0)
				return new FullType(string.Join(".", parts.Take(parts.Length - 1)), string.Join(".", type));
			else
				return FullType.Empty;
		}
	}
}
