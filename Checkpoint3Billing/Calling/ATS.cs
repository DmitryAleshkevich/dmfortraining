using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Checkpoint3Billing
{
    public class Ats
    {
        public Ats(string companyName, List<int> numbersRange, List<Terminal> terminals, List<Port> ports)
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
        
        private readonly List<Contract> _contracts = new List<Contract>();
 
        public List<int> NumbersRange { get; private set; }
        public List<Terminal> Terminals { get; private set; }
        public List<Port> Ports { get; private set; }
        
        private readonly Dictionary<Terminal, Port> _connections = new Dictionary<Terminal, Port>();
        
        private readonly List<Call> _calls = new List<Call>();

        
        public List<Contract> Contracts
        {
            get { return _contracts; }            
        }

        public Dictionary<Terminal, Port> Connections
        {
            get { return _connections; }
        }

        public List<Call> Calls
        {
            get { return _calls; }            
        }

        private Abonent _abonentIncome;
        private Abonent _abonentAnswered;
        #endregion

        public Contract CreateContract(TariffPlan tp, Client client)
        {
            var newAbonent = new Abonent(client.Person, new AbonentNumber(GenerateNewNumber(), client.Person), ChooseTerminal());
            var contract = new Contract(newAbonent);
            contract.CreatePlanHistory(DateTime.UtcNow, tp);
            _contracts.Add(contract);
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
            return Ports.First(x => x.PortState == PortState.Ready);
        }

        private Port FindActualPort(Terminal terminal)
        {
            return Connections.First(x => x.Key.Equals(terminal)).Value;
        }

        private Terminal FindTerminalByPort(Port incomePort)
        {
            return Connections.Where(x => x.Value.Equals(incomePort)).Select(x => x.Key).First();
        }

        private Abonent GetAbonentByTerminal(Terminal result)
        {
            var incomeAbonent = (from x in Contracts
                                 where x.TheAbonent.Terminal.Equals(result)
                                 select x.TheAbonent).First();
            return incomeAbonent;
        }

        public void AddContract(Contract contract)
        {
            _contracts.Add(contract);
        }

        public void RemoveContract(Contract contract)
        {
            _contracts.Remove(contract);
        }

        public IEnumerable<Call> GetCallReport(Contract contract, DateTime startdate, DateTime enddate, Func<Call,bool> selector)
        {
            var freeminutesremain = 0;
            var paytime = 0;
            TariffPlan oldtariff = null;
            var result = Calls.Where(call => call.StartTime >= startdate && call.StartTime <= enddate && call.IsActive == false && call.AbonentIncome.Equals(contract.TheAbonent));
            var enumerable = result as IList<Call> ?? result.ToList();
            foreach (var call in enumerable)
            {
                var tariff = contract.PlanHistory.GetTpByDate(call.StartTime);
                if (!tariff.Equals(oldtariff))
                {
                    freeminutesremain = tariff.FreeMinutes;
                }                
                var difference = freeminutesremain - (call.Duration.Days * 24 * 60 + call.Duration.Hours * 60 + call.Duration.Minutes);                                    
                if (difference >= 0)
                {
                    freeminutesremain -= difference;
                    paytime = 0;
                }
                else if (difference < 0)
                {
                    paytime = -difference;
                    freeminutesremain = 0;
                }
                oldtariff = tariff;
                call.Cost = paytime*tariff.CallCost;
            }
            return enumerable.Where(selector);
        }

        #endregion

        #region Event Terminal State Changed
        private void TerminalStateChange(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "TerminalState") return;
            var terminal = sender as Terminal;
            if (terminal == null) return;            
            switch (terminal.TerminalState)
            {
                case TerminalState.On:
                    var newPort = FindFreePort();
                    newPort.PortState = PortState.Busy;
                    _connections.Add(terminal, newPort);
                    newPort.Subscribe(terminal);
                    terminal.Subscribe(newPort);
                    newPort.Call += NewPortOnCall;
                    newPort.AbonentAnswer += NewPortOnAbonentAnswer;
                    newPort.CallFinish += NewPortOnCallFinish;
                    Console.WriteLine("ATS {0} set port for terminal, cause it`s on!",CompanyName);
                    break;
                case TerminalState.Off:
                    var actualPort = FindActualPort(terminal);
                    actualPort.PortState = PortState.Ready;
                    _connections.Remove(terminal);
                    actualPort.UnSubscribe(terminal);
                    terminal.UnSubscribe(actualPort);
                    actualPort.Call -= NewPortOnCall;
                    actualPort.AbonentAnswer -= NewPortOnAbonentAnswer;
                    actualPort.CallFinish -= NewPortOnCallFinish;
                    Console.WriteLine("ATS {0} delete port for terminal, cause it`s off!", CompanyName);                    
                    break;
            }
        }       
        #endregion
        
        #region Event Call
        private void NewPortOnCall(object sender, CallEventArgs callEventArgs)
        {
            var incomePort = sender as Port;
            if (incomePort == null) return;                                    
            Port port;
            if (Connections.TryGetValue(callEventArgs.Abonent.Terminal, out port))
            {
                Console.WriteLine("ATS tries to establish connection...");
                switch (port.PortState)
                {
                    case PortState.Call:
                        incomePort.GetAtsAnswer(CallState.Busy);
                        break;
                    default:
                        var result = FindTerminalByPort(incomePort);
                        if (result == null) return;
                        var incomeAbonent = GetAbonentByTerminal(result);
                        if (incomeAbonent == null) return;
                        _abonentAnswered = callEventArgs.Abonent;
                        _abonentIncome = incomeAbonent;
                        port.IncomingCall(incomeAbonent);                        
                        break;
                }
            }
            else
            {
                incomePort.GetAtsAnswer(CallState.Offline);
            }
        }        
        #endregion

        #region Event AbonentAnswer

        private void NewPortOnAbonentAnswer(object sender, AbonentAnswerEventArgs abonentAnswerEventArgs)
        {
            Console.WriteLine("ATS sent answer!");
            var port = FindActualPort(_abonentIncome.Terminal);
            if (port == null) return;
            port.GetAtsAnswer(abonentAnswerEventArgs.CallState);
            if (abonentAnswerEventArgs.CallState == CallState.Established)
            {
                _calls.Add(new Call(DateTime.UtcNow, _abonentIncome, _abonentAnswered, true));
            }            
        }

        #endregion

        #region Event Call Finish

        private void NewPortOnCallFinish(object sender, EventArgs eventArgs)
        {
            var incomePort = sender as Port;
            if (incomePort == null) return;
            var terminal = FindTerminalByPort(incomePort);
            if (terminal == null) return;
            var incomeAbonent = GetAbonentByTerminal(terminal);
            if (incomeAbonent == null) return;
            var call = Calls.First(x => x.AbonentIncome.Equals(incomeAbonent) || x.AbonentAnswered.Equals(incomeAbonent));
            if (call == null) return;
            call.FinishTime = DateTime.UtcNow;
            call.IsActive = false;
            var portotmessage = FindActualPort(call.AbonentAnswered.Equals(incomeAbonent) ? call.AbonentIncome.Terminal : call.AbonentAnswered.Terminal);
            portotmessage.GetAtsAnswer(CallState.Busy);
        }

        #endregion
    }
}
