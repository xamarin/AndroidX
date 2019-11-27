using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Xamarin.AndroidX.Migration.Tests
{
	public static class CecilAssert
	{
		public static void Equal(IEnumerable<AssemblyNameReference> expected, IEnumerable<AssemblyNameReference> actual)
		{
			Assert.Equal(
				expected.Select(GetAssemblyFullName),
				actual.Select(GetAssemblyFullName));
		}

		public static void NotEqual(IEnumerable<AssemblyNameReference> expected, IEnumerable<AssemblyNameReference> actual)
		{
			Assert.NotEqual(
				expected.Select(GetAssemblyFullName),
				actual.Select(GetAssemblyFullName));
		}

		public static void Equal(IEnumerable<TypeDefinition> expected, IEnumerable<TypeDefinition> actual)
		{
			Assert.Equal(
				expected.Select(GetTypeDefinitionFullName),
				actual.Select(GetTypeDefinitionFullName));
		}

		public static void NotEqual(IEnumerable<TypeDefinition> expected, IEnumerable<TypeDefinition> actual)
		{
			Assert.NotEqual(
				expected.Select(GetTypeDefinitionFullName),
				actual.Select(GetTypeDefinitionFullName));
		}

		public static void Equal(TypeDefinition expected, TypeDefinition actual)
		{
			Assert.Equal(
				expected.Fields.Select(f => f.FieldType.FullName),
				actual.Fields.Select(f => f.FieldType.FullName));
			Assert.Equal(
				expected.Properties.Select(p => p.PropertyType.FullName),
				actual.Properties.Select(p => p.PropertyType.FullName));
			Assert.Equal(
				expected.Methods.Select(GetMethodTypesFullNames),
				actual.Methods.Select(GetMethodTypesFullNames));
			Assert.Equal(
				expected.Events.Select(e => e.EventType.FullName),
				actual.Events.Select(e => e.EventType.FullName));
		}

		private static object GetMethodTypesFullNames(MethodDefinition m)
		{
			var value = m.ReturnType.FullName;
			if (m.HasGenericParameters)
				value += "<" + string.Join(",", m.GenericParameters.Select(GetGenericConstraintsFullNames)) + ">";
			if (m.HasParameters)
				value += "(" + string.Join(",", m.Parameters.Select(p => p.ParameterType.FullName)) + ")";
			return value;
		}

		private static string GetTypeDefinitionFullName(TypeDefinition t)
		{
			var value = t.FullName;
			if (t.HasGenericParameters)
				value += "<" + string.Join(",", t.GenericParameters.Select(GetGenericConstraintsFullNames)) + ">";
			if (t.BaseType != null)
				value += " : " + t.BaseType?.FullName;
			if (t.HasInterfaces)
				value += ", " + string.Join(", ", t.Interfaces.Select(i => i.InterfaceType.FullName));
			return value;
		}

		private static string GetAssemblyFullName(AssemblyNameReference name)
		{
			var value = name.FullName;
			return value;
		}

		private static string GetGenericConstraintsFullNames(GenericParameter gp)
		{
			var value = gp.FullName;
			if (gp.HasConstraints)
				value += "=" + string.Join(",", gp.Constraints.Select(c => c.FullName));
			return value;
		}
	}
}
