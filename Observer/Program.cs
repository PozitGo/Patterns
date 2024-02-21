using Microsoft.Extensions.DependencyInjection;
using Observer.Observer5;
namespace Observer
{
    internal class Program /*: IObserver<Observer.Event>*/
    {

        //public Program()
        //{
        //    var person = new Observer.Person();
        //    var sub = person.Subscribe(this);
        //    //Аналогичный способ подписки без наследования и определения реализации интерфейса IObserver<Observer.Event>, вызов аналогичный OnNext
        //    person.OfType<FallsIllEvent>().Subscribe(args => Console.WriteLine($"We need a doctor to {args.Address}"));
        //    person.CatchACold();
        //}
        static void Main(string[] args)
        {
            //new Program();
            //var person = new Person();
            //person.FallsIll += PersonFallsIll;

            //person.CatchACold();
            //person.FallsIll -= PersonFallsIll;

            //var btn = new Button();
            ////var window = new Window(btn);
            //var window = new Window(btn);
            //var windowRef = new WeakReference(window);
            //btn.Fire();

            //Console.WriteLine("Setting window to null");
            //window = null;

            //FireGC();
            //Console.WriteLine($"Window alive? {windowRef.IsAlive}");

            //btn.Fire();

            //Console.WriteLine("Setting button to null");
            //btn = null;

            //FireGC();

            //Console.WriteLine($"Window alive? {windowRef.IsAlive}");

            //var person = new Observer3.Person 
            //{
            //    Age = 15
            //};
            //person.Citizen = true;
            //person.PropertyChanged += Person_PropertyChanged;
            //Console.WriteLine("Changing age:");
            //person.Age++;
            //Console.WriteLine("Changing citizenship");
            //person.Citizen = false;

            //var product = new Product
            //{
            //    Name = "Book"
            //};

            //var window = new Observer4.Window
            //{
            //    ProductName = "Book"
            //};

            //Синхронизация двух полей в разных объектах классах
            //product.PropertyChanged += (sender, e) =>
            //{
            //    if(e.PropertyName == "Name")
            //    {
            //        Console.WriteLine("Name change in product");
            //        window.ProductName = product.Name;
            //    }
            //};

            //window.PropertyChanged += (sender, e) =>
            //{
            //    if (e.PropertyName == "ProductName")
            //    {
            //        Console.WriteLine("Name change in window");
            //        product.Name = window.ProductName;
            //    }
            //};

            //using var binding = new BidirectionalBinding(product, () => product.Name, window, () => window.ProductName);
            //product.Name = "Table";
            //Console.WriteLine(product);
            //Console.WriteLine(window);

            var services = new ServiceCollection();
            ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();

            // Подписываем обработчики на отправители событий
            EventSubscriptionManager.SubscribeAll(serviceProvider);

            // Использование
            var button = serviceProvider.GetRequiredService<Observer5.Button>();
            button.Fire(1); // Должно вызвать обработчик в Logging и вывести сообщение в консоль
            button.Fire(2); // Аналогично, для второго нажатия

        }

        static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<Observer5.Button>();
            services.AddSingleton<Observer5.Logging>();

            services.AddSingleton<ISend<Observer5.ButtonPressedEvent>>(provider => provider.GetRequiredService<Observer5.Button>());
            services.AddSingleton<IHandle<Observer5.ButtonPressedEvent>>(provider => provider.GetRequiredService<Observer5.Logging>());
        }

        //private static void Person_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        //{
        //    var p = (Observer3.Person)sender;
        //    if(e.PropertyName == "CanVote")
        //    {
        //        Console.WriteLine($"Voting status changed {p.Age}");
        //    }
        //}

        //public void OnCompleted()
        //{

        //}

        //public void OnError(Exception error)
        //{

        //}

        //public void OnNext(Event value)
        //{
        //    if(value is FallsIllEvent args)
        //    {
        //        Console.WriteLine($"Call doctor to {args.Address}");
        //    }
        //}

        //public static void FireGC()
        //{
        //    Console.WriteLine("Starting GC");
        //    GC.Collect();
        //    GC.WaitForPendingFinalizers();
        //    GC.Collect();
        //    Console.WriteLine("GC is done!");
        //}

        //private static void PersonFallsIll(object? sender, FallsIllEventArgs e)
        //{
        //    Console.WriteLine($"Call a doctor to {e.Address}");
        //}
    }
}
