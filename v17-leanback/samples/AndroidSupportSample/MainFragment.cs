using System;
using System.Linq;
using Android.Support.V17.Leanback.App;
using Android.Content;
using Android.Support.V17.Leanback.Widget;
using Java.Lang;
using Java.Interop;

namespace AndroidLeanbackSample
{
    public class MainFragment : BrowseFragment
    {
        public override void OnActivityCreated (Android.OS.Bundle savedInstanceState)
        {
            base.OnActivityCreated (savedInstanceState);

            buildAdapter ();


            this.ItemViewClicked += (sender, e) => {
                var video = (Video)e.Item;

                var intent = new Intent (Intent.ActionView, Android.Net.Uri.Parse ("http://www.youtube.com/watch?v=" + video.Id));
                StartActivity (intent);
            };

            this.ItemViewSelected += (sender, e) => {
                if (e.Item == null)
                    return;

                var video = (Video)e.Item;

                Console.WriteLine ("Selected: " + video.Title);
            };

            HeadersState = BrowseFragment.HeadersEnabled;
            Title = "Xamarin Webinars";
            BadgeDrawable = Resources.GetDrawable (Resource.Drawable.icon);
            HeadersTransitionOnBackEnabled = true;
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
