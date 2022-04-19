using System.Linq;
using Xunit;

namespace Xamarin.AndroidX.Migration.Tests
{
	public class DependenciesTests : BaseTests
	{
		[Fact]
		public void CanLoadJsonFile()
		{
			var tree = PackageDependencyTree.Load();

			Assert.NotEmpty(tree.Packages);

			Assert.NotNull(tree.Packages.FirstOrDefault(p => p.Id == "Xamarin.AndroidX.SwipeRefreshLayout"));

			var material = tree.GetOrCreate("Xamarin.AndroidX.SwipeRefreshLayout");
			Assert.Contains("Xamarin.AndroidX.Interpolator", material.Dependencies);
		}

		[Fact]
		public void CanFlattenDependencies()
		{
			var tree = PackageDependencyTree.Load();

			var flattened = tree.Flatten("Xamarin.AndroidX.Fragment").ToArray();

			Assert.Contains("Xamarin.AndroidX.Annotation", flattened);
			Assert.Equal(flattened, flattened.Distinct().ToArray());
		}

		[Fact]
		public void FlattensNoDependenciesCorrectly()
		{
			var tree = PackageDependencyTree.Load();

			var ids = new[]
			{
				"Xamarin.AndroidX.Annotation",
			};

			var expected = new[]
			{
				"Xamarin.AndroidX.Annotation",
				"Xamarin.AndroidX.Migration",
				"Xamarin.AndroidX.MultiDex",
			};

			var flattened = tree.Flatten(ids);

			Assert.Equal(expected, flattened);
		}

		[Fact]
		public void FlattensSingleDependencyCorrectly()
		{
			var tree = PackageDependencyTree.Load();

			var ids = new[]
			{
				"Xamarin.AndroidX.Collection",
			};

			var expected = new[]
			{
				"Xamarin.AndroidX.Collection",
				"Xamarin.AndroidX.Annotation",
				"Xamarin.AndroidX.Migration",
				"Xamarin.AndroidX.MultiDex",
			};

			var flattened = tree.Flatten(ids);

			Assert.Equal(expected, flattened);
		}

		[Fact]
		public void FlattensSharedDependencyCorrectly()
		{
			var tree = PackageDependencyTree.Load();

			var ids = new[]
			{
				"Xamarin.AndroidX.Collection",
				"Xamarin.AndroidX.CursorAdapter",
			};

			var expected = new[]
			{
				"Xamarin.AndroidX.Collection",
				"Xamarin.AndroidX.CursorAdapter",
				"Xamarin.AndroidX.Annotation",
				"Xamarin.AndroidX.Migration",
				"Xamarin.AndroidX.MultiDex",
			};

			var flattened = tree.Flatten(ids);

			Assert.Equal(expected, flattened);
		}

		[Fact]
		public void FlattensTripleDependencyCorrectly()
		{
			var tree = PackageDependencyTree.Load();

			var ids = new[]
			{
				"Xamarin.AndroidX.VersionedParcelable",
			};

			var expected = new[]
			{
				"Xamarin.AndroidX.VersionedParcelable",
				"Xamarin.AndroidX.Annotation",
				"Xamarin.AndroidX.Collection",
				"Xamarin.AndroidX.Migration",
				"Xamarin.AndroidX.MultiDex",
			};

			var flattened = tree.Flatten(ids);

			Assert.Equal(expected, flattened);
		}

		[Fact]
		public void FlattensNoDependenciesCorrectlyWhenExcludingTopLevel()
		{
			var tree = PackageDependencyTree.Load();

			var ids = new[]
			{
				"Xamarin.AndroidX.Annotation",
			};

			var expected = new string[]
			{
				"Xamarin.AndroidX.Migration",
				"Xamarin.AndroidX.MultiDex",
			};

			var flattened = tree.Flatten(ids, false);

			Assert.Equal(expected, flattened);
		}

		[Fact]
		public void FlattensSingleDependencyCorrectlyWhenExcludingTopLevel()
		{
			var tree = PackageDependencyTree.Load();

			var ids = new[]
			{
				"Xamarin.AndroidX.Collection",
			};

			var expected = new[]
			{
				"Xamarin.AndroidX.Annotation",
				"Xamarin.AndroidX.Migration",
				"Xamarin.AndroidX.MultiDex",
			};

			var flattened = tree.Flatten(ids, false);

			Assert.Equal(expected, flattened);
		}

		[Fact]
		public void FlattensSharedDependencyCorrectlyWhenExcludingTopLevel()
		{
			var tree = PackageDependencyTree.Load();

			var ids = new[]
			{
				"Xamarin.AndroidX.Collection",
				"Xamarin.AndroidX.CursorAdapter",
			};

			var expected = new[]
			{
				"Xamarin.AndroidX.Annotation",
				"Xamarin.AndroidX.Migration",
				"Xamarin.AndroidX.MultiDex",
			};

			var flattened = tree.Flatten(ids, false);

			Assert.Equal(expected, flattened);
		}

		[Fact]
		public void CanReduceNoDependencyCorrectly()
		{
			var ids = new[]
			{
				"Xamarin.AndroidX.Annotation",
			};

			var expected = new[]
			{
				"Xamarin.AndroidX.Annotation",
			};

			var tree = PackageDependencyTree.Load();

			var actual = tree.Reduce(ids);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void CanReduceSingleDependencyCorrectly()
		{
			var ids = new[]
			{
				"Xamarin.AndroidX.Annotation",
				"Xamarin.AndroidX.Collection",
				"Xamarin.AndroidX.CursorAdapter",
			};

			var expected = new[]
			{
				"Xamarin.AndroidX.Collection",
				"Xamarin.AndroidX.CursorAdapter",
			};

			var tree = PackageDependencyTree.Load();

			var actual = tree.Reduce(ids);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void FlattenThenReduceEndsUpInTheSamePlace()
		{
			var tree = PackageDependencyTree.Load();

			var ids = new[] { "Xamarin.AndroidX.AppCompat" };

			var flattened = tree.Flatten(ids);
			Assert.NotEmpty(flattened);
			Assert.Equal(ids, flattened);

			var actual = tree.Reduce(flattened);
			Assert.Equal(ids, actual);
		}

		[Fact]
		public void XamarinFormsTopLevelPackagesExpandToAll()
		{
			var ids = new[]
			{
				"Xamarin.AndroidX.AppCompat",
				"Xamarin.AndroidX.Legacy.Support.Core.Utils",
				"Xamarin.AndroidX.Legacy.Support.V4",
			};

			var expected = new[]
			{
				"Xamarin.AndroidX.Annotation",
				"Xamarin.AndroidX.AppCompat",
				"Xamarin.AndroidX.Arch.Core.Common",
				"Xamarin.AndroidX.Arch.Core.Runtime",
				"Xamarin.AndroidX.Collection",
				"Xamarin.AndroidX.Core",
				"Xamarin.AndroidX.DocumentFile",
				"Xamarin.AndroidX.Legacy.Support.Core.Utils",
				"Xamarin.AndroidX.Legacy.Support.V4",
				"Xamarin.AndroidX.Lifecycle.Common",
				"Xamarin.AndroidX.Lifecycle.LiveData.Core",
				"Xamarin.AndroidX.Lifecycle.Runtime",
				"Xamarin.AndroidX.Lifecycle.ViewModel",
				"Xamarin.AndroidX.Loader",
				"Xamarin.AndroidX.LocalBroadcastManager",
				"Xamarin.AndroidX.Migration",
				"Xamarin.AndroidX.MultiDex",
				"Xamarin.AndroidX.Print",
				"Xamarin.AndroidX.VersionedParcelable",
	    };

			var tree = PackageDependencyTree.Load();

			var flattened = tree.Flatten(ids).ToList();
			flattened.Sort();

			System.Console.WriteLine ($"expected: {string.Join (",", expected)}");
			System.Console.WriteLine ($"actual: {string.Join (",",  flattened)}");
			Assert.Equal(expected, flattened.ToArray());
		}

		[Fact]
		public void XamarinFormsTotalDependencyIsReduced()
		{
			var ids = new[]
			{
				"Xamarin.AndroidX.Arch.Core.Common",
				"Xamarin.AndroidX.Arch.Core.Runtime",
				"Xamarin.AndroidX.Lifecycle.Common",
				"Xamarin.AndroidX.Lifecycle.LiveData.Core",
				"Xamarin.AndroidX.Lifecycle.LiveData",
				"Xamarin.AndroidX.Lifecycle.Runtime",
				"Xamarin.AndroidX.Lifecycle.ViewModel",
				"Xamarin.AndroidX.Annotation",
				"Xamarin.AndroidX.AsyncLayoutInflater",
				"Xamarin.AndroidX.Collection",
				"Xamarin.AndroidX.Core",
				"Xamarin.AndroidX.CoordinatorLayout",
				"Xamarin.AndroidX.Legacy.Support.Core.UI",
				"Xamarin.AndroidX.Legacy.Support.Core.Utils",
				"Xamarin.AndroidX.CursorAdapter",
				"Xamarin.AndroidX.CustomView",
				"Xamarin.AndroidX.DocumentFile",
				"Xamarin.AndroidX.DrawerLayout",
				"Xamarin.AndroidX.Fragment",
				"Xamarin.AndroidX.Interpolator",
				"Xamarin.AndroidX.Loader",
				"Xamarin.AndroidX.LocalBroadcastManager",
				"Xamarin.AndroidX.Print",
				"Xamarin.AndroidX.SlidingPaneLayout",
				"Xamarin.AndroidX.SwipeRefreshLayout",
				"Xamarin.AndroidX.Legacy.Support.V4",
				"Xamarin.AndroidX.AppCompat",
				"Xamarin.AndroidX.CardView",
				"Xamarin.AndroidX.Palette",
				"Xamarin.AndroidX.VersionedParcelable",
			};

			var expected = new[]
			{
				"Xamarin.AndroidX.AppCompat",
				"Xamarin.AndroidX.CardView",
				"Xamarin.AndroidX.Fragment",
				"Xamarin.AndroidX.Legacy.Support.V4",
				"Xamarin.AndroidX.Lifecycle.LiveData",
				"Xamarin.AndroidX.Palette",
			};

			var tree = PackageDependencyTree.Load();

			var flattened = tree.Reduce(ids).ToList();
			flattened.Sort();

			System.Console.WriteLine ($"expected: {string.Join (",", expected)}");
			System.Console.WriteLine ($"actual: {string.Join (",", flattened)}");

			Assert.Equal(expected, flattened.ToArray());
		}
	}
}
