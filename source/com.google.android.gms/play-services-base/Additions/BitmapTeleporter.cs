using System;
using System.Threading.Tasks;
using Android.Gms.Extensions;
using Android.Runtime;

namespace Android.Gms.Common.Data
{
    public partial class BitmapTeleporter 
    {
        static IntPtr id_describeContents;
        // Metadata.xml XPath method reference: path="/api/package[@name='com.google.android.gms.common.data']/class[@name='BitmapTeleporter']/method[@name='describeContents' and count(parameter)=0]"
        [Register("describeContents", "()I", "")]
        public unsafe int DescribeContents()
        {
            if (id_describeContents == IntPtr.Zero)
                id_describeContents = JNIEnv.GetMethodID(class_ref, "describeContents", "()I");
            try
            {
                return JNIEnv.CallIntMethod(((global::Java.Lang.Object)this).Handle, id_describeContents);
            }
            finally
            {
            }
        }
    }
}