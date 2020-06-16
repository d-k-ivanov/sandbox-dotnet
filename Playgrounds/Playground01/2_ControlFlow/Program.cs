using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Intrinsics.X86;
using CSCLib;

namespace _2_ControlFlow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleUtils.PrintSeparator();

            // AmITooFat();
            // ConsoleUtils.PrintSeparator();

            // Loops();
            // ConsoleUtils.PrintSeparator();

            // SumArray();
            // ConsoleUtils.PrintSeparator();

            // FindAntiDuples();
            // ConsoleUtils.PrintSeparator();

            // FindAntiTriples();
            // ConsoleUtils.PrintSeparator();

            // PadawanDetection();
            // ConsoleUtils.PrintSeparator();

            // FibonacciNumbers();
            // ConsoleUtils.PrintSeparator();

            // Factorial();
            // ConsoleUtils.PrintSeparator();

            Averages();
            // ConsoleUtils.PrintSeparator();


            // ConsoleUtils.PrintSeparator();


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

        private static void Loops()
        {
            int[] arr = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20};

            Console.Write("Straight:\t");
            for (var i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
                if (i == arr.Length - 1)
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.Write(" ");
                }

            }

            Console.Write("Reverse:\t");
            for (var i = arr.Length - 1; i >= 0; i--)
            {
                Console.Write(arr[i]);
                if (i == 0)
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.Write(" ");
                }

            }

            Console.Write("Straight:\t");
            foreach (var value in arr)
            {
                Console.Write(value);
                if (value == arr[^1])
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.Write(" ");
                }

            }

            Console.Write("Odds:\t\t");
            foreach (var i in arr)
            {
                if (i % 2 != 0)
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine();

        }

        private static void SumArray()
        {
            int[] numbers = new int[100];
            Random rnd = new Random();

            Console.WriteLine("Numbers:");
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rnd.Next(-1000, 1000);
                Console.Write($"{numbers[i],-6}");
                if (i % 10 == 0 || i == numbers.Length)
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.Write(" ");
                }
            }

            int sum = 0;
            foreach (var value in numbers)
            {
                sum += value;
            }
            Console.WriteLine();
            Console.WriteLine($"Sum of Numbers: {sum}");

        }

        private static void FindAntiDuples()
        {
            // O(n**3)
            int[] numbers = new int[100];
            Random rnd = new Random();

            Console.WriteLine("Numbers:");
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rnd.Next(-100, 100);
                Console.Write($"{numbers[i],-6}");
                if (i % 10 == 0 || i == numbers.Length - 1)
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i; j < numbers.Length; j++)
                {
                    if (numbers[i] + numbers[j] == 0)
                    {
                        Console.WriteLine($"Duple found: index #{i:d3} => {numbers[i],4} | index #{j:d3} => {numbers[j],4}");
                    }
                }
            }

        }

        private static void FindAntiTriples()
        {
            // O(n**3)
            var numbers = new int[100];
            Random rnd = new Random();

            Console.WriteLine("Numbers:");
            for (var i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rnd.Next(-100, 1000);
                Console.Write($"{numbers[i],-6}");
                if (i % 10 == 0 || i == numbers.Length - 1)
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();

            for (var i = 0; i < numbers.Length; i++)
            {
                for (var j = i; j < numbers.Length; j++)
                {
                    for (var k = i; k < numbers.Length; k++)
                    {
                        if (numbers[i] + numbers[j] + numbers[k] == 0)
                        {
                            Console.WriteLine($"Triple found: index #{i:d3} => {numbers[i],4} | index #{j:d3} => {numbers[j],4} | index #{k:d3} => {numbers[k],4}");
                        }
                    }
                }
            }

        }

        private static void PadawanDetection()
        {
            var defaultForegroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            var age = 0;

            while (age < 18)
            {
                Console.Write("What is your age, Youthful Padawan? ");
                age = int.Parse(Console.ReadLine() ?? "0");
            }

            // switch (age)
            // {
            //     case var n when (n >= 100):
            //         break;
            //     case int n when (n < 100 && n >= 50):
            //         break;
            //     case int n when ( n < 50 && n >= 30):
            //         break;
            //     default:
            //         Console.WriteLine("<(°.°)> : Patience you must have my young Padawan.");
            //         break;
            // }

            // Range-based switch with object pattern
            switch (age)
            {
                case { } n when (n >= 100):
                    Console.WriteLine("<(°.°)> : When nine hundred years old you reach, look as good you will not, master Jedi!");
                    break;
                case { } n when (n < 100 && n >= 50):
                    Console.WriteLine("<(°.°)> : A Jedi uses the Force for knowledge and defense, never for attack, Jedi!");
                    break;
                case { } n when ( n < 50 && n >= 30):
                    Console.WriteLine("<(°.°)> : Fear is the path to the dark side. Fear leads to anger. Anger leads to hate. Hate leads to suffering, young Jedi.");
                    break;
                default:
                    Console.WriteLine("<(°.°)> : Patience you must have my young Padawan.");
                    break;
            }

            // Range-based inline switch with object pattern
            var yodasWisdom = age switch
            {
                {} n when (n >= 100)            => "<(°.°)> : Only the Dark Lord of the Sith knows of our weakness. If informed the senate is, multiply our adversaries will, master Jedi!",
                {} n when (n < 100 && n >= 50)  => "<(°.°)> : Do not assume anything Obi-Wan. Clear your mind must be if you are to discover the real villains behind this plot, Jedi!",
                {} n when (n < 50 && n >= 30)   => "<(°.°)> : Powerful you have become, the dark side I sense in you, young Jedi.",
                {}                                  => "<(°.°)> : Always two there are, no more, no less. A master and an apprentice, young Padawan."
            };
            Console.WriteLine(yodasWisdom);

            Console.ForegroundColor = defaultForegroundColor;
        }

        private static void FibonacciNumbers()
        {
            Console.Write("How many Fibonacci numbers you want to see? ");
            ushort maxNumber = ushort.Parse(Console.ReadLine() ?? "1");
            if (maxNumber > 138)
            {
                var oldConsoleColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Sorry, we can show you only 138 numbers...");
                Console.ForegroundColor = oldConsoleColor;
                maxNumber = 138;
            }


            ushort i = 0;
            decimal a = 0, b = 1;

            var fibNums = new decimal[maxNumber];
            while (i < maxNumber)
            {
                // Console.Write(i == 1 ? $"{a} {b} " : $"{b} ");
                // Console.Write($"{b} ");
                fibNums[i] = b;
                var t = a;
                a = b;
                b = t + a;
                i++;
            }

            foreach (var el in fibNums)
            {
                Console.Write($"{el} ");
            }
            Console.WriteLine();
        }

        private static void Factorial()
        {
            Console.Write("Factorial of what number you want to see? ");
            ushort n = ushort.Parse(Console.ReadLine() ?? "0");
            if (n > 27)
            {
                n = 27;
                var oldConsoleColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: Sorry, we can show you only {n} numbers...");
                Console.ForegroundColor = oldConsoleColor;
            }

            decimal ans = 1;
            switch (n)
            {
                case 0:
                case 1:
                    ans = 1;
                    break;
                default:
                    int i = n;
                    do
                    {
                        ans = ans * i;
                        i--;
                    } while (i >= 2);
                    break;
            }
            Console.WriteLine($"{n}! = {ans}");
        }

        private static void Averages()
        {
            const ushort max = 10;
            var numbers = new long[max];

            ushort n = 0;
            do
            {
                Console.Write($"Enter number #{n+1}: ");
                numbers[n] = long.Parse(Console.ReadLine() ?? "0");
                if(numbers[n] == 0)
                    break;
                n++;
            } while (n < max);

            var arithmetic   = 0.0;
            var geometric    = 1.0;
            var harmonic     = 0.0;

            foreach (var el in numbers)
            {
                if (el == 0) continue;

                arithmetic  += el;
                geometric   *= el;
                harmonic    += 1.0 / el;
            }

            Console.WriteLine($"Arithmetic mean = {arithmetic / n}");
            Console.WriteLine($"Geometric mean  = {Math.Pow(geometric, 1.0 / n)}");
            Console.WriteLine($"Harmonic mean   = {n / harmonic}");
        }
    }
}
