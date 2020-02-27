using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Xamarin.AndroidX.Migration
{
	public class PackageDependencyTree
	{
		private readonly Dictionary<string, Package> tree = new Dictionary<string, Package>();

		public List<Package> Packages => tree.Values.ToList();

		public Package GetOrCreate(string id)
		{
			var treeKey = id.ToLowerInvariant();

			if (!tree.TryGetValue(treeKey, out var package))
			{
				package = new Package(id);
				tree[treeKey] = package;
			}

			return package;
		}

		public IEnumerable<string> Reduce(IEnumerable<string> ids)
		{
			var requirements = Flatten(ids).ToDictionary(i => i, i => true);

			var working = requirements.Keys.ToList();
			foreach (var id in working)
			{
				if (!requirements[id])
					continue;

				var dependencies = Flatten(id, false);

				foreach (var dep in dependencies)
					requirements[dep] = false;
			}

			return requirements.Where(p => p.Value).Select(p => p.Key).ToList();
		}

		public IEnumerable<string> Flatten(IEnumerable<string> ids, bool includeTopLevel = true)
		{
			var working = new List<string>(ids.Distinct());

			var dependencies = new Dictionary<string, bool>();
			if (includeTopLevel)
			{
				foreach (var id in working)
				{
					dependencies[id] = true;
				}
			}

			for (var idx = 0; idx < working.Count; idx++)
			{
				var id = working[idx];

				var treeKey = id.ToLowerInvariant();
				if (!tree.TryGetValue(treeKey, out var package) || package.Dependencies.Count == 0)
					continue;

				foreach (var dep in package.Dependencies)
				{
					dependencies[dep] = true;

					if (!working.Contains(dep))
						working.Add(dep);
				}
			}

			return dependencies.Keys.ToList();
		}

		public IEnumerable<string> Flatten(string id, bool includeTopLevel = true) =>
			Flatten(new[] { id }, includeTopLevel);

		public void Save(string jsonPath)
		{
			var dir = Path.GetDirectoryName(jsonPath);
			if (!Directory.Exists(dir))
				Directory.CreateDirectory(dir);

			using (var stream = File.Create(jsonPath))
			{
				Save(stream);
			}
		}

		public void Save(Stream stream)
		{
			var serializationObject = new Tree
			{
				Packages = Packages
			};

			var serializer = new DataContractJsonSerializer(typeof(Tree));
			serializer.WriteObject(stream, serializationObject);
		}

		public static PackageDependencyTree Load()
		{
			var tree = new PackageDependencyTree();
			tree.Deserialize(Resources.DependenciesPath);
			return tree;
		}

		public static PackageDependencyTree Load(string dependenciesFile)
		{
			var tree = new PackageDependencyTree();
			tree.Deserialize(dependenciesFile);
			return tree;
		}

		public static PackageDependencyTree Load(Stream json)
		{
			var tree = new PackageDependencyTree();
			tree.Deserialize(json);
			return tree;
		}

		private void Deserialize(string jsonPath)
		{
			using (var stream = File.OpenRead(jsonPath))
			{
				Deserialize(stream);
			}
		}

		private void Deserialize(Stream stream)
		{
			var serializer = new DataContractJsonSerializer(typeof(Tree));
			var serializationObject = (Tree)serializer.ReadObject(stream);

			if (serializationObject == null || serializationObject.Packages.Count == 0)
				return;

			// recreate the tree
			foreach (var incomingPackage in serializationObject.Packages)
			{
				var id = incomingPackage.Id;
				var package = GetOrCreate(id);

				foreach (var depId in incomingPackage.Dependencies)
				{
					var depPackage = GetOrCreate(depId);

					if (package.Dependencies.All(d => !d.Equals(depId, StringComparison.OrdinalIgnoreCase)))
						package.Dependencies.Add(depId);
				}
			}
		}

		[DataContract]
		private class Tree
		{
			[DataMember(Name = "packages")]
			public List<Package> Packages { get; set; }
		}
	}
}
