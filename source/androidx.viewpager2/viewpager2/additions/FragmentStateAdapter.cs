using Android.Runtime;
using Java.Interop;

namespace AndroidX.ViewPager2.Adapter
{
	// Metadata.xml XPath class reference: path="/api/package[@name='androidx.viewpager2.adapter']/class[@name='FragmentStateAdapter']"
	//[global::Android.Runtime.Register ("androidx/viewpager2/adapter/FragmentStateAdapter", DoNotGenerateAcw=true)]
	public abstract partial class FragmentStateAdapter //: global::AndroidX.RecyclerView.Widget.RecyclerView.Adapter, global::AndroidX.ViewPager2.Adapter.IStatefulAdapter 
    {
        public bool HasStableIds
        {
            get
            {
                return base.HasStableIds;
            }
            set
            {
                this.SetHasStableIds(value);
                //base.HasStableIds = value;
            }
        }


		// Metadata.xml XPath method reference: path="/api/package[@name='androidx.viewpager2.adapter']/class[@name='FragmentStateAdapter']/method[@name='setHasStableIds' and count(parameter)=1 and parameter[1][@type='boolean']]"
		[Register("setHasStableIds", "(Z)V", "")]
		public unsafe void SetHasStableIds(bool hasStableIds)
		{
			const string __id = "setHasStableIds.(Z)V";
			try
			{
				JniArgumentValue* __args = stackalloc JniArgumentValue[1];
				__args[0] = new JniArgumentValue(hasStableIds);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod(__id, this, __args);
			}
			finally
			{
			}
		}

	}
}