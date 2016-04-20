using System;
using Android.App;
using Android.OS;
using Android.Widget;


namespace AndroidSupportSample
{
	[Activity (Label = "@string/grid_layout_2")]
	public class GridLayout2 : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView(Resource.Layout.grid_layout_2);

			FindViewById<Button> (Resource.Id.button_next).Click += delegate {
				Toast.MakeText (this, "Next Tapped!", ToastLength.Short).Show ();
			};
			FindViewById<Button> (Resource.Id.button_manual).Click += delegate {
				Toast.MakeText (this, "Manual Tapped!", ToastLength.Short).Show ();
			};
		}
	}
}

