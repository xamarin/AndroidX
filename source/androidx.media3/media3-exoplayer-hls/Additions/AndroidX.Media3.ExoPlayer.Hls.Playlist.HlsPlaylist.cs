using System;
using System.Collections.Generic;
using Android.Runtime;
using AndroidX.Media3.Common;
using Java.Interop;

namespace AndroidX.Media3.ExoPlayer.Hls.Playlist; 

public partial class HlsPlaylist
{
	public abstract global::Java.Lang.Object? Copy (global::System.Collections.Generic.IList<global::AndroidX.Media3.Common.StreamKey>? p0);
}

internal partial class HlsPlaylistInvoker
{
	// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.exoplayer.hls.playlist']/class[@name='HlsPlaylist']/method[@name='copy' and count(parameter)=1 and parameter[1][@type='java.util.List&lt;androidx.media3.common.StreamKey&gt;']]"
	[Register ("copy", "(Ljava/util/List;)Ljava/lang/Object;", "GetCopy_Ljava_util_List_Handler")]
	public override unsafe global::Java.Lang.Object? Copy (global::System.Collections.Generic.IList<global::AndroidX.Media3.Common.StreamKey>? streamKeys)
	{
		const string __id = "copy.(Ljava/util/List;)Ljava/lang/Object;";
		IntPtr native_streamKeys = global::Android.Runtime.JavaList<global::AndroidX.Media3.Common.StreamKey>.ToLocalJniHandle (streamKeys);
		try {
			JniArgumentValue* __args = stackalloc JniArgumentValue [1];
			__args [0] = new JniArgumentValue (native_streamKeys);
			var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod (__id, this, __args);
			return global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (__rm.Handle, JniHandleOwnership.TransferLocalRef);
		} finally {
			JNIEnv.DeleteLocalRef (native_streamKeys);
			global::System.GC.KeepAlive (streamKeys);
		}
	}
}