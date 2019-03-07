using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Xunit;

namespace Xamarin.Android.Support.BuildTasks.Tests
{
	public class Tests
	{
		[Fact]
		public void Test_Get_Project_Asset_Nugets()
		{
			var path = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "TestData");

			var packageVersions = new Dictionary<string, string>();
			NugetPackages.GatherProjectJsonVersions(
				VerifyVersionsTask.PACKAGE_ID_PREFIX,
				path,
				VerifyVersionsTask.ExcludedPackages,
				new Version(8, 1),
				packageVersions);

			Assert.NotEmpty(packageVersions);
		}

		[Fact]
		public void Test_Should_Detect_Multiple_Versions_Project_Assets()
		{
			var path = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "TestData");

			var packageVersions = new Dictionary<string, string>();
			NugetPackages.GatherProjectJsonVersions(
				VerifyVersionsTask.PACKAGE_ID_PREFIX,
				path,
				VerifyVersionsTask.ExcludedPackages,
				new Version(8, 1),
				packageVersions);

			Assert.NotEmpty(packageVersions);

			var distinctVersions = NugetPackages.GetDistinctVersions(VerifyVersionsTask.PACKAGE_ID_PREFIX, VerifyVersionsTask.ExcludedPackages, packageVersions);

			Assert.True(distinctVersions > 1);
		}

		[Theory]
		[InlineData(23, "23.x")]
		[InlineData(24, "24.x")]
		[InlineData(25, "25.4.0.2")]
		[InlineData(26, "26.1.0.1")]
		public async Task Test_Recommended_NuGet_Version(int apiLevel, string expectedVersion)
		{
			var v = await NugetPackages.GetRecommendedSupportPackageVersion(apiLevel);

			Assert.Equal(expectedVersion, v);
		}
	}
}
