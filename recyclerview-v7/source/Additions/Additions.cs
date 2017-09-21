using System;
namespace Android.Support.V7.Widget
                 //.RecyclerView.RequestDisallowInterceptTouchEventEventArgs
{
	public partial class RecyclerView
	{
		public partial class InterceptTouchEventEventArgs
		{
			public RecyclerView RecyclerView {
				get { return this.Rv;  }
			}
		}

		public partial class RequestDisallowInterceptTouchEventEventArgs
		{
			public bool Disallow
			{
				get { return this.DisallowIntercept; }
			}
		}

		public partial class TouchEventEventArgs
		{
			public RecyclerView RecyclerView
			{
				get { return this.Rv; }
			}
		}
	}
}
