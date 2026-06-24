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
            bool playAgain = true;

            while (playAgain)
            {

                Enemy[] enemyArray = [ //prefilled array with Enemy objects
                new Enemy (7,  "Skeleton"),
                new Enemy (13,  "Orc"),
                new Enemy (19,  "Human Warrior")
                ];

                bool alive = true; //boolean variable to check if player is alive

                Player player1 = new Player(10, "Reggie"); //hard coded player stuff, will change 



                for (int i = 0; i < enemyArray.Length; i++) //for loop to handle progression
                {

                    Enemy newEnemy = enemyArray[i]; //the enemy selected is the enemy from the array based on index

                    Battle battle = new Battle(player1, newEnemy); //player and enemy sent to battle

                    Console.WriteLine($"Beginning battle with {player1.Name} and {newEnemy.Name}");

                    bool isAlive = battle.BeginBattle(); //begins battle with boolean variable to check if player is alive

                    if (!isAlive) //if the player is not alive exit the loop and end the game
                    {
                        break;
                    }
                }
                Console.WriteLine("1 to play again. 2 to exit application.");

                string? input = Console.ReadLine();
                if (!int.TryParse(input, out int userChoice) || userChoice != 1)
                {
                    break;
                }
            }
        }
    }
}
