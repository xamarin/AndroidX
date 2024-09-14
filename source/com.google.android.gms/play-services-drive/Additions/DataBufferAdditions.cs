using System;
using System.Linq;
using System.Collections.Generic;

namespace Android.Gms.Drive
{
    public partial class MetadataBuffer : IEnumerable<Metadata>
    {
        public IEnumerator<Metadata> GetEnumerator()
        {
            return this.ToEnumerable<Metadata> ().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

