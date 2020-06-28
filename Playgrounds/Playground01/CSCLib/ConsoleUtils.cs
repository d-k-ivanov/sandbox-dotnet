using System;

namespace CSCLib
{
    public class ConsoleUtils
    {

        public static void PrintSeparator()
        {
            Console.WriteLine();
            Console.WriteLine(new string('-', 100));
            Console.WriteLine();
        }

        public static void PrintInternalSeparator()
        {
            Console.WriteLine();
            Console.WriteLine(new string('-', 50));
            Console.WriteLine();
        }


        public static void EndOfProgram()
        {
            PrintSeparator();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
