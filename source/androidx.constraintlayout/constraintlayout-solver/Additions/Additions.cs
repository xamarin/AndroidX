using System;
using System.Collections.Generic;
using Android.Runtime;

namespace AndroidX.ConstraintLayout.Solver.Widgets
{
	public partial class ConstraintWidget
	{
		[Obsolete("Use MNextChainWidget instead.")]
		protected IList<ConstraintWidget> MListNextVisibleWidget
		{
			get => MNextChainWidget;
			set => MNextChainWidget = value;
		}
	}
}
