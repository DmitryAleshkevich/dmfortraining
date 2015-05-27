using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckpointTask1Salad
{
    public class Cheeses : SaladItem, IChopable
    {
        public void Chope()
        {
            Console.WriteLine("Cheese {0} was chopped!", this.Name);
        }

        public override void AddToSalad()
        {
            Console.WriteLine("Cheese {0} was added to salad!", this.Name);
        }
    }
}
