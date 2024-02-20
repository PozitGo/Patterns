using Coding.Exercise;
using DesignPatterns;

namespace Builder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var builder = HtmlElement.Create("ul");
            //builder.AddChiled("li", "Hello").AddChiled("li", "world");
            //var Element = builder.Build();

            //HtmlElement Element = HtmlElement.Create("ul").AddChiled("li", "hello");

            //Console.WriteLine(Element);


            //var PersonBuilder = new PersonBuilder();

            ////3 строителя
            //Person person = PersonBuilder.Lives.At("123 London Road").In("London").WithPostcode("SW122BC")
            //    .Works.At("Fabric").AsA("Engineer").Earning(123000);

            //Console.WriteLine(person);

            //var me = PersonGeneric.New.Called("Dmitri").WorksAsA("Quant").Born(DateTime.UtcNow).Build();
            //Console.WriteLine(me);

            //var b = new PersonFunctionalBuilder();

            //b.Called("Dima").WorksAsA("Developer").Build();

            var ms = new EmailService();

            ms.SendEmail(builder => builder.From("pozitgo2005@gmail.com").To("rostikushakov24@gmail.com").Body("test"));


            var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            Console.WriteLine(cb);
        }
    }
}
