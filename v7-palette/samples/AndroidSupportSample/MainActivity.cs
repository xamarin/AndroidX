using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Android.Support.V7.Graphics;
using Android.Graphics;
using Android.Graphics.Drawables;

namespace AndroidSupportSample
{
    [Activity (Label = "AndroidSupportSample", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Bitmap bitmapFoundation;

        protected async override void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            var btnFetchImage = FindViewById<Button> (Resource.Id.btnFetchImage);
            btnFetchImage.Click += (sender, e) => {            
                var p = new Palette.Builder (bitmapFoundation)
                    .Generate ();
                
                RunOnUiThread (() => SetPalette (p));            
            };

            bitmapFoundation = await BitmapFactory.DecodeResourceAsync (Resources, Resource.Drawable.viva);
        }

        public void SetPalette (Palette palette)
        {            
            Window.SetBackgroundDrawable (new ColorDrawable (new Color (palette.GetVibrantColor (Color.Red))));

            FindViewById<Button> (Resource.Id.btnVibrant).SetBackgroundDrawable (new ColorDrawable (new Color (palette.GetVibrantColor (Color.Red))));
            FindViewById<Button> (Resource.Id.btnVibrantDark).SetBackgroundDrawable (new ColorDrawable (new Color (palette.GetDarkVibrantColor (Color.DarkRed))));
            FindViewById<Button> (Resource.Id.btnVibrantLight).SetBackgroundDrawable (new ColorDrawable (new Color (palette.GetLightVibrantColor (Color.LightGoldenrodYellow))));

            FindViewById<Button> (Resource.Id.btnMuted).SetBackgroundDrawable (new ColorDrawable (new Color (palette.GetMutedColor (Color.Gray))));
            FindViewById<Button> (Resource.Id.btnMutedDark).SetBackgroundDrawable (new ColorDrawable (new Color (palette.GetDarkMutedColor (Color.DarkGray))));
            FindViewById<Button> (Resource.Id.btnMutedLight).SetBackgroundDrawable (new ColorDrawable (new Color (palette.GetLightMutedColor (Color.LightGray))));
    
            palette.Dispose ();
        }
    }
}
