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

        //[Test]
        public void Repl ()
        {
            app.Repl ();
        }

        [Test]
        public void AppLaunches ()
        {
            app.Screenshot ("Launch");
        }

        [Test]
        public void Video ()
        {
            app.Screenshot ("Launch");
            app.Tap (q => q.Text ("Dark Theme"));
            app.Screenshot ("Dark Theme");
            app.Tap (q => q.Text ("Cats with hats"));
            app.Screenshot ("Cats with hats");

            if (app.Query (q => q.Class ("MediaRouteButton")).Any ()) {
                app.WaitForElement (q => q.Class ("MediaRouteButton"));
                app.Tap (q => q.Class ("MediaRouteButton"));
                app.WaitForElement (q => q.Id ("media_route_list"));
                app.Screenshot ("Connect to device");
                app.Back ();
                app.WaitForNoElement (q => q.Id ("media_route_list"));
            }
        }
    }
}

