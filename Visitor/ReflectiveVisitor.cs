using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor.Reflective
{
    public abstract class Expression
    {

    }

    public class DoubleExpression : Expression
    {
        public double value;

        public DoubleExpression(double value)
        {
            this.value = value;
        }
    }

    public class AdditionalExpression : Expression
    {
        public Expression Left, Right;

        public AdditionalExpression(Expression left, Expression right)
        {
            this.Left = left;
            this.Right = right;
        }
    }

    //Visitor
    public class ExpressionPrinter
    {
        public static void Print(Expression e, StringBuilder sb)
        {
            if(e is DoubleExpression de)
            {
                sb.Append(de.value);
            }
            else if(e is AdditionalExpression ae)
            {
                sb.Append("(");
                ExpressionPrinter.Print(ae.Left, sb);
                sb.Append("+");
                ExpressionPrinter.Print(ae.Right, sb);
                sb.Append(")");
            }
        }
    }

}
