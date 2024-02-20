using Autofac;
using Autofac.Features.Metadata;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using static Adapter.Button;

namespace Adapter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Adapter
            //Demo.DrawPoints();
            //Demo.DrawPoints();

            //SurrogateProperty
            //var stats = new CountryStats();
            //stats.Capitals.Add("France", "Paris");

            //var xs = new XmlSerializer(typeof(CountryStats));

            //var sb = new StringBuilder();
            //var sw = new StringWriter(sb);
            //xs.Serialize(sw, stats);
            //Console.WriteLine(sb);

            //var newStats = (CountryStats)xs.Deserialize(
            //    new StringReader(sb.ToString()))!;

            //Console.WriteLine(newStats.Capitals["France"]);


            ////DependencyInjection
            //var b = new ContainerBuilder();
            //b.RegisterType<OpenCommand>().As<ICommand>().WithMetadata("Name", "Open");
            //b.RegisterType<SaveCommand>().As<ICommand>().WithMetadata("Name", "Save");
            ////b.RegisterType<Button>();
            //b.RegisterAdapter<Meta<ICommand>, Button>(cmd => new Button(cmd.Value, (string)cmd.Metadata["Name"]!));
            //b.RegisterType<Editor>();

            //using var c = b.Build();

            //var editor = c.Resolve<Editor>();
            //editor.ClickAll();

            //foreach (var button in editor.Buttons)
            //{
            //    button.Click();
            //    button.PrintMe();
            //}

            ////AdapterForLiteralsOnGenerics
            //Vector3f af = new Vector3f();
            //Vector3f bf = new Vector3f();
            //Vector3i ai = new Vector3i();
            //Vector3i bi = new Vector3i();

            //var c = ai + bi;

            //Console.WriteLine(c.ToString());

            //var u = Vector3i.Create(1, 2, 3);
        }
    }
}
