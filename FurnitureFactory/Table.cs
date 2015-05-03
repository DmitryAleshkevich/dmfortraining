using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureFactory
{
    public class Table : Constructions, ISellable, IMovable
    {
        #region Fields
        private string material;
        private string form;
        private string mechanism;        
        private List<Component> components;
        #endregion

        #region Properties
        public string Mechanism
        {
            get { return mechanism; }
            set { mechanism = value; }
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
            Console.WriteLine("The table {0} has been sold on price {1}!", this.Name, price);
        }

        public void Put()
        {
            Console.WriteLine("The item has been put on table {0}!", this.Name);
        }

        public void Take()
        {
            Console.WriteLine("The item has been taken on table {0}!", this.Name);
        }
        #endregion 

        public Table(string name, string color, string size, double price, string material, string form, List<Component> components, string mechanism)
            : base(name, color, size, price) 
        {
            this.material = material;
            this.form = form;
            this.components = components;
            this.mechanism = mechanism;
        }       
    }
}
