using System;
using System.Collections.Generic;
using System.Text;

namespace _1_BaseFeatures
{
    internal class Variables
    {
        internal static void PrintVariables()
        {
            // int i = 1;
            // int @int = 2;
            // char c = 'Q';
            // char @char = 'C';
            // var v = 2.111m;
            // Console.WriteLine("\t" + i + " " + @int + " " + c + " " + @char + " " + v);

            int x = 0b11;
            int y = 0b1001;
            int k = 0b10001000;
            int m = 0b1000_1000;
            Console.WriteLine("\t" + x);
            Console.WriteLine("\t" + y);
            Console.WriteLine("\t" + k);
            Console.WriteLine("\t" + m);

        }
    }
}
