using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;

namespace Xamarin.GooglePlayServices.Tasks
{
    [DataContract]
    [Serializable]
    public class ProjectInfo
    {
        [DataMember (Name="project_id")]
        public string ProjectId { get; set; }
        [DataMember (Name="project_number")]
        public string ProjectNumber { get; set; }
        [DataMember (Name="name")]
        public string Name { get; set; }
        [DataMember (Name="firebase_url")]
        public string FirebaseUrl { get; set; }
        [DataMember (Name="storage_bucket")]
        public string StorageBucket { get; set; }
    }

    [DataContract]
    [Serializable]
    public class AndroidClientInfo
    {
        [DataMember (Name="package_name")]
        public string PackageName { get; set; }
        [DataMember (Name="certificate_hash")]
        public List<string> CertificateHash { get; set; }
    }

    [DataContract]
    [Serializable]
    public class ClientInfo
    {
        [DataMember (Name="mobilesdk_app_id")]
        public string MobileSdkAppId { get; set; }
        [DataMember (Name="client_id")]
        public string ClientId { get; set; }
        [DataMember (Name="client_type")]
        public int ClientType { get; set; }
        [DataMember (Name="android_client_info")]
        public AndroidClientInfo AndroidClientInfo { get; set; }
    }

    [DataContract]
    [Serializable]
    public class AndroidInfo
    {
        [DataMember (Name="package_name")]
        public string PackageName { get; set; }
        [DataMember (Name="certificate_hash")]
        public string CertificateHash { get; set; }
    }

    [DataContract]
    [Serializable]
    public class OauthClient
    {
        [DataMember (Name="client_id")]
        public string ClientId { get; set; }
        [DataMember (Name="client_type")]
        public int ClientType { get; set; }
        [DataMember (Name="android_info")]
        public AndroidInfo AndroidInfo { get; set; }
    }

    [DataContract]
    [Serializable]
    public class AnalyticsProperty
    {
        [DataMember (Name="tracking_id")]
        public string TrackingId { get; set; }
    }

    [DataContract]
    [Serializable]
    public class AnalyticsService
    {
        [DataMember (Name="status")]
        public int Status { get; set; }
        [DataMember (Name="analytics_property")]
        public AnalyticsProperty AnalyticsProperty { get; set; }
    }

    [DataContract]
    [Serializable]
    public class CloudMessagingService
    {
        [DataMember (Name="status")]
        public int Status { get; set; }
        [DataMember (Name="apns_config")]
        public List<object> ApnsConfig { get; set; }
    }

    [DataContract]
    [Serializable]
    public class IosInfo
    {
        [DataMember (Name="bundle_id")]
        public string BundleId { get; set; }
        [DataMember (Name="app_store_id")]
        public string AppStoreId { get; set; }
    }

    [DataContract]
    [Serializable]
    public class OtherPlatformOauthClient
    {
        [DataMember (Name="client_id")]
        public string ClientId { get; set; }
        [DataMember (Name="client_type")]
        public int ClientType { get; set; }
        [DataMember (Name="ios_info")]
        public IosInfo IosInfo { get; set; }
    }

    [DataContract]
    [Serializable]
    public class AppinviteService
    {
        [DataMember (Name="status")]
        public int Status { get; set; }
        [DataMember (Name="other_platform_oauth_client")]
        public List<OtherPlatformOauthClient> OtherPlatformOauthClient { get; set; }
    }

    [DataContract]
    [Serializable]
    public class GoogleSigninService
    {
        [DataMember (Name="status")]
        public int Status { get; set; }
    }

    [DataContract]
    [Serializable]
    public class AdsService
    {
        [DataMember (Name="status")]
        public int Status { get; set; }
        [DataMember (Name="test_banner_ad_unit_id")]
        public string TestBannerAdUnitId { get; set; }
        [DataMember (Name="test_interstitial_ad_unit_id")]
        public string TestInterstitialAdUnitId { get; set; }
    }

    [DataContract]
    [Serializable]
    public class Services
    {
        [DataMember (Name="analytics_service")]
        public AnalyticsService AnalyticsService { get; set; }
        [DataMember (Name="cloud_messaging_service")]
        public CloudMessagingService CloudMessagingService { get; set; }
        [DataMember (Name="appinvite_service")]
        public AppinviteService AppInviteService { get; set; }
        [DataMember (Name="google_signin_service")]
        public GoogleSigninService GoogleSignInService { get; set; }
        [DataMember (Name="ads_service")]
        public AdsService AdsService { get; set; }
    }

    [DataContract]
    [Serializable]
    public class Client
    {
        [DataMember (Name="client_info")]
        public ClientInfo ClientInfo { get; set; }
        [DataMember (Name="oauth_client")]
        public List<OauthClient> OauthClient { get; set; }
        [DataMember (Name="api_key")]
        public List<ApiKey> ApiKey { get; set; }
        [DataMember (Name="services")]
        public Services Services { get; set; }
    }

    [DataContract]
    [Serializable]
    public class ApiKey
    {
        [DataMember (Name = "current_key")]
        public string CurrentKey { get; set; }
    }

    [DataContract]
    [Serializable]
    public class GoogleServices
    {
        [DataMember (Name="project_info")]
        public ProjectInfo ProjectInfo { get; set; }
        [DataMember (Name="client")]
        public List<Client> Client { get; set; }
        [DataMember (Name="client_info")]
        public List<object> ClientInfo { get; set; }
        [DataMember (Name="ARTIFACT_VERSION")]
        public string ArtifactVersion { get; set; }

        public Client GetClient (string packageName)
        {
            if (Client == null || !Client.Any ())
                return null;

            return Client.FirstOrDefault (c => c.ClientInfo.AndroidClientInfo.PackageName == packageName);
        }

        public string GetGATrackingId (string packageName)
        {
            //{YOUR_CLIENT}/services/analytics-service/analytics_property/tracking_id
            var client = GetClient (packageName);
            if (client == null)
                return null;

            if (client.Services != null && client.Services.AnalyticsService != null && client.Services.AnalyticsService.AnalyticsProperty != null)
                return client.Services.AnalyticsService.AnalyticsProperty.TrackingId;

            return null;
        }

        public string GetDefaultGcmSenderId ()
        {
            // project_info/project_number
            if (ProjectInfo != null)
                return ProjectInfo.ProjectNumber;

            return null;
        }

        public string GetGoogleAppId (string packageName)
        {
            // {YOUR_CLIENT}/client_info/mobilesdk_app_id
            var client = GetClient (packageName);
            if (client == null)
                return null;

            if (client.ClientInfo != null)
                return client.ClientInfo.MobileSdkAppId;

            return null;
        }

        public string GetTestBannerAdUnitId (string packageName)
        {
            //{YOUR_CLIENT}/services/ads_service/test_banner_ad_unit_id
            var client = GetClient (packageName);
            if (client == null)
                return null;

            if (client.Services != null && client.Services.AdsService != null)
                return client.Services.AdsService.TestBannerAdUnitId;

            return null;
        }

        public string GetTestInterstitialAdUnitId (string packageName)
        {
            //{YOUR_CLIENT}/services/ads_service/test_interstitial_ad_unit_id
            var client = GetClient (packageName);
            if (client == null)
                return null;

            if (client.Services != null && client.Services.AdsService != null)
                return client.Services.AdsService.TestInterstitialAdUnitId;

            return null;
        }

        public string GetDefaultWebClientId (string packageName)
        {
            // default_web_client_id:
            // {YOUR_CLIENT}/oauth_client/client_id(client_type == 3)

            var client = GetClient (packageName);
            if (client == null)
                return null;

            if (client.OauthClient != null && client.OauthClient.Any ()) {
                var oauthClient = client.OauthClient.FirstOrDefault (c => c.ClientType == 3);
                if (oauthClient != null)
                    return oauthClient.ClientId;
            }

            return null;
        }

        public string GetGoogleApiKey (string packageName)
        {
            // google_api_key:
            // {YOUR_CLIENT}/api_key/current_key

            var client = GetClient (packageName);
            if (client == null)
                return null;

            if (client.ApiKey != null && client.ApiKey.Any ())
                return client.ApiKey.FirstOrDefault ().CurrentKey;

            return null;
        }

        public string GetFirebaseDatabaseUrl ()
        {
            // firebase_database_url:
            // project_info/firebase_url

            if (ProjectInfo != null)
                return ProjectInfo.FirebaseUrl;

            return null;
        }

        public string GetCrashReportingApiKey (string packageName)
        {
            // google_crash_reporting_api_key:
            // {YOUR_CLIENT}/api_key/current_key

            var client = GetClient (packageName);
            if (client == null)
                return null;

            if (client.ApiKey != null && client.ApiKey.Any ())
                return client.ApiKey.FirstOrDefault ().CurrentKey;

            return null;
        }

        public string GetStorageBucket (string packageName)
        {
            // google_storage_bucket:
            // project_info/storage_bucket
            if (ProjectInfo != null)
                return ProjectInfo.StorageBucket;

            return null;
        }
    }
}

