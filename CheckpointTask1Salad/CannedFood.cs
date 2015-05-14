using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckpointTask1Salad
{
    public class CannedFood : Component, ISaladAddable, IOpenable
    {
        public void AddToSalad()
        {
            Console.WriteLine("Canned food {0} was added to salad!", this.Name);
        }

        public void Open()
        {
            Console.WriteLine("Canned food {0} was opened!", this.Name);      
        }
    }
}
