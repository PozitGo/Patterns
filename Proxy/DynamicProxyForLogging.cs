using ImpromptuInterface;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public interface IBankAccount
    {
        void Deposit(int amount);
        bool Withdraw(int amount);
        string ToString();
    }

    public class BankAccount : IBankAccount
    {
        private int balance;
        private int overdraftLimit = -500;

        public void Deposit(int amount)
        {
            balance += amount;
            Console.WriteLine($"Deposited ${amount}, balance is now {balance}");
        }

        public bool Withdraw(int amount)
        {
            if (balance - amount >= overdraftLimit)
            {
                balance -= amount;
                Console.WriteLine($"Withdrew ${amount}, balance is now {balance}");
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{nameof(balance)}: {balance}";
        }
    }

    public class Log<T> : DynamicObject where T : class, new()
    {
        private readonly T subject;
        private Dictionary<string, int> MethodCallCount = new Dictionary<string, int>();
        public string Info
        {
            get
            {
                var sb = new StringBuilder();
                foreach (var KeyValue in MethodCallCount)
                {
                    sb.AppendLine($"{KeyValue.Key} called {KeyValue.Value} time(-s)");
                }

                return sb.ToString();
            }
        }

        public Log(T subject)
        {
            this.subject = subject;
        }

        public static I As<I>() where I : class
        {
            if (!typeof(I).IsInterface)
            {
                throw new Exception("Not an interface");
            }
            else
            {
                return new Log<T>(new T()).ActLike<I>();
            }
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object?[]? args, out object? result)
        {
            try
            {
                //Выводим в консоль имя класса, метод и аргументы вызова
                Console.WriteLine($"Invoking {subject.GetType().Name}.{binder.Name} with args [{string.Join(", ", args != default ? args : "Аргументы отсутствуют")}]");

                if (MethodCallCount.ContainsKey(binder.Name))
                {
                    MethodCallCount[binder.Name]++;
                }
                else
                {
                    MethodCallCount.Add(binder.Name, 1);
                }

                // Вызываем перехваченный метод с переданными аргументами
                result = subject?.GetType().GetMethod(binder.Name)?.Invoke(subject, args);

                return true;
            }
            catch (Exception)
            {
                result = null;
                return false;
            }
        }

        public override string ToString() => $"{Info}{subject}";
    }
}
