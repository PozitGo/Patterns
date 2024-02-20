using System.Text;

namespace Coding.Exercise
{
    public class Code
    {
        private string? ClassName;
        private Dictionary<string, string>? Fields;

        public Code(string ClassName)
        {
            this.ClassName = ClassName;
            Fields = new();
        }
        public void AddField(string FieldName, string FieldType) => Fields?.Add(FieldName, FieldType);

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"public class {ClassName}");
            stringBuilder.AppendLine("{");

            foreach (var Field in Fields!)
            {
                stringBuilder.AppendLine($"  public {Field.Value} {Field.Key};");
            }

            stringBuilder.AppendLine("}");

            return stringBuilder.ToString();
        }
    }

    public class CodeBuilder
    {
        private readonly Code code;
        public CodeBuilder(string ClassName)
        {
            code = new Code(ClassName);
        }
        public override string ToString() => code.ToString();
        public CodeBuilder AddField(string FieldName, string FieldType)
        {
            code.AddField(FieldName, FieldType);
            return this;
        }

        public static implicit operator Code(CodeBuilder builder) => builder.code;
    }
}