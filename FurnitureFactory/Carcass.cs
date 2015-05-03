using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureFactory
{
    public class Carcass : Component
    {
        private string material;

        public string Material
        {
            get { return material; }
            set { material = value; }
        }

        #region Constructors
        public Carcass(string name, string color, string size, double price, string material)
            : base(name, color, size, price)
        {
            this.material = material;            
        }
        #endregion

        #region Methods
        public override void Hang()
        {
            Console.WriteLine("The carcass {0} has been hanged!", this.Name);
        }

        public override void Remove()
        {
            Console.WriteLine("The carcass {0} has been removed!", this.Name);
        }
        #endregion
    }
}
