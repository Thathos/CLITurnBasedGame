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



        public Character(int hp,  string name)
        {
            Hp = hp;
            Name = name;
        }

        public virtual int AttackEnemy()
        {
            Random random = new Random();
            int attackPower = random.Next(1, 5);
            return attackPower;
        }
    }
}
