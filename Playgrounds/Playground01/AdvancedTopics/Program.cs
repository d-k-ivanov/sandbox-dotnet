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

            StartAll();

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
            ConsoleUtils.PrintSeparator();

            ChessPlayersAnalysis();
            ConsoleUtils.PrintSeparator();

            LazyAndGreedyEvaluationsDemo();
            ConsoleUtils.PrintSeparator();

            RemovalDemo();
            ConsoleUtils.PrintSeparator();

            ChessPlayersRus("Top100ChessPlayers.csv");
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

        private static void ChessPlayersAnalysis()
        {
            ChessPlayersMinMaxAvg("Top100ChessPlayers.csv");
            ConsoleUtils.PrintInternalSeparator();

            ChessPlayersList("Top100ChessPlayers.csv");
            ConsoleUtils.PrintInternalSeparator();

            ChessPlayersLinqDemo("Top100ChessPlayers.csv");
        }

        private static void ChessPlayersMinMaxAvg(string file)
        {
            List<ChessPlayer> list = File.ReadAllLines(file)
                                        .Skip(1)
                                        .Select(ChessPlayer.ParseFideData) // .Select(x => ChessPlayer.ParseFideData(x))
                                        // Anonymous expressions
                                        // .Where(delegate(ChessPlayer player) { return player.BirthYear > 1988; })
                                        // Lambda expressions
                                        .Where(player => player.BirthYear > 1988)
                                        .OrderByDescending(player => player.Rating)
                                        .Take(10)
                                        .ToList();

            // SQL-like sintax
            // var list2 = File.ReadAllLines(file)
            //                             .Skip(1)
            //                             .Select(ChessPlayer.ParseFideData);
            //
            // var filtered = from player in list2
            //                                           where player.BirthYear > 1988
            //                                           orderby player.Rating descending
            //                                           select player;

            Console.WriteLine($"The lowest  rating in TOP 10: {list.Min(x => x.Rating)}");
            Console.WriteLine($"The highest rating in TOP 10: {list.Max(x => x.Rating)}");
            Console.WriteLine($"The average rating in TOP 10: {list.Average(x => x.Rating)}");
        }

        private static void ChessPlayersList(string file)
        {
            File.ReadAllLines(file)
                .Skip(1)
                .Select(ChessPlayer.ParseFideData)
                .OrderByDescending(player => player.Rating)
                .ThenByDescending(player => player.Country)
                .ToList()
                .ForEach(Console.WriteLine);
        }


        private static void ChessPlayersLinqDemo(string file)
        {
            List<ChessPlayer> list = File.ReadAllLines(file)
                .Skip(1)
                .Select(ChessPlayer.ParseFideData) // .Select(x => ChessPlayer.ParseFideData(x))
                .OrderByDescending(player => player.Rating)
                .ToList();

            Console.WriteLine($"First:      {list.First()}");
            Console.WriteLine($"Last:       {list.Last()}");

            Console.WriteLine($"First RUS:  {list.First(player => player.Country == "RUS")}");
            Console.WriteLine($"Last  USA:  {list.Last(player => player.Country == "USA")}");

            Console.WriteLine($"First BRA:  {list.FirstOrDefault(player => player.Country == "BRA")}");
            Console.WriteLine($"Last  BRA:  {list.LastOrDefault(player => player.Country == "BRA")}");

            Console.WriteLine($"Single VIE: {list.Single(player => player.Country == "VIE")}");
            Console.WriteLine($"Single BRA: {list.SingleOrDefault(player => player.Country == "BRA")}");
        }

        private static void ChessPlayersRus(string file)
        {
            List<ChessPlayer> list = File.ReadAllLines(file)
                .Skip(1)
                .Select(ChessPlayer.ParseFideData)
                .Where(player => player.Country == "RUS")
                .OrderBy(player => player.BirthYear)
                .ToList();

            foreach (var chessPlayer in list)
            {
                Console.WriteLine(chessPlayer);
            }

        }

        private static void LazyAndGreedyEvaluationsDemo()
        {
            var list = new List<int> {1, 2, 3};
            var query = list.Where(x => x >= 2 );
            list.Remove(3);

            foreach (var item in query)
            {
                Console.WriteLine($"Q Item: {item}");
            }

            Console.WriteLine($"Q Count: {query.Count()}");

            // Lazy: Select, SelectMany, Take, Skip, Where
            // Greedy: Count, Average, Mean, Max, Sum, Last, ToList

        }

        public static void RemovalDemo()
        {
            // RemoveInForEach();
            // ConsoleUtils.PrintInternalSeparator();

            RemoveInFor();
            ConsoleUtils.PrintInternalSeparator();

            RemoveInForBackward();
            ConsoleUtils.PrintInternalSeparator();

            RemoveAllDemo();
        }

        private static void RemoveInForEach()
        {
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9};
            foreach (var item in list)
            {
                if (item % 2 == 0)
                {
                    list.Remove(item);
                }
            }

            Console.WriteLine($"List size: {list.Count}");

            // List<int>.Enumerator enumerator = list.GetEnumerator();
            // try
            // {
            //     while (enumerator.MoveNext())
            //     {
            //         int item = enumerator.Current;
            //     }
            // }
            // finally
            // {
            //     enumerator.Dispose();
            // }
        }

        private static void RemoveInFor()
        {
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9};
            for (int index = 0; index < list.Count; index++)
            {
                var item = list[index];
                if (item % 2 == 0)
                {
                    list.Remove(item);
                    index--; // Important to move index back
                }
            }

            Console.WriteLine($"List Count == 5? {list.Count == 5}");


            Console.WriteLine("RemoveInFor");
            var list2 = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9};
            for (int index = 0; index < list2.Count; index++)
            {
                var item = list2[index];
                if (item >= 5)
                {
                    list2.Remove(item);
                    index--; // Important to move index back
                }
            }

            Console.WriteLine($"List Count == 4? {list2.Count == 4}");
        }

        private static void RemoveInForBackward()
        {
            Console.WriteLine("RemoveInForBackward");
            var list2 = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9};
            for (int index = list2.Count - 1; index >= 0; index--)
            {
                var item = list2[index];
                if (item >= 5)
                {
                    list2.Remove(item);
                }
            }

            Console.WriteLine($"List Count == 4? {list2.Count == 4}");
        }

        private static void RemoveAllDemo()
        {
            Console.WriteLine("RemoveAllDemo");
            var list2 = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9};
            list2.RemoveAll(x => x >= 5);

            Console.WriteLine($"List Count == 4? {list2.Count == 4}");
        }
    }
}
