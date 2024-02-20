using ChainOfResponsibility.Broker;
using ChainOfResponsibility.Work;

namespace ChainOfResponsibility
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var goblin = new Creature("Goblin", 1, 1);
            //Console.WriteLine(goblin);

            //var root = new Creature.CreatureModifier(goblin);
            //root.Add(new NoBonusesModifier(goblin));
            //root.Add(new DoubleAttackModifier(goblin));
            //root.Add(new IncreaseDefenseModifier(goblin));
            //root.Add(new DoubleAttackModifier(goblin));

            //root.Handle();
            //Console.WriteLine(goblin);

            //var game = new Game();

            //var goblin = new ChainOfResponsibility.Broker.Creature(game, "String Goblin", 2, 2);
            //Console.WriteLine(goblin);

            //using (new ChainOfResponsibility.Broker.DoubleAttackModifier(game, goblin))
            //{
            //    Console.WriteLine(goblin);

            //    using (new ChainOfResponsibility.Broker.IncreaseDefenseModifier(game, goblin))
            //    {
            //        Console.WriteLine(goblin);
            //    }
            //}

            //Console.WriteLine(goblin);

            var game = new ChainOfResponsibility.Work.Game();
            game.Creatures.Add(new Goblin(game));
        }
    }
}
