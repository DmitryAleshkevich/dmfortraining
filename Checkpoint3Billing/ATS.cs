using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Checkpoint3Billing
{
    public class ATS
    {
        public string CompanyName { get; private set; }
        public List<Contract> Contracts { get; private set; }
        public List<int> NumbersRange { get; private set; }
        public List<Terminal> Terminals { get; private set; }
        public List<Port> Ports { get; private set; }
        public Dictionary<Terminal, Port> Connections { get; private set; }

        private int GenerateNewNumber()
        {
            int element = NumbersRange.First();
            NumbersRange.Remove(element);
            return element;
        }

        private Terminal ChooseTerminal()
        {
            Terminal element = Terminals.First();
            Terminals.Remove(element);
            return element;
        }

        public Contract CreateContract(TariffPlan tp, double fee, Client client)
        {
            Abonent newAbonent = new Abonent(client.Person,new AbonentNumber(GenerateNewNumber(),client.Person),ChooseTerminal());
            Contract contract = new Contract(newAbonent);
            contract.Pay(fee);
            contract.CreatePlanHistory(DateTime.UtcNow, tp);
            Contracts.Add(contract);
            return contract;
        }

        private Port FindFreePort()
        {
            return this.Ports.Where(x => x.portState == PortState.Ready).First();
        }

        private Port FindActualPort(Terminal terminal)
        {
            return Connections.Where(x => x.Key == terminal).First().Value;
        }

        private void TerminalStateChange(Terminal sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "TerminalState")
            {
                if (sender.TerminalState == TerminalState.On)
                {
                    Port newPort = FindFreePort();
                    newPort.portState = PortState.Busy;
                    Connections.Add(sender, newPort);
                }
                else if (sender.TerminalState == TerminalState.Off)
                {
                    Port actualPort = FindActualPort(sender);
                    actualPort.portState = PortState.Ready;
                    Connections.Remove(sender);
                }
            }
        }
    }
}
