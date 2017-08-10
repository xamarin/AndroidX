# Using Preference Support Libraries

The v7, v14, and v17 Leanback preference support libraries allow you to use a common approach to implementing UI preferences across many different API levels.  


## Configure your Theme
To use the Preference support classes, your app will need to apply a Preference style in the theme of your activity that will display preferences.  You can set your app theme in your `styles.xml` file to specify a `preferenceTheme`:

```xml
<?xml version="1.0" encoding="UTF-8" ?>
<resources>
	<style name="AppTheme" parent="Theme.AppCompat.Light">
		<item name="preferenceTheme">@style/PreferenceThemeOverlay</item>
	</style>
</resources>
```

Note that you will need to inherit from a different theme for v17 Leanback (you could make a `values-television` folder so that the appropriate styles.xml file is automatically loaded at runtime for the given platform, with a declaration like this:

```xml
<?xml version="1.0" encoding="UTF-8" ?>
<resources>
	<style name="AppTheme" parent="@style/Theme.Leanback">
		<item name="preferenceTheme">@style/PreferenceThemeOverlay</item>
	</style>
</resources>
```

Make sure to apply the theme you created to the activity that will display Preference fragments.

## Create Xml Preferences

The easiest way to setup a bunch of preferences is to define them in an Xml resource file:

```xml
<?xml version="1.0" encoding="UTF-8" ?>
<PreferenceScreen
    xmlns:android="http://schemas.android.com/apk/res/android"
    android:title="This is a test">

    <PreferenceCategory
        android:title="Inline Preference">

        <CheckBoxPreference
            android:key="checkbox_preference"
            android:title="CheckboxPreference"
            android:summary="Checkbox Preference Summary" />

    </PreferenceCategory>

	<!-- ... -->
	
</PreferenceScreen>
```


## Create Preference Fragments

You will need to create implementations of `PreferenceFragment` to display in your app.  If you would like to target Leanback as well, it's wise to create two implementations, deriving from the appropriate types:

```csharp
public class SampleLeanbackPreferencesFragment : LeanbackPreferenceFragment
{
    public override void OnCreatePreferences (Bundle savedInstanceState, String rootKey) 
    {
        AddPreferencesFromResource (Resource.Xml.Preferences);
    }
}

public class SamplePreferencesFragment : PreferenceFragment
{
    public override void OnCreatePreferences (Bundle savedInstanceState, String rootKey) 
    {
        AddPreferencesFromResource (Resource.Xml.Preferences);
    }
}
```

Note that in the `OnCreatePreferences` methods both add preferences from the same xml resource we created earlier.



## Set up your Activity Layout

The easiest way to load the fragments we just created is to let the Android Layout files automatically pick the right fragment for the right platform.  For most platforms the layout file in the `layout` folder will look like this:

```xml
<?xml version="1.0" encoding="utf-8"?>
<FrameLayout xmlns:android="http://schemas.android.com/apk/res/android"
    android:layout_width="match_parent"
    android:layout_height="match_parent"
    android:id="@+id/container">
    <fragment
        android:name="androidsupportsample.SamplePreferencesFragment"
        android:layout_width="match_parent"
        android:layout_height="match_parent"
        android:id="@+id/fragmentPrefs" />
</FrameLayout>
```

If you are supporting Leanback, you can create a `layout-television` folder and add the following layout xml in a file with the same name as the first layout:

```xml
<?xml version="1.0" encoding="utf-8"?>
<FrameLayout xmlns:android="http://schemas.android.com/apk/res/android"
    android:layout_width="match_parent"
    android:layout_height="match_parent"
    android:id="@+id/container">
    <fragment
        android:name="androidsupportsample.SampleLeanbackPreferencesFragment"
        android:layout_width="match_parent"
        android:layout_height="match_parent"
        android:id="@+id/fragmentPrefs" />
</FrameLayout>
```

Note that the only difference in the television version is that it's using the `SampleLeanbackPreferencesFragment` instead of the `SamplePreferencesFragment`.  This way, our application will choose the correct layout and fragment to initialize for the right device at runtime.

