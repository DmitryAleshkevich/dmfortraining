using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Checkpoint3Billing
{
    public class Client
    {
        public Client(string person, int age)
        {
            Person = person;
            Age = age;
        }

        public string Person { get; private set; }
        public int Age { get; private set; }
        public List<Contract> Contracts { get; private set; }

        public void AddContract(Contract contract)
        {
            Contracts.Add(contract);
        }

        public event EventHandler Enquiry;

        public void SendEnquiry(Func<TariffPlan,bool> selector)
        {
            OnEnquired(selector);
        }

        protected virtual void OnEnquired(Func<TariffPlan, bool> selector)
        {
            if (Enquiry != null)
            {
                Enquiry(this, new EnquiryEventArgs(selector));
            }
        }

    }
}
