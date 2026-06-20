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


        public bool BeginBattle(Player player, Enemy enemy, bool alive)
        {
            while (alive)
            {
                ProcessPlayerTurn(player, enemy);
                CheckEnemyHp(enemy, alive);
                ProcessEnemyTurn(enemy, player);
                CheckPlayerHp(player, alive);
                if (!alive)
                {
                    return false;
                }
            }
            return true;
        }

        public void ProcessPlayerTurn(Player player, Enemy enemy)
        {

            Console.WriteLine("What is your choice?");
            int playerChoice = int.Parse(Console.ReadLine());
            if (playerChoice == 1)
            {
                int attack = player.AttackEnemy();
                Enemy.Hp -= attack;
                Console.WriteLine($"{player.Name} deals {attack} damage to {enemy.Name}!");
                Console.WriteLine($"{enemy.Name} has {enemy.Hp} HP remaining!");

            }
            else if (playerChoice == 2)
            {
                Player.UsePotion(player);
                Console.WriteLine($"{Player.Name} used a potion to restore their health!");
                Console.WriteLine($"{Player.Hp}");
            }
        }

        public void ProcessEnemyTurn(Enemy enemy, Player player)
        {
            int attack = Player.AttackEnemy();
            Player.Hp -= attack;
            Console.WriteLine($"{enemy.Name} deals {attack} damage to {player.Name}!");
            Console.WriteLine($"{player.Name} has {player.Hp} HP remaining!");

        }

        public bool CheckPlayerHp(Player player, bool alive)
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

        public bool CheckEnemyHp(Enemy enemy, bool alive)
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
