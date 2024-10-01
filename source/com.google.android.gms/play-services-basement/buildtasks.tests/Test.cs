using NUnit.Framework;
using System;
using System.IO;
using Xamarin.GooglePlayServices.Tasks;
using System.Reflection;

namespace buildtasks.tests
{
    [TestFixture ()]
    public class GoogleServicesJsonTests
    {
        const string TestPkgName = "com.xamarin.sample";

        static Stream OpenTestFile ()
        {
            var path = Path.Combine (TestContext.CurrentContext.TestDirectory, "..", "..", "google-services.json");

            return File.OpenRead (path);
        }

        [Test]
        public void GoogleApiKey_Should_Match_Test ()
        {
            var g = GoogleServicesJsonProcessor.ProcessJson (TestPkgName, OpenTestFile ());
            var v = g.GetGoogleApiKey (TestPkgName);

            Assert.AreEqual ("EXAMPLE_KEY_HERE", v);
        }

        [Test]
        public void GoogleAppId_Should_Match_Test ()
        {
            var g = GoogleServicesJsonProcessor.ProcessJson (TestPkgName, OpenTestFile ());
            var v = g.GetGoogleAppId (TestPkgName);

            Assert.AreEqual ("1:1041063143217:android:ffbe6976403db935", v);
        }

        [Test]
        public void CrashReportingApiKey_Should_Match_Test ()
        {
            var g = GoogleServicesJsonProcessor.ProcessJson (TestPkgName, OpenTestFile ());
            var v = g.GetCrashReportingApiKey (TestPkgName);

            Assert.AreEqual ("EXAMPLE_KEY_HERE", v);
        }

        [Test]
        public void DefaultGcmSenderId_Should_Match_Test ()
        {
            var g = GoogleServicesJsonProcessor.ProcessJson (TestPkgName, OpenTestFile ());
            var v = g.GetDefaultGcmSenderId ();

            Assert.AreEqual ("1041063143217", v);
        }

        [Test]
        public void DefaultWebClientId_Should_Match_Test ()
        {
            var g = GoogleServicesJsonProcessor.ProcessJson (TestPkgName, OpenTestFile ());
            var v = g.GetDefaultWebClientId (TestPkgName);

            Assert.AreEqual ("1041063143217-hu5u4dnv8dkj19i4tpi6piv97kd2k9i0.apps.googleusercontent.com", v);
        }

        [Test]
        public void FirebaseDatabaseUrl_Should_Match_Test ()
        {
            var g = GoogleServicesJsonProcessor.ProcessJson (TestPkgName, OpenTestFile ());
            var v = g.GetFirebaseDatabaseUrl ();

            Assert.AreEqual ("https://white-cedar-97320.firebaseio.com", v);
        }

        [Test]
        public void GATrackingId_Should_Match_Test ()
        {
            var g = GoogleServicesJsonProcessor.ProcessJson (TestPkgName, OpenTestFile ());
            var v = g.GetGATrackingId (TestPkgName);

            Assert.AreEqual ("UA-6465612-26", v);
        }

        [Test]
        public void ProjectId_Should_Match_Test ()
        {
            var g = GoogleServicesJsonProcessor.ProcessJson (TestPkgName, OpenTestFile ());
            var v = g.ProjectInfo.ProjectId;

            Assert.AreEqual ("white-cedar-97320", v);
        }
    }
}

