using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureFactory
{
    public class Sofa : Chair, ILieDownable
    {
        private int placesCount;

        public int PlacesCount
        {
            get { return placesCount; }
            set { placesCount = value; }
        }

        #region Methods
        public override void Sit()
        {
            Console.WriteLine("Sitting on sofa {0}",this.Name);
        }

        public override void SitComfortable()
        {
            Console.WriteLine("Sitting with comfort on sofa {0}", this.Name);
        }

        public override void Sell(double price)
        {
            Console.WriteLine("The sofa {0} has been sold on price {1}!", this.Name, price);
        }

        public virtual void LieDown()
        {
            Console.WriteLine("Lied down on the sofa {0}", this.Name);
        }

        #endregion 

        public Sofa(string name, string color, string size, double price, string material, string form, List<Component> components, int placesCount)
            : base(name, color, size, price, material,form,components) 
        {
            this.placesCount = placesCount;    
        }        
    }
}
