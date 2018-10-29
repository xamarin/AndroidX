using System;
using Android.Runtime;

namespace Android.Support.V17.Preferences.Leanback
{
     public partial class LeanbackListPreferenceDialogFragment
     {
         public partial class AdapterSingle
         {
             static Delegate cb_onBindViewHolder_Landroid_support_v7_widget_RecyclerView_ViewHolder_I;
 #pragma warning disable 0169
             static Delegate GetOnBindViewHolder_Landroid_support_v7_widget_RecyclerView_ViewHolder_IHandler ()
             {
                 if (cb_onBindViewHolder_Landroid_support_v7_widget_RecyclerView_ViewHolder_I == null)
                     cb_onBindViewHolder_Landroid_support_v7_widget_RecyclerView_ViewHolder_I = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, int>)n_OnBindViewHolder_Landroid_support_v7_widget_RecyclerView_ViewHolder_I);
                 return cb_onBindViewHolder_Landroid_support_v7_widget_RecyclerView_ViewHolder_I;
             }

             static void n_OnBindViewHolder_Landroid_support_v7_widget_RecyclerView_ViewHolder_I (IntPtr jnienv, IntPtr native__this, IntPtr native_holder, int position)
             {
                 global::Android.Support.V17.Preferences.Leanback.LeanbackListPreferenceDialogFragment.AdapterSingle __this = global::Java.Lang.Object.GetObject<global::Android.Support.V17.Preferences.Leanback.LeanbackListPreferenceDialogFragment.AdapterSingle> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
                 global::Android.Support.V7.Widget.RecyclerView.ViewHolder holder = global::Java.Lang.Object.GetObject<global::Android.Support.V7.Widget.RecyclerView.ViewHolder> (native_holder, JniHandleOwnership.DoNotTransfer);
                 __this.OnBindViewHolder (holder, position);
             }
 #pragma warning restore 0169

             static IntPtr id_onBindViewHolder_Landroid_support_v7_widget_RecyclerView_ViewHolder_I;
             // Metadata.xml XPath method reference: path="/api/package[@name='android.support.v17.preference']/class[@name='LeanbackListPreferenceDialogFragment.AdapterSingle']/method[@name='onBindViewHolder' and count(parameter)=2 and parameter[1][@type='android.support.v7.widget.RecyclerView.ViewHolder'] and parameter[2][@type='int']]"
             [Register ("onBindViewHolder", "(Landroid/support/v7/widget/RecyclerView$ViewHolder;I)V", "GetOnBindViewHolder_Landroid_support_v7_widget_RecyclerView_ViewHolder_IHandler")]
             public override unsafe void OnBindViewHolder (global::Android.Support.V7.Widget.RecyclerView.ViewHolder holder, int position)
             {
                 if (id_onBindViewHolder_Landroid_support_v7_widget_RecyclerView_ViewHolder_I == IntPtr.Zero)
                     id_onBindViewHolder_Landroid_support_v7_widget_RecyclerView_ViewHolder_I = JNIEnv.GetMethodID (class_ref, "onBindViewHolder", "(Landroid/support/v7/widget/RecyclerView$ViewHolder;I)V");
                 try {
                     JValue* __args = stackalloc JValue [2];
                     __args [0] = new JValue (holder);
                     __args [1] = new JValue (position);

                     if (GetType () == ThresholdType)
                         JNIEnv.CallVoidMethod (((global::Java.Lang.Object)this).Handle, id_onBindViewHolder_Landroid_support_v7_widget_RecyclerView_ViewHolder_I, __args);
                     else
                         JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onBindViewHolder", "(Landroid/support/v7/widget/RecyclerView$ViewHolder;I)V"), __args);
                 } finally {
                 }
             }

             static Delegate cb_onCreateViewHolder_Landroid_view_ViewGroup_I;
 #pragma warning disable 0169
             static Delegate GetOnCreateViewHolder_Landroid_view_ViewGroup_IHandler ()
             {
                 if (cb_onCreateViewHolder_Landroid_view_ViewGroup_I == null)
                     cb_onCreateViewHolder_Landroid_view_ViewGroup_I = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, int, IntPtr>)n_OnCreateViewHolder_Landroid_view_ViewGroup_I);
                 return cb_onCreateViewHolder_Landroid_view_ViewGroup_I;
             }

             static IntPtr n_OnCreateViewHolder_Landroid_view_ViewGroup_I (IntPtr jnienv, IntPtr native__this, IntPtr native_parent, int viewType)
             {
                 global::Android.Support.V17.Preferences.Leanback.LeanbackListPreferenceDialogFragment.AdapterSingle __this = global::Java.Lang.Object.GetObject<global::Android.Support.V17.Preferences.Leanback.LeanbackListPreferenceDialogFragment.AdapterSingle> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
                 global::Android.Views.ViewGroup parent = global::Java.Lang.Object.GetObject<global::Android.Views.ViewGroup> (native_parent, JniHandleOwnership.DoNotTransfer);
                 IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.OnCreateViewHolder (parent, viewType));
                 return __ret;
             }
 #pragma warning restore 0169

             static IntPtr id_onCreateViewHolder_Landroid_view_ViewGroup_I;
             // Metadata.xml XPath method reference: path="/api/package[@name='android.support.v17.preference']/class[@name='LeanbackListPreferenceDialogFragment.AdapterSingle']/method[@name='onCreateViewHolder' and count(parameter)=2 and parameter[1][@type='android.view.ViewGroup'] and parameter[2][@type='int']]"
             [Register ("onCreateViewHolder", "(Landroid/view/ViewGroup;I)Landroid/support/v7/widget/RecyclerView$ViewHolder;", "GetOnCreateViewHolder_Landroid_view_ViewGroup_IHandler")]
             public override unsafe global::Android.Support.V7.Widget.RecyclerView.ViewHolder OnCreateViewHolder (global::Android.Views.ViewGroup parent, int viewType)
             {
                 if (id_onCreateViewHolder_Landroid_view_ViewGroup_I == IntPtr.Zero)
                     id_onCreateViewHolder_Landroid_view_ViewGroup_I = JNIEnv.GetMethodID (class_ref, "onCreateViewHolder", "(Landroid/view/ViewGroup;I)Landroid/support/v7/widget/RecyclerView$ViewHolder;");
                 try {
                     JValue* __args = stackalloc JValue [2];
                     __args [0] = new JValue (parent);
                     __args [1] = new JValue (viewType);

                     global::Android.Support.V7.Widget.RecyclerView.ViewHolder __ret;
                     if (GetType () == ThresholdType)
                         __ret = global::Java.Lang.Object.GetObject<global::Android.Support.V7.Widget.RecyclerView.ViewHolder> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object)this).Handle, id_onCreateViewHolder_Landroid_view_ViewGroup_I, __args), JniHandleOwnership.TransferLocalRef);
                     else
                         __ret = global::Java.Lang.Object.GetObject<global::Android.Support.V7.Widget.RecyclerView.ViewHolder> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onCreateViewHolder", "(Landroid/view/ViewGroup;I)Landroid/support/v7/widget/RecyclerView$ViewHolder;"), __args), JniHandleOwnership.TransferLocalRef);
                     return __ret;
                 } finally {
                 }
             }
         }

         public partial class AdapterMulti
         {
             static Delegate cb_onBindViewHolder_Landroid_support_v7_widget_RecyclerView_ViewHolder_I;
 #pragma warning disable 0169
             static Delegate GetOnBindViewHolder_Landroid_support_v7_widget_RecyclerView_ViewHolder_IHandler ()
             {
                 if (cb_onBindViewHolder_Landroid_support_v7_widget_RecyclerView_ViewHolder_I == null)
                     cb_onBindViewHolder_Landroid_support_v7_widget_RecyclerView_ViewHolder_I = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr, int>)n_OnBindViewHolder_Landroid_support_v7_widget_RecyclerView_ViewHolder_I);
                 return cb_onBindViewHolder_Landroid_support_v7_widget_RecyclerView_ViewHolder_I;
             }

             static void n_OnBindViewHolder_Landroid_support_v7_widget_RecyclerView_ViewHolder_I (IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1)
             {
                 global::Android.Support.V17.Preferences.Leanback.LeanbackListPreferenceDialogFragment.AdapterMulti __this = global::Java.Lang.Object.GetObject<global::Android.Support.V17.Preferences.Leanback.LeanbackListPreferenceDialogFragment.AdapterMulti> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
                 global::Android.Support.V7.Widget.RecyclerView.ViewHolder p0 = global::Java.Lang.Object.GetObject<global::Android.Support.V7.Widget.RecyclerView.ViewHolder> (native_p0, JniHandleOwnership.DoNotTransfer);
                 __this.OnBindViewHolder (p0, p1);
             }
 #pragma warning restore 0169

             static IntPtr id_onBindViewHolder_Landroid_support_v7_widget_RecyclerView_ViewHolder_I;
             // Metadata.xml XPath method reference: path="/api/package[@name='android.support.v17.preference']/class[@name='LeanbackListPreferenceDialogFragment.AdapterMulti']/method[@name='onBindViewHolder' and count(parameter)=2 and parameter[1][@type='android.support.v7.widget.RecyclerView.ViewHolder'] and parameter[2][@type='int']]"
             [Register ("onBindViewHolder", "(Landroid/support/v7/widget/RecyclerView$ViewHolder;I)V", "GetOnBindViewHolder_Landroid_support_v7_widget_RecyclerView_ViewHolder_IHandler")]
             public override unsafe void OnBindViewHolder (global::Android.Support.V7.Widget.RecyclerView.ViewHolder p0, int p1)
             {
                 if (id_onBindViewHolder_Landroid_support_v7_widget_RecyclerView_ViewHolder_I == IntPtr.Zero)
                     id_onBindViewHolder_Landroid_support_v7_widget_RecyclerView_ViewHolder_I = JNIEnv.GetMethodID (class_ref, "onBindViewHolder", "(Landroid/support/v7/widget/RecyclerView$ViewHolder;I)V");
                 try {
                     JValue* __args = stackalloc JValue [2];
                     __args [0] = new JValue (p0);
                     __args [1] = new JValue (p1);

                     if (GetType () == ThresholdType)
                         JNIEnv.CallVoidMethod (((global::Java.Lang.Object)this).Handle, id_onBindViewHolder_Landroid_support_v7_widget_RecyclerView_ViewHolder_I, __args);
                     else
                         JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onBindViewHolder", "(Landroid/support/v7/widget/RecyclerView$ViewHolder;I)V"), __args);
                 } finally {
                 }
             }

             static Delegate cb_onCreateViewHolder_Landroid_view_ViewGroup_I;
 #pragma warning disable 0169
             static Delegate GetOnCreateViewHolder_Landroid_view_ViewGroup_IHandler ()
             {
                 if (cb_onCreateViewHolder_Landroid_view_ViewGroup_I == null)
                     cb_onCreateViewHolder_Landroid_view_ViewGroup_I = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr, int, IntPtr>)n_OnCreateViewHolder_Landroid_view_ViewGroup_I);
                 return cb_onCreateViewHolder_Landroid_view_ViewGroup_I;
             }

             static IntPtr n_OnCreateViewHolder_Landroid_view_ViewGroup_I (IntPtr jnienv, IntPtr native__this, IntPtr native_parent, int viewType)
             {
                 global::Android.Support.V17.Preferences.Leanback.LeanbackListPreferenceDialogFragment.AdapterMulti __this = global::Java.Lang.Object.GetObject<global::Android.Support.V17.Preferences.Leanback.LeanbackListPreferenceDialogFragment.AdapterMulti> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
                 global::Android.Views.ViewGroup parent = global::Java.Lang.Object.GetObject<global::Android.Views.ViewGroup> (native_parent, JniHandleOwnership.DoNotTransfer);
                 IntPtr __ret = JNIEnv.ToLocalJniHandle (__this.OnCreateViewHolder (parent, viewType));
                 return __ret;
             }
 #pragma warning restore 0169

             static IntPtr id_onCreateViewHolder_Landroid_view_ViewGroup_I;
             // Metadata.xml XPath method reference: path="/api/package[@name='android.support.v17.preference']/class[@name='LeanbackListPreferenceDialogFragment.AdapterMulti']/method[@name='onCreateViewHolder' and count(parameter)=2 and parameter[1][@type='android.view.ViewGroup'] and parameter[2][@type='int']]"
             [Register ("onCreateViewHolder", "(Landroid/view/ViewGroup;I)Landroid/support/v7/widget/RecyclerView$ViewHolder;", "GetOnCreateViewHolder_Landroid_view_ViewGroup_IHandler")]
             public override unsafe global::Android.Support.V7.Widget.RecyclerView.ViewHolder OnCreateViewHolder (global::Android.Views.ViewGroup parent, int viewType)
             {
                 if (id_onCreateViewHolder_Landroid_view_ViewGroup_I == IntPtr.Zero)
                     id_onCreateViewHolder_Landroid_view_ViewGroup_I = JNIEnv.GetMethodID (class_ref, "onCreateViewHolder", "(Landroid/view/ViewGroup;I)Landroid/support/v7/widget/RecyclerView$ViewHolder;");
                 try {
                     JValue* __args = stackalloc JValue [2];
                     __args [0] = new JValue (parent);
                     __args [1] = new JValue (viewType);

                     global::Android.Support.V7.Widget.RecyclerView.ViewHolder __ret;
                     if (GetType () == ThresholdType)
                         __ret = global::Java.Lang.Object.GetObject<global::Android.Support.V7.Widget.RecyclerView.ViewHolder> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object)this).Handle, id_onCreateViewHolder_Landroid_view_ViewGroup_I, __args), JniHandleOwnership.TransferLocalRef);
                     else
                         __ret = global::Java.Lang.Object.GetObject<global::Android.Support.V7.Widget.RecyclerView.ViewHolder> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "onCreateViewHolder", "(Landroid/view/ViewGroup;I)Landroid/support/v7/widget/RecyclerView$ViewHolder;"), __args), JniHandleOwnership.TransferLocalRef);
                     return __ret;
                 } finally {
                 }
             }
         }
     }
}
