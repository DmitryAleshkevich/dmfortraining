using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Checkpoint3Billing
{
    public class TariffPlanHistory
    {
        private readonly Dictionary<DateTime, TariffPlan> _history = new Dictionary<DateTime, TariffPlan>();
        
        public Abonent TheAbonent { get; private set; }

        public KeyValuePair<DateTime, TariffPlan> LastHistoryChange
        {
            get
            {
                return History.Last();
            }
        }

        public Dictionary<DateTime, TariffPlan> History
        {
            get { return _history; }            
        }

        public TariffPlan GetTpByDate(DateTime date)
        {
            return History.Last(x => x.Key <= date).Value;
        }

        public string ChangePlan(DateTime date, TariffPlan tp)
        {
            if (date.Month - LastHistoryChange.Key.Month <= 0) return "Error! You can`t change plan in this month!";
            _history.Add(date, tp);
            return "Success";
        }

        public TariffPlanHistory(Abonent abonent, DateTime date, TariffPlan tp)
        {
            _history.Add(date, tp);
            TheAbonent = abonent;
        }
    }
}
