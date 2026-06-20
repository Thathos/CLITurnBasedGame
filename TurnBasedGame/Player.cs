using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame
{
    internal class Player : Character
    {
        public int potionCount = 2;
        public Player(int hp, string name)
            :base(hp, name)
        {

        }

        //potions to increase health
        public void UsePotion(Player player)
        {
            if (potionCount <= 0)
            {
                Console.WriteLine("You have no potions remaining!");
            }
            else if (potionCount > 0)
            {
                player.Hp += 10;
                potionCount--;
            }
        }


    }
}
