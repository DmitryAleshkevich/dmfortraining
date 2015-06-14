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
        public bool IsTalking;

        public void SwitchTerminal(bool on)
        {
            var ts = TerminalState.Off;
            if (on)
            {
                ts = TerminalState.On;
                Terminal.IncomeCall += TerminalOnIncomeCall;
                Terminal.AtsAnswer += TerminalOnAtsAnswer;
            }
            else
            {
                Terminal.IncomeCall -= TerminalOnIncomeCall;
                Terminal.AtsAnswer -= TerminalOnAtsAnswer;
            }
            if (Terminal.TerminalState == ts) return;
            Terminal.TerminalState = ts;
            if (@on)
            {
                Terminal.TerminalState = TerminalState.Waiting;
            }
        }

        #region Event AtsAnswer
        private void TerminalOnAtsAnswer(object sender, AbonentAnswerEventArgs abonentAnswerEventArgs)
        {
            if (abonentAnswerEventArgs.CallState == CallState.Established)
            {
                IsTalking = true;
            }        
        }
        #endregion

        #region Event Income Call
        private void TerminalOnIncomeCall(object sender, CallEventArgs callEventArgs)
        {
            var random = new Random();
            if (random.Next(0, 2) == 0)
            {
                Terminal.Answer(CallState.Declined);
            }
            else
            {
                Terminal.Answer(CallState.Established);
                IsTalking = true;
            }
        }
        #endregion

        public void MakeCall(Abonent abonent)
        {
            Terminal.MakeCall(abonent);
        }

        public void FinishCall()
        {
            if (IsTalking)
            {
                Terminal.FinishCall();
            }
        }

        public Abonent(string name, AbonentNumber number, Terminal terminal)
        {
            AbonentName = name;
            Number = number;
            Terminal = terminal;
        }
    }
}
