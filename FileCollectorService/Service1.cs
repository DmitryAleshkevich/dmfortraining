using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using BLClassLibrary;

namespace FileCollectorService
{
    public partial class Service1 : ServiceBase
    {
        private static readonly Timer Timer = new Timer(15000);
        private static readonly FileWatcher FileWatcher = new FileWatcher();
        
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Timer.Elapsed += TimerOnElapsed;
            Timer.Enabled = true;
            FileWatcher.Start();
        }

        protected override void OnStop()
        {
            Timer.Enabled = false;
            Timer.Elapsed -= TimerOnElapsed;
            Timer.Dispose();
            FileWatcher.Stop();
        }

        private static void TimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            FileWatcher.FilesHandleAsync();
        }
    }
}
