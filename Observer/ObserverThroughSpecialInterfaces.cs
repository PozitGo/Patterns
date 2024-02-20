namespace Observer.Observer
{
    public class Event
    {

    }

    public class FallsIllEvent : Event
    {
        public string Address;

        public FallsIllEvent(string Address)
        {
            this.Address = Address;
        }
    }

    public class Person : IObservable<Event>
    {
        private readonly HashSet<Subscription> subscriptions = new();
        public IDisposable Subscribe(IObserver<Event> observer)
        {
            var sub = new Subscription(this, observer);
            subscriptions.Add(sub);
            return sub;
        }

        public void CatchACold()
        {
            foreach (var subscription in subscriptions)
            {
                subscription.Observer.OnNext(new FallsIllEvent("123 London Road"));
            }
        }

        private class Subscription : IDisposable
        {
            private Person person;
            public IObserver<Event> Observer;

            public Subscription(Person peron, IObserver<Event> observer)
            {
                this.person = peron;
                this.Observer = observer;
            }

            public void Dispose()
            {
                person.subscriptions.Remove(this);
            }
        }
    }
}
