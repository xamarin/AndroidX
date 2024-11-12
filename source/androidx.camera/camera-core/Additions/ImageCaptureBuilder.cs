using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AndroidX.Camera.Core.Internal;
using Java.Lang;

namespace AndroidX.Camera.Core
{
	public partial class ImageCapture
	{
		public partial class Builder
		{
			// Explicitly implement these interface methods that have
			// covariant return types in the public API.
			Java.Lang.Object IExtendableBuilder.Build ()
			{
				return Build ();
			}

			Java.Lang.Object ITargetConfigBuilder.SetTargetClass (Class @class)
			{
				return SetTargetClass (@class);
			}

			Java.Lang.Object ITargetConfigBuilder.SetTargetName (string name)
			{
				return SetTargetName (name);
			}
		}
	}
}
