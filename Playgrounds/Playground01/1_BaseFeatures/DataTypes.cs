using System;
using System.Numerics;

namespace _1_BaseFeatures
{
    internal class DataTypes
    {
        internal static void PrintDataTypes()
        {
            Console.WriteLine("Primitive data types:");

            Console.WriteLine("\tBoolean True: " + bool.TrueString        + "\t\t\t\tBoolean False: "    + bool.FalseString);
            Console.WriteLine("\tChar Min:     " + (ushort) char.MinValue + "\t\t\t\t\tChar Max:      "  + (ushort) char.MaxValue);
            Console.WriteLine();

            Console.WriteLine("\tSByte Min:    " + sbyte.MinValue         + "\t\t\t\tSByte Max:     "    + sbyte.MaxValue);
            Console.WriteLine("\tByte Min:     " + byte.MinValue          + "\t\t\t\t\tByte Max:      "  + byte.MaxValue);
            Console.WriteLine();

            Console.WriteLine("\tInt16 Min:    " + short.MinValue         + "\t\t\t\tInt16 Max:     "    + short.MaxValue);
            Console.WriteLine("\tUInt16 Min:   " + ushort.MinValue        + "\t\t\t\t\tUInt16 Max:    "  + ushort.MaxValue);
            Console.WriteLine();

            Console.WriteLine("\tInt32 Min:    " + int.MinValue           + "\t\t\tInt32 Max:     "      + int.MaxValue);
            Console.WriteLine("\tUInt32 Min:   " + uint.MinValue          + "\t\t\t\t\tUInt32 Max:    "  + uint.MaxValue);
            Console.WriteLine();

            Console.WriteLine("\tInt64 Min:    " + long.MinValue          + "\t\tInt64 Max:     "        + long.MaxValue);
            Console.WriteLine("\tUInt64 Min:   " + ulong.MinValue         + "\t\t\t\t\tUInt64 Max:    "  + ulong.MaxValue);
            Console.WriteLine();

            Console.WriteLine("\tSingle Min:   " + float.MinValue         + "\t\t\tSingle Max:    "      + float.MaxValue);
            Console.WriteLine("\tDouble Min:   " + double.MinValue        + "\t\tDouble Max:    "        + double.MaxValue);
            Console.WriteLine();

            Console.WriteLine("Primitive data type sizes:");
            Console.WriteLine("\tsizeof(bool):     " + sizeof(bool));
            Console.WriteLine("\tsizeof(sbyte):    " + sizeof(sbyte));
            Console.WriteLine("\tsizeof(byte):     " + sizeof(byte));
            Console.WriteLine("\tsizeof(short):    " + sizeof(short));
            Console.WriteLine("\tsizeof(ushort):   " + sizeof(ushort));
            Console.WriteLine("\tsizeof(char):     " + sizeof(char));
            Console.WriteLine("\tsizeof(int):      " + sizeof(int));
            Console.WriteLine("\tsizeof(uint):     " + sizeof(uint));
            Console.WriteLine("\tsizeof(long):     " + sizeof(long));
            Console.WriteLine("\tsizeof(ulong):    " + sizeof(ulong));
            Console.WriteLine("\tsizeof(float):    " + sizeof(float));
            Console.WriteLine("\tsizeof(double):   " + sizeof(double));
            Console.WriteLine();

            Console.WriteLine("Non-Primitive data types:");

            Console.WriteLine("\tDateTime Min:      " + DateTime.MinValue   + "\t\t\tDateTime Max:  "      + DateTime.MaxValue);
            Console.WriteLine("\tTimeSpan Min:      " + TimeSpan.MinValue   + "\t\tTimeSpan Max:  "        + TimeSpan.MaxValue);
            Console.WriteLine("\tDecimal Min:       " + decimal.MinValue    + "\tDecimal Max:   "        + decimal.MaxValue);
            Console.WriteLine();

            Console.WriteLine("\tString             " + "string".GetType());
            Console.WriteLine("\tObject:            " + new object());
            Console.WriteLine("\tGuid:              " + Guid.NewGuid());
            Console.WriteLine();

            Console.WriteLine("\tBigInteger 2**300: " + BigInteger.Pow(2, 300));
            Console.WriteLine("\tComplex Infinity:  " + Complex.Infinity);
            Console.WriteLine();

            Console.WriteLine("Non-Primitive data type sizes:");
            Console.WriteLine("\tsizeof(TimeSpan):   " + sizeof(long));        // Fake, just to print proper size
            Console.WriteLine("\tsizeof(DateTime):   " + sizeof(ulong));       // Fake, just to print proper size
            Console.WriteLine("\tsizeof(object):     " + sizeof(long));        // Fake, just to print proper size
            Console.WriteLine("\tsizeof(Guid):       " + sizeof(decimal));     // Fake, just to print proper size
            Console.WriteLine("\tsizeof(decimal):    " + sizeof(decimal));
            Console.WriteLine("\tsizeof(BigInteger): " + "symbols * byte + C");
        }

        internal static void TypeConversions()
        {
            byte  b = 3; // 0000 0011
            int   i = b; // 0000 0000 0000 0000 0000 0000 0000 0011
            long  l = i; // 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0011
            float f = i; // 3.0

            b = (byte) i;
            i = (int)  f;

            Console.WriteLine("\tf: " + f + " i: "  + i);
            f = 3.3f;
            i = (int) f;
            Console.WriteLine("\tf: " + f + " i: "  + i);

            f = 3.5f;
            i = (int) f;
            Console.WriteLine("\tf: " + f + " i: "  + i);

            f = 3.7f;
            i = (int) f;
            Console.WriteLine("\tf: " + f + " i: "  + i);

            i = 5;
            Console.WriteLine("\t5/2=" + i / 2);
            Console.WriteLine("\t5/2=" + (double)i / 2);
        }
    }
}
