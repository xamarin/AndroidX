using System;
using Java.Interop;
using System.Threading.Tasks;
using Android.Gms.Common.Apis;
using Android.Gms.Cast;

namespace Android.Gms.Cast.Framework
{
    public partial class CastSession
    {
        public async Task<Statuses> SendMessageAsync (string @namespace, string message)
        {
            return (await SendMessage (@namespace, message)).JavaCast<Statuses> ();
        }
    }
}

namespace Android.Gms.Cast.Framework.Media
{
    public partial class RemoteMediaClient
    {
        [Obsolete]
        public async Task<IMediaChannelResult> LoadAsync (MediaInfo mediaInfo)
        {
            return (await Load (mediaInfo)).JavaCast<IMediaChannelResult> ();
        }
        [Obsolete]
        public async Task<IMediaChannelResult> LoadAsync (MediaInfo mediaInfo, bool autoplay)
        {
            return (await Load (mediaInfo, autoplay)).JavaCast<IMediaChannelResult> ();
        }
        [Obsolete]
        public async Task<IMediaChannelResult> LoadAsync (MediaInfo mediaInfo, bool autoplay, long playPosition)
        {
            return (await Load (mediaInfo, autoplay, playPosition)).JavaCast<IMediaChannelResult> ();
        }
        [Obsolete]
        public async Task<IMediaChannelResult> LoadAsync (MediaInfo mediaInfo, bool autoplay, long playPosition, Org.Json.JSONObject customData)
        {
            return (await Load (mediaInfo, autoplay, playPosition, customData)).JavaCast<IMediaChannelResult> ();
        }
        [Obsolete]
        public async Task<IMediaChannelResult> LoadAsync (MediaInfo mediaInfo, bool autoplay, long playPosition, long [] activeTrackIds, Org.Json.JSONObject customData)
        {
            return (await Load (mediaInfo, autoplay, playPosition, activeTrackIds, customData)).JavaCast<IMediaChannelResult> ();
        }
        public async Task<IMediaChannelResult> LoadAsync (MediaInfo mediaInfo, MediaLoadOptions mediaLoadOptions)
        {
            return (await Load (mediaInfo, mediaLoadOptions)).JavaCast<IMediaChannelResult> ();
        }
        public async Task<IMediaChannelResult> PauseAsync ()
        {
            return (await Pause ()).JavaCast<IMediaChannelResult> ();
        }
        public async Task<IMediaChannelResult> PauseAsync (Org.Json.JSONObject customData)
        {
            return (await Pause (customData)).JavaCast<IMediaChannelResult> ();
        }
        public async Task<IMediaChannelResult> PlayAsync ()
        {
            return (await Play ()).JavaCast<IMediaChannelResult> ();
        }
        public async Task<IMediaChannelResult> PlayAsync (Org.Json.JSONObject customData)
        {
            return (await Play (customData)).JavaCast<IMediaChannelResult> ();
        }
        public async Task<IMediaChannelResult> QueueAppendItemAsync (MediaQueueItem item, Org.Json.JSONObject customData)
        {
            return (await QueueAppendItem (item, customData)).JavaCast<IMediaChannelResult> ();
        }
        public async Task<IMediaChannelResult> QueueInsertAndPlayItemAsync (MediaQueueItem item, int insertBeforeItemId, Org.Json.JSONObject customData)
        {
            return (await QueueInsertAndPlayItem (item, insertBeforeItemId, customData)).JavaCast<IMediaChannelResult> ();
        }
        public async Task<IMediaChannelResult> QueueInsertAndPlayItemAsync (MediaQueueItem item, int insertBeforeItemId, long playPosition, Org.Json.JSONObject customData)
        {
            return (await QueueInsertAndPlayItem (item, insertBeforeItemId, playPosition, customData)).JavaCast<IMediaChannelResult> ();
        }
        public async Task<IMediaChannelResult> QueueInsertItemsAsync (MediaQueueItem [] itemsToInsert, int insertBeforeItemId, Org.Json.JSONObject customData)
        {
            return (await QueueInsertItems (itemsToInsert, insertBeforeItemId, customData)).JavaCast<IMediaChannelResult> ();
        }
        public async Task<IMediaChannelResult> QueueJumpToItemAsync (int itemId, Org.Json.JSONObject customData)
        {
            return (await QueueJumpToItem (itemId, customData)).JavaCast<IMediaChannelResult> ();
        }
        public async Task<IMediaChannelResult> QueueJumpToItemAsync (int itemId, long playPosition, Org.Json.JSONObject customData)
        {
            return (await QueueJumpToItem (itemId, playPosition, customData)).JavaCast<IMediaChannelResult> ();
        }
        public async Task<IMediaChannelResult> QueueLoadAsync (MediaQueueItem [] items, int startIndex, int repeatMode, Org.Json.JSONObject customData)
        {
            return (await QueueLoad (items, startIndex, repeatMode, customData)).JavaCast<IMediaChannelResult> ();
        }
        public async Task<IMediaChannelResult> QueueLoadAsync (MediaQueueItem [] items, int startIndex, int repeatMode, long playPosition, Org.Json.JSONObject customData)
        {
            return (await QueueLoad (items, startIndex, repeatMode, playPosition, customData)).JavaCast<IMediaChannelResult> ();
        }
        public async Task<IMediaChannelResult> QueueMoveItemToNewIndexAsync (int itemId, int newIndex, Org.Json.JSONObject customData)
        {
            return (await QueueMoveItemToNewIndex (itemId, newIndex, customData)).JavaCast<IMediaChannelResult> ();
        }
        public async Task<IMediaChannelResult> QueueNextAsync (Org.Json.JSONObject customData)
        {
            return (await QueueNext (customData)).JavaCast<IMediaChannelResult> ();
        }
        public async Task<IMediaChannelResult> QueuePrevAsync (Org.Json.JSONObject customData)
        {
            return (await QueuePrev (customData)).JavaCast<IMediaChannelResult> ();
        }
        public async Task<IMediaChannelResult> QueueRemoveItemAsync (int itemId, Org.Json.JSONObject customData)
        {
            return (await QueueRemoveItem (itemId, customData)).JavaCast<IMediaChannelResult> ();
        }
        public async Task<IMediaChannelResult> QueueRemoveItemsAsync (int [] itemIdsToRemove, Org.Json.JSONObject customData)
        {
            return (await QueueRemoveItems (itemIdsToRemove, customData)).JavaCast<IMediaChannelResult> ();
        }
        public async Task<IMediaChannelResult> QueueReorderItemsAsync (int [] itemIdsToReorder, int insertBeforeItemId, Org.Json.JSONObject customData)
        {
            return (await QueueReorderItems (itemIdsToReorder, insertBeforeItemId, customData)).JavaCast<IMediaChannelResult> ();
        }
        public async Task<IMediaChannelResult> QueueSetRepeatModeAsync (int repeatMode, Org.Json.JSONObject customData)
        {
            return (await QueueSetRepeatMode (repeatMode, customData)).JavaCast<IMediaChannelResult> ();
        }
        public async Task<IMediaChannelResult> QueueUpdateItemsAsync (MediaQueueItem [] itemsToUpdate, Org.Json.JSONObject customData)
        {
            return (await QueueUpdateItems (itemsToUpdate, customData)).JavaCast<IMediaChannelResult> ();
        }
        public async Task<IMediaChannelResult> RequestStatusAsync ()
        {
            return (await RequestStatus ()).JavaCast<IMediaChannelResult> ();
        }
        public async Task<IMediaChannelResult> SeekAsync (long position)
        {
            return (await Seek (position)).JavaCast<IMediaChannelResult> ();
        }
        public async Task<IMediaChannelResult> SeekAsync (long position, int resumeState)
        {
            return (await Seek (position, resumeState)).JavaCast<IMediaChannelResult> ();
        }
        public async Task<IMediaChannelResult> SeekAsync (long position, int resumeState, Org.Json.JSONObject customData)
        {
            return (await Seek (position, resumeState, customData)).JavaCast<IMediaChannelResult> ();
        }
        public async Task<IMediaChannelResult> SetActiveMediaTracksAsync (long [] trackIds)
        {
            return (await SetActiveMediaTracks (trackIds)).JavaCast<IMediaChannelResult> ();
        }
        public async Task<IMediaChannelResult> SetStreamMuteAsync (bool muted)
        {
            return (await SetStreamMute (muted)).JavaCast<IMediaChannelResult> ();
        }
        public async Task<IMediaChannelResult> SetStreamMuteAsync (bool muted, Org.Json.JSONObject customData)
        {
            return (await SetStreamMute (muted, customData)).JavaCast<IMediaChannelResult> ();
        }
        public async Task<IMediaChannelResult> SetStreamVolumeAsync (double volume)
        {
            return (await SetStreamVolume (volume)).JavaCast<IMediaChannelResult> ();
        }
        public async Task<IMediaChannelResult> SetStreamVolumeAsync (double volume, Org.Json.JSONObject customData)
        {
            return (await SetStreamVolume (volume, customData)).JavaCast<IMediaChannelResult> ();
        }
        public async Task<IMediaChannelResult> SetTextTrackStyleAsync (TextTrackStyle trackStyle)
        {
            return (await SetTextTrackStyle (trackStyle)).JavaCast<IMediaChannelResult> ();
        }
        public async Task<IMediaChannelResult> StopAsync ()
        {
            return (await Stop ()).JavaCast<IMediaChannelResult> ();
        }
        public async Task<IMediaChannelResult> StopAsync (Org.Json.JSONObject customData)
        {
            return (await Stop (customData)).JavaCast<IMediaChannelResult> ();
        }

        public async Task<IMediaChannelResult> SetPlaybackRateAsync (double rate)
        {
            return (await SetPlaybackRate (rate)).JavaCast<IMediaChannelResult> ();
        }
    }
}

