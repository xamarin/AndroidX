using Android.Runtime;

namespace Google.Android.Material.Tabs.AppCompat.App
{
    [Register ("com.google.android.material.tabs.appcompat.app.AppCompatActivity", DoNotGenerateAcw=true)]
    public class AppCompatActivity : AndroidX.AppCompat.App.AppCompatActivity, Google.Android.Material.Tabs.TabLayout.IOnTabSelectedListener2 
    {
        public virtual void OnTabSelected(TabLayout.Tab tab)
        {
            return;
        }

        public virtual void OnTabUnselected(TabLayout.Tab tab)
        {
            return;
        }

        public virtual void OnTabReselected(TabLayout.Tab tab)
        {
            return;
        }
    }
}