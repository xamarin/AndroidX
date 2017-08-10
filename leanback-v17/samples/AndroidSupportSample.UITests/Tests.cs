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
        public void Leanback ()
        {
            app.Screenshot ("Launch");
            app.Tap(q => q.Text("evolve"));
            app.Screenshot ("Evolve Category");
            app.Tap(q => q.Text("Evolve 2013 Keynote"));
            app.Screenshot ("Evolve 2013 Keynote");
        }
    }
}

