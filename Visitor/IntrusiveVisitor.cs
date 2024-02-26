using System.Text;

namespace Visitor.Intrusive
{
    public abstract class Expression
    {
        //Intrusive
        public abstract void Print(StringBuilder sb);
    }

    public class DoubleExpression : Expression
    {
        private double value;

        public DoubleExpression(double value)
        {
            this.value = value;
        }

        //Intrusive
        public override void Print(StringBuilder sb) => sb.Append(value);
    }

    public class AdditionalExpression : Expression
    {
        private Expression left, right;

        public AdditionalExpression(Expression left, Expression right)
        {
            this.left = left;
            this.right = right;
        }

        //Intrusive
        public override void Print(StringBuilder sb)
        {
            sb.Append("(");
            left.Print(sb);
            sb.Append("+");
            right.Print(sb);
            sb.Append(")");
        }
    }

    //Intrusive, нарушает принцип открытости-закрытости, подразумевает добавление метода или чего-то ещё в главный абстрактный класс и описать реализацию во всех его наследниках

}
