
using Android.Runtime;

namespace AndroidX.Emoji.Widget
{

	// Metadata.xml XPath class reference: path="/api/package[@name='androidx.emoji.widget']/class[@name='EmojiKeyListener']"
	//[global::Android.Runtime.Register("androidx/emoji/widget/EmojiKeyListener", DoNotGenerateAcw = true)]
	public sealed partial class EmojiKeyListener //: global::Java.Lang.Object, global::Android.Text.Method.IKeyListener
	{

		public unsafe global::Android.Text.InputTypes InputType
		{
			// Metadata.xml XPath method reference: path="/api/package[@name='androidx.emoji.widget']/class[@name='EmojiKeyListener']/method[@name='getInputType' and count(parameter)=0]"
			[Register("getInputType", "()I", "")]
			get
			{
				const string __id = "getInputType.()I";
				try
				{
					var __rm = _members.InstanceMethods.InvokeAbstractInt32Method(__id, this, null);
					return (Android.Text.InputTypes)__rm;
				}
				finally
				{
				}
			}
		}
	}
}
