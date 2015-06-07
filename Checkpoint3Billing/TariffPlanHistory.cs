using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Checkpoint3Billing
{
    public class TariffPlanHistory
    {
        public Dictionary<DateTime, TariffPlan> History { get; private set; }
        public Abonent TheAbonent { get; private set; }

        public KeyValuePair<DateTime, TariffPlan> LastHistoryChange
        {
            get
            {
                return History.Last();
            }
        }

        public string ChangePlan(DateTime date, TariffPlan tp)
        {
            if (date.Month - this.LastHistoryChange.Key.Month > 0)
            {
                this.History.Add(date, tp);
                return "Success";
            }
            else
            {
                return "Error! You can`t change plan in this month!";
            }
        }

        public TariffPlanHistory(Abonent abonent, DateTime date, TariffPlan tp)
        {
            History.Add(date, tp);
            this.TheAbonent = abonent;
        }
    }
}
