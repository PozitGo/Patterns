using System.Runtime.InteropServices.JavaScript;

namespace Builder
{
    public class PersonFunctional
    {
        public string? Name, Position;
    }

    public abstract class FunctionalBuilder<TSubject, TSelf> where TSelf : FunctionalBuilder<TSubject, TSelf> where TSubject : new()
    {
        private readonly List<Func<TSubject, TSubject>> Actions = new List<Func<TSubject, TSubject>>();

        public TSelf Do(Action<TSubject> action) => AddAction(action);

        private TSelf AddAction(Action<TSubject> action)
        {
            Actions.Add(p =>
            {
                action(p);
                return p;
            });

            return (TSelf)this;
        }


        public TSubject Build() => Actions.Aggregate(new TSubject(), (p, f) => f(p));
    }

    public sealed class PersonFunctionalBuilder : FunctionalBuilder<PersonFunctional, PersonFunctionalBuilder>
    {
        public PersonFunctionalBuilder Called(string Name) => Do(p => p.Name = Name);
    }


    //Расширение функционала без нарушения принципа открытости закрытости
    public static class PersonBuilderExtensions
    {
        public static PersonFunctionalBuilder WorksAsA(this PersonFunctionalBuilder builder, string Position)
        {
            builder.Do(p => p.Position = Position);
            return builder;
        }
    }

}
