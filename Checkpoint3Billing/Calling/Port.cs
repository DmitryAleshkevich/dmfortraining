using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Checkpoint3Billing
{
    public class Port
    {
        public PortState PortState { get; set; }

        #region Subscribe

        public void Subscribe(Terminal terminal)
        {
            terminal.Call += CallHandle;
            terminal.AbonentAnswer += AbonentAnswerHandle;
            terminal.CallFinish += TerminalOnCallFinish;
        }
        
        public void UnSubscribe(Terminal terminal)
        {
            terminal.Call -= CallHandle;
            terminal.AbonentAnswer -= AbonentAnswerHandle;
            terminal.CallFinish -= TerminalOnCallFinish;
        }
        
        #endregion

        #region Event Call

        public event EventHandler<CallEventArgs> Call;

        private void CallHandle(object sender, CallEventArgs args)
        {
            if (Call == null) return;
            PortState = PortState.Call;
            Console.WriteLine("Port has been informed about call to {0}",args.Abonent.AbonentName);
            Call(this, args);
        }

        #endregion

        #region Event IncomeCall
        public event EventHandler<CallEventArgs> IncomeCall;

        protected virtual void OnIncomeCall(Abonent abonent)
        {
            var handler = IncomeCall;
            if (handler == null) return;
            Console.WriteLine("Port indicates income call!");
            handler(this, new CallEventArgs(abonent));
        }

        public void IncomingCall(Abonent abonent)
        {
            OnIncomeCall(abonent);
        }
        #endregion

        #region Event AbonentAnswer

        public void AbonentAnswerHandle(object sender, AbonentAnswerEventArgs args)
        {
            OnAbonentAnswer(args);        
        }

        public event EventHandler<AbonentAnswerEventArgs> AbonentAnswer;

        protected virtual void OnAbonentAnswer(AbonentAnswerEventArgs e)
        {
            var handler = AbonentAnswer;
            if (handler != null)
            {
                Console.WriteLine("Port sent answer!");
                handler(this, e);
            }
        }

        #endregion        

        #region Event AtsAnswer

        public event EventHandler<AbonentAnswerEventArgs> AtsAnswer;

        protected virtual void OnAtsAnswer(AbonentAnswerEventArgs e)
        {
            var handler = AtsAnswer;
            if (handler != null) handler(this, e);
        }

        public void GetAtsAnswer(CallState callState)
        {
            if (callState != CallState.Established)
            {
                PortState = PortState.Busy;
            }
            Console.WriteLine("Port got answer!");
            OnAtsAnswer(new AbonentAnswerEventArgs(callState));
        }

        #endregion

        #region Event Call Finish

        private void TerminalOnCallFinish(object sender, EventArgs eventArgs)
        {
            OnCallFinish();    
        }

        public event EventHandler CallFinish;

        protected virtual void OnCallFinish()
        {
            var handler = CallFinish;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        #endregion       
    }
}
