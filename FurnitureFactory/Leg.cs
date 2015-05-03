using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureFactory
{
    public class Leg : Component
    {
        #region Fields
        private string material;        
        private string mechanism;        
        #endregion

        #region Properties
        public string Material
        {
            get { return material; }
            set { material = value; }
        }

        public string Mechanism
        {
            get { return mechanism; }
            set { mechanism = value; }
        }
        #endregion

        #region Constructors
        public Leg(string name, string color, string size, double price, string material, string mechanism)
            : base(name, color, size, price)
        {
            this.material = material;
            this.mechanism = mechanism;
        }
        #endregion

        #region Methods
        public override void Hang()
        {
            Console.WriteLine("The leg {0} has been hanged!", this.Name);
        }

        public override void Remove()
        {
            Console.WriteLine("The leg {0} has been removed!", this.Name);
        }
        #endregion
    }
}
