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

            // StartAll();
            TenSticks();

            // -----------------------------------------------
            ConsoleUtils.EndOfProgram();
        }

        private static void StartAll()
        {
            DelegatesDemo();
            ConsoleUtils.PrintSeparator();

            TimerDemo();
            ConsoleUtils.PrintSeparator();

            TenSticks();
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

        private static void TenSticks()
        {
            var p1 = new TenSticksPlayer("John", SticksPlayerType.Human);
            var p2 = new TenSticksPlayer("Karl", SticksPlayerType.Human);
            var p3 = new TenSticksPlayer("R2D2", SticksPlayerType.Cpu);
            var p4 = new TenSticksPlayer("C3PO", SticksPlayerType.Cpu);

            // var game = new TenSticksGame(p1,p2);
            var game = new TenSticksGame(p1,p3);
            // var game = new TenSticksGame(p3,p4);
            game.GameInProgress += Game_GameInProgress;
            game.SticksTaken += Game_SticksTaken;
            game.EndGame += Game_EndGame;
            game.Start();

        }

        private static int Game_GameInProgress(TenSticksGame game, TenSticksPlayer player)
        {
            var sticksToTake = -1;
            var max = game.SticksCurrent >= 3 ? 3 : game.SticksCurrent;

            // Console.WriteLine($"Remaining sticks: game.SticksCurrent");
            Console.WriteLine($"Remaining sticks: {game.SticksCurrent} --> {new string('|', game.SticksCurrent)}");
            Console.Write($"\t{player.Name} take from 1 to {max}.");

            if (player.SticksPlayerType == SticksPlayerType.Cpu)
            {
                sticksToTake = game.Random.Next(1, max+1);
                return sticksToTake;
            }

            while (sticksToTake < 1 || sticksToTake > max)
            {
                switch (sticksToTake)
                {
                    case -1:
                        break;
                    default:
                        Console.Write($"\tWrong Number. Enter number from 1 to {max}: ");
                        break;
                }

                var answer = Console.ReadLine();
                try
                {
                    sticksToTake = int.Parse(answer);
                }
                catch (FormatException)
                {
                    sticksToTake = -2;
                }
            }

            return sticksToTake;
        }

        private static void Game_SticksTaken(TenSticksPlayer player, int sticks)
        {
            Console.WriteLine($"\t{player.Name} took {sticks} sticks");
        }

        private static void Game_EndGame(TenSticksPlayer player)
        {
            Console.WriteLine(new string('-', 25));
            Console.WriteLine($"\tPlayer {player.Name} wins!");
        }
    }
}
