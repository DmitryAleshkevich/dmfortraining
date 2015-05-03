using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureFactory
{
    public class FoldingChair : Chair, ILieDownable, ITransformable
    {
        public FoldingChair(string name, string color, string size, double price, string material, string form, List<Component> components)
            : base(name, color, size, price, material, form, components) { }

        #region Methods
        public virtual void Transform()
        {
            Console.WriteLine("The folding chair {0} has been transformed!", this.Name);
        }

        public virtual void LieDown()
        {
            Console.WriteLine("Layed down on folding chair {0}!", this.Name);
        }

        public override void Sit()
        {
            Console.WriteLine("Sitting on folding chair {0}", this.Name);
        }

        public override void SitComfortable()
        {
            Console.WriteLine("Sitting with comfort on folding chair {0}", this.Name);
        }

        public override void Sell(double price)
        {
            Console.WriteLine("The folding chair {0} has been sold on price {1}!", this.Name, price);
        }
        #endregion
    }
}
