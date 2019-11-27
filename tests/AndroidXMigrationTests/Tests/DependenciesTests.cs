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

			Assert.NotNull(tree.Packages.FirstOrDefault(p => p.Id == "Xamarin.Google.Android.Material"));

			var material = tree.GetOrCreate("Xamarin.Google.Android.Material");
			Assert.Contains("Xamarin.AndroidX.AppCompat", material.Dependencies);
		}

		[Fact]
		public void CanFlattenDependencies()
		{
			var tree = PackageDependencyTree.Load();

			var flattened = tree.Flatten("Xamarin.AndroidX.Palette").ToArray();

			Assert.Contains("Xamarin.AndroidX.Annotation", flattened);
			Assert.DoesNotContain("Xamarin.AndroidX.MultiDex", flattened);
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

			var expected = new[]
			{
				"Xamarin.AndroidX.Migration",
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
			Assert.NotEqual(ids, flattened);

			var actual = tree.Reduce(flattened);
			Assert.Equal(ids, actual);
		}

		[Fact]
		public void XamarinFormsTopLevelPackagesExpandToAll()
		{
			var ids = new[]
			{
				"Xamarin.AndroidX.AppCompat",
				"Xamarin.AndroidX.Browser",
				"Xamarin.AndroidX.CardView",
				"Xamarin.AndroidX.Legacy.Support.Core.Utils",
				"Xamarin.AndroidX.Legacy.Support.V4",
				"Xamarin.Google.Android.Material",
			};

			var expected = new[]
			{
				"Xamarin.AndroidX.Activity",
				"Xamarin.AndroidX.Annotation",
				"Xamarin.AndroidX.AppCompat",
				"Xamarin.AndroidX.AppCompat.Resources",
				"Xamarin.AndroidX.Arch.Core.Common",
				"Xamarin.AndroidX.Arch.Core.Runtime",
				"Xamarin.AndroidX.AsyncLayoutInflater",
				"Xamarin.AndroidX.Browser",
				"Xamarin.AndroidX.CardView",
				"Xamarin.AndroidX.Collection",
				"Xamarin.AndroidX.CoordinatorLayout",
				"Xamarin.AndroidX.Core",
				"Xamarin.AndroidX.CursorAdapter",
				"Xamarin.AndroidX.CustomView",
				"Xamarin.AndroidX.DocumentFile",
				"Xamarin.AndroidX.DrawerLayout",
				"Xamarin.AndroidX.Fragment",
				"Xamarin.AndroidX.Interpolator",
				"Xamarin.AndroidX.Legacy.Support.Core.UI",
				"Xamarin.AndroidX.Legacy.Support.Core.Utils",
				"Xamarin.AndroidX.Legacy.Support.V4",
				"Xamarin.AndroidX.Lifecycle.Common",
				"Xamarin.AndroidX.Lifecycle.LiveData.Core",
				"Xamarin.AndroidX.Lifecycle.Runtime",
				"Xamarin.AndroidX.Lifecycle.ViewModel",
				"Xamarin.AndroidX.Loader",
				"Xamarin.AndroidX.LocalBroadcastManager",
				"Xamarin.AndroidX.Media",
				"Xamarin.AndroidX.Migration",
				"Xamarin.AndroidX.Print",
				"Xamarin.AndroidX.RecyclerView",
				"Xamarin.AndroidX.SavedState",
				"Xamarin.AndroidX.SlidingPaneLayout",
				"Xamarin.AndroidX.SwipeRefreshLayout",
				"Xamarin.AndroidX.Transition",
				"Xamarin.AndroidX.VectorDrawable",
				"Xamarin.AndroidX.VectorDrawable.Animated",
				"Xamarin.AndroidX.VersionedParcelable",
				"Xamarin.AndroidX.ViewPager",
				"Xamarin.Google.Android.Material",
			};

			var tree = PackageDependencyTree.Load();

			var flattened = tree.Flatten(ids).ToList();
			flattened.Sort();

			Assert.Equal(expected, flattened);
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
				"Xamarin.AndroidX.VectorDrawable.Animated",
				"Xamarin.AndroidX.Annotation",
				"Xamarin.AndroidX.AsyncLayoutInflater",
				"Xamarin.AndroidX.Collection",
				"Xamarin.AndroidX.Core",
				"Xamarin.AndroidX.CoordinatorLayout",
				"Xamarin.AndroidX.Legacy.Support.Core.UI",
				"Xamarin.AndroidX.Legacy.Support.Core.Utils",
				"Xamarin.AndroidX.CursorAdapter",
				"Xamarin.AndroidX.Browser",
				"Xamarin.AndroidX.CustomView",
				"Xamarin.Google.Android.Material",
				"Xamarin.AndroidX.DocumentFile",
				"Xamarin.AndroidX.DrawerLayout",
				"Xamarin.AndroidX.Fragment",
				"Xamarin.AndroidX.Interpolator",
				"Xamarin.AndroidX.Loader",
				"Xamarin.AndroidX.LocalBroadcastManager",
				"Xamarin.AndroidX.Media",
				"Xamarin.AndroidX.Print",
				"Xamarin.AndroidX.SlidingPaneLayout",
				"Xamarin.AndroidX.SwipeRefreshLayout",
				"Xamarin.AndroidX.Transition",
				"Xamarin.AndroidX.Legacy.Support.V4",
				"Xamarin.AndroidX.AppCompat",
				"Xamarin.AndroidX.CardView",
				"Xamarin.AndroidX.MediaRouter",
				"Xamarin.AndroidX.Palette",
				"Xamarin.AndroidX.RecyclerView",
				"Xamarin.AndroidX.VectorDrawable",
				"Xamarin.AndroidX.VersionedParcelable",
				"Xamarin.AndroidX.ViewPager",
			};

			var expected = new[]
			{
				"Xamarin.AndroidX.Browser",
				"Xamarin.AndroidX.Legacy.Support.V4",
				"Xamarin.AndroidX.Lifecycle.LiveData",
				"Xamarin.AndroidX.MediaRouter",
				"Xamarin.Google.Android.Material",
			};

			var tree = PackageDependencyTree.Load();

			var flattened = tree.Reduce(ids).ToList();
			flattened.Sort();

			Assert.Equal(expected, flattened);
		}
	}
}
