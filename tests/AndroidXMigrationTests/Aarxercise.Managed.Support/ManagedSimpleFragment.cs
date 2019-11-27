using Android.OS;
using Android.Support.V4.App;
using Android.Views;

namespace ManagedAarxercise
{
	public class ManagedSimpleFragment : Fragment
	{
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			return inflater.Inflate(Resource.Layout.managedsimplefragment, container, false);
		}
	}
}
