using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureFactory
{
    public abstract class ConstructionsBuilder : IBuilderFurniture
    {
        #region Fields
        protected string name;
        protected string material;
        protected string color;
        protected string size;
        protected double price;
        protected List<Component> componentsList = new List<Component>();
        #endregion

        #region Properties
        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public string Size
        {
            get { return size; }
            set { size = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        public string Material
        {
            get { return material; }
            set { material = value; }
        }
        #endregion

        #region Methods
        public void ComponentAdd(Component component)
        {
            this.componentsList.Add(component);
            component.Hang();
        }

        public void FinishFurniture()
        {
            Console.WriteLine("The construction is finished!");
        }

        public abstract Constructions ReturnFurniture();
       
        #endregion

        #region Constructors
        public ConstructionsBuilder( string name, string material, string color, string size, double price)
        {
            this.name = name;
            this.material = material;
            this.color = color;
            this.size = size;
            this.price = price;
        }
        #endregion
    }
}
