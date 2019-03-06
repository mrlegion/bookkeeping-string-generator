using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumToString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter sum: ");
            string money = Console.ReadLine();
            Console.WriteLine("Very Good!");
            Console.WriteLine("Rub: ");
            Console.WriteLine(Model.NumberToString(money, false));

            // delay
            Console.ReadKey();
        }
    }
}
