using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureFactory
{
    public interface ILieDownable : IComfortSittable
    {
        void LieDown();
    }
}
