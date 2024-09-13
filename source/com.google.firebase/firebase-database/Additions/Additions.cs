using System;
using System.Threading.Tasks;
using Android.Gms.Extensions;

namespace Firebase.Database
{
    public partial class DatabaseReference
    {
        public Task RemoveValueAsync ()
        {
            return RemoveValue ().AsAsync ();
        }

        public Task SetPriorityAsync (Java.Lang.Object obj)
        {
            return SetPriority (obj).AsAsync ();
        }

        public Task SetValueAsync (Java.Lang.Object obj)
        {
            return SetValue (obj).AsAsync ();
        }

        public Task SetValueAsync (Java.Lang.Object obj1, Java.Lang.Object obj2)
        {
            return SetValue (obj1, obj2).AsAsync ();
        }

        public Task UpdateChildrenAsync (System.Collections.Generic.IDictionary<string, Java.Lang.Object> map)
        {
            return UpdateChildren (map).AsAsync ();
        }
    }

    public partial class OnDisconnect
    {
        public Task CancelAsync ()
        {
            return Cancel ().AsAsync ();
        }

        public Task RemoveValueAsync ()
        {
            return RemoveValue ().AsAsync ();
        }

        public Task SetValueAsync (Java.Lang.Object obj)
        {
            return SetValue (obj).AsAsync ();
        }

        public Task SetValueAsync (Java.Lang.Object obj, string key)
        {
            return SetValue (obj, key).AsAsync ();
        }

        public Task SetValueAsync (Java.Lang.Object obj, double val)
        {
            return SetValue (obj, val).AsAsync ();
        }

        public Task UpdateChildrenAsync (System.Collections.Generic.IDictionary<string, Java.Lang.Object> map)
        {
            return UpdateChildren (map).AsAsync ();
        }
    }
}
