using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using Android.Support.CustomTabs;

namespace ChromeCustomTabs
{
    [Activity (Label = "Chrome Tabs", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        const string TAG = "CustomTabsClientExample";

        CustomTabsActivityManager customTabs;

        string packageNameToBind = null;
        EditText editText;
        Button connectButton;
        Button warmupButton;
        Button mayLaunchButton;
        Button launchButton;
        Button simpleLaunch;

        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            editText = FindViewById<EditText> (Resource.Id.edit);
            connectButton = FindViewById<Button> (Resource.Id.connect_button);
            warmupButton = FindViewById<Button> (Resource.Id.warmup_button);
            mayLaunchButton = FindViewById<Button> (Resource.Id.may_launch_button);
            launchButton = FindViewById<Button> (Resource.Id.launch_button);
            Spinner spinner = FindViewById<Spinner> (Resource.Id.spinner);

            customTabs = new CustomTabsActivityManager (this);
            customTabs.CustomTabsServiceConnected += (name, client) => {
                connectButton.Enabled = false;
                warmupButton.Enabled = true;
                mayLaunchButton.Enabled = true;
                launchButton.Enabled = true;
            };
            customTabs.CustomTabsServiceDisconnected += (name) => {
                connectButton.Enabled = true;
                warmupButton.Enabled = false;
                mayLaunchButton.Enabled = false;
                launchButton.Enabled = false;
            };
            customTabs.NavigationEvent += (navigationEvent, extras) => {
                Android.Util.Log.Debug (TAG, "Navigation: " + navigationEvent);
            };
            customTabs.ExtraCallback += (sender, args) => {
                Android.Util.Log.Debug (TAG, "Extra Callback: " + args.CallbackName);
            };
           

            simpleLaunch = FindViewById<Button> (Resource.Id.buttonSimpleLaunch);
            simpleLaunch.Click += (sender, e) => {
                
                var mgr = new CustomTabsActivityManager (this);
                mgr.CustomTabsServiceConnected += delegate {
                    mgr.LaunchUrl ("http://xamarin.com");
                };
                mgr.BindService ();
            };

            editText.RequestFocus ();
            connectButton.Click += delegate {
                if (!customTabs.BindService (packageNameToBind))
                    Toast.MakeText (this, "Custom Tabs Not Supported - try installing Chrome", ToastLength.Long).Show ();
            };
            warmupButton.Click += delegate {

                warmupButton.Enabled = customTabs.Warmup ();

                Toast.MakeText (this, "Warmed Up", ToastLength.Short).Show ();
            };
            mayLaunchButton.Click += delegate {
                var url = editText.Text;

                mayLaunchButton.Enabled = customTabs.MayLaunchUrl (url, null, null);
                
                Toast.MakeText (this, "May Launch Called", ToastLength.Short).Show ();
            };
            launchButton.Click += delegate {
                var url = editText.Text;

                var builder = new CustomTabsIntent.Builder (customTabs.Session)
                    .SetToolbarColor (Color.Argb (255, 52, 152, 219))
                    .SetShowTitle (true)
                    .SetStartAnimations (this, Resource.Animation.slide_in_right, Resource.Animation.slide_out_left)
                    .SetExitAnimations (this, Resource.Animation.slide_in_left, Resource.Animation.slide_out_right);

                prepareMenuItems(builder);
                prepareActionButton(builder);

                var customTabsIntent = builder.Build ();

                CustomTabsHelper.AddKeepAliveExtra (this, customTabsIntent.Intent);

                customTabsIntent.LaunchUrl (this, Android.Net.Uri.Parse (url));
            };

            spinner.Adapter = new ArrayAdapter <string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem,
                CustomTabsHelper.Packages);


            spinner.ItemSelected += (sender, e) => {
                if (string.IsNullOrEmpty (e.Parent.GetItemAtPosition (e.Position).ToString ()))
                    packageNameToBind = null;
            };
            spinner.NothingSelected += (sender, e) => {
                packageNameToBind = null;
            };

        }

        void prepareMenuItems (CustomTabsIntent.Builder builder)
        {
            var menuIntent = new Intent();
            menuIntent.SetClass (ApplicationContext, typeof(MainActivity));
            // Optional animation configuration when the user clicks menu items.
            var menuBundle = ActivityOptions.MakeCustomAnimation (this, Android.Resource.Animation.SlideInLeft,
                Android.Resource.Animation.SlideOutRight).ToBundle ();
            var pi = PendingIntent.GetActivity (ApplicationContext, 0, menuIntent, 0, menuBundle);
            builder.AddMenuItem ("Menu entry 1", pi);
        }

        void prepareActionButton(CustomTabsIntent.Builder builder)
        {
            // An example intent that sends an email.
            var actionIntent = new Intent(Intent .ActionSend);
            actionIntent.SetType ("*/*");
            actionIntent.PutExtra (Intent.ExtraEmail, "example@example.com");
            actionIntent.PutExtra (Intent.ExtraSubject, "example");
            var pi = PendingIntent.GetActivity (ApplicationContext, 0, actionIntent, 0);
            var icon = BitmapFactory.DecodeResource (Resources, Resource.Drawable.Icon);
            builder.SetActionButton (icon, "send email", pi);
        }
    }

}


