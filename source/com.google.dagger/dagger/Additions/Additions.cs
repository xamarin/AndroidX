using System;
using Android.Runtime;
using Java.Interop;

namespace Dagger.Internal
{
    partial class MapFactory
    {
        public unsafe global::Java.Lang.Object Get()
        {
            return Dictionary as Java.Lang.Object;
        }
    }

    partial class SetFactory
    {
        public unsafe global::Java.Lang.Object Get()
        {
            return Collection as Java.Lang.Object;
        }
    }

    partial class ProviderOfLazy
    {
        public unsafe global::Java.Lang.Object Get()
        {
            return Lazy as Java.Lang.Object;
        }
    }
}
