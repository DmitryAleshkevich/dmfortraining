using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Checkpoint3Billing
{
    public class AbonentAnswerEventArgs : EventArgs
    {
        public AbonentAnswerEventArgs(CallState callState)
        {
            CallState = callState;
        }

        public CallState CallState { get; private set; }
    }
}
