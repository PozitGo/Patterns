using System.Text;

namespace Flyweight
{
    //Дорогая версия в виде озу
    public class FormattedText
    {
        private readonly string plainText;
        private readonly bool[] capitalize;

        public FormattedText(string plainText)
        {
            this.plainText = plainText;
            this.capitalize = new bool[this.plainText.Length];

        }

        public void Capitalize(int start, int end)
        {
            for (int i = start; i <= end; ++i)
            {
                capitalize[i] = true;
            }
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < plainText.Length; i++)
            {
                var c = plainText[i];
                stringBuilder.Append(capitalize[i] ? Char.ToUpper(c) : c);
            }

            return stringBuilder.ToString();
        }
    }

    //Дешевая версия в видео озу
    public class BetterFormattedText
    {
        private readonly string plainText;
        private readonly List<TextRange> formatting = new();

        public BetterFormattedText(string plainText)
        {
            this.plainText = plainText;
        }

        public TextRange GetRange(int Start, int End)
        {
            var range = new TextRange { Start = Start, End = End };
            formatting.Add(range);

            return range;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            for (int i = 0; i < plainText.Length; i++)
            {
                char c = plainText[i];

                foreach (var range in formatting)
                {
                    if(range.Covers(i) && range.Capitalize)
                    {
                        c = char.ToUpperInvariant(c);
                    }
                }

                stringBuilder.Append(c);
            }

            return stringBuilder.ToString();
        }

        public class TextRange
        {
            public int Start, End;
            public bool Capitalize, Bold, Italic;

            public bool Covers(int Position) => (Position >= Start && Position <= End);
        }
    }
}
