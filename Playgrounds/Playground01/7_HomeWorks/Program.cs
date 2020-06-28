using System;
using System.Net.Http.Headers;
using CSCLib;
using Microsoft.VisualBasic;

namespace _7_HomeWorks
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleUtils.PrintSeparator();

            // StartAll();
            PlayGuessNumber();

            // -----------------------------------------------
            ConsoleUtils.EndOfProgram();
        }

        private static void StartAll()
        {
            ComplexNumbers();
            ConsoleUtils.PrintSeparator();

            PlayGuessNumber();
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

        private static void PlayGuessNumber()
        {
            Console.WriteLine("Game Guess Number: ");
            Player p1 = new Player("Dima", PlayerType.Human);
            Player p2 = new Player("Vasya", PlayerType.Human);
            Player p3 = new Player("PC1", PlayerType.Cpu);
            Player p4 = new Player("PC2", PlayerType.Cpu);

            // GuessNumber game = new GuessNumber(p1, p2);
            // GuessNumber game = new GuessNumber(p1, p3);

            for (var i = 0; i < 10; i++)
            {
                var game = new GuessNumber(p3, p1);
                Console.WriteLine($"\nThe answer is {game.Play()}. Winner: {game.Winner.Name}");
                ConsoleUtils.PrintInternalSeparator();
            }


            // for (var i = 0; i < 10; i++)
            // {
            //     var game = new GuessNumber(p1, p3, 10);
            //     Console.WriteLine($"\nThe answer is {game.Play()}. Winner: {game.Winner.Name}");
            //     ConsoleUtils.PrintInternalSeparator();
            // }

            // Demo version
            // while (true)
            // {
            //     Console.Clear();
            //     var game = new GuessNumber(p3, p4, 10);
            //     Console.WriteLine($"\nThe answer is {game.Play()}. Winner: {game.Winner.Name}");
            //     System.Threading.Thread.Sleep(2000);
            // }

        }

    }
}
