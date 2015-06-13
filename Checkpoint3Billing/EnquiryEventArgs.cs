using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Checkpoint3Billing
{
    public class EnquiryEventArgs : EventArgs
    {
        public EnquiryEventArgs(Func<TariffPlan, bool> selector)
        {
            Selector = selector;
        }

        public Func<TariffPlan, bool> Selector { get; private set; }  
    }
}
