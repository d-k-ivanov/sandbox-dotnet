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

        // Explicit constrictor for structs is forbidden
        // public EvilStruct()
        // {
        // }

        // Only custom ctor and should initialize every field
        public EvilStruct(string name, int x, int y)
        {
            Name = name;
            X = x;
            Y = y;
            PrRef = new PointRef();
        }


        public void LogValues()
        {
            Console.WriteLine($"EvilStruct {Name}:\tX={X}, Y={Y}");
            PrRef.LogValues();
        }
    }
}
