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

        #region Methods
        public void Pay(double sum)
        {
            this.Balance += sum;
        }

        public void CreatePlanHistory(DateTime date, TariffPlan tp)
        {
            this.PlanHistory = new TariffPlanHistory(this.TheAbonent, date, tp);
        }

        public string ChangePlan(DateTime date, TariffPlan tp)
        {
            return PlanHistory != null ? PlanHistory.ChangePlan(date, tp) : "Couldn`t change plan, cause of contract wasn`t signed!";
        }
        #endregion

        public Contract(Abonent abonent)
        {
            TheAbonent = abonent;            
        }
    }
}
