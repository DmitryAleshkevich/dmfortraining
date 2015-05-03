using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureFactory
{
    public class StandBuilder : ConstructionsBuilder
    {
        #region Fields
        private string form;
        private string type;
        #endregion

        #region Properties
        public string Form
        {
            get { return form; }
            set { form = value; }
        }

        public string Type
        {
          get { return type; }
          set { type = value; }
        }
        #endregion

        #region Method
        public override Constructions ReturnFurniture()
        {
            return new Stand(base.name, base.color, base.size, base.price, base.material, this.form, base.componentsList,this.type);
        }
        #endregion

        #region Constructors
        public StandBuilder(string name, string form, string material, string color, string size, double price, string type)
            : base(name,material,color,size,price)
        {
            this.form = form;
            this.type = type;
        }
        #endregion
    }
}
