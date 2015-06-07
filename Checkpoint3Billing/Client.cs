using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Checkpoint3Billing
{
    public class Client
    {
        public string Person { get; private set; }
        public int Age { get; private set; }
        public List<Contract> Contracts { get; private set; }        

        public void SignContract(ATS ats, TariffPlan tp, double fee)
        {
            Contracts.Add(ats.CreateContract(tp,fee,this));                
        }

    }
}
