using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using BLClassLibrary;

namespace Checkpoint4Service
{
    class Program
    {
        static void Main(string[] args)
        {
            FileWatcher.Start();
            Thread.Sleep(10000);
            FileWatcher.Stop();
        }
    }
}
