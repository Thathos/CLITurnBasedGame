namespace TurnBasedGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player(10, 0, "Reggie");
            Enemy enemy = new Enemy(10, 7, "Goblin");

            Battle battle = new Battle(player1, enemy);

            battle.BeginBattle(player1, enemy);
        }
    }
}
