using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using CSCLib;

namespace _4_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleUtils.PrintSeparator();

            StartAll();

            // -----------------------------------------------
            ConsoleUtils.EndOfProgram();
        }



        private static void StartAll()
        {
            CharacterRunner();
            ConsoleUtils.PrintSeparator();

            CalculatorRunner();
            ConsoleUtils.PrintSeparator();

            OutParameters();
            ConsoleUtils.PrintSeparator();

            StaticFields();
            ConsoleUtils.PrintSeparator();

            OptionalVariables();
            ConsoleUtils.PrintSeparator();

            ClassAndStruct();
            ConsoleUtils.PrintSeparator();

            ReferenceParameters();
            ConsoleUtils.PrintSeparator();

            NullableStructures();
            ConsoleUtils.PrintSeparator();

            BoxingAndUnboxing();
            ConsoleUtils.PrintSeparator();

            ClassConstruction();
            ConsoleUtils.PrintSeparator();

            Inheritance();
            ConsoleUtils.PrintSeparator();

            Interfaces();
            ConsoleUtils.PrintSeparator();

            EvilInheritance();
        }

        private static void CharacterRunner()
        {
            var c = new Character();
            while (c.Health > 0)
            {
                Console.Write($"\b\rCurrent Health = {c.Health}        Damages: Spacebar = 1; Enter = 10; Delete = 50;    ");
                var keyPressed  = Console.ReadKey();

                switch (keyPressed.Key.ToString())
                {
                    case "Spacebar":
                        c.Hit(1);
                        break;
                    case "Enter":
                        c.Hit(10);
                        break;
                    case "Delete":
                        c.Hit(50);
                        break;
                }
            }
            Console.WriteLine();
        }

        private static void CalculatorRunner()
        {
            var c = new Calculator();
            Console.Write("Triangle 3-5-6:\t\t");
            Console.Write($"Heron's: {c.CalcTriangleArea(3.0,4.0,5.0)}   ");
            Console.Write($"By Height: {c.CalcTriangleArea(3.0,4.0)}   ");
            Console.WriteLine($"Trigonometric: {c.CalcTriangleArea(3.0,4.0, 90)} ");

            Console.Write("Triangle 20-21-29:\t");
            Console.Write($"Heron's: {c.CalcTriangleArea(20.0,21.0,29.0)} ");
            Console.Write($"By Height: {c.CalcTriangleArea(20.0,21.0)} ");
            Console.WriteLine($"Trigonometric: {c.CalcTriangleArea(20.0,21.0, 90)}");

            Console.WriteLine($"Triangle Base=6, Height=5: {c.CalcTriangleArea(6.0,5.0)} ");
            Console.WriteLine($"Triangle Base=8, Height=9: {c.CalcTriangleArea(8.0,9.0)} ");
            Console.WriteLine($"Triangle AB=7, AC=9, Angle=30: {c.CalcTriangleArea(7.0,9.0, 30)} ");

            Console.WriteLine();
            Console.WriteLine($"Average of 1,2,3,4: {c.Average(new []{1,2,3,4})}");
            Console.WriteLine($"Average of 1,2,3,4: {c.Average2(1, 2, 3, 4)}");

            // Named Arguments:
            c.CalcTriangleArea(ab: 3.0,bc: 4.0,ac: 5.0);
            c.CalcTriangleArea(@base: 3.0,height: 4.0);
            c.CalcTriangleArea(ab: 3.0,ac: 4.0, angle: 90);
        }

        private static void OutParameters()
        {
            Console.Write("Enter integer: ");
            var integer = Console.ReadLine();
            // var parsed = int.Parse(integer);
            // int parsed = 0;
            int parsed = 0;
            var wasParsed = int.TryParse(integer, out parsed);
            Console.WriteLine($"Entered: {(!wasParsed ? "Error: Failed to parse..." : parsed.ToString())}");

            Console.WriteLine();

            Console.Write("Enter integer: ");
            var integer2 = Console.ReadLine();
            var wasParsed2 = int.TryParse(integer, out int parsed2);
            Console.WriteLine($"Entered: {(!wasParsed2 ? "Error: Failed to parse..." : parsed.ToString())}");

            Console.WriteLine();
            Console.WriteLine("Enter two doubles:");
            var d1 = double.Parse(Console.ReadLine() ?? "0,0");
            var d2 = double.Parse(Console.ReadLine() ?? "0,0");
            var c = new Calculator();
            bool wasDivided = c.TryDivide(d1, d2, out var result);
            Console.WriteLine($"{d1} / {d2}: {(!wasDivided ? "Error: Failed to divide..." : result.ToString(CultureInfo.CurrentCulture))}");

        }

        private static void StaticFields()
        {
            var c1 = new Character();
            var c2 = new Character();

            Console.Write("c1 speed: ");
            c1.PrintSpeed();
            Console.Write("c2 speed: ");
            c2.PrintSpeed();

            Console.WriteLine("c1 is increasing speed...");
            c1.IncreaseSpeed();

            Console.Write("c1 speed: ");
            c1.PrintSpeed();
            Console.Write("c2 speed: ");
            c2.PrintSpeed();

            Console.WriteLine("c2 is increasing speed...");
            c2.IncreaseSpeed();

            Console.Write("c1 speed: ");
            c1.PrintSpeed();
            Console.Write("c2 speed: ");
            c2.PrintSpeed();

        }

        private static void OptionalVariables()
        {
            var c = new Calculator();
            Console.WriteLine($"Triangle AB=7, AC=9, Angle=30 deg: {c.CalcTriangleArea(3.0,4.0, 90f)}");
            Console.WriteLine($"Triangle AB=7, AC=9, Angle=30 deg: {c.CalcTriangleArea(3.0,4.0, 1.57f, true)}");

            Console.WriteLine($"Triangle AB=7, AC=9, Angle=30 deg: {c.CalcTriangleArea(20.0,21.0, 90f)}");
            Console.WriteLine($"Triangle AB=7, AC=9, Angle=30 deg: {c.CalcTriangleArea(20.0,21.0, 1.57f, true)}");

            Console.WriteLine($"Triangle AB=7, AC=9, Angle=30 deg: {c.CalcTriangleArea(7.0,9.0, 30f)}");
            Console.WriteLine($"Triangle AB=7, AC=9, Angle=30 deg: {c.CalcTriangleArea(7.0,9.0, 0.5235f, true)}");
        }

        private static void ClassAndStruct()
        {
            PointVal a; // PointVal a = new PointVal();
            a.X = 5;
            a.Y = 9;

            PointVal b = a;
            b.X = 4;
            b.Y = 8;

            a.LogValues();
            b.LogValues();

            PointRef c = new PointRef();
            c.X = 5;
            c.Y = 9;

            PointRef d = c;
            d.X = 4;
            d.Y = 8;

            c.LogValues();
            d.LogValues();

            Console.WriteLine("----------------");

            var es1 = new EvilStruct();
            es1.Name = "es1";
            es1.X = 1;
            es1.Y = 2;
            es1.PrRef = new PointRef() {X = 11, Y = 22};

            var es2 = es1;
            es2.Name = "es2";

            es1.LogValues();
            es2.LogValues();
            Console.WriteLine();

            es2.X = 3;
            es2.Y = 4;
            es2.PrRef.X = 33;
            es2.PrRef.Y = 44;

            es1.LogValues();
            es2.LogValues();
            Console.WriteLine();
        }

        private static void ReferenceParameters()
        {
            var list = new List<int>();
            AddNumbers(list);

            Console.Write("List: ");
            foreach (var element in list)
            {
                Console.Write($"{element} ");
            }

            Console.WriteLine();

            int a = 20;
            int b = 30;
            Console.WriteLine($"Swap. Original before: a={a}, b={b}");
            Swap(a, b);
            Console.WriteLine($"Swap. Original after: a={a}, b={b}");

            Console.WriteLine();

            Console.WriteLine($"SwapR. Original before: a={a}, b={b}");
            SwapR(ref a, ref b);
            Console.WriteLine($"SwapR. Original after: a={a}, b={b}");

        }

        private static void AddNumbers(List<int> numbers)
        {
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
        }

        private static void Swap(int a, int b)
        {
            Console.WriteLine($"Swap. Internal before: a={a}, b={b}");
            int tmp = a;
            a = b;
            b = tmp;

            Console.WriteLine($"Swap. Internal after: a={a}, b={b}");
        }

        private static void SwapR(ref int a, ref int b)
        {
            Console.WriteLine($"SwapR. Internal before: a={a}, b={b}");
            int tmp = a;
            a = b;
            b = tmp;

            Console.WriteLine($"SwapR. Internal after: a={a}, b={b}");
        }

        private static void NullableStructures()
        {
            PointVal pv;
            // Console.WriteLine(pv.X); // Not initialized
            PointRef pr = null;
            // Console.WriteLine(pr.X); // Null Pointer Exception

            PointVal? pv2 = null;

            if (pv2.HasValue)
            {
                PointVal pv3 = pv2.Value;
                Console.WriteLine(pv2.Value.X);
                Console.WriteLine(pv3.X);
            }

            PointVal pv4 = pv2.GetValueOrDefault();

        }

        private static void BoxingAndUnboxing()
        {
            int x = 1;
            object obj = x;    // Boxing

            int y = (int) obj; // Unboxing

            double pi = 3.14;
            object obj2 = pi;

            // double number = (int) obj2;      // Invalid Cast Exception
            double number = (int)(double) obj2; // Possible workaround
            Console.WriteLine(number);

            var point = new PointRef();
            DoSomething(point);
            Console.WriteLine($"PointRef: x={point.X}, y={point.Y}");

        }

        private static void DoSomething(object o)
        {
            if (o is PointRef)
            {
                PointRef pr = (PointRef) o;
                pr.X = 11;
                pr.Y = 22;
            }

            PointRef pr2 = o as PointRef;
            if (pr2 != null)
            {
                // Do Something
            }

            if (o is PointRef pr3)
            {
                // Do Something
            }
        }

        private static void ClassConstruction()
        {
            Character c = new Character("Elf");
            Console.WriteLine($"Character: {c.Race} HP:{c.Health}");

            Character c1 = new Character("Orc", 200);
            Console.WriteLine($"Character: {c.Race} HP:{c1.Health}");
        }

        private static void Inheritance()
        {
            Ingenico in112233 = new Ingenico("112233");
            in112233.Connect();

            Telco tl556677 = new Telco("556677");
            tl556677.Connect();

            SZFP sz889944 = new SZFP("889944");
            sz889944.Connect();
        }

        private static void Polymorphism()
        {
            // Shape shape = new Shape(); // Abstract  class couldn't be created

            Shape[] shapes = new Shape[2];
            shapes[0] = new Triangle(20,21,29);
            shapes[1] = new Rectangle(10,20);

            foreach (Shape shape in shapes)
            {
                shape.Draw();
                Console.WriteLine($"Area of shape: {shape.Area()}");
                Console.WriteLine($"Perimeter of shape: {shape.Perimeter()}");
            }
        }

        private static void Interfaces()
        {
            IBaseCollection collection = new BaseList(4);
            collection.Add(11);
            collection.Add(22);
            collection.Add(33);

            Console.Write($"My Collection Size={collection.Size()}:\t");
            foreach (var item in collection)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            collection.RemoveLast("something");

            Console.Write($"My Collection Size={collection.Size()}:\t");
            foreach (var item in collection)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            collection.RemoveLast("something");
            collection.RemoveLast("something");
            collection.Add(55);

            Console.Write($"My Collection Size={collection.Size()}:\t");
            foreach (var item in collection)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            collection.Add(61);
            collection.Add(63);
            collection.Add(65);
            collection.Add(67);
            collection.Add(69);
            collection.Add(71);
            collection.Add(73);
            collection.Add(75);
            collection.Add(77);
            collection.Add(79);
            collection.Add(81);
            collection.Add(83);

            Console.Write($"My Collection Size={collection.Size()}:\t");
            foreach (var item in collection)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            collection.RemoveLast("something");
            collection.RemoveLast("something");
            collection.RemoveLast("something");
            collection.RemoveLast("something");
            collection.RemoveLast("something");

            Console.Write($"My Collection Size={collection.Size()}:\t");
            foreach (var item in collection)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            // object[] newItems = {101, 102, 103, 104, 105, 106, 107, 108, 109, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119};
            object[] newItems = {101, 102, 103, 104, 105, 106, 107, 108, 109, 109, 110, 111, 112};
            collection.AddRange(newItems);

            Console.Write($"My Collection Size={collection.Size()}:\t");
            foreach (var item in collection)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            collection.RemoveLastN(8);

            Console.Write($"My Collection Size={collection.Size()}:\t");
            foreach (var item in collection)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        private static void EvilInheritance()
        {
            // Rect rect   = new Rect() {Height = 10, Width = 20};
            // Console.WriteLine($"Rect area = {AreaCalculator.CalcArea(rect)}");
            //
            // Rect square = new Square() {Height = 10, Width = 10};
            // Console.WriteLine($"Rect area = {AreaCalculator.CalcArea(square)}");

            IShape rect = new Rect() {Height = 10, Width = 20};
            Console.WriteLine($"Rect area = {rect.CalcArea()}");
            IShape square = new Square() {SideLenght = 10};
            Console.WriteLine($"Square area = {square.CalcArea()}");
        }
    }
}
