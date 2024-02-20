using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Work
{
    public class Bird
    {
        public int Age { get; set; }

        public string Fly()
        {
            return (Age < 10) ? "flying" : "too old";
        }
    }

    public class Lizard
    {
        public int Age { get; set; }

        public string Crawl()
        {
            return (Age > 1) ? "crawling" : "too young";
        }
    }

    public class Dragon
    {
        private int age;
        private Bird bird = new Bird();
        private Lizard lizard = new Lizard();

        public int Age 
        { 
            get => age;
            set
            {
                age = bird.Age = lizard.Age = value;
            }
        }
        public Dragon(int age)
        {
            this.Age = age;
            bird.Age = age;
            lizard.Age = age;
        }


        public string Fly() => bird.Fly();

        public string Crawl() => lizard.Crawl();
    }
}
