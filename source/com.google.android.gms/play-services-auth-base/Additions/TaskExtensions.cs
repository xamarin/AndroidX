using System;
using System.Threading.Tasks;
using Android.Gms.Extensions;

namespace Android.Gms.Auth.Account
{
	public partial class WorkAccountClient
	{
		public virtual Task<Android.Accounts.Account> AddWorkAccountAsync(string token)
		{
			return AddWorkAccount(token).AsAsync<Android.Accounts.Account>();
		}

		public virtual Task RemoveWorkAccountAsync(Android.Accounts.Account account)
		{
			return RemoveWorkAccount(account).AsAsync();
		}

		public virtual Task SetWorkAuthenticatorEnabledAsync(bool enabled)
		{
			return SetWorkAuthenticatorEnabled(enabled).AsAsync();
		}
	}
}

namespace Android.Gms.Auth.Api.AccountTransfer
{
	public partial class AccountTransferClient
	{
		public Task<DeviceMetaData> GetDeviceMetaDataAsync(string accountType)
		{
			return GetDeviceMetaData(accountType).AsAsync<DeviceMetaData>();
		}

		public Task NotifyCompletionAsync(string accountType, int completionStatus)
		{
			return NotifyCompletion(accountType, completionStatus).AsAsync();
		}

		public Task SendDataAsync(string accountType, byte[] transferData)
		{
			return SendData(accountType, transferData).AsAsync();
		}

		public Task ShowUserChallengeAsync(string accountType, Android.App.PendingIntent pendingIntent)
		{
			return ShowUserChallenge(accountType, pendingIntent).AsAsync();
		}
	}
}
