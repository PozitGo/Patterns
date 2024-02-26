using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.Static
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

    //За счёт generic становится статическим
    public class TextProcessor<LS> where LS : IListStrategy, new()
    {
        private StringBuilder sb = new StringBuilder();
        private LS listStrategy = new();

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
