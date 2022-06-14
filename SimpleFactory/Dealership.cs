using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory
{
    public class Dealership
    {
        public static void ChooseCar()
        {
            Console.WriteLine("==== Choose you Car ====");
            Console.WriteLine("1: Audi");
            Console.WriteLine("2: Ferrari");

            var chooserCar = Console.ReadLine();

            switch (chooserCar)
            {
                case "1":
                    var audi = new Audi();
                    audi.Make();
                    audi.Sale();
                    break;
                case "2":
                    var ferrari = new Ferrari();
                    ferrari.Make();
                    ferrari.Sale();
                    break;
                default:
                    Console.WriteLine("Car does not exist!");
                    break;
            }
        }
    }
}
