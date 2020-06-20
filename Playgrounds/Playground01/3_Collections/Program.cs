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
            ConsoleUtils.PrintSeparator();

            Dictionaries();
            ConsoleUtils.PrintSeparator();

            Stacks();
            ConsoleUtils.PrintSeparator();

            Queues();
            ConsoleUtils.PrintSeparator();

            ArraysMultiDim();
            ConsoleUtils.PrintSeparator();

            ArraysJagged();
            ConsoleUtils.PrintSeparator();

            ArraysCustom();
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

        private static void Dictionaries()
        {
            var people = new Dictionary<int, string>();
            people.Add(1, "John");
            people.Add(2, "Bob");
            people.Add(3, "Alice");

            var people2 = new Dictionary<int, string> {{1, "Juan"}, {2, "Jesus"}, {3, "Veronica"}};

            string name = people[1];
            Console.WriteLine($"people2[1] = {people2[1]}\tpeople2[2] = {people2[2]}\tpeople2[3] = {people2[3]}");

            Console.Write("people2 keys: ");
            foreach (var people2Key in people2.Keys)
            {
                Console.Write($"{people2Key} ");
            }

            Console.WriteLine();

            Console.Write("people2 values: ");
            foreach (var people2Value in people2.Values)
            {
                Console.Write($"{people2Value} ");
            }

            Console.WriteLine();

            foreach (var pair in people)
            {
                Console.Write($"{pair} ");
            }

            Console.WriteLine();

            bool containsKey = people2.ContainsKey(2);
            bool containsValue = people2.ContainsValue("John");
            bool containsValue2 = people2.ContainsValue("Jesus");

            people.Remove(1);
            foreach (var pair in people)
            {
                Console.Write($"{pair} ");
            }

            Console.WriteLine();

            if (people2.TryAdd(2, "Simon"))
            {
                Console.WriteLine("Simon added to people2");
            }
            else
            {
                Console.WriteLine("Simon not added to people2. Adding with different key...");

                people2.TryAdd(4, "Simon");
            }

            foreach (var pair in people2)
            {
                Console.Write($"{pair} ");
            }

            Console.WriteLine();

            if (people2.TryGetValue(4, out string val))
            {
                Console.WriteLine($"Key found: {val}");
            }
            else
            {
                Console.WriteLine("Key not found...");
            }

            people.Clear();
        }

        private static void Stacks()
        {
            var st0 = new Stack<int>();
            st0.Push(1);
            st0.Push(2);
            st0.Push(5);
            st0.Push(7);

            foreach (var i in st0)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();

            Console.WriteLine($"st0.Pop: {st0.Pop()}");
            Console.WriteLine($"st0.Pop: {st0.Pop()}");

            foreach (var i in st0)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();

            Console.WriteLine($"st0.Peek: {st0.Peek()}");
            Console.WriteLine($"st0.Peek: {st0.Peek()}");

            foreach (var i in st0)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();

            for (int i = 0; i < 10; i++)
            {
                st0.Push(i);
            }

            foreach (var i in st0)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();

        }

        private static void Queues()
        {
            var qu0 = new Queue<int>();
            qu0.Enqueue(1);
            qu0.Enqueue(2);
            qu0.Enqueue(5);
            qu0.Enqueue(7);

            foreach (var i in qu0)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();

            Console.WriteLine($"qu0.Dequeue: {qu0.Dequeue()}");
            Console.WriteLine($"qu0.Dequeue: {qu0.Dequeue()}");

            foreach (var i in qu0)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();

            Console.WriteLine($"qu0.Peek: {qu0.Peek()}");
            Console.WriteLine($"qu0.Peek: {qu0.Peek()}");

            foreach (var i in qu0)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();

            for (int i = 0; i < 10; i++)
            {
                qu0.Enqueue(i);
            }

            foreach (var i in qu0)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();

        }

        private static void ArraysMultiDim()
        {
            int[,] a1 = new int[2, 3];
            int[,] a2 = new int[2, 3] {{1, 2, 3,}, {4, 5, 6}};
            int[,] a3 = {{1, 2, 3,}, {4, 5, 6}};
            Array a4 = Array.CreateInstance(typeof(int), 2, 3);

            Array.Copy(a3, a4, a3.Length);
            foreach (var item in a4)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();

            Array.Clear(a2, 0, a2.Length);
            foreach (var number in a2)
            {
                Console.Write($"{number} ");
            }

            Console.WriteLine();

            for (int i = 0; i < a3.GetLength(0); i++)
            {
                for (int j = 0; j < a3.GetLength(1); j++)
                {
                    Console.Write($"a3[{i},{j}]={a3[i, j]}\t");
                }

                Console.WriteLine();
            }
        }

        private static void ArraysJagged()
        {
            int[][] ja1 = new int[4][];
            ja1[0] = new int[1];
            ja1[1] = new int[3];
            ja1[2] = new int[2];
            ja1[3] = new int[4];

            Random rnd = new Random();

            for (var i = 0; i < ja1.Length; i++)
            {
                for (var j = 0; j < ja1[i].Length; j++)
                {
                    // Console.Write($"Enter value for JaggedArray[{i}][{j}]: ");
                    // ja1[i][j] = int.Parse(Console.ReadLine() ?? "0");
                    ja1[i][j] = rnd.Next(10, 99);
                }
            }

            Console.WriteLine("Print Jagged Array:");
            foreach (var i in ja1)
            {
                foreach (var j in i)
                {
                    Console.Write($"JaggedArray[{ja1.Length},{i.Length}]={j}\t");
                }
                Console.WriteLine();
            }

        }

        private static void ArraysCustom()
        {
            var arrayIndexedFromOne  = Array.CreateInstance(typeof(int), new[] {5}, new[] {1});

            var rnd = new Random();

            for (var i = 1; i <= arrayIndexedFromOne.Length; i++)
            {
                arrayIndexedFromOne.SetValue(rnd.Next(10, 99), i);
            }

            foreach (var item in arrayIndexedFromOne)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();

            Console.WriteLine($"Starting Index:\t{arrayIndexedFromOne.GetLowerBound(0)}");
            Console.WriteLine($"Ending Index:\t{arrayIndexedFromOne.GetUpperBound(0)}");
        }
    }
}
