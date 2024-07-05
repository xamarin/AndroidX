using Android.Runtime;
using Java.Interop;
using Java.Lang;
using System;

namespace AndroidX.Health.Connect.Client.Contracts
{
    public sealed partial class HealthPermissionsRequestContract
    {
        [Register("createIntent", "(Landroid/content/Context;Ljava/util/Set;)Landroid/content/Intent;", "")]
        public override unsafe global::Android.Content.Intent CreateIntent(global::Android.Content.Context context, global::Java.Lang.Object? input)
        {
            const string __id = "createIntent.(Landroid/content/Context;Ljava/util/Set;)Landroid/content/Intent;";

            IntPtr native_input = global::Android.Runtime.JavaSet<string>.ToLocalJniHandle(input as global::Android.Runtime.JavaSet<string>);
            try
            {
                JniArgumentValue* __args = stackalloc JniArgumentValue[2];
                __args[0] = new JniArgumentValue((context == null) ? IntPtr.Zero : ((global::Java.Lang.Object)context).Handle);
                __args[1] = new JniArgumentValue(native_input);
                var __rm = _members.InstanceMethods.InvokeAbstractObjectMethod(__id, this, __args);
                return global::Java.Lang.Object.GetObject<global::Android.Content.Intent>(__rm.Handle, JniHandleOwnership.TransferLocalRef)!;
            }
            finally
            {
                JNIEnv.DeleteLocalRef(native_input);
                global::System.GC.KeepAlive(context);
                global::System.GC.KeepAlive(input);
            }
        }

    }
}