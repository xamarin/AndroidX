using System;
using System.Linq;
using System.Collections.Generic;

namespace Android.Gms.Wearable
{
    public partial class DataEventBuffer : IEnumerable<IDataEvent>
    {
        public IEnumerator<IDataEvent> GetEnumerator()
        {
            return this.ToEnumerable<IDataEvent> ().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public partial class DataItemBuffer : IEnumerable<IDataItem>
    {
        public IEnumerator<IDataItem> GetEnumerator()
        {
            return this.ToEnumerable<IDataItem> ().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

