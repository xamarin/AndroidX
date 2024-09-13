using System;

namespace Android.Gms.Drive
{
    public partial class DriveClass
    {
        [Obsolete ("Use API Instead")]
        public static Android.Gms.Common.Apis.Api Api {
            get { return Android.Gms.Drive.DriveClass.API; }
        }
    }
}

