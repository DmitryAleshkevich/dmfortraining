using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckpointTask1Salad
{
    public class Meat : SaladItem, IChopable, IBoilable, IFryable
    {
        #region Realization
        public void Chope()
        {
            Console.WriteLine("Meat {0} was chopped!", this.Name);
        }

        public void Boil()
        {
            Console.WriteLine("Meat {0} was boiled!", this.Name);
        }

        public void Fry()
        {
            Console.WriteLine("Meat {0} was fryed!", this.Name);
        }

        public override void AddToSalad()
        {
            Console.WriteLine("Meat {0} was added to salad!", this.Name);
        }
        #endregion
    }
}
