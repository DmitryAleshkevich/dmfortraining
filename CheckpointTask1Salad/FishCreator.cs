using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckpointTask1Salad
{
    public class FishCreator : IFabricComponents
    {
        public IComponent CreateComponent(double calories, double carbohydrates, double fats, string name, double proteins, Tastes taste, List<Vitamins> vitamins, double weight)
        {
            return new Fish() { Calories = calories, Carbohydrates = carbohydrates, Fats = fats, Name = name, Proteins = proteins, Taste = taste, Vitamins = vitamins, Weight = weight };
        }

        public IComponent CreateComponent(double calories, double carbohydrates, double fats, string name, double proteins, Tastes taste, List<Vitamins> vitamins, double weight, ConsoleColor color)
        {
            return new Fish() { Calories = calories, Carbohydrates = carbohydrates, Fats = fats, Name = name, Proteins = proteins, Taste = taste, Vitamins = vitamins, Weight = weight, Color = color };
        }
    }
}
