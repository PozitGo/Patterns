using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{

    public interface ICreature
    {
        int Age { get; set; }
    }

    public interface IBird : ICreature
    {
        void Fly();
    }

    public class Bird : IBird
    {
        public int Age { get; set; }
        public void Fly()
        {
            if (Age >= 10)
            {
                Console.WriteLine("I am flying!");
            }
        }
    }

    public interface ILizard : ICreature
    {
        void Crawl();
    }

    public class Lizard : ILizard
    {
        public int Age { get; set; }

        public void Crawl()
        {
            if (Age < 10)
            {
                Console.WriteLine("I am crawling");
            }
        }
    }

    public class Dragon : ILizard, IBird
    {
        private readonly IBird bird;
        private readonly ILizard lizard;
        public int Age
        {
            //Говнище потому что свойства не синхронизуются при возврате           
            get => bird.Age;
            set => bird.Age = lizard.Age = value;
        }

        public Dragon(IBird bird, ILizard lizard)
        {
            this.bird = bird;
            this.lizard = lizard;
        }

        public void Crawl()
        {
            lizard.Crawl();
        }

        public void Fly()
        {
            bird.Fly();
        }

        public void BreatheFire()
        {
            Console.WriteLine("Дышу огнём вам пизда");
        }
    }
}
