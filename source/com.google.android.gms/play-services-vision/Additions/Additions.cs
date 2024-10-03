using System;
using Android.Runtime;

namespace Android.Gms.Vision.Barcodes
{
    public partial class Barcode
    {
        public BarcodeFormat Format {
            get {
                return (BarcodeFormat)_Format;
            }
        }

        public BarcodeValueFormat ValueFormat {
            get {
                return (BarcodeValueFormat)_ValueFormat;
            }
        }
    }
}

namespace Android.Gms.Vision.Faces
{
	public partial class FaceDetector
	{
		static IntPtr id_finalize;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.google.android.gms.vision.face']/class[@name='FaceDetector']/method[@name='finalize' and count(parameter)=0]"
		[Register("finalize", "()V", "")]
		protected new unsafe void Dispose()
		{
			if (id_finalize == IntPtr.Zero)
				id_finalize = JNIEnv.GetMethodID(class_ref, "finalize", "()V");
			try
			{
				JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_finalize);
			}
			finally
			{
			}

			base.Dispose();
		}

	}
}

