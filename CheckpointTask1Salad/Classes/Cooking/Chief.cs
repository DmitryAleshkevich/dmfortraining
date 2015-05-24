using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckpointTask1Salad
{
    public class Chief
    {
        public SaladCollection MakeSalad(ISaladBuilder builder)
        {
            builder.CookVegetables();
            builder.CookMeat();
            builder.CookFish();
            builder.CookCannedFood();
            builder.CookCheeses();
            builder.CookGreens();
            builder.CookGroats();
            builder.CookSpices();
            return builder.ReturnSalad();
        }
    }
}
