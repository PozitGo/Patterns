namespace Mediator
{
    public abstract class GameEventArgs : EventArgs
    {
        public abstract void Print();
    }

    public class PlayerScoredEventArgs : GameEventArgs
    {
        public string PlayerName;
        public int GoalsScoredSoFar;

        public PlayerScoredEventArgs(string PlayerName, int GoalsScoredSoFar)
        {
            this.PlayerName = PlayerName;
            this.GoalsScoredSoFar = GoalsScoredSoFar;
        }
        public override void Print()
        {
            Console.WriteLine($"{PlayerName} has scored! (their {GoalsScoredSoFar} goal)");
        }
    }

    public class Game
    {
        #nullable disable
        public event EventHandler<GameEventArgs> Events;

        public void Fire(GameEventArgs args)
        {
            Events?.Invoke(this, args);
        }
    }

    public class Player
    {
        private string Name;
        private Game game;
        private int goalsScored = 0;

        public Player(string Name, Game game)
        {
            this.Name = Name;
            this.game = game;
        }

        public void Score()
        {
            goalsScored++;
            var args = new PlayerScoredEventArgs(Name, goalsScored);
            game.Fire(args);
        }
    }

    public class Coach
    {
        private Game game;

        public Coach(Game game)
        {
            this.game = game;
            game.Events += (sender, args) =>
            {
                if (args is PlayerScoredEventArgs scored && scored.GoalsScoredSoFar < 3)
                {
                    Console.WriteLine($"Coach says: well done, {scored.PlayerName}");
                }
            };
        }
    }
}
