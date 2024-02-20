namespace Command
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var bank = new BankAccount(100);
            //var cmd =  new BankAccountCommand(bank, BankAccountCommand.Action.Withdraw, 1000);
            //cmd.Call();
            //Console.WriteLine(bank);

            //cmd.Undo();
            //Console.WriteLine(bank);

            //var ba = new BankAccount(0);

            //var cmdDeposit = new BankAccountCommand(ba, BankAccountCommand.Action.Deposit, 100);
            //var cmdWithdraw = new BankAccountCommand(ba, BankAccountCommand.Action.Withdraw, 10);

            //var composite = new CompositeBankAccountCommand(new[] { cmdDeposit, cmdWithdraw });

            //composite.Call();

            //Console.WriteLine(ba);
            //composite.Undo();

            var from = new BankAccount(100);
            var to = new BankAccount(0);

            var mtc = new MoneyTransferCommand(from, to, 100);
            mtc.Call();

            Console.WriteLine(from);
            Console.WriteLine(to);

            mtc.Undo();

            Console.WriteLine(from);
            Console.WriteLine(to);
        }
    }
}
