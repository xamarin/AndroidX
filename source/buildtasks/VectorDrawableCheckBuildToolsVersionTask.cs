using System;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Xamarin.Android.Support.Tasks
{
    public class VectorDrawableCheckBuildToolsVersionTask : Task
    {
        const int MIN_REQ_MAJOR_VERSION = 23;
        const string MIN_REQ_MAJOR_VERSION_STR = "23.0.0";

        //$(AndroidSdkBuildToolsPath)
        [Required]
        public ITaskItem AndroidSdkBuildToolsPath { get; set; }

        public override bool Execute ()
        {
            Log.LogMessage ("Checking Android SDK Build-tools version...");

            var selectedBuildToolsFullPath = AndroidSdkBuildToolsPath.GetMetadata ("FullPath");
            Log.LogMessage ("Selected Android SDK Build Tools Path: " + selectedBuildToolsFullPath);

            var selectedBuildToolsPathInfo = new DirectoryInfo (selectedBuildToolsFullPath);
            var selectedVersion = selectedBuildToolsPathInfo.Name;
            Log.LogMessage ("Selected Android SDK Build Tools Version: " + selectedVersion);

            var selectedMajorVersion = GetMajorVersionNumber (selectedVersion);

            // check if we have the minimum version selected, if so, log ok and return, nothing more to do
            if (selectedMajorVersion >= MIN_REQ_MAJOR_VERSION) {
                Log.LogMessage ("Android SDK Build Tools Version: " + selectedVersion + " meets minimum requirements for Vector Drawables. OK.");
                Log.LogMessage ("Finished Checking Android SDK Build-tools version.");
                return true;
            }

            var buildToolsPath = selectedBuildToolsPathInfo.Parent;
            Log.LogMessage ("Android SDK Build Tools Directory: " + buildToolsPath);
            Log.LogMessage ("The following Build-tools versions are installed:");

            var hasMinRequiredInstalled = false;

            foreach (var btp in buildToolsPath.EnumerateDirectories ()) {

                // See if any of the versions meet the min requirements
                // they may have it installed, and just not have it selected to use
                var btpMajorVersion = GetMajorVersionNumber (btp.Name);
                if (btpMajorVersion >= MIN_REQ_MAJOR_VERSION)
                    hasMinRequiredInstalled = true;
                
                Log.LogMessage ("    {0}", btp.Name);
            }

            var errorMsg = "An outdated of 'Android SDK Build-tools' is in use which this version of Android Support Library does not support.  You must uninstall any 'Android SDK Build-tools' versions older than " + MIN_REQ_MAJOR_VERSION_STR + " from the 'Tools' section in your 'Android SDK Manager'";

            if (!hasMinRequiredInstalled)
                errorMsg += "\r\nYou also need to install 'Android SDK Build-tools' version " + MIN_REQ_MAJOR_VERSION_STR + " or higher.";

            Log.LogError (errorMsg);
            return false;
        }

        int GetMajorVersionNumber (string version)
        {
            if (!string.IsNullOrEmpty (version) && version.Any (c => c == '.')) {
                var parts = version.Split ('.');

                if (parts != null && parts.Length > 0) {
                    int major = -1;
                    if (int.TryParse (parts [0], out major))
                        return major;
                }
            }

            return -1;
        }
    }
}
