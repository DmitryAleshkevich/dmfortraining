using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Checkpoint3Billing
{
    public class AbonentNumber
    {
        public int Number { get; private set; }
        public string TextName { get; private set; }

        public AbonentNumber(int number, string name)
        {
            Number = number;
            TextName = name;
        }
    }
}
