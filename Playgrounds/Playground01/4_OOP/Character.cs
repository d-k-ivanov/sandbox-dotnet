using System;

namespace _4_OOP
{
    public class Character
    {
        private static int _speed = 10;
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
        }

    }
}
