using System;
using System.Linq;
using System.Collections.Generic;


namespace Android.Gms.Plus.Model.People
{
    public partial class PersonBuffer : IEnumerable<IPerson>
    {
        public IEnumerator<IPerson> GetEnumerator()
        {
            return this.ToEnumerable<IPerson> ().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

