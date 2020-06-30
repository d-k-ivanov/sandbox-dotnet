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

            // -----------------------------------------------
            ConsoleUtils.EndOfProgram();
        }

        private static void StartAll()
        {
            // ComplexNumbers();
            // ConsoleUtils.PrintSeparator();
            //
            // PlayGuessNumber();
            // ConsoleUtils.PrintSeparator();

            PlayHangman();
        }

        private static void ComplexNumbers()
        {
            Console.Clear();
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

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void PlayGuessNumber()
        {
            Console.Clear();
            Console.WriteLine("Game Guess Number: ");
            Player p1 = new Player("Dima", PlayerType.Human);
            Player p2 = new Player("Vasya", PlayerType.Human);
            Player p3 = new Player("PC1", PlayerType.Cpu);
            Player p4 = new Player("PC2", PlayerType.Cpu);

            // GuessNumber game = new GuessNumber(p1, p2);
            // GuessNumber game = new GuessNumber(p1, p3);

            // for (var i = 0; i < 10; i++)
            // {
            //     var game = new GuessNumber(p3, p1);
            //     Console.WriteLine($"\nThe answer is {game.Play()}. Winner: {game.Winner.Name}");
            //     ConsoleUtils.PrintInternalSeparator();
            // }


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

            var game = new GuessNumber(p3, p4, 10);
            Console.WriteLine($"\nThe answer is {game.Play()}. Winner: {game.Winner.Name}");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }

        private static void PlayHangman()
        {
            var game = new Hangman("Dima");
            // var game = new Hangman("PC", tries:15, demo:true);
            game.Play();

            // for (var i = 0; i < 11; i++)
            // {
            //     Console.Clear();
            //     Console.Write(Hangman.MakeHangMan(i));
            //     System.Threading.Thread.Sleep(1000);
            // }
        }
    }
}
