using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureFactory
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConstructionsCollection<Constructions> newSpringCollection = new ConstructionsCollection<Constructions>() { CollectionName = "Elvis" };

            // make components:
            #region Components
            Component legPrototype = new Leg("Elvis leg", "Gray", "10x5x3", 75000, "particleboard", "fixed");

            Component leg1 = legPrototype.CreateComponent();
            Component leg2 = legPrototype.CreateComponent();
            Component leg3 = legPrototype.CreateComponent();
            Component leg4 = legPrototype.CreateComponent();
            Component leg5 = legPrototype.CreateComponent();
            Component leg6 = legPrototype.CreateComponent();
            Component leg7 = legPrototype.CreateComponent();
            Component leg8 = legPrototype.CreateComponent();            

            Component carcassProtorype = new Carcass("Elvis carcass", "Grey", "120x110x15", 500000, "particleboard");

            Component carcass1 = carcassProtorype.CreateComponent();
            Component carcass2 = carcassProtorype.CreateComponent();

            Component leftArmPrototype = new Armrest("Elvis left arm", "Grey", "45x20x8", 200000, "particleboard", Sides.Left);
            Component rightArmPrototype = new Armrest("Elvis right arm", "Grey", "45x20x8", 200000, "particleboard", Sides.Right);

            Component leftArm1 = leftArmPrototype.CreateComponent();
            Component leftArm2 = leftArmPrototype.CreateComponent();

            Component rightArm1 = rightArmPrototype.CreateComponent();
            Component rightArm2 = rightArmPrototype.CreateComponent();

            Component downPoufPrototype = new Pouf("Elvis down pouf", "Grey", "120x70x10", 400000, "polyuretan", Sides.Down);
            Component upPoufPrototype = new Pouf("Elvis up pouf", "Grey", "120x60x10", 450000, "polyuretan", Sides.Up);

            Component downPouf1 = downPoufPrototype.CreateComponent();
            Component downPouf2 = downPoufPrototype.CreateComponent();

            Component upPouf1 = upPoufPrototype.CreateComponent();
            Component upPouf2 = upPoufPrototype.CreateComponent();
            #endregion

            // make production:
            #region Production
            DirectorFurnitureCreator dir = new DirectorFurnitureCreator();

            ConstructionsBuilder chairBuilder = new ChairBuilder("Elvis chair", "Squared", "particleboard & polyuretan", "Grey", "150x120x40", 4000000);
            ConstructionsBuilder foldingBuilder = new FoldingChairBuilder("Elvis folding chair", "Rectangled", "particleboard & polyuretan", "Grey", "150x220x40", 4900000);

            dir.InitializeBuilder(chairBuilder);
            dir.ConstructFurniture(carcass1);
            dir.ConstructFurniture(leg1);
            dir.ConstructFurniture(leg2);
            dir.ConstructFurniture(leg3);
            dir.ConstructFurniture(leg4);
            dir.ConstructFurniture(leftArm1);
            dir.ConstructFurniture(rightArm1);
            dir.ConstructFurniture(downPouf1);
            dir.ConstructFurniture(upPouf1);
            
            Constructions chair = dir.ReturnConstruction();

            dir.InitializeBuilder(foldingBuilder);
            dir.ConstructFurniture(carcass1);
            dir.ConstructFurniture(leg5);
            dir.ConstructFurniture(leg6);
            dir.ConstructFurniture(leg7);
            dir.ConstructFurniture(leg8);
            dir.ConstructFurniture(rightArm2);
            dir.ConstructFurniture(leftArm2);
            dir.ConstructFurniture(upPouf2);
            dir.ConstructFurniture(downPouf2);

            Constructions foldingChair = dir.ReturnConstruction();
            #endregion

            // collection manipulations:
            #region Collection
            newSpringCollection.Add(foldingChair);
            newSpringCollection.Add(chair);

            Console.WriteLine("Unsorted:");
            foreach (var item in newSpringCollection)
            {
                Console.WriteLine("{0}", item.Name);
            }

            newSpringCollection.SortByPrice();

            Console.WriteLine("Sorted:");
            foreach (var item in newSpringCollection)
            {
                Console.WriteLine("{0}", item.Name);
            }

            Console.WriteLine("Price diapasone (3500000-4500000):");

            IEnumerable<Constructions> coll1 = newSpringCollection.GetItemsForDiapasone(3500000, 4500000);

            foreach (var item in coll1)
            {
                Console.WriteLine("{0}", item.Name);
            }

            #endregion

            Console.ReadLine();
        }
    }
}
