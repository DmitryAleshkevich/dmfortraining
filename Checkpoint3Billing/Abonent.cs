using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Checkpoint3Billing
{
    public class Abonent
    {
        public string AbonentName { get; private set; }
        public AbonentNumber Number { get; private set; }
        public Terminal Terminal { get; private set; }        

        public void SwitchTerminal(bool on)
        {
            var ts = TerminalState.Off;
            if (on)
            {
                ts = TerminalState.On;
                Terminal.IncomeCall += TerminalOnIncomeCall;
            }
            else
            {
                Terminal.IncomeCall -= TerminalOnIncomeCall;
            }
            if (Terminal.TerminalState != ts)
            {
                Terminal.TerminalState = ts;
            }
        }

        private void TerminalOnIncomeCall(object sender, CallEventArgs callEventArgs)
        {
            var random = new Random();
            Terminal.Answer(random.Next(0, 2) == 0 ? CallState.Declined : CallState.Established);
        }

        public void MakeCall(Abonent abonent)
        {
            Terminal.MakeCall(abonent);
        }

        public Abonent(string name, AbonentNumber number, Terminal terminal)
        {
            AbonentName = name;
            Number = number;
            Terminal = terminal;
        }
    }
}
