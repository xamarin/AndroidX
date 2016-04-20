using System;
using System.Collections.Generic;
using Android.Content;
using System.IO;
using System.Runtime.Serialization.Json;

namespace AndroidLeanbackSample
{
	public class VideoResponse 
	{
		public List<Video> Videos { get;set; }
	}

	public class Video : Java.Lang.Object
	{
		public Video ()
		{
		}

		/*
		 * "title": "Buttons are a Hack",
            "id": "Pug7CCVz-18",
            "type": "youtube",
            "datePublished": "02/27/2014",
            "platforms": "cross-platform",
            "categories": "Evolve",
            "brief": "Josh Clark specializes in mobile design strategy and user experience. He is the founder of Global Moxie and the author of four books, including Tapworthy: Designing Great iPhone Apps. In his Evolve session, titled 'Buttons are a Hack' Josh will talk about how touch gestures are sweeping away buttons, menus and windows from mobile devices and how you can craft touchscreen interfaces that effortlessly teach users new gesture vocabularies",
            "by": "Josh Clark",
            "relativePath": "/videos/cross-platform/Evolve-Buttons-are-a-hack"*/

		public string Title { get;set; }
		public string Id { get;set; }
		public string Type { get;set; }
		public string DatePublished { get;set; }
		public string Platforms { get;set; }
		public string Categories { get;set; }
		public string Brief { get;set; }
		public string By { get;set; }
		public string RelativePath { get;set; }

		public static List<Video> GetVideos (Context context)
		{
			var videos = new List<Video> ();

			var serializer = new DataContractJsonSerializer (typeof(VideoResponse));

			var data = string.Empty;
			using (var sr = new StreamReader (context.Resources.Assets.Open ("xamarin.videos.json")))
				data = sr.ReadToEnd ();

			var json = System.Json.JsonObject.Parse (data);

			foreach (var item in (System.Json.JsonArray)json ["videos"]) {
				var v = new Video ();
				v.Title = item ["title"];
				v.Id = item ["id"];
				v.Type = item ["type"];
				v.DatePublished = item ["datePublished"];
				v.Platforms = item ["platforms"];
				v.Categories = item ["categories"];
				v.Brief = item ["brief"];
				v.By = item ["by"];
				v.RelativePath = item ["relativePath"];

				videos.Add (v);
			}

			return videos;
		}
	}
}

