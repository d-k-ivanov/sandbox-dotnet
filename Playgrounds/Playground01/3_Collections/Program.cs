using System;
using CSCLib;

namespace _3_Collections
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
            Arrays();
            // ConsoleUtils.PrintSeparator();
        }

        private static void Arrays()
        {
            int[] a1 = new int[5];
            int[] a2 = {1, 2, 3, 4, 5};
            Array a3 = new int[5];
            Array a4 = Array.CreateInstance(typeof(int), 5);

            a4.SetValue(10, 1);
            foreach (var item in a4)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9};
            int index = Array.BinarySearch(numbers, 7);
            Console.WriteLine($"Index of '7' = {index}");

            int[] numbersCopy = new int[10];
            Array.Copy(numbers, numbersCopy, numbers.Length);

            int[] numbersCopy2 = new int[10];
            numbers.CopyTo(numbersCopy2, 0);

            Array.Reverse(numbersCopy);
            foreach (var number in numbersCopy)
            {
                Console.Write($"{number} ");
            }

            Console.WriteLine();

            Array.Sort(numbersCopy);
            foreach (var number in numbersCopy)
            {
                Console.Write($"{number} ");
            }

            Console.WriteLine();

            Array.Clear(numbersCopy, 0, numbersCopy.Length);
            foreach (var number in numbersCopy)
            {
                Console.Write($"{number} ");
            }

            Console.WriteLine();


        }
    }
}
