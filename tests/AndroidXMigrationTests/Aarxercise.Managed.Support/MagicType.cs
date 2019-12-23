using Android.Support.V4.App;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;

namespace ManagedAarxercise
{
	public class MagicType<T> : AppCompatActivity
		where T : Space
	{
		private Fragment theFrag;
		private View theView;

		public NotificationCompat Notifications { get; set; }

		public void CompleXBody()
		{
			var referencedType = new AppCompatActivity();

			var somethingNew = new Android.Support.V7.Widget.Toolbar(this);

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
