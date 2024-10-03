using System;
using System.Threading.Tasks;
using Android.App;
using Android.Gms.Fitness.Data;
using Android.Gms.Fitness.Result;
using Android.Gms.Fitness.Request;
using Java.Util;
using Android.Gms.Extensions;
using Android.Runtime;

namespace Android.Gms.Fitness
{
    public partial class BleClient
    {
        public Task ClaimBleDeviceAsync (BleDevice p0)
        {
            return ClaimBleDevice (p0).AsAsync ();
        }

        public Task ClaimBleDeviceAsync (String p0)
        {
            return ClaimBleDevice (p0).AsAsync ();
        }

        public Task<JavaSet<BleDevice>> ListClaimedBleDevicesAsync ()
        {
            return ListClaimedBleDevices ().AsAsync<JavaSet<BleDevice>> ();
        }

        public Task StartBleScanAsync (JavaList<DataType> p0, int p1, BleScanCallback p2)
        {
            return StartBleScan (p0, p1, p2).AsAsync ();
        }

        public Task<Java.Lang.Boolean> StopBleScanAsync (BleScanCallback p0)
        {
            return StopBleScan (p0).AsAsync<Java.Lang.Boolean> ();
        }

        public Task UnclaimBleDeviceAsync (BleDevice p0)
        {
            return UnclaimBleDevice (p0).AsAsync ();
        }

        public Task UnclaimBleDeviceAsync (String p0)
        {
            return UnclaimBleDevice (p0).AsAsync ();
        }
    }

    public partial class ConfigClient
    {
        public Task<DataType> CreateCustomDataTypeAsync (DataTypeCreateRequest p0)
        {
            return CreateCustomDataType (p0).AsAsync<DataType> ();
        }

        public Task DisableFitAsync ()
        {
            return DisableFit ().AsAsync ();
        }

        public Task<DataType> ReadDataTypeAsync (String p0)
        {
            return ReadDataType (p0).AsAsync<DataType> ();
        }

    }

    public partial class GoalsClient
    {
        public Task<JavaList<Goal>> ReadCurrentGoalsAsync (GoalsReadRequest p0)
        {
            return ReadCurrentGoals (p0).AsAsync<JavaList<Goal>> ();
        }
    }

    public partial class HistoryClient
    {
        public Task DeleteDataAsync (DataDeleteRequest p0)
        {
            return DeleteData (p0).AsAsync ();
        }

        public Task InsertDataAsync (DataSet p0)
        {
            return InsertData (p0).AsAsync ();
        }

        public Task<DataSet> ReadDailyTotalAsync (DataType p0)
        {
            return ReadDailyTotal (p0).AsAsync<DataSet> ();
        }

        public Task<DataSet> ReadDailyTotalFromLocalDeviceAsync (DataType p0)
        {
            return ReadDailyTotalFromLocalDevice (p0).AsAsync<DataSet> ();
        }

        public Task<DataReadResponse> ReadDataAsync (DataReadRequest p0)
        {
            return ReadData (p0).AsAsync<DataReadResponse> ();
        }

        public Task RegisterDataUpdateListenerAsync (DataUpdateListenerRegistrationRequest p0)
        {
            return RegisterDataUpdateListener (p0).AsAsync ();
        }

        public Task UnregisterDataUpdateListenerAsync (PendingIntent p0)
        {
            return UnregisterDataUpdateListener (p0).AsAsync ();
        }

        public Task UpdateDataAsync (DataUpdateRequest p0)
        {
            return UpdateData (p0).AsAsync ();
        }
    }

    public partial class RecordingClient
    {
        public Task<JavaList<Subscription>> ListSubscriptionsAsync ()
        {
            return ListSubscriptions ().AsAsync<JavaList<Subscription>> ();
        }

        public Task<JavaList<Subscription>> ListSubscriptionsAsync (DataType p0)
        {
            return ListSubscriptions (p0).AsAsync<JavaList<Subscription>> ();
        }

        public Task SubscribeAsync (DataSource p0)
        {
            return Subscribe (p0).AsAsync ();
        }

        public Task SubscribeAsync (DataType p0)
        {
            return Subscribe (p0).AsAsync ();
        }

        public Task UnsubscribeAsync (DataSource p0)
        {
            return Unsubscribe (p0).AsAsync ();
        }

        public Task UnsubscribeAsync (DataType p0)
        {
            return Unsubscribe (p0).AsAsync ();
        }

        public Task UnsubscribeAsync (Subscription p0)
        {
            return Unsubscribe (p0).AsAsync ();
        }
    }

    public partial class SensorsClient
    {
        public Task AddAsync (SensorRequest p0, PendingIntent p1)
        {
            return Add (p0, p1).AsAsync ();
        }

        public Task AddAsync (SensorRequest p0, IOnDataPointListener p1)
        {
            return Add (p0, p1).AsAsync ();
        }

        public Task<JavaList<DataSource>> FindDataSourcesAsync (DataSourcesRequest p0)
        {
            return FindDataSources (p0).AsAsync<JavaList<DataSource>> ();
        }

        public Task RemoveAsync (PendingIntent p0)
        {
            return Remove (p0).AsAsync ();
        }

        public Task<Java.Lang.Boolean> RemoveAsync (IOnDataPointListener p0)
        {
            return Remove (p0).AsAsync<Java.Lang.Boolean> ();
        }
    }

    public partial class SessionsClient
    {
        public Task InsertSessionAsync (SessionInsertRequest p0)
        {
            return InsertSession (p0).AsAsync ();
        }

        public Task<SessionReadResponse> ReadSessionAsync (SessionReadRequest p0)
        {
            return ReadSession (p0).AsAsync<SessionReadResponse> ();
        }

        public Task RegisterForSessionsAsync (PendingIntent p0)
        {
            return RegisterForSessions (p0).AsAsync ();
        }

        public Task StartSessionAsync (Session p0)
        {
            return StartSession (p0).AsAsync ();
        }

        public Task<JavaList<Session>> StopSessionAsync (String p0)
        {
            return StopSession (p0).AsAsync<JavaList<Session>> ();
        }

        public Task UnregisterForSessionsAsync (PendingIntent p0)
        {
            return UnregisterForSessions (p0).AsAsync ();
        }
    }
}
