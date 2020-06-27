using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using CSCLib;

namespace _6_Streams
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
            FilesAndStreams();
            ConsoleUtils.PrintSeparator();

            try
            {
                FileSystemRunner();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void FilesAndStreams()
        {
            Stream fs = new FileStream("test.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            try
            {
                string str = "Hello, World!\nHello, World!\nHello, World!\nHello, World!\n";
                byte[] strInBytes = Encoding.ASCII.GetBytes(str);
                fs.Write(strInBytes,0, strInBytes.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                fs.Close();
            }

            using(Stream readingStream = new FileStream("test.txt", FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[10];
                var encoding = new ASCIIEncoding();

                int len = 0;
                while ((len = readingStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    var str = Encoding.ASCII.GetString(buffer, 0, len);
                    Console.Write(str);
                }
            }

            Console.WriteLine();

            using (Stream readingStream = new FileStream("test.txt", FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[readingStream.Length];

                int bytesToRead = (int) readingStream.Length;
                int bytesRead = 0;

                while (bytesToRead > 0)
                {
                    var n = readingStream.Read(buffer, bytesRead, bytesToRead);

                    if (n == 0)
                        break;

                    bytesRead += n;
                    bytesToRead -= n;
                }

                var str = Encoding.ASCII.GetString(buffer, 0, buffer.Length);
                Console.Write(str);

            }

            Console.WriteLine();
            Console.WriteLine();

            File.WriteAllText("test2.txt","Test2\nTest2\nTest2\nTest2\nTest2\n");

            File.WriteAllLines("test3.txt",
                new string[]
                {
                    "Test3",
                    "Test3",
                    "Test3",
                    "Test3",
                    "Test3"
                });

            File.WriteAllBytes("test4.txt",
                new byte[]
                {
                    84, 101, 115, 116, 52, 10, // ASCII: Test4
                    84, 101, 115, 116, 52, 10, // ASCII: Test4
                    84, 101, 115, 116, 52, 10, // ASCII: Test4
                    84, 101, 115, 116, 52, 10, // ASCII: Test4
                    84, 101, 115, 116, 52, 10  // ASCII: Test4
                });

            Console.WriteLine("------------------");

            string[] allLines = File.ReadAllLines("test2.txt");
            foreach (var line in allLines)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("------------------");

            string allText = File.ReadAllText("test3.txt");
            Console.Write(allText);

            Console.WriteLine("------------------");
            foreach (var line in File.ReadLines("test4.txt"))
            {
                Console.WriteLine(line);
            }
        }

        private static void FileSystemRunner()
        {
            // Test Data
            File.WriteAllLines("test20.txt",
                new string[]
                {
                    "Test20-Test20-Test20",
                    "Test20-Test20-Test20",
                    "Test20-Test20-Test20",
                    "Test20-Test20-Test20",
                    "Test20-Test20-Test20",
                    "Test20-Test20-Test20",
                    "Test20-Test20-Test20",
                    "Test20-Test20-Test20",
                    "Test20-Test20-Test20"
                });
            // End of Test Data


            // File.Copy("test20.txt", @"D:\text21.txt", overwrite: true);
            File.Copy("test20.txt", "test21.txt", overwrite: true);

            // System.Threading.Thread.Sleep(1000);
            File.Move("test21.txt","test22.txt", overwrite: true);
            File.Copy("test22.txt","test22_1.txt", overwrite: true);

            // System.Threading.Thread.Sleep(1000);
            File.Delete("test22_1.txt");

            if (File.Exists("test22.txt"))
            {
                File.AppendAllText("test22.txt", "bla-bla-bla");
                File.Copy("test22.txt","test23.txt", overwrite: true);
            }

            File.Replace("test20.txt", "test23.txt", "test23.bak.txt");

            var tmpDirExist = Directory.Exists(@"C:\Temp");
            if (tmpDirExist)
            {
                var files = Directory.EnumerateFiles(@"C:\Temp");
                Console.WriteLine("C:\\Temp\\: ");
                foreach (var file in files)
                {
                    Console.WriteLine($"\t{file}");
                }

                Console.WriteLine();
                Console.WriteLine("--------------");
                Console.WriteLine();
                files = Directory.EnumerateFiles(@"C:\Temp", "*.xlsx", SearchOption.AllDirectories);
                Console.WriteLine("C:\\Temp\\*.xlsx: ");
                foreach (var file in files)
                {
                    Console.WriteLine($"\t{file}");
                }
            }

            // Directory.Delete(".....");
            Console.WriteLine();
            Console.WriteLine("--------------");
            Console.WriteLine();

            string fullPath = Path.Combine("C:", "Temp", "Super", "Folder", "text.txt");
            Console.WriteLine(fullPath);

        }

    }
}
