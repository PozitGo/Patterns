using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
   public class GameTemplate
    {
        public static void Run(Action start, Action takeTurn, Func<bool> haveWinner, Func<int> winningPlayer)
        {
            start();

            while (!haveWinner())
            {
                takeTurn();
            }

            Console.WriteLine($"Player {winningPlayer()} wins.");
        }
    }
}
