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
            Character c = new Character();
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
            throw new NotImplementedException();
        }
    }
}
