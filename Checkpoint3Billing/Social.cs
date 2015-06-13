using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Checkpoint3Billing
{
    public class Social : TariffPlan
    {
        public Social(double monthlyFee, int freeMinutes, double callCost, string name)
            : base(monthlyFee, freeMinutes, callCost, name) { this.MonthlyFee = 0; }
    }
}
