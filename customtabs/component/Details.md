
# Custom Tabs Android Support Library

App developers face a choice when a user taps a URL to either launch a browser, or build their own in-app browser using WebViews.

Both options present challenges — launching the browser is a heavy context switch that isn't customizable, while WebViews don't share state with the browser and add maintenance overhead.

Custom tabs give apps more control over their web experience, and make transitions between native and web content more seamless without having to resort to a WebView.

Custom tabs allow an app to customize how Chrome looks and feels. An app can change things like:
 - Toolbar color
 - Enter and exit animations
 - Add custom actions to the Chrome toolbar and overflow menu
 - Custom tabs also allow the developer to pre-start Chrome and pre-fetch content for faster loading.


### When should I use Chrome custom tabs vs WebView?

The WebView is good solution if you are hosting your own content inside your app. If your app directs people to URLs outside your domain, we recommend that you use Chrome custom tabs for these reasons:

 - Simple to implement. No need to build code to manage requests, permission grants or cookie stores.
 - UI customization:
   - Toolbar color
   - Action button
   - Custom menu items
   - Custom in/out animations
 - Navigation awareness: the browser delivers a callback to the application upon an external navigation.
 - Performance optimization:
    - Pre-warming of the Browser in the background, while avoiding stealing resources from the application.
    - Providing a likely URL in advance to the browser, which may perform speculative work, speeding up page load time.
 - Lifecycle management: the browser prevents the application from being evicted by the system while on top of it, by raising its importance to the "foreground" level.
 - Shared Cookie Jar and permissions model so users don't have to log in to sites they are already connected to, or re-grant permissions they have already granted.
 -  If the user has turned on Data Saver, they will still benefit from it.
Synchronized AutoComplete across devices for better form completion.
 - Simple customization model.
 - Quickly return to app with a single tap.
 - You want to use the latest browser implementations on devices pre-Lollipop (auto updating WebView) instead of older WebViews.




## Android Support Libraries

The Android Support Libraries are a set of code libraries that provide backward-compatible versions of Android framework APIs as well as features that are only available through the library APIs. Each Support Library is backward-compatible to a specific Android API level. This design means that your applications can use the libraries' features and still be compatible with devices running older versions of Android.

Including the Support Libraries in your Android project is considered a best practice for application developers, depending on the range of platform versions your app is targeting and the APIs that it uses. Using the features the libraries provide can help you improve the look of your application, increase performance and broaden the reach of your application to more users. 



