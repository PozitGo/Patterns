using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class HtmlBuilder 
    {
        private readonly string rootName;
        protected HtmlElement root = new HtmlElement();

        public HtmlBuilder(string rootName)
        {
            this.rootName = rootName;
            root.Name = rootName;
        }

        public HtmlBuilder AddChiled(string chiledName, string childText)
        {
            var e = new HtmlElement(chiledName, childText);
            root.Elements.Value.Add(e);
            return this;
        }

        public HtmlElement Build() => root;
        public override string ToString() => root.ToString();

        public void Clear()
        {
            root = new HtmlElement 
            {
                Name = rootName,    
            };   
        }

        public static implicit operator HtmlElement(HtmlBuilder builder)
        {
            return builder.root; 
        }
    }
}
