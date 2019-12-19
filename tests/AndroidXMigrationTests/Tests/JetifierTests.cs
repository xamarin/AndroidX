using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Android.Tools.Bytecode;
using Xunit;

namespace Xamarin.AndroidX.Migration.Tests
{
	public class JetifierTests : BaseTests
	{
		[Fact]
		public void CanReadAarFileWithDifferentSlashes()
		{
			var layout = ReadAarEntry(SupportAar, "res\\layout\\supportlayout.xml");

			Assert.NotNull(layout);
			Assert.True(layout.Length > 0);
		}

		[Fact]
		public void CanReadAarFile()
		{
			var layout = ReadAarEntry(SupportAar, "res/layout/supportlayout.xml");

			Assert.NotNull(layout);
			Assert.True(layout.Length > 0);
		}

		[Fact]
		public void LayoutFilesAreAsExpected()
		{
			var supportLayout = ReadAarEntry(SupportAar, "res/layout/supportlayout.xml");
			var androidxLayout = ReadAarEntry(AndroidXAar, "res/layout/supportlayout.xml");

			Assert.Equal(
				"android.support.v7.widget.AppCompatButton",
				XDocument.Load(supportLayout).Root.Elements().FirstOrDefault().Name.LocalName);

			Assert.Equal(
				"androidx.appcompat.widget.AppCompatButton",
				XDocument.Load(androidxLayout).Root.Elements().FirstOrDefault().Name.LocalName);
		}

		[Fact]
		public void JetifierMigratesLayoutFiles()
		{
			var migratedAar = Utils.GetTempFilename();

			var jetifier = new Jetifier();
			var result = jetifier.Jetify(SupportAar, migratedAar);

			Assert.True(result);

			var migratedLayout = ReadAarEntry(migratedAar, "res/layout/supportlayout.xml");
			var androidxLayout = ReadAarEntry(AndroidXAar, "res/layout/supportlayout.xml");

			Assert.Equal(
				"androidx.appcompat.widget.AppCompatButton",
				XDocument.Load(migratedLayout).Root.Elements().FirstOrDefault().Name.LocalName);

			Assert.Equal(
				"androidx.appcompat.widget.AppCompatButton",
				XDocument.Load(androidxLayout).Root.Elements().FirstOrDefault().Name.LocalName);
		}

		[Fact]
		public void JetifierMigratesIndividualLayoutFiles()
		{
			var migratedLayout = Utils.GetTempFilename();

			var supportLayout = CreateFile("supportlayout.xml",
@"<?xml version=""1.0"" encoding=""utf-8""?>
<RelativeLayout xmlns:android=""http://schemas.android.com/apk/res/android""
                android:orientation=""vertical""
                android:layout_width=""match_parent""
                android:layout_height=""match_parent"">
    <android.support.v7.widget.AppCompatButton
        android:id=""@+id/appcompatButton""
        android:layout_width=""wrap_content""
        android:layout_height=""wrap_content""
        android:layout_centerInParent=""true""
        android:text=""AppCompat Button"" />
</RelativeLayout>");

			var jetifier = new Jetifier();
			var result = jetifier.Jetify(supportLayout, migratedLayout);

			Assert.True(result);

			Assert.Equal(
				"androidx.appcompat.widget.AppCompatButton",
				XDocument.Load(migratedLayout).Root.Elements().FirstOrDefault().Name.LocalName);
		}

		[Fact]
		public void JetifierMigratesIndividualProguardFiles()
		{
			var migratedLayout = Utils.GetTempFilename();

			var supportLayout = CreateFile("proguard.txt", @"
-keepclassmembers class android.support.v7.widget.AppCompatButton {
   public *;
}");

			var jetifier = new Jetifier();
			var result = jetifier.Jetify(supportLayout, migratedLayout);

			Assert.True(result);

			Assert.Contains("androidx.appcompat.widget.AppCompatButton", File.ReadAllText(migratedLayout));
		}

		[Fact]
		public void JetifierMigratesIndividualProguardFilesWithWildcards()
		{
			var migratedLayout = Utils.GetTempFilename();

			var supportLayout = CreateFile("proguard.txt", @"
-keepclassmembers class android.support.v7.widget.* {
   public *;
}");

			var jetifier = new Jetifier();
			var result = jetifier.Jetify(supportLayout, migratedLayout);

			Assert.True(result);

			Assert.Contains("androidx.appcompat.widget.*", File.ReadAllText(migratedLayout));
		}

		[Fact]
		public void JetifierMigratesIndividualManifestFiles()
		{
			var migratedLayout = Utils.GetTempFilename();

			var supportLayout = CreateFile("AndroidManifest.xml",
@"<?xml version=""1.0"" encoding=""utf-8""?>
<manifest xmlns:android=""http://schemas.android.com/apk/res/android""
          android:versionCode=""1""
          android:versionName=""1.0""
          package=""SimpleWidget.SimpleWidget"">
  <uses-sdk android:minSdkVersion=""8"" android:targetSdkVersion=""8"" />
  <application android:name=""mono.android.app.Application"" android:debuggable=""true"">
    <service android:name=""android.arch.lifecycle.LifecycleService"" />
  </application>
</manifest>");

			var jetifier = new Jetifier();
			var result = jetifier.Jetify(supportLayout, migratedLayout);

			Assert.True(result);

			Assert.Contains("<service android:name=\"androidx.lifecycle.LifecycleService\" />", File.ReadAllText(migratedLayout));
		}

		[Fact]
		public void CanReadJarFileAfterMigration()
		{
			var migratedAar = Utils.GetTempFilename();

			var jetifier = new Jetifier();
			var result = jetifier.Jetify(SupportAar, migratedAar);

			Assert.True(result);

			var jar = ReadAarEntry(migratedAar, "classes.jar");

			var classPath = new ClassPath();
			classPath.Load(jar);
			var packages = classPath.GetPackages();

			Assert.True(packages.Count > 0);
			Assert.Equal("com.xamarin.aarxercise", packages.Keys.FirstOrDefault());

			var classes = packages["com.xamarin.aarxercise"];

			Assert.True(classes.Count > 0);
		}

		[Fact]
		public void JavaTypesAreMigratedAfterJetifier()
		{
			var migratedAar = Utils.GetTempFilename();

			var jetifier = new Jetifier();
			var result = jetifier.Jetify(SupportAar, migratedAar);

			Assert.True(result);

			var jar = ReadAarEntry(migratedAar, "classes.jar");

			var classPath = new ClassPath();
			classPath.Load(jar);
			var packages = classPath.GetPackages();

			Assert.True(packages.Count > 0);
			Assert.Equal("com.xamarin.aarxercise", packages.Keys.FirstOrDefault());

			var classes = packages["com.xamarin.aarxercise"];
			var simpleFragment = classes.FirstOrDefault(c => c.ThisClass.Name.Value == "com/xamarin/aarxercise/SimpleFragment");

			Assert.Equal("androidx/fragment/app/Fragment", simpleFragment.SuperClass.Name.Value);
		}

		[Fact]
		public void JavaTypesAreMigratedAfterJetifierWithIntermediate()
		{
			var migratedAar = Utils.GetTempFilename();

			var jetifier = new Jetifier();
			jetifier.UseIntermediateFile = true;
			var result = jetifier.Jetify(SupportAar, migratedAar);

			Assert.True(result);

			var jar = ReadAarEntry(migratedAar, "classes.jar");

			var classPath = new ClassPath();
			classPath.Load(jar);
			var packages = classPath.GetPackages();

			Assert.True(packages.Count > 0);
			Assert.Equal("com.xamarin.aarxercise", packages.Keys.FirstOrDefault());

			var classes = packages["com.xamarin.aarxercise"];
			var simpleFragment = classes.FirstOrDefault(c => c.ThisClass.Name.Value == "com/xamarin/aarxercise/SimpleFragment");

			Assert.Equal("androidx/fragment/app/Fragment", simpleFragment.SuperClass.Name.Value);
		}

		[Fact]
		public async Task JetifierWrapperMigratesFacebookAar()
		{
			var facebookFilename = "facebook-android-sdk";
			var facebookVersion = "4.40.0";
			var facebookFullName = $"{facebookFilename}-{facebookVersion}";
			var facebookTestUrl = $"https://origincache.facebook.com/developers/resources/?id={facebookFullName}.zip";

			var workspace = Utils.GetTempFilename();
			Directory.CreateDirectory(workspace);

			// download facebook
			var facebookZip = Path.Combine(workspace, "facebook.zip");
			await Utils.DownloadFileAsync(facebookTestUrl, facebookZip);
			ZipFile.ExtractToDirectory(facebookZip, workspace);

			// run jetifier
			var aarFiles = Directory.GetFiles(workspace, "*.aar", SearchOption.AllDirectories);
			var pairs = aarFiles.Select(f => new MigrationPair(f, Path.ChangeExtension(f, "jetified.aar"))).ToArray();
			var jetifier = new Jetifier();
			var result = jetifier.Jetify(pairs);
			Assert.True(result);

			// read the classes
			var commonAar = pairs.FirstOrDefault(pair => Path.GetFileNameWithoutExtension(pair.Source) == "facebook-common");
			var jar = ReadAarEntry(commonAar.Destination, "classes.jar");
			var classPath = new ClassPath();
			classPath.Load(jar);
			var packages = classPath.GetPackages();

			// read the type
			var classes = packages["com.facebook"];
			var activity = classes.FirstOrDefault(c => c.ThisClass.Name.Value == "com/facebook/FacebookActivity");

			// read the layout
			var migratedLayout = ReadAarEntry(commonAar.Destination, "res/layout/com_facebook_device_auth_dialog_fragment.xml");

			// check
			Assert.Equal("androidx/fragment/app/FragmentActivity", activity.SuperClass.Name.Value);
			Assert.Equal(
				"androidx.cardview.widget.CardView",
				XDocument.Load(migratedLayout).Root.Name.LocalName);
		}
	}
}
