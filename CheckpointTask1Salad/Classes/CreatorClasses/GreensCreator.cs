using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckpointTask1Salad
{
    public class GreensCreator : SaladItemsCreator
    {
        public override IComponent CreateComponent()
        {
            return new Greens();
        }
    }
}
