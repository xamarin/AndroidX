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
	}
}
