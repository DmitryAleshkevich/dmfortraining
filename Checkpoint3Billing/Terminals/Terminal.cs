using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Checkpoint3Billing
{
    public abstract class Terminal : INotifyPropertyChanged
    {
        #region Terminal state + Event Changed
        private TerminalState _terminalState;

        public TerminalState TerminalState
        {
            get { return _terminalState; }
            set 
            { 
                _terminalState = value;
                NotifyPropertyChanged("TerminalState");
            }
        }

        protected virtual void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged == null) return;
            Console.WriteLine("Terminal has been {0}",TerminalState);
            PropertyChanged(this, new PropertyChangedEventArgs(property));
        } 

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region EventCall
        public void MakeCall(Abonent abonent)
        {
            if (Call == null) return;
            _terminalState = TerminalState.Call;            
            Console.WriteLine("Call to {0}...",abonent.AbonentName);
            Call(this, new CallEventArgs(abonent));
        }

        public event EventHandler<CallEventArgs> Call;
        #endregion

        #region Subscribe

        public void Subscribe(Port port)
        {
            port.IncomeCall += PortOnIncomeCall;
            port.AtsAnswer += PortOnAtsAnswer;
        }

        public void UnSubscribe(Port port)
        {
            port.IncomeCall -= PortOnIncomeCall;
            port.AtsAnswer -= PortOnAtsAnswer;
        }

        #endregion

        #region Event Income Call
        private void PortOnIncomeCall(object sender, CallEventArgs callEventArgs)
        {
            if (IncomeCall == null) return;
            Console.WriteLine("Terminal receives income call!");
            IncomeCall(this, callEventArgs);
        }

        public event EventHandler<CallEventArgs> IncomeCall;
        #endregion

        #region Event AbonentAnswer

        public event EventHandler<AbonentAnswerEventArgs> AbonentAnswer;

        protected virtual void OnAbonentAnswer(AbonentAnswerEventArgs e)
        {
            var handler = AbonentAnswer;
            if (handler == null) return;
            Console.WriteLine("Terminal sent answer!");
            handler(this, e);
        }

        public void Answer(CallState callState)
        {
            OnAbonentAnswer(new AbonentAnswerEventArgs(callState));
        }

        #endregion
        
        #region Event AtsAnswer

        private void PortOnAtsAnswer(object sender, AbonentAnswerEventArgs abonentAnswerEventArgs)
        {
            if (abonentAnswerEventArgs.CallState != CallState.Established)
            {
                TerminalState = TerminalState.Waiting;
            }
            Console.WriteLine("Terminal got answer!");            
            OnAtsAnswer(abonentAnswerEventArgs);
        }

        public event EventHandler<AbonentAnswerEventArgs> AtsAnswer;

        protected virtual void OnAtsAnswer(AbonentAnswerEventArgs e)
        {
            var handler = AtsAnswer;
            if (handler != null) handler(this, e);
        }

        #endregion

        #region Event CallFinish

        public event EventHandler CallFinish;

        protected virtual void OnCallFinish()
        {
            var handler = CallFinish;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public void FinishCall()
        {
            OnCallFinish();
        }

        #endregion       
    }
}
