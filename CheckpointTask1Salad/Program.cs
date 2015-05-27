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
            Chief boss = new Chief();
            ISaladBuilder builder = new GreekSaladBuilder();
            var greeksalad = boss.MakeSalad(builder);

            // caloricity:
            Console.WriteLine("The caloricity of salad is {0} kcal", greeksalad.CountCalories());

            // sorting by weight:
            Console.WriteLine("Unsorted:");
            foreach (var item in greeksalad)
            {
                Console.WriteLine("{0}", item.Name);
            }

            greeksalad.Sort(x => x.Weight);

            Console.WriteLine("Sorted:");
            foreach (var item in greeksalad)
            {
                Console.WriteLine("{0}", item.Name);
            }

            // select by diapasone:
            Console.WriteLine("Calories diapasone (0-100):");

            IEnumerable<IComponent> coll1 = greeksalad.GetItemsRangeForCalories(0, 100);

            foreach (var item in coll1)
            {
                Console.WriteLine("{0}", item.Name);
            }

            Console.ReadLine();
        }
    }
}
