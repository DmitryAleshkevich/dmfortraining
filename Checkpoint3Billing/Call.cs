using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Checkpoint3Billing
{
    public class Call
    {
        public Call(DateTime startTime, Abonent abonentIncome, Abonent abonentAnswered, bool isActive)
        {
            StartTime = startTime;
            AbonentIncome = abonentIncome;
            AbonentAnswered = abonentAnswered;
            IsActive = isActive;
        }

        public DateTime StartTime { get; private set; }
        public DateTime FinishTime { get; set; }
        public bool IsActive { get; set; }

        public TimeSpan Duration
        {
            get { return FinishTime - StartTime; }
        }

        public Abonent AbonentIncome { get; private set; }
        public Abonent AbonentAnswered { get; private set; }

        public double Cost { get; set; }

    }
}
