
Add the Xamarin.AndroidX.Migration NuGet package to your app
------------------------------------------------------------

You should add the `Xamarin.AndroidX.Migration` NuGet package to your Xamarin
Android application project and any Xamarin.Android library projects it
references.


Keep the Xamarin.Android.Support.* NuGet packages
-------------------------------------------------

You will need to keep your existing references to Xamarin.Android.Support.*
NuGet packages as any remaining usage of the old Android Support API's will
require this for compiling before the migration build step does its job.  The
Android Support libraries will not be bundled into your apk.


Add references to the correct AndroidX NuGet packages
-----------------------------------------------------

The migration package contains a validation step which helps ensure you have
references to all of the AndroidX NuGet packages that the Android Support
library NuGet packages you reference in your app map to.

You will see a build error generated telling you which packages are missing
which you need to add.


When can I remove the Migration package?
----------------------------------------

As soon as all of your own source code, layout files, proguard configurations,
and manifest files are converted over to using the new AndroidX API's, and all
of the libraries you depend on have done the same, you can safely remove the
AndroidX Migration NuGet package along with all of the old Android Support
library NuGet packages.
