using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckpointTask1Salad
{
    public class Cheeses : SaladItem, IChopable, ISaladAddable
    {
        public void Chope()
        {
            Console.WriteLine("Cheese {0} was chopped!", this.Name);
        }

        public void AddToSalad()
        {
            Console.WriteLine("Cheese {0} was added to salad!", this.Name);
        }
    }
}
