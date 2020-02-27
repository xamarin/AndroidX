using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;
using System;
using Xunit.Runners;
using System.Threading.Tasks;
using Android.Support.V7.App;
using Android.Views;

namespace AndroidSupport.Tests
{
	[Activity(Label = "AndroidSupport.Tests", MainLauncher = true, Theme="@style/Theme.AppCompat.Light", Icon = "@mipmap/icon")]
	public class MainActivity : AppCompatActivity
	{
		public static Activity TestParentActivity { get; set; }


		TaskCompletionSource<bool> tcsTests = new TaskCompletionSource<bool>();

		AssemblyRunner assemblyRunner;

		TestResultsAdapter adapter;
		ListView listView;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			TestParentActivity = this;

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			listView = FindViewById<ListView>(Resource.Id.listView);

			adapter = new TestResultsAdapter { Parent = this };
			listView.Adapter = adapter;

			assemblyRunner = AssemblyRunner.WithoutAppDomain(Assembly.GetExecutingAssembly().GetName().Name + ".dll");
			assemblyRunner.OnDiscoveryComplete = DiscoveryCompleteHandler;;
			assemblyRunner.OnExecutionComplete = ExecutionCompleteHandler;;
			assemblyRunner.OnTestFailed = TestFailedHandler;;
			assemblyRunner.OnTestSkipped = TestSkippedHandler;
			assemblyRunner.OnTestPassed = TestPassedHandler;
			assemblyRunner.OnTestOutput = TestOutputHandler;

			Console.WriteLine("Discovering...");
			assemblyRunner.Start ();
    	}

		bool anyFailed = false;

		void DiscoveryCompleteHandler(DiscoveryCompleteInfo obj)
		{
			Console.WriteLine("Discovery Complete.");
		}

		void ExecutionCompleteHandler(ExecutionCompleteInfo obj)
		{
			Console.WriteLine("Test Complete: Success={0}", !anyFailed);
			tcsTests.TrySetResult(anyFailed);
		}

		void TestFailedHandler(TestFailedInfo obj)
		{
			anyFailed = true;
			adapter.AddResult(new TestResultInfo
			{
				Passed = false,
				DisplayName = obj.TestDisplayName
			});
		}

		void TestSkippedHandler(TestSkippedInfo obj)
		{
			
		}

		void TestOutputHandler(TestOutputInfo obj)
		{
			
		}

		void TestPassedHandler(TestPassedInfo obj)
		{
			adapter.AddResult(new TestResultInfo
			{
				Passed = true,
				DisplayName = obj.TestDisplayName
			});
		}
	}

	class TestResultInfo
	{
		public bool Passed { get; set; }
		public string DisplayName { get; set; }
	}

	class TestResultsAdapter : BaseAdapter<TestResultInfo>
	{
		public Activity Parent;
		List<TestResultInfo> results = new List<TestResultInfo>();

		public void AddResult(TestResultInfo info)
		{
			results.Add(info);
			Parent.RunOnUiThread(() => NotifyDataSetChanged());
		}

		public override TestResultInfo this[int position]
		{
			get { return results[position]; }
		}

		public override int Count
		{
			get { return results.Count; }
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var view = convertView ?? LayoutInflater.From(Parent).Inflate(Android.Resource.Layout.TwoLineListItem, parent, false);

			var r = this[position];

			view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = r.DisplayName;
			view.FindViewById<TextView>(Android.Resource.Id.Text2).Text = r.Passed ? "Passed" : "Failed";
			view.FindViewById<TextView>(Android.Resource.Id.Text2).SetTextColor(r.Passed ? Android.Graphics.Color.Green : Android.Graphics.Color.Maroon);

			return view;
		}
	}
}