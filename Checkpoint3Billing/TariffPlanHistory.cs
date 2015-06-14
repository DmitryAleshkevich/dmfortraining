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

        public TariffPlan GetTpByDate(DateTime date)
        {
            return History.Last(x => x.Key <= date).Value;
        }

        public string ChangePlan(DateTime date, TariffPlan tp)
        {
            if (date.Month - LastHistoryChange.Key.Month <= 0) return "Error! You can`t change plan in this month!";
            History.Add(date, tp);
            return "Success";
        }

        public TariffPlanHistory(Abonent abonent, DateTime date, TariffPlan tp)
        {
            History.Add(date, tp);
            this.TheAbonent = abonent;
        }
    }
}
