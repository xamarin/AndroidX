using Xunit;

namespace Xamarin.AndroidX.Migration.Tests
{
	public class JniStringMigrationTests : BaseTests
	{
		[Theory]
		[InlineData("", "")]
		[InlineData("()V", "()V")]
		[InlineData(
			"(Landroid/content/Context;)Landroid/support/v4/app/Fragment;",
			"(Landroid/content/Context;)Landroidx/fragment/app/Fragment;")]
		[InlineData(
			"com/test/test/test/a/b/ʹ$ʹ",
			"com/test/test/test/a/b/ʹ$ʹ")]
		public void JniStringAreCorrectlyMapped(string supportJni, string androidxJni)
		{
			var cecilMigrator = new CecilMigrator();
			var wasChanged = cecilMigrator.MigrateJniString(supportJni, out var mappedJni);

			Assert.Equal(supportJni != androidxJni, wasChanged);
			if (wasChanged)
				Assert.Equal(androidxJni, mappedJni);
			else
				Assert.Null(mappedJni);
		}
	}
}
