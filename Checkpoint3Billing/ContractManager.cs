using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Checkpoint3Billing
{
    public class ContractManager
    {
        public List<TariffPlan> Tariffs { get; private set; }

        #region Methods
        public void AddTariffPlan(TariffPlan tp)
        {
            Tariffs.Add(tp);
        }

        public void RemoveTariffPlan(TariffPlan tp)
        {
            Tariffs.Remove(tp);
        }
        #endregion

        #region Event Enquiry
        public void Subscribe(Client client)
        {
            client.Enquiry += EnquiryHandler;
            client.TariffChange += ClientOnTariffChange;
            client.CallReport += ClientOnCallReport;
        }

        private void ClientOnCallReport(object sender, CallReportEventArgs callReportEventArgs)
        {
            callReportEventArgs.Contract.PlanHistory.LastHistoryChange.Value.Ats.GetCallReport(callReportEventArgs.Contract, callReportEventArgs.StartTime, callReportEventArgs.EndTime, callReportEventArgs.Selector);
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
            if (result != "Success") return;
            oldtariff.Ats.RemoveContract(contract);
            tariff.Ats.AddContract(contract);
        }



        private void EnquiryHandler(object sender, EnquiryEventArgs args)
        {
            var tariff = Tariffs.First(args.Selector);
            if (tariff == null) return;
            var client = sender as Client;
            if (client != null)
            {
                client.AddContract(tariff.Ats.CreateContract(tariff, client));
            }
        }
        #endregion
    }
}
