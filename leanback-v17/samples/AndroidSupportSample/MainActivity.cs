using System;
using System.Linq;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.App;

using Android.Support.V4.App;
using Android.Support.V17.Leanback.App;
using Android.Support.V17.Leanback.Widget;

namespace AndroidLeanbackSample
{
	[IntentFilter (new [] { "android.intent.action.MAIN" }, Categories = new [] { "android.intent.category.LEANBACK_LAUNCHER" })]
	[Activity (Label = "Xamarin Webinars", MainLauncher = true)]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.main);
		}
	}     
}
