using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor.Acyclic
{
    public interface IVisitor<TVisitable>
    {
        void Visit(TVisitable obj);   
    }

    public interface IVisitor { } //Marker interface

    public abstract class Expression
    {
        public virtual void Accept(IVisitor visitor)
        {
            if(visitor is IVisitor<Expression> typed)
            {
                typed.Visit(this);
            }
        }
    }

    public class DoubleExpression : Expression
    {
        public double Value;

        public DoubleExpression(double Value)
        {
            this.Value = Value;
        }

        public override void Accept(IVisitor visitor)
        {
            if (visitor is IVisitor<DoubleExpression> typed)
            {
                typed.Visit(this);
            }
        }
    }

    public class AdditionalExpression : Expression
    {
        #nullable disable
        public Expression Left, Right;

        public AdditionalExpression(Expression Left, Expression Right)
        {
            this.Left = Left;
            this.Right = Right;
        }

        public override void Accept(IVisitor visitor)
        {
            if (visitor is IVisitor<AdditionalExpression> typed)
            {
                typed.Visit(this);
            }
        }
    }

    public class ExpressionPrinter : IVisitor, IVisitor<Expression>, IVisitor<DoubleExpression>, IVisitor<AdditionalExpression> //Все типы которые он поддерживает даже с учетом наследования
    {
        private StringBuilder sb = new StringBuilder(); 

        public void Visit(Expression obj) //Если тип будет наследоваться от Expression но не будет реализован тут, оно попадёт в этот метод где можно об этом сообщить
        {
            
        }

        public void Visit(DoubleExpression obj)
        {
            sb.Append(obj.Value);
        }

        public void Visit(AdditionalExpression obj)
        {
            sb.Append("(");
            obj.Left.Accept(this);
            sb.Append("+");
            obj.Right.Accept(this);
            sb.Append(")");
        }

        public override string ToString() => sb.ToString();
    }
}
