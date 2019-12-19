using Android.Content;
using Android.Util;
using AndroidX.Core.Content;
using AndroidX.Legacy.Widget;
using AndroidX.ViewPager.Widget;

namespace OldAarxercise
{
	public class Supportv4Split : ViewPager
	{
		public Supportv4Split(Context context, IAttributeSet attrs)
			: base(context, attrs)
		{
			Color = ContextCompat.GetColor(context, Android.Resource.Color.Black);
			SpaceWidget = new Space(context);
			Provider = new FileProvider();
		}

		public int Color { get; }

		public Space SpaceWidget { get; }

		public FileProvider Provider { get; }
	}
}
