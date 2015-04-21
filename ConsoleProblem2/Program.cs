using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProblem2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Item item1 = new Item();
            StrItem item2 = new StrItem();
            IAnyItem[] items = { item1, item2 };

            foreach (IAnyItem item in items)
            {
                WorkWith(item);
            }

            Console.ReadLine();
        }

        static void WorkWith(IAnyItem item)
        {
            DateTime dt1 = DateTime.UtcNow;

            ArrayList al = new ArrayList();
            Random rand = new Random();
            double costSum = 0;

            for (int i = 1; i < 100001; i++)
            {
                IAnyItem it = item.CreateItem("Item" + i, rand.Next(), rand.Next());
                al.Add(it);
                costSum += it.Cost;
            }
               
            Console.WriteLine("Total sum is {0}", costSum);

            DateTime dt2 = DateTime.UtcNow;

            TimeSpan dt3 = dt2 - dt1;

            Console.WriteLine("Total time is {0} ms", dt3.Milliseconds);
            
        }

    }
}
