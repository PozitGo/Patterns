namespace Singleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(SingletonDataBase.Instance.GetPopulation("Tokyo"));

            var primary = Printer.Get(SubSystem.Main);
            var backup = Printer.Get(SubSystem.Backup);
        }
    }
}
