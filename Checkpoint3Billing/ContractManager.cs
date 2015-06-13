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
        }

        private void EnquiryHandler(object sender, EnquiryEventArgs args)
        {
            var tariff = Tariffs.First(args.Selector);
            var client = sender as Client;
            if (client != null)
            {
                client.AddContract(tariff.Ats.CreateContract(tariff, client));
            }
        }
        #endregion
    }
}
