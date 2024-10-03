using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.Gms.Extensions;

namespace Android.Gms.Nearby.Connection
{
    public static partial class ConnectionsClientExtensions
    {
        public static Task AcceptConnectionAsync (this IConnectionsClient self, String p0, PayloadCallback p1)
        {
            return self.AcceptConnection (p0, p1).AsAsync ();
        }

        public static Task CancelPayloadAsync (this IConnectionsClient self, long p0)
        {
            return self.CancelPayload (p0).AsAsync ();
        }

        public static Task RejectConnectionAsync (this IConnectionsClient self, String p0)
        {
            return self.RejectConnection (p0).AsAsync ();
        }

        public static Task RequestConnectionAsync (this IConnectionsClient self, String p0, String p1, ConnectionLifecycleCallback p2)
        {
            return self.RequestConnection (p0, p1, p2).AsAsync ();
        }

        public static Task SendPayloadAsync (this IConnectionsClient self, String p0, Payload p1)
        {
            return self.SendPayload (p0, p1).AsAsync ();
        }

        public static Task SendPayloadAsync (this IConnectionsClient self, IList<String> p0, Payload p1)
        {
            return self.SendPayload (p0, p1).AsAsync ();
        }

        public static Task StartAdvertisingAsync (this IConnectionsClient self, String p0, String p1, ConnectionLifecycleCallback p2, AdvertisingOptions p3)
        {
            return self.StartAdvertising (p0, p1, p2, p3).AsAsync ();
        }

        public static Task StartDiscoveryAsync (this IConnectionsClient self, String p0, EndpointDiscoveryCallback p1, DiscoveryOptions p2)
        {
            return self.StartDiscovery (p0, p1, p2).AsAsync ();
        }
    }
}

namespace Android.Gms.Nearby.Messages
{
    public static partial class MessagesClientExtensions
    {
        public static Task PublishAsync (this IMessagesClient self, Message p0)
        {
            return self.Publish (p0).AsAsync ();
        }

        public static Task PublishAsync (this IMessagesClient self, Message p0, PublishOptions p1)
        {
            return self.Publish (p0, p1).AsAsync ();
        }

        public static Task RegisterStatusCallbackAsync (this IMessagesClient self, StatusCallback p0)
        {
            return self.RegisterStatusCallback (p0).AsAsync ();
        }

        public static Task SubscribeAsync (this IMessagesClient self, PendingIntent p0)
        {
            return self.Subscribe (p0).AsAsync ();
        }

        public static Task SubscribeAsync (this IMessagesClient self, PendingIntent p0, SubscribeOptions p1)
        {
            return self.Subscribe (p0, p1).AsAsync ();
        }

        public static Task SubscribeAsync (this IMessagesClient self, MessageListener p0)
        {
            return self.Subscribe (p0).AsAsync ();
        }

        public static Task SubscribeAsync (this IMessagesClient self, MessageListener p0, SubscribeOptions p1)
        {
            return self.Subscribe (p0, p1).AsAsync ();
        }

        public static Task UnpublishAsync (this IMessagesClient self, Message p0)
        {
            return self.Unpublish (p0).AsAsync ();
        }

        public static Task UnregisterStatusCallbackAsync (this IMessagesClient self, StatusCallback p0)
        {
            return self.UnregisterStatusCallback (p0).AsAsync ();
        }

        public static Task UnsubscribeAsync (this IMessagesClient self, PendingIntent p0)
        {
            return self.Unsubscribe (p0).AsAsync ();
        }

        public static Task UnsubscribeAsync (this IMessagesClient self, MessageListener p0)
        {
            return self.Unsubscribe (p0).AsAsync ();
        }
    }

}
