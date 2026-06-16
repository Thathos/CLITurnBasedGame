namespace TurnBasedGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player(10, 2, "Reggie");
            Enemy enemy = new Enemy(10, 3, "Goblin");

            Battle battle = new Battle(player1, enemy);

            battle.BeginBattle(player1, enemy);
        }
    }
}
