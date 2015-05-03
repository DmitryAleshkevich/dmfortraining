using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureFactory
{
    public abstract class Constructions
    {
        #region Fields
        private string name;
        private string color;
        private string size;
        private double price;
        #endregion

        #region Properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public string Size
        {
            get { return size; }
            set { size = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        #endregion

        #region Methods
        public void ToTheWarehouse()
        {
            Console.WriteLine("Construction {0} has been moved to the warehouse!",this.name);
        }
        #endregion

        #region Constructors
        public Constructions(string name, string color, string size, double price)
        {
            this.name = name;
            this.color = color;
            this.size = size;
            this.price = price;
        }
        #endregion
    }
}
