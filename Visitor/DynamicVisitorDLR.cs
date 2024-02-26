using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor.Dynamic
{
    public interface IExpressionVisitor
    {
        void Visit(DoubleExpression expression);
        void Visit(AdditionalExpression expression);
    }
    public abstract class Expression
    {
        public abstract void Accept(IExpressionVisitor visitor);
    }

    public class DoubleExpression : Expression
    {
        public double value;

        public DoubleExpression(double value)
        {
            this.value = value;
        }

        public override void Accept(IExpressionVisitor visitor) => visitor.Visit(this);
    }

    public class AdditionalExpression : Expression
    {
        public Expression Left, Right;

        public AdditionalExpression(Expression left, Expression right)
        {
            this.Left = left;
            this.Right = right;
        }

        public override void Accept(IExpressionVisitor visitor) => visitor.Visit(this);
    }

    public class ExpressionCalculator : IExpressionVisitor
    {
        public double Result;
        public void Visit(DoubleExpression expression)
        {
            this.Result = expression.value;
        }

        public void Visit(AdditionalExpression expression)
        {
            expression.Left.Accept(this);
            var a = this.Result;
            expression.Right.Accept(this);
            var b = this.Result;

            this.Result = a + b;
        }
    }

    public class ExpressionPrinter : IExpressionVisitor
    {
        private StringBuilder stringBuilder = new();
        public void Visit(DoubleExpression expression)
        {
            stringBuilder.Append(expression.value);
        }

        //dynamic на этапе выполнения ищет метод Visit который принимает получавшийся тип (expression.Left - DoubleExpression) в принимаемых параметрах и динамически его вызывает, нет статических проверок и есть вероятность ошибок, просаживает производительность
        public void Visit(AdditionalExpression expression)
        {
            stringBuilder.Append("(");
            Visit((dynamic)expression.Left); //DoubleExpression
            stringBuilder.Append("+");
            Visit((dynamic)expression.Right);
            stringBuilder.Append(")");
        }

        public override string ToString() => stringBuilder.ToString();
    }
}
