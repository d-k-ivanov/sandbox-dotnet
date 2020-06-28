using System;
using System.Collections.Generic;
using System.Text;

namespace _7_HomeWorks
{
    public class Complex
    {
        public double Real { get; }
        public double Imaginary { get; }

        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        private Complex()
        {
        }

        public Complex Plus(Complex c)
        {
            if (c == null) throw new ArgumentNullException(nameof(c));
            return new Complex(this.Real + c.Real, this.Imaginary + c.Imaginary);
        }

        public static Complex operator+(Complex c1, Complex c2)
        {
            if (c1 == null) throw new ArgumentNullException(nameof(c1));
            if (c2 == null) throw new ArgumentNullException(nameof(c2));
            return new Complex(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
        }

        public Complex Minus(Complex c)
        {
            if (c == null) throw new ArgumentNullException(nameof(c));
            return new Complex(this.Real - c.Real, this.Imaginary - c.Imaginary);
        }

        public static Complex operator-(Complex c1, Complex c2)
        {
            if (c1 == null) throw new ArgumentNullException(nameof(c1));
            if (c2 == null) throw new ArgumentNullException(nameof(c2));
            return new Complex(c1.Real - c2.Real, c1.Imaginary - c2.Imaginary);
        }

        public override string ToString()
        {
            if (Imaginary < 0)
            {
                return $"({Real} - {Math.Abs(Imaginary)}i)";
            }

            if (Math.Abs(Imaginary) < 0.0000001 && Math.Abs(Imaginary) > -0.0000001)
            {
                return $"{Real}";
            }

            return $"({Real} + {Math.Abs(Imaginary)}i)";
        }
    }


}
