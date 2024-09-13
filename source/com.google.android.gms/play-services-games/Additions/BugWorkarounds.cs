using System;
using Android.Runtime;
               
namespace Android.Gms.Games.Achievement
{
	internal static class FreezeMethodImplementor
	{
		internal static Java.Lang.Object Freeze(ref IntPtr id_freeze, IntPtr class_ref, IntPtr Handle)
		{
			if (id_freeze == IntPtr.Zero)
				id_freeze = JNIEnv.GetMethodID(class_ref, "freeze", "()Ljava/lang/Object;");
			return (Java.Lang.Object)global::Java.Lang.Object.GetObject<global::Java.Lang.Object>(JNIEnv.CallObjectMethod(Handle, id_freeze), JniHandleOwnership.TransferLocalRef);
		}
	}

	public partial class AchievementRef
	{
		IntPtr id_freeze;
		public Java.Lang.Object Freeze()
		{
			return FreezeMethodImplementor.Freeze(ref id_freeze, class_ref, Handle);
		}
	}
}


namespace Android.Gms.Games.Event
{
	internal static class FreezeMethodImplementor
	{
		internal static Java.Lang.Object Freeze(ref IntPtr id_freeze, IntPtr class_ref, IntPtr Handle)
		{
			if (id_freeze == IntPtr.Zero)
				id_freeze = JNIEnv.GetMethodID(class_ref, "freeze", "()Ljava/lang/Object;");
			return (Java.Lang.Object)global::Java.Lang.Object.GetObject<global::Java.Lang.Object>(JNIEnv.CallObjectMethod(Handle, id_freeze), JniHandleOwnership.TransferLocalRef);
		}
	}

	public partial class EventRef
	{
		IntPtr id_freeze;
		public Java.Lang.Object Freeze()
		{
			return FreezeMethodImplementor.Freeze(ref id_freeze, class_ref, Handle);
		}
	}
}

namespace Android.Gms.Games 
{
	internal static class FreezeMethodImplementor
	{
		internal static Java.Lang.Object Freeze (ref IntPtr id_freeze, IntPtr class_ref, IntPtr Handle)
		{
			if (id_freeze == IntPtr.Zero)
				id_freeze = JNIEnv.GetMethodID (class_ref, "freeze", "()Ljava/lang/Object;");
			return (Java.Lang.Object) global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (JNIEnv.CallObjectMethod  (Handle, id_freeze), JniHandleOwnership.TransferLocalRef);
		}
	}


}

namespace Android.Gms.Games.MultiPlayer
{
    public partial interface IMultiplayer : Android.Runtime.IJavaObject
    {

    }

	internal static class FreezeMethodImplementor
	{
		internal static Java.Lang.Object Freeze(ref IntPtr id_freeze, IntPtr class_ref, IntPtr Handle)
		{
			if (id_freeze == IntPtr.Zero)
				id_freeze = JNIEnv.GetMethodID(class_ref, "freeze", "()Ljava/lang/Object;");
			return (Java.Lang.Object)global::Java.Lang.Object.GetObject<global::Java.Lang.Object>(JNIEnv.CallObjectMethod(Handle, id_freeze), JniHandleOwnership.TransferLocalRef);
		}
	}

}


namespace Android.Gms.Games.LeaderBoard
{
    internal static class FreezeMethodImplementor
    {
        internal static Java.Lang.Object Freeze (ref IntPtr id_freeze, IntPtr class_ref, IntPtr Handle)
        {
            if (id_freeze == IntPtr.Zero)
                id_freeze = JNIEnv.GetMethodID (class_ref, "freeze", "()Ljava/lang/Object;");
            return (Java.Lang.Object) global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (JNIEnv.CallObjectMethod  (Handle, id_freeze), JniHandleOwnership.TransferLocalRef);
        }
    }

    public partial class LeaderboardScoreEntity
    {
        IntPtr id_freeze;
        public Java.Lang.Object Freeze ()
        {
            return FreezeMethodImplementor.Freeze (ref id_freeze, class_ref, Handle);
        }
    }

    public partial class LeaderboardScoreRef
    {
        IntPtr id_freeze;
        public Java.Lang.Object Freeze ()
        {
            return FreezeMethodImplementor.Freeze (ref id_freeze, class_ref, Handle);
        }
    }

    public partial class LeaderboardEntity
    {
        IntPtr id_freeze;
        public Java.Lang.Object Freeze ()
        {
            return FreezeMethodImplementor.Freeze (ref id_freeze, class_ref, Handle);
        }
    }

    public partial class LeaderboardRef
    {
        IntPtr id_freeze;
        public Java.Lang.Object Freeze ()
        {
            return FreezeMethodImplementor.Freeze (ref id_freeze, class_ref, Handle);
        }
    }

}

namespace Android.Gms.Games.Quest
{
	internal static class FreezeMethodImplementor
	{
		internal static Java.Lang.Object Freeze(ref IntPtr id_freeze, IntPtr class_ref, IntPtr Handle)
		{
			if (id_freeze == IntPtr.Zero)
				id_freeze = JNIEnv.GetMethodID(class_ref, "freeze", "()Ljava/lang/Object;");
			return (Java.Lang.Object)global::Java.Lang.Object.GetObject<global::Java.Lang.Object>(JNIEnv.CallObjectMethod(Handle, id_freeze), JniHandleOwnership.TransferLocalRef);
		}
	}
}


namespace Android.Gms.Games.Snapshot
{
	internal static class FreezeMethodImplementor
	{
		internal static Java.Lang.Object Freeze(ref IntPtr id_freeze, IntPtr class_ref, IntPtr Handle)
		{
			if (id_freeze == IntPtr.Zero)
				id_freeze = JNIEnv.GetMethodID(class_ref, "freeze", "()Ljava/lang/Object;");
			return (Java.Lang.Object)global::Java.Lang.Object.GetObject<global::Java.Lang.Object>(JNIEnv.CallObjectMethod(Handle, id_freeze), JniHandleOwnership.TransferLocalRef);
		}
	}

	public partial class SnapshotMetadataRef
	{
		IntPtr id_freeze;
		public Java.Lang.Object Freeze()
		{
			return FreezeMethodImplementor.Freeze(ref id_freeze, class_ref, Handle);
		}
	}
}


namespace Android.Gms.Games.Stats
{
    internal static class FreezeMethodImplementor
    {
        internal static Java.Lang.Object Freeze (ref IntPtr id_freeze, IntPtr class_ref, IntPtr Handle)
        {
            if (id_freeze == IntPtr.Zero)
                id_freeze = JNIEnv.GetMethodID (class_ref, "freeze", "()Ljava/lang/Object;");
            return (Java.Lang.Object) global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (JNIEnv.CallObjectMethod  (Handle, id_freeze), JniHandleOwnership.TransferLocalRef);
        }
    }

    //public partial class PlayerStatsEntity
    //{
    //    IntPtr id_freeze;
    //    public Java.Lang.Object Freeze ()
    //    {
    //        return FreezeMethodImplementor.Freeze (ref id_freeze, class_ref, Handle);
    //    }
    //}

    //public partial class PlayerStatsRef
    //{
    //    IntPtr id_freeze;
    //    public Java.Lang.Object Freeze ()
    //    {
    //        return FreezeMethodImplementor.Freeze (ref id_freeze, class_ref, Handle);
    //    }
    //}
}

namespace Android.Gms.Games.Request
{
	//    public sealed partial class GameRequestSummaryBuffer
	//    {
	//        IntPtr id_get;

	//        internal static IntPtr this_java_class_handle;
	//        internal static IntPtr this_class_ref {
	//            get {
	//                return JNIEnv.FindClass ("com/google/android/gms/games/request/GameRequestSummaryBuffer", ref this_java_class_handle);
	//            }
	//        }

	//        public override Java.Lang.Object Get (int position)
	//        {
	//            if (id_get == IntPtr.Zero)
	//                id_get = JNIEnv.GetMethodID (this_class_ref, "get", "(I)Ljava/lang/Object;");
	//            return (Java.Lang.Object) global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (JNIEnv.CallObjectMethod  (Handle, id_get, new JValue (position)), JniHandleOwnership.TransferLocalRef);
	//        }
	//    }
}

namespace Android.Gms.Games.Stats
{
    public sealed partial class PlayerStatsBuffer
    {
        IntPtr id_get;

        internal static IntPtr this_java_class_handle;
        internal static IntPtr this_class_ref {
            get {
                return JNIEnv.FindClass ("com/google/android/gms/games/stats/PlayerStatsBuffer", ref this_java_class_handle);
            }
        }

        public override Java.Lang.Object Get (int position)
        {
            if (id_get == IntPtr.Zero)
                id_get = JNIEnv.GetMethodID (this_class_ref, "get", "(I)Ljava/lang/Object;");
            return (Java.Lang.Object) global::Java.Lang.Object.GetObject<global::Java.Lang.Object> (JNIEnv.CallObjectMethod  (Handle, id_get, new JValue (position)), JniHandleOwnership.TransferLocalRef);
        }
    }
}
