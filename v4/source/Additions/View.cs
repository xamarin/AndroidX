using System;
using Android.Runtime;

namespace Android.Support.V4.View
{
    public partial class ViewPager
    {
        IntPtr id_canScrollHorizontally_I;

        [Register ("canScrollHorizontally", "(I)Z", "GetCanScrollHorizontally_IHandler")]
        public virtual bool CanScrollHorizontally (int direction)
        {
            if (id_canScrollHorizontally_I == IntPtr.Zero) {
                id_canScrollHorizontally_I = JNIEnv.GetMethodID (class_ref, "canScrollHorizontally", "(I)Z");
            }
            if (base.GetType () == this.ThresholdType) {
                return JNIEnv.CallBooleanMethod (base.Handle, id_canScrollHorizontally_I, new JValue[] {
                    new JValue (direction)
                });
            }
            return JNIEnv.CallNonvirtualBooleanMethod (base.Handle, this.ThresholdClass, JNIEnv.GetMethodID (this.ThresholdClass, "canScrollHorizontally", "(I)Z"), new JValue[] {
                new JValue (direction)
            });
        }

    }
}

