using System;
using Android.Views;
using Android.Widget;
using Android.Graphics;


namespace Xamarin.Grpc.Core.InProcess 
{
	public sealed partial class InProcessChannelBuilder 
    {
		// public override unsafe global::Java.Lang.Object Intercept (params global::Xamarin.Grpc.IClientInterceptor[] p0)
		// {
		// 	const string __id = "intercept.([Lio/grpc/ClientInterceptor;)Lio/grpc/inprocess/InProcessChannelBuilder;";
		// 	IntPtr native_p0 = JNIEnv.NewArray (p0);
		// 	try {
		// 		JniArgumentValue* __args = stackalloc JniArgumentValue [1];
		// 		__args [0] = new JniArgumentValue (native_p0);
		// 		var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod (__id, this, __args);
		// 		return (global::Java.Lang.Object) global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (__rm.Handle, JniHandleOwnership.TransferLocalRef);
		// 	} finally {
		// 		if (p0 != null) {
		// 			JNIEnv.CopyArray (native_p0, p0);
		// 			JNIEnv.DeleteLocalRef (native_p0);
		// 		}
		// 		global::System.GC.KeepAlive (p0);
		// 	}
		// }
        
    }
}