using System;
using Android.Runtime;
using Java.Interop;

namespace Google.Android.Material.Tabs.AppCompat.App
{
    [Register ("com.google.material.tabs.appcompat.app.AppCompatActivity", DoNotGenerateAcw=true)]
    public class AppCompatActivity : AndroidX.AppCompat.App.AppCompatActivity, TabLayout.IOnTabSelectedListener2 
    {
        public IntPtr Handle => throw new NotImplementedException();

        public int JniIdentityHashCode => throw new NotImplementedException();

        public JniObjectReference PeerReference => throw new NotImplementedException();

        public JniPeerMembers JniPeerMembers => throw new NotImplementedException();

        public JniManagedPeerStates JniManagedPeerState => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Disposed()
        {
            throw new NotImplementedException();
        }

        public void DisposeUnlessReferenced()
        {
            throw new NotImplementedException();
        }

        public void Finalized()
        {
            throw new NotImplementedException();
        }

        [Register ("onTabReselected", "()V", "")]
        public virtual void OnTabReselected(TabLayout.Tab tab)
        {
            throw new NotImplementedException();
        }

        public virtual void OnTabSelected(TabLayout.Tab tab)
        {
            throw new NotImplementedException();
        }

        public virtual void OnTabUnselected(TabLayout.Tab tab)
        {
            throw new NotImplementedException();
        }

        public void SetJniIdentityHashCode(int value)
        {
            throw new NotImplementedException();
        }

        public void SetJniManagedPeerState(JniManagedPeerStates value)
        {
            throw new NotImplementedException();
        }

        public void SetPeerReference(JniObjectReference reference)
        {
            throw new NotImplementedException();
        }

        public void UnregisterFromRuntime()
        {
            throw new NotImplementedException();
        }
    }
}