using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame
{
    internal class Player : Character
    {

        public Player(int hp, int attackPower, string name)
            :base(hp, attackPower, name)
        {

        }
    }
}
