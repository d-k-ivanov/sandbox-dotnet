using System;
using System.Collections.Generic;
using System.Text;

namespace _1_BaseFeatures
{
    internal class HomeWork
    {
        internal static void HeronArea()
        {
            var defaultForegroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("Enter a: ");
            string sideAInput = Console.ReadLine();
            double sideA = double.Parse((string.IsNullOrWhiteSpace(sideAInput) ? "1" : sideAInput));

            Console.Write("Enter b: ");
            string sideBInput = Console.ReadLine();
            double sideB = double.Parse((string.IsNullOrWhiteSpace(sideBInput) ? "1" : sideBInput));

            Console.Write("Enter c: ");
            string sideCInput = Console.ReadLine();
            double sideC = double.Parse((string.IsNullOrWhiteSpace(sideCInput) ? "1" : sideCInput));

            double perimeter = (sideA + sideB + sideC) / 2;
            double area = Math.Sqrt(perimeter * (perimeter - sideA) * (perimeter - sideB) * (perimeter - sideC));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  Triangle:\n" +
                              $"\tSide A: {sideA}\n" +
                              $"\tSide B: {sideB}\n" +
                              $"\tSide C: {sideC}\n" +
                              $"  Area: {area}");
            Console.ForegroundColor = defaultForegroundColor;
        }

        internal static void UserProfile()
        {
            var defaultForegroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("Enter your Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your Surname: ");
            string surname = Console.ReadLine();
            Console.Write("Enter your age (years): ");
            string ageInput = Console.ReadLine();
            int age = int.Parse((string.IsNullOrWhiteSpace(ageInput) ? "1" : ageInput));
            Console.Write("Enter your weight (kilograms): ");
            string weightInput = Console.ReadLine();
            double weight = double.Parse((string.IsNullOrWhiteSpace(weightInput) ? "1" : weightInput));
            Console.Write("Enter your height (meters): ");
            string heightInput = Console.ReadLine();
            double height = double.Parse((string.IsNullOrWhiteSpace(heightInput) ? "1" : heightInput));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(
                $"  Your profile:\n\tFull Name: {surname} {name}\n\tAge: {age}\n\tWeight: {weight}\n\t" +
                $"Height: {height}\n\tBody Mass Index: {weight/Math.Pow(height, 2)}");
            Console.ForegroundColor = defaultForegroundColor;
        }
    }
}
