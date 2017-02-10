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
        }

        [Test]
        public void SimpleForm ()
        {
            app.Screenshot ("Launch");
            app.Tap (q => q.Text ("1. Simple Form"));
            app.Screenshot ("Tap 1. Simple Form");
            app.WaitForElement (q => q.Class ("GridLayout"));
            app.Screenshot ("Simple Form");
        }

        [Test]
        public void FormXml ()
        {
            app.Screenshot ("Launch");
            app.Tap (q => q.Text ("2. Form (XML)"));
            app.Screenshot ("Tap 2. Form (XML)");
            app.WaitForElement (q => q.Class ("GridLayout"));
            app.Screenshot ("Form Xml");
        }

        [Test]
        public void FormCSharp ()
        {
            app.Screenshot ("Launch");
            app.Tap (q => q.Text ("3. Form (C#)"));
            app.Screenshot ("Tap 3. Form (C#)");
            app.WaitForElement (q => q.Class ("GridLayout"));
            app.Screenshot ("Form C#");
        }
    }
}

