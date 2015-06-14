using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Checkpoint3Billing
{
    public class ContractManager
    {
        private readonly List<TariffPlan> _tariffs = new List<TariffPlan>();

        public List<TariffPlan> Tariffs
        {
            get { return _tariffs; }
        }

        #region Methods
        public void AddTariffPlan(TariffPlan tp)
        {
            _tariffs.Add(tp);
        }

        public void RemoveTariffPlan(TariffPlan tp)
        {
            _tariffs.Remove(tp);
        }
        #endregion

        #region Events
        public void Subscribe(Client client)
        {
            client.Enquiry += EnquiryHandler;
            client.TariffChange += ClientOnTariffChange;
            client.CallReport += ClientOnCallReport;
        }

        private void ClientOnCallReport(object sender, CallReportEventArgs callReportEventArgs)
        {
            var report = callReportEventArgs.Contract.PlanHistory.LastHistoryChange.Value.Ats.GetCallReport(callReportEventArgs.Contract, callReportEventArgs.StartTime, callReportEventArgs.EndTime, callReportEventArgs.Selector);
            ShowReportInConsole(report);
        }

        private void ShowReportInConsole(IEnumerable<Call> report)
        {
            foreach (var call in report)
            {
                Console.WriteLine("Duration: {0},      Cost: {1},        Abonent: {2},    Date: {3}  ",call.Duration,call.Cost,call.AbonentAnswered.AbonentName,call.StartTime);
            }
        }

        private void ClientOnTariffChange(object sender, TariffChangeEventArgs tariffChangeEventArgs)
        {
            var client = sender as Client;
            if (client == null) return;
            var tariff = Tariffs.First(tariffChangeEventArgs.Selector);
            if (tariff == null) return;
            var contract = client.Contracts.First(x => x.TheAbonent.Equals(tariffChangeEventArgs.Abonent));
            if (contract == null) return;
            var oldtariff = contract.PlanHistory.LastHistoryChange.Value;
            var result = contract.PlanHistory.ChangePlan(tariffChangeEventArgs.Date, tariff);
            Console.WriteLine("Manager inform: {0}!",result);
            if (result != "Success") return;
            oldtariff.Ats.RemoveContract(contract);
            tariff.Ats.AddContract(contract);
        }

        private void EnquiryHandler(object sender, EnquiryEventArgs args)
        {
            var tariff = Tariffs.First(args.Selector);
            if (tariff == null) return;
            var client = sender as Client;
            if (client == null) return;
            client.AddContract(tariff.Ats.CreateContract(tariff, client));
            Console.WriteLine("Manager clinches deal, now {0} got new contract with ATS {1} and tariff {2}!",client.Person,tariff.Ats.CompanyName,tariff.Name);
        }
        #endregion
    }
}
