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
				resources.GetString (Resource.String.grid_layout_1),
				resources.GetString (Resource.String.grid_layout_2),
				resources.GetString (Resource.String.grid_layout_3)
			};

			ListAdapter = new ArrayAdapter<string> (this, Android.Resource.Layout.SimpleListItem1, mList);

			ListView list = ListView;

			list.ItemClick += (sender, e) => {
				Intent intent = null;
				switch (e.Position) {
				case 0:
					intent = new Intent (this, typeof(GridLayout1));
					break;
				case 1:
					intent = new Intent (this, typeof(GridLayout2));
					break;
				case 2:
					intent = new Intent (this, typeof(GridLayout3));
					break;
				
				}

				if (intent != null)
					StartActivity (intent);
			};
		}
	}
}
