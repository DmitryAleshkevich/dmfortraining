using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureFactory
{
    public class Shelf : Component, ISellable
    {
        #region Fields
        private string model;
        private string material;
        #endregion

        #region Properties
        public string Material
        {
            get { return material; }
            set { material = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        #endregion

        #region Constructors
        public Shelf(string name, string color, string size, double price, string material, string model)
            : base(name, color, size, price)
        {
            this.material = material;
            this.model = model;
        }
        #endregion

        #region Methods
        public override void Hang()
        {
            Console.WriteLine("The shelf {0} has been hanged!", this.Name);
        }

        public override void Remove()
        {
            Console.WriteLine("The shelf {0} has been removed!", this.Name);
        }

        public void Sell(double price)
        {
            Console.WriteLine("The shelf {0} has been sold on price {1}!", this.Name, price);
        }
        #endregion
    }
}
