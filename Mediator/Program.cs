using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Mediator.Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //GroupChat
            //var room = new ChatRoom();

            //var John = new Person("John");
            //var Jane = new Person("Jane");


            //room.Join(John);
            //room.Join(Jane);

            //John.Say("Hi, room");
            //Jane.Say("Oh, hey john");

            //var Simon = new Person("Simon");
            //room.Join(Simon);

            //Simon.Say("Hi, everyone");

            //Jane.PrivateMessage("Simon", "Glad you cloud join us");

            ////EventBroker
            //var game = new Game();
            //var player = new Player("Sam", game);
            //var coach = new Coach(game);

            //player.Score();
            //player.Score();
            //player.Score();

            //ReactiveExtensions

            //var cb = new ContainerBuilder();
            //cb.RegisterType<EventBroker>().SingleInstance();
            //cb.RegisterType<Mediator.ReactiveExtensions.Player>().AsSelf();
            //cb.Register<Func<string, Player>>(c => {
            //    var context = c.Resolve<IComponentContext>();
            //    return name => context.Resolve<Player>(new NamedParameter("Name", name));
            //});
            //cb.RegisterType<Mediator.ReactiveExtensions.Coach>();

            //using var container = cb.Build();

            //var playerFactory = container.Resolve<Func<string, Mediator.ReactiveExtensions.Player>>();
            //var player = playerFactory("John");

            //var coach = container.Resolve<Mediator.ReactiveExtensions.Coach>();

            //player.Score();
            //player.Score();
            //player.Score();
            //player.Score();
            //player.Score();
            //player.Score();
            //    IRequestHandler<PingCommand, PongResponse> handler = new PingCommandHandler();

            //    // Создание экземпляра Mediator напрямую
            //    var mediator = new MediatR.Mediator(type =>
            //    {
            //        // Фабрика для создания обработчиков
            //        if (type == typeof(IRequestHandler<PingCommand, PongResponse>))
            //            return handler;

            //        throw new ArgumentException("Неизвестный тип", nameof(type));
            //    });

            //    // Отправка команды
            //    var response = mediator.Send(new PingCommand());

            //    Console.WriteLine($"We got a pong at {response.GetAwaiter().GetResult().Timestamp}");

            //Work
            var mediator = new Mediator();

            var participant1 = new Participant(mediator);
            var participant2 = new Participant(mediator);

            participant1.Say(3);
            Console.WriteLine($"Participant1: {participant1.Value}, Participant2: {participant2.Value}");

            participant2.Say(2);
            Console.WriteLine($"Participant1: {participant1.Value}, Participant2: {participant2.Value}");
        }

    }
}
