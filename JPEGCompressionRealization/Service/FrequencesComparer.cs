using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPEGCompressionRealization.Service
{
    public class FrequencesComparer : IEqualityComparer<Frequencies>
    {
        public bool Equals(Frequencies x, Frequencies y)
        {
            if (Object.ReferenceEquals(x, y))
                return true;

            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            if ((x.frequency == y.frequency) && (x.zerosValues.Values == y.zerosValues.Values) && (x.zerosValues.Zeros == y.zerosValues.Zeros))
                return true;

            return false;
        }

        public int GetHashCode(Frequencies obj)
        {
            if (Object.ReferenceEquals(obj, null)) return 0;

            var hashcode = obj.zerosValues.Values.GetHashCode() + obj.zerosValues.Zeros.GetHashCode() + obj.frequency.GetHashCode();

            return hashcode;
        }
    }
}
