
This library adds support for utilizing Vector drawable graphics on devices running Android API Level 11 or higher. 

### Target SDK Version 
NOTE: Using this support library requires that your app have its Target Android Version (*targetSdkVersion*) set to Lollipop (5.0 - API Level 21) or higher, or you will have *aapt* related compile errors.  You can still set the Target Framework which your app is compiled against as low as Android 4.0.3 (API Level 15).


Using Animated Vector Drawables
------

To use your vector drawable, you should also reference the **AppCompat v7 Support Library** in your app.

Your activity should derive from `AppCompatActivity` so that the `AppCompatImageView` is automatically used at runtime where you have defined `ImageView` types.

Here is an example of an animated vector.  It is created by defining multiple resources.

1. Create a vector image by creating a file `Resources/drawable/vector.xml` with the contents:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<vector
  xmlns:android="http://schemas.android.com/apk/res/android"
  android:height="64dp"
  android:width="64dp"
  android:viewportHeight="600"
  android:viewportWidth="600" >
  <group
    android:name="rotationGroup"
    android:pivotX="300.0"
    android:pivotY="300.0"
    android:rotation="45.0" >
    <path
      android:name="v"
      android:fillColor="#000000"
      android:pathData="M300,70 l 0,-70 70,70 0,0 -70,70z" />
  </group>
</vector>

```



2. Create a file `Resources/anim/path_morph.xml` with the contents:

```xml
<?xml version="1.0" encoding="UTF-8" ?>
<set
  xmlns:android="http://schemas.android.com/apk/res/android">
  <objectAnimator
    android:duration="3000"
    android:propertyName="pathData"
    android:valueFrom="M300,70 l 0,-70 70,70 0,0   -70,70z"
      android:valueTo="M300,70 l 0,-70 70,0  0,140 -70,0 z"
    android:valueType="pathType"/>
</set>
```


3. Create a file `Resources/anim/rotation.xml` with the contents:

```xml
<?xml version="1.0" encoding="UTF-8" ?>
<objectAnimator
  xmlns:android="http://schemas.android.com/apk/res/android"
  android:duration="6000"
  android:propertyName="rotation"
  android:valueFrom="0"
  android:valueTo="360" />
```


Finally, create an animated vector drawable file `Resources/anim/avd.xml` to tie the vector and animations together with the contents:

```xml
<?xml version="1.0" encoding="UTF-8" ?>
<animated-vector
  xmlns:android="http://schemas.android.com/apk/res/android"
  android:drawable="@drawable/vector" >
  <target
    android:name="rotationGroup"
    android:animation="@anim/rotation" />
  <target
    android:name="v"
    android:animation="@anim/path_morph" />
</animated-vector>
```

You can then reference your vector drawable programmatically, or declaratively in your android layout xml.

To use your vector drawable programmatically:

```csharp
imageView.SetImageResource (Resource.Drawable.avd);
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
        app:srcCompat="@drawable/avd"
        android:layout_width="match_parent"
        android:layout_height="fill_parent"
        android:layout_weight="1"
        android:id="@+id/imageView" />
</LinearLayout>
```

Finally, you will need to start the animation from your code:

```csharp
imageView.Drawable.JavaCast<Android.Graphics.Drawables.IAnimatable> ().Start ();
```


**NOTE:** The `Xamarin.Android.Support.Vector.Drawable` nuget package contains a .targets file which appends the argument `--no-version-vectors` to  `AndroidResgenExtraArgs` build property value to ensure the parameter is passed to the `aapt` invocation.
