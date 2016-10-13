static class __SupportConsts {
    public const string Url  = "https://dl-ssl.google.com/android/repository/android_m2repository_r38.zip";

    // We get the Sha1 hash from google's xml feed: https://dl.google.com/android/repository/addon.xml
    // Search for the <sdk:checksum type="sha1">..</..> tag for the archive name android_m2repository_rXX.zip
    public const string Sha1sum = "2ad48ed61d6fc8d7d9351ce62873be60dac5187b";
    public const string Version = "24.2.1";
    public const string AarVersion = "24.2.1";
    public const string PackageName = "Xamarin.Android.Support";
}
