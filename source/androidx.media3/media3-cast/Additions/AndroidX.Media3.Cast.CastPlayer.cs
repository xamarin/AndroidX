namespace AndroidX.Media3.Cast 
{

	// Metadata.xml XPath class reference: path="/api/package[@name='androidx.media3.cast']/class[@name='CastPlayer']"
	// [global::Android.Runtime.Register ("androidx/media3/cast/CastPlayer", DoNotGenerateAcw=true)]
	public sealed partial class CastPlayer // : global::AndroidX.Media3.Common.BasePlayer 
    {
		public override void AddMediaItems (int index, global::System.Collections.Generic.IList <global:: AndroidX.Media3.Common.MediaItem >? mediaItems)
		{
            this.AddMediaItems(index, mediaItems);
		}
    }
}
