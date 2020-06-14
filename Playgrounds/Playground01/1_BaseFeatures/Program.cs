using System;

namespace _1_BaseFeatures
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Utils.PrintSeparator();

            Console.WriteLine("Hello World!");
            Utils.PrintSeparator();

            DataTypes.PrintDataTypes();
            Utils.PrintSeparator();

            Variables.PrintVariables();
            Utils.PrintSeparator();

            Variables.VariablesOverflow();
            Utils.PrintSeparator();

            Variables.ArithmeticOperations();
            Utils.PrintSeparator();

            Strings.PrintBasicStringOperations();
            Utils.PrintSeparator();

            Strings.PrintEmptiness();
            Utils.PrintSeparator();

            Strings.PrintStringChanging();
            Utils.PrintSeparator();

            Strings.PrintStringsComparison();
            Utils.PrintSeparator();

            InputOutput.IOBasics();
            Utils.PrintSeparator();

            DataTypes.TypeConversions();
            Utils.PrintSeparator();

            MathModule.MathExamples();
            Utils.PrintSeparator();

            DataTypes.Arrays();
            Utils.PrintSeparator();

            DataTypes.Dates();
            Utils.PrintSeparator();

            HomeWork.HeronArea();
            Utils.PrintSeparator();

            HomeWork.UserProfile();
            Utils.PrintSeparator();


            // -----------------------------------------------
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
