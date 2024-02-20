using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public struct Percentage
    {
        private readonly decimal value;

        public Percentage(decimal value)
        {
            this.value = value;
        }

        public override bool Equals(object? obj) => obj is Percentage percentage && value == percentage.value;

        public override int GetHashCode() => HashCode.Combine(value);

        public static implicit operator Percentage(int value) => value.Persent();
        public static decimal operator *(decimal a, Percentage b) => a * b.value;
        public static Percentage operator +(Percentage a, Percentage b) => new Percentage(a.value + b.value);
        public static decimal operator *(Percentage a, Percentage b) => a.value * b.value;

        public override string ToString()
        {
            return $"{value * 100}%";
        }
    }

    public static class ExtensionMethods
    {
        public static Percentage Persent(this int value) => new Percentage(value / 100.0m);

        public static Percentage Persent(this decimal value) => new Percentage(value / 100.0m);
    }
}
