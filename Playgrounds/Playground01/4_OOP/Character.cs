using System;
using System.Collections.Generic;
using System.Text;

namespace _4_OOP
{
    public class Character
    {
        // public
        // private
        // internal
        // protected
        public int Health = 100;

        public void Hit(int damage)
        {
            Health -= damage;
        }
    }
}
