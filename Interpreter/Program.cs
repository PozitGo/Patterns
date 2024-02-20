using System.Text;

namespace Interpreter
{
    internal class Program
    {
        static List<Token> Lex(string input)
        {
            var result = new List<Token>();

            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case '+':
                        result.Add(new Token(Token.Type.Plus, "+"));
                        break;
                    case '-':
                        result.Add(new Token(Token.Type.Minus, "-"));
                        break;
                    case '(':
                        result.Add(new Token(Token.Type.Lparen, "("));
                        break;
                    case ')':
                        result.Add(new Token(Token.Type.Rparen, ")"));
                        break;
                    default:
                        var sb = new StringBuilder(input[i].ToString());
                        for (int j = i + 1; j < input.Length; ++j)
                        {
                            if (char.IsDigit(input[j]))
                            {
                                sb.Append(input[j]);
                                ++i;
                            }
                            else
                            {
                                result.Add(new Token(Token.Type.Integer, sb.ToString()));
                                break;
                            }
                        }
                        break;
                }
            }

            return result;
        }

        static IElement Parse(IReadOnlyList<Token> tokens)
        {
            var result = new BinaryOperation();
            bool haveLHS = false;

            for (int i = 0; i < tokens.Count; i++)
            {
                var token = tokens[i];

                switch (token.MyType)
                {
                    case Token.Type.Integer:
                        var integer = new Integer(int.Parse(token.Text));

                        if (!haveLHS)
                        {
                            result.Left = integer;
                            haveLHS = true;
                        }
                        else
                        {
                            result.Right = integer;

                        }

                        break;
                    case Token.Type.Plus:
                        result.MyType = BinaryOperation.Type.Addition;
                        break;
                    case Token.Type.Minus:
                        result.MyType = BinaryOperation.Type.Subtraction;
                        break;
                    case Token.Type.Lparen:
                        int j = i + 1;
                        int lparenCount = 1;
                        while (j < tokens.Count && lparenCount > 0)
                        {
                            if (tokens[j].MyType == Token.Type.Lparen) lparenCount++;
                            if (tokens[j].MyType == Token.Type.Rparen) lparenCount--;
                            j++;
                        }

                        var subExpression = tokens.Skip(i + 1).Take(j - i - 2).ToList();
                        var element = Parse(subExpression);
                        if (!haveLHS)
                        {
                            result.Left = element;
                            haveLHS = true;
                        }
                        else
                        {
                            result.Right = element;
                        }
                        i = j - 1; 
                        break;
                }
            }

            return result;
        }
        static void Main(string[] args)
        {
            var input = "(13+4)-(12+1)";

            var tokens = Lex(input);

            Console.WriteLine(string.Join(" ", tokens));


            var parsed = Parse(tokens);
            Console.WriteLine($"{input} = {parsed.Value}");
        }
    }
}
