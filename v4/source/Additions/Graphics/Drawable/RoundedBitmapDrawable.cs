using System;

namespace Android.Support.V4.Graphics.Drawable
{
    public partial class RoundedBitmapDrawable
    {
		
        public override void SetAlpha (int alpha)
        {
            Alpha = alpha;
        }


        public override void SetColorFilter (Android.Graphics.ColorFilter colorFilter)
        {
            ColorFilter = colorFilter;
        }
    }
}

