using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureFactory
{
    public class Armrest : Component
    {
        #region Fields
        private string material;        
        private Sides side;
        #endregion

        #region Properties
        public Sides Side
        {
            get { return side; }
            set { side = value; }
        }

        public string Material
        {
            get { return material; }
            set { material = value; }
        }
        #endregion

        #region Constructors
        public Armrest(string name, string color, string size, double price, string material, Sides side)
            : base(name, color, size, price)
        {
            this.material = material;
            this.side = side;           
        }
        #endregion

        #region Methods
        public override void Hang()
        {
            Console.WriteLine("The armrest {0} has been hanged!", this.Name);
        }

        public override void Remove()
        {
            Console.WriteLine("The armrest {0} has been removed!", this.Name);
        }
        #endregion
    }
}
