using System;
using System.Collections.Generic;
using System.Text;

namespace _1_BaseFeatures
{
    internal static class InputOutput
    {
        internal static void IoBasics()
        {
            // Console.Clear();
            // Console.BackgroundColor = ConsoleColor.Black;
            var defaultForegroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\tEnter your name: ");
            string name = Console.ReadLine();
            Console.Write("\tEnter your age: ");
            string ageInput = Console.ReadLine();
            int age = int.Parse((string.IsNullOrWhiteSpace(ageInput) ? "0" : ageInput));

            Console.WriteLine($"\tHello {(string.IsNullOrWhiteSpace(name) ? "John Doe" : name)}! I'm {age} year old, too!");
            Console.ForegroundColor = defaultForegroundColor;
        }
    }
}
