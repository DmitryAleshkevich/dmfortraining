using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckpointTask1Salad
{
    public class GroatsCreator : IFabricComponents
    {
        public IComponent CreateComponent(double calories, double carbohydrates, double fats, string name, double proteins, Tastes taste, List<Vitamins> vitamins, double weight)
        {
            return new Groats() { Calories = calories, Carbohydrates = carbohydrates, Fats = fats, Name = name, Proteins = proteins, Taste = taste, Vitamins = vitamins, Weight = weight };
        }

        public IComponent CreateComponent(double calories, double carbohydrates, double fats, string name, double proteins, Tastes taste, List<Vitamins> vitamins, double weight, ConsoleColor color)
        {
            throw new NotImplementedException("Coudn`t create component because of it hasn`t color!");
        }
    }
}
