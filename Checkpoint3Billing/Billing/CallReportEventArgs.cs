using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Checkpoint3Billing
{
    public class CallReportEventArgs : EventArgs
    {
        public CallReportEventArgs(Contract contract, Func<Call, bool> selector, DateTime endTime, DateTime startTime)
        {
            Contract = contract;
            Selector = selector;
            EndTime = endTime;
            StartTime = startTime;
        }

        public Contract Contract { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public Func<Call, bool> Selector { get; private set; } 
    }
}
