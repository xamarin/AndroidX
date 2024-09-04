using System;

namespace Android.Gms.Panorama
{
    public partial class PanoramaClass
    {
        [Obsolete ("Use API instead")]
        public static Android.Gms.Common.Apis.Api Api {
            get {
                return PanoramaClass.API;
            }
        }
    }
}

