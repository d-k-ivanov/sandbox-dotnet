using System;
using System.Linq;

namespace _4_OOP
{
    public class Calculator
    {
        public bool TryDivide(double divisible, double divisor, out double result)
        {
            result = 0.0;
            if (Math.Abs(divisor) < 0.0001)
                return false;
            result = divisible / divisor;
            return true;

        }

        // Average(new []{1,2,3,4})
        public double Average(int[] numbers)
        {
            var sum = numbers.Sum();
            return (double) sum / numbers.Length;
        }

        // Average2(1, 2, 3, 4)
        public double Average2(params int[] numbers)
        {
            var sum = numbers.Sum();
            return (double) sum / numbers.Length;
        }

        public double CalcTriangleArea(double ab, double bc, double ac)
        {
            var perimeter = (ab + bc + ac) / 2;
            return Math.Sqrt(perimeter * (perimeter - ab) * (perimeter - bc) * (perimeter - ac));
        }

        public double CalcTriangleArea(double @base, double height)
        {
            return 0.5 * @base * height;
        }

        // public double CalcTriangleArea(double ab, double ac, int angle)
        // {
        //     double radians = (angle * Math.PI) / 180;
        //     return 0.5 * ab * ac * Math.Sin(radians);
        // }

        public double CalcTriangleArea(double ab, double ac, float angle, bool isInRadians = false)
        {
            if (isInRadians)
            {
                return  Math.Round(0.5 * ab * ac * Math.Sin(angle), 2, MidpointRounding.AwayFromZero);
            }
            var radians = (angle * Math.PI) / 180;
            return Math.Round(0.5 * ab * ac * Math.Sin(radians), 2, MidpointRounding.AwayFromZero);
        }
    }
}
