using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Checkpoint3Billing
{
    public class Contract
    {
        public Abonent TheAbonent { get; private set; }
        public TariffPlanHistory PlanHistory { get; private set; }
        public double Balance { get; private set; }

        public void Pay(double sum)
        {

        }

        public Contract(Abonent abonent, TariffPlanHistory planHistory)
        {
            this.TheAbonent = abonent;
            this.PlanHistory = planHistory;
            this.Balance = 0;
        }
    }
}
