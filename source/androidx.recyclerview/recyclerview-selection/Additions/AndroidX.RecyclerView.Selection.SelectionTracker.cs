#nullable restore
using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.RecyclerView.Selection 
{

	// Metadata.xml XPath class reference: path="/api/package[@name='androidx.recyclerview.selection']/class[@name='SelectionTracker']"
	// [global::Android.Runtime.Register ("androidx/recyclerview/selection/SelectionTracker", DoNotGenerateAcw=true)]
	// [global::Java.Interop.JavaTypeParameters (new string [] {"K"})]
	public abstract partial class SelectionTracker : global::Java.Lang.Object     
{
        public Selection Selection => RawSelection;        
    }
}