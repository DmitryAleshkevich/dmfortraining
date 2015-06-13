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
        public Ats Ats { get; protected set; }
        public string Name { get; protected set; }

        protected TariffPlan(double monthlyFee, int freeMinutes, double callCost, string name)
        {
            MonthlyFee = monthlyFee;
            FreeMinutes = freeMinutes;
            CallCost = callCost;
            Name = name;
        }        
    }
}
