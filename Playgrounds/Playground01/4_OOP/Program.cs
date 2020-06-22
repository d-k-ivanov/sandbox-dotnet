using System;
using CSCLib;

namespace _4_OOP
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
            CharacterRunner();
            ConsoleUtils.PrintSeparator();

            CalculatorRunner();
        }

        private static void CharacterRunner()
        {
            var c = new Character();
            while (c.Health > 0)
            {
                Console.Write($"\b\rCurrent Health = {c.Health}        Damages: Spacebar = 1; Enter = 10; Delete = 50;    ");
                var keyPressed  = Console.ReadKey();

                switch (keyPressed.Key.ToString())
                {
                    case "Spacebar":
                        c.Hit(1);
                        break;
                    case "Enter":
                        c.Hit(10);
                        break;
                    case "Delete":
                        c.Hit(50);
                        break;
                }
            }
            Console.WriteLine();
        }

        private static void CalculatorRunner()
        {
            var c = new Calculator();
            Console.Write("Triangle 3-5-6:\t\t");
            Console.Write($"Heron's: {c.CalcTriangleSquare(3.0,4.0,5.0)}   ");
            Console.Write($"By Height: {c.CalcTriangleSquare(3.0,4.0)}   ");
            Console.WriteLine($"Trigonometric: {c.CalcTriangleSquare(3.0,4.0, 90)} ");

            Console.Write("Triangle 20-21-29:\t");
            Console.Write($"Heron's: {c.CalcTriangleSquare(20.0,21.0,29.0)} ");
            Console.Write($"By Height: {c.CalcTriangleSquare(20.0,21.0)} ");
            Console.WriteLine($"Trigonometric: {c.CalcTriangleSquare(20.0,21.0, 90)}");

            Console.WriteLine($"Triangle Base=6, Height=5: {c.CalcTriangleSquare(6.0,5.0)} ");
            Console.WriteLine($"Triangle Base=8, Height=9: {c.CalcTriangleSquare(8.0,9.0)} ");
            Console.WriteLine($"Triangle AB=7, AC=9, Angle=30: {c.CalcTriangleSquare(7.0,9.0, 30)} ");

            Console.WriteLine();
            Console.WriteLine($"Average of 1,2,3,4: {c.Average(new []{1,2,3,4})}");
            Console.WriteLine($"Average of 1,2,3,4: {c.Average2(1, 2, 3, 4)}");

            // Named Arguments:
            c.CalcTriangleSquare(ab: 3.0,bc: 4.0,cd: 5.0);
            c.CalcTriangleSquare(@base: 3.0,height: 4.0);
            c.CalcTriangleSquare(ab: 3.0,ac: 4.0, angle: 90);
        }
    }
}
