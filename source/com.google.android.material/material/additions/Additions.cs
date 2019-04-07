using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Material
{

    public partial class NavigationMenuItemView
    {
    }

    public partial class BottomNavigationItemView
    {
    }

}

namespace Google.Android.Material.AppBar
{

    //public partial class AppBarLayout
    //{
    //    public partial class OffsetChangedEventArgs
    //    {
    //        [Obsolete ("Use AppBarLayout property instead")]
    //        public AppBarLayout Layout {
    //            get { return AppBarLayout; }
    //            //set { AppBarLayout = value; }
    //        }
    //    }
    //}


    public partial class CollapsingToolbarLayout
    {
        public void SetTitle (string title)
        {           
            this.Title = title;
        }

        public override global::Android.Views.ViewStates Visibility {
            get { return base.Visibility; }
            set { SetVisibility (value); }
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
            global::Google.Android.Material.AppBar.CollapsingToolbarLayout __this = global::Java.Lang.Object.GetObject<global::Google.Android.Material.AppBar.CollapsingToolbarLayout> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            global::Android.Views.ViewStates visibility = (global::Android.Views.ViewStates)native_visibility;
            __this.SetVisibility (visibility);
        }
#pragma warning restore 0169

        static IntPtr id_setVisibility_I;
        // Metadata.xml XPath method reference: path="/api/package[@name='android.support.design.widget']/class[@name='CollapsingToolbarLayout']/method[@name='setVisibility' and count(parameter)=1 and parameter[1][@type='int']]"
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
}

namespace Google.Android.Material.Snackbar
{
    public partial class Snackbar
    {
        public Snackbar SetAction(string text, Action<global::Android.Views.View> clickHandler)
        {
            return SetAction(text, new SnackbarActionClickImplementor { Handler = clickHandler });
        }

        public Snackbar SetAction(Java.Lang.ICharSequence text, Action<global::Android.Views.View> clickHandler)
        {
            return SetAction(text, new SnackbarActionClickImplementor { Handler = clickHandler });
        }

        public Snackbar SetAction(int resId, Action<global::Android.Views.View> clickHandler)
        {
            return SetAction(resId, new SnackbarActionClickImplementor { Handler = clickHandler });
        }

        internal class SnackbarActionClickImplementor : Java.Lang.Object, global::Android.Views.View.IOnClickListener
        {
            public Action<global::Android.Views.View> Handler { get; set; }

            public void OnClick(global::Android.Views.View v)
            {
                var h = Handler;
                if (h != null)
                    h(v);
            }
        }
    }
}

namespace Google.Android.Material.Internal
{
    public partial class VisibilityAwareImageButton
    {
        public override global::Android.Views.ViewStates Visibility {
            get { return base.Visibility; }
            set { SetVisibility (value); }
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
            global::Google.Android.Material.Internal.VisibilityAwareImageButton __this = global::Java.Lang.Object.GetObject<global::Google.Android.Material.Internal.VisibilityAwareImageButton> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            global::Android.Views.ViewStates visibility = (global::Android.Views.ViewStates)native_visibility;
            __this.SetVisibility (visibility);
        }
#pragma warning restore 0169

        static IntPtr id_setVisibility_I;
        // Metadata.xml XPath method reference: path="/api/package[@name='android.support.design.widget']/class[@name='VisibilityAwareImageButton']/method[@name='setVisibility' and count(parameter)=1 and parameter[1][@type='int']]"
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


//    public partial class FloatingActionButton
//    {
//        public override Android.Views.ViewStates Visibility {
//            get { return base.Visibility; }
//            set { SetVisibility (value); }
//        }

//        static Delegate cb_setVisibility_I;
//#pragma warning disable 0169
//        static Delegate GetSetVisibility_IHandler ()
//        {
//            if (cb_setVisibility_I == null)
//                cb_setVisibility_I = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, int>)n_SetVisibility_I);
//            return cb_setVisibility_I;
//        }

//        static void n_SetVisibility_I (IntPtr jnienv, IntPtr native__this, int native_p0)
//        {
//            global::Android.Support.Design.Widget.FloatingActionButton __this = global::Java.Lang.Object.GetObject<global::Android.Support.Design.Widget.FloatingActionButton> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
//            global::Android.Views.ViewStates p0 = (global::Android.Views.ViewStates)native_p0;
//            __this.SetVisibility (p0);
//        }
//#pragma warning restore 0169

    //    static IntPtr id_setVisibility_I;
    //    // Metadata.xml XPath method reference: path="/api/package[@name='android.support.design.widget']/class[@name='FloatingActionButton']/method[@name='setVisibility' and count(parameter)=1 and parameter[1][@type='int']]"
    //    [Register ("setVisibility", "(I)V", "GetSetVisibility_IHandler")]
    //    public unsafe void SetVisibility ([global::Android.Runtime.GeneratedEnum] global::Android.Views.ViewStates p0)
    //    {
    //        if (id_setVisibility_I == IntPtr.Zero)
    //            id_setVisibility_I = JNIEnv.GetMethodID (class_ref, "setVisibility", "(I)V");
    //        try {
    //            JValue* __args = stackalloc JValue [1];
    //            __args [0] = new JValue ((int)p0);

    //            if (GetType () == ThresholdType)
    //                JNIEnv.CallVoidMethod (((global::Java.Lang.Object)this).Handle, id_setVisibility_I, __args);
    //            else
    //                JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setVisibility", "(I)V"), __args);
    //        } finally {
    //        }
    //    }
    //}
}

namespace Google.Android.Material.Tabs
{
    public partial class TabLayout
    {
        public partial class TabView
        {
            public override bool Selected {
                get {
                    return base.Selected;
                }
                set {
                    SetSelected (value);
                }
            }

            static Delegate cb_setSelected_Z;
#pragma warning disable 0169
            static Delegate GetSetSelected_ZHandler ()
            {
                if (cb_setSelected_Z == null)
                    cb_setSelected_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, bool>)n_SetSelected_Z);
                return cb_setSelected_Z;
            }

            static void n_SetSelected_Z (IntPtr jnienv, IntPtr native__this, bool selected)
            {

                global::Google.Android.Material.Tabs.TabLayout.TabView __this = global::Java.Lang.Object.GetObject<global::Google.Android.Material.Tabs.TabLayout.TabView> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
                __this.SetSelected (selected);
            }
#pragma warning restore 0169

            static IntPtr id_setSelected_Z;
            // Metadata.xml XPath method reference: path="/api/package[@name='android.support.design.widget']/class[@name='TabLayout.TabView']/method[@name='setSelected' and count(parameter)=1 and parameter[1][@type='boolean']]"
            [Register ("setSelected", "(Z)V", "GetSetSelected_ZHandler")]
            public unsafe void SetSelected (bool selected)
            {
                if (id_setSelected_Z == IntPtr.Zero)
                    id_setSelected_Z = JNIEnv.GetMethodID (class_ref, "setSelected", "(Z)V");
                try {
                    JValue* __args = stackalloc JValue [1];
                    __args [0] = new JValue (selected);

                    if (GetType () == ThresholdType)
                        JNIEnv.CallVoidMethod (((global::Java.Lang.Object)this).Handle, id_setSelected_Z, __args);
                    else
                        JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setSelected", "(Z)V"), __args);
                } finally {
                }
            }
        }
    }
}

namespace Google.Android.Material.TextField 
{

    public partial class TextInputLayout
    {
        public override bool Enabled {
            get {
                return base.Enabled;
            }
            set {
                SetEnabled (value);
            }
        }

        static Delegate cb_setEnabled_Z;
#pragma warning disable 0169
        static Delegate GetSetEnabled_ZHandler ()
        {
            if (cb_setEnabled_Z == null)
                cb_setEnabled_Z = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, bool>)n_SetEnabled_Z);
            return cb_setEnabled_Z;
        }

        static void n_SetEnabled_Z (IntPtr jnienv, IntPtr native__this, bool enabled)
        {
            global::Google.Android.Material.TextField.TextInputLayout __this = global::Java.Lang.Object.GetObject<global::Google.Android.Material.TextField.TextInputLayout> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            __this.SetEnabled (enabled);
        }
#pragma warning restore 0169

        static IntPtr id_setEnabled_Z;
        // Metadata.xml XPath method reference: path="/api/package[@name='android.support.design.widget']/class[@name='TextInputLayout']/method[@name='setEnabled' and count(parameter)=1 and parameter[1][@type='boolean']]"
        [Register ("setEnabled", "(Z)V", "GetSetEnabled_ZHandler")]
        public unsafe void SetEnabled (bool enabled)
        {
            if (id_setEnabled_Z == IntPtr.Zero)
                id_setEnabled_Z = JNIEnv.GetMethodID (class_ref, "setEnabled", "(Z)V");
            try {
                JValue* __args = stackalloc JValue [1];
                __args [0] = new JValue (enabled);

                if (GetType () == ThresholdType)
                    JNIEnv.CallVoidMethod (((global::Java.Lang.Object)this).Handle, id_setEnabled_Z, __args);
                else
                    JNIEnv.CallNonvirtualVoidMethod (((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "setEnabled", "(Z)V"), __args);
            } finally {
            }
        }
    }
}


// namespace Google.Android.Material.Animation
// {

// 	public partial class ArgbEvaluatorCompat
// 	{
// 		public Java.Lang.Object Evaluate(float fraction, Java.Lang.Object startValue, Java.Lang.Object endValue)
// 		{
// 			return Evaluate(fraction, (Java.Lang.Integer)startValue, (Java.Lang.Integer)endValue);
// 		}
// 	}

// 	public partial class MatrixEvaluator
// 	{
// 		public Java.Lang.Object Evaluate(float fraction, Java.Lang.Object startValue, Java.Lang.Object endValue)
// 		{
// 			return Evaluate(fraction, (Java.Lang.Integer)startValue, (Java.Lang.Integer)endValue);
// 		}
// 	}
// }

// namespace Google.Android.Material.CircularReveal
// {
// 	public partial class CircularRevealWidgetCircularRevealEvaluator
// 	{
// 		public Java.Lang.Object Evaluate(float fraction, Java.Lang.Object startValue, Java.Lang.Object endValue)
// 		{
// 			return Evaluate(fraction, (Java.Lang.Integer)startValue, (Java.Lang.Integer)endValue);
// 		}
// 	}
// }


namespace Google.Android.Material.BottomNavigation
{

    // Metadata.xml XPath class reference: path="/api/package[@name='com.google.android.material.bottomnavigation']/class[@name='BottomNavigationItemView']"
    // [global::Android.Runtime.Register("com/google/android/material/bottomnavigation/BottomNavigationItemView", DoNotGenerateAcw = true)]
    public partial class BottomNavigationItemView 
    {
        bool enabled;
        public bool Enabled
        {
            get
            {
                return enabled;
            }
            set
            {
                SetEnabled(value);
            }
        }

                static Delegate cb_setEnabled_Z;
        #pragma warning disable 0169
                static Delegate GetSetEnabled_ZHandler()
                {
                    if (cb_setEnabled_Z == null)
                        cb_setEnabled_Z = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, bool>)n_SetEnabled_Z);
                    return cb_setEnabled_Z;
                }

                static void n_SetEnabled_Z(IntPtr jnienv, IntPtr native__this, bool enabled)
                {
                    global::Google.Android.Material.BottomNavigation.BottomNavigationItemView __this = global::Java.Lang.Object.GetObject<global::Google.Android.Material.BottomNavigation.BottomNavigationItemView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
                    __this.SetEnabled(enabled);
                }
        #pragma warning restore 0169

        // Metadata.xml XPath method reference: path="/api/package[@name='com.google.android.material.bottomnavigation']/class[@name='BottomNavigationItemView']/method[@name='setEnabled' and count(parameter)=1 and parameter[1][@type='boolean']]"
        [Register("setEnabled", "(Z)V", "GetSetEnabled_ZHandler")]
        public unsafe void SetEnabled(bool enabled)
        {
            const string __id = "setEnabled.(Z)V";
            try
            {
                JniArgumentValue* __args = stackalloc JniArgumentValue[1];
                __args[0] = new JniArgumentValue(enabled);
                _members.InstanceMethods.InvokeVirtualVoidMethod(__id, this, __args);
            }
            finally
            {
            }
        }
    }
}

namespace Google.Android.Material.Internal
{

    // Metadata.xml XPath class reference: path="/api/package[@name='com.google.android.material.internal']/class[@name='NavigationMenuItemView']"
    //[global::Android.Runtime.Register("com/google/android/material/internal/NavigationMenuItemView", DoNotGenerateAcw = true)]
    public partial class NavigationMenuItemView : global::Google.Android.Material.Internal.ForegroundLinearLayout, global::AndroidX.AppCompat.View.Menu.IMenuViewItemView
    {
        bool enabled;
        public bool Enabled
        {
            get
            {
                return enabled;
            }
            set
            {
                SetEnabled(value); 
            }
        }


        static Delegate cb_setEnabled_Z;
#pragma warning disable 0169
        static Delegate GetSetEnabled_ZHandler()
        {
            if (cb_setEnabled_Z == null)
                cb_setEnabled_Z = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, bool>)n_SetEnabled_Z);
            return cb_setEnabled_Z;
        }

        static void n_SetEnabled_Z(IntPtr jnienv, IntPtr native__this, bool enabled)
        {
            global::Google.Android.Material.Internal.NavigationMenuItemView __this = global::Java.Lang.Object.GetObject<global::Google.Android.Material.Internal.NavigationMenuItemView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            __this.SetEnabled(enabled);
        }
#pragma warning restore 0169

        // Metadata.xml XPath method reference: path="/api/package[@name='com.google.android.material.internal']/class[@name='NavigationMenuItemView']/method[@name='setEnabled' and count(parameter)=1 and parameter[1][@type='boolean']]"
        [Register("setEnabled", "(Z)V", "GetSetEnabled_ZHandler")]
        public unsafe void SetEnabled(bool enabled)
        {
            const string __id = "setEnabled.(Z)V";
            try
            {
                JniArgumentValue* __args = stackalloc JniArgumentValue[1];
                __args[0] = new JniArgumentValue(enabled);
                _members.InstanceMethods.InvokeVirtualVoidMethod(__id, this, __args);
            }
            finally
            {
            }
        }
    }
}

namespace Google.Android.Material.CircularReveal
{
    // Metadata.xml XPath class reference: path="/api/package[@name='com.google.android.material.circularreveal']/class[@name='CircularRevealWidget.CircularRevealProperty']"
    //[global::Android.Runtime.Register("com/google/android/material/circularreveal/CircularRevealWidget$CircularRevealProperty", DoNotGenerateAcw = true)]
    public partial class CircularRevealWidgetCircularRevealProperty 
    {
        public override Java.Lang.Object Get(Java.Lang.Object @object)
        {

            return this.Get(@object as Google.Android.Material.CircularReveal.ICircularRevealWidget);
        }
    }

    public partial class CircularRevealWidgetCircularRevealScrimColorProperty
    {
        public override Java.Lang.Object Get(Java.Lang.Object @object)
        {

            return this.Get(@object as Google.Android.Material.CircularReveal.ICircularRevealWidget);
        }
    }
}


