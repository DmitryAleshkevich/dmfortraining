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
        private readonly List<Contract> _contracts = new List<Contract>();        
        public List<Contract> Contracts
        {
            get { return _contracts; }            
        }

        #endregion

        #region Methods
        public void AddContract(Contract contract)
        {
            _contracts.Add(contract);
        }
        #endregion

        #region Event Enquiry
        public event EventHandler<EnquiryEventArgs> Enquiry;

        public void SendEnquiry(Func<TariffPlan,bool> selector)
        {
            Console.WriteLine("Client {0} send enquiry for contract",this.Person);
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

        #region Event Tariff Change

        public event EventHandler<TariffChangeEventArgs> TariffChange;

        public void ChangeTariff(Abonent abonent, DateTime date, Func<TariffPlan, bool> selector)
        {
            Console.WriteLine("Abonent {0} wants to change tariff!",abonent.AbonentName);
            OnTariffChange(new TariffChangeEventArgs(selector,date,abonent));
        }

        protected virtual void OnTariffChange(TariffChangeEventArgs e)
        {
            var handler = TariffChange;
            if (handler != null) handler(this, e);
        }

        #endregion

        #region Event CallReport

        public event EventHandler<CallReportEventArgs> CallReport;

        public void GetReport(Contract contract, DateTime startTime, DateTime endTime, Func<Call,bool> selector)
        {
            Console.WriteLine("Abonent {0} wants call report!",contract.TheAbonent.AbonentName);
            OnCallReport(new CallReportEventArgs(contract,selector,endTime,startTime));
        }

        protected virtual void OnCallReport(CallReportEventArgs e)
        {
            var handler = CallReport;
            if (handler != null) handler(this, e);
        }

        #endregion
    }
}
