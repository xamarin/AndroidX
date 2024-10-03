using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Xamarin.GooglePlayServices.Tasks
{
    public class GoogleServicesJsonProcessor
    {
        public GoogleServicesJsonProcessor ()
        {
        }

        public static GoogleServices ProcessJson (string packageName, Stream json)
        {
            GoogleServices googleServices;

            var serializer = new DataContractJsonSerializer (typeof (GoogleServices));
            googleServices = serializer.ReadObject (json) as GoogleServices;
            if (googleServices == null)
                throw new NullReferenceException ();
            return googleServices;
        }
    }
}

