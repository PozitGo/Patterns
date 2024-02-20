using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public class GraphicObject
    {
        public virtual string? Name { get; set; } = "Group";
        public string? Color;

        private Lazy<List<GraphicObject>> children = new(() => new List<GraphicObject>());
        public List<GraphicObject> Children => children.Value;

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            Print(stringBuilder, 0);
            return stringBuilder.ToString();
        }

        private void Print(StringBuilder stringBuilder, int depth)
        {
            stringBuilder.Append(new string('*', depth)).Append(string.IsNullOrWhiteSpace(Color) ? string.Empty : Color).AppendLine(Name);

            foreach (var child in Children)
            {
                child.Print(stringBuilder, depth + 1);
            }
        }
    }

    public class Circle: GraphicObject
    {
        public override string? Name { get; set; } = "Circle";
    }
    public class  Square: GraphicObject
    {
        public override string? Name { get; set; } = "Square";
    }

}
