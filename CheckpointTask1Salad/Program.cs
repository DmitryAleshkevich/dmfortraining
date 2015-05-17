using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckpointTask1Salad
{
    public class Program
    {
        static void Main(string[] args)
        {
            SaladCollection greeksalad = new SaladCollection() { CollectionName = "Greek" };

            #region Salad Making
            IFabricComponents productfabric = new VegetableCreator();
            IComponent potatoproduct = productfabric.CreateComponent(840, 0.6, 0.2, "potato", 4.2, Tastes.Sweet, new List<Vitamins>() { Vitamins.A }, 840, ConsoleColor.Red);

            var chopedpotato = potatoproduct as IChopable;
            if (chopedpotato != null) chopedpotato.Chope();

            greeksalad.Add(potatoproduct);

            IComponent onionproduct = productfabric.CreateComponent(20.5, 0.7, 0.1, "red onion", 4.1, Tastes.Bitter, new List<Vitamins>() { Vitamins.B }, 36, ConsoleColor.Red);

            var chopedonion = onionproduct as IChopable;
            if (chopedonion != null) chopedonion.Chope();

            greeksalad.Add(onionproduct);

            IComponent cucumberproduct = productfabric.CreateComponent(15, 0.65, 0.11, "cucumber", 3.13, Tastes.Salty, new List<Vitamins>() { Vitamins.D }, 100, ConsoleColor.Green);

            var chopedcucumber = cucumberproduct as IChopable;
            if (chopedcucumber != null) chopedcucumber.Chope();

            greeksalad.Add(cucumberproduct);

            IComponent pepperproduct = productfabric.CreateComponent(26, 1.3, 0.1, "yellow pepper", 4.9, Tastes.Sweet, new List<Vitamins>() { Vitamins.C }, 80, ConsoleColor.Yellow);

            var chopedpepper = pepperproduct as IChopable;
            if (chopedpepper != null) chopedpepper.Chope();

            greeksalad.Add(pepperproduct);

            IComponent oliveproduct = productfabric.CreateComponent(296, 1.6, 23.7, "olive", 19, Tastes.Salty, new List<Vitamins>() { Vitamins.C }, 80, ConsoleColor.Green);

            var chopedolive = oliveproduct as IChopable;
            if (chopedolive != null) chopedolive.Chope();

            greeksalad.Add(oliveproduct);

            IFabricComponents greenfabric = new GreensCreator();

            IComponent dillproduct = greenfabric.CreateComponent(40, 2.5, 0.5, "dill", 6.3, Tastes.Sour, new List<Vitamins>() { Vitamins.N }, 100);

            var chopeddill = dillproduct as IChopable;
            if (chopeddill != null) chopeddill.Chope();

            greeksalad.Add(dillproduct);

            IFabricComponents cheesesfabric = new CheesesCreator();

            IComponent fetaproduct = cheesesfabric.CreateComponent(215, 1.5, 4.2, "feta cheese", 8.1, Tastes.Sour, new List<Vitamins>() { Vitamins.P }, 150);

            var chopedfeta = fetaproduct as IChopable;
            if (chopedfeta != null) chopedfeta.Chope();

            greeksalad.Add(fetaproduct);

            IFabricComponents spicesfabric = new SpicesCreator();

            IComponent oliveoil = spicesfabric.CreateComponent(153, 0, 153, "olive oil extra virgin", 0, Tastes.Sour, new List<Vitamins>() { Vitamins.K }, 17);

            greeksalad.Add(oliveoil);
            #endregion

            // caloricity:
            Console.WriteLine("The caloricity of salad is {0} kcal", greeksalad.CountCalories());

            // sorting by weight:
            Console.WriteLine("Unsorted:");
            foreach (var item in greeksalad)
            {
                Console.WriteLine("{0}", item.Name);
            }

            greeksalad.SortByWeight();

            Console.WriteLine("Sorted:");
            foreach (var item in greeksalad)
            {
                Console.WriteLine("{0}", item.Name);
            }

            // select by diapasone:
            Console.WriteLine("Calories diapasone (0-100):");

            IEnumerable<IComponent> coll1 = greeksalad.GetItemsDiapasoneForCalories(0, 100);

            foreach (var item in coll1)
            {
                Console.WriteLine("{0}", item.Name);
            }

            Console.ReadLine();
        }
    }
}
