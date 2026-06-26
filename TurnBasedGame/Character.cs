using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame
{
    internal class Character
    {
        public int Hp { get; set; }
        public string Name { get; set; }
        public int Mana { get; set; }

        protected static readonly Random _rng = new(); //creating a Random object once for the Character class

        public Character(int hp,  string name)
        {
            Hp = hp;
            Name = name;
        }

        public virtual int AttackEnemy()
        {
            return _rng.Next(1, 5);
        }

        public void DeductHealth(int damage)
        {
            Hp -= damage;
            if (Hp < 0)
            {
                Hp = 0;
            }
        }

        public bool IsAlive() //checks the target's hp
        {
            if (Hp > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
