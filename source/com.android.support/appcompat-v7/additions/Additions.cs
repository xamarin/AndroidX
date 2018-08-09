using System;
using Android.Runtime;
using Java.Interop;

namespace Android.Support.V7.View
{

    public partial class SupportActionModeWrapper
    {
        static Delegate cb_getTitle;
#pragma warning disable 0169
        static Delegate GetGetTitleHandler ()
        {
            if (cb_getTitle == null)
                cb_getTitle = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>)n_GetTitle);
            return cb_getTitle;
        }

        static IntPtr n_GetTitle (IntPtr jnienv, IntPtr native__this)
        {
            global::Android.Support.V7.View.SupportActionModeWrapper __this = global::Java.Lang.Object.GetObject<global::Android.Support.V7.View.SupportActionModeWrapper> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            return CharSequence.ToLocalJniHandle (__this.TitleFormatted);
        }
#pragma warning restore 0169

        static IntPtr id_getTitle;
        public override unsafe global::Java.Lang.ICharSequence TitleFormatted {
            // Metadata.xml XPath method reference: path="/api/package[@name='android.support.v7.view']/class[@name='SupportActionModeWrapper']/method[@name='getTitle' and count(parameter)=0]"
            [Register ("getTitle", "()Ljava/lang/CharSequence;", "GetGetTitleHandler")]
            get {
                if (id_getTitle == IntPtr.Zero)
                    id_getTitle = JNIEnv.GetMethodID (class_ref, "getTitle", "()Ljava/lang/CharSequence;");
                try {

                    if (GetType () == ThresholdType)
                        return global::Java.Lang.Object.GetObject<Java.Lang.ICharSequence> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object)this).Handle, id_getTitle), JniHandleOwnership.TransferLocalRef);
                    else
                        return global::Java.Lang.Object.GetObject<Java.Lang.ICharSequence> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getTitle", "()Ljava/lang/CharSequence;")), JniHandleOwnership.TransferLocalRef);
                } finally {
                }
            }

            set {
                SetTitle (value);
            }
        }


        static Delegate cb_setTitle_Ljava_lang_CharSequence_;
#pragma warning disable 0169
        static Delegate GetSetTitle_Ljava_lang_CharSequence_Handler ()
        {
            if (cb_setTitle_Ljava_lang_CharSequence_ == null)
                cb_setTitle_Ljava_lang_CharSequence_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>)n_SetTitle_Ljava_lang_CharSequence_);
            return cb_setTitle_Ljava_lang_CharSequence_;
        }

        static void n_SetTitle_Ljava_lang_CharSequence_ (IntPtr jnienv, IntPtr native__this, IntPtr native_title)
        {
            global::Android.Support.V7.View.SupportActionModeWrapper __this = global::Java.Lang.Object.GetObject<global::Android.Support.V7.View.SupportActionModeWrapper> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            global::Java.Lang.ICharSequence title = global::Java.Lang.Object.GetObject<global::Java.Lang.ICharSequence> (native_title, JniHandleOwnership.DoNotTransfer);
            __this.SetTitle (title);
        }
#pragma warning restore 0169

        static IntPtr id_setTitle_Ljava_lang_CharSequence_;
        // Metadata.xml XPath method reference: path="/api/package[@name='android.support.v7.view']/class[@name='SupportActionModeWrapper']/method[@name='setTitle' and count(parameter)=1 and parameter[1][@type='java.lang.CharSequence']]"
        [Register ("setTitle", "(Ljava/lang/CharSequence;)V", "GetSetTitle_Ljava_lang_CharSequence_Handler")]
        public unsafe void SetTitle (global::Java.Lang.ICharSequence title)
        {
            if (id_setTitle_Ljava_lang_CharSequence_ == IntPtr.Zero)
                id_setTitle_Ljava_lang_CharSequence_ = JNIEnv.GetMethodID (class_ref, "setTitle", "(Ljava/lang/CharSequence;)V");
            IntPtr native_title = CharSequence.ToLocalJniHandle (title);
            try {
                JValue* __args = stackalloc JValue [1];
                __args [0] = new JValue (native_title);

                if (GetType () == ThresholdType)
                    JNIEnv.CallVoidMethod (((global::Java.Lang.Object)this).Handle, id_setTitle_Ljava_lang_CharSequence_, __args);
                else
                    JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setTitle", "(Ljava/lang/CharSequence;)V"), __args);
            } finally {
                JNIEnv.DeleteLocalRef (native_title);
            }
        }





        static Delegate cb_getSubtitle;
#pragma warning disable 0169
        static Delegate GetGetSubtitleHandler ()
        {
            if (cb_getSubtitle == null)
                cb_getSubtitle = JNINativeWrapper.CreateDelegate ((Func<IntPtr, IntPtr, IntPtr>)n_GetSubtitle);
            return cb_getSubtitle;
        }

        static IntPtr n_GetSubtitle (IntPtr jnienv, IntPtr native__this)
        {
            global::Android.Support.V7.View.SupportActionModeWrapper __this = global::Java.Lang.Object.GetObject<global::Android.Support.V7.View.SupportActionModeWrapper> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            return CharSequence.ToLocalJniHandle (__this.SubtitleFormatted);
        }
#pragma warning restore 0169

        static IntPtr id_getSubtitle;
        public override unsafe global::Java.Lang.ICharSequence SubtitleFormatted {
            // Metadata.xml XPath method reference: path="/api/package[@name='android.support.v7.view']/class[@name='SupportActionModeWrapper']/method[@name='getSubtitle' and count(parameter)=0]"
            [Register ("getSubtitle", "()Ljava/lang/CharSequence;", "GetGetSubtitleHandler")]
            get {
                if (id_getSubtitle == IntPtr.Zero)
                    id_getSubtitle = JNIEnv.GetMethodID (class_ref, "getSubtitle", "()Ljava/lang/CharSequence;");
                try {

                    if (GetType () == ThresholdType)
                        return global::Java.Lang.Object.GetObject<Java.Lang.ICharSequence> (JNIEnv.CallObjectMethod (((global::Java.Lang.Object)this).Handle, id_getSubtitle), JniHandleOwnership.TransferLocalRef);
                    else
                        return global::Java.Lang.Object.GetObject<Java.Lang.ICharSequence> (JNIEnv.CallNonvirtualObjectMethod (((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getSubtitle", "()Ljava/lang/CharSequence;")), JniHandleOwnership.TransferLocalRef);
                } finally {
                }
            }
            set {
                SetSubtitle (value);
            }
        }


        static Delegate cb_setSubtitle_Ljava_lang_CharSequence_;
#pragma warning disable 0169
        static Delegate GetSetSubtitle_Ljava_lang_CharSequence_Handler ()
        {
            if (cb_setSubtitle_Ljava_lang_CharSequence_ == null)
                cb_setSubtitle_Ljava_lang_CharSequence_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>)n_SetSubtitle_Ljava_lang_CharSequence_);
            return cb_setSubtitle_Ljava_lang_CharSequence_;
        }

        static void n_SetSubtitle_Ljava_lang_CharSequence_ (IntPtr jnienv, IntPtr native__this, IntPtr native_subtitle)
        {
            global::Android.Support.V7.View.SupportActionModeWrapper __this = global::Java.Lang.Object.GetObject<global::Android.Support.V7.View.SupportActionModeWrapper> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            global::Java.Lang.ICharSequence subtitle = global::Java.Lang.Object.GetObject<global::Java.Lang.ICharSequence> (native_subtitle, JniHandleOwnership.DoNotTransfer);
            __this.SetSubtitle (subtitle);
        }
#pragma warning restore 0169

        static IntPtr id_setSubtitle_Ljava_lang_CharSequence_;
        // Metadata.xml XPath method reference: path="/api/package[@name='android.support.v7.view']/class[@name='SupportActionModeWrapper']/method[@name='setSubtitle' and count(parameter)=1 and parameter[1][@type='java.lang.CharSequence']]"
        [Register ("setSubtitle", "(Ljava/lang/CharSequence;)V", "GetSetSubtitle_Ljava_lang_CharSequence_Handler")]
        public unsafe void SetSubtitle (global::Java.Lang.ICharSequence subtitle)
        {
            if (id_setSubtitle_Ljava_lang_CharSequence_ == IntPtr.Zero)
                id_setSubtitle_Ljava_lang_CharSequence_ = JNIEnv.GetMethodID (class_ref, "setSubtitle", "(Ljava/lang/CharSequence;)V");
            IntPtr native_subtitle = CharSequence.ToLocalJniHandle (subtitle);
            try {
                JValue* __args = stackalloc JValue [1];
                __args [0] = new JValue (native_subtitle);

                if (GetType () == ThresholdType)
                    JNIEnv.CallVoidMethod (((global::Java.Lang.Object)this).Handle, id_setSubtitle_Ljava_lang_CharSequence_, __args);
                else
                    JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setSubtitle", "(Ljava/lang/CharSequence;)V"), __args);
            } finally {
                JNIEnv.DeleteLocalRef (native_subtitle);
            }
        }
    }
}

namespace Android.Support.V7.Widget
{
    public partial class AbsActionBarView
    {
        public override Android.Views.ViewStates Visibility {
            get {
                return base.Visibility;
            }
            set {
                SetVisibility (value);
            }
        }

        static Delegate cb_setVisibility_I;
#pragma warning disable 0169
        static Delegate GetSetVisibility_IHandler ()
        {
            if (cb_setVisibility_I == null)
                cb_setVisibility_I = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, int>)n_SetVisibility_I);
            return cb_setVisibility_I;
        }

        static void n_SetVisibility_I (IntPtr jnienv, IntPtr native__this, int native_visibility)
        {
            global::Android.Support.V7.Widget.AbsActionBarView __this = global::Java.Lang.Object.GetObject<global::Android.Support.V7.Widget.AbsActionBarView> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            global::Android.Views.ViewStates visibility = (global::Android.Views.ViewStates)native_visibility;
            __this.SetVisibility (visibility);
        }
#pragma warning restore 0169

        static IntPtr id_setVisibility_I;
        // Metadata.xml XPath method reference: path="/api/package[@name='android.support.v7.widget']/class[@name='AbsActionBarView']/method[@name='setVisibility' and count(parameter)=1 and parameter[1][@type='int']]"
        [Register ("setVisibility", "(I)V", "GetSetVisibility_IHandler")]
        public unsafe virtual void SetVisibility ([global::Android.Runtime.GeneratedEnum] global::Android.Views.ViewStates visibility)
        {
            if (id_setVisibility_I == IntPtr.Zero)
                id_setVisibility_I = JNIEnv.GetMethodID (class_ref, "setVisibility", "(I)V");
            try {
                JValue* __args = stackalloc JValue [1];
                __args [0] = new JValue ((int)visibility);

                if (GetType () == ThresholdType)
                    JNIEnv.CallVoidMethod (((global::Java.Lang.Object)this).Handle, id_setVisibility_I, __args);
                else
                    JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setVisibility", "(I)V"), __args);
            } finally {
            }
        }
    }


    public partial class ActionBarContainer
    {
        public override Android.Views.ViewStates Visibility {
            get {
                return base.Visibility;
            }
            set {
                SetVisibility (value);
            }
        }

        static Delegate cb_setVisibility_I;
#pragma warning disable 0169
        static Delegate GetSetVisibility_IHandler ()
        {
            if (cb_setVisibility_I == null)
                cb_setVisibility_I = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, int>)n_SetVisibility_I);
            return cb_setVisibility_I;
        }

        static void n_SetVisibility_I (IntPtr jnienv, IntPtr native__this, int native_visibility)
        {
            global::Android.Support.V7.Widget.ActionBarContainer __this = global::Java.Lang.Object.GetObject<global::Android.Support.V7.Widget.ActionBarContainer> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            global::Android.Views.ViewStates visibility = (global::Android.Views.ViewStates)native_visibility;
            __this.SetVisibility (visibility);
        }
#pragma warning restore 0169

        static IntPtr id_setVisibility_I;
        // Metadata.xml XPath method reference: path="/api/package[@name='android.support.v7.widget']/class[@name='ActionBarContainer']/method[@name='setVisibility' and count(parameter)=1 and parameter[1][@type='int']]"
        [Register ("setVisibility", "(I)V", "GetSetVisibility_IHandler")]
        public unsafe void SetVisibility ([global::Android.Runtime.GeneratedEnum] global::Android.Views.ViewStates visibility)
        {
            if (id_setVisibility_I == IntPtr.Zero)
                id_setVisibility_I = JNIEnv.GetMethodID (class_ref, "setVisibility", "(I)V");
            try {
                JValue* __args = stackalloc JValue [1];
                __args [0] = new JValue ((int)visibility);

                if (GetType () == ThresholdType)
                    JNIEnv.CallVoidMethod (((global::Java.Lang.Object)this).Handle, id_setVisibility_I, __args);
                else
                    JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setVisibility", "(I)V"), __args);
            } finally {
            }
        }
    }


//    public partial class AppCompatSpinner
//    {
//        public override Android.Widget.ISpinnerAdapter Adapter {
//            get {
//                return base.Adapter;
//            }
//            set {
//                SetAdapter (value);
//            }
//        }

//        static Delegate cb_setAdapter_Landroid_widget_SpinnerAdapter_;
//#pragma warning disable 0169
//        static Delegate GetSetAdapter_Landroid_widget_SpinnerAdapter_Handler ()
//        {
//            if (cb_setAdapter_Landroid_widget_SpinnerAdapter_ == null)
//                cb_setAdapter_Landroid_widget_SpinnerAdapter_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>)n_SetAdapter_Landroid_widget_SpinnerAdapter_);
//            return cb_setAdapter_Landroid_widget_SpinnerAdapter_;
//        }

//        static void n_SetAdapter_Landroid_widget_SpinnerAdapter_ (IntPtr jnienv, IntPtr native__this, IntPtr native_adapter)
//        {
//            global::Android.Support.V7.Widget.AppCompatSpinner __this = global::Java.Lang.Object.GetObject<global::Android.Support.V7.Widget.AppCompatSpinner> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//            global::Android.Widget.ISpinnerAdapter adapter = (global::Android.Widget.ISpinnerAdapter)global::Java.Lang.Object.GetObject<global::Android.Widget.ISpinnerAdapter> (native_adapter, JniHandleOwnership.DoNotTransfer);
//            __this.SetAdapter (adapter);
//        }
//#pragma warning restore 0169

    //    static IntPtr id_setAdapter_Landroid_widget_SpinnerAdapter_;
    //    // Metadata.xml XPath method reference: path="/api/package[@name='android.support.v7.widget']/class[@name='AppCompatSpinner']/method[@name='setAdapter' and count(parameter)=1 and parameter[1][@type='android.widget.SpinnerAdapter']]"
    //    [Register ("setAdapter", "(Landroid/widget/SpinnerAdapter;)V", "GetSetAdapter_Landroid_widget_SpinnerAdapter_Handler")]
    //    public unsafe void SetAdapter (global::Android.Widget.ISpinnerAdapter adapter)
    //    {
    //        if (id_setAdapter_Landroid_widget_SpinnerAdapter_ == IntPtr.Zero)
    //            id_setAdapter_Landroid_widget_SpinnerAdapter_ = JNIEnv.GetMethodID (class_ref, "setAdapter", "(Landroid/widget/SpinnerAdapter;)V");
    //        try {
    //            JValue* __args = stackalloc JValue [1];
    //            __args [0] = new JValue (adapter);

    //            if (GetType () == ThresholdType)
    //                JNIEnv.CallVoidMethod (((global::Java.Lang.Object)this).Handle, id_setAdapter_Landroid_widget_SpinnerAdapter_, __args);
    //            else
    //                JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setAdapter", "(Landroid/widget/SpinnerAdapter;)V"), __args);
    //        } finally {
    //        }
    //    }
    //}


// mc++ begin
//    public partial class ListViewCompat
//    {
//        public override Android.Graphics.Drawables.Drawable Selector {
//            set {
//                SetSelector (value);
//            }
//            get {
//                return base.Selector;
//            }
//        }

//        static Delegate cb_setSelector_Landroid_graphics_drawable_Drawable_;
//#pragma warning disable 0169
//        static Delegate GetSetSelector_Landroid_graphics_drawable_Drawable_Handler ()
//        {
//            if (cb_setSelector_Landroid_graphics_drawable_Drawable_ == null)
//                cb_setSelector_Landroid_graphics_drawable_Drawable_ = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>)n_SetSelector_Landroid_graphics_drawable_Drawable_);
//            return cb_setSelector_Landroid_graphics_drawable_Drawable_;
//        }

//        static void n_SetSelector_Landroid_graphics_drawable_Drawable_ (IntPtr jnienv, IntPtr native__this, IntPtr native_sel)
//        {
//            global::Android.Support.V7.Widget.ListViewCompat __this = global::Java.Lang.Object.GetObject<global::Android.Support.V7.Widget.ListViewCompat> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//            global::Android.Graphics.Drawables.Drawable sel = global::Java.Lang.Object.GetObject<global::Android.Graphics.Drawables.Drawable> (native_sel, JniHandleOwnership.DoNotTransfer);
//            __this.SetSelector (sel);
//        }
//#pragma warning restore 0169

    //    static IntPtr id_setSelector_Landroid_graphics_drawable_Drawable_;
    //    // Metadata.xml XPath method reference: path="/api/package[@name='android.support.v7.widget']/class[@name='ListViewCompat']/method[@name='setSelector' and count(parameter)=1 and parameter[1][@type='android.graphics.drawable.Drawable']]"
    //    [Register ("setSelector", "(Landroid/graphics/drawable/Drawable;)V", "GetSetSelector_Landroid_graphics_drawable_Drawable_Handler")]
    //    public unsafe void SetSelector (global::Android.Graphics.Drawables.Drawable sel)
    //    {
    //        if (id_setSelector_Landroid_graphics_drawable_Drawable_ == IntPtr.Zero)
    //            id_setSelector_Landroid_graphics_drawable_Drawable_ = JNIEnv.GetMethodID (class_ref, "setSelector", "(Landroid/graphics/drawable/Drawable;)V");
    //        try {
    //            JValue* __args = stackalloc JValue [1];
    //            __args [0] = new JValue (sel);

    //            if (GetType () == ThresholdType)
    //                JNIEnv.CallVoidMethod (((global::Java.Lang.Object)this).Handle, id_setSelector_Landroid_graphics_drawable_Drawable_, __args);
    //            else
    //                JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setSelector", "(Landroid/graphics/drawable/Drawable;)V"), __args);
    //        } finally {
    //        }
    //    }
    //}
    // mc++ end


//    public partial class ScrollingTabContainerView
//    {
//        private partial class TabView
//        {
//            public override bool Selected {
//                set {
//                    SetSelected (value);
//                }
//                get {
//                    return base.Selected;
//                }
//            }

//            static Delegate cb_setSelected_Z;
//#pragma warning disable 0169
//            static Delegate GetSetSelected_ZHandler ()
//            {
//                if (cb_setSelected_Z == null)
//                    cb_setSelected_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, bool>)n_SetSelected_Z);
//                return cb_setSelected_Z;
//            }

//            static void n_SetSelected_Z (IntPtr jnienv, IntPtr native__this, bool selected)
//            {
//                global::Android.Support.V7.Widget.ScrollingTabContainerView.TabView __this = global::Java.Lang.Object.GetObject<global::Android.Support.V7.Widget.ScrollingTabContainerView.TabView> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//                __this.SetSelected (selected);
//            }
//#pragma warning restore 0169

//            static IntPtr id_setSelected_Z;
//            // Metadata.xml XPath method reference: path="/api/package[@name='android.support.v7.widget']/class[@name='ScrollingTabContainerView.TabView']/method[@name='setSelected' and count(parameter)=1 and parameter[1][@type='boolean']]"
//            [Register ("setSelected", "(Z)V", "GetSetSelected_ZHandler")]
//            public unsafe void SetSelected (bool selected)
//            {
//                if (id_setSelected_Z == IntPtr.Zero)
//                    id_setSelected_Z = JNIEnv.GetMethodID (class_ref, "setSelected", "(Z)V");
//                try {
//                    JValue* __args = stackalloc JValue [1];
//                    __args [0] = new JValue (selected);

//                    if (GetType () == ThresholdType)
//                        JNIEnv.CallVoidMethod (((global::Java.Lang.Object)this).Handle, id_setSelected_Z, __args);
//                    else
//                        JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setSelected", "(Z)V"), __args);
//                } finally {
//                }
//            }
//        }
//    }
}

namespace Android.Support.V7.View.Menu
{
    // Metadata.xml XPath class reference: path="/api/package[@name='android.support.v7.view.menu']/class[@name='BaseMenuPresenter']"
    public abstract partial class BaseMenuPresenter
    {
        public void SetCallback (global::Android.Support.V7.View.Menu.IMenuPresenterCallback callback)
        {
            Callback = callback;
        }
    }

    public partial class ActionMenuItemView
    {
        public void SetEnabled (bool enabled)
        {
            Enabled = enabled;
        }
    }

    public partial class ListMenuItemView
    {
        public void SetEnabled (bool enabled)
        {
            Enabled = enabled;
        }
    }

	public partial class MenuBuilder
	{
		public void SetGroupDividerEnabled(bool enabled)
		{
			GroupDividerEnabled = enabled;
		}
	}

	public partial class MenuAdapter
	{

		static Delegate cb_getItem_I;
#pragma warning disable 0169
		static Delegate GetGetItem_IHandler()
		{
			if (cb_getItem_I == null)
				cb_getItem_I = JNINativeWrapper.CreateDelegate((Func<IntPtr, IntPtr, int, Java.Lang.Object>)n_GetItem_I);
			return cb_getItem_I;
		}

		static Java.Lang.Object n_GetItem_I(IntPtr jnienv, IntPtr native__this, int position)
		{
			global::Android.Support.V7.View.Menu.MenuAdapter __this = global::Java.Lang.Object.GetObject<global::Android.Support.V7.View.Menu.MenuAdapter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return __this.GetItem(position);
		}
#pragma warning restore 0169

		// Metadata.xml XPath method reference: path="/api/package[@name='android.support.v7.view.menu']/class[@name='MenuAdapter']/method[@name='getItem' and count(parameter)=1 and parameter[1][@type='int']]"
		[Register("getItem", "(I)J", "GetGetItem_IHandler")]
		public override unsafe Java.Lang.Object GetItem(int position)
		{
			const string __id = "getItem.(I)J";
			try
			{
				JniArgumentValue* __args = stackalloc JniArgumentValue[1];
				__args[0] = new JniArgumentValue(position);
				var __rm = _members.InstanceMethods.InvokeVirtualObjectMethod(__id, this, __args);
				return global::Java.Lang.Object.GetObject<global::Java.Lang.Object>(__rm.Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
			}
		}

	}
}