using System;
using Android.Runtime;

namespace Android.Support.V7.Widget
{
	public partial class ActionMenuView
	{
		static IntPtr id_setPresenter_ActionMenuPresenter;
		[Register("setPresenter", "(Landroid/support/v7/widget/ActionMenuPresenter;)V", "GetSetPresenter_Landroid_support_v7_widget_ActionMenuPresenter")]
		public unsafe void SetPresenter(global::Android.Support.V7.Widget.ActionMenuPresenter presenter)
		{
			if (id_setPresenter_ActionMenuPresenter == IntPtr.Zero)
				id_setPresenter_ActionMenuPresenter = JNIEnv.GetMethodID(class_ref, "setPresenter", "(Landroid/support/v7/widget/ActionMenuPresenter;)V");
			try
			{
				JValue* __args = stackalloc JValue[1];
				__args[0] = new JValue(presenter);

				if (GetType() == ThresholdType)
					JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_setPresenter_ActionMenuPresenter, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setPresenter", "(Landroid/support/v7/widget/ActionMenuPresenter;)V"), __args);
			}
			finally
			{
			}
		}
	}
}
