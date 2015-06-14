using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Checkpoint3Billing
{
    public class TariffChangeEventArgs : EventArgs
    {
        public TariffChangeEventArgs(Func<TariffPlan, bool> selector, DateTime date, Abonent abonent)
        {
            Selector = selector;
            Date = date;
            Abonent = abonent;
        }

        public Func<TariffPlan, bool> Selector { get; private set; }
        public DateTime Date { get; private set; }
        public Abonent Abonent { get; private set; }
    }
}
