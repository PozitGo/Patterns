using static ChainOfResponsibility.Creature;

namespace ChainOfResponsibility
{
    public class Creature
    {
        public string? Name;
        public int Attack, Defense;

        public Creature(string? Name, int Attack, int Defense)
        {
            this.Name = Name;
            this.Attack = Attack;
            this.Defense = Defense;
        }

        public override string ToString() => $"{nameof(this.Name)}: {this.Name}, {nameof(this.Attack)}: {this.Attack}, {nameof(this.Defense)}: {this.Defense}";

        public class CreatureModifier
        {
            protected Creature? creature;
            //Singly Linked List
            protected CreatureModifier? next;

            public CreatureModifier(Creature creature)
            {
                this.creature = creature;
            }

            public void Add(CreatureModifier creatureModifier)
            {
                if (next != null)
                {
                    next.Add(creatureModifier);
                }
                else
                {
                    next = creatureModifier;
                }
            }

            public virtual void Handle() => next?.Handle();
        }
    }

    public class DoubleAttackModifier : CreatureModifier
    {
        public DoubleAttackModifier(Creature creature) : base(creature) 
        {
            
        }

        public override void Handle()
        {
            if(creature != null)
            {
                Console.WriteLine($"Doubling {creature?.Name}'s attack");
                creature!.Attack *= 2;

                base.Handle();
            }
        }
    }

    public class IncreaseDefenseModifier : CreatureModifier
    {
        public IncreaseDefenseModifier(Creature creature) : base(creature)
        {

        }

        public override void Handle()
        {
            if (creature != null)
            {
                if(creature.Attack <= 2)
                {
                    Console.WriteLine($"Increasing {creature?.Name}'s defense");
                    creature!.Defense++;
                }

                base.Handle();
            }
        }
    }

    //Отрезает обработку следующих добавлений мофикаций путём того что не выполняется вызов base.Handle(), и вызов этого класса находится выше остальных
    public class NoBonusesModifier : CreatureModifier
    {
        public NoBonusesModifier(Creature creature) : base(creature)
        {

        }

        public override void Handle()
        {
            return;
        }
    }
}
