using System;
using Android.Views;
using Android.Graphics;
using Android.Runtime;
using Java.Interop;

namespace Google.Android.Material.Animation
{
    public partial class ChildrenAlphaProperty
    {
        public override Java.Lang.Object Get(Java.Lang.Object @object) =>
            Get((ViewGroup)@object);
        public override void Set(Java.Lang.Object @object, Java.Lang.Object value) =>
            Set((ViewGroup)@object, (Java.Lang.Float)value);
    }

    public partial class DrawableAlphaProperty
    {
        public override Java.Lang.Object Get(Java.Lang.Object @object) =>
            Get((global::Android.Graphics.Drawables.Drawable)@object);
        public override void Set(Java.Lang.Object @object, Java.Lang.Object value) =>
            Set((global::Android.Graphics.Drawables.Drawable)@object, (Java.Lang.Integer)value);
    }

    public partial class ImageMatrixProperty
    {
        public override Java.Lang.Object Get(Java.Lang.Object @object) =>
            Get((global::Android.Widget.ImageView)@object);
        public override void Set(Java.Lang.Object @object, Java.Lang.Object value) =>
            Set((global::Android.Widget.ImageView)@object, (Matrix)value);
    }

    public partial class ArgbEvaluatorCompat
    {
        public Java.Lang.Object Evaluate(float fraction, Java.Lang.Object startValue, Java.Lang.Object endValue) =>
            Evaluate(fraction, (Java.Lang.Integer)startValue, (Java.Lang.Integer)endValue);
    }

    public partial class MatrixEvaluator
    {
        public Java.Lang.Object Evaluate(float fraction, Java.Lang.Object startValue, Java.Lang.Object endValue) =>
            Evaluate(fraction, (Matrix)startValue, (Matrix)endValue);
    }
}

namespace Google.Android.Material.AppBar
{
    public partial class CollapsingToolbarLayout
    {
        public override ViewStates Visibility
        {
            get => base.Visibility;
            set => base.Visibility = value;
        }

        public void SetTitle(string title) =>
            Title = title;

        public void SetVisibility(ViewStates visibility) =>
            Visibility = visibility;
    }
}

namespace Google.Android.Material.BottomNavigation
{
    public partial class BottomNavigationItemView
    {
        public void SetEnabled(bool enabled) =>
            Enabled = enabled;
    }
}

namespace Google.Android.Material.CircularReveal
{
    public partial class CircularRevealWidgetCircularRevealEvaluator
    {
        public Java.Lang.Object Evaluate(float fraction, Java.Lang.Object startValue, Java.Lang.Object endValue) =>
            Evaluate(fraction, (CircularRevealWidgetRevealInfo)startValue, (CircularRevealWidgetRevealInfo)endValue);
    }

    public partial class CircularRevealWidgetCircularRevealProperty
    {
        public override Java.Lang.Object Get(Java.Lang.Object @object) =>
            Get((ICircularRevealWidget)@object);
        public override void Set(Java.Lang.Object @object, Java.Lang.Object value) =>
            Set((ICircularRevealWidget)@object, (CircularRevealWidgetRevealInfo)value);
    }

    public partial class CircularRevealWidgetCircularRevealScrimColorProperty
    {
        public override Java.Lang.Object Get(Java.Lang.Object @object) =>
            Get((ICircularRevealWidget)@object);
        public override void Set(Java.Lang.Object @object, Java.Lang.Object value) =>
            Set((ICircularRevealWidget)@object, (Java.Lang.Integer)value);
    }
}

namespace Google.Android.Material.Internal
{
    public partial class NavigationMenuItemView
    {
        public void SetEnabled(bool enabled) =>
            Enabled = enabled;
    }

    public partial class VisibilityAwareImageButton
    {
        public override ViewStates Visibility
        {
            get => base.Visibility;
            set => base.Visibility = value;
        }

        public void SetVisibility(ViewStates visibility) =>
            Visibility = visibility;
    }
}

namespace Google.Android.Material.Snackbar
{
    public partial class Snackbar
    {
        public Snackbar SetAction(string text, Action<View> clickHandler) =>
            SetAction(text, new SnackbarActionClickImplementor(clickHandler));

        public Snackbar SetAction(Java.Lang.ICharSequence text, Action<View> clickHandler) =>
            SetAction(text, new SnackbarActionClickImplementor(clickHandler));

        public Snackbar SetAction(int resId, Action<View> clickHandler) =>
            SetAction(resId, new SnackbarActionClickImplementor(clickHandler));

        internal class SnackbarActionClickImplementor : Java.Lang.Object, View.IOnClickListener
        {
            private Action<View> handler;

            public SnackbarActionClickImplementor(Action<View> handler) =>
                this.handler = handler;

            public void OnClick(View v) =>
                handler?.Invoke(v);
        }
    }
}

namespace Google.Android.Material.Tabs
{
    public partial class TabLayout
    {
        public partial class TabView
        {
            public override bool Selected
            {
                get => base.Selected;
                set => base.Selected = value;
            }

            public void SetSelected(bool selected) =>
                Selected = selected;
        }
    }
}

namespace Google.Android.Material.TextField
{
    public partial class TextInputLayout
    {
        public override bool Enabled
        {
            get => base.Enabled;
            set => base.Enabled = value;
        }

        public void SetEnabled(bool enabled) =>
            Enabled = enabled;
    }
}

namespace Google.Android.Material.Slider
{
    delegate void _JniMarshal_PPZ_V(IntPtr jnienv, IntPtr klass, bool p0);

    public partial class Slider
    {

        static Delegate cb_setEnabled_Z;
#pragma warning disable 0169
        static Delegate GetSetEnabled_ZHandler()
        {
            if (cb_setEnabled_Z == null)
                cb_setEnabled_Z = JNINativeWrapper.CreateDelegate((_JniMarshal_PPZ_V)n_SetEnabled_Z);
            return cb_setEnabled_Z;
        }

        static void n_SetEnabled_Z(IntPtr jnienv, IntPtr native__this, bool p0)
        {
            var __this = global::Java.Lang.Object.GetObject<global::Google.Android.Material.Slider.Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            __this.SetEnabled(p0);
        }
#pragma warning restore 0169

        // Metadata.xml XPath method reference: path="/api/package[@name='com.google.android.material.slider']/class[@name='Slider']/method[@name='setEnabled' and count(parameter)=1 and parameter[1][@type='boolean']]"
        [Register("setEnabled", "(Z)V", "GetSetEnabled_ZHandler")]
        public unsafe void SetEnabled(bool p0)
        {
            const string __id = "setEnabled.(Z)V";
            try
            {
                JniArgumentValue* __args = stackalloc JniArgumentValue[1];
                __args[0] = new JniArgumentValue(p0);
                _members.InstanceMethods.InvokeVirtualVoidMethod(__id, this, __args);
            }
            finally
            {
            }
        }

        public override bool Enabled
        {
            get { return base.Enabled; }
            set { SetEnabled(value); }
        }
    }

    public partial class RangeSlider
    {
        static Delegate cb_setEnabled_Z;
#pragma warning disable 0169
        static Delegate GetSetEnabled_ZHandler()
        {
            if (cb_setEnabled_Z == null)
                cb_setEnabled_Z = JNINativeWrapper.CreateDelegate((_JniMarshal_PPZ_V)n_SetEnabled_Z);
            return cb_setEnabled_Z;
        }

        static void n_SetEnabled_Z(IntPtr jnienv, IntPtr native__this, bool p0)
        {
            var __this = global::Java.Lang.Object.GetObject<global::Google.Android.Material.Slider.RangeSlider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            __this.SetEnabled(p0);
        }
#pragma warning restore 0169

        // Metadata.xml XPath method reference: path="/api/package[@name='com.google.android.material.slider']/class[@name='RangeSlider']/method[@name='setEnabled' and count(parameter)=1 and parameter[1][@type='boolean']]"
        [Register("setEnabled", "(Z)V", "GetSetEnabled_ZHandler")]
        public unsafe void SetEnabled(bool p0)
        {
            const string __id = "setEnabled.(Z)V";
            try
            {
                JniArgumentValue* __args = stackalloc JniArgumentValue[1];
                __args[0] = new JniArgumentValue(p0);
                _members.InstanceMethods.InvokeVirtualVoidMethod(__id, this, __args);
            }
            finally
            {
            }
        }

        public override bool Enabled
        {
            get { return base.Enabled; }
            set { SetEnabled(value); }
        }
    }
}


namespace Google.Android.Material.Snackbar
{
    public partial class Snackbar //: global::Google.Android.Material.Snackbar.BaseTransientBottomBar
    {
        public sealed partial class SnackbarLayout
        {
            // Metadata.xml XPath method reference: path="/api/package[@name='com.google.android.material.snackbar']/class[@name='Snackbar.SnackbarLayout']/method[@name='setBackground' and count(parameter)=1 and parameter[1][@type='android.graphics.drawable.Drawable']]"
            [Register("setBackground", "(Landroid/graphics/drawable/Drawable;)V", "")]
            public unsafe void SetBackground(global::Android.Graphics.Drawables.Drawable this_)
            {
                const string __id = "setBackground.(Landroid/graphics/drawable/Drawable;)V";
                try
                {
                    JniArgumentValue* __args = stackalloc JniArgumentValue[1];
                    __args[0] = new JniArgumentValue((this_ == null) ? IntPtr.Zero : ((global::Java.Lang.Object)this_).Handle);
                    _members.InstanceMethods.InvokeAbstractVoidMethod(__id, this, __args);
                }
                finally
                {
                }
            }

            public global::Android.Graphics.Drawables.Drawable Background
            {
                get { return base.Background; }
                set { SetBackground(value); }
            }
        }
    }
}


namespace Google.Android.Material.Snackbar
{
    public partial class Snackbar //: global::Google.Android.Material.Snackbar.BaseTransientBottomBar
    {
        public sealed partial class SnackbarLayout
        {
            // Metadata.xml XPath method reference: path="/api/package[@name='com.google.android.material.snackbar']/class[@name='Snackbar.SnackbarLayout']/method[@name='setBackgroundTintList' and count(parameter)=1 and parameter[1][@type='android.content.res.ColorStateList']]"
            [Register("setBackgroundTintList", "(Landroid/content/res/ColorStateList;)V", "")]
            public unsafe void SetBackgroundTintList(global::Android.Content.Res.ColorStateList this_)
            {
                const string __id = "setBackgroundTintList.(Landroid/content/res/ColorStateList;)V";
                try
                {
                    JniArgumentValue* __args = stackalloc JniArgumentValue[1];
                    __args[0] = new JniArgumentValue((this_ == null) ? IntPtr.Zero : ((global::Java.Lang.Object)this_).Handle);
                    _members.InstanceMethods.InvokeAbstractVoidMethod(__id, this, __args);
                }
                finally
                {
                }
            }

            public global::Android.Content.Res.ColorStateList BackgroundTintList
            {
                get { return base.BackgroundTintList; }
                set { SetBackgroundTintList(value); }
            }
        }
    }
}

namespace Google.Android.Material.Snackbar
{
    public partial class Snackbar //: global::Google.Android.Material.Snackbar.BaseTransientBottomBar
    {
        public sealed partial class SnackbarLayout
        {
            // Metadata.xml XPath method reference: path="/api/package[@name='com.google.android.material.snackbar']/class[@name='Snackbar.SnackbarLayout']/method[@name='setBackgroundTintMode' and count(parameter)=1 and parameter[1][@type='android.graphics.PorterDuff.Mode']]"
            [Register("setBackgroundTintMode", "(Landroid/graphics/PorterDuff$Mode;)V", "")]
            public unsafe void SetBackgroundTintMode(global::Android.Graphics.PorterDuff.Mode this_)
            {
                const string __id = "setBackgroundTintMode.(Landroid/graphics/PorterDuff$Mode;)V";
                try
                {
                    JniArgumentValue* __args = stackalloc JniArgumentValue[1];
                    __args[0] = new JniArgumentValue((this_ == null) ? IntPtr.Zero : ((global::Java.Lang.Object)this_).Handle);
                    _members.InstanceMethods.InvokeAbstractVoidMethod(__id, this, __args);
                }
                finally
                {
                }
            }

            public global::Android.Graphics.PorterDuff.Mode BackgroundTintMode
            {
                get { return base.BackgroundTintMode; }
                set { SetBackgroundTintMode(value); }
            }
        }
    }
}

namespace Google.Android.Material.TextField
{
    public partial class MaterialAutoCompleteTextView
    {
        // Metadata.xml XPath method reference: path="/api/package[@name='com.google.android.material.textfield']/class[@name='MaterialAutoCompleteTextView']/method[@name='setAdapter' and count(parameter)=1 and parameter[1][@type='T']]"
        [Register("setAdapter", "(Landroid/widget/ListAdapter;)V", "GetSetAdapter_Landroid_widget_ListAdapter_Handler")]
        [global::Java.Interop.JavaTypeParameters(new string[] { "T extends android.widget.ListAdapter & android.widget.Filterable" })]
        public unsafe void SetAdapter(global::Android.Widget.IListAdapter adapter)
        {
            const string __id = "setAdapter.(Landroid/widget/ListAdapter;)V";
            IntPtr native_adapter = JNIEnv.ToLocalJniHandle(adapter);
            try
            {
                JniArgumentValue* __args = stackalloc JniArgumentValue[1];
                __args[0] = new JniArgumentValue(native_adapter);
                _members.InstanceMethods.InvokeVirtualVoidMethod(__id, this, __args);
            }
            finally
            {
                JNIEnv.DeleteLocalRef(native_adapter);
            }
        }

        public global::Android.Widget.IListAdapter Adapter
        {
            get { return base.Adapter; }
            set { SetAdapter(value); }
        }

    }
}