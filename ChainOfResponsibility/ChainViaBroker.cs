namespace ChainOfResponsibility.Broker
{
    public enum Argument
    {
        Attack, Defense
    }

    //CQS (CQRS)
    public class Query
    {
        public string CreatureName;
        public Argument WhatToQuery;
        public int Value;

        public Query(string CreatureName, Argument WhatToQuery, int Value)
        {
            this.CreatureName = CreatureName;
            this.WhatToQuery = WhatToQuery;
            this.Value = Value;
        }

    }
    public class Game
    {
        public event EventHandler<Query>? Queries;
        public void PerformQuery(object sender, Query query)
        {
            Queries?.Invoke(sender, query);
        }
    }

    public class Creature
    {
        private readonly Game game;
        public string Name;
        private int attack, defense;

        public int Attack
        {
            get
            {
                var q = new Query(Name, Argument.Attack, attack);
                game.PerformQuery(this, q);
                return q.Value;
            }
        }

        public int Defense
        {
            get
            {
                var q = new Query(Name, Argument.Defense, defense);
                game.PerformQuery(this, q);
                return q.Value;
            }
        }
        public Creature(Game game, string Name, int Attack, int Defense)
        {
            this.Name = Name;
            this.attack = Attack;
            this.defense = Defense;
            this.game = game;
        }


        public override string ToString() => $"{nameof(this.Name)}: {this.Name}, {nameof(this.Attack)}: {this.Attack}, {nameof(this.Defense)}: {this.Defense}";
    }

    public abstract class CreatureModifier : IDisposable
    {
        protected Game game;
        protected Creature creature;

        public CreatureModifier(Game game, Creature creature)
        {
            this.game = game;
            this.creature = creature;
            game.Queries += Handle;
        }

        protected abstract void Handle(object? sender, Query q);
        public void Dispose()
        {
            game.Queries -= Handle;
        }
    }

    public class DoubleAttackModifier : CreatureModifier
    {
        public DoubleAttackModifier(Game game, Creature creature) : base(game, creature)
        {

        }

        protected override void Handle(object? sender, Query q)
        {
            if(q.CreatureName == creature.Name && q.WhatToQuery == Argument.Attack)
            {
               q.Value *= 2;
            }
        }
    }

    public class IncreaseDefenseModifier : CreatureModifier
    {
        public IncreaseDefenseModifier(Game game, Creature creature) : base(game, creature)
        {

        }

        protected override void Handle(object? sender, Query q)
        {
            if (q.CreatureName == creature.Name && q.WhatToQuery == Argument.Defense)
            {
                q.Value += 2;
            }
        }
    }
}
