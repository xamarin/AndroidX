using System;
using Android.App;
using Android.OS;
using Android.Support.V14.Preferences;
using Android.Support.V17.Preferences.Leanback;
using Android.Support.V7.Preferences;


namespace AndroidSupportSample
{
    public class SampleLeanbackPreferencesFragment : LeanbackPreferenceFragment
    {
        public override void OnCreatePreferences (Bundle savedInstanceState, String rootKey) 
        {
            AddPreferencesFromResource (Resource.Xml.Preferences);
        }
    }

    public class SamplePreferencesFragment : PreferenceFragment
    {
        public override void OnCreatePreferences (Bundle savedInstanceState, String rootKey) 
        {
            AddPreferencesFromResource (Resource.Xml.Preferences);
        }
    }
}

