using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedGame
{
    internal class Battle
    {
        public Player Player { get; set; } = null!;

        public Enemy Enemy { get; set; } = null!;
        public bool alive { get; set; } = true;

        public Battle(Player player, Enemy enemy)
        {
            Player = player;
            Enemy = enemy;
        }


        public void BeginBattle(Player player, Enemy enemy)
        {
            while (alive)
            {
                ProcessPlayerTurn(player);
                alive = CheckEnemyHp(enemy);
                if (!alive)
                {
                    break;
                }
                ProcessEnemyTurn();
                alive = CheckPlayerHp(player);
            }
        }

        public void ProcessPlayerTurn(Player player)
        {

            Console.WriteLine("What is your choice?");
            int playerChoice = int.Parse(Console.ReadLine());
            if (playerChoice == 1)
            {
                Console.WriteLine($"{Player.Name} attacks {Enemy.Name}!");
                Enemy.Hp -= Player.AttackPower;
                Console.WriteLine($"{Player.Name} deals {Player.AttackPower} damage to {Enemy.Name}!");
                Console.WriteLine($"{Enemy.Name} has {Enemy.Hp} HP remaining!");
            }
            else if (playerChoice == 2)
            {
                Player.UsePotion(player);
                Console.WriteLine($"{Player.Name} used a potion to restore their health!");
                Console.WriteLine($"{Player.Hp}");
            }
        }

        public void ProcessEnemyTurn()
        {
            //Random random = new Random();
            //int enemyAttack = random.Next(1, 5);
            Console.WriteLine($"{Enemy.Name} deals {Enemy.AttackPower} damage to {Player.Name}!");
            Player.Hp -= Enemy.AttackPower;
            Console.WriteLine($"{Player.Name} has {Player.Hp} HP remaining!");
        }

        public bool CheckPlayerHp(Player player)
        {
            
            if (player.Hp > 0)
            {
                alive = true;
                //return true;
            }
            else if (player.Hp <= 0)
            {
                alive = false;
                Console.WriteLine($"{player.Name} has died! You lose...");
                return false;
            }
            return true;
        }

        public bool CheckEnemyHp(Enemy enemy)
        {
            if (enemy.Hp > 0)
            {
                alive = true;
                //return true;
            }
            else if (enemy.Hp <= 0)
            {
                alive = false;
                Console.WriteLine($"{enemy.Name} has died! You win!");
                return false;
            }
            return true;

        }
    }
}
