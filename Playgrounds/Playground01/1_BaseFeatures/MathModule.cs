using System;
using System.Collections.Generic;
using System.Text;

namespace _1_BaseFeatures
{
    internal static class MathModule
    {
        internal static void MathExamples()
        {
            Console.WriteLine("\te = " + Math.E);
            Console.WriteLine("\tMath.Pow(2,3)   = "+ Math.Pow(2,3));
            Console.WriteLine("\tMath.Sqrt(8)    = "+ Math.Sqrt(8));
            Console.WriteLine("\tMath.Sqrt(8)    = "+ Math.Sqrt(9));

            Console.WriteLine("\tMath.Round(1.7) = "+ Math.Round(1.7));
            Console.WriteLine("\tMath.Round(1.4) = "+ Math.Round(1.4));

            Console.WriteLine();
            Console.WriteLine("\tMath.Round(2.5) = "+ Math.Round(2.5));
            Console.WriteLine("\tMath.Round(2.5) = "+ Math.Round(2.5, MidpointRounding.AwayFromZero) + " AwayFromZero");
            Console.WriteLine("\tMath.Round(2.5) = "+ Math.Round(2.5, MidpointRounding.ToEven) + " ToEven");

            Console.WriteLine();
            Console.WriteLine("\tMath.Round(3.5) = "+ Math.Round(3.5));
            Console.WriteLine("\tMath.Round(3.5) = "+ Math.Round(3.5, MidpointRounding.AwayFromZero) + " AwayFromZero");
            Console.WriteLine("\tMath.Round(3.5) = "+ Math.Round(3.5, MidpointRounding.ToEven) + " ToEven");

        }
    }
}
