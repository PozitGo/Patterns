namespace TemplateMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var chess = new Chess();
            chess.Run();

            int numberOfPlayers = 2;
            int currentPlayer = 0;
            int turn = 0, maxTurn = 10;

            void Start()
            {
                Console.WriteLine($"Starting a game of chess with {numberOfPlayers} players.");
            }

            bool HaveWinner()
            {
                return turn == maxTurn;
            }

            void TakeTurn()
            {
                Console.WriteLine($"Turn {turn++} taken by player {currentPlayer}.");
                currentPlayer = (currentPlayer + 1) % numberOfPlayers;
            }

            int WinningPlayer()
            {
                return currentPlayer;
            }

            GameTemplate.Run(Start, TakeTurn, HaveWinner, WinningPlayer);
        }
    }
}
