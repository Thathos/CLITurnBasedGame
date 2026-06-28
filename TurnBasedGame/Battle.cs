using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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

        public Battle(Player player, Enemy enemy)
        {
            Player = player;
            Enemy = enemy;

        }


        public bool BeginBattle()
        {
            while (true) //while the player is alive
            {
                bool success = ProcessPlayerTurn(); //process the player's turn
                if (!success)
                {
                    continue;
                }
                bool isEnemyAlive = Enemy.IsAlive(); //check the enemies' hp with a boolean variable
                if (!isEnemyAlive) //if the enemy is not alive break out of the loop to move on to the next enemy
                {
                    Console.WriteLine($"{Enemy.Name} has died!");
                    break;
                }
                ProcessEnemyTurn(); //process the player's turn
                bool isPlayerAlive = Player.IsAlive(); //check the player's hp with a boolean variable
                if (!isPlayerAlive) //if the player is not alive, return false
                {
                    Console.WriteLine($"{Player.Name} has died. You lose...");
                    return false;
                }
            }
            return true;
        }

        public bool ProcessPlayerTurn()
        {
            //Console.WriteLine("What is your choice? 1 for attack 2 for potion");
            Player.Menu();
            string? input = Console.ReadLine(); //attempt to convert the string input to an int. If successful carry out the operation
            if (!int.TryParse(input, out int playerChoice))
            {
                Console.WriteLine("Please enter a valid selection");
                return false;
            }
            else if (playerChoice == 1) //attack enemy
            {
                int attack = Player.AttackEnemy();
                Enemy.DeductHealth(attack);
                Console.WriteLine($"{Player.Name} deals {attack} damage to {Enemy.Name}!");
                Console.WriteLine($"{Enemy.Name} has {Enemy.Hp} HP remaining!");
                return true;
            }
            else if (playerChoice == 2) //heal
            {
                Player.UsePotion();
                Console.WriteLine($"{Player.Name} used a potion to restore their health!");
                Console.WriteLine($"{Player.Name} has {Player.Hp} remaining!.");
                return true;
            }
            else if (playerChoice == 3)
            {
                while (true)
                {
                    bool spellSuccess = Player.DeductMana();
                    if (!spellSuccess)
                    {
                        Console.WriteLine("Not enough mana!");
                        break;
                    }
                    else
                    {
                        int attack = Player.SpecialAttack(Player);
                        Enemy.DeductHealth(attack);
                        Console.WriteLine($"{Player.Name} deals {attack} damage!");
                        Console.WriteLine($"{Enemy.Name} has {Enemy.Hp} health remaining!");
                    }
                    return true;
                }
            }
            else if (playerChoice == 4)
            {
                Player.UseManaPotion();
                Console.WriteLine($"{Player.Name} restores 10 mana! {Player.Name} has {Player.Mana} mana remaining!");
                return true;
            }
            else //reject any other input
            {
                Console.WriteLine("Please enter a valid selection");
                return false;
            }
            return false;
        }

        public void ProcessEnemyTurn() //process the player turn. right now its only attack
        {
            int attack = Enemy.AttackEnemy();
            Player.DeductHealth(attack);
            if (Player.Hp < 0)
            {
                Player.Hp = 0;
            }
            Console.WriteLine($"{Enemy.Name} deals {attack} damage to {Player.Name}!");
            Console.WriteLine($"{Player.Name} has {Player.Hp} HP remaining!");

        }
    }
}
