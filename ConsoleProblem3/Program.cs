using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProblem3
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle tr = new Triangle(4, 3, 5);

            Console.WriteLine("This triangle is {0}", tr.GetTriangleType());

            tr.SideA = 20;

            Console.WriteLine("This triangle is {0}", tr.GetTriangleType());

            tr.SideA = 7;

            Console.WriteLine("This triangle is {0}", tr.GetTriangleType());

            tr.SideA = 5;

            Console.WriteLine("This triangle is {0}", tr.GetTriangleType());

            Console.ReadLine();

        }
    }
}
