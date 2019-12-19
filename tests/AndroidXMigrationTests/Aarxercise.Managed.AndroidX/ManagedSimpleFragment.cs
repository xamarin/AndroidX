using Android.OS;
using Android.Views;
using AndroidX.Fragment.App;

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
