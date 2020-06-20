using System;
using System.Collections.Generic;
using System.Linq;
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
            ConsoleUtils.PrintSeparator();

            Lists();

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

        private static void Lists()
        {
            var list1 = new List<int>() {1, 6, 23, 6, 12, 1, 5, 9};
            list1.Add(10);
            foreach (var i in list1)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

            int[] ar1 = {1, 6, 14};
            list1.AddRange(ar1);

            foreach (var i in list1)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

            if (list1.Remove(14))
            {
                Console.WriteLine("Item removed");
            }
            else
            {
                Console.WriteLine("Item not found");
            }

            list1.RemoveAt(0);

            foreach (var i in list1)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

            list1.Reverse();

            foreach (var i in list1)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

            bool contains = list1.Contains(4);

            int min = list1.Min();
            int max = list1.Max();
            Console.WriteLine($"Min={min}\tMax={max}");

            Console.WriteLine($"IndexOf(6)={list1.IndexOf(6)}");
            Console.WriteLine($"LastIndexOf(6)={list1.LastIndexOf(6)}");

            for (int i = 0; i < list1.Count; i++)
            {
                Console.Write($"{list1[i]} ");
            }
            Console.WriteLine();
        }
    }
}
