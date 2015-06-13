using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Checkpoint3Billing
{
    public class ContractManager
    {
        public List<TariffPlan> Tariffs { get; private set; }

        public void AddTariffPlan(TariffPlan tp)
        {
            Tariffs.Add(tp);
        }

        public void RemoveTariffPlan(TariffPlan tp)
        {
            Tariffs.Remove(tp);
        }

        private void EnquiryHandler(Client sender, EnquiryEventArgs args)
        {
            var tariff = Tariffs.First(args.Selector);
            sender.AddContract(tariff.Ats.CreateContract(tariff,sender));
        }
    }
}
