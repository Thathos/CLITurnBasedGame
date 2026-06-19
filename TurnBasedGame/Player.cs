using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame
{
    internal class Player : Character
    {
        //public Player player { get; set; } = null!;
        public Player(int hp,  string name)
            :base(hp, name)
        {

        }

        //add potions to increase health
        public void UsePotion(Player player)
        {
            player.Hp += 10;
        }

        //public override int AttackEnemy(int attackPower)
        //{
        //    return base.AttackEnemy(attackPower);
        //}

    }
}
