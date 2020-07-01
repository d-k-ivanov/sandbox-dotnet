using System;
using CSCLib;

namespace AdvancedTopics
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleUtils.PrintSeparator();

            StartAll();

            // -----------------------------------------------
            ConsoleUtils.EndOfProgram();
        }

        private static void StartAll()
        {
            DelegatesDemo();
            // ConsoleUtils.PrintSeparator();
        }

        private static void DelegatesDemo()
        {
            var car = new Car();

            car.RegisterOnTooFast(HandleTooFast);

            car.Start();
            Console.WriteLine("Accelerating....");
            for (var i = 0; i < 40; i++)
            {
                Console.WriteLine($"Current Speed: {car.Speed}");
                car.Accelerate();
            }
        }

        private static void HandleTooFast(Car car)
        {
            Console.WriteLine($"Too fast. Speed: {car.Speed}. Stopping...");
            car.Stop();
        }
    }
}
