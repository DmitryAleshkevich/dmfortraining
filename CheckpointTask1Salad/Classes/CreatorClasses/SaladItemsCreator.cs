using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckpointTask1Salad
{
    public abstract class SaladItemsCreator : IFabricComponents
    {
        public abstract IComponent CreateComponent();
        public virtual void InitializeComponent(ref IComponent component, SaladItemProperties properties)
        {
            component.Calories = properties.Calories;
            component.Carbohydrates = properties.Carbohydrates;
            component.Fats = properties.Fats;
            component.Name = properties.Name;
            component.Proteins = properties.Proteins;
            component.Taste = properties.Taste;
            component.Vitamins = properties.Vitamins;
            component.Weight = properties.Weight;
        }
    }
}
