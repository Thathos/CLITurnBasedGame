using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        //public bool alive { get; set; } = true;

        public Battle(Player player, Enemy enemy)
        {
            Player = player;
            Enemy = enemy;
        }


        public bool BeginBattle(Player player, Enemy enemy, bool alive)
        {
            while (alive) //while the player is alive
            {
                bool success = ProcessPlayerTurn(player, enemy); //process the player's turn
                if (!success)
                {
                    continue;
                }
                bool isEnemyAlive = CheckEnemyHp(enemy); //check the enemies' hp with a boolean variable
                if (!isEnemyAlive) //if the enemy is not alive break out of the loop to move on to the next enemy
                {
                    break;
                }
                ProcessEnemyTurn(enemy, player); //process the player's turn
                bool isPlayerAlive = CheckPlayerHp(player); //check the player's hp with a boolean variable
                if (!isPlayerAlive) //if the player is not alive, return false
                {
                    return false;
                }
            }
            return true;
        }

        public bool ProcessPlayerTurn(Player player, Enemy enemy) //1 to attack 2 to heal
        {
            try
            {
                Console.WriteLine("What is your choice?");

                int playerChoice = int.Parse(Console.ReadLine());
                if (playerChoice == 1)
                {
                    int attack = player.AttackEnemy();
                    enemy.Hp -= attack;
                    Console.WriteLine($"{player.Name} deals {attack} damage to {enemy.Name}!");
                    Console.WriteLine($"{enemy.Name} has {enemy.Hp} HP remaining!");
                    return true;
                }
                else if (playerChoice == 2)
                {
                    player.UsePotion(player);
                    Console.WriteLine($"{player.Name} used a potion to restore their health!");
                    Console.WriteLine($"{player.Hp}");
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid choice, please enter 1 or 2.");
                    return false;
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Please use the number pad for your selection!");
                return false;
            }
        }

        public void ProcessEnemyTurn(Enemy enemy, Player player)
        {
            int attack = enemy.AttackEnemy();
            player.Hp -= attack;
            if (player.Hp < 0)
            {
                player.Hp = 0;
            }
            Console.WriteLine($"{enemy.Name} deals {attack} damage to {player.Name}!");
            Console.WriteLine($"{player.Name} has {player.Hp} HP remaining!");

        } //runs the attack method found in player and deducts hp from the player

        public bool CheckPlayerHp(Player player)
        {
            
            if (player.Hp > 0)
            {
                //alive = true;
                //return true;
            }
            else if (player.Hp == 0)
            {
                //alive = false;
                Console.WriteLine($"{player.Name} has died! You lose...");
                return false;
            }
            return true;
        } //checks the player's hp and determines if they are alive or dead

        public bool CheckEnemyHp(Enemy enemy)
        {
            if (enemy.Hp > 0)
            {
                //alive = true;
                //return true;
            }
            else if (enemy.Hp <= 0)
            {
                //alive = false;
                Console.WriteLine($"{enemy.Name} has died! You win!");
                return false;
            }
            return true;

        } //checks enemy hp and determines if they are alive or dead
    }
}
