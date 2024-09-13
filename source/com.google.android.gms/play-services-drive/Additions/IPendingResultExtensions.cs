using System;
using System.Threading.Tasks;
using Android.Gms.Common.Apis;
using Android.Runtime;
using System.Collections.Generic;

namespace Android.Gms.Drive
{
    public static partial class IDriveApiExtensions
    {
        //[Obsolete]
        //public static async Task<Statuses> CancelPendingActionsAsync (this IDriveApi api, GoogleApiClient apiClient, IList<string> trackingTags)
        //{
        //    return (await api.CancelPendingActions (apiClient, trackingTags)).JavaCast<Statuses> ();
        //}
        [Obsolete]
        public static async Task<IDriveApiDriveIdResult> FetchDriveIdAsync (this IDriveApi api, GoogleApiClient apiClient, string resourceId)
        {
            return (await api.FetchDriveId (apiClient, resourceId)).JavaCast<IDriveApiDriveIdResult> ();
        }
        //[Obsolete]
        //public static async Task<BooleanResult> IsAutobackupEnabledAsync (this IDriveApi api, GoogleApiClient apiClient)
        //{
        //    return (await api.IsAutobackupEnabled (apiClient)).JavaCast<BooleanResult> ();
        //}
        [Obsolete]
        public static async Task<IDriveApiDriveContentsResult> NewDriveContentsAsync (this IDriveApi api, GoogleApiClient apiClient)
        {
            return (await api.NewDriveContents (apiClient)).JavaCast<IDriveApiDriveContentsResult> ();
        }
        [Obsolete]
        public static async Task<IDriveApiMetadataBufferResult> QueryAsync (this IDriveApi api, GoogleApiClient apiClient, Android.Gms.Drive.Query.QueryClass query)
        {
            return (await api.Query (apiClient, query)).JavaCast<IDriveApiMetadataBufferResult> ();
        }
        [Obsolete]
        public static async Task<Statuses> RequestSyncAsync (this IDriveApi api, GoogleApiClient apiClient)
        {
            return (await api.RequestSync (apiClient)).JavaCast<Statuses> ();
        }
    }

    public static partial class IDriveContentsExtensions
    {
        [Obsolete]
        public static async Task<Statuses> CommitAsync (this IDriveContents api, GoogleApiClient apiClient, Android.Gms.Drive.MetadataChangeSet changeSet)
        {
            return (await api.Commit (apiClient, changeSet)).JavaCast<Statuses> ();
        }
        [Obsolete]
        public static async Task<Statuses> CommitAsync (this IDriveContents api, GoogleApiClient apiClient, Android.Gms.Drive.MetadataChangeSet changeSet, Android.Gms.Drive.ExecutionOptions executionOptions)
        {
            return (await api.Commit (apiClient, changeSet, executionOptions)).JavaCast<Statuses> ();
        }
        [Obsolete]
        public static async Task<IDriveApiDriveContentsResult> ReopenForWriteAsync (this IDriveContents api, GoogleApiClient apiClient)
        {
            return (await api.ReopenForWrite (apiClient)).JavaCast<IDriveApiDriveContentsResult> ();
        }
    }

    public static partial class IDriveFileExtensions
    {
        [Obsolete]
        public static async Task<IDriveApiDriveContentsResult> OpenAsync (this IDriveFile api, GoogleApiClient apiClient, int mode, IDriveFileDownloadProgressListener listener)
        {
            return (await api.Open (apiClient, mode, listener)).JavaCast<IDriveApiDriveContentsResult> ();
        }
    }

    public static partial class IDriveFolderExtensions
    {
        [Obsolete]
        public static async Task<IDriveFolderDriveFileResult> CreateFileAsync (this IDriveFolder api, GoogleApiClient apiClient, MetadataChangeSet changeSet, IDriveContents driveContents)
        {
            return (await api.CreateFile (apiClient, changeSet, driveContents)).JavaCast<IDriveFolderDriveFileResult> ();
        }
        [Obsolete]
        public static async Task<IDriveFolderDriveFileResult> CreateFileAsync (this IDriveFolder api, GoogleApiClient apiClient, MetadataChangeSet changeSet, IDriveContents driveContents, ExecutionOptions executionOptions)
        {
            return (await api.CreateFile (apiClient, changeSet, driveContents, executionOptions)).JavaCast<IDriveFolderDriveFileResult> ();
        }
        [Obsolete]
        public static async Task<IDriveFolderDriveFolderResult> CreateFolderAsync (this IDriveFolder api, GoogleApiClient apiClient, MetadataChangeSet changeSet)
        {
            return (await api.CreateFolder (apiClient, changeSet)).JavaCast<IDriveFolderDriveFolderResult> ();
        }
        [Obsolete]
        public static async Task<IDriveApiMetadataBufferResult> ListChildrenAsync (this IDriveFolder api, GoogleApiClient apiClient)
        {
            return (await api.ListChildren (apiClient)).JavaCast<IDriveApiMetadataBufferResult> ();
        }
        [Obsolete]
        public static async Task<IDriveApiMetadataBufferResult> QueryChildrenAsync (this IDriveFolder api, GoogleApiClient apiClient, Query.QueryClass query)
        {
            return (await api.QueryChildren (apiClient, query)).JavaCast<IDriveApiMetadataBufferResult> ();
        }
    }

    public static partial class IDrivePreferencesApiExtensions
    {
        [Obsolete]
        public static async Task<IDrivePreferencesApiFileUploadPreferencesResult> GetFileUploadPreferencesAsync (this IDrivePreferencesApi api, GoogleApiClient apiClient)
        {
            return (await api.GetFileUploadPreferences (apiClient)).JavaCast<IDrivePreferencesApiFileUploadPreferencesResult> ();
        }
        [Obsolete]
        public static async Task<Statuses> SetFileUploadPreferencesAsync (this IDrivePreferencesApi api, GoogleApiClient apiClient, IFileUploadPreferences fileUploadPreferences)
        {
            return (await api.SetFileUploadPreferences (apiClient, fileUploadPreferences)).JavaCast<Statuses> ();
        }
    }
        
    public static partial class IDriveResourceExtensions
    {
        [Obsolete]
        public static async Task<Statuses> AddChangeListenerAsync (this IDriveResource api, GoogleApiClient apiClient, Android.Gms.Drive.Events.IChangeListener listener)
        {
            return (await api.AddChangeListener (apiClient, listener)).JavaCast<Statuses> ();
        }
        [Obsolete]
        public static async Task<Statuses> AddChangeSubscriptionAsync (this IDriveResource api, GoogleApiClient apiClient)
        {
            return (await api.AddChangeSubscription (apiClient)).JavaCast<Statuses> ();
        }
        [Obsolete]
        public static async Task<Statuses> DeleteAsync (this IDriveResource api, GoogleApiClient apiClient)
        {
            return (await api.Delete (apiClient)).JavaCast<Statuses> ();
        }
        [Obsolete]
        public static async Task<IDriveResourceMetadataResult> GetMetadataAsync (this IDriveResource api, GoogleApiClient apiClient)
        {
            return (await api.GetMetadata (apiClient)).JavaCast<IDriveResourceMetadataResult> ();
        }
        [Obsolete]
        public static async Task<IDriveApiMetadataBufferResult> ListParentsAsync (this IDriveResource api, GoogleApiClient apiClient)
        {
            return (await api.ListParents (apiClient)).JavaCast<IDriveApiMetadataBufferResult> ();
        }
        [Obsolete]
        public static async Task<Statuses> RemoveChangeListenerAsync (this IDriveResource api, GoogleApiClient apiClient, Events.IChangeListener listener)
        {
            return (await api.RemoveChangeListener (apiClient, listener)).JavaCast<Statuses> ();
        }
        [Obsolete]
        public static async Task<Statuses> RemoveChangeSubscriptionAsync (this IDriveResource api, GoogleApiClient apiClient)
        {
            return (await api.RemoveChangeSubscription (apiClient)).JavaCast<Statuses> ();
        }
        [Obsolete]
        public static async Task<Statuses> SetParentsAsync (this IDriveResource api, GoogleApiClient apiClient, ICollection<DriveId> parentIds)
        {
            return (await api.SetParents (apiClient, parentIds)).JavaCast<Statuses> ();
        }
        [Obsolete]
        public static async Task<Statuses> TrashAsync (this IDriveResource api, GoogleApiClient apiClient)
        {
            return (await api.Trash (apiClient)).JavaCast<Statuses> ();
        }
        [Obsolete]
        public static async Task<Statuses> UntrashAsync (this IDriveResource api, GoogleApiClient apiClient)
        {
            return (await api.Untrash (apiClient)).JavaCast<Statuses> ();
        }
        [Obsolete]
        public static async Task<IDriveResourceMetadataResult> UpdateMetadataAsync (this IDriveResource api, GoogleApiClient apiClient, Android.Gms.Drive.MetadataChangeSet changeSet)
        {
            return (await api.UpdateMetadata (apiClient, changeSet)).JavaCast<IDriveResourceMetadataResult> ();
        }
    }
}


