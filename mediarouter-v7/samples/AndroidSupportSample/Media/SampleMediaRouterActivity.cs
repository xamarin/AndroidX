
/*
 * Copyright (C) 2013 The Android Open Source Project
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Media;
using Android.Widget;
using Android.Util;
using Android.Support.V4.View;
using Android.Runtime;
using Android.Content;


namespace AndroidSupportSample
{
	[Android.App.Activity (Label = "@string/sample_media_router_activity_dark", Theme = "@style/Theme.AppCompat")]	
    public class SampleMediaRouterActivity : Android.Support.V7.App.ActionBarActivity
	{
		private static string TAG = "MediaRouterSupport";
		private static string DISCOVERY_FRAGMENT_TAG = "DiscoveryFragment";

		private MediaRouter mMediaRouter;
		private MediaRouteSelector mSelector;
		private ArrayAdapter<MediaItem> mMediaItems;
		private TextView mInfoTextView;
		private ListView mMediaListView;
		private Button mPlayButton;
		private Button mStatisticsButton;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Get the media router service.
			mMediaRouter = MediaRouter.GetInstance(this);

			// Create a route selector for the type of routes that we care about.
			mSelector = new MediaRouteSelector.Builder()
				.AddControlCategory(MediaControlIntent.CategoryLiveAudio)
				.AddControlCategory(MediaControlIntent.CategoryLiveVideo)
				.AddControlCategory(MediaControlIntent.CategoryRemotePlayback)
				.AddControlCategory(SampleMediaRouteProvider.CATEGORY_SAMPLE_ROUTE)
				.Build();

			// Add a fragment to take care of media route discovery.
			// This fragment automatically adds or removes a callback whenever the activity
			// is started or stopped.
			var fm = SupportFragmentManager;
			if (fm.FindFragmentByTag(DISCOVERY_FRAGMENT_TAG) == null) {
				DiscoveryFragment fragment = new DiscoveryFragment(this);
				fragment.RouteSelector = mSelector;
				fm.BeginTransaction()
					.Add(fragment, DISCOVERY_FRAGMENT_TAG)
					.Commit();
			}

			// Populate an array adapter with fake media items.
			string[] mediaNames = Resources.GetStringArray(Resource.Array.media_names);
			string[] mediaUris = Resources.GetStringArray(Resource.Array.media_uris);
			mMediaItems = new ArrayAdapter<MediaItem>(this,
				Android.Resource.Layout.SimpleListItemSingleChoice, Android.Resource.Id.Text1);
			for (int i = 0; i < mediaNames.Length; i++) {
				mMediaItems.Add(new MediaItem(mediaNames[i], Android.Net.Uri.Parse (mediaUris[i])));
			}

			// Initialize the layout.
			SetContentView(Resource.Layout.sample_media_router);

			mInfoTextView = FindViewById<TextView> (Resource.Id.info);

			mMediaListView = FindViewById<ListView> (Resource.Id.media);
			mMediaListView.Adapter = mMediaItems;
			mMediaListView.ChoiceMode = ChoiceMode.Single;
			mMediaListView.ItemClick += (sender, e) => {
				UpdateButtons();
			};

			mPlayButton = FindViewById<Button> (Resource.Id.play_button);
			mPlayButton.Click += (sender, e) => {
				Play ();
			};

			mStatisticsButton = FindViewById<Button>(Resource.Id.statistics_button);
			mStatisticsButton.Click += (sender, e) => {
				ShowStatistics ();
			};
		}

		override protected void OnStart() 
		{
			// Be sure to call the super class.
			base.OnStart();

			UpdateRouteDescription();
		}

		public override bool OnCreateOptionsMenu (Android.Views.IMenu menu) 
		{
			// Be sure to call the super class.
			base.OnCreateOptionsMenu(menu);

			// Inflate the menu and configure the media router action provider.
			MenuInflater.Inflate(Resource.Menu.sample_media_router_menu, menu);

			var mediaRouteMenuItem = menu.FindItem(Resource.Id.media_route_menu_item);
			var mediaRouteActionProvider =
				MenuItemCompat.GetActionProvider(mediaRouteMenuItem).JavaCast <Android.Support.V7.App.MediaRouteActionProvider> ();
			mediaRouteActionProvider.RouteSelector = mSelector;

			// Return true to show the menu.
			return true;
		}

		private void UpdateRouteDescription() {
			var route = mMediaRouter.SelectedRoute;
			mInfoTextView.Text = "Currently selected route: " + route.Name
				+ " from provider " + route.Provider.PackageName
				+ ", description: " + route.Description;
			UpdateButtons();
		}

		private void UpdateButtons() {
			MediaRouter.RouteInfo route = mMediaRouter.SelectedRoute;

			MediaItem item = CheckedMediaItem;
			if (item != null) {
				mPlayButton.Enabled = route.SupportsControlRequest(MakePlayIntent(item));
			} else {
				mPlayButton.Enabled = false;
			}

			mStatisticsButton.Enabled = route.SupportsControlRequest(MakeStatisticsIntent());
		}


		private void Play() {
			var item = CheckedMediaItem;
			if (item == null) {
				return;
			}

			var route = mMediaRouter.SelectedRoute;
			var intent = MakePlayIntent(item);
			if (route.SupportsControlRequest(intent)) {
				MediaRouterControlRequestCallback callback = new MediaRouterControlRequestCallback ();

				callback.OnResultEvent += (data) => {
					string streamId = data != null ? data.GetString( MediaControlIntent.ExtraItemId) : null;

					Log.Debug(TAG, "Play request succeeded: data=" + data + " , streamId=" + streamId);
					Toast.MakeText(this,
							"Now playing " + item.mName,
						ToastLength.Long).Show ();
				};

				callback.OnErrorEvent += (error, data) => {
					Log.Debug (TAG, "Play request failed: error=" + error + ", data=" + data);
					Toast.MakeText(this,
							"Unable to play " + item.mName + ", error: " + error,
						ToastLength.Long).Show();
				};

				Log.Debug (TAG, "Sending play request: intent=" + intent);
				route.SendControlRequest(intent, callback);
			} else {
				Log.Debug(TAG, "Play request not supported: intent=" + intent);
				Toast.MakeText(this,
					"Play not supported for " + item.mName, ToastLength.Long).Show();
			}
		}

		private void ShowStatistics() {
			MediaRouter.RouteInfo route = mMediaRouter.SelectedRoute;
			Intent intent = MakeStatisticsIntent();
			if (route.SupportsControlRequest(intent)) {
				MediaRouterControlRequestCallback callback = new MediaRouterControlRequestCallback ();

				callback.OnResultEvent += (data) => {
					Log.Debug (TAG, "Statistics request succeeded: data=" + data);
						if (data != null) {
						int playbackCount = data.GetInt(
								SampleMediaRouteProvider.DATA_PLAYBACK_COUNT, -1);
						Toast.MakeText(this,
								"Total playback count: " + playbackCount,
							ToastLength.Long).Show();
						} else {
						Toast.MakeText(this,
								"Statistics query did not return any data",
							ToastLength.Long).Show();
						}
				};

				callback.OnErrorEvent += (error, data) => {
					Log.Debug (TAG, "Statistics request failed: error=" + error + ", data=" + data);
					Toast.MakeText(this,
							"Unable to query statistics, error: " + error,
						ToastLength.Long).Show();
				};

				Log.Debug (TAG, "Sent statistics request: intent=" + intent);
				route.SendControlRequest(intent, callback);
			} else {
				Log.Debug(TAG, "Statistics request not supported: intent=" + intent);
				Toast.MakeText(this,
					"Statistics not supported.", ToastLength.Long).Show();
			}
		}

		private class MediaRouterControlRequestCallback : MediaRouter.ControlRequestCallback
		{
			public event Action <Bundle> OnResultEvent;
			public event Action <string, Bundle> OnErrorEvent;

			public override void OnResult (Bundle p0)
			{
				if (OnResultEvent != null)
					OnResultEvent (p0);
			}

			public override void OnError (string p0, Bundle p1)
			{
				if (OnErrorEvent != null)
					OnErrorEvent (p0, p1);
			}
		}


		private Intent MakePlayIntent(MediaItem item) {
			Intent intent = new Intent(MediaControlIntent.ActionPlay);
			intent.AddCategory(MediaControlIntent.CategoryRemotePlayback);
			intent.SetDataAndType(item.mUri, "video/mp4");
			return intent;
		}

		private Intent MakeStatisticsIntent() {
			Intent intent = new Intent(SampleMediaRouteProvider.ACTION_GET_STATISTICS);
			intent.AddCategory(SampleMediaRouteProvider.CATEGORY_SAMPLE_ROUTE);
			return intent;
		}

		private MediaItem CheckedMediaItem {
			get {
				int index = mMediaListView.CheckedItemPosition ;
				if (index >= 0 && index < mMediaItems.Count) {
					return mMediaItems.GetItem (index);
				}
				return null;
			}
		}
	
		private class DiscoveryFragment : MediaRouteDiscoveryFragment 
		{
			SampleMediaRouterActivity mOutterClass;

			public DiscoveryFragment (SampleMediaRouterActivity outterClass)
			{
				mOutterClass = outterClass;
			}

			override public MediaRouter.Callback OnCreateCallback () 
			{
				// Return a custom callback that will simply log all of the route events
				// for demonstration purposes.
				return new MediaRouterCallback (mOutterClass);
			}

			private class MediaRouterCallback : MediaRouter.Callback
			{
				SampleMediaRouterActivity mOutterClass;

				public MediaRouterCallback (SampleMediaRouterActivity outterClass)
				{
					mOutterClass = outterClass;
				}

				override public void OnRouteAdded(MediaRouter router, MediaRouter.RouteInfo route) 
				{
					Log.Debug (TAG, "OnRouteAdded: route=" + route);
				}

				override public void OnRouteChanged(MediaRouter router, MediaRouter.RouteInfo route) 
				{
					Log.Debug(TAG, "OnRouteChanged: route=" + route);
					mOutterClass.UpdateRouteDescription();
				}

				override public void OnRouteRemoved(MediaRouter router, MediaRouter.RouteInfo route) 
				{
					Log.Debug(TAG, "OnRouteRemoved: route=" + route);
				}

				override public void OnRouteSelected(MediaRouter router, MediaRouter.RouteInfo route) 
				{
					Log.Debug(TAG, "OnRouteSelected: route=" + route);
					mOutterClass.UpdateRouteDescription();
				}

				override public void OnRouteUnselected(MediaRouter router, MediaRouter.RouteInfo route) 
				{
					Log.Debug(TAG, "OnRouteUnselected: route=" + route);
					mOutterClass.UpdateRouteDescription();
				}

				override public void OnRouteVolumeChanged(MediaRouter router, MediaRouter.RouteInfo route) 
				{
					Log.Debug(TAG, "OnRouteVolumeChanged: route=" + route);
				}

				override public void OnRoutePresentationDisplayChanged(MediaRouter router, MediaRouter.RouteInfo route)
				{
					Log.Debug(TAG, "OnRoutePresentationDisplayChanged: route=" + route);
				}
			}

			override public int OnPrepareCallbackFlags() {
				// Add the CALLBACK_FLAG_UNFILTERED_EVENTS flag to ensure that we will
				// observe and log all route events including those that are for routes
				// that do not match our selector.  This is only for demonstration purposes
				// and should not be needed by most applications.
				return base.OnPrepareCallbackFlags()
					| MediaRouter.CallbackFlagUnfilteredEvents;
			}
		}

		class MediaItem 
		{
			public string mName;
			public Android.Net.Uri mUri;

			public MediaItem(String name, Android.Net.Uri uri) {
				mName = name;
				mUri = uri;
			}

			public override string ToString ()
			{
				return mName;
			}
		}

		/**
	     * Trivial subclass of this activity used to provide another copy of the
	     * same activity using a light theme instead of the dark theme.
	     */
		[Android.App.Activity (Label = "@string/sample_media_router_activity_light", Theme = "@style/Theme.AppCompat.Light")]	
		public class Light : SampleMediaRouterActivity 
		{
		}

		/*	*
	     * Trivial subclass of this activity used to provide another copy of the
	     * same activity using a light theme with dark action bar instead of the dark theme.
	     */
		[Android.App.Activity (Label = "@string/sample_media_router_activity_light_with_dark_action_bar", Theme = "@style/Theme.AppCompat.Light.DarkActionBar")]	
		public class LightWithDarkActionBar : SampleMediaRouterActivity 
		{
		}
	}
}

