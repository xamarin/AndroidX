using System;
using System.Threading.Tasks;
using Android.Gms.Common.Apis;
using Android.Runtime;

namespace Android.Gms.Tagmanager
{
    public partial class TagManagerClass
    {
        public async Task<IContainerHolder> LoadContainerDefaultOnlyAsync(string containerId, int defaultContainerResourceId)
        {
            return (await LoadContainerDefaultOnly(containerId, defaultContainerResourceId)).JavaCast<IContainerHolder>();
        }

        public async Task<IContainerHolder> LoadContainerDefaultOnlyAsync(string containerId, int defaultContainerResourceId, Android.OS.Handler handler)
        {
            return (await LoadContainerDefaultOnly(containerId, defaultContainerResourceId, handler)).JavaCast<IContainerHolder>();
        }

        public async Task<IContainerHolder> LoadContainerPreferFreshAsync(string containerId, int defaultContainerResourceId)
        {
            return (await LoadContainerPreferFresh(containerId, defaultContainerResourceId)).JavaCast<IContainerHolder>();
        }

        public async Task<IContainerHolder> LoadContainerPreferFreshAsync(string containerId, int defaultContainerResourceId, Android.OS.Handler handler)
        {
            return (await LoadContainerPreferFresh(containerId, defaultContainerResourceId, handler)).JavaCast<IContainerHolder>();
        }

        public async Task<IContainerHolder> LoadContainerPreferNonDefaultAsync(string containerId, int defaultContainerResourceId)
        {
            return (await LoadContainerPreferNonDefault(containerId, defaultContainerResourceId)).JavaCast<IContainerHolder>();
        }

        public async Task<IContainerHolder> LoadContainerPreferNonDefaultAsync(string containerId, int defaultContainerResourceId, Android.OS.Handler handler)
        {
            return (await LoadContainerPreferNonDefault(containerId, defaultContainerResourceId, handler)).JavaCast<IContainerHolder>();
        }
    }
}