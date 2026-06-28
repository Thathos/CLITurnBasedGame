using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame
{
    internal class Enemy : Character
    {

        public Enemy(int hp,  string name, int mana)
            :base(hp,  name, mana)
        {

        }
    }
}
