using System;
using Android.Runtime;
using Android.Gms.Extensions;

namespace Firebase.Storage
{
    public partial class FileDownloadTask
    {
        static IntPtr id_getResult;
        protected override unsafe global::Java.Lang.Object RawResult {
            [Register ("getResult", "()Ljava/lang/Object;", "GetGetRawResultHandler")]
            get {
                if (id_getResult == IntPtr.Zero)
                    id_getResult = JNIEnv.GetMethodID (class_ref, "getResult", "()Ljava/lang/Object;");
                try {
                    return global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (JNIEnv.CallObjectMethod  (Handle, id_getResult), JniHandleOwnership.TransferLocalRef);
                } finally {
                }
            }
        }
    }

    public partial class StreamDownloadTask
    {
        static IntPtr id_getResult;
        protected override unsafe global::Java.Lang.Object RawResult {
            [Register ("getResult", "()Ljava/lang/Object;", "GetGetRawResultHandler")]
            get {
                if (id_getResult == IntPtr.Zero)
                    id_getResult = JNIEnv.GetMethodID (class_ref, "getResult", "()Ljava/lang/Object;");
                try {
                    return global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (JNIEnv.CallObjectMethod  (Handle, id_getResult), JniHandleOwnership.TransferLocalRef);
                } finally {
                }
            }
        }
    }

    public partial class UploadTask
    {
        static IntPtr id_getResult;
        protected override unsafe global::Java.Lang.Object RawResult {
            [Register ("getResult", "()Ljava/lang/Object;", "GetGetRawResultHandler")]
            get {
                if (id_getResult == IntPtr.Zero)
                    id_getResult = JNIEnv.GetMethodID (class_ref, "getResult", "()Ljava/lang/Object;");
                try {
                    return global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (JNIEnv.CallObjectMethod  (Handle, id_getResult), JniHandleOwnership.TransferLocalRef);
                } finally {
                }
            }
        }
    }

    public partial class StorageReference
    {
        public System.Threading.Tasks.Task DeleteAsync ()
        {
            return Delete ().AsAsync ();
        }

        // public System.Threading.Tasks.Task<byte []> GetBytesAsync (long l)
        // {
        //     return GetBytes (l).AsAsync<byte []> ();
        // }

         public System.Threading.Tasks.Task<Android.Net.Uri> GetDownloadUrlAsync ()
         {
             return GetDownloadUrl ().AsAsync<Android.Net.Uri> ();
         }
    }

    public partial class StorageException
    {
        static Delegate cb_getMessage;
#pragma warning disable 0169
        static Delegate GetGetMessageHandler ()
        {
            if (cb_getMessage == null)
                cb_getMessage = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>) n_GetMessage);
            return cb_getMessage;
        }

        static IntPtr n_GetMessage (IntPtr jnienv, IntPtr native__this)
        {
            global::Firebase.Storage.StorageException __this = global::Java.Lang.Object.GetObject<global::Firebase.Storage.StorageException> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            return JNIEnv.NewString (__this.Message);
        }
#pragma warning restore 0169

        static IntPtr id_getMessage;
        public override unsafe string Message {
            // Metadata.xml XPath method reference: path="/api/package[@name='com.google.firebase.storage']/class[@name='StorageException']/method[@name='getMessage' and count(parameter)=0]"
            [Register ("getMessage", "()Ljava/lang/String;", "GetGetMessageHandler")]
            get {
                if (id_getMessage == IntPtr.Zero)
                    id_getMessage = JNIEnv.GetMethodID (class_ref, "getMessage", "()Ljava/lang/String;");
                try {

                    if (GetType () == ThresholdType)
                        return JNIEnv.GetString (JNIEnv.CallObjectMethod (((global::Java.Lang.Throwable) this).Handle, id_getMessage), JniHandleOwnership.TransferLocalRef);
                    else
                        return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Throwable) this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getMessage", "()Ljava/lang/String;")), JniHandleOwnership.TransferLocalRef);
                } finally {
                }
            }
        }
    }
}

