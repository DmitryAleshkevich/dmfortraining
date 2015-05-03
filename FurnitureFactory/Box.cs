using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureFactory
{
    public class Box : Component, IOpenClose, ISellable
    {
        #region Fields
        private string material;
        private string form;
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
   

        public string Form
        {
            get { return form; }
            set { form = value; }
        }
        #endregion

        #region Constructors
        public Box(string name, string color, string size, double price, string material, string mechanism, string form)
            : base(name, color, size, price)
        {
            this.material = material;
            this.mechanism = mechanism;
            this.form = form;
        }
        #endregion

        #region Methods
        public override void Hang()
        {
            Console.WriteLine("The box {0} has been hanged!", this.Name);
        }

        public override void Remove()
        {
            Console.WriteLine("The box {0} has been removed!", this.Name);
        }

        public void Open()
        {
            Console.WriteLine("The box {0} has been opened!", this.Name);
        }

        public void Close()
        {
            Console.WriteLine("The box {0} has been closed!", this.Name);
        }

        public void Sell(double price)
        {
            Console.WriteLine("The box {0} has been sold on price {1}!", this.Name, price);
        }
        #endregion
    }
}
