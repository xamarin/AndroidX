using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Android.Support.V7.Widget;

namespace AndroidSupportSample
{
	[Activity (Label = "AndroidSupportSample", MainLauncher = true)]
	public class MainActivity : Activity
	{
        RecyclerView recyclerView;
        RecyclerView.Adapter adapter;
        RecyclerView.LayoutManager layoutManager;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			recyclerView = FindViewById<RecyclerView> (Resource.Id.my_recycler_view);

			// improve performance if you know that changes in content
			// do not change the size of the RecyclerView
			recyclerView.HasFixedSize = true;

			// use a linear layout manager
			layoutManager = new LinearLayoutManager (this);
			recyclerView.SetLayoutManager (layoutManager);

			// specify an adapter
			adapter = new MyAdapter (new [] { "Brasil", "Mexico", "United States", "Canada" });
			
            recyclerView.SetAdapter (adapter);
		}
	}

	public class MyAdapter : RecyclerView.Adapter
	{
        string [] items;

		public MyAdapter (string [] data)
		{
			items = data;
		}

		// Create new views (invoked by the layout manager)
		public override RecyclerView.ViewHolder OnCreateViewHolder (ViewGroup parent, int viewType)
		{	
            // set the view's size, margins, paddings and layout parameters
			var tv = new TextView (parent.Context);
			tv.SetWidth (200);
			tv.Text = "";

			var vh = new MyViewHolder (tv);
			return vh;
		} 

		// Replace the contents of a view (invoked by the layout manager)
		public override void OnBindViewHolder (RecyclerView.ViewHolder viewHolder, int position)
		{
            var item = items [position];

			// Replace the contents of the view with that element
			var holder = viewHolder as MyViewHolder;
			holder.TextView.Text = items[position];
		}

		public override int ItemCount {
			get {
				return items.Length;
			}
		}
	}

	public class MyViewHolder : RecyclerView.ViewHolder 
	{
		public TextView TextView { get; set; }

		public MyViewHolder (TextView v) : base (v)
		{
			TextView = v;
		}
	}
}


