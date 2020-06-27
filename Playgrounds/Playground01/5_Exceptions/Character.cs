using System;
using System.Threading;

namespace _5_Exceptions
{
    public enum Race : int
    {
        Elf,
        Orc,
        Human,
        Halfling,
        Dwarf,
        Unknown
    }

    public class Character
    {

        private static int _speed = 10;

        public int Health { get; private set; } = 100;

        public Race Race { get; private set; }

        public int Armor { get; set; }

        public string Name { get; set; }

        // Default constructor
        public Character()
        {
            SetRace(Race.Unknown);
        }

        public Character(string name)
        {
            Name = name;
        }

        public Character(Race race)
        {
            SetRace(race);
        }

        public Character(string name, int armor)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name), "Name value can't be null");
            }

            if (armor < 0 || armor > 100)
            {
                throw new ArgumentException("Armor value should be between 0 and 100");
            }

            Name = name;
            Armor = armor;
        }

        public Character(Race race, int health)
        {
            SetRace(race);
            Health = health;
        }

        public Character(Race race, int health, int speed)
        {
            SetRace(race);
            Health = health;
        }

        public void Hit(int damage)
        {
            if (Health == 0)
                throw new InvalidOperationException($"{this.Name} is already dead");

            if (damage > Health)
            {
                damage = Health;
                Health -= damage;
                throw new ArgumentException("Damage is too high. Damage reduced to the health value");
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
        }

        private void SetRace(Race race)
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
