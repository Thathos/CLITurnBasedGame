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


        public bool BeginBattle(bool alive)
        {
            while (alive) //while the player is alive
            {
                bool success = ProcessPlayerTurn(); //process the player's turn
                if (!success)
                {
                    continue;
                }
                bool isEnemyAlive = CheckEnemyHp(); //check the enemies' hp with a boolean variable
                if (!isEnemyAlive) //if the enemy is not alive break out of the loop to move on to the next enemy
                {
                    break;
                }
                ProcessEnemyTurn(); //process the player's turn
                bool isPlayerAlive = CheckPlayerHp(); //check the player's hp with a boolean variable
                if (!isPlayerAlive) //if the player is not alive, return false
                {
                    return false;
                }
            }
            return true;
        }

        public bool ProcessPlayerTurn() //1 to attack 2 to heal
        {
            try
            {
                Console.WriteLine("What is your choice?");

                int playerChoice = int.Parse(Console.ReadLine());
                if (playerChoice == 1)
                {
                    int attack = Player.AttackEnemy();
                    Enemy.Hp -= attack;
                    Console.WriteLine($"{Player.Name} deals {attack} damage to {Enemy.Name}!");
                    Console.WriteLine($"{Enemy.Name} has {Enemy.Hp} HP remaining!");
                    return true;
                }
                else if (playerChoice == 2)
                {
                    Player.UsePotion(Player);
                    Console.WriteLine($"{Player.Name} used a potion to restore their health!");
                    Console.WriteLine($"{Player.Hp}");
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

        public void ProcessEnemyTurn()
        {
            int attack = Enemy.AttackEnemy();
            Player.Hp -= attack;
            if (Player.Hp < 0)
            {
                Player.Hp = 0;
            }
            Console.WriteLine($"{Enemy.Name} deals {attack} damage to {Player.Name}!");
            Console.WriteLine($"{Player.Name} has {Player.Hp} HP remaining!");

        } //runs the attack method found in player and deducts hp from the player

        public bool CheckPlayerHp()
        {
            
            if (Player.Hp > 0)
            {
                //alive = true;
                //return true;
            }
            else if (Player.Hp == 0)
            {
                //alive = false;
                Console.WriteLine($"{Player.Name} has died! You lose...");
                return false;
            }
            return true;
        } //checks the player's hp and determines if they are alive or dead

        public bool CheckEnemyHp()
        {
            if (Enemy.Hp > 0)
            {
                //alive = true;
                //return true;
            }
            else if (Enemy.Hp <= 0)
            {
                //alive = false;
                Console.WriteLine($"{Enemy.Name} has died! You win!");
                return false;
            }
            return true;

        } //checks enemy hp and determines if they are alive or dead
    }
}
