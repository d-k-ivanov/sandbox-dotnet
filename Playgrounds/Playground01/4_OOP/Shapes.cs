using System;
using System.Collections.Generic;
using System.Text;

namespace _4_OOP
{
    public abstract class Shape
    {
        protected Shape()
        {
            Console.WriteLine("Shape created");
        }

        public abstract void Draw();

        public abstract double Area();

        public abstract double Perimeter();
    }

    class Rectangle : Shape
    {
        private readonly double _width;
        private readonly double _height;

        // Custom base constructor:
        // public Rectangle(double width, double height) : base("ShapeName")
        public Rectangle(double width, double height) : base()
        {
            this._width = width;
            this._height = height;

            Console.WriteLine("Rectangle created");
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing Rectangle");
        }

        public override double Area()
        {
            return _width * _height;
        }

        public override double Perimeter()
        {
            return 2 * (_width + _height);
        }
    }

    class Triangle: Shape
    {
        private readonly double _ab;
        private readonly double _bc;
        private readonly double _ac;

        // Custom base constructor:
        // public Triangle(double ab, double bc, double ac) : base("ShapeName")
        public Triangle(double ab, double bc, double ac) : base()
        {
            this._ab = ab;
            this._bc = bc;
            this._ac = ac;
            Console.WriteLine("Triangle created");
        }


        public override void Draw()
        {
            Console.WriteLine("Drawing Triangle");
        }

        public override double Area()
        {
            // var c = new Calculator();
            // return c.CalcTriangleArea(_ab, _bc, _ac);

            var p = this.Perimeter();
            return Math.Sqrt(p * (p - _ab) * (p - _bc) * (p - _ac));
        }

        public override double Perimeter()
        {
            return (_ab + _bc + _ac) / 2;
        }
    }
}
