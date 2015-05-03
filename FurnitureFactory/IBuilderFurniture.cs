using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureFactory
{
    public interface IBuilderFurniture
    {
        void ComponentAdd(Component component);

        void FinishFurniture();

        Constructions ReturnFurniture();
    }
}
