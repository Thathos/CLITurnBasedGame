using System;

namespace TurnBasedGame
{
    internal class Program
    {
        //for progression system, when an enemy is defeated. choose another enemy in the array and multiply its stats

        //items for player
        //classes for player

        //if i add player classes (mage, warrior) where do those attributes live in the program?

        //critical hits for player and enemy
        static void Main(string[] args)
        {
            Enemy[] enemyArray = [ //prefilled array with Enemy objects
                new Enemy (6,  "Skeleton"),
                new Enemy (10,  "Orc"),
                new Enemy (18,  "Human Warrior")
            ];

            //Random random = new Random(); //rng to select enemy from enemyArray
            //int enemySelect = random.Next(0, 2);

            Player player1 = new Player(10, "Reggie"); //hard coded player stuff, will change 

            for (int i = 0; i < enemyArray.Length; i++) //for loop to handle progression
            {

                Enemy newEnemy = enemyArray[i]; //the enemy selected is the enemy from the array based on index

                Battle battle = new Battle(player1, newEnemy); //player and enemy sent to battle

                Console.WriteLine($"Beginning battle with {player1.Name} and {newEnemy.Name}"); //debug line

                battle.BeginBattle(player1, newEnemy); //begins battle
            }

            //randomize attack power for enemy and player
        }
    }
}
