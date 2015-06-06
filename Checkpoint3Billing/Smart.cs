using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Checkpoint3Billing
{
    public class Smart : TariffPlan
    {
        public int InternetTraffic { get; private set; }

        public Smart(int internetTraffic, double monthlyFee, int freeMinutes, double callCost)
            : base(monthlyFee, freeMinutes, callCost)
        {
            this.InternetTraffic = internetTraffic;
        }
    }
}
