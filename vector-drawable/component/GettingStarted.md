
This library adds support for utilizing Vector drawable graphics on devices running Android API Level 11 or higher. 

### Target SDK Version 
NOTE: Using this support library requires that your app have its Target Android Version (*targetSdkVersion*) set to Lollipop (5.0 - API Level 21) or higher, or you will have *aapt* related compile errors.  You can still set the Target Framework which your app is compiled against as low as Android 4.0.3 (API Level 15).


Using Vector Drawables
------


To use your vector drawable, you should also reference the **AppCompat v7 Support Library** in your app.

Your activity should derive from `AppCompatActivity` so that the `AppCompatImageView` is automatically used at runtime where you have defined `ImageView` types.


You can define your vectors as .xml files in your `Resources\drawable` folder.  Here is an example:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<vector xmlns:android="http://schemas.android.com/apk/res/android"
	android:height="96dp"
	android:width="96dp"
	android:viewportHeight="48"
	android:viewportWidth="48" >
	<group>
		<path
			android:fillColor="#393939"
			android:pathData="M12 36l17-12-17-12v24zm20-24v24h4V12h-4z" />
	</group>
</vector>
```

You can then reference your vector drawable programmatically, or declaratively in your android layout xml.

To use your vector drawable programmatically:

```csharp
imageView.SetImageResource (Resource.Drawable.media);
```

To specify the vector in your layout file, use the `app:srcCompat` attribute (be sure to define the `xmlns:app` namespace as well):

```xml
<?xml version="1.0" encoding="utf-8"?>
<LinearLayout xmlns:android="http://schemas.android.com/apk/res/android"
    xmlns:app="http://schemas.android.com/apk/res-auto"
    android:orientation="vertical"
    android:layout_width="match_parent"
    android:layout_height="match_parent">
    <ImageView
        app:srcCompat="@drawable/media"
        android:layout_width="match_parent"
        android:layout_height="fill_parent"
        android:layout_weight="1"
        android:id="@+id/imageView" />
</LinearLayout>
```


**NOTE:** The `Xamarin.Android.Support.Vector.Drawable` nuget package contains a .targets file which appends the argument `--no-version-vectors` to  `AndroidResgenExtraArgs` build property value to ensure the parameter is passed to the `aapt` invocation.
