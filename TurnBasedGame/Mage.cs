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

        public Mage(int hp, string name, int mana)
            : base(hp, name, mana)
        {

        }

        public override int AttackEnemy()
        {
            return base.AttackEnemy();
        }

        public override int SpecialAttack(Player player)
        {
            Console.WriteLine($"{player.Name} casts fireball!");
            return _rng.Next(3, 7);
        }

        public override void Menu()
        {
            Console.WriteLine($"1.)Attack");
            Console.WriteLine($"2.) Use Health potion");
            Console.WriteLine($"3.) Fireball");
            //base.Menu();
        }
    }
}
