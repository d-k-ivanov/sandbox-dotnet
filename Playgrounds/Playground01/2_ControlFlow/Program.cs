using System;
using System.Runtime.Intrinsics.X86;
using CSCLib;

namespace _2_ControlFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleUtils.PrintSeparator();
            AmITooFat();
            ConsoleUtils.PrintSeparator();

            // -----------------------------------------------
            ConsoleUtils.EndOfProgram();
        }

        private static void AmITooFat()
        {
            var defaultForegroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter your age (years): ");
            string ageInput = Console.ReadLine();
            int age = int.Parse((string.IsNullOrWhiteSpace(ageInput) ? "1" : ageInput));
            Console.Write("Enter your weight (kilograms): ");
            string weightInput = Console.ReadLine();
            double weight = double.Parse((string.IsNullOrWhiteSpace(weightInput) ? "1" : weightInput));
            Console.Write("Enter your height (meters): ");
            string heightInput = Console.ReadLine();
            double height = double.Parse((string.IsNullOrWhiteSpace(heightInput) ? "1" : heightInput));

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            double bmi = weight / Math.Pow(height, 2);
            Console.WriteLine($"\tYour Body Mass Index is {bmi:f1}");

            bool isTooLow       = bmi <= 18.5;
            bool isNormal       = bmi > 18.5 && bmi <25;
            bool isAboveNormal  = bmi >= 25 && bmi <=30;
            bool isTooHigh      = bmi > 30;

            bool isFat = isAboveNormal || isTooHigh;

            if (isFat)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tYou need to go to gym!!!");
                Console.ForegroundColor = defaultForegroundColor;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\tYou in a good shape");
                Console.ForegroundColor = defaultForegroundColor;
            }

            Console.ForegroundColor = ConsoleColor.Green;

            if (isTooLow)
                Console.WriteLine("\tYour weight is too low. Be careful!");
            else if (isNormal)
                Console.WriteLine("\tYour weight is Okay. Keep going!");
            else if (isAboveNormal)
                Console.WriteLine("\tYour weight is in danger area. Start jogging!");
            else
                Console.WriteLine("\tYour weight is too high. Start jogging and stay on a diet!");

            string canIGoToTheClub = age > 18 ? "Welcome to the club" : "Stay home. You're too yong";
            Console.WriteLine($"\t{canIGoToTheClub}");

            Console.ForegroundColor = defaultForegroundColor;
        }
    }
}
