using System;

namespace Android.Gms.Wallet
{
    public partial class WalletClass
    {
        [Obsolete ("Use API instead")]
        public static Android.Gms.Common.Apis.Api Api {
            get { return null; } // Android.Gms.Wallet.WalletClass.API; }
        }
    }
}

