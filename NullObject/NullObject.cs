using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    public interface ILog
    {
        void Info(string msg);
        void Warn(string msg);
    }

    class ConsoleLog : ILog
    {
        public void Info(string msg)
        {
            Console.WriteLine(msg);
        }

        public void Warn(string msg)
        {
            Console.WriteLine("WARNING: " + msg);
        }
    }

    //Аналог класса nullLog только он используется сразу же со страховками а не пустые реализации
    class OptionalLog : ILog
    {
        private ILog impl;

        public OptionalLog(ILog impl)
        {
            this.impl = impl;
        }

        public void Info(string msg)
        {
            impl?.Info(msg);
        }

        public void Warn(string msg)
        {
            impl?.Warn(msg);
        }
    }


    public class BankAccount
    {
        private ILog log;
        private int balance;

        public BankAccount(ILog log = null)
        {
            //Безопасное использование логов через объект класса OptionalLog у которого есть поддержка null которой якобы нет в исходном коде
            this.log = new OptionalLog(log);
        }

        public void Deposit(int amount)
        {
            balance += amount;
            // check for null everywhere
            log?.Info($"Deposited ${amount}, balance is now {balance}");
        }

        public void Withdraw(int amount)
        {
            if (balance >= amount)
            {
                balance -= amount;
                log?.Info($"Withdrew ${amount}, we have ${balance} left");
            }
            else
            {
                log?.Warn($"Could not withdraw ${amount} because " +
                          $"balance is only ${balance}");
            }
        }
    }

    public sealed class NullLog : ILog
    {
        public void Info(string msg) { }
        public void Warn(string ms) { }
    }

}
