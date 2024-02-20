namespace NullObject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var ba = new BankAccount(new NullLog());
            //ba.Deposit(100);
            //var log = NullObject.Dynamic.Null<ILog>.Instance;
            //var ba = new BankAccount(log);
            //ba.Deposit(100);
            //Console.WriteLine(ba);

            var account = new NullObject.Work.Account(new NullObject.Work.NullLog());
            account.SomeOperation();
        }
    }

}
