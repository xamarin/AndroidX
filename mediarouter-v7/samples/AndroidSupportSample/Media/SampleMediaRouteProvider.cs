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
using Android.Support.V7.Media;
using Android.Content;
using System.Collections.Generic;
using Java.Lang;

namespace AndroidSupportSample
{
	/**
	 * Demonstrates how to create a custom media route provider.
	 *
	 * @see SampleMediaRouteProviderService
	 */
	class SampleMediaRouteProvider : MediaRouteProvider
	{
		private static string TAG = "SampleMediaRouteProvider";
		private static string FIXED_VOLUME_ROUTE_ID = "fixed";
		private static string VARIABLE_VOLUME_ROUTE_ID = "variable";
		private static int VOLUME_MAX = 10;
		/**
	     * A custom media control intent category for special requests that are
	     * supported by this provider's routes.
	     */
		public static string CATEGORY_SAMPLE_ROUTE =
			"com.example.android.supportv7.media.CATEGORY_SAMPLE_ROUTE";
		/**
	     * A custom media control intent action for special requests that are
	     * supported by this provider's routes.
	     * <p>
	     * This particular request is designed to return a bundle of not very
	     * interesting statistics for demonstration purposes.
	     * </p>
	     *
	     * @see #DATA_PLAYBACK_COUNT
	     */
		public static string ACTION_GET_STATISTICS =
			"com.example.android.supportv7.media.ACTION_GET_STATISTICS";
		/*	*
	     * {@link #ACTION_GET_STATISTICS} result data: Number of times the
	     * playback action was invoked.
	     */
		public static string DATA_PLAYBACK_COUNT =
			"com.example.android.supportv7.media.EXTRA_PLAYBACK_COUNT";
		private static List<IntentFilter> CONTROL_FILTERS;

		static SampleMediaRouteProvider ()
		{
			IntentFilter f1 = new IntentFilter ();
			f1.AddCategory (CATEGORY_SAMPLE_ROUTE);
			f1.AddAction (ACTION_GET_STATISTICS);

			IntentFilter f2 = new IntentFilter ();
			f2.AddCategory (MediaControlIntent.CategoryRemotePlayback);
			f2.AddAction (MediaControlIntent.ActionPlay);
			f2.AddDataScheme ("http");
			f2.AddDataScheme ("https");
			addDataTypeUnchecked (f2, "video/*");

			CONTROL_FILTERS = new List<IntentFilter> ();
			CONTROL_FILTERS.Add (f1);
			CONTROL_FILTERS.Add (f2);
		}

		private static void addDataTypeUnchecked (IntentFilter filter, string type)
		{
			try {
				filter.AddDataType (type);
			} catch (Android.Content.IntentFilter.MalformedMimeTypeException ex) {
				throw new RuntimeException (ex);
			}
		}

		private int mVolume = 5;
		private int mPlaybackCount;

		public SampleMediaRouteProvider (Context context) : base (context)
		{

			PublishRoutes ();
		}

		override public RouteController OnCreateRouteController (string routeId)
		{
			return new SampleRouteController (this, routeId);
		}

		private void PublishRoutes ()
		{
			var r = Context.Resources;

			MediaRouteDescriptor routeDescriptor1 = new MediaRouteDescriptor.Builder (
				                                        FIXED_VOLUME_ROUTE_ID,
				                                        r.GetString (Resource.String.fixed_volume_route_name))
				.SetDescription (r.GetString (Resource.String.sample_route_description))
				.AddControlFilters (CONTROL_FILTERS)
				.SetPlaybackType (MediaRouter.RouteInfo.PlaybackTypeRemote)
				.SetVolumeHandling (MediaRouter.RouteInfo.PlaybackVolumeFixed)
				.SetVolume (VOLUME_MAX)
				.Build ();

			MediaRouteDescriptor routeDescriptor2 = new MediaRouteDescriptor.Builder (
				                                        VARIABLE_VOLUME_ROUTE_ID,
				                                        r.GetString (Resource.String.variable_volume_route_name))
				.SetDescription (r.GetString (Resource.String.sample_route_description))
				.AddControlFilters (CONTROL_FILTERS)
				.SetPlaybackType (MediaRouter.RouteInfo.PlaybackTypeRemote)
				.SetVolumeHandling (MediaRouter.RouteInfo.PlaybackVolumeVariable)
				.SetVolumeMax (VOLUME_MAX)
				.SetVolume (mVolume)
				.Build ();

			MediaRouteProviderDescriptor providerDescriptor =
				new MediaRouteProviderDescriptor.Builder ()
					.AddRoute (routeDescriptor1)
					.AddRoute (routeDescriptor2)
					.Build ();
			Descriptor = providerDescriptor;
		}

		private string GenerateStreamId ()
		{
			return Java.Util.UUID.RandomUUID ().ToString ();
		}

		private class SampleRouteController : MediaRouteProvider.RouteController
		{
			private string mRouteId;
			private SampleMediaRouteProvider mOutterClass;

			public SampleRouteController (SampleMediaRouteProvider outterClass, string routeId)
			{
				mOutterClass = outterClass;
				mRouteId = routeId;
				Android.Util.Log.Debug (TAG, mRouteId + ": Controller created");
			}

			override public void OnRelease ()
			{
				Android.Util.Log.Debug (TAG, mRouteId + ": Controller released");
			}

			override public void OnSelect ()
			{
				Android.Util.Log.Debug (TAG, mRouteId + ": Selected");
			}

			override public void OnUnselect ()
			{
				Android.Util.Log.Debug (TAG, mRouteId + ": Unselected");
			}

			override public void OnSetVolume (int volume)
			{
				Android.Util.Log.Debug (TAG, mRouteId + ": Set volume to " + volume);
				if (mRouteId.Equals (VARIABLE_VOLUME_ROUTE_ID)) {
					setVolumeInternal (volume);
				}
			}

			override public void OnUpdateVolume (int delta)
			{
				Android.Util.Log.Debug (TAG, mRouteId + ": Update volume by " + delta);
				if (mRouteId.Equals (VARIABLE_VOLUME_ROUTE_ID)) {
					setVolumeInternal (mOutterClass.mVolume + delta);
				}
			}

			private void setVolumeInternal (int volume)
			{
				if (volume >= 0 && volume <= VOLUME_MAX) {
					mOutterClass.mVolume = volume;
					Android.Util.Log.Debug (SampleMediaRouteProvider.TAG, mRouteId + ": New volume is " + mOutterClass.mVolume);
					mOutterClass.PublishRoutes ();
				}
			}

			override public bool OnControlRequest (Intent intent, Android.Support.V7.Media.MediaRouter.ControlRequestCallback callback)
			{
				Android.Util.Log.Debug (TAG, mRouteId + ": Received control request " + intent);
				if (intent.Action.Equals (MediaControlIntent.ActionPlay)
				    && intent.HasCategory (MediaControlIntent.CategoryRemotePlayback)
				    && intent.Data != null) {
					mOutterClass.mPlaybackCount += 1;

					// TODO: Handle queue ids.
					var uri = intent.Data;
					long contentPositionMillis = intent.GetLongExtra (
						                             MediaControlIntent.ExtraItemContentPosition, 0);
					var metadata = intent.GetBundleExtra (MediaControlIntent.ExtraItemMetadata);
					var headers = intent.GetBundleExtra (
						              MediaControlIntent.ExtraItemHttpHeaders);

					Android.Util.Log.Debug (TAG, mRouteId + ": Received play request, uri=" + uri
					+ ", contentPositionMillis=" + contentPositionMillis
					+ ", metadata=" + metadata
					+ ", headers=" + headers);

					if (uri.ToString ().Contains ("hats")) {
						// Simulate generating an error whenever the uri contains the word 'hats'.
						Android.Widget.Toast.MakeText (mOutterClass.Context, "Route rejected play request: uri=" + uri
						+ ", no hats allowed!", Android.Widget.ToastLength.Long).Show ();
						if (callback != null) {
							callback.OnError ("Simulated error.  No hats allowed!", null);
						}
					} else {
						Android.Widget.Toast.MakeText (mOutterClass.Context, "Route received play request: uri=" + uri,
							Android.Widget.ToastLength.Long).Show ();
						string streamId = mOutterClass.GenerateStreamId ();
						if (callback != null) {
							MediaItemStatus status = new MediaItemStatus.Builder (
								                         MediaItemStatus.PlaybackStatePlaying)
								.SetContentPosition (contentPositionMillis)
								.Build ();

							var result = new Android.OS.Bundle ();
							result.PutString (MediaControlIntent.ExtraItemId, streamId);
							result.PutString (MediaControlIntent.ExtraItemStatus, status.AsBundle ().ToString ());
							callback.OnResult (result);
						}
					}
					return true;
				}

				if (intent.Action.Equals (ACTION_GET_STATISTICS)
				    && intent.HasCategory (CATEGORY_SAMPLE_ROUTE)) {
					var data = new Android.OS.Bundle ();
					data.PutInt (DATA_PLAYBACK_COUNT, mOutterClass.mPlaybackCount);
					if (callback != null) {
						callback.OnResult (data);
					}
					return true;
				}


				return false;
			}
		}
	}
}

