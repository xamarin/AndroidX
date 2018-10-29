using System;
using Android.Content;
using System.Collections.Generic;
using System.Linq;

namespace Android.Support.CustomTabs
{
    public class CustomTabsHelper 
    {
        const string TAG = "CustomTabsHelper";
        const string STABLE_PACKAGE = "com.android.chrome";
        const string BETA_PACKAGE = "com.chrome.beta";
        const string DEV_PACKAGE = "com.chrome.dev";
        const string LOCAL_PACKAGE = "com.google.android.apps.chrome";
        const string EXTRA_CUSTOM_TABS_KEEP_ALIVE = "android.support.customtabs.extra.KEEP_ALIVE";

        static String packageNameToUse;

        public static void AddKeepAliveExtra (Context context, Intent intent) 
        {
            var keepAliveIntent = new Intent ().SetClass (context, typeof(KeepAliveService));
            intent.PutExtra (EXTRA_CUSTOM_TABS_KEEP_ALIVE, keepAliveIntent);
        }

        /**
     * Goes through all apps that handle VIEW intents and have a warmup service. Picks
     * the one chosen by the user if there is one, otherwise makes a best effort to return a
     * valid package name.
     *
     * This is <strong>not</strong> threadsafe.
     *
     * @param context {@link Context} to use for accessing {@link PackageManager}.
     * @return The package name recommended to use for connecting to custom tabs related components.
     */
        public static String GetPackageNameToUse (Context context) 
        {
            if (packageNameToUse != null) 
                return packageNameToUse;

            var pm = context.PackageManager;

            // Get default VIEW intent handler.
            var activityIntent = new Intent (Intent.ActionView, global::Android.Net.Uri.Parse ("http://www.example.com"));
            var defaultViewHandlerInfo = pm.ResolveActivity (activityIntent, 0);

            string defaultViewHandlerPackageName = null;
            if (defaultViewHandlerInfo != null)
                defaultViewHandlerPackageName = defaultViewHandlerInfo.ActivityInfo.PackageName;

            // Get all apps that can handle VIEW intents.
            var resolvedActivityList = pm.QueryIntentActivities (activityIntent, 0);
            var packagesSupportingCustomTabs = new List<string> ();

            foreach (var info in resolvedActivityList) {
                var serviceIntent = new Intent();
                serviceIntent.SetAction (CustomTabsService.ActionCustomTabsConnection);
                serviceIntent.SetPackage (info.ActivityInfo.PackageName);

                if (pm.ResolveService (serviceIntent, 0) != null)
                    packagesSupportingCustomTabs.Add (info.ActivityInfo.PackageName);
            }

            // Now packagesSupportingCustomTabs contains all apps that can handle both VIEW intents
            // and service calls.
            if (!packagesSupportingCustomTabs.Any ()) {
                packageNameToUse = null;
            } else if (packagesSupportingCustomTabs.Count == 1) {
                packageNameToUse = packagesSupportingCustomTabs [0];
            } else if (!string.IsNullOrEmpty (defaultViewHandlerPackageName)
                && !hasSpecializedHandlerIntents (context, activityIntent)
                && packagesSupportingCustomTabs.Contains (defaultViewHandlerPackageName)) {
                packageNameToUse = defaultViewHandlerPackageName;
            } else if (packagesSupportingCustomTabs.Contains (STABLE_PACKAGE)) {
                packageNameToUse = STABLE_PACKAGE;
            } else if (packagesSupportingCustomTabs.Contains (BETA_PACKAGE)) {
                packageNameToUse = BETA_PACKAGE;
            } else if (packagesSupportingCustomTabs.Contains (DEV_PACKAGE)) {
                packageNameToUse = DEV_PACKAGE;
            } else if (packagesSupportingCustomTabs.Contains (LOCAL_PACKAGE)) {
                packageNameToUse = LOCAL_PACKAGE;
            }

            return packageNameToUse;
        }

        static bool hasSpecializedHandlerIntents (Context context, Intent intent)
        {
            try {
                var pm = context.PackageManager;
                var handlers = pm.QueryIntentActivities (intent, Android.Content.PM.PackageInfoFlags.ResolvedFilter);

                if (handlers == null || handlers.Count == 0)
                    return false;
                
                foreach (var resolveInfo in handlers) {

                    var filter = resolveInfo.Filter;
                    if (filter == null) 
                        continue;
                    if (filter.CountDataAuthorities () == 0 || filter.CountDataPaths () == 0) 
                        continue;
                    if (resolveInfo.ActivityInfo == null) 
                        continue;

                    return true;
                }
            } catch (Java.Lang.RuntimeException) {
                global::Android.Util.Log.Error (TAG, "Runtime exception while getting specialized handlers");
            }
            return false;
        }

        // All possible chrome package names with this feature
        public static string[] Packages = new [] {"", STABLE_PACKAGE, BETA_PACKAGE, DEV_PACKAGE, LOCAL_PACKAGE};
    }
}

