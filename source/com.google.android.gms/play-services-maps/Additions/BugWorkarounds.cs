using System;

namespace Android.Gms.Maps.Model
{
    public partial class MarkerOptions
    {
        [Obsolete ("Use SetAlpha instead")]
        public MarkerOptions InvokeAlpha (float alpha)
        {
            return SetAlpha (alpha);
        }

        [Obsolete ("Use SetRotation instead")]
        public MarkerOptions InvokeRotation (float rotation)
        {
            return SetRotation (rotation);
        }

        [Obsolete ("Use SetIcon instead")]
        public MarkerOptions InvokeIcon (BitmapDescriptor icon)
        {
            return SetIcon (icon);
        }
    }
}

