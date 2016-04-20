using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Content;
using Android.Support.V7.Widget;


namespace AndroidSupportSample
{
	[Activity (Label = "@string/grid_layout_3")]			
	public class GridLayout3 : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView(Create(this));
		}

		static View Create(Context context)
		{
			GridLayout p = new GridLayout(context);
			p.UseDefaultMargins = true;
			p.AlignmentMode = GridLayout.AlignBounds;
			var configuration = context.Resources.Configuration;
			if ((configuration.Orientation == Android.Content.Res.Orientation.Portrait)) {
				p.ColumnOrderPreserved = false;
			} else {
				p.RowOrderPreserved = false;
			}

			var titleRow = GridLayout.InvokeSpec (0);
			var introRow = GridLayout.InvokeSpec (1);
			var emailRow = GridLayout.InvokeSpec (2, GridLayout.BaselineAlignment);
			var passwordRow = GridLayout.InvokeSpec (3, GridLayout.BaselineAlignment);
			var button1Row = GridLayout.InvokeSpec (5);
			var button2Row = GridLayout.InvokeSpec (6);



			var centerInAllColumns = GridLayout.InvokeSpec (0, 4, GridLayout.CenterAlignment);
			var leftAlignInAllColumns = GridLayout.InvokeSpec (0, 4, GridLayout.LeftAlignment);
			var labelColumn = GridLayout.InvokeSpec (0, GridLayout.RightAlignment);
			var fieldColumn = GridLayout.InvokeSpec (1, GridLayout.LeftAlignment);
			var defineLastColumn = GridLayout.InvokeSpec (3);
			var fillLastColumn = GridLayout.InvokeSpec (3, GridLayout.FillAlignment);

			{
				var c = new Android.Widget.TextView(context);
				c.TextSize = 32;
				c.Text = "Email setup";
				p.AddView(c, new Android.Support.V7.Widget.GridLayout.LayoutParams(titleRow, centerInAllColumns));
			}

			{
				var c = new Android.Widget.TextView(context);
				c.TextSize = 16;
				c.Text  = "You can configure email in a few simple steps:";
				p.AddView(c, new Android.Support.V7.Widget.GridLayout.LayoutParams(introRow, leftAlignInAllColumns));
			}
			{
				var c = new Android.Widget.TextView(context);
				c.Text = "Email address:";
				p.AddView(c, new Android.Support.V7.Widget.GridLayout.LayoutParams(emailRow, labelColumn));
			}
			{
				var c = new Android.Widget.EditText(context);
				c.SetEms (10);
				c.InputType = Android.Text.InputTypes.ClassText | Android.Text.InputTypes.TextVariationEmailAddress;
				p.AddView(c, new Android.Support.V7.Widget.GridLayout.LayoutParams(emailRow, fieldColumn));
			}
			{
				var c = new Android.Widget.TextView(context);
				c.Text = "Password:";
				p.AddView(c, new Android.Support.V7.Widget.GridLayout.LayoutParams(passwordRow, labelColumn));
			}
			{
				var c = new Android.Widget.EditText(context);
				c.SetEms (8);
				c.InputType = Android.Text.InputTypes.ClassText | Android.Text.InputTypes.TextVariationPassword;
				p.AddView(c, new Android.Support.V7.Widget.GridLayout.LayoutParams(passwordRow, fieldColumn));
			}
			{
				var c = new Android.Widget.Button(context);
				c.Text = "Manual setup";
				p.AddView(c, new Android.Support.V7.Widget.GridLayout.LayoutParams(button1Row, defineLastColumn));
				c.Click += delegate {
					Android.Widget.Toast.MakeText (Application.Context, "Manual Tapped!", Android.Widget.ToastLength.Short).Show ();
				};
			}
			{
				var c = new Android.Widget.Button(context);
				c.Text = "Next";
				p.AddView(c, new Android.Support.V7.Widget.GridLayout.LayoutParams(button2Row, fillLastColumn));
				c.Click += delegate {
					Android.Widget.Toast.MakeText (Application.Context, "Next Tapped!", Android.Widget.ToastLength.Short).Show ();
				};
			}

			return p;
		}
	}
}

