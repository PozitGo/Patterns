using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor.Work
{
    public abstract class ExpressionVisitor
    {
        public abstract void Visit(Value expression);
        public abstract void Visit(Expression expression);
        public abstract void Visit(AdditionExpression expression);
        public abstract void Visit(MultiplicationExpression expression);
    }

    public abstract class Expression
    {
        public abstract void Accept(ExpressionVisitor ev);
    }

    public class Value : Expression
    {
        public readonly int TheValue;

        public Value(int value)
        {
            TheValue = value;
        }

        public override void Accept(ExpressionVisitor ev) => ev.Visit(this);

        // todo
    }

    public class AdditionExpression : Expression
    {
        public readonly Expression LHS, RHS;

        public AdditionExpression(Expression lhs, Expression rhs)
        {
            LHS = lhs;
            RHS = rhs;
        }

        public override void Accept(ExpressionVisitor ev) => ev.Visit(this);

        // todo
    }

    public class MultiplicationExpression : Expression
    {
        public readonly Expression LHS, RHS;

        public MultiplicationExpression(Expression lhs, Expression rhs)
        {
            LHS = lhs;
            RHS = rhs;
        }

        public override void Accept(ExpressionVisitor ev) => ev.Visit(this);

        // todo
    }

    public class ExpressionPrinter : ExpressionVisitor
    {
        private StringBuilder sb = new();

        public override void Visit(Value value) => sb.Append(value.TheValue);

        public override void Visit(Expression expression)
        {
            Console.WriteLine("Вы не определили реализацию типа по этому он не будет обработан.");
        }

        public override void Visit(AdditionExpression ae)
        {
            sb.Append("(");
            ae.LHS.Accept(this);
            sb.Append("+");
            ae.RHS.Accept(this);
            sb.Append(")");
        }

        public override void Visit(MultiplicationExpression me)
        {
            me.LHS.Accept(this);
            sb.Append("*");
            me.RHS.Accept(this);
        }

        public override string ToString() => sb.ToString();

    }
}
