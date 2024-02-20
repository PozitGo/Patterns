using System.Text;

namespace Builder
{
    public class HtmlElement
    {
        public string? Name, Text;
        public Lazy<List<HtmlElement>> Elements;
        private const int indentSize = 2;

        public HtmlElement()
        {
            Elements = new Lazy<List<HtmlElement>>();
        }

        public HtmlElement(string Name, string Text)
        {
            this.Name = Name;
            this.Text = Text;
            Elements = new Lazy<List<HtmlElement>>();
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }

        public static HtmlBuilder Create(string Name) => new HtmlBuilder(Name);

        private string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ', indentSize * indent);
            sb.Append($"{i}<{Name}>\n");

            if (!string.IsNullOrWhiteSpace(Text))
            {
                sb.Append(new string(' ', indentSize * (indent + 1)));
                sb.Append(Text);
                sb.Append("\n");
            }

            foreach (var e in Elements.Value)
            {
                sb.Append(e.ToStringImpl(indent + 1));
            }

            sb.Append($"{i}</{Name}>\n");
            return sb.ToString();
        }
    }
}
