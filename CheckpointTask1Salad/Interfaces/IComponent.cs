using System;
namespace CheckpointTask1Salad
{
    public interface IComponent
    {
        double Calories { get; set; }
        double Carbohydrates { get; set; }
        double Fats { get; set; }
        string Name { get; set; }
        double Proteins { get; set; }
        Tastes Taste { get; set; }
        System.Collections.Generic.List<Vitamins> Vitamins { get; set; }
        double Weight { get; set; }
    }
}
