using System;
using System.Threading.Tasks;
using Android.Content;
using Android.Gms.Drive.Events;
using Android.Gms.Extensions;

namespace Android.Gms.Drive
{
    public partial class DriveClient
    {
        public Task<DriveId> GetDriveIdAsync (String s)
        {
            return GetDriveId (s).AsAsync<DriveId> ();
        }

        public Task<ITransferPreferences> GetUploadPreferencesAsync ()
        {
            return GetUploadPreferences ().AsAsync<ITransferPreferences> ();
        }

        //public Task<IntentSender> NewCreateFileActivityIntentSenderAsync (CreateFileActivityOptions options)
        //{
        //    return NewCreateFileActivityIntentSender (options).AsAsync<IntentSender> ();
        //}

        public Task<IntentSender> NewOpenFileActivityIntentSenderAsync (OpenFileActivityOptions options)
        {
            return NewOpenFileActivityIntentSender (options).AsAsync<IntentSender> ();
        }

        public Task RequestSyncAsync ()
        {
            return RequestSync ().AsAsync ();
        }

        public Task SetUploadPreferencesAsync (ITransferPreferences transferPrefs)
        {
            return SetUploadPreferences (transferPrefs).AsAsync ();
        }
    }

    public partial class DriveResourceClient
    {
        public Task<IListenerToken> AddChangeListenerAsync (IDriveResource driveResource, IOnChangeListener changeListener)
        {
            return AddChangeListener (driveResource, changeListener).AsAsync<IListenerToken> ();
        }

        public Task AddChangeSubscriptionAsync (IDriveResource driveResource)
        {
            return AddChangeSubscription (driveResource).AsAsync ();
        }

        public Task<Java.Lang.Boolean> CancelOpenFileCallbackAsync (IListenerToken listenerToken)
        {
            return CancelOpenFileCallback (listenerToken).AsAsync<Java.Lang.Boolean> ();
        }

        public Task CommitContentsAsync (IDriveContents driveContents, MetadataChangeSet metadataChangeSet)
        {
            return CommitContents (driveContents, metadataChangeSet).AsAsync ();
        }

        public Task CommitContentsAsync (IDriveContents driveContents, MetadataChangeSet metadataChangeSet, ExecutionOptions executionOptions)
        {
            return CommitContents (driveContents, metadataChangeSet, executionOptions).AsAsync ();
        }

        public Task<IDriveContents> CreateContentsAsync ()
        {
            return CreateContents ().AsAsync<IDriveContents> ();
        }

        public Task<IDriveFile> CreateFileAsync (IDriveFolder driveFolder, MetadataChangeSet metadataChangeSet, IDriveContents driveContents)
        {
            return CreateFile (driveFolder, metadataChangeSet, driveContents).AsAsync<IDriveFile> ();
        }

        public Task<IDriveFile> CreateFileAsync (IDriveFolder driveFolder, MetadataChangeSet metadataChangeSet, IDriveContents driveContents, ExecutionOptions executionOptions)
        {
            return CreateFile (driveFolder, metadataChangeSet, driveContents, executionOptions).AsAsync<IDriveFile> ();
        }

        public Task<IDriveFolder> CreateFolderAsync (IDriveFolder driveFolder, MetadataChangeSet metadataChangeSet)
        {
            return CreateFolder (driveFolder, metadataChangeSet).AsAsync<IDriveFolder> ();
        }

        public Task DeleteAsync (IDriveResource driveResource)
        {
            return Delete (driveResource).AsAsync ();
        }

        public Task DiscardContentsAsync (IDriveContents driveResource)
        {
            return DiscardContents (driveResource).AsAsync ();
        }

        public Task<IDriveFolder> GetAppFolderAsync ()
        {
            return GetAppFolder ().AsAsync<IDriveFolder> ();
        }

        public Task<Metadata> GetMetadataAsync (IDriveResource driveResource)
        {
            return GetMetadata (driveResource).AsAsync<Metadata> ();
        }

        public Task<IDriveFolder> GetRootFolderAsync ()
        {
            return GetRootFolder ().AsAsync<IDriveFolder> ();
        }

        public Task<MetadataBuffer> ListChildrenAsync (IDriveFolder driveFolder)
        {
            return ListChildren (driveFolder).AsAsync<MetadataBuffer> ();
        }

        public Task<MetadataBuffer> ListParentsAsync (IDriveResource driveResource)
        {
            return ListParents (driveResource).AsAsync<MetadataBuffer> ();
        }

        public Task<IDriveContents> OpenFileAsync (IDriveFile file, int i)
        {
            return OpenFile (file, i).AsAsync<IDriveContents> ();
        }

        public Task<IListenerToken> OpenFileAsync (IDriveFile file, int i, OpenFileCallback callback)
        {
            return OpenFile (file, i, callback).AsAsync<IListenerToken> ();
        }

        public Task<MetadataBuffer> QueryAsync (Query.QueryClass query)
        {
            return Query (query).AsAsync<MetadataBuffer> ();
        }

        public Task<MetadataBuffer> QueryChildrenAsync (IDriveFolder folder, Query.QueryClass query)
        {
            return QueryChildren (folder, query).AsAsync<MetadataBuffer> ();
        }

        public Task<Java.Lang.Boolean> RemoveChangeListenerAsync (IListenerToken listenerToken)
        {
            return RemoveChangeListener (listenerToken).AsAsync<Java.Lang.Boolean> ();
        }

        public Task RemoveChangeSubscriptionAsync (IDriveResource driveResource)
        {
            return RemoveChangeSubscription (driveResource).AsAsync ();
        }

        public Task<IDriveContents> ReopenContentsForWriteAsync (IDriveContents contents)
        {
            return ReopenContentsForWrite (contents).AsAsync<IDriveContents> ();
        }

        public Task SetParentsAsync (IDriveResource driveResource, System.Collections.Generic.ICollection<DriveId> ids)
        {
            return SetParents (driveResource, ids).AsAsync ();
        }

        public Task TrashAsync (IDriveResource driveResource)
        {
            return Trash (driveResource).AsAsync ();
        }

        public Task UntrashAsync (IDriveResource driveResource)
        {
            return Untrash (driveResource).AsAsync ();
        }

        public Task<Metadata> UpdateMetadataAsync (IDriveResource driveResource, MetadataChangeSet metadataChangeSet)
        {
            return UpdateMetadata (driveResource, metadataChangeSet).AsAsync<Metadata> ();
        }
    }
}
