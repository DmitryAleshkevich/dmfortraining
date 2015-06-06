using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Checkpoint3Billing
{
    public class Social : TariffPlan
    {
        public Social(double monthlyFee, int freeMinutes, double callCost)
            : base(monthlyFee, freeMinutes, callCost) { this.MonthlyFee = 0; }
    }
}
