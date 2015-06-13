using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Checkpoint3Billing
{
    public class Client
    {
        #region Constructors
        public Client(string person, int age)
        {
            Person = person;
            Age = age;
        }
        #endregion

        #region Properties
        public string Person { get; private set; }
        public int Age { get; private set; }
        public List<Contract> Contracts { get; private set; }
        #endregion

        #region Methods
        public void AddContract(Contract contract)
        {
            Contracts.Add(contract);
        }
        #endregion

        #region Event Enquiry
        public event EventHandler<EnquiryEventArgs> Enquiry;

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
        #endregion
    }
}
