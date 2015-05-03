using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureFactory
{
    public class BedBuilder : ConstructionsBuilder
    {
        #region Fields
        private string form;
        private int placesCount;
        private int lyingPlacesCount;
        #endregion

        #region Properties
        public int LyingPlacesCount
        {
            get { return lyingPlacesCount; }
            set { lyingPlacesCount = value; }
        }

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
            return new Bed(base.name, base.color, base.size, base.price, base.material, this.form, base.componentsList, this.placesCount, this.lyingPlacesCount);
        }
        #endregion

        #region Constructors
        public BedBuilder(string name, string form, string material, string color, string size, double price, int placesCount, int lyingPlacesCount)
            : base(name,material,color,size,price)
        {
            this.form = form;
            this.placesCount = placesCount;
            this.lyingPlacesCount = lyingPlacesCount;
        }
        #endregion
    }
}
