using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Android.Gms.Common.Apis;
using Android.Runtime;

namespace Android.Gms.Wearable
{
    public static partial class ICapabilityApiExtensions
    {
        public static async Task<Statuses> AddCapabilityListenerAsync (this ICapabilityApi api, GoogleApiClient client, ICapabilityApiCapabilityListener listener, string capability)
        {
            return (await api.AddCapabilityListener (client, listener, capability)).JavaCast<Statuses> ();
        }
        public static async Task<ICapabilityApiAddLocalCapabilityResult> AddLocalCapabilityAsync (this ICapabilityApi api, GoogleApiClient client, string capability)
        {
            return (await api.AddLocalCapability (client, capability)).JavaCast<ICapabilityApiAddLocalCapabilityResult> ();
        }
        public static async Task<ICapabilityApiGetAllCapabilitiesResult> GetAllCapabilitiesAsync (this ICapabilityApi api, GoogleApiClient client, int filter)
        {
            return (await api.GetAllCapabilities (client, filter)).JavaCast<ICapabilityApiGetAllCapabilitiesResult> ();
        }
        public static async Task<ICapabilityApiGetCapabilityResult> GetCapabilityAsync (this ICapabilityApi api, GoogleApiClient client, string capability, int filter)
        {
            return (await api.GetCapability (client, capability, filter)).JavaCast<ICapabilityApiGetCapabilityResult> ();
        }
        public static async Task<Statuses> RemoveCapabilityListenerAsync (this ICapabilityApi api, GoogleApiClient client, ICapabilityApiCapabilityListener listener, string capability)
        {
            return (await api.RemoveCapabilityListener (client, listener, capability)).JavaCast<Statuses> ();
        }
        public static async Task<ICapabilityApiRemoveLocalCapabilityResult> RemoveLocalCapabilityAsync (this ICapabilityApi api, GoogleApiClient client, string capability)
        {
            return (await api.RemoveLocalCapability (client, capability)).JavaCast<ICapabilityApiRemoveLocalCapabilityResult> ();
        }
    }

    public static partial class IChannelExtensions
    {
        public static async Task<Statuses> AddListenerAsync (this IChannel api, GoogleApiClient client, IChannelApiChannelListener listener)
        {
            return (await api.AddListener (client, listener)).JavaCast<Statuses> ();
        }
        public static async Task<Statuses> CloseAsync (this IChannel api, GoogleApiClient client)
        {
            return (await api.Close (client)).JavaCast<Statuses> ();
        }
        public static async Task<Statuses> CloseAsync (this IChannel api, GoogleApiClient client, int errorCode)
        {
            return (await api.Close (client, errorCode)).JavaCast<Statuses> ();
        }
        public static async Task<IChannelGetInputStreamResult> GetInputStreamAsync (this IChannel api, GoogleApiClient client)
        {
            return (await api.GetInputStream (client)).JavaCast<IChannelGetInputStreamResult> ();
        }
        public static async Task<IChannelGetOutputStreamResult> GetOutputStreamAsync (this IChannel api, GoogleApiClient client)
        {
            return (await api.GetOutputStream (client)).JavaCast<IChannelGetOutputStreamResult> ();
        }
        public static async Task<Statuses> ReceiveFileAsync (this IChannel api, GoogleApiClient client, Android.Net.Uri uri, bool append)
        {
            return (await api.ReceiveFile (client, uri, append)).JavaCast<Statuses> ();
        }
        public static async Task<Statuses> RemoveListenerAsync (this IChannel api, GoogleApiClient client, IChannelApiChannelListener listener)
        {
            return (await api.RemoveListener (client, listener)).JavaCast<Statuses> ();
        }
        public static async Task<Statuses> SendFileAsync (this IChannel api, GoogleApiClient client, Android.Net.Uri uri)
        {
            return (await api.SendFile (client, uri)).JavaCast<Statuses> ();
        }
        public static async Task<Statuses> SendFileAsync (this IChannel api, GoogleApiClient client, Android.Net.Uri uri, long startOffset, long length)
        {
            return (await api.SendFile (client, uri, startOffset, length)).JavaCast<Statuses> ();
        }
        public static async Task<Statuses> AddListenerAsync (this IChannelApi api, GoogleApiClient client, IChannelApiChannelListener listener)
        {
            return (await api.AddListener (client, listener)).JavaCast<Statuses> ();
        }
        public static async Task<IChannelApiOpenChannelResult> OpenChannelAsync (this IChannelApi api, GoogleApiClient client, string nodeId, string path)
        {
            return (await api.OpenChannel (client, nodeId, path)).JavaCast<IChannelApiOpenChannelResult> ();
        }
        public static async Task<Statuses> RemoveListenerAsync (this IChannelApi api, GoogleApiClient client, IChannelApiChannelListener listener)
        {
            return (await api.RemoveListener (client, listener)).JavaCast<Statuses> ();
        }
    }

    public static partial class IDataApiExtensions
    {
        public static async Task<Statuses> AddListenerAsync (this IDataApi api, GoogleApiClient client, IDataApiDataListener listener)
        {
            return (await api.AddListener (client, listener)).JavaCast<Statuses> ();
        }
        public static async Task<IDataApiDeleteDataItemsResult> DeleteDataItemsAsync (this IDataApi api, GoogleApiClient client, Android.Net.Uri uri)
        {
            return (await api.DeleteDataItems (client, uri)).JavaCast<IDataApiDeleteDataItemsResult> ();
        }
        public static async Task<IDataApiDeleteDataItemsResult> DeleteDataItemsAsync (this IDataApi api, GoogleApiClient client, Android.Net.Uri uri, int filterType)
        {
            return (await api.DeleteDataItems (client, uri, filterType)).JavaCast<IDataApiDeleteDataItemsResult> ();
        }
        public static async Task<IDataApiDataItemResult> GetDataItemAsync (this IDataApi api, GoogleApiClient client, Android.Net.Uri uri)
        {
            return (await api.GetDataItem (client, uri)).JavaCast<IDataApiDataItemResult> ();
        }
        public static async Task<DataItemBuffer> GetDataItemsAsync (this IDataApi api, GoogleApiClient client)
        {
            return (await api.GetDataItems (client)).JavaCast<DataItemBuffer> ();
        }
        public static async Task<DataItemBuffer> GetDataItemsAsync (this IDataApi api, GoogleApiClient client, Android.Net.Uri uri)
        {
            return (await api.GetDataItems (client, uri)).JavaCast<DataItemBuffer> ();
        }
        public static async Task<DataItemBuffer> GetDataItemsAsync (this IDataApi api, GoogleApiClient client, Android.Net.Uri uri, int filterType)
        {
            return (await api.GetDataItems (client, uri, filterType)).JavaCast<DataItemBuffer> ();
        }
        public static async Task<IDataApiGetFdForAssetResult> GetFdForAssetAsync (this IDataApi api, GoogleApiClient client, Asset asset)
        {
            return (await api.GetFdForAsset (client, asset)).JavaCast<IDataApiGetFdForAssetResult> ();
        }
        public static async Task<IDataApiGetFdForAssetResult> GetFdForAssetAsync (this IDataApi api, GoogleApiClient client, IDataItemAsset asset)
        {
            return (await api.GetFdForAsset (client, asset)).JavaCast<IDataApiGetFdForAssetResult> ();
        }
        public static async Task<IDataApiDataItemResult> PutDataItemAsync (this IDataApi api, GoogleApiClient client, PutDataRequest request)
        {
            return (await api.PutDataItem (client, request)).JavaCast<IDataApiDataItemResult> ();
        }
        public static async Task<Statuses> RemoveListenerAsync (this IDataApi api, GoogleApiClient client, IDataApiDataListener listener)
        {
            return (await api.RemoveListener (client, listener)).JavaCast<Statuses> ();
        }
    }

    public static partial class IMessageApiExtensions
    {
        public static async Task<Statuses> AddListenerAsync (this IMessageApi api, GoogleApiClient client, IMessageApiMessageListener listener)
        {
            return (await api.AddListener (client, listener)).JavaCast<Statuses> ();
        }
        public static async Task<Statuses> RemoveListenerAsync (this IMessageApi api, GoogleApiClient client, IMessageApiMessageListener listener)
        {
            return (await api.RemoveListener (client, listener)).JavaCast<Statuses> ();
        }
        public static async Task<IMessageApiSendMessageResult> SendMessageAsync (this IMessageApi api, GoogleApiClient client, string nodeId, string action, Byte[] data)
        {
            return (await api.SendMessage (client, nodeId, action, data)).JavaCast<IMessageApiSendMessageResult> ();
        }
    }

    public static partial class INodeApiExtensions
    {
        public static async Task<INodeApiGetConnectedNodesResult> GetConnectedNodesAsync (this INodeApi api, GoogleApiClient client)
        {
            return (await api.GetConnectedNodes (client)).JavaCast<INodeApiGetConnectedNodesResult> ();
        }
        public static async Task<INodeApiGetLocalNodeResult> GetLocalNodeAsync (this INodeApi api, GoogleApiClient client)
        {
            return (await api.GetLocalNode (client)).JavaCast<INodeApiGetLocalNodeResult> ();
        }
    }
}


