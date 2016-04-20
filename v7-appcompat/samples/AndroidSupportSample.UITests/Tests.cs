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
        public void ActionBarMechanics ()
        {
            app.Screenshot ("Launch");
            app.Tap(q => q.Text("Action Bar Mechanics"));
            app.WaitForElement (q => q.Class ("Toolbar"));
            app.Screenshot ("Action Bar Mechanics");

            // Tap the action bar button
            app.Tap (q => q.Class ("ActionMenuItemView"));
            // Wait for toast to show
            app.WaitForElement (q => q.Id ("message"));
            app.Screenshot ("Toast");

            // Tap the overflow menu
            app.Tap(q => q.Class("OverflowMenuButton")); 
            app.WaitForElement (q => q.Text ("Normal item"));
            app.Screenshot ("Menu Item");
            app.Tap (q => q.Text ("Normal item"));

            // Wait for toast to show
            app.WaitForElement (q => q.Id ("message"));
        }

        [Test]
        public void ActionBarTabs ()
        {
            app.Screenshot ("Launch");
            app.Tap(q => q.Text("Action Bar Tabs"));

            app.WaitForElement (q => q.Class ("Toolbar"));
            app.Screenshot ("Action Bar Tabs");

            // Turn tabs on
            app.Tap (q => q.Id ("btn_toggle_tabs"));

            // Add Tabs
            app.Tap (q => q.Id ("btn_add_tab"));
            app.WaitForElement (q => q.Text ("Tab 0"));
            app.Screenshot ("Add Tab 0");
            app.Tap (q => q.Id ("btn_add_tab"));
            app.WaitForElement (q => q.Text ("Tab 1"));
            app.Screenshot ("Add Tab 1");

            app.Tap (q => q.Id ("btn_remove_tab"));
            app.WaitForNoElement (q => q.Text ("Tab 1"));
            app.Screenshot ("Remove Tab 1");

            app.Tap (q => q.Id ("btn_remove_all_tabs"));
            app.WaitForNoElement (q => q.Text ("Tab 0"));
            app.Screenshot ("Remove All Tabs");
        }

        [Test]
        public void DisplayOptions ()
        {
            app.Screenshot ("Launch");
            app.Tap(q => q.Text("Display Options"));
            app.WaitForElement (q => q.Class ("Toolbar"));
            app.Screenshot ("Display Options");

            app.Tap (q => q.Id ("toggle_home_as_up"));
            app.WaitForElement (q => q.Class ("ImageButton"));
            app.Screenshot ("Toggle Home as Up");

            app.Tap (q => q.Id ("toggle_show_title"));
            app.WaitForNoElement (q => q.Text ("Display Options"));
            app.Screenshot ("Hide Title");
            app.Tap (q => q.Id ("toggle_show_title"));
            app.WaitForElement (q => q.Text ("Display Options"));
            app.Screenshot ("Show Title");

            app.Tap (q => q.Id ("toggle_visibility"));
            app.WaitForNoElement (q => q.Class ("Toolbar"));
            app.Screenshot ("Hide Toolbar");
        }

        [Test]
        public void AlertDialog ()
        {
            app.Screenshot ("Launch");
            app.Tap(q => q.Text("AlertDialog"));
            app.WaitForElement (q => q.Id ("alertTitle"));
            app.Screenshot ("Alert Dialog");
        }
    }
}

