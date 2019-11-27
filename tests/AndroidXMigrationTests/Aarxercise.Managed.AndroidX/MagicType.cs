using Android.Views;
using AndroidX.AppCompat.App;
using AndroidX.Core.App;
using AndroidX.Fragment.App;
using AndroidX.Legacy.Widget;

namespace ManagedAarxercise
{
	public class MagicType<T> : AppCompatActivity
		where T : AndroidX.Legacy.Widget.Space
	{
		private Fragment theFrag;
		private View theView;

		public NotificationCompat Notifications { get; set; }

		public void CompleXBody()
		{
			var referencedType = new AppCompatActivity();

			var somethingNew = new AndroidX.AppCompat.Widget.Toolbar(this);

			referencedType.SetSupportActionBar(somethingNew);
		}

		public Fragment GetThing(AppCompatActivity activity, T fragment)
		{
			return new Fragment();
		}

		public R GetThing<R>(AppCompatActivity activity, T fragment)
			where R : AppCompatDialog, new()
		{
			return new R();
		}

		public class NestedClass : AppCompatActivity
		{
		}
	}
}
