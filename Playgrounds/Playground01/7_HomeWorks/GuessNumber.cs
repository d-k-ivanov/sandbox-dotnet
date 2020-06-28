using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic;

namespace _7_HomeWorks
{
    public enum PlayerType
    {
        Human,
        Cpu
    }

    public class GuessNumber
    {

        private int _guessedNumber;
        private int _tries;

        private int _lower = 0;
        private int _upper = 100;

        private readonly Player _player1;
        private readonly Player _player2;
        public Player Winner;



        public GuessNumber(Player p1, Player p2, int numberOfTries = 5)
        {
            _player1 = p1;
            _player2 = p2;
            _tries = numberOfTries;
            Console.WriteLine($"\n\tPlayer {p1.Name} VS Player {p2.Name}\n");
        }

        public int Play()
        {
            Console.WriteLine($"Player {_player1.Name} turn:");
            Console.Write("\tThink of number from 0 to 100: ");
            _guessedNumber = _player1.GetNumber(from: _lower, to: _upper);

            Console.WriteLine("\n\n==============================");
            Console.WriteLine($"Player {_player2.Name} turn:");

            while (_tries > 0)
            {
                Console.Write($"\tGuess number from {_lower} to {_upper}: ");
                var ans = _player2.GetNumber(from: _lower, to: _upper);
                if (_player2.PlayerType == PlayerType.Cpu)
                    Console.WriteLine($"\t{ans}");

                if (ans == _guessedNumber)
                {
                    Console.WriteLine($"\n\tPlayer {_player2.Name} win. The answer is {ans}");
                    Winner = _player2;
                    return ans;
                }

                if (ans > _guessedNumber)
                {
                    if (_player2.PlayerType == PlayerType.Human)
                        Console.WriteLine("\tWrong! The guessed number is bigger than your.");
                    _upper = ans;
                }


                if (ans < _guessedNumber)
                {
                    if (_player2.PlayerType == PlayerType.Human)
                        Console.WriteLine("\tWrong! The guessed number is lesser than your.");
                    _lower = ans;
                }

                _tries--;
            }

            if (_player2.PlayerType == PlayerType.Human)
                Console.WriteLine($"\nThe number of tries expired. Player {_player1.Name} win the game. Game over...");

            Winner = _player1;
            return _guessedNumber;
        }
    }

    public class Player
    {
        public string Name { get; private set; }
        public PlayerType PlayerType { get; private set; }

        public Player(string name, PlayerType playerType = PlayerType.Cpu)
        {
            Name        = name;
            PlayerType  = playerType;
        }

        public int GetNumber(int from, int to)
        {
            if (this.PlayerType == PlayerType.Cpu)
            {
                var rnd = new Random();
                return rnd.Next(from, to + 1);
            }

            var number = -1;
            while (number < from || number > to)
            {
                switch (number)
                {
                    case -1:
                        break;
                    default:
                        Console.Write($"\tWrong Number. Enter number from {from} to {to}: ");
                        break;
                }

                var answer = Console.ReadLine();
                try
                {
                    number = int.Parse(answer);
                }
                catch (FormatException)
                {
                    number = -2;
                }
            }

            return number;
        }
    }
}
