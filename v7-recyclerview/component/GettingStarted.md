The RecyclerView widget is a more advanced and flexible version of ListView. This widget is a container for displaying large data sets that can be scrolled very efficiently by maintaining a limited number of views. Use the RecyclerView widget when you have data collections whose elements change at runtime based on user action or network events.

The RecyclerView class simplifies the display and handling of large data sets by providing:

 - Layout managers for positioning items
 - Default animations for common item operations, such as removal or addition of items

You also have the flexibility to define custom layout managers and animations for RecyclerView widgets.


### Target SDK Version 
NOTE: Using this support library requires that your app have its Target Android Version (*targetSdkVersion*) set to Lollipop (5.0 - API Level 21) or higher, or you will have *aapt* related compile errors.  You can still set the Target Framework which your app is compiled against as low as Android 4.0.3 (API Level 15).


Using RecyclerView
------------------

The RecyclerView, like the ListView requires you to create an adapter.  You can subclass `RecyclerView.Adapter`:

```csharp
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
```

The `ViewHolder` pattern is used to hold references to controls in a layout to avoid the more expensive operation of finding views by id over and over.  Here is an example of a custom `ViewHolder` used in the adapter above:

```csharp
public class MyViewHolder : RecyclerView.ViewHolder 
{
	public TextView TextView { get; set; }


	public MyViewHolder (TextView v) : base (v)
	{
		TextView = v;
	}
}
```

Finally, you need to setup your adapter and `RecyclerView`:

```csharp
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
```

To learn more about the RecyclerView, visit the [Official RecyclerView documentation](https://developer.android.com/training/material/lists-cards.html).
