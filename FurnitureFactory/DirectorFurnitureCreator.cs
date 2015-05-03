using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureFactory
{
    public class DirectorFurnitureCreator
    {
        private IBuilderFurniture furnitureBuilder;

        public void InitializeBuilder(IBuilderFurniture furnitureBuilder)
        {
            this.furnitureBuilder = furnitureBuilder;
        }

        public void ConstructFurniture(Component component)
        {
            furnitureBuilder.ComponentAdd(component);              
        }

        public Constructions ReturnConstruction()
        {
            furnitureBuilder.FinishFurniture();
            return furnitureBuilder.ReturnFurniture();
        }
    }
}
