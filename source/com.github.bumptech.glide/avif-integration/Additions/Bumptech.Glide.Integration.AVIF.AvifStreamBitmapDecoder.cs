#nullable restore
using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace Bumptech.Glide.Integration.AVIF 
{

	// Metadata.xml XPath class reference: path="/api/package[@name='com.bumptech.glide.integration.avif']/class[@name='AvifStreamBitmapDecoder']"
	// [global::Android.Runtime.Register ("com/bumptech/glide/integration/avif/AvifStreamBitmapDecoder", DoNotGenerateAcw=true)]
	public sealed partial class AvifStreamBitmapDecoder //: global::Java.Lang.Object, global::Bumptech.Glide.Load.IResourceDecoder 
    {

		// Metadata.xml XPath method reference: path="/api/package[@name='com.bumptech.glide.integration.avif']/class[@name='AvifStreamBitmapDecoder']/method[@name='decode' and count(parameter)=4 and parameter[1][@type='java.io.InputStream'] and parameter[2][@type='int'] and parameter[3][@type='int'] and parameter[4][@type='com.bumptech.glide.load.Options']]"
		[Register ("decode", "(Ljava/io/InputStream;IILcom/bumptech/glide/load/Options;)Lcom/bumptech/glide/load/engine/Resource;", "")]
		public unsafe global::Bumptech.Glide.Load.Engine.IResource? Decode (Java.Lang.Object? source, int width, int height, global::Bumptech.Glide.Load.Options? options)
		{
			const string __id = "decode.(Ljava/io/InputStream;IILcom/bumptech/glide/load/Options;)Lcom/bumptech/glide/load/engine/Resource;";
			IntPtr native_source = global::Android.Runtime.InputStreamAdapter.ToLocalJniHandle (source);
			try {
				JniArgumentValue* __args = stackalloc JniArgumentValue [4];
				__args [0] = new JniArgumentValue (native_source);
				__args [1] = new JniArgumentValue (width);
				__args [2] = new JniArgumentValue (height);
				__args [3] = new JniArgumentValue ((options == null) ? IntPtr.Zero : ((global::Java.Lang.Object) options).Handle);
				var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod (__id, this, __args);
				return global::Java.Lang.Object.GetObject<global::Bumptech.Glide.Load.Engine.IResource> (__rm.Handle, JniHandleOwnership.TransferLocalRef);
			} finally {
				JNIEnv.DeleteLocalRef (native_source);
				global::System.GC.KeepAlive (source);
				global::System.GC.KeepAlive (options);
			}
		}


    }
}