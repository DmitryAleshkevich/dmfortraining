using System;
using System.Timers;
using BLClassLibrary;

namespace Checkpoint4Service
{
    class Program
    {
        private static readonly Timer Timer = new Timer(15000);
        private static readonly FileWatcher FileWatcher = new FileWatcher();
            
        static void Main(string[] args)
        {
            Timer.Elapsed += TimerOnElapsed;
            Timer.Enabled = true;
            FileWatcher.Start();
            Console.ReadLine();
        }

        private static void TimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            FileWatcher.FilesHandleAsync();
        }
    }
}
