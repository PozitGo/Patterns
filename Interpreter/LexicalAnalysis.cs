using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{

    public interface IElement
    {
        int Value { get; }
    }

    public class Integer : IElement
    {
        public int Value { get; }   

        public Integer(int value) 
        {
            this.Value = value;
        }
    }

    public class BinaryOperation : IElement
    {
        public Type MyType;
        public IElement Left, Right;
        public int Value
        {
            get
            {
                var Data = 0;
                
                switch (MyType)
                {
                    case Type.Addition:
                        Data = Left.Value + Right.Value;
                        break;
                    case Type.Subtraction:
                        Data = Left.Value - Right.Value;
                        break;
                }

                return Data;
            }
        }
        public enum Type
        {
            Addition,
            Subtraction
        }

        public BinaryOperation()
        {
            
        }

        public BinaryOperation(IElement left, IElement right)
        {
            this.Left = left;
            this.Right = right;
        }
    }
    public class Token
    {
        public enum Type
        {
            Integer, Plus, Minus, Lparen, Rparen
        }

        public Type MyType;
        public string Text;

        public Token(Type myType, string Text)
        {
            this.Text = Text;
            this.MyType = myType;
        }

        public override string ToString() => $"`{Text}`";
    }
}
