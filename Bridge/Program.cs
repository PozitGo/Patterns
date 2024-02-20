using Autofac;
using Bridge.Work;

namespace Bridge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var raster = new RasterRenderer();
            //var vector = new VectorRenderer();

            //var circle = new Circle(vector, 20);

            //circle.Draw();
            //circle.Resize(2);
            //circle.Draw();


            //Использование DJ Autofac
            //var cb = new ContainerBuilder();

            //cb.RegisterType<VectorRenderer>().As<IRenderer>();
            //cb.Register((c, p) => new Circle(
            //    c.Resolve<IRenderer>(),
            //    p.Positional<float>(0)
            //));

            //using (var r = cb.Build())
            //{
            //    var circle = r.Resolve<Circle>(new PositionalParameter(0, 5.0f));
            //    circle.Draw();
            //    circle.Resize(2);
            //    circle.Draw();
            //}

            Console.WriteLine(new Triangle(new RasterRenderer()).ToString());
        }
    }
}
