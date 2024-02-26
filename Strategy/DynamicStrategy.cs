using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public enum OutputFormat
    {
        Markdown, Html
    }

    public interface IListStrategy
    {
        void Start(StringBuilder sb);
        void End(StringBuilder sb);
        void AddListItem(StringBuilder sb, string item);
    }

    public class MarkdownListStrategy : IListStrategy
    {
        public void Start(StringBuilder sb)
        {
        }
        public void End(StringBuilder sb)
        {
        }
        public void AddListItem(StringBuilder sb, string item)
        {
            sb.AppendLine($" * {item}");
        }
    }

    public class HtmlListStrategy : IListStrategy
    {
        public void Start(StringBuilder sb) => sb.AppendLine("<ul>");

        public void End(StringBuilder sb) => sb.AppendLine("</ul>");

        public void AddListItem(StringBuilder sb, string item)
        {
            sb.AppendLine($"  <li>{item}</li>");
        }
    }

    public class TextProcessor
    {
        private StringBuilder sb = new StringBuilder();
        private IListStrategy listStrategy;

        public void SetOutputFormat(OutputFormat format)
        {
            switch (format)
            {
                case OutputFormat.Html:
                    listStrategy = new HtmlListStrategy();
                    break;
                case OutputFormat.Markdown:
                    listStrategy = new MarkdownListStrategy();
                    break;
                default: 
                    throw new ArgumentOutOfRangeException(nameof(format), format, null);
            }
        }

        public StringBuilder Clear() => sb.Clear();
        public override string ToString() => sb.ToString();

        //html -> <ul><li>hello</li></ul>
        //* hello
        //* world
        public void AppendList(IEnumerable<string> items)
        {
            listStrategy.Start(sb);

            foreach (string item in items)
            {
                listStrategy.AddListItem(sb, item);
            }

            listStrategy.End(sb);
        }
    }
}
