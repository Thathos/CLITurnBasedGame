using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame
{
    //Just playing with adding classes.
    internal class Mage : Player
    {

        public Mage(int hp, string name)
            : base(hp, name)
        {

        }

        public override int AttackEnemy()
        {
            return base.AttackEnemy();
        }

        public int CastFireball()
        {
            return _rng.Next(3, 7);
        }


    }
}
