using System;

namespace Firebase.Crash
{
    public partial class FirebaseCrash
    {
        public static void Logcat (Android.Util.LogPriority logPriority, string tag, string message)
        {
            Logcat ((int)logPriority, tag, message);
        }

        public static void Logcat (Android.Util.LogPriority logPriority, string tag, string format, params object[] args)
        {
            Logcat ((int)logPriority, tag, string.Format (format, args));
        }

        public static void Report (System.Exception exception)
        {
            Report (Java.Lang.Throwable.FromException (exception));
        }
    }
}

