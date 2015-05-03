using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureFactory
{
    public class Cupboard : Stand
    {
        #region Methods
        public override void Sell(double price)
        {
            Console.WriteLine("The cupboard {0} has been sold on price {1}!", this.Name, price);
        }

        public override void Put()
        {
            Console.WriteLine("The item has been putted on/in cupboard {0}!", this.Name);
        }

        public override void Take()
        {
            Console.WriteLine("The item has been taken from cupboard {0}!", this.Name);
        }

        public override void Open()
        {
            Console.WriteLine("The cupboard {0} has been opened!", this.Name);
        }

        public override void Close()
        {
            Console.WriteLine("The cupboard {0} has been closed!", this.Name);
        }
        #endregion 

        public Cupboard(string name, string color, string size, double price, string material, string form, List<Component> components, string type)
            : base(name, color, size, price, material, form, components, type) {}  
    }
}
