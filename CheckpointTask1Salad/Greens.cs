using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckpointTask1Salad
{
    public class Greens : Component, ISaladAddable, IChopable
    {
        public void AddToSalad()
        {
            Console.WriteLine("Greens {0} was added to salad!", this.Name);
        }

        public void Chope()
        {
            Console.WriteLine("Greens {0} was chopped!", this.Name);
        }
    }
}
