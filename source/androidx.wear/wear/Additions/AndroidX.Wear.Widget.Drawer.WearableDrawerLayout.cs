namespace AndroidX.Wear.Widget.Drawer 
{

	// Metadata.xml XPath class reference: path="/api/package[@name='androidx.wear.widget.drawer']/class[@name='WearableDrawerLayout']"
	// [global::Android.Runtime.Register ("androidx/wear/widget/drawer/WearableDrawerLayout", DoNotGenerateAcw=true)]
	public partial class WearableDrawerLayout 
    {
        public void OnNestedScrollAccepted(Android.Views.View child, Android.Views.View target, int axes)
		{
			Android.Views.ScrollAxis scroll_axes = (Android.Views.ScrollAxis) axes;

			OnStartNestedScroll(child, target, scroll_axes);

			return;
		}

		public virtual bool OnStartNestedScroll (Android.Views.View child, Android.Views.View target, int axes)
		{
			Android.Views.ScrollAxis scroll_axes = (Android.Views.ScrollAxis) axes;

			return OnStartNestedScroll(child, target, scroll_axes);
		}
    }
}