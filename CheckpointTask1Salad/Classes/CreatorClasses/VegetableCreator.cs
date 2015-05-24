using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckpointTask1Salad
{
    public class VegetableCreator : SaladItemsCreator
    {
        public override IComponent CreateComponent()
        {
            return new Vegetable();
        }

        public override void InitializeComponent(ref IComponent component, SaladItemProperties properties)
        {
            var newComponent = component as Vegetable;
            newComponent.Calories = properties.Calories;
            newComponent.Carbohydrates = properties.Carbohydrates;
            newComponent.Fats = properties.Fats;
            newComponent.Name = properties.Name;
            newComponent.Proteins = properties.Proteins;
            newComponent.Taste = properties.Taste;
            newComponent.Vitamins = properties.Vitamins;
            newComponent.Weight = properties.Weight;
            newComponent.Color = properties.Color;
            component = (IComponent)newComponent;
        }
    }
}
