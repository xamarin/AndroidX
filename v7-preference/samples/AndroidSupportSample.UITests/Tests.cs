using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.Queries;

namespace AndroidSupportSample.UITests
{
    [TestFixture]
    public class Tests
    {
        AndroidApp app;

        [SetUp]
        public void BeforeEachTest ()
        {
            app = ConfigureApp.Android
                .ApkFile ("app.apk")
                .PreferIdeSettings ()
                .StartApp ();
        }

        [Test]
        public void Repl ()
        {
            app.Repl ();
        }

        [Test]
        public void AppLaunches ()
        {
            app.Screenshot ("Launch");
            app.WaitForElement (q => q.Marked ("List Preference"));
        }

		[Test]
		public void ListPreference()
		{
			app.Screenshot("Launch");
			app.WaitForElement(q => q.Marked("List Preference"));
			app.Tap(q => q.Marked("List Preference"));
			app.WaitForElement(q => q.Marked("Three"));
			app.Screenshot("List Preference");
		}

		[Test]
		public void EditTextPreference()
		{
			app.Screenshot("Launch");
			app.WaitForElement(q => q.Marked("Edit Text Preference"));
			app.Tap(q => q.Marked("Edit Text Preference"));
			app.WaitForElement(q => q.Marked("Dialog Title Edit Text Preference"));
			app.Screenshot("Edit Text Preference");
		}
    }
}

