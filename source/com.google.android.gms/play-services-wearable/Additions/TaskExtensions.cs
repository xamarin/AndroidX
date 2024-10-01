using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.Runtime;
using Java.IO;
using Android.Gms.Extensions;

namespace Android.Gms.Wearable
{
    public partial class CapabilityClient
    {
        public Task AddListenerAsync (IOnCapabilityChangedListener p0, Android.Net.Uri p1, int p2)
        {
            return AddListener (p0, p1, p2).AsAsync ();
        }

        public Task AddListenerAsync (IOnCapabilityChangedListener p0, String p1)
        {
            return AddListener (p0, p1).AsAsync ();
        }

        public Task AddLocalCapabilityAsync (String p0)
        {
            return AddLocalCapability (p0).AsAsync ();
        }

        public Task<JavaDictionary<Java.Lang.String, ICapabilityInfo>> GetAllCapabilitiesAsync (int p0)
        {
            return GetAllCapabilities (p0).AsAsync<JavaDictionary<Java.Lang.String, ICapabilityInfo>> ();
        }

        public Task<ICapabilityInfo> GetCapabilityAsync (String p0, int p1)
        {
            return GetCapability (p0, p1).AsAsync<ICapabilityInfo> ();
        }

        public Task<Java.Lang.Boolean> RemoveListenerAsync (IOnCapabilityChangedListener p0)
        {
            return RemoveListener (p0).AsAsync<Java.Lang.Boolean> ();
        }

        public Task<Java.Lang.Boolean> RemoveListenerAsync (IOnCapabilityChangedListener p0, String p1)
        {
            return RemoveListener (p0, p1).AsAsync<Java.Lang.Boolean> ();
        }

        public Task RemoveLocalCapabilityAsync (String p0)
        {
            return RemoveLocalCapability (p0).AsAsync ();
        }
    }

    public partial class ChannelClient
    {
        public Task CloseAsync (IChannel p0)
        {
            return Close (p0).AsAsync ();
        }

        public Task CloseAsync (IChannel p0, int p1)
        {
            return Close (p0, p1).AsAsync ();
        }

        public Task<InputStream> GetInputStreamAsync (IChannel p0)
        {
            return GetInputStream (p0).AsAsync<InputStream> ();
        }

        public Task<OutputStream> GetOutputStreamAsync (IChannel p0)
        {
            return GetOutputStream (p0).AsAsync<OutputStream> ();
        }

        public Task<IChannel> OpenChannelAsync (String p0, String p1)
        {
            return OpenChannel (p0, p1).AsAsync<IChannel> ();
        }

        public Task ReceiveFileAsync (IChannel p0, Android.Net.Uri p1, bool p2)
        {
            return ReceiveFile (p0, p1, p2).AsAsync ();
        }

        public Task RegisterChannelCallbackAsync (IChannel p0, ChannelCallback p1)
        {
            return RegisterChannelCallback (p0, p1).AsAsync ();
        }

        public Task RegisterChannelCallbackAsync (ChannelCallback p0)
        {
            return RegisterChannelCallback (p0).AsAsync ();
        }

        public Task SendFileAsync (IChannel p0, Android.Net.Uri p1)
        {
            return SendFile (p0, p1).AsAsync ();
        }

        public Task SendFileAsync (IChannel p0, Android.Net.Uri p1, long p2, long p3)
        {
            return SendFile (p0, p1, p2, p3).AsAsync ();
        }

        public Task<Java.Lang.Boolean> UnregisterChannelCallbackAsync (IChannel p0, ChannelCallback p1)
        {
            return UnregisterChannelCallback (p0, p1).AsAsync<Java.Lang.Boolean> ();
        }

        public Task<Java.Lang.Boolean> UnregisterChannelCallbackAsync (ChannelCallback p0)
        {
            return UnregisterChannelCallback (p0).AsAsync<Java.Lang.Boolean> ();
        }
    }

    public partial class DataClient
    {
        public Task AddListenerAsync (IOnDataChangedListener p0)
        {
            return AddListener (p0).AsAsync ();
        }

        public Task AddListenerAsync (IOnDataChangedListener p0, Android.Net.Uri p1, int p2)
        {
            return AddListener (p0, p1, p2).AsAsync ();
        }

        public Task<Java.Lang.Integer> DeleteDataItemsAsync (Android.Net.Uri p0)
        {
            return DeleteDataItems (p0).AsAsync<Java.Lang.Integer> ();
        }

        public Task<Java.Lang.Integer> DeleteDataItemsAsync (Android.Net.Uri p0, int p1)
        {
            return DeleteDataItems (p0, p1).AsAsync<Java.Lang.Integer> ();
        }

        public Task<IDataItem> GetDataItemAsync (Android.Net.Uri p0)
        {
            return GetDataItem (p0).AsAsync<IDataItem> ();
        }

        public Task<DataItemBuffer> GetDataItemsAsync ()
        {
            return GetDataItems ().AsAsync<DataItemBuffer> ();
        }

        public Task<DataItemBuffer> GetDataItemsAsync (Android.Net.Uri p0)
        {
            return GetDataItems (p0).AsAsync<DataItemBuffer> ();
        }

        public Task<DataItemBuffer> GetDataItemsAsync (Android.Net.Uri p0, int p1)
        {
            return GetDataItems (p0, p1).AsAsync<DataItemBuffer> ();
        }

        //public Task<DataClienGetFdForAssetResponse> GetFdForAssetAsync (Asset p0)
        //{
        //    return GetFdForAsset (p0).AsAsync<DataClienGetFdForAssetResponse> ();
        //}

        //public Task<DataClienGetFdForAssetResponse> GetFdForAssetAsync (IDataItemAsset p0)
        //{
        //    return GetFdForAsset (p0).AsAsync<DataClienGetFdForAssetResponse> ();
        //}

        public Task<IDataItem> PutDataItemAsync (PutDataRequest p0)
        {
            return PutDataItem (p0).AsAsync<IDataItem> ();
        }

        public Task<Java.Lang.Boolean> RemoveListenerAsync (IOnDataChangedListener p0)
        {
            return RemoveListener (p0).AsAsync<Java.Lang.Boolean> ();
        }
    }

    public partial class MessageClient
    {
        public Task AddListenerAsync (IOnMessageReceivedListener p0)
        {
            return AddListener (p0).AsAsync ();
        }

        public Task AddListenerAsync (IOnMessageReceivedListener p0, Android.Net.Uri p1, int p2)
        {
            return AddListener (p0, p1, p2).AsAsync ();
        }

        public Task<Java.Lang.Boolean> RemoveListenerAsync (IOnMessageReceivedListener p0)
        {
            return RemoveListener (p0).AsAsync<Java.Lang.Boolean> ();
        }

        public Task<Java.Lang.Integer> SendMessageAsync (String p0, String p1, byte[] p2)
        {
            return SendMessage (p0, p1, p2).AsAsync<Java.Lang.Integer> ();
        }
    }

    public partial class NodeClient
    {
        public Task<JavaList<INode>> GetConnectedNodesAsync ()
        {
            return GetConnectedNodes ().AsAsync<JavaList<INode>> ();
        }

        public Task<INode> GetLocalNodeAsync ()
        {
            return GetLocalNode ().AsAsync<INode> ();
        }
    }
}
