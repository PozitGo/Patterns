namespace Decorator.Static
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var cb = new CodeBuilder();
            //cb.Append("class Foo\n").Append("{\n").Append("}\n");
            //Console.WriteLine(cb);

            //var Circle = new Circle(2);

            //Console.WriteLine(Circle.AsString);

            //var redCircle = new ColorShape(Circle, "Red");

            //Console.WriteLine(redCircle.AsString);

            //var redHTCircle = new TransparentShape(redCircle, 2);
            //Console.WriteLine(redHTCircle.AsString);


            ////Не даёт возможности указывать значения для базового типа и так же нельзя менять значению декоратору который находится поверх другого декоратора
            //var blueCircle = new ColorShape<Circle>("Black");
            //Console.WriteLine(blueCircle.AsString);

            //var blackHalfSquare = new TransparentShape<ColorShape<Circle>>(2);
            //Console.WriteLine(blueCircle.AsString);

            //Если создать новый декоратор поверз другого придётся передавать объект чтобы сохранять старые данные
            //var Circle = new Circle(2);

            //var blueCircle = new ColorShape<Circle>("Black", Circle);
            //Console.WriteLine(blueCircle.AsString);

            //var blackHalfSquare = new TransparentShape<ColorShape<Circle>>(2, blueCircle);
            //Console.WriteLine(blackHalfSquare.AsString);

            //Adapter

            MyStringBuilder builder = "test"; // И строитель и сущность которая хранит текст одновременно 
            builder.ToString();
        }
    }
}
