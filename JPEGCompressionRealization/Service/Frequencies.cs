using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPEGCompressionRealization.Service
{
    public struct Frequencies : IComparable<Frequencies>
    {
        public ZerosValues zerosValues { get; set; }
        public double frequency { get; set; }

        public int CompareTo(Frequencies other)
        {
            if (this.frequency > other.frequency)
                return 1;
            else if (this.frequency < other.frequency)
                return -1;
            else return 0;
        }
    }
}
