using System;
using System.Collections.Generic;
using System.IO;

namespace _7_HomeWorks
{
    public class Hangman
    {
        private readonly int _tries;
        private readonly string _name;

        private readonly List<string> _alphabet = new List<string>
        {
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
            "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
        };

        private readonly List<string> _buffer = new List<string>();

        public Hangman(string playerName, int tries = 10)
        {
            _name   = playerName;
            // _buffer = new string[tries];
            _tries  = tries;
        }

        public void Play()
        {
            string word = GetWord();
            int turn    = 10 - _tries;
            string shownWord;

            while (true)
            {
                Console.Clear();
                Console.WriteLine();
                Console.Write(MakeHangMan(turn));
                Console.WriteLine();
                Console.WriteLine($"\n\tLet's play a game, {_name}\n\t\tTURN: {turn}\n");

                shownWord    = "";
                foreach (var ch in word)
                {
                    if (_buffer.Contains(ch.ToString()))
                    {
                        shownWord += ch.ToString();
                    }
                    else
                    {
                        shownWord += "_";
                    }
                }

                Console.Write(
                    $"     {shownWord}       <<< GUESS THE LETTER!     " +
                    $"Your previous letters: {string.Join(",", _buffer.ToArray())}   : ");

                if (turn == 10 || shownWord == word)
                    break;

                var keyPressed  = Console.ReadKey();
                var key         = keyPressed.Key.ToString();


                if (!_buffer.Contains(key) && _alphabet.Contains(key))
                {
                    _buffer.Add(keyPressed.Key.ToString());
                }
                else
                {
                    continue;
                }

                turn++;
                // System.Threading.Thread.Sleep(1000);
            }

            if (shownWord == word)
                Console.WriteLine($"\n\n\tCONGRATS! YOU WIN, HANGMAN! The answer is {word}");
            else
                Console.WriteLine($"\n\n\tHA-HA-HA! YOU LOOSE, HANGMAN! ...SNAP... The answer was {word}");
        }

        private static string GetWord()
        {
            string[] words  = File.ReadAllLines("HangManWords.txt");
            var rnd         = new Random();
            int index       = rnd.Next(0, words.Length);

            return words[index].ToUpper();
        }

        private string MakeHangMan(int turn)
        {
            string result;
            switch (turn)
            {
                case 10:
                    result =  "\n  ================|\n //               |\n ||               |\n ||               |\n ||              _^_\n ||             / ..\\\n ||            [  _  ]\n ||             \\___/\n ||\n ||               ||    - *Snap!!!*\n ||              /||\\\n ||             //||\\\\\n ||            // || \\\\\n ||            *  ||  *\n ||              //\\\\\n ||             //  \\\\\n /\\            //    \\\\\n//\\\\         ***      ***\n/||\\\\\n_||_\\\\\n";
                    break;
                case 9:
                    result =  "\n  ================|\n //               |\n ||               |\n ||               |\n ||              _^_\n ||             / ..\\\n ||            [  _  ]\n ||             \\___/\n ||               ||\n ||              /||\\\n ||             //||\\\\\n ||            // || \\\\\n ||            *  ||  *\n ||              //\n ||             //\n ||            //\n /\\          ***\n//\\\\ \n/||\\\\ \n_||_\\\\\n";
                    break;
                case 8:
                    result =  "\n  ================|\n //               |\n ||               |\n ||               |\n ||              _^_\n ||             / ..\\\n ||            [  _  ]\n ||             \\___/\n ||               ||\n ||              /||\\\n ||             //||\\\\\n ||            // || \\\\\n ||            *  ||  *\n ||\n ||\n ||\n /\\\n//\\\\\n/||\\\\\n_||_\\\\\n";
                    break;
                case 7:
                    result =  "\n  ================|\n //               |\n ||               |\n ||               |\n ||              _^_\n ||             / ..\\\n ||            [  _  ]\n ||             \\___/\n ||               ||\n ||              /||\n ||             //||\n ||            // ||\n ||            *  ||\n ||\n ||\n ||\n /\\\n//\\\\\n/||\\\\\n_||_\\\\\n";
                    break;
                case 6:
                    result =  "\n  ================|\n //               |\n ||               |\n ||               |\n ||              _^_\n ||             / ..\\\n ||            [  _  ]\n ||             \\___/\n ||               ||\n ||               ||\n ||               ||\n ||               ||\n ||               ||\n ||\n ||\n ||\n /\\\n//\\\\\n/||\\\\\n_||_\\\\\n";
                    break;
                case 5:
                    result =  "\n  ================|\n //               |\n ||               |\n ||               |\n ||              _^_\n ||             / ..\\\n ||            [  _  ]\n ||             \\___/\n ||               ||\n ||\n ||\n ||\n ||\n ||\n ||\n ||\n /\\\n//\\\\\n/||\\\\\n_||_\\\\\n";
                    break;
                case 4:
                    result =  "\n  ================|\n //               |\n ||               |\n ||               |\n ||              _^_\n ||             / ..\\\n ||            [  _  ]\n ||             \\___/\n ||\n ||\n ||\n ||\n ||\n ||\n ||\n ||\n /\\\n//\\\\\n/||\\\\\n_||_\\\\\n";
                    break;
                case 3:
                    result =  "\n  ================|\n //               |\n ||               |\n ||               |\n ||\n ||\n ||\n ||\n ||\n ||\n ||\n ||\n ||\n ||\n ||\n ||\n /\\\n//\\\\\n/||\\\\\n_||_\\\\\n";
                    break;
                case 2:
                    result =  "\n  ================\n //\n ||\n ||\n ||\n ||\n ||\n ||\n ||\n ||\n ||\n ||\n ||\n ||\n ||\n ||\n /\\\n//\\\\\n/||\\\\\n_||_\\\\\n";
                    break;
                case 1:
                    result =  "\n\n\n ||\n ||\n ||\n ||\n ||\n ||\n ||\n ||\n ||\n ||\n ||\n ||\n ||\n ||\n /\\\n//\\\\\n/||\\\\\n_||_\\\\\n";
                    break;
                default:
                    result =  "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n /\\\n//\\\\\n/||\\\\\n_||_\\\\\n";
                    break;
            }

            return result;
        }

    }


}
