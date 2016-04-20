//using System;
//using Android.Runtime;
//
//namespace Android.Support.V17.Leanback.Widget
//{
//    public partial class StreamingTextView : Android.Widget.EditText
//    {
//
//        static IntPtr id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_;
//        // Metadata.xml XPath constructor reference: path="/api/package[@name='android.support.v17.leanback.widget']/class[@name='StreamingTextView']/constructor[@name='StreamingTextView' and count(parameter)=2 and parameter[1][@type='android.content.Context'] and parameter[2][@type='android.util.AttributeSet']]"
//        [Register (".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
//        public StreamingTextView (global::Android.Content.Context p0, global::Android.Util.IAttributeSet p1) : base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
//        {
//            if (Handle != IntPtr.Zero)
//                return;
//
//            if (GetType () != typeof (StreamingTextView)) {
//                SetHandle (
//                    global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(Landroid/content/Context;Landroid/util/AttributeSet;)V", new JValue (p0), new JValue (p1)),
//                    JniHandleOwnership.TransferLocalRef);
//                global::Android.Runtime.JNIEnv.FinishCreateInstance (Handle, "(Landroid/content/Context;Landroid/util/AttributeSet;)V", new JValue (p0), new JValue (p1));
//                return;
//            }
//
//            if (id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_ == IntPtr.Zero)
//                id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_ = JNIEnv.GetMethodID (class_ref, "<init>", "(Landroid/content/Context;Landroid/util/AttributeSet;)V");
//            SetHandle (
//                global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_, new JValue (p0), new JValue (p1)),
//                JniHandleOwnership.TransferLocalRef);
//            JNIEnv.FinishCreateInstance (Handle, class_ref, id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_, new JValue (p0), new JValue (p1));
//        }
//
//       
//
//        static IntPtr id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I;
//        // Metadata.xml XPath constructor reference: path="/api/package[@name='android.support.v17.leanback.widget']/class[@name='StreamingTextView']/constructor[@name='StreamingTextView' and count(parameter)=3 and parameter[1][@type='android.content.Context'] and parameter[2][@type='android.util.AttributeSet'] and parameter[3][@type='int']]"
//        [Register (".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", "")]
//        public StreamingTextView (global::Android.Content.Context p0, global::Android.Util.IAttributeSet p1, int p2) : base (IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
//        {
//            if (Handle != IntPtr.Zero)
//                return;
//
//            if (GetType () != typeof (StreamingTextView)) {
//                SetHandle (
//                    global::Android.Runtime.JNIEnv.StartCreateInstance (GetType (), "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", new JValue (p0), new JValue (p1), new JValue (p2)),
//                    JniHandleOwnership.TransferLocalRef);
//                global::Android.Runtime.JNIEnv.FinishCreateInstance (Handle, "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", new JValue (p0), new JValue (p1), new JValue (p2));
//                return;
//            }
//
//            if (id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I == IntPtr.Zero)
//                id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I = JNIEnv.GetMethodID (class_ref, "<init>", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V");
//            SetHandle (
//                global::Android.Runtime.JNIEnv.StartCreateInstance (class_ref, id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I, new JValue (p0), new JValue (p1), new JValue (p2)),
//                JniHandleOwnership.TransferLocalRef);
//            JNIEnv.FinishCreateInstance (Handle, class_ref, id_ctor_Landroid_content_Context_Landroid_util_AttributeSet_I, new JValue (p0), new JValue (p1), new JValue (p2));
//        }
//
//
//        internal static IntPtr java_class_handle;
//        internal static IntPtr class_ref {
//            get {
//                return JNIEnv.FindClass ("android/support/v17/leanback/widget/StreamingTextView", ref java_class_handle);
//            }
//        }
//
//
//        protected override IntPtr ThresholdClass {
//            get { return class_ref; }
//        }
//
//        protected override global::System.Type ThresholdType {
//            get { return typeof (StreamingTextView); }
//        }
//
//
//        static IntPtr id_onInitializeAccessibilityNodeInfo_Landroid_view_accessibility_AccessibilityNodeInfo_;
//        // Metadata.xml XPath method reference: path="/api/package[@name='android.support.v17.leanback.widget']/class[@name='SearchEditText']/method[@name='onInitializeAccessibilityNodeInfo' and count(parameter)=1 and parameter[1][@type='android.view.accessibility.AccessibilityNodeInfo']]"
//        [Register ("onInitializeAccessibilityNodeInfo", "(Landroid/view/accessibility/AccessibilityNodeInfo;)V", "GetOnInitializeAccessibilityNodeInfo_Landroid_view_accessibility_AccessibilityNodeInfo_Handler")]
//        public void OnInitializeAccessibilityNodeInfo (global::Android.Views.Accessibility.AccessibilityNodeInfo p0)
//        {
//            if (id_onInitializeAccessibilityNodeInfo_Landroid_view_accessibility_AccessibilityNodeInfo_ == IntPtr.Zero)
//                id_onInitializeAccessibilityNodeInfo_Landroid_view_accessibility_AccessibilityNodeInfo_ = JNIEnv.GetMethodID (class_ref, "onInitializeAccessibilityNodeInfo", "(Landroid/view/accessibility/AccessibilityNodeInfo;)V");
//
//            if (GetType () == ThresholdType)
//                JNIEnv.CallVoidMethod  (Handle, id_onInitializeAccessibilityNodeInfo_Landroid_view_accessibility_AccessibilityNodeInfo_, new JValue (p0));
//            else
//                JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onInitializeAccessibilityNodeInfo", "(Landroid/view/accessibility/AccessibilityNodeInfo;)V"), new JValue (p0));
//        }
//
//
//        static IntPtr id_reset;
//        // Metadata.xml XPath method reference: path="/api/package[@name='android.support.v17.leanback.widget']/class[@name='SearchEditText']/method[@name='reset' and count(parameter)=0]"
//        [Register ("reset", "()V", "GetResetHandler")]
//        public void Reset ()
//        {
//            if (id_reset == IntPtr.Zero)
//                id_reset = JNIEnv.GetMethodID (class_ref, "reset", "()V");
//
//            if (GetType () == ThresholdType)
//                JNIEnv.CallVoidMethod  (Handle, id_reset);
//            else
//                JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "reset", "()V"));
//        }
//
//
//        static IntPtr id_setFinalRecognizedText_Ljava_lang_CharSequence_;
//        // Metadata.xml XPath method reference: path="/api/package[@name='android.support.v17.leanback.widget']/class[@name='SearchEditText']/method[@name='setFinalRecognizedText' and count(parameter)=1 and parameter[1][@type='java.lang.CharSequence']]"
//        [Register ("setFinalRecognizedText", "(Ljava/lang/CharSequence;)V", "GetSetFinalRecognizedText_Ljava_lang_CharSequence_Handler")]
//        public void SetFinalRecognizedText (global::Java.Lang.ICharSequence p0)
//        {
//            if (id_setFinalRecognizedText_Ljava_lang_CharSequence_ == IntPtr.Zero)
//                id_setFinalRecognizedText_Ljava_lang_CharSequence_ = JNIEnv.GetMethodID (class_ref, "setFinalRecognizedText", "(Ljava/lang/CharSequence;)V");
//            IntPtr native_p0 = CharSequence.ToLocalJniHandle (p0);
//
//            if (GetType () == ThresholdType)
//                JNIEnv.CallVoidMethod  (Handle, id_setFinalRecognizedText_Ljava_lang_CharSequence_, new JValue (native_p0));
//            else
//                JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setFinalRecognizedText", "(Ljava/lang/CharSequence;)V"), new JValue (native_p0));
//            JNIEnv.DeleteLocalRef (native_p0);
//        }
//
//
//        static IntPtr id_updateRecognizedText_Ljava_lang_String_Ljava_lang_String_;
//        // Metadata.xml XPath method reference: path="/api/package[@name='android.support.v17.leanback.widget']/class[@name='SearchEditText']/method[@name='updateRecognizedText' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.lang.String']]"
//        [Register ("updateRecognizedText", "(Ljava/lang/String;Ljava/lang/String;)V", "GetUpdateRecognizedText_Ljava_lang_String_Ljava_lang_String_Handler")]
//        public void UpdateRecognizedText (string p0, string p1)
//        {
//            if (id_updateRecognizedText_Ljava_lang_String_Ljava_lang_String_ == IntPtr.Zero)
//                id_updateRecognizedText_Ljava_lang_String_Ljava_lang_String_ = JNIEnv.GetMethodID (class_ref, "updateRecognizedText", "(Ljava/lang/String;Ljava/lang/String;)V");
//            IntPtr native_p0 = JNIEnv.NewString (p0);
//            IntPtr native_p1 = JNIEnv.NewString (p1);
//
//            if (GetType () == ThresholdType)
//                JNIEnv.CallVoidMethod  (Handle, id_updateRecognizedText_Ljava_lang_String_Ljava_lang_String_, new JValue (native_p0), new JValue (native_p1));
//            else
//                JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "updateRecognizedText", "(Ljava/lang/String;Ljava/lang/String;)V"), new JValue (native_p0), new JValue (native_p1));
//            JNIEnv.DeleteLocalRef (native_p0);
//            JNIEnv.DeleteLocalRef (native_p1);
//        }
//
//
//
//        static IntPtr id_updateRecognizedText_Ljava_lang_String_Ljava_util_List_;
//        // Metadata.xml XPath method reference: path="/api/package[@name='android.support.v17.leanback.widget']/class[@name='SearchEditText']/method[@name='updateRecognizedText' and count(parameter)=2 and parameter[1][@type='java.lang.String'] and parameter[2][@type='java.util.List']]"
//        [Register ("updateRecognizedText", "(Ljava/lang/String;Ljava/util/List;)V", "GetUpdateRecognizedText_Ljava_lang_String_Ljava_util_List_Handler")]
//        public void UpdateRecognizedText (string p0, global::System.Collections.IList p1)
//        {
//            if (id_updateRecognizedText_Ljava_lang_String_Ljava_util_List_ == IntPtr.Zero)
//                id_updateRecognizedText_Ljava_lang_String_Ljava_util_List_ = JNIEnv.GetMethodID (class_ref, "updateRecognizedText", "(Ljava/lang/String;Ljava/util/List;)V");
//            IntPtr native_p0 = JNIEnv.NewString (p0);
//            IntPtr native_p1 = global::Android.Runtime.JavaList.ToLocalJniHandle (p1);
//
//            if (GetType () == ThresholdType)
//                JNIEnv.CallVoidMethod  (Handle, id_updateRecognizedText_Ljava_lang_String_Ljava_util_List_, new JValue (native_p0), new JValue (native_p1));
//            else
//                JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "updateRecognizedText", "(Ljava/lang/String;Ljava/util/List;)V"), new JValue (native_p0), new JValue (native_p1));
//            JNIEnv.DeleteLocalRef (native_p0);
//            JNIEnv.DeleteLocalRef (native_p1);
//        }
//    }
//}
//
