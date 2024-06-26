﻿using ImpromptuInterface;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject.Dynamic
{
    public class BankAccount
    {
        private ILog log;
        private int balance;

        public BankAccount(ILog log = null)
        {
            
            this.log = log;
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

    //Универсальный класс которых подходят для любого интерфейса, интерфейс указывается во время вызова этого класса
    public class Null<T> : DynamicObject where T : class
    {
        //ImpromptuInterface
        //ILog

        public static T Instance
        {
            get
            {
                if(!typeof(T).IsInterface)
                {
                    throw new ArgumentException("Must be interface!");
                }

                return new Null<T>().ActLike<T>();
            }
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object?[]? args, out object? result)
        {
            result = Activator.CreateInstance(binder.ReturnType);
            return true;
        }
    }
}
