namespace Factory
{
    public interface IAsyncInit<T>
    {
        Task<T> InitAsync();    
    }

    public class Foo: IAsyncInit<Foo>
    {
        public Foo()
        {

        }

        public async Task<Foo> InitAsync()
        {
            await Task.Delay(1000);
            return this;
        }

        //Фабричный метод для асинхронного создания и инициализации объекта
        public async static Task<Foo> CreateAsync() => await new Foo().InitAsync();

    }

    public static class AsyncFactory
    {
        public static async Task<T> CreateAsync<T>() where T : IAsyncInit<T>, new() => await new T().InitAsync();
    }
}
