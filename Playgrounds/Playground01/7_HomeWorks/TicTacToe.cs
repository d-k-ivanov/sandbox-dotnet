using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;

namespace _7_HomeWorks
{
    public enum State
    {
        Cross,
        Zero,
        Unset
    }

    public enum Winner
    {
        Crosses,
        Zeroes,
        Draw,
        GameIsUnfinished
    }

    public class TicTacToe
    {
        private readonly State[] _board = new State[9];
        public int MovesCounter { get; set; }

        public TicTacToe()
        {
            for (int i = 0; i < _board.Length; i++)
            {
                _board[i] = State.Unset;
            }
        }

        public void MakeMove(int index)
        {
            _board[index - 1] = MovesCounter % 2 == 0 ? State.Cross : State.Zero;
            MovesCounter++;
        }

        public State GetCurrentPlayer()
        {
            return MovesCounter % 2 == 0 ? State.Cross : State.Zero;
        }

        public State GetState(int index)
        {
            return _board[index - 1];
        }

        public Winner GetWinner()
        {
            return GetWinner(1, 4, 7, 2, 5, 8, 3, 6, 9,
                1, 2, 3, 4, 5, 6, 7, 8, 9,
                1, 5, 9, 3, 5, 7);
        }

        private Winner GetWinner(params int[] indexes)
        {
            for (int i = 0; i < indexes.Length; i += 3)
            {
                bool same = AreSame(indexes[i], indexes[i + 1], indexes[i + 2]);
                if (same)
                {
                    State state = GetState(indexes[i]);
                    if (state != State.Unset)
                    {
                        return state == State.Cross ? Winner.Crosses : Winner.Zeroes;
                    }
                }
            }

            if (MovesCounter < 9)
                return Winner.GameIsUnfinished;
            return Winner.Draw;
        }

        private bool AreSame(int a, int b, int c)
        {
            return GetState(a) == GetState(b) && GetState(a) == GetState(c);
        }
    }

    public class TicTacToePlay
    {
        public static TicTacToe Game = new TicTacToe();

        public static void MakeTurn()
        {
            int index = -1;
            bool loop = true;
            while (loop)
            {
                Console.Write($"{PrintCurrentPlayer()}: enter cell number: ");
                string answer = Console.ReadLine();

                try
                {
                    index = int.Parse(answer);
                    loop = false;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Error: The number is too big...");
                    loop = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Incorrect data format. Only numbers are allowed...");
                    loop = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: Something wrong happened... ");
                    Console.WriteLine("Details: ");
                    Console.WriteLine(ex.ToString());
                    loop = true;
                }
            }
            Game.MakeMove(index);
        }

        public static string PrintCurrentPlayer()
        {
            return Game.GetCurrentPlayer() == State.Cross ? "Crosses" : "Zeroes";
        }

        public static string PrintState()
        {
            var sb = new StringBuilder();
            for (int i = 1; i <= 7; i += 3)
            {
                sb.AppendLine($"\t|     |     |     |")
                    .AppendLine($"\t|  {GetChar(i)}  |  {GetChar(i+1)}  |  {GetChar(i+2)}  |")
                    .AppendLine($"\t|_____|_____|_____|");
            }

            return sb.ToString();
        }

        private static string GetChar(int index)
        {
            State state = Game.GetState(index);
            if (state == State.Unset)
                return index.ToString();

            return state == State.Cross ? "X" : "O";
        }
    }
}
