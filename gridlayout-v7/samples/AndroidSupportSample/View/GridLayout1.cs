using System;
using Android.App;
using Android.OS;
using Android.Widget;


namespace AndroidSupportSample
{
	[Activity (Label = "@string/grid_layout_1")]
	public class GridLayout1 : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView(Resource.Layout.grid_layout_1);

			FindViewById<Button> (Resource.Id.button_ok).Click += delegate {
				Toast.MakeText (this, "OK Tapped!", ToastLength.Short).Show ();
			};
			FindViewById<Button> (Resource.Id.button_cancel).Click += delegate {
				Toast.MakeText (this, "Cancel Tapped!", ToastLength.Short).Show ();
			};
		}
	}
}





