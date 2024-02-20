namespace Memento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount(0);
            var m1 = account.Deposit(100);
            var m2 = account.Deposit(50);
            Console.WriteLine(account);


            account.Undo();
            Console.WriteLine($"Undo1: {account}");
            account.Undo();
            Console.WriteLine($"Undo2: {account}");
            account.Redo();
            Console.WriteLine($"Redo: {account}");
        }
    }
}
