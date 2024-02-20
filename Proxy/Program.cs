namespace Proxy
{
    internal class Program
    {

        //public static void DrawImage(Bitmap bmp)
        //{
        //    Console.WriteLine("About to draw image");
        //    bmp.Draw();
        //    Console.WriteLine("Done drawing image");
        //}

        public static void DrawImage(IBitmap bmp)
        {
            Console.WriteLine("About to draw image");
            bmp.Draw();
            Console.WriteLine("Done drawing image");
        }
        static void Main(string[] args)
        {
            //var car = new Car();
            //car.Drive();


            ////Паттерн прокси
            //var carProxe = new CarProxy(new Driver(18));
            //carProxe.Drive();

            //DrawImage(new Bitmap("Text"));

            //DrawImage(new LazyBitmap("Text"));

            //var c = new Creature();

            //c.Agility = 12;
            //int n = c.Agility;

            //Console.WriteLine(10m * 5.Persent());
            //Console.WriteLine(2.Persent() + 3m.Persent());

            //Age Age Age Age Age
            //X X X X X X
            //Y Y Y Y Y Y

            //var creatures = new BadCreature[100];

            //foreach (var creature in creatures)
            //{
            //    creature.X++; // Не эффективно 
            //}

            ////Новая версия

            //var creatures2 = new Creatures(100);

            //foreach (var creature in creatures2.GetEnumerator())
            //{
            //    creature.X++;
            //}

            //Логгирование

            ////Раньше
            //var ba = new BankAccount();
            //ba.Deposit(100);
            //ba.Withdraw(50);

            //Сейчас
            dynamic ba = Log<BankAccount>.As<IBankAccount>();

            ba.Deposit(100);
            ba.Withdraw(50);

            Console.WriteLine(ba);
        }
    }
}
