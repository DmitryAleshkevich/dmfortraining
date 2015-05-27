using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckpointTask1Salad
{
    public struct SaladItemProperties 
    {
        public double Calories { get; set; }
        public double Carbohydrates { get; set; }
        public double Fats { get; set; }
        public string Name { get; set; }
        public double Proteins { get; set; }
        public Tastes Taste { get; set; }
        public List<Vitamins> Vitamins { get; set; }
        public double Weight { get; set; }
        public string Color { get; set; }

    }
}
