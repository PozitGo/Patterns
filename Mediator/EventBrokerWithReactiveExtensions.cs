using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using Autofac;

namespace Mediator.ReactiveExtensions
{
    //Event Broker
    //ReactiveExtensions

    public class EventBroker : IObservable<EventArgs>
    {
        private readonly List<Subsription> subscribers;
        public EventBroker()
        {
            this.subscribers = new List<Subsription>();
        }
        public IDisposable Subscribe(IObserver<EventArgs> observer)
        {
            var sub = new Subsription(this, observer);

            if(subscribers.All(s => s.Subscriber != observer))
            {
                subscribers.Add(sub);
            }

            return sub;

        }

        private void Unsubscribe(IObserver<EventArgs> subscriber)
        {
            subscribers.RemoveAll(s => s.Subscriber == subscriber);
        }

        public void Publish<T>(T args) where T : EventArgs
        {
            foreach (var s in subscribers.ToArray())
            {
                s.Subscriber.OnNext(args);
            }
        }

        private class Subsription : IDisposable
        {
            private readonly EventBroker broker;
            public IObserver<EventArgs> Subscriber { get; private set; }

            public Subsription(EventBroker broker, IObserver<EventArgs> observer)
            {
                this.broker = broker;
                this.Subscriber = observer;
            }
            public void Dispose()
            {
                broker.Unsubscribe(Subscriber);
            }
        }
    }

    public class PlayerScoredEventArgs : EventArgs
    {
        public string PlayerName;
        public int GoalsScoredSoFar;

        public PlayerScoredEventArgs(string PlayerName, int GoalsScoredSoFar)
        {
            this.PlayerName = PlayerName;
            this.GoalsScoredSoFar = GoalsScoredSoFar;
        }
    }

    public class Player
    {
        public string Name;
        private int goalsScored;
        private EventBroker broker;

        //public delegate Player Factory(string name); чет не работает

        public Player(string Name, EventBroker broker)
        {
            this.Name = Name;
            this.broker = broker;
        }

        public void Score()
        {
            goalsScored++;
            var args = new PlayerScoredEventArgs(Name, goalsScored);
            broker.Publish(args);
        }

    }

    public class Coach
    {
        private IDisposable subscription;

        public Coach(EventBroker broker)
        {
            subscription = broker.OfType<PlayerScoredEventArgs>().Skip(1).Take(3).Subscribe(args =>
                Console.WriteLine($"Well done, {args.PlayerName}! ({args.GoalsScoredSoFar} goals)"));
        }
    }
}
