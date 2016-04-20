using Android.App;
using Android.Widget;
using Android.OS;
using Android.Runtime;

namespace VectorDrawableSample
{
    [Activity (Label = "Animated Vector Drawable Sample", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Android.Support.V7.App.AppCompatActivity
    {
        protected override void OnCreate (Bundle savedInstanceState)
        {
            base.OnCreate (savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            // Get our image view
            var iv = FindViewById<ImageView> (Resource.Id.imageView);

            // Start the animation
            var avd = iv.Drawable.JavaCast<Android.Graphics.Drawables.IAnimatable> ();
            avd.Start ();
        }
    }
}


