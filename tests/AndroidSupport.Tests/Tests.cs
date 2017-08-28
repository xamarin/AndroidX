using System;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Support.V4.App;
using Xunit;
using Xunit.Extensions;

namespace AndroidSupport.Tests
{
	public class Tests
	{
		// https://bugzilla.xamarin.com/show_bug.cgi?id=51180
		[Fact]
		public async Task Bugzilla_51180_ToBundle_Compat_Does_Not_Fail()
		{
			var tcsUIThread = new TaskCompletionSource<object>();

			Bundle bundleOrig = null;
			Bundle bundleCompat = null;

			// We need to run these things on the UI Thread
			MainActivity.TestParentActivity.RunOnUiThread(() => {

			   var context = MainActivity.TestParentActivity;
			   var someView = MainActivity.TestParentActivity.FindViewById(Resource.Id.listView);

			   var optionsOrig = ActivityOptions.MakeSceneTransitionAnimation(context, someView, "testTransition");
			   var optionsCompat = ActivityOptionsCompat.MakeSceneTransitionAnimation(context, someView, "testTransition");

			   bundleOrig = optionsOrig.ToBundle();
			   bundleCompat = optionsCompat.ToBundle();

				tcsUIThread.SetResult(null);
		   });

			await tcsUIThread.Task;

			Assert.NotNull(bundleOrig);
			Assert.NotNull(bundleCompat);
		}

		[Fact]
		public void Support_Design_Internal_Classes_Exist()
		{
			var ctx = MainActivity.TestParentActivity;
			var a = new Android.Support.Design.Internal.BottomNavigationItemView(ctx);
			var b = new Android.Support.Design.Internal.BottomNavigationMenu(ctx);
			var c = new Android.Support.Design.Internal.BottomNavigationMenuView(ctx);
			var d = new Android.Support.Design.Internal.SnackbarContentLayout(ctx);
		}

		[Fact]
		public void Support_Design_Classes_Exist()
		{
			var ctx = MainActivity.TestParentActivity;
			var e = new Android.Support.Design.Widget.BottomSheetDialog(ctx);
			var f = new Android.Support.Design.Widget.BottomSheetDialogFragment();
		}
	}
}
