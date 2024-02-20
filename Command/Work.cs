using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class Command
    {
        public enum Action
        {
            Deposit,
            Withdraw
        }

        public Action TheAction;
        public int Amount;
        public bool Success;
    }

    public class Account
    {
        public int Balance { get; set; }

        public void Process(Command c)
        {
            switch (c.TheAction)
            {
                case Command.Action.Deposit:
                    Balance += c.Amount;
                    Console.WriteLine($"Пополнено {c.Amount}");
                    c.Success = true;
                    break;
                case Command.Action.Withdraw:
                    if(c.Amount <= Balance)
                    {
                        Balance -= c.Amount;
                        Console.WriteLine($"Снято {c.Amount}");
                        c.Success = true;
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно средств");
                        c.Success = false;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
