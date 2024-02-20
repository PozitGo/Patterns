using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    public class Memento
    {
        public int Balance { get; set; }

        public Memento(int Balance)
        {
            this.Balance = Balance;
        }
    }

    public class BankAccount
    {
        private int balance;
        private List<Memento> Changes;
        private int Current;
        public BankAccount(int balance)
        {
            Changes = new List<Memento>();
            this.Changes.Add(new Memento(this.balance = balance));
        }
        public void Restore(Memento memento)
        {
            if(memento != null)
            {
                this.balance = memento.Balance;
                this.Changes.Add(memento);
                this.Current = Changes.Count - 1;
            }
        }

        public Memento? Undo()
        {
            if(Current > 0)
            {
                var m = Changes[--Current];
                balance = m.Balance;
                return m;
            }

            return null;
        }
        public Memento? Redo()
        {
            if(Current + 1 < Changes.Count)
            {
                var m = Changes[++Current];
                balance = m.Balance;
                return m;
            }

            return null;
        }
        public Memento Deposit(int amount)
        {
            var m = new Memento(this.balance += amount);
            this.Changes.Add(m);
            this.Current++;
            return m;
        }

        public override string ToString() => $"{nameof(this.balance)}: {this.balance}";
    }

}
