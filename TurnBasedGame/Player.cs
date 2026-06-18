using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame
{
    internal class Player : Character
    {
        public Player player { get; set; } = null!;
        public Player(int hp, int attackPower, string name)
            :base(hp, attackPower, name)
        {

        }

        //add potions to increase health
        public void UsePotion(Player player)
        {
            player.Hp += 10;
        }
    }
}
