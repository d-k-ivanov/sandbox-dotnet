using System;
using System.IO;
using CSCLib;

namespace _5_Exceptions
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
            ExceptionHandling();
            ConsoleUtils.PrintSeparator();

            ThrowingExceptions();
            ConsoleUtils.PrintSeparator();

            CustomExceptions();
        }

        private static void ExceptionHandling()
        {
            int number = 0;
            bool loop = true;
            while (loop)
            {
                Console.Write("Enter a number: ");
                string answer = Console.ReadLine();

                try
                {
                    number = int.Parse(answer);
                    loop = false;
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine("Error: The number is too big...");
                    // Console.WriteLine("Details: ")n
                    // Console.WriteLine(ex.ToString());
                    loop = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Error: Incorrect data format. Only numbers are allowed...");
                    // Console.WriteLine("Details: ");
                    // Console.WriteLine(ex.ToString());
                    // throw;
                    loop = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: Something wrong happened... ");
                    Console.WriteLine("Details: ");
                    Console.WriteLine(ex.ToString());
                    // throw;
                    loop = true;
                }
            }

            Console.WriteLine($"You entered: {number}");

            Console.WriteLine();

            FileStream file = null;
            try
            {
                file = File.Open("tmp.txt", FileMode.Open);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                file?.Dispose();
            }
        }

        private static void ThrowingExceptions()
        {
            Character c1;
            Character c2;
            Character c3;


            c1 = new Character("TeddyBear", 100);

            try
            {
                c2 = new Character(null, 100);

            }
            catch (ArgumentNullException ex)
            {
                c2 = new Character("NuLLLLLL", 100);
            }

            try
            {
                c3 = new Character("Thor", 1001);

            }
            catch (ArgumentException ex)
            {
                c3 = new Character("Thor", 1);
            }

            Console.WriteLine($"C1: {c1.Name} Armor: {c1.Armor}");
            Console.WriteLine($"C1: {c2.Name} Armor: {c2.Armor}");
            Console.WriteLine($"C1: {c3.Name} Armor: {c3.Armor}");

            Console.WriteLine($"{c1.Name} Health: {c1.Health}");
            c1.Hit(99);
            Console.WriteLine($"{c1.Name} Health: {c1.Health}");
            c1.Hit(1);
            Console.WriteLine($"{c1.Name} Health: {c1.Health}");
            try
            {
                c1.Hit(1);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine($"{c1.Name} Health: {c1.Health}");

            Console.WriteLine($"{c2.Name} Health: {c2.Health}");
            try
            {
                c2.Hit(999);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine($"{c2.Name} Health: {c2.Health}");
        }

        private static void CustomExceptions()
        {
            try
            {
                Console.WriteLine("100 Eur from Santander");
                CreditCard.Withdraw(100, "Santander");
            }
            catch (CreditCardWithdrawalException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();

            try
            {
                Console.WriteLine("100 Eur from Sberbank");
                CreditCard.Withdraw(100, "Sberbank");
            }
            catch (CreditCardWithdrawalException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();

            try
            {
                Console.WriteLine("10000 Eur from Santander");
                CreditCard.Withdraw(10000, "Santander");
            }
            catch (CreditCardWithdrawalException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();

            try
            {
                Console.WriteLine("100 Eur from Santander - cancelled");
                CreditCard.Withdraw(100, "Santander", true);
            }
            catch (CreditCardWithdrawalException e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
