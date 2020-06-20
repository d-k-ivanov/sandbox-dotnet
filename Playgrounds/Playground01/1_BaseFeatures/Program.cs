using System;
using CSCLib;

namespace _1_BaseFeatures
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            ConsoleUtils.PrintSeparator();

            Console.WriteLine("Hello World!");
            ConsoleUtils.PrintSeparator();

            DataTypes.PrintDataTypes();
            ConsoleUtils.PrintSeparator();

            Variables.PrintVariables();
            ConsoleUtils.PrintSeparator();

            Variables.VariablesOverflow();
            ConsoleUtils.PrintSeparator();

            Variables.ArithmeticOperations();
            ConsoleUtils.PrintSeparator();

            Strings.PrintBasicStringOperations();
            ConsoleUtils.PrintSeparator();

            Strings.PrintEmptiness();
            ConsoleUtils.PrintSeparator();

            Strings.PrintStringChanging();
            ConsoleUtils.PrintSeparator();

            Strings.PrintStringsComparison();
            ConsoleUtils.PrintSeparator();

            InputOutput.IoBasics();
            ConsoleUtils.PrintSeparator();

            DataTypes.TypeConversions();
            ConsoleUtils.PrintSeparator();

            MathModule.MathExamples();
            ConsoleUtils.PrintSeparator();

            DataTypes.Arrays();
            ConsoleUtils.PrintSeparator();

            DataTypes.Dates();
            ConsoleUtils.PrintSeparator();

            HomeWork.HeronArea();
            ConsoleUtils.PrintSeparator();

            HomeWork.UserProfile();
            ConsoleUtils.PrintSeparator();


            ConsoleUtils.PrintSeparator();


            // -----------------------------------------------
            ConsoleUtils.EndOfProgram();
        }
    }
}
