using System;

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
            Console.WriteLine();

            x = 0x1F;
            y = 0xFF0D;
            k = 0x1FAB30EF;
            m = 0x1FAB_30EF;
            Console.WriteLine("\t" + x);
            Console.WriteLine("\t" + y);
            Console.WriteLine("\t" + k);
            Console.WriteLine("\t" + m);
            Console.WriteLine();

            Console.WriteLine("\t" + 4.5e2);
            Console.WriteLine("\t" + 3.1E-1);
            Console.WriteLine();

            Console.WriteLine("\t" + '\x78');
            Console.WriteLine("\t" + '\x5a');

            Console.WriteLine("\t" + '\u0420');
            Console.WriteLine("\t" + '\u0421');
        }

        internal static void VariablesScope()
        {
            var a = 1;
            {
                var b = 2;
                {
                    var c = 3;
                    Console.WriteLine("\t" + a);
                    Console.WriteLine("\t" + b);
                    Console.WriteLine("\t" + c);
                }
                Console.WriteLine("\t" + a);
                Console.WriteLine("\t" + b);
                // Console.WriteLine("\t" + c);
            }
            Console.WriteLine("\t" + a);
            // Console.WriteLine("\t" + b);
            // Console.WriteLine("\t" + c);
        }

        internal static void VariablesOverflow()
        {
            uint ui = uint.MaxValue;
            Console.WriteLine("\tuint.MaxValue:\t\t" + ui);

            ui += 1;
            Console.WriteLine("\tuint.MaxValue + 1:\t" + ui);

            ui -= 1;
            Console.WriteLine("\tuint.MaxValue + 1 - 1:\t" + ui);

            checked
            {
                // ui = uint.MaxValue;
                // Console.WriteLine("\tuint.MaxValue:\t\t" + ui);
                //
                // ui += 1;
                // Console.WriteLine("\tuint.MaxValue + 1:\t" + ui);
                //
                // ui -= 1;
                // Console.WriteLine("\tuint.MaxValue + 1 - 1:\t" + ui);
            }
        }

        internal static void ArithmeticOperations()
        {
            int x = 1;
            x = x + 1;
            Console.WriteLine("\tx + 1: " + x);

            x++;
            Console.WriteLine("\tx++: " + x);

            ++x;
            Console.WriteLine("\t++x: " + x);

            x = x - 1;
            Console.WriteLine("\tx - 1: " + x);

            x--;
            Console.WriteLine("\tx--: " + x);

            --x;
            Console.WriteLine("\t--x: " + x);

            Console.WriteLine();
            Console.WriteLine("Increments: ");
            Console.WriteLine();

            x = 1;
            Console.WriteLine($"Current state of x: {x}");
            int j = x++;
            Console.WriteLine("\tj = x++:");
            Console.WriteLine("\tx: " + x);
            Console.WriteLine("\tj: " + j);
            Console.WriteLine();


            x = 1;
            Console.WriteLine($"Current state of x: {x}");
            j = ++x;
            Console.WriteLine("\tj = ++x:");
            Console.WriteLine("\tx: " + x);
            Console.WriteLine("\tj: " + j);
        }
    }
}
