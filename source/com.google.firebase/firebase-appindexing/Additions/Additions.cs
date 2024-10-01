using System;
using Java.Interop;
using Android.Runtime;

namespace Android.Gms.AppIndexing
{
    public partial class AppIndex
    {
        [Obsolete ("Use APP_INDEX_API instead")]
        public static Android.Gms.Common.Apis.Api AppIndexApiField {
            get { return AppIndex.APP_INDEX_API; }
        }

        [Obsolete ("Use API instead")]
        public static Android.Gms.Common.Apis.Api Api {
            get { return AppIndex.API; }
        }
    }
}

// needed in 16.9, but not in 16.10
namespace Firebase.AppIndexing
{
    public partial interface IIndexable : IJavaObject, IDisposable
    {
    }

    /*
    //[Register("com/google/firebase/appindexing/Indexable", DoNotGenerateAcw = true)]
    internal partial class IIndexableInvoker : Java.Lang.Object, IIndexable, IJavaObject, IDisposable
    {
        //
        // Static Fields
        //
        private static IntPtr java_class_ref = JNIEnv.FindClass("com/google/firebase/appindexing/Indexable");
 
        private IntPtr class_ref;
 
 
        //
        // Properties
        //
        protected override IntPtr ThresholdClass
        {
            get
            {
                return this.class_ref;
            }
        }
 
        protected override Type ThresholdType
        {
            get
            {
                return typeof(IIndexableInvoker);
            }
        }
 
        //
        // Constructors
        //
        public IIndexableInvoker(IntPtr handle, JniHandleOwnership transfer) : base(IIndexableInvoker.Validate(handle), transfer)
        {
            IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
            this.class_ref = JNIEnv.NewGlobalRef(objectClass);
            JNIEnv.DeleteLocalRef(objectClass);
        }
 
        //
        // Static Methods
        //
        public static IIndexable GetObject(IntPtr handle, JniHandleOwnership transfer)
        {
            return Java.Lang.Object.GetObject<IIndexable>(handle, transfer);
        }
 
        private static IntPtr Validate(IntPtr handle)
        {
            if (!JNIEnv.IsInstanceOf(handle, IIndexableInvoker.java_class_ref))
            {
                throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "com.google.firebase.IIndexable"));
            }
            return handle;
        }
 
        //
        // Methods
        //
        protected override void Dispose(bool disposing)
        {
            if (this.class_ref != IntPtr.Zero)
            {
                JNIEnv.DeleteGlobalRef(this.class_ref);
            }
            this.class_ref = IntPtr.Zero;
            base.Dispose(disposing);
        }
    }
    */
}
