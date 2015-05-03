using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureFactory
{
    public class Glass : Component, ISellable
    {
        #region Fields
        private int clarity;
        private string form;
        #endregion

        #region Properties
        public int Clarity
        {
            get { return clarity; }
            set { clarity = value; }
        }

        public string Form
        {
            get { return form; }
            set { form = value; }
        }
        #endregion

        #region Constructors
        public Glass(string name, string color, string size, double price, string form, int clarity)
            : base(name, color, size, price)
        {
            this.clarity = clarity;
            this.form = form;
        }
        #endregion

        #region Methods
        
        public void Reflect()
        {
            Console.WriteLine("The glass {0} reflect the light!", this.Name);
        }

        public override void Hang()
        {
            Console.WriteLine("The glass {0} has been hanged!", this.Name);
        }

        public override void Remove()
        {
            Console.WriteLine("The glass {0} has been removed!", this.Name);
        }

        public void Sell(double price)
        {
            Console.WriteLine("The glass {0} has been sold on price {1}!", this.Name, price);
        }
        #endregion 

    }
}
