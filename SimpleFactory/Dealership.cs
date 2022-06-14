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

            try
            {
                var car = CarFactory.Create(chooserCar);
                car.Make();
                car.Sale();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
    }
}
