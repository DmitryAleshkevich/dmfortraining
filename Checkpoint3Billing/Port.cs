using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Checkpoint3Billing
{
    public class Port
    {
        public PortState PortState { get; set; }

        #region Event Call
        public event EventHandler<CallEventArgs> Call;

        private void CallHandle(object sender, CallEventArgs args)
        {
            PortState = PortState.Call;
            if (Call != null)
            {
                Call(this, args);
            }
        }

        public void Subscribe(Terminal terminal)
        {
            terminal.Call += CallHandle;
            terminal.AbonentAnswer += AbonentAnswerHandle;
        }

        public void UnSubscribe(Terminal terminal)
        {
            terminal.Call -= CallHandle;
            terminal.AbonentAnswer -= AbonentAnswerHandle;
        }
        #endregion

        #region Event IncomeCall
        public event EventHandler<CallEventArgs> IncomeCall;

        protected virtual void OnIncomeCall(Abonent abonent)
        {
            var handler = IncomeCall;
            if (handler != null)
            {
                handler(this, new CallEventArgs(abonent));
            }        
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
            if (handler != null) handler(this, e);
        }

        #endregion        
    }
}
