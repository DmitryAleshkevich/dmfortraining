using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Checkpoint3Billing
{
    public abstract class Terminal : INotifyPropertyChanged
    {
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
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        } 

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
