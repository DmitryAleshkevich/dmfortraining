using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckpointTask1Salad
{
    public class Fish : Component, IColorable, IPeelable, IBoilable, IFryable, ISaladAddable
    {
        #region Realization
        public ConsoleColor Color { get; set; }

        public void Peel()
        {
            Console.WriteLine("Fish {0} was peeled!", this.Name);
        }

        public void Boil()
        {
            Console.WriteLine("Fish {0} was boiled!", this.Name);
        }

        public void Fry()
        {
            Console.WriteLine("Fish {0} was fryed!", this.Name);
        }

        public void AddToSalad()
        {
            Console.WriteLine("Fish {0} was added to salad!", this.Name);
        }
        #endregion
    }
}
