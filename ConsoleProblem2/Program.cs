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
            WorkWith(MyEnumModules.Class);
            WorkWith(MyEnumModules.Structure);
            Console.ReadLine();
        }

        static void WorkWith(MyEnumModules enm)
        {
            DateTime dt1 = DateTime.UtcNow;

            ArrayList al = new ArrayList();
            Random rand = new Random();
            double costSum = 0;

            if (enm == MyEnumModules.Class)  
            {
                for (int i = 1; i < 100001; i++)
                {
                    Item it = new Item("Item" + i, rand.Next(), rand.Next());
                    al.Add(it);
                    costSum += it.Cost;
                }
            }        
            else
            {
                for (int i = 1; i < 100001; i++)
                {
                    StrItem it = new StrItem("Item" + i, rand.Next(), rand.Next());
                    al.Add(it);
                    costSum += it.Cost;
                }
            }
                
            Console.WriteLine("Total sum is {0}", costSum);

            DateTime dt2 = DateTime.UtcNow;

            TimeSpan dt3 = dt2 - dt1;

            Console.WriteLine("Total time is {0} ms", dt3.Milliseconds);
            
        }

        public enum MyEnumModules
        {
            Class,Structure
        }
    }
}
