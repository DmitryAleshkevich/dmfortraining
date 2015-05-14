using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckpointTask1Salad
{
    public class Spices : Component, ISaladAddable
    {
        public void AddToSalad()
        {
            Console.WriteLine("Spice {0} was added to salad!", this.Name);        
        }
    }
}
