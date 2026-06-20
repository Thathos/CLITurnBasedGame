using System;

namespace TurnBasedGame
{
    internal class Program
    {
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

            bool alive = true;

            Player player1 = new Player(1, "Reggie"); //hard coded player stuff, will change 

            for (int i = 0; i < enemyArray.Length; i++) //for loop to handle progression
            {

                Enemy newEnemy = enemyArray[i]; //the enemy selected is the enemy from the array based on index

                Battle battle = new Battle(player1, newEnemy); //player and enemy sent to battle

                Console.WriteLine($"Beginning battle with {player1.Name} and {newEnemy.Name}"); 

               battle.BeginBattle(player1, newEnemy, alive); //begins battle
            }
            
        }
    }
}
