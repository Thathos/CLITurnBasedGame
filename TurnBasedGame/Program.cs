using System;

namespace TurnBasedGame
{
    internal class Program
    {
        //Fix mana in character class

        //items for player
        //classes for player

        //if i add player classes (mage, warrior) where do those attributes live in the program?

        //critical hits for player and enemy
        static void Main(string[] args)
        {
            Enemy[] enemyArray = [ //prefilled array with Enemy objects
                new Enemy (7,  "Skeleton", 10),
                new Enemy (13,  "Orc", 10),
                new Enemy (19,  "Human Warrior", 10)
            ];

            Player player1 = null;
            Console.WriteLine("Please enter your name.");
            string? name = Console.ReadLine();
            Console.WriteLine("Please enter your class.");
            string? classType = Console.ReadLine();
            if (!int.TryParse(classType, out int userClass){
                Console.WriteLine("Please enter a valid option");
                
            }
            else if (userClass == 1)
            {
                Console.WriteLine("You chose mage.");
                player1 = new Mage(10, name, 10);
            }

            bool playAgain = true;

            while (playAgain)
            {


                //Player player1 = new Mage(10, "Reggie", 10); //hard coded player stuff, will change 

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
