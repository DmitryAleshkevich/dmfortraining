using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckpointTask1Salad
{
    public class Vegetable : SaladItem, IColorable, IChopable, IPeelable, IBoilable, IFryable, ISaladAddable
    {        
        #region Realization
        public string Color { get; set; }

        public void Chope()
        {
            Console.WriteLine("Vegetable {0} was chopped!", this.Name);
        }

        public void Peel()
        {
            Console.WriteLine("Vegetable {0} was peeled!", this.Name);
        }

        public void Boil()
        {
            Console.WriteLine("Vegetable {0} was boiled!", this.Name);
        }

        public void Fry()
        {
            Console.WriteLine("Vegetable {0} was fryed!", this.Name);
        }

        public void AddToSalad()
        {
            Console.WriteLine("Vegetable {0} was added to salad!", this.Name);
        }
        #endregion
    }
}
