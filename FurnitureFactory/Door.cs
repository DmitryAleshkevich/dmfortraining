using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureFactory
{
    public class Door : Component, IOpenClose, ISellable
    {
        #region Fields
        private string material;
        private Sides side;
        private string mechanism;
        private string form;
        #endregion

        #region Properties
        public string Form
        {
            get { return form; }
            set { form = value; }
        }

        public string Mechanism
        {
            get { return mechanism; }
            set { mechanism = value; }
        }

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
        public Door(string name, string color, string size, double price, string material, Sides side, string mechanism, string form)
            : base(name, color, size, price)
        {
            this.material = material;
            this.side = side;
            this.mechanism = mechanism;
            this.form = form;
        }
        #endregion

        #region Methods
        public override void Hang()
        {
            Console.WriteLine("The door {0} has been hanged!", this.Name);
        }

        public override void Remove()
        {
            Console.WriteLine("The door {0} has been removed!", this.Name);
        }

        public void Open()
        {
            Console.WriteLine("The door {0} has been opened!", this.Name);
        }

        public void Close()
        {
            Console.WriteLine("The door {0} has been closed!", this.Name);
        }

        public void Sell(double price)
        {
            Console.WriteLine("The door {0} has been sold on price {1}!", this.Name, price);
        }
        #endregion 
    }
}
