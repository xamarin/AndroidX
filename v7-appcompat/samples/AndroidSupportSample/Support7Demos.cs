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
				resources.GetString (Resource.String.action_bar_mechanics),
				resources.GetString (Resource.String.action_bar_tabs),
				resources.GetString (Resource.String.action_bar_usage),
				resources.GetString (Resource.String.action_bar_display_options),
				resources.GetString (Resource.String.action_bar_fragment_menu),
				resources.GetString (Resource.String.action_bar_settings_action_provider),
                "AlertDialog"
			};

			ListAdapter = new ArrayAdapter<string> (this, Android.Resource.Layout.SimpleListItem1, mList);

			ListView list = ListView;

			list.ItemClick += (sender, e) => {
				Intent intent = null;
				switch (e.Position) {
				case 0:
					intent = new Intent (this, typeof(ActionBarMechanics));
					break;
				case 1:
					intent = new Intent (this, typeof(ActionBarTabs));
					break;
				case 2:
					intent = new Intent (this, typeof(ActionBarUsage));
					break;
				case 3:
					intent = new Intent (this, typeof(ActionBarDisplayOptions));
					break;
				case 4:
					intent = new Intent (this, typeof(ActionBarFragmentMenu));
					break;
				case 5:
					intent = new Intent (this, typeof(ActionBarSettingsActionProviderActivity));
					break;
                case 6:
                    ShowAlert ();
                    break;

				}

				if (intent != null)
					StartActivity (intent);
			};
		}

        void ShowAlert ()
        {
            new Android.Support.V7.App.AlertDialog.Builder(this)
                .SetTitle("This is an alert")
                .SetInverseBackgroundForced(true)
                .SetPositiveButton(Android.Resource.String.Ok, (sender, args) =>
                    {
                        ((IDialogInterface)sender).Dismiss();
                    }).Create().Show();


        }
	}
}
