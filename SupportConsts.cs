static class __SupportConsts {
    public const string Url  = "https://dl-ssl.google.com/android/repository/android_m2repository_r40.zip";

    // We get the Sha1 hash from google's xml feed: https://dl.google.com/android/repository/addon.xml
    // Search for the <sdk:checksum type="sha1">..</..> tag for the archive name android_m2repository_rXX.zip
    public const string Sha1sum = "782e7233f18c890463e8602571d304e680ce354c";
    public const string Version = "25.0.1";
    public const string AarVersion = "25.0.1";
    public const string PackageName = "Xamarin.Android.Support";
}
