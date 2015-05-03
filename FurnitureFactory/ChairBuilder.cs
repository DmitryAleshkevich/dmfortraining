using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureFactory
{
    public class ChairBuilder : ConstructionsBuilder
    {
        #region Fields
        private string form;
        #endregion

        #region Properties
        public string Form
        {
            get { return form; }
            set { form = value; }
        }
        #endregion

        #region Method
        public override Constructions ReturnFurniture()
        {
            return new Chair(base.name, base.color, base.size, base.price, base.material, this.form, base.componentsList);
        }
        #endregion

        #region Constructors
        public ChairBuilder(string name, string form, string material, string color, string size, double price)
            : base(name,material,color,size,price)
        {
            this.form = form;    
        }
        #endregion
    }
}
