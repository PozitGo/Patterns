using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Observer.Observer3
{
    public class PropertyNotificationSupport : INotifyPropertyChanged, INotifyPropertyChanging
    {
        public event PropertyChangingEventHandler? PropertyChanging;
        public event PropertyChangedEventHandler? PropertyChanged;

        private readonly Dictionary<string, HashSet<string>> affectedBy = new Dictionary<string, HashSet<string>>();

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            foreach (var affected in affectedBy.Keys)
            {
                if (affectedBy[affected].Contains(propertyName))
                {
                    OnPropertyChanged(affected);
                }
            }
        }

        protected virtual void OnPropertyChanging([CallerMemberName] string propertyName = null)
        {
            PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
        }

        protected bool SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;

            OnPropertyChanging(propertyName);
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected Func<T> property<T>(string name, Expression<Func<T>> expr)
        {
            Console.WriteLine($"Creating computed property for expression {expr}");

            var visitor = new MemberAccessVisitor(GetType());
            visitor.Visit(expr);

            if (visitor.PropertyNames.Any())
            {
                if (!affectedBy.ContainsKey(name))
                {
                    affectedBy.Add(name, new HashSet<string>());
                }

                foreach (var propName in visitor.PropertyNames)
                {
                    if (propName != name)
                    {
                        affectedBy[name].Add(propName);
                    }
                }
            }

            return expr.Compile();
        }

        private class MemberAccessVisitor : ExpressionVisitor
        {
            private readonly Type declaringType;
            public readonly IList<string> PropertyNames = new List<string>();

            public MemberAccessVisitor(Type declaringType)
            {
                this.declaringType = declaringType;
            }

            public override Expression Visit(Expression expr)
            {
                if (expr != null && expr.NodeType == ExpressionType.MemberAccess)
                {
                    var memberExpr = (MemberExpression)expr;
                    if (memberExpr.Member.DeclaringType == declaringType)
                    {
                        PropertyNames.Add(memberExpr.Member.Name);
                    }
                }

                return base.Visit(expr);
            }
        }
    }

    public class Person : PropertyNotificationSupport
    {
        private readonly Func<bool> canVote;

        private int age;
        private bool citizen;

        public bool Citizen
        {
            get => citizen;
            set => base.SetValue(ref citizen, value);
        }

        public int Age
        {
            get => age;
            set => base.SetValue(ref age, value);
        }
        public bool CanVote => canVote();

        public Person()
        {
            canVote = base.property(nameof(CanVote), () => Age >= 16 && Citizen);
        }

    }
}

