using System;
using System.Collections.Generic;
using System.Text;

namespace AndroidX.AppCompat.Graphics.Drawable
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso href="https://github.com/dotnet/maui/issues/16074" />
    /// <seealso href="https://github.com/xamarin/Xamarin.Forms/issues/15668" />
    /// <seealso href="https://github.com/xamarin/AndroidX/issues/690#issuecomment-1414325720" />
    [Obsolete("This class is obsoleted in this android platform. Google replaced DrawableContainer with DrawableContainerCompat")]
    public partial class DrawableContainer : DrawableContainerCompat
    {
    }
}