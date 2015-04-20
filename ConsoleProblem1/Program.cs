using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProblem1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input variable X:");

            string userX = Console.ReadLine();

            double x;

            bool isSuccessful = double.TryParse(userX, out x);

            if (isSuccessful)
            {
                LinearFunction lf = new LinearFunction(3, 5);
                Console.WriteLine("Result is: {0} with coeffA = 3 & coeffB = 5 & variable {1}", lf.GetFunctionValue(x), x);
            }
            else Console.WriteLine("Coud not convert you x into double!");

            Console.ReadLine();

        }
    }
}
