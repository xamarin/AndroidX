using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Media3.ExoPlayer.Source;

public sealed partial class SilenceMediaSource
{
    // Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer.source']/class[@name='SilenceMediaSource']/method[@name='canUpdateMediaItem' and count(parameter)=1 and parameter[1][@type='androidx.media3.common.MediaItem']]"
    [Register ("canUpdateMediaItem", "(Landroidx/media3/common/MediaItem;)Z", "")]
    public /*virtual*/ unsafe bool CanUpdateMediaItem (global::AndroidX.Media3.Common.MediaItem? mediaItem)
    {
        const string __id = "canUpdateMediaItem.(Landroidx/media3/common/MediaItem;)Z";
        try {
            JniArgumentValue* __args = stackalloc JniArgumentValue [1];
            __args [0] = new JniArgumentValue ((mediaItem == null) ? IntPtr.Zero : ((global::Java.Lang.Object) mediaItem).Handle);
            var __rm = _members.InstanceMethods.InvokeAbstractBooleanMethod (__id, this, __args);
            return __rm;
        } finally {
            global::System.GC.KeepAlive (mediaItem);
        }
    }

    // Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer.source']/class[@name='SilenceMediaSource']/method[@name='updateMediaItem' and count(parameter)=1 and parameter[1][@type='androidx.media3.common.MediaItem']]"
    [Register ("updateMediaItem", "(Landroidx/media3/common/MediaItem;)V", "")]
    public /*override*/ unsafe void UpdateMediaItem (global::AndroidX.Media3.Common.MediaItem? mediaItem)
    {
        const string __id = "updateMediaItem.(Landroidx/media3/common/MediaItem;)V";
        try {
            JniArgumentValue* __args = stackalloc JniArgumentValue [1];
            __args [0] = new JniArgumentValue ((mediaItem == null) ? IntPtr.Zero : ((global::Java.Lang.Object) mediaItem).Handle);
            _members.InstanceMethods.InvokeAbstractVoidMethod (__id, this, __args);
        } finally {
            global::System.GC.KeepAlive (mediaItem);
        }
    }
}