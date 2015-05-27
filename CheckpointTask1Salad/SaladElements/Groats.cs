using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckpointTask1Salad
{
    public class Groats : SaladItem, IBoilable
    {
        public override void AddToSalad()
        {
            Console.WriteLine("Groats {0} was added to salad!", this.Name);
        }

        public void Boil()
        {
            Console.WriteLine("Groats {0} was boiled!", this.Name);
        }
    }
}
