using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace Android.Gms.Games {

	// Metadata.xml XPath class reference: path="/api/package[@name='com.google.android.gms.games']/class[@name='Games']"
	// [global::Android.Runtime.Register ("com/google/android/gms/games/Games", DoNotGenerateAcw=true)]
	public sealed partial class GamesClass // : global::Java.Lang.Object 
	{
		public sealed partial class GamesOptions // : global::Java.Lang.Object, global::Android.Gms.Auth.Api.SignIn.IGoogleSignInOptionsExtension, global::Android.Gms.Common.Apis.Api.IApiOptionsHasGoogleSignInAccountOptions, global::Android.Gms.Common.Apis.Api.IApiOptionsOptional 
		{
			public unsafe global::System.Collections.Generic.IList <global:: Android.Gms.Common.Apis.Scope > ImpliedScopes 
			{
				// Metadata.xml XPath method reference: path="/api/package[@name='com.google.android.gms.games']/class[@name='Games.GamesOptions']/method[@name='getImpliedScopes' and count(parameter)=0]"
				[Register ("getImpliedScopes", "()Ljava/util/List;", "")]
				get 
				{
					const string __id = "getImpliedScopes.()Ljava/util/List;";
					try {
						var __rm = _members.InstanceMethods.InvokeNonvirtualObjectMethod (__id, this, null);
						return 
							(global::System.Collections.Generic.IList <global:: Android.Gms.Common.Apis.Scope >)
								global::Android.Runtime.JavaList.FromJniHandle (__rm.Handle, JniHandleOwnership.TransferLocalRef);
					} finally {
					}
				}
			}
		}
	}
}
