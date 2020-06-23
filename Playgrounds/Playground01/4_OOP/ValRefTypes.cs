using System;

namespace _4_OOP
{
    public struct PointVal
    {
        public int X;
        public int Y;

        public void LogValues()
        {
            Console.WriteLine($"PointVal: X={X}, Y={Y}");
        }

    }

    public class PointRef
    {
        public int X;
        public int Y;

        public void LogValues()
        {
            Console.WriteLine($"PointRef: X={X}, Y={Y}");
        }

    }

    public struct EvilStruct
    {
        public string Name;

        public int X;
        public int Y;

        public PointRef PrRef;

        public void LogValues()
        {
            Console.WriteLine($"EvilStruct {Name}:\tX={X}, Y={Y}");
            PrRef.LogValues();
        }
    }
}
