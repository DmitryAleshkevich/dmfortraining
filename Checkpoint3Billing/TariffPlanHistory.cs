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
    }
}
