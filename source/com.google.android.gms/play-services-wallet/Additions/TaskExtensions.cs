using System;
using System.Threading.Tasks;
using Android.Gms.Extensions;

namespace Android.Gms.Wallet
{
	public partial class PaymentsClient
	{
		public Task<Java.Lang.Boolean> IsReadyToPayAsync(IsReadyToPayRequest isReadyToPayRequest)
		{
			return IsReadyToPay(isReadyToPayRequest).AsAsync<Java.Lang.Boolean>();
		}

		public Task<PaymentData> LoadPaymentDataAsync(PaymentDataRequest paymentDataRequest)
		{
			return LoadPaymentData(paymentDataRequest).AsAsync<PaymentData>();
		}
	}

	public partial class WalletObjectsClient
	{
		public Task<AutoResolvableVoidResult> CreateWalletObjectsAsync(CreateWalletObjectsRequest request)
		{
			return CreateWalletObjects(request).AsAsync<AutoResolvableVoidResult>();
		}
	}
}
