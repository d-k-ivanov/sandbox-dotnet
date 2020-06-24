using System;
using System.Collections.Generic;
using System.Text;

namespace _4_OOP
{
    public interface IShape
    {
        int CalcArea();
    }

    public class Rect : IShape
    {
        public int Width  { get; set; }
        public int Height { get; set; }
        public int CalcArea()
        {
            return this.Width * this.Height;
        }
    }

    public class Square : IShape
    {
        public int SideLenght { get; set; }

        public int CalcArea()
        {
            return this.SideLenght * this.SideLenght;
        }
    }

    // public static class AreaCalculator
    // {
    //     public static int CalcArea(Rect rect)
    //     {
    //         return rect.Width * rect.Height;
    //     }
    //
    //     public static int CalcArea(Square square)
    //     {
    //         return square.Width * square.Width;
    //     }
    // }
}
