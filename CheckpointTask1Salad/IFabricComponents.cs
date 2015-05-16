using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckpointTask1Salad
{
    public interface IFabricComponents
    {
        IComponent CreateComponent(double calories, double carbohydrates, double fats, string name, double proteins, Tastes taste, System.Collections.Generic.List<Vitamins> vitamins, double weight);
        IComponent CreateComponent(double calories, double carbohydrates, double fats, string name, double proteins, Tastes taste, System.Collections.Generic.List<Vitamins> vitamins, double weight, ConsoleColor color);
    }
}
