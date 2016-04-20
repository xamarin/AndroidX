using System;
using Android.Support.V17.Leanback.Widget;
using Android.Widget;
using Android.Views;

namespace AndroidLeanbackSample
{
    public class VideoPresenter : Presenter 
    {
        public override void OnBindViewHolder (ViewHolder viewHolder, Java.Lang.Object item)
        {
            var v = (Video)item;
            var textView = (TextView)viewHolder.View;
            textView.Text = v.Title;
        }

        public override ViewHolder OnCreateViewHolder (ViewGroup parent)
        {
            var textView = new TextView(parent.Context);
            textView.SetWidth (200);
            textView.Focusable = true;
            textView.FocusableInTouchMode = true;
            textView.Text = "";
            return new ViewHolder(textView);
        }

        public override void OnUnbindViewHolder (ViewHolder p0)
        {
            // No op
        }
    }
}

