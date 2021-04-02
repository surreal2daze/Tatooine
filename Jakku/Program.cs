using System;
using System.Diagnostics;
using StarWarsLibrary;

namespace Jakku
{
    class Program
    {
        static void Main(string[] args)
        {
            StarWarsDeepCore context = new StarWarsDeepCore();

            Console.WriteLine(@" r2d2            ");
            Console.WriteLine(@"             .=. ");
            Console.WriteLine(@"            '==c|");
            Console.WriteLine(@"            [)-+|");
            Console.WriteLine(@"            //'_|");
            Console.WriteLine(@"       snd /]==;\");
            Console.WriteLine(@"---------------------------");



            do
            {

                Console.Write(@"Input Number of passengers: ");

                try
                {
                    int number = int.Parse(Console.ReadLine());
                    Console.WriteLine("-----------------------------------");
                    context.CarryPassengers = number;

                    foreach (var item in context.AllStarshipsWithPilot())
                    {
                        Console.WriteLine($"{item.StarshipName} - {item.StarshipPilot}");
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Error");
                }
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Press any key to try again. Input q to exit.");
                if (Console.ReadLine().ToLower() == "q")
                {
                    break;
                }

            } while (true);

            Console.WriteLine("Press Any Key!");
            Console.Read();
        }
    }
}
