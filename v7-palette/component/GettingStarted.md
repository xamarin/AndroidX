
The Palette Support Library helps extract prominent colors from an image.

A number of colors with different profiles are extracted from the image:
 - Vibrant
 - Vibrant Dark
 - Vibrant Light
 - Muted
 - Muted Dark
 - Muted Light

### Target SDK Version 
NOTE: Using this support library requires that your app have its Target Android Version (*targetSdkVersion*) set to Lollipop (5.0 - API Level 21) or higher, or you will have *aapt* related compile errors.  You can still set the Target Framework which your app is compiled against as low as Android 4.0.3 (API Level 15).


Extracting Palette Colors
-------------------------

You can extract a palette of colors from a bitmap image using the synchronous or asynchronous methods.

```csharp
// Synchronous call
var palette = Palette.Generate (someBitmap);

var vibrantColor = palette.GetVibrantColor (defaultVibrantColor);
var darkVibrantColor = palette.GetDarkVibrantColor (defaultDarkVibrantColor);
var lightVibrantColor = palette.GetLightVibrantColor (defaultLightVibrantColor);
var mutedColor = palette.GetMutedColor (defaultMutedColor);
var mutedDarkColor = palette.GetDarkMutedColor (defaultDarkMutedColor);
var mutedLightColor = palette.GetLightMutedColor (defaultLightMutedColor);

Window.SetBackgroundDrawable (new ColorDrawable (new Color (vibrantColor)));
```

```csharp
// Asynchronous call - second param is an instance of Palette.IPaletteAsyncListener
Palette.GenerateAsync (someBitmap, this);

// Palette.IPaletteAsyncListener implementation:
public void SetPalette (Palette palette)
{
	// Handle the Palette just like the synchronous example above
}
```

