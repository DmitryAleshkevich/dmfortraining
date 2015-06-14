using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Checkpoint3Billing
{
    public class CallEventArgs : EventArgs
    {
        public CallEventArgs(Abonent abonent)
        {
            Abonent = abonent;
        }

        public Abonent Abonent { get; private set; }
    }
}
