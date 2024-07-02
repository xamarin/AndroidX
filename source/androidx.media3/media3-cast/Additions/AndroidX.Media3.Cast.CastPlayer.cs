#nullable restore
using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Media3.Cast 
{

	// Metadata.xml XPath class reference: path="/api/package[@name='androidx.media3.cast']/class[@name='CastPlayer']"
	// [global::Android.Runtime.Register ("androidx/media3/cast/CastPlayer", DoNotGenerateAcw=true)]
	public sealed partial class CastPlayer // : global::AndroidX.Media3.Common.BasePlayer 
    {

        // Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.cast']/class[@name='CastPlayer']/method[@name='addMediaItems' and count(parameter)=2 and parameter[1][@type='int'] and parameter[2][@type='java.util.List&lt;androidx.media3.common.MediaItem&gt;']]"
        [Register ("addMediaItems", "(ILjava/util/List;)V", "")]
        public 
            override
            unsafe void AddMediaItems (int index, global::System.Collections.Generic.IList<global::AndroidX.Media3.Common.MediaItem>? mediaItems)
        {
            const string __id = "addMediaItems.(ILjava/util/List;)V";
            IntPtr native_mediaItems = global::Android.Runtime.JavaList<global::AndroidX.Media3.Common.MediaItem>.ToLocalJniHandle (mediaItems);
            try {
                JniArgumentValue* __args = stackalloc JniArgumentValue [2];
                __args [0] = new JniArgumentValue (index);
                __args [1] = new JniArgumentValue (native_mediaItems);
                _members.InstanceMethods.InvokeAbstractVoidMethod (__id, this, __args);
            } finally {
                JNIEnv.DeleteLocalRef (native_mediaItems);
                global::System.GC.KeepAlive (mediaItems);
            }
        }

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.cast']/class[@name='CastPlayer']/method[@name='setMediaItems' and count(parameter)=2 and parameter[1][@type='java.util.List&lt;androidx.media3.common.MediaItem&gt;'] and parameter[2][@type='boolean']]"
		[Register ("setMediaItems", "(Ljava/util/List;Z)V", "")]
		public 
            override
            unsafe void SetMediaItems (global::System.Collections.Generic.IList<global::AndroidX.Media3.Common.MediaItem>? mediaItems, bool resetPosition)
		{
			const string __id = "setMediaItems.(Ljava/util/List;Z)V";
			IntPtr native_mediaItems = global::Android.Runtime.JavaList<global::AndroidX.Media3.Common.MediaItem>.ToLocalJniHandle (mediaItems);
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [2];
				__args [0] = new JniArgumentValue (native_mediaItems);
				__args [1] = new JniArgumentValue (resetPosition);
				_members.InstanceMethods.InvokeAbstractVoidMethod (__id, this, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_mediaItems);
				global::System.GC.KeepAlive (mediaItems);
			}
		}

		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.media3.cast']/class[@name='CastPlayer']/method[@name='setMediaItems' and count(parameter)=3 and parameter[1][@type='java.util.List&lt;androidx.media3.common.MediaItem&gt;'] and parameter[2][@type='int'] and parameter[3][@type='long']]"
		[Register ("setMediaItems", "(Ljava/util/List;IJ)V", "")]
		public 
            override
            unsafe void SetMediaItems (global::System.Collections.Generic.IList<global::AndroidX.Media3.Common.MediaItem>? mediaItems, int startIndex, long startPositionMs)
		{
			const string __id = "setMediaItems.(Ljava/util/List;IJ)V";
			IntPtr native_mediaItems = global::Android.Runtime.JavaList<global::AndroidX.Media3.Common.MediaItem>.ToLocalJniHandle (mediaItems);
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [3];
				__args [0] = new JniArgumentValue (native_mediaItems);
				__args [1] = new JniArgumentValue (startIndex);
				__args [2] = new JniArgumentValue (startPositionMs);
				_members.InstanceMethods.InvokeAbstractVoidMethod (__id, this, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_mediaItems);
				global::System.GC.KeepAlive (mediaItems);
			}
		}


    }
}