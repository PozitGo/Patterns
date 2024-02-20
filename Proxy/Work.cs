using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public interface IPerson
    {

        string Drink();
        string DrinkAndDrive();
        string Drive();
    }

    public class Person : IPerson
    {
        public int Age { get; set; }

        public string Drink()
        {
            return "drinking";
        }

        public string Drive()
        {
            return "driving";
        }

        public string DrinkAndDrive()
        {
            return "driving while drunk";
        }
    }

    public class ResponsiblePerson : IPerson
    {
        private readonly Person Person;
        public int Age { get => Person.Age; set => Person.Age = value; }

        public ResponsiblePerson(Person person)
        {
            this.Person = person;
        }

        public string Drink() => Age >= 18 ? this.Person.Drink() : "too young";

        public string DrinkAndDrive() => "dead";

        public string Drive() => Age >= 16 ? this.Person.Drive() : "too young";
    }
}
