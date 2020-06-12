using System;

namespace _1_BaseFeatures
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine('\n');

            PrintDataTypes();
            Console.WriteLine('\n');
        }

        private static void PrintDataTypes()
        {
            Console.WriteLine("Data types:");
            Console.WriteLine("\tByte Min:     " + byte.MinValue       + "\t\t\t\tByte Max:      "  + byte.MaxValue);
            Console.WriteLine("\tInt16 Min:    " + short.MinValue      + "\t\t\tInt16 Max:     "    + short.MaxValue);
            Console.WriteLine("\tInt32 Min:    " + int.MinValue        + "\t\tInt32 Max:     "      + int.MaxValue);
            Console.WriteLine("\tInt64 Min:    " + long.MinValue       + "\tInt64 Max:     "        + long.MaxValue);
            Console.WriteLine("\tFloat Min:    " + float.MinValue      + "\t\tFloat Max:     "      + float.MaxValue);
            Console.WriteLine("\tDouble Min:   " + double.MinValue     + "\tDouble Max:    "        + double.MaxValue);
            Console.WriteLine("\tChar Min:     " + (int) char.MinValue + "\t\t\t\tChar Max:      "  + (int) char.MaxValue);
            Console.WriteLine("\tBoolean True: " + bool.TrueString     + "\t\t\tBoolean False: "    + bool.FalseString);
            Console.WriteLine("\tString        " + string.Empty);

            Console.WriteLine('\n');

            Console.WriteLine("Data type sizes:");
            Console.WriteLine("\tsizeof(sbyte):   " + sizeof(sbyte));
            Console.WriteLine("\tsizeof(byte):    " + sizeof(byte));
            Console.WriteLine("\tsizeof(short):   " + sizeof(short));
            Console.WriteLine("\tsizeof(ushort):  " + sizeof(ushort));
            Console.WriteLine("\tsizeof(int):     " + sizeof(int));
            Console.WriteLine("\tsizeof(uint):    " + sizeof(uint));
            Console.WriteLine("\tsizeof(long):    " + sizeof(long));
            Console.WriteLine("\tsizeof(ulong):   " + sizeof(ulong));
            Console.WriteLine("\tsizeof(char):    " + sizeof(char));
            Console.WriteLine("\tsizeof(float):   " + sizeof(float));
            Console.WriteLine("\tsizeof(double):  " + sizeof(double));
            Console.WriteLine("\tsizeof(decimal): " + sizeof(decimal));
            Console.WriteLine("\tsizeof(bool):    " + sizeof(bool));
        }
    }
}
