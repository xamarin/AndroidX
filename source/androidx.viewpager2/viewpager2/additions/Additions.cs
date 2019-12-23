using System;
namespace Androidx.Viewpager2.Adapter {
    partial class FragmentStateAdapter
    {
        public override unsafe global::AndroidX.RecyclerView.Widget.RecyclerView.ViewHolder OnCreateViewHolder(global::Android.Views.ViewGroup parent, int viewType)
        {
            return OnCreateFragmentViewHolder(parent, viewType);
        }
    }
}
