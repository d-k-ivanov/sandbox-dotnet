using System;
using System.Text;
using System.Threading;

namespace _1_BaseFeatures
{
    internal static class Strings
    {
        internal static void PrintBasicStringOperations()
        {
            string name = "abracadabra";
            bool containsA = name.Contains('a');
            bool containsE = name.Contains('E');

            Console.WriteLine("\t" + containsA);
            Console.WriteLine("\t" + containsE);

            bool endsWithAbra = name.EndsWith("abra");
            Console.WriteLine("\t" + endsWithAbra);

            bool startsWithAbra = name.StartsWith("abra");
            Console.WriteLine("\t" + startsWithAbra);

            int indexOfA = name.IndexOf('a');
            Console.WriteLine("\t" + indexOfA);

            int lastIndexOfR = name.LastIndexOf('r');
            Console.WriteLine("\t" + lastIndexOfR);

            Console.WriteLine("\t" + name.Length);
            Console.WriteLine($"\t{name.Substring(5)}");
            Console.WriteLine($"\t{name.Substring(0,3)}");
        }

        internal static void PrintEmptiness()
        {
            string str1 = "";
            string str2 = " ";
            string str3 = " a";
            string str4 = null;

            Console.WriteLine("IsNullOrEmpty");
            Console.WriteLine("\t" + string.IsNullOrEmpty(str1));
            Console.WriteLine("\t" + string.IsNullOrEmpty(str2));
            Console.WriteLine("\t" + string.IsNullOrEmpty(str3));
            Console.WriteLine("\t" + string.IsNullOrEmpty(str4));
            Console.WriteLine();
            Console.WriteLine("IsWhitespaceOrEmpty");
            Console.WriteLine("\t" + string.IsNullOrWhiteSpace(str1));
            Console.WriteLine("\t" + string.IsNullOrWhiteSpace(str2));
            Console.WriteLine("\t" + string.IsNullOrWhiteSpace(str3));
            Console.WriteLine("\t" + string.IsNullOrWhiteSpace(str4));
        }

        internal static void PrintStringChanging()
        {
            string str = string.Concat("My ", "name ", "is ", "Dima");
            Console.WriteLine("\t" + str);

            str = string.Join(" ", "My", "name", "is", "Dima");
            Console.WriteLine("\t" + str);

            str = str.Insert(0, "BTW, ");
            Console.WriteLine("\t" + str);

            str = str.Remove(0, 2);
            Console.WriteLine("\t" + str);

            str = str.Replace('n', 'z');
            Console.WriteLine("\t" + str);

            string data = "11;12;13;15;15;111111116;17";
            string[] splData = data.Split(';');
            Console.WriteLine("\t" + splData[0]);

            char[] chrs = str.ToCharArray();
            Console.WriteLine("\t" + chrs[0]);
            Console.WriteLine("\t" + str[0]);

            Console.WriteLine("\t" + str.ToUpper());
            Console.WriteLine("\t" + str.ToLower());
            Console.WriteLine("\t" + str.Trim());

            StringBuilder sb = new StringBuilder();
            sb.Append("\t" + "My ");
            sb.Append("name ");
            sb.Append("IS ");
            sb.Append("John");
            sb.AppendLine("!");
            Console.WriteLine("\t" + sb);
            Console.WriteLine();

            string name = "Dima";
            int age = 36;

            Console.WriteLine("\t" + "My name is {0} and I'm {1}", name, age);
            Console.WriteLine("\t" + $"My name is {name} and I'm {age}");
            Console.WriteLine();

            Console.WriteLine("\t" + "My namw is \n\tDima");
            Console.WriteLine("\t" + $"My namw is {Environment.NewLine}\tDima");
            Console.WriteLine("\t" + "I'm Dima and I'm a \"good\" programmer");
            Console.WriteLine("\t" + "c:\\Temp\\test.txt");
            Console.WriteLine("\t" + @"c:\Temp\test.txt");
            Console.WriteLine();

            Console.WriteLine(string.Format("\tNumber: {0:d}", 32));
            Console.WriteLine(string.Format("\tNumber: {0:d4}", 32));
            Console.WriteLine();

            Console.WriteLine(string.Format("\tNumber: {0:f}", 32));
            Console.WriteLine(string.Format("\tNumber: {0:f4}", 32));
            Console.WriteLine();

            Console.WriteLine(string.Format("\tNumber: {0:f}", 32.08));
            Console.WriteLine(string.Format("\tNumber: {0:f1}", 32.08));
            Console.WriteLine();

            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine(string.Format("\tMoney: {0:C}", 32.08));
            Console.WriteLine(string.Format("\tMoney: {0:C1}", 32.08));


            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ru-RU");
            Console.WriteLine(string.Format("\tMoney: {0:C}", 32.08));
            Console.WriteLine(string.Format("\tMoney: {0:C1}", 32.08));

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");
            Console.WriteLine(string.Format("\tMoney: {0:C}", 32.08));
            Console.WriteLine(string.Format("\tMoney: {0:C1}", 32.08));
        }

        internal static void PrintStringsComparison()
        {
            string str1 = "abcde";
            string str2 = "abcde";

            Console.WriteLine("\t" + (str1 == str2));
            Console.WriteLine("\t" + string.Equals(str1, str2, StringComparison.Ordinal));

            string str3 = "Strasse";
            string str4 = "Straße";
            Console.WriteLine("\t" + string.Equals(str3, str4, StringComparison.Ordinal));
            Console.WriteLine("\t" + string.Equals(str3, str4, StringComparison.InvariantCulture));
            Console.WriteLine("\t" + string.Equals(str3, str4, StringComparison.CurrentCulture));

        }
    }
}
