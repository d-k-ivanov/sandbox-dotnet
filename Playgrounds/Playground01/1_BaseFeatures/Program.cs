using System;

namespace _1_BaseFeatures
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Utils.PrintSeparator();

            DataTypes.PrintDataTypes();
            Utils.PrintSeparator();

            // Variables.PrintVariables();
            // Utils.PrintSeparator();
            //
            // Variables.VariablesOverflow();
            // Utils.PrintSeparator();
            //
            // Variables.ArithmeticOperations();
            // Utils.PrintSeparator();
            //
            // Strings.PrintBasicStringOperations();
            // Utils.PrintSeparator();
            //
            // Strings.PrintEmptiness();
            // Utils.PrintSeparator();
            //
            // Strings.PrintStringChanging();
            // Utils.PrintSeparator();

            Strings.PrintStringsComparison();
            Utils.PrintSeparator();
        }
    }
}
