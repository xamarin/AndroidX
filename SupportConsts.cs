static class __SupportConsts {
    public const string Url  = "https://dl-ssl.google.com/android/repository/android_m2repository_r39.zip";

    // We get the Sha1 hash from google's xml feed: https://dl.google.com/android/repository/addon.xml
    // Search for the <sdk:checksum type="sha1">..</..> tag for the archive name android_m2repository_rXX.zip
    public const string Sha1sum = "89ad37d67a1018c42be36933cec3d7712141d42c";
    public const string Version = "25.0.0";
    public const string AarVersion = "25.0.0";
    public const string PackageName = "Xamarin.Android.Support";
}
