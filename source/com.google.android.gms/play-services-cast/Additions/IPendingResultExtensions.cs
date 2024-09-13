using System;
using System.Threading.Tasks;
using Android.Gms.Common.Apis;
using Android.Runtime;

namespace Android.Gms.Cast 
{
    public static partial class CastClassICastApiExtensions 
    {
        public static async Task<CastClass.IApplicationConnectionResult> JoinApplicationAsync (this CastClass.ICastApi api, GoogleApiClient client) 
        {
            return (await api.JoinApplication (client)).JavaCast<CastClass.IApplicationConnectionResult> ();
        }
        public static async Task<CastClass.IApplicationConnectionResult> JoinApplicationAsync (this CastClass.ICastApi api, GoogleApiClient client, string applicationId) 
        {
            return (await api.JoinApplication (client, applicationId)).JavaCast<CastClass.IApplicationConnectionResult> ();
        }
        public static async Task<CastClass.IApplicationConnectionResult> JoinApplicationAsync (this CastClass.ICastApi api, GoogleApiClient client, string applicationId, string sessionId) 
        {
            return (await api.JoinApplication (client, applicationId, sessionId)).JavaCast<CastClass.IApplicationConnectionResult> ();
        }
        public static async Task<CastClass.IApplicationConnectionResult> LaunchApplicationAsync (this CastClass.ICastApi api, GoogleApiClient client, string applicationId) 
        {
            return (await api.LaunchApplication (client, applicationId)).JavaCast<CastClass.IApplicationConnectionResult> ();
        }
        public static async Task<CastClass.IApplicationConnectionResult> LaunchApplicationAsync (this CastClass.ICastApi api, GoogleApiClient client, string applicationId, LaunchOptions options) 
        {
            return (await api.LaunchApplication (client, applicationId, options)).JavaCast<CastClass.IApplicationConnectionResult> ();
        }
        [Obsolete ("Use the override specifying LaunchOptions instead")]
        public static async Task<CastClass.IApplicationConnectionResult> LaunchApplicationAsync (this CastClass.ICastApi api, GoogleApiClient client, string applicationId, bool relaunchIfRunning) 
        {
            return (await api.LaunchApplication (client, applicationId, relaunchIfRunning)).JavaCast<CastClass.IApplicationConnectionResult> ();
        }
        public static async Task<Statuses> LeaveApplicationAsync (this CastClass.ICastApi api, GoogleApiClient client)
        {
            return (await api.LeaveApplication (client)).JavaCast<Statuses> ();
        }
        public static async Task<Statuses> SendMessageAsync (this CastClass.ICastApi api, GoogleApiClient client, string @namespace, string message)
        {
            return (await api.SendMessage (client, @namespace, message)).JavaCast<Statuses> ();
        }
        public static async Task<Statuses> StopApplicationAsync (this CastClass.ICastApi api, GoogleApiClient client) 
        {
            return (await api.StopApplication (client)).JavaCast<Statuses> ();
        }
        public static async Task<Statuses> StopApplicationAsync (this CastClass.ICastApi api, GoogleApiClient client, string sessionId) 
        {
            return (await api.StopApplication (client, sessionId)).JavaCast<Statuses> ();
        }
    }
}

namespace Android.Gms.Cast 
{
    public static partial class ICastRemoteDisplayApiExtensions
    {
        public static async Task<CastRemoteDisplay.ICastRemoteDisplaySessionResult> StartRemoteDisplayAsync (this ICastRemoteDisplayApi api, GoogleApiClient apiClient, string appId)
        {
            return (await api.StartRemoteDisplay (apiClient, appId)).JavaCast<CastRemoteDisplay.ICastRemoteDisplaySessionResult> ();
        }
        public static async Task<CastRemoteDisplay.ICastRemoteDisplaySessionResult> StopRemoteDisplayAsync (this ICastRemoteDisplayApi api, GoogleApiClient apiClient)
        {
            return (await api.StopRemoteDisplay (apiClient)).JavaCast<CastRemoteDisplay.ICastRemoteDisplaySessionResult> ();
        }
    }
}

namespace Android.Gms.Cast 
{
    public partial class RemoteMediaPlayer 
    {
        public async Task<RemoteMediaPlayer.IMediaChannelResult> LoadAsync (GoogleApiClient apiClient, MediaInfo mediaInfo)
        {
            return (await Load (apiClient, mediaInfo)).JavaCast<RemoteMediaPlayer.IMediaChannelResult> ();
        }
        public async Task<RemoteMediaPlayer.IMediaChannelResult> LoadAsync (GoogleApiClient apiClient, MediaInfo mediaInfo, bool autoplay) 
        {
            return (await Load (apiClient, mediaInfo, autoplay)).JavaCast<RemoteMediaPlayer.IMediaChannelResult> ();
        }
        public async Task<RemoteMediaPlayer.IMediaChannelResult> LoadAsync (GoogleApiClient apiClient, MediaInfo mediaInfo, bool autoplay, long playPosition) 
        {
            return (await Load (apiClient, mediaInfo, autoplay, playPosition)).JavaCast<RemoteMediaPlayer.IMediaChannelResult> ();
        }
        public async Task<RemoteMediaPlayer.IMediaChannelResult> LoadAsync (GoogleApiClient apiClient, Android.Gms.Cast.MediaInfo mediaInfo, bool autoplay, long playPosition, Org.Json.JSONObject customData) {
            return (await Load (apiClient, mediaInfo, autoplay, playPosition, customData)).JavaCast<RemoteMediaPlayer.IMediaChannelResult> ();
        }
        public async Task<RemoteMediaPlayer.IMediaChannelResult> LoadAsync (GoogleApiClient apiClient, Android.Gms.Cast.MediaInfo mediaInfo, bool autoplay, long playPosition, long[] activeTrackIds, Org.Json.JSONObject customData) {
            return (await Load (apiClient, mediaInfo, autoplay, playPosition, activeTrackIds, customData)).JavaCast<RemoteMediaPlayer.IMediaChannelResult> ();
        }
        public async Task<RemoteMediaPlayer.IMediaChannelResult> PauseAsync (GoogleApiClient apiClient) {
            return (await Pause (apiClient)).JavaCast<RemoteMediaPlayer.IMediaChannelResult> ();
        }
        public async Task<RemoteMediaPlayer.IMediaChannelResult> PauseAsync (GoogleApiClient apiClient, Org.Json.JSONObject customData) {
            return (await Pause (apiClient, customData)).JavaCast<RemoteMediaPlayer.IMediaChannelResult> ();
        }
        public async Task<RemoteMediaPlayer.IMediaChannelResult> PlayAsync (GoogleApiClient apiClient) {
            return (await Play (apiClient)).JavaCast<RemoteMediaPlayer.IMediaChannelResult> ();
        }
        public async Task<RemoteMediaPlayer.IMediaChannelResult> PlayAsync (GoogleApiClient apiClient, Org.Json.JSONObject customData) {
            return (await Play (apiClient, customData)).JavaCast<RemoteMediaPlayer.IMediaChannelResult> ();
        }
        public async Task<RemoteMediaPlayer.IMediaChannelResult> QueueAppendItemAsync (GoogleApiClient apiClient, Android.Gms.Cast.MediaQueueItem item, Org.Json.JSONObject customData) {
            return (await QueueAppendItem (apiClient, item, customData)).JavaCast<RemoteMediaPlayer.IMediaChannelResult> ();
        }
        public async Task<RemoteMediaPlayer.IMediaChannelResult> QueueInsertAndPlayItemAsync (GoogleApiClient apiClient, Android.Gms.Cast.MediaQueueItem item, int insertBeforeItemId, long playPosition, Org.Json.JSONObject customData)
        {
            return (await QueueInsertAndPlayItem (apiClient, item, insertBeforeItemId, playPosition, customData)).JavaCast<RemoteMediaPlayer.IMediaChannelResult> ();
        }
        public async Task<RemoteMediaPlayer.IMediaChannelResult> QueueInsertAndPlayItemAsync (GoogleApiClient apiClient, Android.Gms.Cast.MediaQueueItem item, int insertBeforeItemId, Org.Json.JSONObject customData)
        {
            return (await QueueInsertAndPlayItem (apiClient, item, insertBeforeItemId, customData)).JavaCast<RemoteMediaPlayer.IMediaChannelResult> ();
        }
        public async Task<RemoteMediaPlayer.IMediaChannelResult> QueueInsertItemsAsync (GoogleApiClient apiClient, Android.Gms.Cast.MediaQueueItem[] itemsToInsert, int insertBeforeItemId, Org.Json.JSONObject customData) {
            return (await QueueInsertItems (apiClient, itemsToInsert, insertBeforeItemId, customData)).JavaCast<RemoteMediaPlayer.IMediaChannelResult> ();
        }
        public async Task<RemoteMediaPlayer.IMediaChannelResult> QueueJumpToItemAsync (GoogleApiClient apiClient, int itemId, long playPosition, Org.Json.JSONObject customData)
        {
            return (await QueueJumpToItem (apiClient, itemId, playPosition, customData)).JavaCast<RemoteMediaPlayer.IMediaChannelResult> ();
        }
        public async Task<RemoteMediaPlayer.IMediaChannelResult> QueueJumpToItemAsync (GoogleApiClient apiClient, int itemId, Org.Json.JSONObject customData) {
            return (await QueueJumpToItem (apiClient, itemId, customData)).JavaCast<RemoteMediaPlayer.IMediaChannelResult> ();
        }
        public async Task<RemoteMediaPlayer.IMediaChannelResult> QueueLoadAsync (GoogleApiClient apiClient, Android.Gms.Cast.MediaQueueItem[] items, int startIndex, int repeatMode, long playPosition, Org.Json.JSONObject customData)
        {
            return (await QueueLoad (apiClient, items, startIndex, repeatMode, playPosition, customData)).JavaCast<RemoteMediaPlayer.IMediaChannelResult> ();
        }
        public async Task<RemoteMediaPlayer.IMediaChannelResult> QueueLoadAsync (GoogleApiClient apiClient, Android.Gms.Cast.MediaQueueItem[] items, int startIndex, int repeatMode, Org.Json.JSONObject customData) {
            return (await QueueLoad (apiClient, items, startIndex, repeatMode, customData)).JavaCast<RemoteMediaPlayer.IMediaChannelResult> ();
        }
        public async Task<RemoteMediaPlayer.IMediaChannelResult> QueueMoveItemToNewIndexAsync (GoogleApiClient apiClient, int itemId, int newIndex, Org.Json.JSONObject customData) {
            return (await QueueMoveItemToNewIndex (apiClient, itemId, newIndex, customData)).JavaCast<RemoteMediaPlayer.IMediaChannelResult> ();
        }
        public async Task<RemoteMediaPlayer.IMediaChannelResult> QueueNextAsync (GoogleApiClient apiClient, Org.Json.JSONObject customData) {
            return (await QueueNext (apiClient, customData)).JavaCast<RemoteMediaPlayer.IMediaChannelResult> ();
        }
        public async Task<RemoteMediaPlayer.IMediaChannelResult> QueuePrevAsync (GoogleApiClient apiClient, Org.Json.JSONObject customData) {
            return (await QueuePrev (apiClient, customData)).JavaCast<RemoteMediaPlayer.IMediaChannelResult> ();
        }
        public async Task<RemoteMediaPlayer.IMediaChannelResult> QueueRemoveItemAsync (GoogleApiClient apiClient, int itemId, Org.Json.JSONObject customData) {
            return (await QueueRemoveItem (apiClient, itemId, customData)).JavaCast<RemoteMediaPlayer.IMediaChannelResult> ();
        }
        public async Task<RemoteMediaPlayer.IMediaChannelResult> QueueRemoveItemsAsync (GoogleApiClient apiClient, int[] itemIdsToRemove, Org.Json.JSONObject customData) {
            return (await QueueRemoveItems (apiClient, itemIdsToRemove, customData)).JavaCast<RemoteMediaPlayer.IMediaChannelResult> ();
        }
        public async Task<RemoteMediaPlayer.IMediaChannelResult> QueueReorderItemsAsync (GoogleApiClient apiClient, int[] itemIdsToReorder, int insertBeforeItemId, Org.Json.JSONObject customData) {
            return (await QueueReorderItems (apiClient, itemIdsToReorder, insertBeforeItemId, customData)).JavaCast<RemoteMediaPlayer.IMediaChannelResult> ();
        }
        public async Task<RemoteMediaPlayer.IMediaChannelResult> QueueSetRepeatModeAsync (GoogleApiClient apiClient, int repeatMode, Org.Json.JSONObject customData) {
            return (await QueueSetRepeatMode (apiClient, repeatMode, customData)).JavaCast<RemoteMediaPlayer.IMediaChannelResult> ();
        }
        public async Task<RemoteMediaPlayer.IMediaChannelResult> QueueUpdateItemsAsync (GoogleApiClient apiClient, Android.Gms.Cast.MediaQueueItem[] itemsToUpdate, Org.Json.JSONObject customData) {
            return (await QueueUpdateItems (apiClient, itemsToUpdate, customData)).JavaCast<RemoteMediaPlayer.IMediaChannelResult> ();
        }
        public async Task<RemoteMediaPlayer.IMediaChannelResult> RequestStatusAsync (GoogleApiClient apiClient) {
            return (await RequestStatus (apiClient)).JavaCast<RemoteMediaPlayer.IMediaChannelResult> ();
        }
        public async Task<RemoteMediaPlayer.IMediaChannelResult> SeekAsync (GoogleApiClient apiClient, long position) {
            return (await Seek (apiClient, position)).JavaCast<RemoteMediaPlayer.IMediaChannelResult> ();
        }
        public async Task<RemoteMediaPlayer.IMediaChannelResult> SeekAsync (GoogleApiClient apiClient, long position, int resumeState) {
            return (await Seek (apiClient, position, resumeState)).JavaCast<RemoteMediaPlayer.IMediaChannelResult> ();
        }
        public async Task<RemoteMediaPlayer.IMediaChannelResult> SeekAsync (GoogleApiClient apiClient, long position, int resumeState, Org.Json.JSONObject customData) {
            return (await Seek (apiClient, position, resumeState, customData)).JavaCast<RemoteMediaPlayer.IMediaChannelResult> ();
        }
        public async Task<RemoteMediaPlayer.IMediaChannelResult> SetActiveMediaTracksAsync (GoogleApiClient apiClient, long[] trackIds) {
            return (await SetActiveMediaTracks (apiClient, trackIds)).JavaCast<RemoteMediaPlayer.IMediaChannelResult> ();
        }
        public async Task<RemoteMediaPlayer.IMediaChannelResult> SetStreamMuteAsync (GoogleApiClient apiClient, bool muteState) {
            return (await SetStreamMute (apiClient, muteState)).JavaCast<RemoteMediaPlayer.IMediaChannelResult> ();
        }
        public async Task<RemoteMediaPlayer.IMediaChannelResult> SetStreamMuteAsync (GoogleApiClient apiClient, bool muteState, Org.Json.JSONObject customData) {
            return (await SetStreamMute (apiClient, muteState, customData)).JavaCast<RemoteMediaPlayer.IMediaChannelResult> ();
        }
        public async Task<RemoteMediaPlayer.IMediaChannelResult> SetStreamVolumeAsync (GoogleApiClient apiClient, Double volume) {
            return (await SetStreamVolume (apiClient, volume)).JavaCast<RemoteMediaPlayer.IMediaChannelResult> ();
        }
        public async Task<RemoteMediaPlayer.IMediaChannelResult> SetStreamVolumeAsync (GoogleApiClient apiClient, Double volume, Org.Json.JSONObject customData) {
            return (await SetStreamVolume (apiClient, volume, customData)).JavaCast<RemoteMediaPlayer.IMediaChannelResult> ();
        }
        public async Task<RemoteMediaPlayer.IMediaChannelResult> SetTextTrackStyleAsync (GoogleApiClient apiClient, Android.Gms.Cast.TextTrackStyle trackStyle) {
            return (await SetTextTrackStyle (apiClient, trackStyle)).JavaCast<RemoteMediaPlayer.IMediaChannelResult> ();
        }
        public async Task<RemoteMediaPlayer.IMediaChannelResult> StopAsync (GoogleApiClient apiClient) {
            return (await Stop (apiClient)).JavaCast<RemoteMediaPlayer.IMediaChannelResult> ();
        }
        public async Task<RemoteMediaPlayer.IMediaChannelResult> StopAsync (GoogleApiClient apiClient, Org.Json.JSONObject customData) {
            return (await Stop (apiClient, customData)).JavaCast<RemoteMediaPlayer.IMediaChannelResult> ();
        }
    }
}

namespace Android.Gms.Cast.Games 
{
}
