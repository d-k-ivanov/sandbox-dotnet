using System;

namespace _1_BaseFeatures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!\n\n");

            Console.WriteLine("Data Types:");
            Console.WriteLine("Int16 Min: " + short.MinValue + "\t\t\tInt16 Max:  " + short.MaxValue);
            Console.WriteLine("Int32 Min: " + int.MinValue + "\t\t\tInt32 Max:  " + int.MaxValue);
            Console.WriteLine("Int64 Min: " + long.MinValue + "\t\tInt64 Max:  " + long.MaxValue);

            Console.WriteLine("Float Min: " + float.MinValue + "\t\tFloat Max:  " + float.MaxValue);
            Console.WriteLine("Double Min: " + double.MinValue + "\tDouble Max: " + double.MaxValue);
            Console.WriteLine("Char Min: " + (int) char.MinValue + "\t\t\t\tChar Max:   " + (int) char.MaxValue);
            Console.WriteLine("String " + string.Empty);
            Console.WriteLine("Boolean True: " + bool.TrueString + "\t\t\tBoolean False: " + bool.FalseString);

            Console.WriteLine("");
        }
    }
}
