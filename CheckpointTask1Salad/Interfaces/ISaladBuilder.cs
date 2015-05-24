using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckpointTask1Salad
{
    public interface ISaladBuilder
    {
        void CookVegetables();
        void CookCannedFood();
        void CookCheeses();
        void CookFish();
        void CookGreens();
        void CookGroats();
        void CookMeat();
        void CookSpices();
        SaladCollection ReturnSalad();
    }
}
