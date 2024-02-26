using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    //Описывание скелета алгоритма, пример основа для любой игры
    public abstract class Game
    {
        protected readonly int numberOfPlayers;
        protected abstract bool IHaveWinner { get;  }
        protected abstract int WinningPlayer { get;  }
        protected int CurrentPlayer { get; set; }

        protected Game(int numberOfPlayers)
        {
            this.numberOfPlayers = numberOfPlayers;
        }
        protected abstract void Start();
        protected abstract void TakeTurn();
        public void Run()
        {
            this.Start();

            while (!this.IHaveWinner) 
            {
                this.TakeTurn();
            }

            Console.WriteLine($"Player {this.WinningPlayer} wins!");
        }
    }

    public class Chess : Game
    {

        protected override bool IHaveWinner => Turn == maxTurn;
        protected override int WinningPlayer => CurrentPlayer;
        private int Turn = 1, maxTurn = 10;

        public Chess() : base(2)
        {
        }

        protected override void Start()
        {
            Console.WriteLine($"Start a game of chess with {base.numberOfPlayers}");
        }

        protected override void TakeTurn()
        {
            Console.WriteLine($"Turn {Turn++} taken by player {CurrentPlayer}.");
            CurrentPlayer = (CurrentPlayer + 1) % numberOfPlayers;
        }
    }
}
