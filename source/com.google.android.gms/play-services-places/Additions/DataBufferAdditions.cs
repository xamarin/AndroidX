using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Android.Gms.Location.Places
{
    public partial class AutocompletePredictionBuffer : IEnumerable<IAutocompletePrediction>
    {
        public IEnumerator<IAutocompletePrediction> GetEnumerator()
        {
            return this.ToEnumerable<IAutocompletePrediction> ().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public partial class PlaceBuffer : IEnumerable<IPlace>
    {
        public IEnumerator<IPlace> GetEnumerator()
        {
            return this.ToEnumerable<IPlace> ().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public partial class PlaceLikelihoodBuffer : IEnumerable<IPlaceLikelihood>
    {
        public IEnumerator<IPlaceLikelihood> GetEnumerator()
        {
            return this.ToEnumerable<IPlaceLikelihood> ().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public partial class PlacePhotoMetadataBuffer : IEnumerable<IPlacePhotoMetadata>
    {
        public IEnumerator<IPlacePhotoMetadata> GetEnumerator()
        {
            return this.ToEnumerable<IPlacePhotoMetadata> ().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

