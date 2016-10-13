using System;

namespace Android.Support.V7.App
{
    public partial class AlertDialog
    {
        public partial class Builder
        {
            public AlertDialog.Builder SetAdapter (Android.Widget.IListAdapter adapter, EventHandler<Android.Content.DialogClickEventArgs> handler)
            {
                return SetAdapter (adapter, new IDialogInterfaceOnClickListenerImplementor () { Handler = handler });
            }

            public AlertDialog.Builder SetCursor (Android.Database.ICursor cursor, EventHandler<Android.Content.DialogClickEventArgs> handler, string labelColumn)
            {
                return SetCursor (cursor, new IDialogInterfaceOnClickListenerImplementor () { Handler = handler }, labelColumn);
            }

            public AlertDialog.Builder SetItems (int itemsId, EventHandler<Android.Content.DialogClickEventArgs> handler)
            {
                return SetItems (itemsId, new IDialogInterfaceOnClickListenerImplementor () { Handler = handler });
            }

            public AlertDialog.Builder SetItems (Java.Lang.ICharSequence[] items, EventHandler<Android.Content.DialogClickEventArgs> handler)
            {
                return SetItems (items, new IDialogInterfaceOnClickListenerImplementor () { Handler = handler });
            }

            public AlertDialog.Builder SetItems (string[] items, EventHandler<Android.Content.DialogClickEventArgs> handler)
            {
                return SetItems (items, new IDialogInterfaceOnClickListenerImplementor () { Handler = handler });
            }

            public AlertDialog.Builder SetMultiChoiceItems (int itemsId, bool[] checkedItems, EventHandler<Android.Content.DialogMultiChoiceClickEventArgs> handler)
            {
                return SetMultiChoiceItems (itemsId, checkedItems, new IDialogInterfaceOnMultiChoiceClickListenerImplementor () { Handler = handler });
            }

            public AlertDialog.Builder SetMultiChoiceItems (Java.Lang.ICharSequence[] items, bool[] checkedItems, EventHandler<Android.Content.DialogMultiChoiceClickEventArgs> handler)
            {
                return SetMultiChoiceItems (items, checkedItems, new IDialogInterfaceOnMultiChoiceClickListenerImplementor () { Handler = handler });
            }

            public AlertDialog.Builder SetMultiChoiceItems (string[] items, bool[] checkedItems, EventHandler<Android.Content.DialogMultiChoiceClickEventArgs> handler)
            {
                return SetMultiChoiceItems (items, checkedItems, new IDialogInterfaceOnMultiChoiceClickListenerImplementor () { Handler = handler });
            }

            public AlertDialog.Builder SetMultiChoiceItems (Android.Database.ICursor cursor, string isCheckedColumn, string labelColumn, EventHandler<Android.Content.DialogMultiChoiceClickEventArgs> handler)
            {
                return SetMultiChoiceItems (cursor, isCheckedColumn, labelColumn, new IDialogInterfaceOnMultiChoiceClickListenerImplementor () { Handler = handler });
            }

            public AlertDialog.Builder SetNegativeButton (int textId, EventHandler<Android.Content.DialogClickEventArgs> handler)
            {
                return SetNegativeButton (textId, new IDialogInterfaceOnClickListenerImplementor () { Handler = handler });
            }

            public AlertDialog.Builder SetNegativeButton (Java.Lang.ICharSequence text, EventHandler<Android.Content.DialogClickEventArgs> handler)
            {
                return SetNegativeButton (text, new IDialogInterfaceOnClickListenerImplementor () { Handler = handler } );
            }

            public AlertDialog.Builder SetNegativeButton (string text, EventHandler<Android.Content.DialogClickEventArgs> handler)
            {
                return SetNegativeButton (text, new IDialogInterfaceOnClickListenerImplementor () { Handler = handler });
            }

            public AlertDialog.Builder SetNeutralButton (int textId, EventHandler<Android.Content.DialogClickEventArgs> handler)
            {
                return SetNeutralButton (textId, new IDialogInterfaceOnClickListenerImplementor () { Handler = handler });
            }

            public AlertDialog.Builder SetNeutralButton (Java.Lang.ICharSequence text, EventHandler<Android.Content.DialogClickEventArgs> handler)
            {
                return SetNeutralButton (text, new IDialogInterfaceOnClickListenerImplementor () { Handler = handler });
            }

            public AlertDialog.Builder SetNeutralButton (string text, EventHandler<Android.Content.DialogClickEventArgs> handler)
            {
                return SetNeutralButton (text, new IDialogInterfaceOnClickListenerImplementor () { Handler = handler });
            }

            public AlertDialog.Builder SetPositiveButton (int textId, EventHandler<Android.Content.DialogClickEventArgs> handler)
            {
                return SetPositiveButton (textId, new IDialogInterfaceOnClickListenerImplementor () { Handler = handler });
            }

            public AlertDialog.Builder SetPositiveButton (Java.Lang.ICharSequence text, EventHandler<Android.Content.DialogClickEventArgs> handler)
            {
                return SetPositiveButton (text, new IDialogInterfaceOnClickListenerImplementor () { Handler = handler });
            }

            public AlertDialog.Builder SetPositiveButton (string text, EventHandler<Android.Content.DialogClickEventArgs> handler)
            {
                return SetPositiveButton (text, new IDialogInterfaceOnClickListenerImplementor () { Handler = handler });
            }

            public AlertDialog.Builder SetSingleChoiceItems (int itemsId, int checkedItem, EventHandler<Android.Content.DialogClickEventArgs> handler)
            {
                return SetSingleChoiceItems (itemsId, checkedItem, new IDialogInterfaceOnClickListenerImplementor () { Handler = handler });
            }

            public AlertDialog.Builder SetSingleChoiceItems (Android.Database.ICursor cursor, int checkedItem, string labelColumn, EventHandler<Android.Content.DialogClickEventArgs> handler)
            {
                return SetSingleChoiceItems (cursor, checkedItem, labelColumn, new IDialogInterfaceOnClickListenerImplementor () { Handler = handler });
            }

            public AlertDialog.Builder SetSingleChoiceItems (Java.Lang.ICharSequence[] items, int checkedItem, EventHandler<Android.Content.DialogClickEventArgs> handler)
            {
                return SetSingleChoiceItems (items, checkedItem, new IDialogInterfaceOnClickListenerImplementor () { Handler = handler });
            }

            public AlertDialog.Builder SetSingleChoiceItems (string[] items, int checkedItem, EventHandler<Android.Content.DialogClickEventArgs> handler)
            {
                return SetSingleChoiceItems (items, checkedItem, new IDialogInterfaceOnClickListenerImplementor () { Handler = handler });
            }

            public AlertDialog.Builder SetSingleChoiceItems (Android.Widget.IListAdapter adapter, int checkedItem, EventHandler<Android.Content.DialogClickEventArgs> handler)
            {
                return SetSingleChoiceItems (adapter, checkedItem, new IDialogInterfaceOnClickListenerImplementor () { Handler = handler });
            }

        }



        protected AlertDialog (Android.Content.Context context, bool cancelable, EventHandler cancelHandler) 
            : this (context, cancelable, new IDialogInterfaceOnCancelListenerImplementor () { Handler = cancelHandler }) {}

        public void SetButton (int whichButton, Java.Lang.ICharSequence text, EventHandler<Android.Content.DialogClickEventArgs> handler)
        {
            SetButton (whichButton, text, new IDialogInterfaceOnClickListenerImplementor () { Handler = handler });
        }

        public void SetButton (int whichButton, string text, EventHandler<Android.Content.DialogClickEventArgs> handler)
        {
            SetButton (whichButton, text, new IDialogInterfaceOnClickListenerImplementor () { Handler = handler });
        }

        class IDialogInterfaceOnClickListenerImplementor : Java.Lang.Object, Android.Content.IDialogInterfaceOnClickListener 
        {
            public EventHandler<Android.Content.DialogClickEventArgs> Handler { get; set; }

            #region IDialogInterfaceOnClickListener implementation
            public void OnClick (Android.Content.IDialogInterface dialog, int which)
            {
                var h = Handler;

                if (h != null)
                    h (dialog, new Android.Content.DialogClickEventArgs (which));
            }
            #endregion
        }

        class IDialogInterfaceOnCancelListenerImplementor : Java.Lang.Object, Android.Content.IDialogInterfaceOnCancelListener
        {
            public EventHandler Handler { get;set; }

            public void OnCancel (Android.Content.IDialogInterface dialog)
            {
                var h = Handler;

                if (h != null)
                    h (dialog, new EventArgs ());
            }
        }

        class IDialogInterfaceOnMultiChoiceClickListenerImplementor : Java.Lang.Object, Android.Content.IDialogInterfaceOnMultiChoiceClickListener
        {
            public EventHandler<Android.Content.DialogMultiChoiceClickEventArgs> Handler { get; set; }

            public void OnClick (Android.Content.IDialogInterface dialog, int which, bool isChecked)
            {
                var h = Handler;

                if (h != null)
                    h (dialog, new Android.Content.DialogMultiChoiceClickEventArgs (which, isChecked));
            }
        }
    }
}

