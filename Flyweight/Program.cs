namespace Flyweight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var user = new User("Sam Smith");
            //var user2 = new User("Jane Smith");

            //var ft = new FormattedText("This is a brave new world");
            //ft.Capitalize(10, 15);
            //Console.WriteLine(ft);

            //var bft = new BetterFormattedText("This is a brave new world");
            //bft.GetRange(10, 15).Capitalize = true;
            //Console.WriteLine(bft);

            var sentence = new Sentence("hello world");
            sentence[1].Capitalize = true;
            Console.WriteLine(sentence);
        }
    }
}
