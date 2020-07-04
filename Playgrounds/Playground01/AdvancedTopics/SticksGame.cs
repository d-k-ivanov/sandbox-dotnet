using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedTopics
{
    public enum SticksPlayerType
    {
        Human,
        Cpu
    }

    /// <summary>
    /// In the game of sticks there is a heap of sticks on a board.
    /// On their turn, each player picks up 1 to 3 sticks.
    /// The one who has to pick the final stick will be the loser.
    /// </summary>
    public class TenSticksGame
    {
        private enum GameStatus
        {
            NotStarted,
            Progress,
            Finished
        }

        private enum Player : int
        {
            One = 0,
            Two = 1
        }

        public readonly Random Random;
        private GameStatus _gameStatus;

        private Player Current { get; set; }

        private TenSticksPlayer[] players = new TenSticksPlayer[2];

        public int SticksInit { get; }
        public int SticksCurrent { get; private set; }

        public event Func<TenSticksGame, TenSticksPlayer, int> GameInProgress;
        public event Action<TenSticksPlayer,int> SticksTaken;
        public event Action<TenSticksPlayer> EndGame;

        public TenSticksGame(TenSticksPlayer player1, TenSticksPlayer player2, int sticks = 10)
        {
            Random         = new Random();
            _gameStatus     = GameStatus.NotStarted;

            SticksInit      = sticks;
            SticksCurrent   = sticks;

            players[(int)Player.One] = player1;
            players[(int)Player.Two] = player2;

            Current = Random.Next(0, 2) == 0 ? Player.One : Player.Two;
        }

        public void Start()
        {
            switch (_gameStatus)
            {
                case GameStatus.Finished:
                    SticksCurrent = SticksInit;
                    break;
                case GameStatus.Progress:
                    throw new InvalidOperationException("Game already started. Game couldn't be started twice...");
                case GameStatus.NotStarted:
                    _gameStatus = GameStatus.Progress;
                    while (_gameStatus == GameStatus.Progress)
                    {
                        MakeMove();
                        IsGameFinished();
                        Current = Current == Player.One ? Player.Two : Player.One;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void MakeMove()
        {
            // int sticksToTake = 0;
            if (GameInProgress != null)
            {
                var sticksToTake = GameInProgress.Invoke(this, players[(int)Current]);

                TakeSticks(sticksToTake);
                if (sticksToTake != 0)
                    SticksTaken?.Invoke(players[(int)Current], sticksToTake);
            }
            else
            {
                throw new InvalidOperationException("At least one instance GameInProgress handler should be defined.");
            }
        }

        private void IsGameFinished()
        {
            if (SticksCurrent != 0) return;
            _gameStatus = GameStatus.Finished;
            EndGame?.Invoke(Current == Player.One ? players[(int) Player.Two] : players[(int) Player.One]);
        }

        private void TakeSticks(int stickNumber)
        {
            if (stickNumber < 1 || stickNumber > 3)
            {
                throw new ArgumentException("Error: From 1 to 3 sticks could be taken in a single move.");
            }

            if (stickNumber > SticksCurrent)
            {
                throw new ArgumentException($"Error: To much sticks to take. Sticks available: {SticksCurrent}");
            }

            SticksCurrent -= stickNumber;
        }

    }

    public class TenSticksPlayer
    {
        public string Name { get; }
        public SticksPlayerType SticksPlayerType { get; }

        public TenSticksPlayer(string name, SticksPlayerType sticksPlayerType = SticksPlayerType.Human)
        {
            Name = name;
            SticksPlayerType = sticksPlayerType;
        }
    }
}
