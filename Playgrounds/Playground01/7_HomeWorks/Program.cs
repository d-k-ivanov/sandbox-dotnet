using System;
using CSCLib;

namespace _7_HomeWorks
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleUtils.PrintSeparator();

            StartAll();
            // ComplexNumbers();

            // -----------------------------------------------
            ConsoleUtils.EndOfProgram();
        }

        private static void StartAll()
        {
            ComplexNumbers();
            // ConsoleUtils.PrintSeparator();
        }

        private static void ComplexNumbers()
        {
            var c1 = new Complex(1,1);
            var c2 = new Complex(1,2);

            var result = c1.Plus(c2);
            Console.WriteLine($"{c1} + {c2} = {result}");

            c1 = new Complex(5.245,4.52);
            c2 = new Complex(11.57,-12.11);

            result = c1.Plus(c2);
            Console.WriteLine($"{c1} + {c2} = {result}");

            c1 = new Complex(11,0);
            c2 = new Complex(-6,0);

            result = c1.Plus(c2);
            Console.WriteLine($"{c1} + {c2} = {result}");

            ConsoleUtils.PrintInternalSeparator();

            c1 = new Complex(1,1);
            c2 = new Complex(1,2);

            result = c1.Minus(c2);
            Console.WriteLine($"{c1} - {c2} = {result}");

            c1 = new Complex(5.245,4.52);
            c2 = new Complex(11.57,-12.11);

            result = c1.Minus(c2);
            Console.WriteLine($"{c1} - {c2} = {result}");

            c1 = new Complex(11,0);
            c2 = new Complex(-6,0);

            result = c1.Minus(c2);
            Console.WriteLine($"{c1} - {c2} = {result}");

            ConsoleUtils.PrintInternalSeparator();

            c1 = new Complex(1,1);
            c2 = new Complex(1,2);

            result = c1 + c2;
            Console.WriteLine($"{c1} + {c2} = {result}");

            c1 = new Complex(5.245,4.52);
            c2 = new Complex(11.57,-12.11);

            result = c1 + c2;
            Console.WriteLine($"{c1} + {c2} = {result}");

            c1 = new Complex(11,0);
            c2 = new Complex(-6,0);

            result = c1 + c2;
            Console.WriteLine($"{c1} + {c2} = {result}");

            ConsoleUtils.PrintInternalSeparator();

            c1 = new Complex(1,1);
            c2 = new Complex(1,2);

            result = c1 - c2;
            Console.WriteLine($"{c1} - {c2} = {result}");

            c1 = new Complex(5.245,4.52);
            c2 = new Complex(11.57,-12.11);

            result = c1 - c2;
            Console.WriteLine($"{c1} - {c2} = {result}");

            c1 = new Complex(11,0);
            c2 = new Complex(-6,0);

            result = c1 - c2;
            Console.WriteLine($"{c1} - {c2} = {result}");
        }
    }
}
