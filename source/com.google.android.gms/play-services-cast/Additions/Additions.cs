using System;

namespace Android.Gms.Cast
{
    public partial class CastClass
    {
        [Obsolete ("Use API instead")]
        public static Android.Gms.Common.Apis.Api Api {
            get { return Android.Gms.Cast.CastClass.API; }
        }
    }
}

