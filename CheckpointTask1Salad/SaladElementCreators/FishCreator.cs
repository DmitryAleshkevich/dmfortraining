using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckpointTask1Salad
{
    public class FishCreator : SaladItemsCreator
    {      
        public override IComponent CreateComponent()
        {
            return new Fish();
        }
        public override void InitializeComponent(ref IComponent component, SaladItemProperties properties)
        {
            base.InitializeComponent(ref component, properties);
            var newComponent = component as Fish;                        
            newComponent.Color = properties.Color;
            component = (IComponent)newComponent;
        }
    }
}
