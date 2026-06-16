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
        public int AttackPower { get; set; }
        public string Name { get; set; }

        public Character(int hp, int attackPower, string name)
        {
            Hp = hp;
            AttackPower = attackPower;
            Name = name;
        }
    }
}
