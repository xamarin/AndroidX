using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.Gms.Common.Apis;
using Android.Runtime;

namespace Android.Gms.Fitness
{
    public static partial class IBleApiExtensions
    {
        public static async Task<Statuses> ClaimBleDeviceAsync (this IBleApi api, GoogleApiClient client, Data.BleDevice bleDevice)
        {
            return (await api.ClaimBleDevice (client, bleDevice)).JavaCast<Statuses> ();
        }
        public static async Task<Statuses> ClaimBleDeviceAsync (this IBleApi api, GoogleApiClient client, string deviceAddress)
        {
            return (await api.ClaimBleDevice (client, deviceAddress)).JavaCast<Statuses> ();
        }
        public static async Task<Result.BleDevicesResult> ListClaimedBleDevicesAsync (this IBleApi api, GoogleApiClient client)
        {
            return (await api.ListClaimedBleDevices (client)).JavaCast<Result.BleDevicesResult> ();
        }
        public static async Task<Statuses> StartBleScanAsync (this IBleApi api, GoogleApiClient client, Request.StartBleScanRequest request)
        {
            return (await api.StartBleScan (client, request)).JavaCast<Statuses> ();
        }
        public static async Task<Statuses> StopBleScanAsync (this IBleApi api, GoogleApiClient client, Request.BleScanCallback requestCallback)
        {
            return (await api.StopBleScan (client, requestCallback)).JavaCast<Statuses> ();
        }
        public static async Task<Statuses> UnclaimBleDeviceAsync (this IBleApi api, GoogleApiClient client, Data.BleDevice bleDevice)
        {
            return (await api.UnclaimBleDevice (client, bleDevice)).JavaCast<Statuses> ();
        }
        public static async Task<Statuses> UnclaimBleDeviceAsync (this IBleApi api, GoogleApiClient client, string deviceAddress)
        {
            return (await api.UnclaimBleDevice (client, deviceAddress)).JavaCast<Statuses> ();
        }
    }

    public static partial class IConfigApiExtensions
    {
        public static async Task<Result.DataTypeResult> CreateCustomDataTypeAsync (this IConfigApi api, GoogleApiClient client, Request.DataTypeCreateRequest request)
        {
            return (await api.CreateCustomDataType (client, request)).JavaCast<Result.DataTypeResult> ();
        }
        public static async Task<Statuses> DisableFitAsync (this IConfigApi api, GoogleApiClient client)
        {
            return (await api.DisableFit (client)).JavaCast<Statuses> ();
        }
        public static async Task<Result.DataTypeResult> ReadDataTypeAsync (this IConfigApi api, GoogleApiClient client, string dataTypeName)
        {
            return (await api.ReadDataType (client, dataTypeName)).JavaCast<Result.DataTypeResult> ();
        }
    }

    public static partial class IHistoryApiExtensions
    {
        public static async Task<Statuses> DeleteDataAsync (this IHistoryApi api, GoogleApiClient client, Request.DataDeleteRequest request)
        {
            return (await api.DeleteData (client, request)).JavaCast<Statuses> ();
        }
        public static async Task<Statuses> InsertDataAsync (this IHistoryApi api, GoogleApiClient client, Data.DataSet dataSet)
        {
            return (await api.InsertData (client, dataSet)).JavaCast<Statuses> ();
        }
        public static async Task<Result.DailyTotalResult> ReadDailyTotalAsync (this IHistoryApi api, GoogleApiClient client, Data.DataType dataType)
        {
            return (await api.ReadDailyTotal (client, dataType)).JavaCast<Result.DailyTotalResult> ();
        }
        public static async Task<Result.DataReadResult> ReadDataAsync (this IHistoryApi api, GoogleApiClient client, Request.DataReadRequest request)
        {
            return (await api.ReadData (client, request)).JavaCast<Result.DataReadResult> ();
        }
        public static async Task<Statuses> UpdateDataAsync (this IHistoryApi api, GoogleApiClient client, Request.DataUpdateRequest request)
        {
            return (await api.UpdateData (client, request)).JavaCast<Statuses> ();
        }
        public static async Task<Result.DailyTotalResult> ReadDailyTotalFromLocalDeviceAsync (this IHistoryApi api, GoogleApiClient client, Data.DataType dataType)
        {
            return (await api.ReadDailyTotalFromLocalDevice (client, dataType)).JavaCast<Result.DailyTotalResult> ();
        }
        public static async Task<Statuses> RegisterDataUpdateListenerAsync (this IHistoryApi api, GoogleApiClient client, Request.DataUpdateListenerRegistrationRequest request)
        {
            return (await api.RegisterDataUpdateListener (client, request)).JavaCast<Statuses> ();
        }
        public static async Task<Statuses> UnregisterDataUpdateListenerAsync (this IHistoryApi api, GoogleApiClient client, Android.App.PendingIntent pendingIntent)
        {
            return (await api.UnregisterDataUpdateListener (client, pendingIntent)).JavaCast<Statuses> ();
        }
    }

    public static partial class IRecordingApiExtensions
    {
        public static async Task<Result.ListSubscriptionsResult> ListSubscriptionsAsync (this IRecordingApi api, GoogleApiClient client)
        {
            return (await api.ListSubscriptions (client)).JavaCast<Result.ListSubscriptionsResult> ();
        }
        public static async Task<Result.ListSubscriptionsResult> ListSubscriptionsAsync (this IRecordingApi api, GoogleApiClient client, Data.DataType dataType)
        {
            return (await api.ListSubscriptions (client, dataType)).JavaCast<Result.ListSubscriptionsResult> ();
        }
        public static async Task<Statuses> SubscribeAsync (this IRecordingApi api, GoogleApiClient client, Data.DataSource dataSource)
        {
            return (await api.Subscribe (client, dataSource)).JavaCast<Statuses> ();
        }
        public static async Task<Statuses> SubscribeAsync (this IRecordingApi api, GoogleApiClient client, Data.DataType dataType)
        {
            return (await api.Subscribe (client, dataType)).JavaCast<Statuses> ();
        }
        public static async Task<Statuses> UnsubscribeAsync (this IRecordingApi api, GoogleApiClient client, Data.DataSource dataSource)
        {
            return (await api.Unsubscribe (client, dataSource)).JavaCast<Statuses> ();
        }
        public static async Task<Statuses> UnsubscribeAsync (this IRecordingApi api, GoogleApiClient client, Data.DataType dataType)
        {
            return (await api.Unsubscribe (client, dataType)).JavaCast<Statuses> ();
        }
        public static async Task<Statuses> UnsubscribeAsync (this IRecordingApi api, GoogleApiClient client, Data.Subscription subscription)
        {
            return (await api.Unsubscribe (client, subscription)).JavaCast<Statuses> ();
        }
    }

    public static partial class ISensorsApiExtensions
    {
        public static async Task<Statuses> AddAsync (this ISensorsApi api, GoogleApiClient client, Request.SensorRequest request, Android.App.PendingIntent intent)
        {
            return (await api.Add (client, request, intent)).JavaCast<Statuses> ();
        }
        public static async Task<Statuses> AddAsync (this ISensorsApi api, GoogleApiClient client, Request.SensorRequest request, Request.IOnDataPointListener listener)
        {
            return (await api.Add (client, request, listener)).JavaCast<Statuses> ();
        }
        public static async Task<Result.DataSourcesResult> FindDataSourcesAsync (this ISensorsApi api, GoogleApiClient client, Request.DataSourcesRequest request)
        {
            return (await api.FindDataSources (client, request)).JavaCast<Result.DataSourcesResult> ();
        }
        public static async Task<Statuses> RemoveAsync (this ISensorsApi api, GoogleApiClient client, Android.App.PendingIntent pendingIntent)
        {
            return (await api.Remove (client, pendingIntent)).JavaCast<Statuses> ();
        }
        public static async Task<Statuses> RemoveAsync (this ISensorsApi api, GoogleApiClient client, Request.IOnDataPointListener listener)
        {
            return (await api.Remove (client, listener)).JavaCast<Statuses> ();
        }
    }

    public static partial class ISessionsApiExtensions
    {
        public static async Task<Statuses> InsertSessionAsync (this ISessionsApi api, GoogleApiClient client, Request.SessionInsertRequest request)
        {
            return (await api.InsertSession (client, request)).JavaCast<Statuses> ();
        }
        public static async Task<Result.SessionReadResult> ReadSessionAsync (this ISessionsApi api, GoogleApiClient client, Request.SessionReadRequest request)
        {
            return (await api.ReadSession (client, request)).JavaCast<Result.SessionReadResult> ();
        }
        public static async Task<Statuses> RegisterForSessionsAsync (this ISessionsApi api, GoogleApiClient client, Android.App.PendingIntent intent)
        {
            return (await api.RegisterForSessions (client, intent)).JavaCast<Statuses> ();
        }
        public static async Task<Statuses> StartSessionAsync (this ISessionsApi api, GoogleApiClient client, Data.Session session)
        {
            return (await api.StartSession (client, session)).JavaCast<Statuses> ();
        }
        public static async Task<Result.SessionStopResult> StopSessionAsync (this ISessionsApi api, GoogleApiClient client, string identifier)
        {
            return (await api.StopSession (client, identifier)).JavaCast<Result.SessionStopResult> ();
        }
        public static async Task<Statuses> UnregisterForSessionsAsync (this ISessionsApi api, GoogleApiClient client, Android.App.PendingIntent intent)
        {
            return (await api.UnregisterForSessions (client, intent)).JavaCast<Statuses> ();
        }
    }

    public static partial class IGoalsApiExtensions
    {
        public static async Task<Result.GoalsResult> ReadCurrentGoals(this IGoalsApi api, Android.Gms.Common.Apis.GoogleApiClient client, Request.GoalsReadRequest request)
        {
            return (await api.ReadCurrentGoals(client, request)).JavaCast<Result.GoalsResult> ();
        }
    }
}

