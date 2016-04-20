Custom Tabs Support Library
===========================

As of Chrome 45, Chrome custom tabs is now generally available to all users of Chrome, on all of Chrome's supported Android versions (Jellybean onwards). Please note that the API will change slightly over the coming weeks.


### Loading a Page

You can load pages without any customization very easily:

```csharp
var mgr = new CustomTabsActivityManager (this);
mgr.CustomTabsServiceConnected += delegate {
	mgr.LaunchUrl ("http://xamarin.com");
};
mgr.BindService ();
```

### Customization

You can also customize the look and feel of the browser tab. You can change the background colour of the toolbar, customize start and exit animations, add items to the overflow menu, and even add icons to the action bar!

```csharp
var builder = new CustomTabsIntent.Builder (customTabs.Session)

	// Xamarin Blue
	.SetToolbarColor (Color.Argb (255, 52, 152, 219))
	
	// Show Title of page, not just URL
	.SetShowTitle (true)
	
	// Customize the Animations for displaying the browser
	.SetStartAnimations (this, Resource.Animation.slide_in_right, Resource.Animation.slide_out_left)
	.SetExitAnimations (this, Resource.Animation.slide_in_left, Resource.Animation.slide_out_right);

var intent = builder.Build ();

var mgr = new CustomTabsActivityManager (this);
mgr.CustomTabsServiceConnected += delegate {
	mgr.LaunchUrl ("http://xamarin.com", intent);
};
mgr.BindService ();
```


#### Adding Menu Items

It's also possible to add your own menu items to the overflow menu:

```csharp
var menuIntent = new Intent (typeof (MainActivity));
menuIntent.PutExtra ("hug", true);

// Optional animation configuration when the user clicks menu items.
var menuBundle = ActivityOptions.MakeCustomAnimation (this, 
					Android.Resource.Animation.SlideInLeft,
                	Android.Resource.Animation.SlideOutRight).ToBundle ();
                	
var pi = PendingIntent.GetActivity (
			ApplicationContext, 0, menuIntent, 0, menuBundle);

builder.AddMenuItem ("Hug a Monkey", pi);
```

#### Adding Action Button

You can also add your own buttons to the Toolbar:

```csharp
// An example intent that sends an email.
var actionIntent = new Intent(Intent.ActionSend);
actionIntent.SetType("*/*");
actionIntent.PutExtra (Intent.ExtraEmail, "support@xamarin.com");
actionIntent.PutExtra (Intent.ExtraSubject, "Help me make awesome apps!");

var pi = PendingIntent.GetActivity (ApplicationContext, 0, actionIntent, 0);

var icon = BitmapFactory.DecodeResource (Resources, Resource.Drawable.Icon);

builder.SetActionButton (icon, pi);
```

### Fall back gracefully

Not every user will have Chrome installed, so you should build your app to gracefully fall back to other methods of handling displaying your URL.  If your call to `BindService` returns false, you should assume Custom Tabs will not work and should handle the URL another way:

```csharp
if (!mgr.BindService ()) {
   // Cannot use Custom Tabs,
   // Launch the URL another way
}
```

