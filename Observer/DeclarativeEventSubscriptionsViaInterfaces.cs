using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.Observer5
{
    // +=
    //[Published("foo")], [Subscribes("foo")]

    public interface IEvent
    {

    }

    public interface ISend<TEvent> where TEvent : IEvent
    {
        event EventHandler<TEvent> Sender;
    }

    public interface IHandle<TEvent> where TEvent : IEvent
    {
        void Handle(object sender, TEvent args);   
    }

    public class ButtonPressedEvent : IEvent
    {
        public int NumberOfClicks;
    }

    public class Button : ISend<ButtonPressedEvent>
    {
        #nullable disable
        public event EventHandler<ButtonPressedEvent> Sender;

        public void Fire(int clicks)
        {
            Sender?.Invoke(this, new ButtonPressedEvent
            {
                NumberOfClicks = clicks
            });
        }
    }

    public class Logging : IHandle<ButtonPressedEvent>
    {
        public void Handle(object sender, ButtonPressedEvent args)
        {
            Console.WriteLine($"Button clicked {args.NumberOfClicks} times");
        }
    }

    public class EventSubscriptionManager
    {
        public static void SubscribeAll(IServiceProvider serviceProvider)
        {
            var senders = serviceProvider.GetServices<ISend<ButtonPressedEvent>>().ToList();
            var handlers = serviceProvider.GetServices<IHandle<ButtonPressedEvent>>().ToList();

            foreach (var sender in senders)
            {
                foreach (var handler in handlers)
                {
                    if (sender != null)
                    {
                        sender.Sender += (EventHandler<ButtonPressedEvent>)Delegate.CreateDelegate(typeof(EventHandler<ButtonPressedEvent>), handler, "Handle");
                    }
                }
            }
        }
    }

}
