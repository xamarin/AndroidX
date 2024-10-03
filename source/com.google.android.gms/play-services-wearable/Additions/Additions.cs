using System;

namespace Android.Gms.Wearable
{

    public partial class WearableClass 
    {
        [Obsolete ("Use API instead")]
        public static Android.Gms.Common.Apis.Api Api {
            get { return WearableClass.API; }
        }
    }

}

