using System;
using Android.OS;
using Android.App;
using Android.Widget;
using Android.Content;

namespace AndroidSupportSample
{
	[Activity (MainLauncher = true)]
	public class Support7Demos : ListActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			var resources = Resources;

			string[] mList = {
				resources.GetString (Resource.String.sample_media_router_activity_dark),
				resources.GetString (Resource.String.sample_media_router_activity_light),
				resources.GetString (Resource.String.sample_media_router_activity_light_with_dark_action_bar),
			};

			ListAdapter = new ArrayAdapter<string> (this, Android.Resource.Layout.SimpleListItem1, mList);

			ListView list = ListView;

			list.ItemClick += (sender, e) => {
				Intent intent = null;
				switch (e.Position) {
				case 0:
					intent = new Intent (this, typeof(SampleMediaRouterActivity));
					break;
				case 1:
					intent = new Intent (this, typeof(SampleMediaRouterActivity.Light));
					break;
				case 2:
					intent = new Intent (this, typeof(SampleMediaRouterActivity.LightWithDarkActionBar));
					break;
				}

				if (intent != null)
					StartActivity (intent);
			};
		}
	}
}
