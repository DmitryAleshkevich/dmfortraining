using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProblem2
{
    public interface IAnyItem
    {
        double Cost { get; }
        IAnyItem CreateItem(string name, double price, double quantity);
    }
}
