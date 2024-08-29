using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Media3.ExoPlayer.SmoothStreaming;

// Metadata.xml XPath class reference: path="/api/package[@name='androidx.media3.exoplayer.smoothstreaming']/class[@name='SsMediaSource']"
// [global::Android.Runtime.Register ("androidx/media3/exoplayer/smoothstreaming/SsMediaSource", DoNotGenerateAcw=true)]
public sealed partial class SsMediaSource //: global::AndroidX.Media3.ExoPlayer.Source.BaseMediaSource, global::AndroidX.Media3.ExoPlayer.Upstream.Loader.ICallback 
{
    // Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer.smoothstreaming']/class[@name='SsMediaSource']/method[@name='canUpdateMediaItem' and count(parameter)=1 and parameter[1][@type='androidx.media3.common.MediaItem']]"
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


    // Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer.smoothstreaming']/class[@name='SsMediaSource']/method[@name='updateMediaItem' and count(parameter)=1 and parameter[1][@type='androidx.media3.common.MediaItem']]"
    [Register ("updateMediaItem", "(Landroidx/media3/common/MediaItem;)V", "")]
    public /*virtual*/ unsafe void UpdateMediaItem (global::AndroidX.Media3.Common.MediaItem? mediaItem)
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