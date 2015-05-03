using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureFactory
{
    public abstract class Component : Constructions, IMontage
    {
        #region Methods
        public virtual void Hang()
        {
            Console.WriteLine("The component {0} has been hanged!", this.Name);
        }

        public virtual void Remove()
        {
            Console.WriteLine("The component {0} has been removed!", this.Name);
        }

        public virtual Component CreateComponent()
        {
            return (Component)this.MemberwiseClone();
        }
        #endregion

        public Component(string name, string color, string size, double price)
            : base(name, color, size, price) {}

    }
}
