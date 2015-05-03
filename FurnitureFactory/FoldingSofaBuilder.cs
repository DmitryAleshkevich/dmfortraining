using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureFactory
{
    public class FoldingSofaBuilder : ConstructionsBuilder
    {
        #region Fields
        private string form;
        private int placesCount;
        #endregion

        #region Properties
        public string Form
        {
            get { return form; }
            set { form = value; }
        }

        public int PlacesCount
        {
            get { return placesCount; }
            set { placesCount = value; }
        }
        #endregion

        #region Method
        public override Constructions ReturnFurniture()
        {
            return new FoldingSofa(base.name, base.color, base.size, base.price, base.material, this.form, base.componentsList, this.placesCount);
        }
        #endregion

        #region Constructors
        public FoldingSofaBuilder(string name, string form, string material, string color, string size, double price, int placesCount)
            : base(name,material,color,size,price)
        {
            this.form = form;
            this.placesCount = placesCount;
        }
        #endregion
    }
}
