using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Observer.Observer4
{
   //binding TwoWay
   //data <-> UI

    public class Product : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;
        //Объект синхронизации
        #nullable disable
        private string name;

		public string Name
		{
			get => name;
            set
            {
                if (value != name)
                {
                    name = value;
                    this.OnPropertyChanged();
                }
            }
		}


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString() => $"Product: {this.Name}";
    }

    public class Window : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        //Объект синхронизации
        private string productName;

        public string ProductName
        {
            get => productName;
            set
            {
                if (value != productName)
                {
                    productName = value;
                    this.OnPropertyChanged();
                }
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString() => $"Window: {this.ProductName}";
    }

    //Крутой двусторонний биндинг
    public class BidirectionalBinding : IDisposable
    {
        private bool Disposed;
        public BidirectionalBinding(INotifyPropertyChanged first, Expression<Func<object>> firstProperty, INotifyPropertyChanged second, Expression<Func<object>> secondProperty)
        {
            if(firstProperty.Body is MemberExpression firstExpression && secondProperty.Body is MemberExpression secondExpression)
            {
                if(firstExpression.Member is PropertyInfo firstProp && secondExpression.Member is PropertyInfo secondProp)
                {
                    first.PropertyChanged += (sender, e) =>
                    {
                        if(!Disposed)
                        {
                            Console.WriteLine("Name change in first");
                            secondProp.SetValue(second, firstProp.GetValue(first));
                        }
                    };

                    second.PropertyChanged += (sender, e) =>
                    {
                        if (!Disposed)
                        {
                            Console.WriteLine("Name change in second");
                            firstProp.SetValue(first, secondProp.GetValue(second));
                        }
                    };
                }
            }
        }

        public void Dispose()
        {
            this.Disposed = true;
        }
    }
}
