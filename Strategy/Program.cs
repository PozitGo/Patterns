namespace Strategy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Динамическая реализация
            var tp = new TextProcessor();
            tp.SetOutputFormat(OutputFormat.Markdown);
            tp.AppendList(new[] { "foo", "bar", "bax" });
            Console.WriteLine(tp);
            tp.Clear();
            tp.SetOutputFormat(OutputFormat.Html);
            tp.AppendList(new[] { "foo", "bar", "bax" });
            Console.WriteLine(tp);


            //Статическая реализация
            var tp2 = new Static.TextProcessor<Static.MarkdownListStrategy>();
            tp2.AppendList(new[] { "foo", "bar", "bax" });
            Console.WriteLine(tp2);
            tp2.Clear();
        }
    }
}
