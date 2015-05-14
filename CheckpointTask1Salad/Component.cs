using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckpointTask1Salad
{
    public abstract class Component
    {
        #region Fields

        private string name;        
        private double calories;
        private double proteins;
        private double fats;
        private double carbohydrates;
        private List<Vitamins> vitamins;
        private Tastes taste;
        private double weight;        

        #endregion

        #region Properties

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Calories
        {
            get { return calories; }
            set { calories = value; }
        }

        public double Proteins
        {
            get { return proteins; }
            set { proteins = value; }
        }

        public double Fats
        {
            get { return fats; }
            set { fats = value; }
        }

        public double Carbohydrates
        {
            get { return carbohydrates; }
            set { carbohydrates = value; }
        }

        public List<Vitamins> Vitamins
        {
            get { return vitamins; }
            set { vitamins = value; }
        }

        public Tastes Taste
        {
            get { return taste; }
            set { taste = value; }
        }

        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        #endregion
    }
}
