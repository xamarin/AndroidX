using System;
using Java.Lang;

namespace AndroidX.MediaRouter.App
{
    public partial class MediaRouteChooserDialog
    {
        public sealed partial class RouteComparator
        {
            public int Compare(Java.Lang.Object lhs, Java.Lang.Object rhs)
            {
                return Compare
                            (
                                (global::AndroidX.MediaRouter.Media.MediaRouter.RouteInfo)lhs,
                                (global::AndroidX.MediaRouter.Media.MediaRouter.RouteInfo)rhs
                            );
            }
        }
    }
}
