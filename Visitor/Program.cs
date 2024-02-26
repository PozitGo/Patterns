using System.Text;
using Visitor.DoubleDispatch;
using Visitor.Reflective;
using Visitor.Work;

namespace Visitor
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("\nIntrusiveVisitor");

            var IntrusiveExpression = new Intrusive.AdditionalExpression(new Intrusive.DoubleExpression(1), new Intrusive.AdditionalExpression(new Intrusive.DoubleExpression(2), new Intrusive.DoubleExpression(3)));
            var sbIntrusive = new StringBuilder();

            IntrusiveExpression.Print(sbIntrusive);
            Console.WriteLine(sbIntrusive);

            //----------------------------------------------------

            Console.WriteLine("\nReflectiveVisitor");

            var ReflectiveExpression = new Reflective.AdditionalExpression(new Reflective.DoubleExpression(1), new Reflective.AdditionalExpression(new Reflective.DoubleExpression(2), new Reflective.DoubleExpression(3)));
            var sbReflective = new StringBuilder();

            Reflective.ExpressionPrinter.Print(ReflectiveExpression, sbReflective);
            Console.WriteLine(sbReflective);

            //----------------------------------------------------

            Console.WriteLine("\nDoubleDispatchVisitor");

            var DoubleDispatchExpression = new DoubleDispatch.AdditionalExpression(new DoubleDispatch.DoubleExpression(1), new DoubleDispatch.AdditionalExpression(new DoubleDispatch.DoubleExpression(2), new DoubleDispatch.DoubleExpression(3)));
            var expressionPrinter = new DoubleDispatch.ExpressionPrinter();
            expressionPrinter.Visit(DoubleDispatchExpression);
            Console.WriteLine(expressionPrinter);

            var Calc = new DoubleDispatch.ExpressionCalculator();
            Calc.Visit(DoubleDispatchExpression);
            Console.WriteLine($"{expressionPrinter} = {Calc.Result}");

            //----------------------------------------------------


            Console.WriteLine("\nDynamicVisitor");

            var DynamicExpression = new Dynamic.AdditionalExpression(new Dynamic.DoubleExpression(1), new Dynamic.AdditionalExpression(new Dynamic.DoubleExpression(2), new Dynamic.DoubleExpression(3)));
            var DynamicExpressionPrinter = new Dynamic.ExpressionPrinter();
            DynamicExpressionPrinter.Visit(DynamicExpression);
            Console.WriteLine(expressionPrinter);

            //----------------------------------------------------

            Console.WriteLine("\nAcyclicVisitor");

            var AcyclicExpression = new Acyclic.AdditionalExpression(new Acyclic.DoubleExpression(1), new Acyclic.AdditionalExpression(new Acyclic.DoubleExpression(2), new Acyclic.DoubleExpression(3)));
            var AcyclicExpressionPrinter = new Acyclic.ExpressionPrinter();
            AcyclicExpressionPrinter.Visit(AcyclicExpression);
            Console.WriteLine(expressionPrinter);

            //----------------------------------------------------

            Console.WriteLine("\nDoubleDispatchVisitor - (Work)");

            var WorkExpression = new MultiplicationExpression(
            new AdditionExpression(new Value(2), new Value(3)),
            new AdditionExpression(new Value(4), new Value(5)));

            var printer = new Work.ExpressionPrinter();
            WorkExpression.Accept(printer);

            Console.WriteLine(printer);

        }
    }
}
