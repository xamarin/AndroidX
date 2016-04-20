using Android.App;
using Android.Widget;
using Android.OS;

namespace VectorDrawableSample
{
    [Activity (Label = "Vector Drawable Sample", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Android.Support.V7.App.AppCompatActivity
    {
        protected override void OnCreate (Bundle savedInstanceState)
        {
            base.OnCreate (savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
        }
    }
}


