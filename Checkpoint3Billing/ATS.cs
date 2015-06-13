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
            foreach (var terminal in Terminals)
            {
                terminal.PropertyChanged += TerminalStateChange;
            }
        }

        #region Properties
        public string CompanyName { get; private set; }
        public List<Contract> Contracts { get; private set; }
        public List<int> NumbersRange { get; private set; }
        public List<Terminal> Terminals { get; private set; }
        public List<Port> Ports { get; private set; }
        public Dictionary<Terminal, Port> Connections { get; private set; }
        #endregion

        public Contract CreateContract(TariffPlan tp, Client client)
        {
            var newAbonent = new Abonent(client.Person, new AbonentNumber(GenerateNewNumber(), client.Person), ChooseTerminal());
            var contract = new Contract(newAbonent);
            contract.CreatePlanHistory(DateTime.UtcNow, tp);
            Contracts.Add(contract);
            return contract;
        }

        #region Auxiliary Methods
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
        
        private Port FindFreePort()
        {
            return this.Ports.First(x => x.PortState == PortState.Ready);
        }

        private Port FindActualPort(Terminal terminal)
        {
            return Connections.First(x => x.Key == terminal).Value;
        }
        #endregion

        #region Event Terminal State Changed
        private void TerminalStateChange(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "TerminalState") return;
            var terminal = sender as Terminal;
            if (terminal == null) return;
            if (!Terminals.Contains(terminal)) return;
            switch (terminal.TerminalState)
            {
                case TerminalState.On:
                    var newPort = FindFreePort();
                    newPort.PortState = PortState.Busy;
                    Connections.Add(terminal, newPort);
                    newPort.Subscribe(terminal);
                    terminal.Subscribe(newPort);
                    newPort.Call += NewPortOnCall;
                    newPort.AbonentAnswer += NewPortOnAbonentAnswer;
                    break;
                case TerminalState.Off:
                    var actualPort = FindActualPort(terminal);
                    actualPort.PortState = PortState.Ready;
                    Connections.Remove(terminal);
                    actualPort.UnSubscribe(terminal);
                    terminal.Subscribe(actualPort);
                    actualPort.Call -= NewPortOnCall;
                    actualPort.AbonentAnswer -= NewPortOnAbonentAnswer;                    
                    break;
            }
        }        
        #endregion
        
        #region Event Call
        private void NewPortOnCall(object sender, CallEventArgs callEventArgs)
        {
            Port port;
            if (Connections.TryGetValue(callEventArgs.Abonent.Terminal, out port))
            {
                if (port.PortState == PortState.Call)
                {
                    
                }
                else
                {                    
                    var incomePort = sender as Port;
                    if (incomePort == null) return;                    
                    var result = Connections.Where(x => x.Value.Equals(incomePort)).Select(x => x.Key).First();
                    if (result == null) return;
                    var incomeAbonent = (from x in Contracts
                        where x.TheAbonent.Terminal.Equals(result)
                        select x.TheAbonent).First();
                    if (incomeAbonent == null) return;
                    port.IncomingCall(incomeAbonent);
                }
            }
            else
            {
                
            }
        }
        #endregion

        #region Event AbonentAnswer

        private void NewPortOnAbonentAnswer(object sender, AbonentAnswerEventArgs abonentAnswerEventArgs)
        {
            
        }

        #endregion
    }
}
