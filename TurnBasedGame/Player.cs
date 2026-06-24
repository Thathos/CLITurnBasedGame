using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame
{
    internal class Player : Character
    {
        private int _potionCount = 2;
        public Player(int hp, string name)
            : base(hp, name)
        {

        }

        //potions to increase health
        public bool UsePotion()
        {
            if (_potionCount <= 0) //if potion count is 0 write the message and forfeit your turn, which is bad
            {
                Console.WriteLine("You have no potions remaining!");
                return false;
            }
            Hp += 10; //add the potion to the player's health
            _potionCount--; //decrement potion count
            return true;
        }

    }
}
