using System;
using Android.Runtime;

namespace Android.Support.Graphics.Drawable
{
    public partial class VectorDrawableCompat
    {
        public override void SetAlpha (int alpha)
        {
            Alpha = alpha;
        }

//        [Register ("setColorFilter", "(Landroid/graphics/ColorFilter;)V", "GetSetColorFilter_Landroid_graphics_ColorFilter_Handler")]
//        public override void SetColorFilter (Android.Graphics.ColorFilter cf)
//        {
//
//        }
//        // Metadata.xml XPath method reference: path="/api/package[@name='android.support.graphics.drawable']/class[@name='VectorDrawableCompat']/method[@name='setColorFilter' and count(parameter)=1 and parameter[1][@type='android.graphics.ColorFilter']]"
//        [Register ("setColorFilter", "(Landroid/graphics/ColorFilter;)V", "GetSetColorFilter_Landroid_graphics_ColorFilter_Handler")]
//        set {
//            if (id_setColorFilter_Landroid_graphics_ColorFilter_ == IntPtr.Zero)
//                id_setColorFilter_Landroid_graphics_ColorFilter_ = JNIEnv.GetMethodID (class_ref, "setColorFilter", "(Landroid/graphics/ColorFilter;)V");
//            try {
//                JValue* __args = stackalloc JValue [1];
//                __args [0] = new JValue (value);
//
//                if (GetType () == ThresholdType)
//                    JNIEnv.CallVoidMethod  (Handle, id_setColorFilter_Landroid_graphics_ColorFilter_, __args);
//                else
//                    JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setColorFilter", "(Landroid/graphics/ColorFilter;)V"), __args);
//            } finally {
//            }
//        }
    }
}

