v7 Support GridLayout Library
=========================

This library adds support for the `GridLayout` class, which allows you to arrange user interface elements 
using a grid of rectangular cells.

### Target SDK Version 
NOTE: Using this support library requires that your app have its Target Android Version (*targetSdkVersion*) set to Lollipop (5.0 - API Level 21) or higher, or you will have *aapt* related compile errors.  You can still set the Target Framework which your app is compiled against as low as Android 4.0.3 (API Level 15).


Using GridLayout
------

#####grid_layout_1.xml
```xml
<?xml version="1.0" encoding="utf-8"?>
<android.support.v7.widget.GridLayout xmlns:android="http://schemas.android.com/apk/res/android"
    xmlns:app="http://schemas.android.com/apk/res-auto"
    android:layout_width="match_parent"
    android:layout_height="wrap_content"
    android:background="@drawable/blue"
    android:padding="10dip"
    app:columnCount="4">
    <TextView
        android:text="@string/grid_layout_1_instructions" />
    <EditText
        app:layout_gravity="fill_horizontal"
        app:layout_column="0"
        app:layout_columnSpan="4" />
    <Button
        android:text="@string/grid_layout_1_cancel"
        app:layout_column="2" />
    <Button
        android:text="@string/grid_layout_1_ok"
        android:layout_marginLeft="10dip" />
</android.support.v7.widget.GridLayout>
```
#####GridLayout1.cs
```csharp
[Activity (Label = "@string/grid_layout_1")]
public class GridLayout1 : Activity
{
	protected override void OnCreate (Bundle bundle)
	{
		base.OnCreate (bundle);
		SetContentView(Resource.Layout.grid_layout_1);
	}
}
```

