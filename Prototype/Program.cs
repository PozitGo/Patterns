namespace Prototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var john = new Person(
            //  new[] { "John", "Smith" },
            //  new Address("London Road", 123));

            //var jane = (Person)john.Clone();
            //jane.Address.HouseNumber = 321; // oops, John is now at 321

            //// this doesn't work
            ////var jane = john;

            //// but clone is typically shallow copy
            //jane.Names[0] = "Jane";

            //Console.WriteLine(john);
            //Console.WriteLine(jane);

            Prototype.CopyCtor.Person person = new(new[] { "fsdf" }, new Prototype.CopyCtor.Address("London", 123));

            Prototype.CopyCtor.Person personCopy = new CopyCtor.Person(person);
            personCopy.Address.HouseNumber = 22;
            Console.WriteLine(person);
            Console.WriteLine(personCopy);
        }
    }
}
