using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class CodeBuilder 
    {
        private StringBuilder builder = new StringBuilder();
        private int indentLevel = 0;

        public override string ToString()
        {
            return builder.ToString();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            ((ISerializable)builder).GetObjectData(info, context);
        }

        public int EnsureCapacity(int capacity)
        {
            return builder.EnsureCapacity(capacity);
        }


        public CodeBuilder Append(double value)
        {
            builder.Append(value);
            return this;
        }

        public CodeBuilder Append(decimal value)
        {
            builder.Append(value);
            return this;
        }

        public CodeBuilder Append(ushort value)
        {
            builder.Append(value);
            return this;
        }

        public CodeBuilder Append(uint value)
        {
            builder.Append(value);
            return this;
        }

        public CodeBuilder Append(ulong value)
        {
            builder.Append(value);
            return this;
        }

        public CodeBuilder Append(object value)
        {
            builder.Append(value);
            return this;
        }

        public CodeBuilder Append(char[] value)
        {
            builder.Append(value);
            return this;
        }

        public CodeBuilder Insert(int index, string value)
        {
            builder.Insert(index, value);
            return this;
        }

        public CodeBuilder Insert(int index, bool value)
        {
            builder.Insert(index, value);
            return this;
        }

        public CodeBuilder Insert(int index, sbyte value)
        {
            builder.Insert(index, value);
            return this;
        }

        public CodeBuilder Insert(int index, byte value)
        {
            builder.Insert(index, value);
            return this;
        }

        public CodeBuilder Insert(int index, short value)
        {
            builder.Insert(index, value);
            return this;
        }

        public CodeBuilder Insert(int index, char value)
        {
            builder.Insert(index, value);
            return this;
        }

        public CodeBuilder Insert(int index, char[] value)
        {
            builder.Insert(index, value);
            return this;
        }

        public CodeBuilder Insert(int index, char[] value, int startIndex, int charCount)
        {
            builder.Insert(index, value, startIndex, charCount);
            return this;
        }

        public CodeBuilder Insert(int index, int value)
        {
            builder.Insert(index, value);
            return this;
        }

        public CodeBuilder Insert(int index, long value)
        {
            builder.Insert(index, value);
            return this;
        }

        public CodeBuilder Insert(int index, float value)
        {
            builder.Insert(index, value);
            return this;
        }

        public CodeBuilder Insert(int index, double value)
        {
            builder.Insert(index, value);
            return this;
        }

        public CodeBuilder Insert(int index, decimal value)
        {
            builder.Insert(index, value);
            return this;
        }

        public CodeBuilder Insert(int index, ushort value)
        {
            builder.Insert(index, value);
            return this;
        }

        public CodeBuilder Insert(int index, uint value)
        {
            builder.Insert(index, value);
            return this;
        }

        public CodeBuilder Insert(int index, ulong value)
        {
            builder.Insert(index, value);
            return this;
        }

        public CodeBuilder Insert(int index, object value)
        {
            builder.Insert(index, value);
            return this;
        }

        public CodeBuilder AppendFormat(string format, object arg0)
        {
            builder.AppendFormat(format, arg0);
            return this;
        }

        public CodeBuilder AppendFormat(string format, object arg0, object arg1)
        {
            builder.AppendFormat(format, arg0, arg1);
            return this;
        }

        public CodeBuilder AppendFormat(string format, object arg0, object arg1, object arg2)
        {
            builder.AppendFormat(format, arg0, arg1, arg2);
            return this;
        }

        public CodeBuilder AppendFormat(string format, params object[] args)
        {
            builder.AppendFormat(format, args);
            return this;
        }

        public CodeBuilder AppendFormat(IFormatProvider provider, string format, params object[] args)
        {
            builder.AppendFormat(provider, format, args);
            return this;
        }

        public CodeBuilder Replace(string oldValue, string newValue)
        {
            builder.Replace(oldValue, newValue);
            return this;
        }

        public bool Equals(CodeBuilder sb)
        {
            return builder.Equals(sb);
        }

        public CodeBuilder Replace(string oldValue, string newValue, int startIndex, int count)
        {
            builder.Replace(oldValue, newValue, startIndex, count);
            return this;
        }

        public CodeBuilder Replace(char oldChar, char newChar)
        {
            builder.Replace(oldChar, newChar);
            return this;
        }

        public CodeBuilder Replace(char oldChar, char newChar, int startIndex, int count)
        {
            builder.Replace(oldChar, newChar, startIndex, count);
            return this;
        }

        public int Capacity
        {
            get => builder.Capacity;
            set => builder.Capacity = value;
        }

        public int MaxCapacity => builder.MaxCapacity;

        public int Length
        {
            get => builder.Length;
            set => builder.Length = value;
        }

        public char this[int index]
        {
            get => builder[index];
            set => builder[index] = value;
        }
    }
}
