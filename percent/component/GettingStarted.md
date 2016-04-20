Percent Support Library
======================

The Android Percent Support Library allows developers to specify dimensions of views in terms of percentages instead of absolute numbers, or weights.

The library consists of two main layouts which allow nested views to specify percentage based layouts: `PercentRelativeLayout` and `PercentFrameLayout` which work much like their non-Percent counterparts.

Once you've incorporated one of these containers into your layout you can then specify attributes in percentages such as `app:layout_widthPercent` or `app:layout_marginTopPercent="25%"`.

Here is an example:

```xml
<android.support.percent.PercentFrameLayout 
	xmlns:android="http://schemas.android.com/apk/res/android"
    xmlns:app="http://schemas.android.com/apk/res-auto"
    android:layout_width="match_parent"
    android:layout_height="match_parent">
    <View
        android:background="#f0f0f0"
        app:layout_widthPercent="50%"
        app:layout_heightPercent="50%"
        app:layout_marginTopPercent="25%"
        app:layout_marginLeftPercent="25%" />
</android.support.percent.PercentFrameLayout>
```

