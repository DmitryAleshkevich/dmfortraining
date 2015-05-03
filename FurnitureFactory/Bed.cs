using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureFactory
{
    public class Bed : Sofa
    {
        private int lyingPlacesCount;

        public int LyingPlacesCount
        {
            get { return lyingPlacesCount; }
            set { lyingPlacesCount = value; }
        }

        #region Methods
        public override void Sit()
        {
            Console.WriteLine("Sitting on bed {0}",this.Name);
        }

        public override void SitComfortable()
        {
            Console.WriteLine("Sitting with comfort on bed {0}", this.Name);
        }

        public override void Sell(double price)
        {
            Console.WriteLine("The bed {0} has been sold on price {1}!", this.Name, price);
        }

        public override void LieDown()
        {
            Console.WriteLine("Lied down on the bed {0}", this.Name);
        }

        #endregion 

        public Bed(string name, string color, string size, double price, string material, string form, List<Component> components, int placesCount, int lyingPlacesCount)
            : base(name, color, size, price, material,form,components,placesCount) 
        {
            this.lyingPlacesCount = lyingPlacesCount;    
        }    
    }
}
