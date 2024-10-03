using System;

namespace Android.Gms.Plus
{
    public partial class PlusClass
    {
        [Obsolete ("Use API instead")]
        public Android.Gms.Common.Apis.Api Api {
            get { return PlusClass.API; }
        }
    }
}

