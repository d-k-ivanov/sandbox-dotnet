using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            LinqDemo_2();

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
            ConsoleUtils.PrintSeparator();

            LinqDemo_1();
            ConsoleUtils.PrintSeparator();

            LinqDemo_2();
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
            // var game = new TenSticksGame(p1,p3);
            var game = new TenSticksGame(p3,p4);
            game.GameInProgress += Game_GameInProgress;
            game.SticksTaken += Game_SticksTaken;
            game.EndGame += Game_EndGame;
            // game.Start();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("\t\tStarting 10 Sticks Demo.\n");
                game.Start();
                ConsoleUtils.PrintInternalSeparator();

            }

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
            Console.WriteLine("\t---------------");
            Console.WriteLine($"\tPlayer {player.Name} wins!");
        }

        private static void LinqDemo_1()
        {
            NoLinqFileInfoDemo(@"C:\Windows");
        }


        private static void NoLinqFileInfoDemo(string path)
        {
            var directoryInfo = new DirectoryInfo(path);
            FileInfo[] files = directoryInfo.GetFiles();

            Array.Sort(files, FilesComparisonBigger);

            Console.WriteLine(String.Format("{0,40} {1,10}", "File", "Size"));


            for (int i = 0; i < 6; i++)
            {
                var file = files[i];
                Console.WriteLine($"{file.Name,40} {file.Length / 1024,10}");
            }
        }

        private static void LinqDemo_2()
        {
            LinqFileInfoDemo(@"C:\Windows");
        }

        private static void LinqFileInfoDemo(string path)
        {
            Console.WriteLine($"{"File",40} {"Size",10}");
            new DirectoryInfo(path)
                .GetFiles()
                .OrderByDescending(file => file.Length)
                .Take(5)
                .ForEach(file => Console.WriteLine($"{file.Name,40} {file.Length / 1024,10}"));

            // ==
            // IEnumerable<FileInfo> orderedFiles = new DirectoryInfo(path)
            //     .GetFiles()
            //     .OrderBy(file => file.Length)
            //     .Take(5);
            //
            // foreach (var file in orderedFiles)
            // {
            //     Console.WriteLine($"{file.Name,40} {file.Length / 1024,10}");
            // }

        }

        // private static long KeySelector(FileInfo file)
        // {
        //     return file.Length;
        // }

        private static int FilesComparisonBigger(FileInfo x, FileInfo y)
        {
            if (x.Length == y.Length) return 0;
            if (x.Length > y.Length) return -1;
            return 1;
        }

        private static int FilesComparisonSmaller(FileInfo x, FileInfo y)
        {
            if (x.Length == y.Length) return 0;
            if (x.Length > y.Length) return 1;
            return -1;
        }

    }
}
