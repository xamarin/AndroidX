using System;
using System.Threading.Tasks;
using Android.Gms.Extensions;
using Android.Runtime;

namespace Android.Gms.Auth.Api.SignIn
{
    public partial class GoogleSignInOptions 
    {
        static IntPtr id_describeContents;
        // Metadata.xml XPath method reference: path="/api/package[@name='com.google.android.gms.auth.api.signin']/class[@name='GoogleSignInOptions']/method[@name='describeContents' and count(parameter)=0]"
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