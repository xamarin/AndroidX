using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Xamarin.AndroidX.Migration.Tests
{
	public static class Utils
	{
		private const string RegisterAttributeFullName = "Android.Runtime.RegisterAttribute";
		private const string AnnotationAttributeFullName = "Android.Runtime.AnnotationAttribute";

		public static string GetTempFilename(string filename = null, bool createDirectory = true)
		{
			var newPath = Path.Combine(
				Path.GetTempPath(),
				"Xamarin.AndroidX.Migration.Tests",
				Guid.NewGuid().ToString(),
				filename ?? Guid.NewGuid().ToString());

			if (createDirectory)
			{
				var dir = Path.GetDirectoryName(newPath);
				if (!Directory.Exists(dir))
					Directory.CreateDirectory(dir);
			}

			return newPath;
		}

		public static IEnumerable<TypeDefinition> GetPublicTypes(this AssemblyDefinition assembly, bool ignoreResourceType = false) =>
			assembly.MainModule.GetTypes().Where(t => (t.IsPublic || t.IsNestedPublic) && (!ignoreResourceType || !t.IsResourceType()));

		public static bool IsResourceType(this TypeDefinition type) =>
			type.IsNestedPublic && type.DeclaringType.Name == "Resource";

		public static CustomAttribute GetAnnotationAttribute(this TypeDefinition type) =>
			type.CustomAttributes.FirstOrDefault(a => a.AttributeType.FullName == AnnotationAttributeFullName);

		public static CustomAttribute GetRegisterAttribute(this TypeDefinition type) =>
			type.CustomAttributes.FirstOrDefault(a => a.AttributeType.FullName == RegisterAttributeFullName);

		public static CustomAttribute GetRegisterAttribute(this MethodDefinition method) =>
			method.CustomAttributes.FirstOrDefault(a => a.AttributeType.FullName == RegisterAttributeFullName);

		public static CustomAttribute GetRegisterAttribute(this PropertyDefinition property) =>
			property.CustomAttributes.FirstOrDefault(a => a.AttributeType.FullName == RegisterAttributeFullName);

		public static object[] GetArguments(this CustomAttribute attribute) =>
			attribute?.ConstructorArguments?.Select(a => a.Value)?.ToArray() ?? new object[0];

		public static async Task DownloadFileAsync(string facebookTestUrl, string facebookZip)
		{
			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(
					"Xamarin.AndroidX.Migration.Tests",
					"1.0.0"));

				using (var stream = await client.GetStreamAsync(facebookTestUrl))
				using (var dest = File.OpenWrite(facebookZip))
				{
					await stream.CopyToAsync(dest);
				}
			}
		}
	}
}
