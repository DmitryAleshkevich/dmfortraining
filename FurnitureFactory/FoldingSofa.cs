using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureFactory
{
    public class FoldingSofa : FoldingChair
    {
        private int placesCount;

        public int PlacesCount
        {
            get { return placesCount; }
            set { placesCount = value; }
        }

        #region Methods
        public override void Transform()
        {
            Console.WriteLine("The folding sofa {0} has been transformed!", this.Name);
        }

        public override void LieDown()
        {
            Console.WriteLine("Layed down on folding sofa {0}!", this.Name);
        }

        public override void Sit()
        {
            Console.WriteLine("Sitting on folding sofa {0}", this.Name);
        }

        public override void SitComfortable()
        {
            Console.WriteLine("Sitting with comfort on folding sofa {0}", this.Name);
        }

        public override void Sell(double price)
        {
            Console.WriteLine("The folding sofa {0} has been sold on price {1}!", this.Name, price);
        }
        #endregion

        public FoldingSofa(string name, string color, string size, double price, string material, string form, List<Component> components, int placesCount)
            : base(name, color, size, price, material, form, components) 
        {
            this.placesCount = placesCount;
        }

    }
}
