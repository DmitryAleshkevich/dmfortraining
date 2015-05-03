using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureFactory
{
    public class Chair : Constructions, IComfortSittable, ISellable
    {
        #region Fields
        private string material;
        private string form;
        private List<Component> components;
        #endregion

        #region Properties
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
        public virtual void Sit()
        {
            Console.WriteLine("Sitting on chair {0}",this.Name);
        }

        public virtual void SitComfortable()
        {
            Console.WriteLine("Sitting with comfort on chair {0}", this.Name);
        }

        public virtual void Sell(double price)
        {
            Console.WriteLine("The chair {0} has been sold on price {1}!", this.Name, price);
        }
        #endregion 

        public Chair(string name, string color, string size, double price, string material, string form, List<Component> components)
            : base(name, color, size, price) 
        {
            this.material = material;
            this.form = form;
            this.components = components;
        }
    }
}
