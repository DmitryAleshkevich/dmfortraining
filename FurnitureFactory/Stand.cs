using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureFactory
{
    public class Stand : Constructions, ISellable, IOpenClose, IMovable
    {
        #region Fields
        private string material;
        private string form;
        private string type;
        private List<Component> components;
        #endregion

        #region Properties
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public List<Component> Components
        {
            get { return components; }
            set { components = value; }
        }

        public string Form
        {
            get { return form; }
            set { form = value; }
        }

        public string Kind
        {
            get { return material; }
            set { material = value; }
        }
        #endregion

        #region Methods
        public virtual void Sell(double price)
        {
            Console.WriteLine("The stand {0} has been sold on price {1}!", this.Name, price);
        }

        public virtual void Put()
        {
            Console.WriteLine("The item has been putted on/in stand {0}!", this.Name);
        }

        public virtual void Take()
        {
            Console.WriteLine("The item has been taken from stand {0}!", this.Name);
        }

        public virtual void Open()
        {
            Console.WriteLine("The stand {0} has been opened!", this.Name);
        }

        public virtual void Close()
        {
            Console.WriteLine("The stand {0} has been closed!", this.Name);
        }
        #endregion 

        public Stand(string name, string color, string size, double price, string material, string form, List<Component> components, string type)
            : base(name, color, size, price) 
        {
            this.material = material;
            this.form = form;
            this.components = components;
            this.type = type;
        }        
    }
}
