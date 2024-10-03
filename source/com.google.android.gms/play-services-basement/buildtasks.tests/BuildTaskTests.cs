using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Build.Construction;
using Microsoft.Build.Evaluation;
using Microsoft.Build.Execution;
using NUnit.Framework;
using Xamarin.ContentPipeline.Tests;

namespace buildtasks.tests
{
	class BuildTaskTests : TestsBase
	{
		public void AddCoreTargets(ProjectRootElement el)
		{
			//var props = Path.Combine(
			//	Path.GetDirectoryName(GetType().Assembly.Location),
			//	"..", "..", "..", "buildtasks", "bin", "Debug", "Xamarin.GooglePlayServices.Basement.props"
			//);
			//el.AddImport(props);
			var targets = Path.Combine(
				Path.GetDirectoryName(GetType().Assembly.Location),
				"..", "..", "..", "buildtasks", "bin", "Debug", "Xamarin.GooglePlayServices.Basement.targets"
			);
			el.AddImport(targets);

		}

		[Test]
		public void Test_Skip_Due_To_Newer_Outputs_Than_Inputs()
		{
			var googleServicesJsonPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "..", "..", "google-services.json");

			var monoAndroidResDirIntermediate = Path.Combine(TempDir, "Debug");

			Directory.CreateDirectory(monoAndroidResDirIntermediate);

			File.WriteAllText(Path.Combine(monoAndroidResDirIntermediate, "ProcessGoogleServicesJson.stamp"), "STAMPS");


			var engine = new ProjectCollection();
			var prel = ProjectRootElement.Create(Path.Combine(TempDir, "project.csproj"), engine);

			Console.WriteLine("TempDir: {0}", TempDir);

			prel.AddProperty("AndroidApplication", "True");
			prel.AddProperty("IntermediateOutputPath", monoAndroidResDirIntermediate);
			prel.AddProperty("MonoAndroidResDirIntermediate", monoAndroidResDirIntermediate);
			prel.AddProperty("_AndroidPackage", "com.xamarin.sample");

			prel.AddItem("GoogleServicesJson", googleServicesJsonPath);

			AddCoreTargets(prel);

			var project = new ProjectInstance(prel);
			var log = new MSBuildTestLogger();

			var success = BuildProject(engine, project, "ProcessGoogleServicesJson", log);

			Assert.IsTrue(success);
			Assert.IsTrue(log.Events.Any(e => e.Message.Contains("ProcessGoogleServicesJson") && e.Message.Contains("skipped")));
		}

		[Test]
		public void Test_Inputs_Newer_Than_Outputs()
		{
			var googleServicesJsonPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "..", "..", "google-services.json");

			var monoAndroidResDirIntermediate = Path.Combine(TempDir, "Debug");

			Directory.CreateDirectory(monoAndroidResDirIntermediate);

			var engine = new ProjectCollection();
			var prel = ProjectRootElement.Create(Path.Combine(TempDir, "project.csproj"), engine);

			Console.WriteLine("TempDir: {0}", TempDir);

			prel.AddProperty("AndroidApplication", "True");
			prel.AddProperty("IntermediateOutputPath", monoAndroidResDirIntermediate);
			prel.AddProperty("MonoAndroidResDirIntermediate", monoAndroidResDirIntermediate);
			prel.AddProperty("_AndroidPackage", "com.xamarin.sample");

			prel.AddItem("GoogleServicesJson", googleServicesJsonPath);

			AddCoreTargets(prel);

			var project = new ProjectInstance(prel);
			var log = new MSBuildTestLogger();

			var success = BuildProject(engine, project, "ProcessGoogleServicesJson", log);

			Assert.IsTrue(success);
			Assert.IsFalse(log.Events.Any(e => e.Message.Contains("ProcessGoogleServicesJson") && e.Message.Contains("skipped")));
		}
	}
}
