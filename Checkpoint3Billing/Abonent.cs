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
        public Terminal TheTerminal { get; private set; }        

        public void SwitchTerminal(bool on)
        {
            TerminalState ts = TerminalState.Off;
            if (on)
            {
                ts = TerminalState.On;
            }
            if (this.TheTerminal.TerminalState != ts)
            {
                this.TheTerminal.TerminalState = ts;
            }
        }

        public Abonent(string name, AbonentNumber number, Terminal terminal)
        {
            this.AbonentName = name;
            this.Number = number;
            this.TheTerminal = terminal;
        }
    }
}
