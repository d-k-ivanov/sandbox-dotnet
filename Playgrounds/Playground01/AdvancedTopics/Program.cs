using System;
using System.Timers;
using CSCLib;

namespace AdvancedTopics
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
            DelegatesDemo();
            ConsoleUtils.PrintSeparator();

            TimerDemo();
        }

        private static void DelegatesDemo()
        {
            var car = new Car();

            // car.RegisterOnTooFast(HandleTooFast1);
            // car.RegisterOnTooFast(HandleTooFast2);
            // car.RegisterOnTooFast(HandleTooFast2);
            // car.UnRegisterOnTooFast(HandleTooFast2);


            // Register
            car.TooFastDriving += HandleTooFast1;
            car.TooFastDriving += HandleTooFast2;

            // car.TooFastDriving += HandleTooFast2;

            // UnRegister. With null handling
            // car.TooFastDriving -= HandleTooFast2;
            // car.TooFastDriving -= HandleTooFast2;
            // car.TooFastDriving -= HandleTooFast1;
            // car.TooFastDriving -= HandleTooFast1;

            // EventHandler Demo
            car.TooFastDrivingEh += HandleTooFast1Eh;
            car.TooFastDrivingEh += HandleTooFast2Eh;


            car.Start();
            Console.WriteLine("Accelerating....");
            for (var i = 0; i < 40; i++)
            {
                Console.WriteLine($"Current Speed: {car.Speed}");
                car.Accelerate();
            }
            Console.WriteLine($"Last Speed: {car.Speed}");
        }

        // Actions
        private static void HandleTooFast1(Car car)
        {
            Console.WriteLine($"Handler1: Too fast. Speed: {car.Speed}. Stopping...");
            car.Stop();
        }

        private static void HandleTooFast2(Car car)
        {
            Console.WriteLine($"Handler2: Too fast. Speed: {car.Speed}. Starting...");
            car.Start();
        }

        // Func-based hndlers
        // private static string HandleTooFast1(Car car)
        // {
        //     Console.WriteLine($"Handler1: Too fast. Speed: {car.Speed}. Stopping...");
        //     car.Stop();
        //     return "Handler1";
        // }

        // private static string HandleTooFast2(Car car)
        // {
        //     Console.WriteLine($"Handler2: Too fast. Speed: {car.Speed}. Starting...");
        //     car.Start();
        //     return "Handler2";
        // }

        // Event Handlers
        private static void HandleTooFast1Eh(object sender, CarArgs e)
        {
            var car = (Car) sender;
            Console.WriteLine($"From HandleTooFast1EH: Speed {car.Speed}");
        }

        private static void HandleTooFast2Eh(object sender, CarArgs e)
        {
            var car = (Car) sender;
            Console.WriteLine($"From HandleTooFast2EH: Speed {car.Speed}");
        }

        private static void TimerDemo()
        {
            var timer = new Timer();
            timer.Elapsed += Timer_Elapsed;
            timer.Interval = 1000;
            timer.Start();

            for (int i = 0; i < 10; i++)
            {
                System.Threading.Thread.Sleep(500);
            }

            timer.Stop();
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var timer = (Timer) sender;
            Console.WriteLine("Handling timer events...");
        }
    }
}
