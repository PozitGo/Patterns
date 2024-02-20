using static Factory.Point;

namespace Factory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var point = Point.Factory.NewPolarPoint(2, 3);

            //var foo = AsyncFactory.CreateAsync<Foo>();

            //var basicFactory = ShapeFactory.GetFactory(true).Create(Shape.Square);
            //var roundedFactory = ShapeFactory.GetFactory(false).Create(Shape.Square);

            var personDima = Person.Factory.Create("Dima");
            Console.WriteLine(personDima);
            var personAndry = Person.Factory.Create("Andry");
            Console.WriteLine(personAndry);
        }
    }
}
