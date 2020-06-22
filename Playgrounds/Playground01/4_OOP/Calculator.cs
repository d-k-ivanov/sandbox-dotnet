using System;
using System.Linq;

namespace _4_OOP
{
    public class Calculator
    {
        public bool TryDevide(double divisible, double divisor, out double result)
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

        public double CalcTriangleSquare(double ab, double bc, double cd)
        {
            var perimeter = (ab + bc + cd) / 2;
            return Math.Sqrt(perimeter * (perimeter - ab) * (perimeter - bc) * (perimeter - cd));
        }

        public double CalcTriangleSquare(double @base, double height)
        {
            return 0.5 * @base * height;
        }

        public double CalcTriangleSquare(double ab, double ac, int angle)
        {
            double radians = (angle * Math.PI) / 180;
            return 0.5 * ab * ac * Math.Sin(radians);
        }
    }
}
