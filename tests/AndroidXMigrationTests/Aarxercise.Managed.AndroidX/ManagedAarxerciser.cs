using Android.Content;
using Android.Support.V4.Media.Session;
using Android.Widget;
using AndroidX.Fragment.App;

namespace ManagedAarxercise
{
	public class ManagedAarxerciser
	{
		public Fragment CreateFragment(Context context)
		{
			ManagedSimpleFragment fragment = new ManagedSimpleFragment();
			return fragment;
		}

		public ManagedSimpleFragment CreateSimpleFragment(Context context)
		{
			ManagedSimpleFragment fragment = new ManagedSimpleFragment();
			return fragment;
		}

		public void UpdateSimpleFragment(ManagedSimpleFragment fragment, string text)
		{
			((TextView)fragment.View.FindViewById(Resource.Id.managedSimpleFragmentTextView)).Text = text;
		}

		public void UpdateFragment(Fragment fragment, string text)
		{
			((TextView)fragment.View.FindViewById(Resource.Id.managedSimpleFragmentTextView)).Text = text;
		}

		public MediaSessionCompat GetNullSession()
		{
			return null;
		}
	}
}
