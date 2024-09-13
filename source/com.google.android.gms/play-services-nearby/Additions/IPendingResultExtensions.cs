using System;
using System.Threading.Tasks;
using Android.Gms.Common.Apis;
using Android.Runtime;

namespace Android.Gms.Nearby.Connection
{
    public static partial class IConnectionsExtensions
    {
		public static async Task<Statuses> AcceptConnectionAsync(this IConnections api, GoogleApiClient apiClient, string endpointId, PayloadCallback payloadCallback)
		{
			return (await api.AcceptConnection(apiClient, endpointId, payloadCallback)).JavaCast<Statuses>();
		}

		public static async Task<Statuses> RejectConnectionAsync(this IConnections api, GoogleApiClient apiClient, string endpointId)
		{
			return (await api.RejectConnection(apiClient, endpointId)).JavaCast<Statuses>();
		}

		public static async Task<Statuses> RequestConnectionAsync(this IConnections api, GoogleApiClient apiClient, string name, string endpointId, ConnectionLifecycleCallback connectionLifecycleCallback)
		{
			return (await api.RequestConnection(apiClient, name, endpointId, connectionLifecycleCallback)).JavaCast<Statuses>();
		}

		public static async Task<Statuses> SendPayloadAsync(this IConnections api, GoogleApiClient apiClient, System.Collections.Generic.IList<string> endpointIds, Payload payload)
		{
			return (await api.SendPayload(apiClient, endpointIds, payload)).JavaCast<Statuses>();
		}

		public static async Task<Statuses> SendPayloadAsync(this IConnections api, GoogleApiClient apiClient, string endpointId, Payload payload)
		{
			return (await api.SendPayload(apiClient, endpointId, payload)).JavaCast<Statuses>();
		}

		public static async Task<IConnectionsStartAdvertisingResult> StartAdvertisingAsync (this IConnections api, GoogleApiClient apiClient, string name, string serviceId, ConnectionLifecycleCallback connectionLifecycleCallback, AdvertisingOptions options)
		{
			return (await api.StartAdvertising(apiClient, name, serviceId, connectionLifecycleCallback, options)).JavaCast<IConnectionsStartAdvertisingResult>();
		}

		public static async Task<Statuses> StartDiscoveryAsync(this IConnections api, GoogleApiClient apiClient, string serviceId, EndpointDiscoveryCallback endpointDiscoveryCallback, DiscoveryOptions options)
		{
			return (await api.StartDiscovery(apiClient, serviceId, endpointDiscoveryCallback, options)).JavaCast<Statuses>();
		}

        [Obsolete]
        public static async Task<Statuses> AcceptConnectionRequestAsync (this IConnections api, GoogleApiClient apiClient, string remoteEndpointId, byte[] payload, IConnectionsMessageListener messageListener)
        {
            return (await api.AcceptConnectionRequest (apiClient, remoteEndpointId, payload, messageListener)).JavaCast<Statuses> ();
        }
        [Obsolete]
        public static async Task<Statuses> RejectConnectionRequestAsync (this IConnections api, GoogleApiClient apiClient, string remoteEndpointId)
        {
            return (await api.RejectConnectionRequest (apiClient, remoteEndpointId)).JavaCast<Statuses> ();
        }
        [Obsolete]
        public static async Task<Statuses> SendConnectionRequestAsync (this IConnections api, GoogleApiClient apiClient, string name, string remoteEndpointId, byte[] payload, IConnectionsConnectionResponseCallback connectionResponseCallback, IConnectionsMessageListener messageListener)
        {
            return (await api.SendConnectionRequest (apiClient, name, remoteEndpointId, payload, connectionResponseCallback, messageListener)).JavaCast<Statuses> ();
        }
        [Obsolete]
        public static async Task<IConnectionsStartAdvertisingResult> StartAdvertisingAsync (this IConnections api, GoogleApiClient apiClient, string name, Android.Gms.Nearby.Connection.AppMetadata appMetadata, long durationMillis, ConnectionsConnectionRequestListener connectionRequestListener)
        {
            return (await api.StartAdvertising (apiClient, name, appMetadata, durationMillis, connectionRequestListener)).JavaCast<IConnectionsStartAdvertisingResult> ();
        }
        [Obsolete]
        public static async Task<Statuses> StartDiscoveryAsync (this IConnections api, GoogleApiClient apiClient, string serviceId, long durationMillis, ConnectionsEndpointDiscoveryListener listener)
        {
            return (await api.StartDiscovery (apiClient, serviceId, durationMillis, listener)).JavaCast<Statuses> ();
        }

        public static async Task<Statuses> CancelPayloadAsync (this IConnections api, GoogleApiClient apiClient, long l)
        {
            return (await api.CancelPayload (apiClient, l)).JavaCast<Statuses> ();
        }
    }
}

namespace Android.Gms.Nearby.Messages
{
    public static partial class IMessagesExtensions
    {
        [Obsolete]
        public static async Task<Statuses> GetPermissionStatusAsync (this IMessages api, GoogleApiClient client)
        {
            return (await api.GetPermissionStatus (client)).JavaCast<Statuses> ();
        }
        public static async Task<Statuses> PublishAsync (this IMessages api, GoogleApiClient client, Android.Gms.Nearby.Messages.Message message)
        {
            return (await api.Publish (client, message)).JavaCast<Statuses> ();
        }
        public static async Task<Statuses> PublishAsync (this IMessages api, GoogleApiClient client, Android.Gms.Nearby.Messages.Message message, Android.Gms.Nearby.Messages.PublishOptions options)
        {
            return (await api.Publish (client, message, options)).JavaCast<Statuses> ();
        }
        public static async Task<Statuses> RegisterStatusCallbackAsync (this IMessages api, GoogleApiClient client, Android.Gms.Nearby.Messages.StatusCallback statusCallback)
        {
            return (await api.RegisterStatusCallback (client, statusCallback)).JavaCast<Statuses> ();
        }
        public static async Task<Statuses> SubscribeAsync (this IMessages api, GoogleApiClient client, Android.Gms.Nearby.Messages.MessageListener listener)
        {
            return (await api.Subscribe (client, listener)).JavaCast<Statuses> ();
        }
        public static async Task<Statuses> SubscribeAsync (this IMessages api, GoogleApiClient client, Android.Gms.Nearby.Messages.MessageListener listener, Android.Gms.Nearby.Messages.SubscribeOptions options)
        {
            return (await api.Subscribe (client, listener, options)).JavaCast<Statuses> ();
        }
        public static async Task<Statuses> UnpublishAsync (this IMessages api, GoogleApiClient client, Android.Gms.Nearby.Messages.Message message)
        {
            return (await api.Unpublish (client, message)).JavaCast<Statuses> ();
        }
        public static async Task<Statuses> UnregisterStatusCallbackAsync (this IMessages api, GoogleApiClient client, Android.Gms.Nearby.Messages.StatusCallback statusCallback)
        {
            return (await api.UnregisterStatusCallback (client, statusCallback)).JavaCast<Statuses> ();
        }
        public static async Task<Statuses> UnsubscribeAsync (this IMessages api, GoogleApiClient client, Android.Gms.Nearby.Messages.MessageListener listener)
        {
            return (await api.Unsubscribe (client, listener)).JavaCast<Statuses> ();
        }
        public static async Task<Statuses> SubscribeAsync (this IMessages api, GoogleApiClient client, Android.App.PendingIntent pendingIntent)
        {
            return (await api.Subscribe (client, pendingIntent)).JavaCast<Statuses> ();
        }
        public static async Task<Statuses> SubscribeAsync (this IMessages api, GoogleApiClient client, Android.App.PendingIntent pendingIntent, SubscribeOptions options)
        {
            return (await api.Subscribe (client, pendingIntent, options)).JavaCast<Statuses> ();
        }
        public static async Task<Statuses> UnsubscribeAsync (this IMessages api, GoogleApiClient client, Android.App.PendingIntent pendingIntent)
        {
            return (await api.Unsubscribe (client, pendingIntent)).JavaCast<Statuses> ();
        }
    }
}


