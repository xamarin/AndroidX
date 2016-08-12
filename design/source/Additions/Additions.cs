using System;
using Android.Runtime;

namespace Android.Support.Design.Widget
{
    //public partial class CollapsingToolbarLayout
    //{
    //    public void SetTitle (string title)
    //    {           
    //        this.Title = title;
    //    }
    //}

    public partial class Snackbar
    {
        public Snackbar SetAction (string text, Action<Android.Views.View> clickHandler)
        {
            return SetAction (text, new SnackbarActionClickImplementor { Handler = clickHandler });
        }

        public Snackbar SetAction (Java.Lang.ICharSequence text, Action<Android.Views.View> clickHandler)
        {
            return SetAction (text, new SnackbarActionClickImplementor { Handler = clickHandler });
        }

        public Snackbar SetAction (int resId, Action<Android.Views.View> clickHandler)
        {
            return SetAction (resId, new SnackbarActionClickImplementor { Handler = clickHandler });
        }

        internal class SnackbarActionClickImplementor : Java.Lang.Object, Android.Views.View.IOnClickListener
        {
            public Action<Android.Views.View> Handler { get; set; }

            public void OnClick (Android.Views.View v)
            {
                var h = Handler;
                if (h != null)
                    h (v);
            }                
        }
    }

    public partial class CoordinatorLayout
    {                
        IntPtr id_getNestedViewAxes = IntPtr.Zero;
        IntPtr id_setNestedViewAxes = IntPtr.Zero;

        public unsafe virtual int NestedScrollViewAxes {
            [Register ("getNestedViewAxes", "()I", "GetGetNestedViewAccessHandler")]
            get {
                if (id_getNestedViewAxes == IntPtr.Zero) {
                    id_getNestedViewAxes = JNIEnv.GetMethodID (class_ref, "getNestedViewAxes", "()I");
                }
                int result;
                try {
                    if (base.GetType () == this.ThresholdType) {
                        result = JNIEnv.CallIntMethod (base.Handle, id_getNestedViewAxes);
                    }
                    else {
                        result = JNIEnv.CallNonvirtualIntMethod (base.Handle, this.ThresholdClass, JNIEnv.GetMethodID (this.ThresholdClass, "getNestedViewAxes", "()I"));
                    }
                }
                finally {
                }
                return result;
            }
            [Register ("setNestedViewAxes", "(I)V", "GetSetNestedViewAccessHandler")]
            set {
                if (id_setNestedViewAxes == IntPtr.Zero) {
                    id_setNestedViewAxes = JNIEnv.GetMethodID (class_ref, "setNestedViewAccess", "(I)V");
                }
                try {
                    JValue* ptr = stackalloc JValue[1];
                    *ptr = new JValue (value);
                    if (base.GetType () == this.ThresholdType) {
                        JNIEnv.CallVoidMethod (base.Handle, id_setNestedViewAxes, ptr);
                    }
                    else {
                        JNIEnv.CallNonvirtualVoidMethod (base.Handle, this.ThresholdClass, JNIEnv.GetMethodID (this.ThresholdClass, "setNestedViewAccess", "(I)V"), ptr);
                    }
                }
                finally {
                }
            }
        }

    }
}


