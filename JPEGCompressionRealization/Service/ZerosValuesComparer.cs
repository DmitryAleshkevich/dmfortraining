using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPEGCompressionRealization.Service
{
    public class ZerosValuesComparer : IEqualityComparer<ZerosValues>
    {
        public bool Equals(ZerosValues x, ZerosValues y)
        {
            if (Object.ReferenceEquals(x, y))
                return true;

            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            if ((x.Values == y.Values) && (x.Zeros == y.Zeros))
                return true;

            return false;
        }

        public int GetHashCode(ZerosValues obj)
        {
            if (Object.ReferenceEquals(obj, null)) return 0;
            
            var hashcode = obj.Values.GetHashCode() + obj.Zeros.GetHashCode();
            
            return hashcode;
        }
    }
}
