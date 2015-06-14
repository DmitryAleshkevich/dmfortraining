using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Checkpoint3Billing
{
    class Program
    {
        static void Main(string[] args)
        {
            var vasili = new Client("vasili",24);
            var yuri = new Client("yuri",23);
            var petr = new ContractManager();           
            petr.Subscribe(yuri);
            petr.Subscribe(vasili);
            var listNumbers = new List<int> {3637383, 5685236, 7255262};
            var terminals = Terminals();
            var ports = Ports();
            var mts = new Ats("MTS", listNumbers, terminals, ports);
            var smart500 = new Smart(400,25000,5,150,"smart 500",mts);
            var social5 = new Social(0,250,50,"social 5",mts);
            petr.AddTariffPlan(smart500);
            petr.AddTariffPlan(social5);
            vasili.SendEnquiry(x => x.Name == "social 5");
            yuri.SendEnquiry(x => x.FreeMinutes == 5);
            var abonentvasili = vasili.Contracts.First().TheAbonent;
            var abonentyuri = yuri.Contracts.First().TheAbonent;            
            abonentvasili.SwitchTerminal(true);
            abonentyuri.SwitchTerminal(true);
            abonentyuri.SwitchTerminal(false);
            abonentyuri.SwitchTerminal(true);
            abonentvasili.MakeCall(abonentyuri);
            Thread.Sleep(5000);
            abonentyuri.FinishCall();
            vasili.ChangeTariff(abonentvasili, DateTime.Today, x => x.FreeMinutes == 5);
            vasili.GetReport(vasili.Contracts.First(),new DateTime(2014,01,01),new DateTime(2015,07,01), x=> true );
        }

        private static List<Port> Ports()
        {
            var ports = new List<Port>
            {
                new Port() {PortState = PortState.Ready},
                new Port() {PortState = PortState.Ready},
                new Port() {PortState = PortState.Ready},
                new Port() {PortState = PortState.Ready},
                new Port() {PortState = PortState.Ready}
            };
            return ports;
        }

        private static List<Terminal> Terminals()
        {
            var terminals = new List<Terminal>
            {
                new MobilePhone() {TerminalState = TerminalState.Default},
                new StationPhone() {TerminalState = TerminalState.Default},
                new MobilePhone() {TerminalState = TerminalState.Default},
                new MobilePhone() {TerminalState = TerminalState.Default}
            };
            return terminals;
        }
    }
}
