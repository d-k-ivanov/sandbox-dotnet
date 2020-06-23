using System;

namespace _4_OOP
{
    public class Character
    {
        private static int _speed = 10;
        private const int _kspeed = 10; // Should be initialized here
        private readonly int _speed_ro; // Could be initialized later
        // public
        // private
        // internal
        // protected
        // private int _health = 100;
        // public int GetHealth()
        // {
        //     return _health;
        // }
        // private void SetHealth(int value)
        // {
        //     _health = value;
        // }

        public int Health { get; private set; } = 100;

        public string Race { get; private set; }

        // Default constructor
        public Character()
        {
            SetRace("Unknown");
        }

        public Character(string race)
        {
            SetRace(race);
        }

        public Character(string race, int health)
        {
            SetRace(race);
            Health = health;
        }

        public Character(string race, int health, int speed)
        {
            SetRace(race);
            Health = health;
            _speed_ro = speed;
        }

        public void Hit(int damage)
        {
            if (damage > Health)
            {
                damage = Health;
            }
            Health -= damage;
        }

        public void PrintSpeed()
        {
            Console.WriteLine($"Speed == {_speed}");
        }

        public void IncreaseSpeed()
        {
            _speed += 10;
            // _kspeed += 10;   // Can't
            // _speed_ro += 10; // Can't
        }

        private void SetRace(string race)
        {
            Race = race;
        }
    }

    public class Point2D
    {
        private int x;
        private int y;

        public Point2D(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
