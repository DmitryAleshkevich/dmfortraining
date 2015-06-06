using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Checkpoint3Billing
{
    public abstract class TariffPlan
    {
        public double MonthlyFee { get; protected set; }
        public int FreeMinutes { get; protected set; }
        public double CallCost { get; protected set; }
        
        public TariffPlan(double monthlyFee, int freeMinutes, double callCost)
        {
            this.MonthlyFee = monthlyFee;
            this.FreeMinutes = freeMinutes;
            this.CallCost = callCost;
        }        
    }
}
