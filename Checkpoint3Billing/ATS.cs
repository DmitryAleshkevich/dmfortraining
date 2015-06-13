using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Checkpoint3Billing
{
    public class Ats
    {
        public Ats(string companyName, List<Contract> contracts, List<int> numbersRange, List<Terminal> terminals, List<Port> ports, Dictionary<Terminal, Port> connections)
        {
            CompanyName = companyName;
            NumbersRange = numbersRange;
            Terminals = terminals;
            Ports = ports;
        }

        public string CompanyName { get; private set; }
        public List<Contract> Contracts { get; private set; }
        public List<int> NumbersRange { get; private set; }
        public List<Terminal> Terminals { get; private set; }
        public List<Port> Ports { get; private set; }
        public Dictionary<Terminal, Port> Connections { get; private set; }

        private int GenerateNewNumber()
        {
            var element = NumbersRange.First();
            NumbersRange.Remove(element);
            return element;
        }

        private Terminal ChooseTerminal()
        {
            var element = Terminals.First();
            Terminals.Remove(element);
            return element;
        }

        public Contract CreateContract(TariffPlan tp, Client client)
        {
            var newAbonent = new Abonent(client.Person,new AbonentNumber(GenerateNewNumber(),client.Person),ChooseTerminal());
            var contract = new Contract(newAbonent);
            contract.CreatePlanHistory(DateTime.UtcNow, tp);
            Contracts.Add(contract);
            return contract;
        }

        private Port FindFreePort()
        {
            return this.Ports.First(x => x.PortState == PortState.Ready);
        }

        private Port FindActualPort(Terminal terminal)
        {
            return Connections.First(x => x.Key == terminal).Value;
        }

        private void TerminalStateChange(Terminal sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "TerminalState") return;
            if (!Terminals.Contains(sender)) return;
            switch (sender.TerminalState)
            {
                case TerminalState.On:
                    var newPort = FindFreePort();
                    newPort.PortState = PortState.Busy;
                    Connections.Add(sender, newPort);
                    break;
                case TerminalState.Off:
                    var actualPort = FindActualPort(sender);
                    actualPort.PortState = PortState.Ready;
                    Connections.Remove(sender);
                    break;
            }
        }
    }
}
