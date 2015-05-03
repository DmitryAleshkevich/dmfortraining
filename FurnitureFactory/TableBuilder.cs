using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureFactory
{
    public class TableBuilder : ConstructionsBuilder
    {
        #region Fields
        private string form;
        private string mechanism;        
        #endregion

        #region Properties
        public string Form
        {
            get { return form; }
            set { form = value; }
        }

        public string Mechanism
        {
            get { return mechanism; }
            set { mechanism = value; }
        }
        #endregion

        #region Method
        public override Constructions ReturnFurniture()
        {
            return new Table(base.name, base.color, base.size, base.price, base.material, this.form, base.componentsList, this.mechanism);
        }
        #endregion

        #region Constructors
        public TableBuilder(string name, string form, string material, string color, string size, double price, string mechanism)
            : base(name,material,color,size,price)
        {
            this.form = form;
            this.mechanism = mechanism;
        }
        #endregion
    }
}
