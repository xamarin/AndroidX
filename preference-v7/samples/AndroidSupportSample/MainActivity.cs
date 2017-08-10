using System;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.App;
using Android.Support.V7.App;

namespace AndroidSupportSample
{
    [Activity (Label = "Support Preferences", MainLauncher = true, Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);

            SetContentView (Resource.Layout.PreferencesLayout);
        }
    }
}
