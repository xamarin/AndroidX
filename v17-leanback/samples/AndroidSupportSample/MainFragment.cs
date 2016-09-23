using System;
using System.Linq;
using Android.Support.V17.Leanback.App;
using Android.Content;
using Android.Support.V17.Leanback.Widget;
using Java.Lang;

namespace AndroidLeanbackSample
{
    public class MainFragment : BrowseFragment
    {
        public override void OnActivityCreated (Android.OS.Bundle savedInstanceState)
        {
            base.OnActivityCreated (savedInstanceState);

            buildAdapter ();

            //base.OnItemViewClickedListener = this;

            HeadersState = BrowseFragment.HeadersEnabled;
            Title = "Xamarin Webinars";
            BadgeDrawable = Resources.GetDrawable (Resource.Drawable.icon);
            HeadersTransitionOnBackEnabled = true;
        }


        public void OnItemClicked (Presenter.ViewHolder itemViewHolder, Java.Lang.Object item, RowPresenter.ViewHolder rowViewHolder, Row row)
        {
            var video = (Video)item;

            var intent = new Intent (Intent.ActionView, Android.Net.Uri.Parse ("http://www.youtube.com/watch?v=" + video.Id));
            StartActivity (intent);
        }

        void buildAdapter() 
        {
            var adapter = new ArrayObjectAdapter (new ListRowPresenter ());

            var videos = Video.GetVideos (this.Activity);

            var categories = from m in videos
                select m.Categories;

            foreach (var c in categories.Distinct ()) {
                var categoryVideos = videos.Where (m => m.Categories == c);

                var categoryAdapter = new ArrayObjectAdapter (new VideoPresenter ());

                foreach (var v in categoryVideos)
                    categoryAdapter.Add (v);

                var header = new HeaderItem (c.ToLowerInvariant ());
                adapter.Add (new ListRow (header, categoryAdapter));
            }

            Adapter = adapter;
        }
    }
}
